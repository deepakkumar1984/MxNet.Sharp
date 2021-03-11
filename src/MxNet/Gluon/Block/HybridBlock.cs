/*****************************************************************************
   Copyright 2018 The MxNet.Sharp Authors. All Rights Reserved.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;

namespace MxNet.Gluon
{
    public class CachedOpArg
    {
        public int Index;
        public bool IsArg;
        public Parameter Param;

        public CachedOpArg(int i)
        {
            IsArg = true;
            Index = i;
        }

        public CachedOpArg(Parameter i)
        {
            IsArg = false;
            Param = i;
        }
    }

    public class HybridBlock : Block
    {
        internal CachedOp _cached_op;
        internal readonly List<CachedOpArg> _cached_op_args = new List<CachedOpArg>();
        internal readonly Dictionary<string, string> _flags = new Dictionary<string, string>();
        internal bool _called_infer_shape_already;
        internal bool _monitor_all;
        internal string _backend;
        internal Dictionary<object, object> _backend_opts;
        internal Action<string, string, NDArray> _callback;
        internal bool _v2;
        internal bool _partition_if_dynamic;
        internal bool _first_forward;

        public HybridBlock() : base()
        {
            this._v2 = true;
            this._cached_graph = (null, null);
            this._cached_op = null;
            this._out_format = null;
            this._in_format = null;
            this._called_infer_shape_already = false;
            this._active = false;
            this._flags = new Dictionary<string, string>();
            this._callback = null;
            this._monitor_all = false;
            this._backend = null;
            this._backend_opts = new Dictionary<object, object>();
            this._partition_if_dynamic = true;
            this._first_forward = true;
        }

        public HybridBlock(Dictionary<string, Block> blocks, bool loadkeys = false)
            : this()
        {
            foreach (var item in blocks)
            {
                if(loadkeys)
                    RegisterChild(item.Value, item.Key);
                else
                    RegisterChild(item.Value);
            }
        }

        private (SymbolList, Symbol) GetGraphV1(NDArrayList args)
        {
            if (_cached_graph.Item1 == null)
            {
                var inputs = new SymbolList();
                var (flatten_args, _in_format) = Flatten(args.Select(x => new NDArrayOrSymbol(x)).ToArray(), "input");

                var flatten_inputs = new List<NDArrayOrSymbol[]>();
                var symbol_inputs = new List<Symbol>();
                var cnt = 0;
                var real_arg_num = flatten_args.Select(x => x != null).Count();
                if (real_arg_num == 0)
                {
                    throw new Exception($"All args are None and we do not support such a case.");
                }

                foreach (var arg in flatten_args)
                {
                    Symbol arg_sym;
                    if (arg != null)
                    {
                        if (real_arg_num > 1)
                        {
                            arg_sym = Symbol.Var("datacnt{}");
                        }
                        else
                        {
                            arg_sym = Symbol.Var("data");
                        }

                        cnt += 1;
                        flatten_inputs.Add(new NDArrayOrSymbol[] { arg_sym });
                        symbol_inputs.Add(arg_sym);
                    }
                    else
                    {
                        flatten_inputs.Add(null);
                    }
                }

                var grouped_inputs = Regroup(flatten_inputs, this._in_format).Item1;
                var outputs = new List<NDArrayOrSymbol>();
                using (var _ = new _BlockScope(this))
                {
                    var @params = new SymbolDict();
                    foreach (var item in _reg_params) @params[item.Key] = item.Value.Var();

                    foreach (var input in grouped_inputs)
                        outputs.Add(HybridForward(input, @params.Values.ToNDArrayOrSymbols()));
                }

                var (@out, _out_format) = Flatten(outputs.ToArray(), "output");
                _cached_graph = (inputs.ToArray(), Symbol.Group(@out.ToList().ToSymbols()));
            }

            return _cached_graph;
        }

        private (SymbolList, Symbol)  GetGraphV2(NDArrayList args)
        {
            List<string> arg_names = new List<string>();
            if (_cached_graph.Item1 == null)
            {
                var inputs = new SymbolList();
                var (flatten_args, _in_format) = Flatten(args.Select(x => new NDArrayOrSymbol(x)).ToArray(), "input");
                flatten_args = new NDArrayOrSymbolList((from ele in flatten_args
                                                        select ele != null ? ele.NdX.Detach() : null).ToArray()).ToArray();
                var real_args = (from ele in flatten_args
                                 where ele != null
                                 select ele).ToList();
                if (real_args.Count == 0)
                {
                    throw new Exception("All args are None and we do not support such a case.");
                }
                if (real_args.Count == 1)
                {
                    arg_names = new List<string> { "data" };
                }
                else
                {
                    for(int i = 0; i<real_args.Count; i++)
                    {
                        arg_names.Add($"data{i}");
                    }
                }

                SymbolList symbol_inputs = new SymbolList();
                for(int i = 0; i< real_args.Count; i++)
                {
                    var name = arg_names[i];
                    var arg = real_args[i];
                    symbol_inputs.Add(Symbol.Var(name));
                }

                DeferredCompute.SetVariable(real_args, symbol_inputs);
                args = Regroup(new List<NDArrayOrSymbol[]> { flatten_args }, this._in_format).Item1;
                NDArrayOrSymbol @out;
                using(var ag = Autograd.Pause())
                {
                    DeferredCompute.Context();
                    @out = base.Call(args.ToNDArrayOrSymbols()[0], args.Length > 1 ? args.ToNDArrayOrSymbols().Skip(1).ToArray() : null);
                }

                var (flatten_out, out_format) = Flatten(new NDArrayOrSymbol[] { @out }, "output");
                this._out_format = out_format.ToList();
                var symbol_outputs = DeferredCompute.GetSymbol(flatten_out);
                this._cached_graph = (symbol_inputs, symbol_outputs);
            }
            return this._cached_graph;
        }

        private (SymbolList, Symbol) GetGraph(NDArrayList args)
        {
            if (_cached_graph.Item1 == null)
            {
                if (!this._v2)
                {
                    return this.GetGraphV1(args);
                }
                else
                {
                    // Gluon 2 based on deferred compute mode
                    return this.GetGraphV2(args);
                }
            }

            return this._cached_graph;
        }

        private void BuildCache(NDArrayList args)
        {
            var (data, @out) = GetGraph(args);
            var data_names = data.Select(x => x.Name).ToArray();
            

            var @params = this.CollectParams().Values().ToDictionary(p => p.Var().Name, p => p);
            var param_serialization_names = this.CollectParams().Items().ToDictionary(_tup_3 => _tup_3.Value.Var().Name, _tup_3 => _tup_3.Key);
            var param_names = new HashSet<string>(@params.Keys).ToArray();

            param_names = MxUtil.Set(@params.Keys.ToList()).ToArray();
            var input_names = @out.ListInputs().ToArray();
            var expected_names = MxUtil.Set(input_names.ToList());
            foreach (var name in expected_names)
                if (!param_names.Contains(name) && !data_names.Contains(name))
                    throw new Exception($"Unknown input to HybridBlock: {name}");

            var used_data_names = new List<string>();
            var unused_data_names = new List<string>();

            var used_param_names = new List<string>();
            var unused_param_names = new List<string>();

            foreach (var name in data_names)
            {
                if (expected_names.Contains(name))
                    used_data_names.Add(name);

                if (!expected_names.Contains(name))
                    unused_data_names.Add(name);
            }

            if (used_data_names.Count != data_names.Length)
                Logger.Warning($"The {string.Join(",", unused_data_names)} input to HybridBlock is not used by any " +
                               "computation. Is this intended?");

            foreach (var name in param_names)
            {
                if (expected_names.Contains(name))
                    used_param_names.Add(name);

                if (!expected_names.Contains(name))
                    unused_param_names.Add(name);
            }

            if (used_param_names.Count != param_names.Length)
                Logger.Warning($"The {string.Join(",", used_param_names)} input to HybridBlock is not used by any " +
                               "computation. Is this intended?");

            var _tup_5 = Flatten(new NDArrayOrSymbolList(args).ToArray(), "input");
            args = _tup_5.Item1;
            try
            {
                foreach (var name in input_names)
                {
                    if (@params.ContainsKey(name)) 
                    {
                        @params[name].Data();
                    }
                }
            }
            catch (Exception ex)
            {
                this.DeferredInferShape(args);
                foreach (var name in input_names)
                {
                    if (@params.ContainsKey(name)) {
                        @params[name].FinishDeferredInit();
                    }
                }
            }

            var arg_dict = new NDArrayDict();
            var aux_dict = new NDArrayDict();
            if (!string.IsNullOrWhiteSpace(this._backend))
            {
                // set context for inputs
                var _tup_6 = GatherTypeCtxInfo(args.ToNDArrayOrSymbols());
                var ctx_set = _tup_6.Item3;
                Context ctx = null;
                if(ctx_set.Length > 0)
                {
                    ctx = ctx_set.Last();
                    ctx_set.ToList().RemoveAt(ctx_set.Length - 1);
                }
                
                // get list of params in the order of out.list_arguments
                var input_shapes = new Dictionary<string, Shape>();
                foreach (var name in @out.ListArguments())
                {
                    if (data_names.keys().Contains(name) && data_names[name] < args.Count)
                    {
                        if (args[data_names[name]] is NDArray)
                        {
                            arg_dict[name] = args[data_names[name]];
                        }
                        else if (args[data_names[name]] is symbol.Symbol && args[data_names[name]].list_attr().Contains("__shape__"))
                        {
                            shape_str = args[data_names[name]].list_attr()["__shape__"];
                            input_shapes[name] = tuple(map(@int, shape_str.strip("()").split(",")));
                        }
                    }
                    else if (params.Contains(name)) {
                        arg_dict[name] = params[name].data();
                    }
                }
                foreach (var name in @out.ListAuxiliaryStates())
                {
                    if (data_names.keys().Contains(name) && data_names[name] < args.Count)
                    {
                        if (args[data_names[name]] is NDArray)
                        {
                            aux_dict[name] = args[data_names[name]];
                        }
                        else if (args[data_names[name]] is symbol.Symbol && args[data_names[name]].list_attr().Contains("__shape__"))
                        {
                            shape_str = args[data_names[name]].list_attr()["__shape__"];
                            input_shapes[name] = tuple(map(@int, shape_str.strip("()").split(",")));
                        }
                    }
                    else if (params.Contains(name)) {
                        aux_dict[name] = params[name].data();
                    }
                }
                // Partition the graph
                @out = @out.OptimizeFor(this._backend, arg_dict, aux_dict, ctx, input_shapes, this._backend_opts);
                //update cached graph with partitioned graph
                if (update_graph)
                {
                    this._cached_graph = (data, @out);
                }
            }

            input_names = @out.ListInputs();

            var data_indices = new List<int>();
            var param_indices = new List<int>();

            for (var i = 0; i < input_names.Length; i++)
            {
                var name = input_names[i];
                if (data_names.Contains(name))
                {
                    data_indices.Add(i);
                    _cached_op_args.Add(new CachedOpArg(data_names.ToList().IndexOf(name)));
                }
                else
                {
                    param_indices.Add(i);
                    _cached_op_args.Add(new CachedOpArg(@params[name]));
                }
            }

            var flags = new Dictionary<string, string>()
            {
                { "data_indices", "[" + string.Join(",", data_indices.Select(i => i.ToString()).ToArray()) + "]" },
                { "param_indices", "[" + string.Join(",", param_indices.Select(i => i.ToString()).ToArray()) + "]" }
            };
            foreach (var item in _flags) flags.Add(item.Key, item.Value);

            _cached_op = new CachedOp(@out, flags);
        }

        private void DeferredInferShape(NDArrayList args)
        {
            try
            {
                InferShape(args);
            }
            catch(Exception ex)
            {
                throw new Exception("Deferred initialization failed because shape cannot be inferred: " + ex.Message);
            }
        }

        internal NDArrayList CallCachedOp(NDArrayList args)
        {
            if (_cached_op == null)
                BuildCache(args);

            var (args_sym, fmt) = Flatten(args.NDArrayOrSymbols, "input");
            _out_format = fmt.ToList();
            args = args_sym.ToList().ToNDArrays();
            var cargs = new List<NDArrayOrSymbol>();
            try
            {
                foreach (var item in _cached_op_args)
                    if (item.IsArg)
                        cargs.Add(args[item.Index]);
                    else
                        cargs.Add(item.Param.Data());
            }
            catch (DeferredInitializationException)
            {
                DeferredInferShape(args);
                cargs.Clear();
                foreach (var item in _cached_op_args)
                    if (item.IsArg)
                    {
                        cargs.Add(args[item.Index]);
                    }
                    else
                    {
                        item.Param.FinishDeferredInit();
                        cargs.Add(item.Param.Data());
                    }
            }

            var @out = _cached_op.Call(cargs.ToNDArrays());
            return Regroup(new List<NDArrayOrSymbol[]> {@out.NDArrayOrSymbols}, _out_format).Item1.ToList()
                .ToNDArrays();
        }

        public virtual void ClearCachedOp()
        {
            _cached_graph = null;
            _cached_op = null;
        }

        public override void RegisterChild(Block block, string name = null)
        {
            if (block is HybridBlock)
                base.RegisterChild(block, name);
            else
                throw new Exception("Children of HybridBlock must also be HybridBlock, " +
                                    $"but {block.Name} has type {block.GetType().Name}. If you are using Sequential, " +
                                    "please try HybridSequential instead.");
        }

        public override void Hybridize(bool active = true, bool static_alloc = false, bool static_shape = false)
        {
            _active = active;
            ClearCachedOp();
            if (active && _forward_hooks != null || _forward_pre_hooks != null)
                Logger.Warning($"{Name} is being hybridized while still having forward hook/pre-hook");

            base.Hybridize(active, static_alloc, static_shape);
        }

        public override void Cast(DType dtype)
        {
            ClearCachedOp();
            base.Cast(dtype);
        }

        private void InterAttrs(string infer_fn, string attr, NDArrayList arguments)
        {
            var (inputs, @out) = GetGraph(arguments);
            var (args, _) = Flatten(arguments.NDArrayOrSymbols, "input");

            if (infer_fn == "infer_shape")
            {
                var args_shape = new Dictionary<string, Shape>();
                var sdict = new Dictionary<string, Shape>();
                for (var i = 0; i < args.Length; i++) args_shape.Add(inputs[i].Name, args[i].NdX.Shape);

                var (arg_attrs, _, aux_attrs) = @out.InferShape(args_shape);
                if (arg_attrs == null)
                    throw new Exception("No Args shape found");

                var arg_names = @out.ListArguments().ToArray();
                for (var i = 0; i < arg_attrs.Length; i++) sdict.Add(arg_names[i], new Shape(arg_attrs[i].Data));

                var aux_names = @out.ListAuxiliaryStates().ToArray();
                for (var i = 0; i < aux_attrs.Length; i++) sdict[aux_names[i]] = aux_attrs[i];

                var collectedValues = CollectParams().Values();
                for (var i = 0; i < collectedValues.Length; i++)
                    collectedValues[i]._shape = sdict[collectedValues[i]._var_name];
            }
            else if (infer_fn == "infer_type")
            {
                var args_shape = new Dictionary<string, DType>();
                var sdict = new Dictionary<string, DType>();
                for (var i = 0; i < args.Length; i++) args_shape.Add(inputs[i].Name, args[i].NdX.DataType);

                var (arg_attrs, _, aux_attrs) = @out.InferType(args_shape);
                if (arg_attrs == null)
                    throw new Exception("No Args shape found");

                var arg_names = @out.ListArguments().ToArray();
                for (var i = 0; i < arg_attrs.Length; i++) sdict.Add(arg_names[i], arg_attrs[i]);

                var aux_names = @out.ListAuxiliaryStates().ToArray();
                for (var i = 0; i < aux_attrs.Length; i++) sdict[aux_names[i]] = aux_attrs[i];

                var collectedValues = CollectParams().Values();
                for (var i = 0; i < collectedValues.Length; i++)
                    collectedValues[i].DataType = sdict[collectedValues[i]._var_name];
            }
        }

        public void InferShape(NDArrayList args)
        {
            InterAttrs("infer_shape", "shape", args);
        }

        public void InferType(NDArrayList args)
        {
            InterAttrs("infer_type", "dtype", args);
        }

        public void Export(string path, int epoch = 0, bool remove_amp_cast = true)
        {
            if (_cached_graph.Item1 == null)
                throw new Exception("Please first call block.hybridize() and then run forward with " +
                                    "this block at least once before calling export.");

            var sym = _cached_graph.Item2;
            sym.Save($"{path}\\symbol.json", remove_amp_cast);

            var arg_names = MxUtil.Set(sym.ListArguments().ToList());
            var aux_names = MxUtil.Set(sym.ListAuxiliaryStates().ToList());

            var arg_dict = new NDArrayDict();
            foreach (var param in CollectParams().Items())
                if (arg_names.Contains(param.Key))
                    arg_dict[$"arg:{param.Key}"] = param.Value.Reduce();
                else if (aux_names.Contains(param.Key)) arg_dict[$"aux:{param.Key}"] = param.Value.Reduce();
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            var @params = new Dictionary<string, NDArrayOrSymbol>();
            var argsList = args.ToList();

            if (x.IsNDArray)
            {
                var ctx = x.NdX.Context;
                var list = args.ToList();
                list.Insert(0, x);

                if (_active) return CallCachedOp(list.ToList().ToNDArrays()).FirstOrDefault();

                try
                {
                    foreach (var p in _reg_params) @params[p.Key] = p.Value.Data(ctx);
                }
                catch (DeferredInitializationException ex)
                {
                    @params.Clear();
                    DeferredInferShape(list.ToList().ToNDArrays());
                    foreach (var p in Params.Items()) p.Value.FinishDeferredInit();

                    foreach (var p in _reg_params) @params[p.Key] = p.Value.Data(ctx);
                }

                argsList.AddRange(@params.Values.ToArray());
                return HybridForward(x, argsList.ToArray());
            }

            foreach (var p in _reg_params) @params[p.Key] = p.Value.Var();

            argsList.AddRange(@params.Values.ToArray());

            return HybridForward(x, argsList.ToArray());
        }

        public virtual NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            return x;
        }
    }
}