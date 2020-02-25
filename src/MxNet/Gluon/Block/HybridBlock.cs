using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon
{
    public class CachedOpArg
    {
        public bool IsArg;
        public int Index;
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

    public abstract class HybridBlock : Block
    {
        private (Symbol[], Symbol)? _cached_graph;
        private CachedOp _cached_op;
        private List<int> _out_format;
        private List<int> _in_format;
        private bool _active = false;
        private NDArrayDict _flags = new NDArrayDict();
        private List<CachedOpArg> _cached_op_args = new List<CachedOpArg>();
        public HybridBlock(string prefix = null , ParameterDict @params = null) : base(prefix, @params)
        {
          
        }

        private (Symbol[], Symbol) GetGraph(NDArrayList args)
        {
            if(!_cached_graph.HasValue)
            {
                List<Symbol> inputs = new List<Symbol>();
                var (args_sym, _in_format) = Flatten(args.Select(x=>(new NDArrayOrSymbol(x))).ToArray(), "input");
                if (args_sym.Count > 1)
                {
                    for (int i = 0; i < args_sym.Count; i++)
                    {
                        inputs.Add(Symbol.Variable($"data{i}"));
                    }
                }
                else
                {
                    inputs.Add(Symbol.Variable("data"));
                }

                var grouped_inputs = Regroup(new List<NDArrayOrSymbol[]>() { inputs.ToNDArrayOrSymbols() }, _in_format.ToList()).Item1;

                Dictionary<string, Symbol> @params = new Dictionary<string, Symbol>();
                foreach (var item in _reg_params)
                {
                    @params[item.Key] = item.Value.Var();
                }

                List<NDArrayOrSymbol> outputs = new List<NDArrayOrSymbol>();

                foreach (var input in grouped_inputs)
                {
                    outputs.Add(HybridForward(input, @params.Values.ToList().ToNDArrayOrSymbols()));
                }

                var (@out, _out_format) = Flatten(outputs.ToArray(), "output");
                _cached_graph = (inputs.ToArray(), Symbol.Group(@out[0].ToList().ToSymbols()));
            }

            return _cached_graph.Value;
        }

        private void BuildCache(NDArrayList args)
        {
            var (data, @out) = GetGraph(args);
            var data_names = data.Select(x => (x.Name)).ToArray();
            var @params = CollectParams();
            var input_names = @out.ListArguments().ToArray();

            var param_names = MxUtil.Set(@params.Keys().ToList()).ToArray();
            var expected_names = MxUtil.Set(input_names.ToList());
            foreach (var name in expected_names)
            {
                if (!param_names.Contains(name) && !data_names.Contains(name))
                    throw new Exception($"Unknown input to HybridBlock: {name}");
            }

            List<string> used_data_names = new List<string>();
            List<string> unused_data_names = new List<string>();

            List<string> used_param_names = new List<string>();
            List<string> unused_param_names = new List<string>();

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

            List<int> data_indices = new List<int>();
            List<int> param_indices = new List<int>();

            for (int i = 0; i < input_names.Length; i++)
            {
                string name = input_names[i];
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

            var flags = new NDArrayDict() { { "data_indices", new NDArray(data_indices.ToArray()) }, { "param_indices", new NDArray(param_indices.ToArray()) } };
            foreach (var item in _flags)
            {
                flags.Add(item.Key, item.Value);
            }

            _cached_op = new CachedOp(@out, flags);
        }

        private void DeferredInferShape(NDArrayList args)
        {
            try
            {
                InferShape(args);
            }
            catch
            {
                throw new Exception("Deferred initialization failed because shape cannot be inferred");
            }
        }

        private NDArrayList CallCachedOp(NDArrayList args)
        {
            if (_cached_op == null)
                BuildCache(args);

            var (args_sym, fmt) = Flatten(args.NDArrayOrSymbols, "input");
            args = args_sym[0].ToList().ToNDArrays();
            List<NDArrayOrSymbol> cargs = new List<NDArrayOrSymbol>();
            try
            {
                foreach (var item in _cached_op_args)
                {
                    if (item.IsArg)
                        cargs.Add(args[item.Index]);
                    else
                        cargs.Add(item.Param.Data());
                }
            }
            catch(DeferredInitializationException ex)
            {
                DeferredInferShape(args);
                cargs.Clear();
                foreach (var item in _cached_op_args)
                {
                    if (item.IsArg)
                        cargs.Add(args[item.Index]);
                    else
                    {
                        item.Param.FinishDeferredInit();
                        cargs.Add(item.Param.Data());
                    }
                }
            }

            var @out = _cached_op.Call(cargs.ToNDArrays());
            return Regroup(new List<NDArrayOrSymbol[]>() { @out.NDArrayOrSymbols }, _out_format).Item1.ToList().ToNDArrays();
        }

        private void ClearCachedOp()
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

            if(infer_fn == "infer_shape")
            {
                Dictionary<string, Shape> args_shape = new Dictionary<string, Shape>();
                Dictionary<string, Shape> sdict = new Dictionary<string, Shape>();
                for (int i = 0; i < args[0].Length; i++)
                {
                    args_shape.Add(inputs[i].Name, args[0][i].NdX.Shape);
                }

                var (arg_attrs, _, aux_attrs) = @out.InferShape(args_shape);
                if (arg_attrs == null)
                    throw new Exception("No Args shape found");

                var arg_names = @out.ListArguments().ToArray();
                for(int i = 0;i< arg_attrs.Length;i++)
                {
                    sdict.Add(arg_names[i], new Shape(arg_attrs[i].Data));
                }

                var aux_names = @out.ListAuxiliaryStates().ToArray();
                for (int i = 0; i < aux_attrs.Length; i++)
                {
                    sdict[aux_names[i]] = aux_attrs[i];
                }

                var collectedValues = CollectParams().Values();
                for (int i = 0; i < collectedValues.Length; i++)
                {
                    collectedValues[i]._shape = sdict[collectedValues[i].Name];
                }
            }
            else if (infer_fn == "infer_type")
            {
                Dictionary<string, DType> args_shape = new Dictionary<string, DType>();
                Dictionary<string, DType> sdict = new Dictionary<string, DType>();
                for (int i = 0; i < args[0].Length; i++)
                {
                    args_shape.Add(inputs[i].Name, args[0][i].NdX.DataType);
                }

                var (arg_attrs, _, aux_attrs) = @out.InferType(args_shape);
                if (arg_attrs == null)
                    throw new Exception("No Args shape found");

                var arg_names = @out.ListArguments().ToArray();
                for (int i = 0; i < arg_attrs.Length; i++)
                {
                    sdict.Add(arg_names[i], arg_attrs[i]);
                }

                var aux_names = @out.ListAuxiliaryStates().ToArray();
                for (int i = 0; i < aux_attrs.Length; i++)
                {
                    sdict[aux_names[i]] = aux_attrs[i];
                }

                var collectedValues = CollectParams().Values();
                for (int i = 0; i < collectedValues.Length; i++)
                {
                    collectedValues[i].DataType = sdict[collectedValues[i].Name];
                }
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

            NDArrayDict arg_dict = new NDArrayDict();
            foreach (var param in CollectParams().Items())
            {
                if(arg_names.Contains(param.Key))
                {
                    arg_dict[$"arg:{param.Key}"] = param.Value.Reduce();
                }
                else if (aux_names.Contains(param.Key))
                {
                    arg_dict[$"aux:{param.Key}"] = param.Value.Reduce();
                }
            }
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            Dictionary<string, NDArrayOrSymbol> @params = new Dictionary<string, NDArrayOrSymbol>();
            List<NDArrayOrSymbol> argsList = new List<NDArrayOrSymbol>();
            foreach (var item in args)
            {
                argsList.Add(item);
            }

            if (x.IsNDArray)
            {
                var ctx = x.NdX.context;
                var list = args.ToList();
                list.Insert(0, x);

                if (_active)
                {
                    return CallCachedOp(list.ToList().ToNDArrays()).FirstOrDefault();
                }

                try
                {
                    foreach (var p in _reg_params)
                    {
                        @params[p.Key] = p.Value.Data(ctx);
                    }
                }
                catch (DeferredInitializationException ex)
                {
                    @params.Clear();
                    DeferredInferShape(list.ToList().ToNDArrays());
                    foreach (var p in Params.Items())
                    {
                        p.Value.FinishDeferredInit();
                    }

                    foreach (var p in _reg_params)
                    {
                        @params[p.Key] = p.Value.Data(ctx);
                    }
                }

                return HybridForward(x, @params.Values.ToArray());
            }
            else 
            {
                foreach (var p in _reg_params)
                {
                    @params[p.Key] = p.Value.Var();
                }
            }

            return HybridForward(x, @params.Values.ToArray());
        }

        public abstract NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args);
    }
}
