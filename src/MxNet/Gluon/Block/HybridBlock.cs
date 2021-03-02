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
        internal bool _active;
        internal (SymbolList, Symbol)? _cached_graph;
        internal CachedOp _cached_op;
        internal readonly List<CachedOpArg> _cached_op_args = new List<CachedOpArg>();
        internal readonly Dictionary<string, string> _flags = new Dictionary<string, string>();
        internal List<int> _in_format;
        internal List<int> _out_format;

        public HybridBlock(string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
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

        private (SymbolList, Symbol) GetGraph(NDArrayList args)
        {
            if (!_cached_graph.HasValue)
            {
                var inputs = new SymbolList();
                var (args_sym, _in_format) = Flatten(args.Select(x => new NDArrayOrSymbol(x)).ToArray(), "input");
                if (args_sym.Length > 1)
                    for (var i = 0; i < args_sym.Length; i++)
                        inputs.Add(Symbol.Variable($"data{i}"));
                else
                    inputs.Add(Symbol.Variable("data"));

                var grouped_inputs = Regroup(new List<NDArrayOrSymbol[]> {inputs.ToNDArrayOrSymbols()},
                    _in_format.ToList()).Item1;

                var @params = new SymbolDict();
                foreach (var item in _reg_params) @params[item.Key] = item.Value.Var();

                var outputs = new List<NDArrayOrSymbol>();

                foreach (var input in grouped_inputs)
                    outputs.Add(HybridForward(input, @params.Values.ToNDArrayOrSymbols()));

                var (@out, _out_format) = Flatten(outputs.ToArray(), "output");
                _cached_graph = (inputs.ToArray(), Symbol.Group(@out.ToList().ToSymbols()));
            }

            return _cached_graph.Value;
        }

        private void BuildCache(NDArrayList args)
        {
            var (data, @out) = GetGraph(args);
            var data_names = data.Select(x => x.Name).ToArray();
            var @params = CollectParams();
            var input_names = @out.ListInputs().ToArray();

            var param_names = MxUtil.Set(@params.Keys().ToList()).ToArray();
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
                    collectedValues[i]._shape = sdict[collectedValues[i].Name];
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
                    collectedValues[i].DataType = sdict[collectedValues[i].Name];
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
            if (!_cached_graph.HasValue)
                throw new Exception("Please first call block.hybridize() and then run forward with " +
                                    "this block at least once before calling export.");

            var sym = _cached_graph.Value.Item2;
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