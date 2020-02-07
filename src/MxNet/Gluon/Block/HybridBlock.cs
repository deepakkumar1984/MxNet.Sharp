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
        private Dictionary<string, NDArray> _flags = new Dictionary<string, NDArray>();
        private List<CachedOpArg> _cached_op_args = new List<CachedOpArg>();
        public HybridBlock(string prefix = null , ParameterDict @params = null) : base(prefix, @params)
        {
          
        }

        private (Symbol[], Symbol) GetGraph(NDArray[] args)
        {
            if(_cached_graph.HasValue)
            {
                List<Symbol> inputs = new List<Symbol>();
                var (args_sym, _in_format) = Flatten(args.Select(x=>(new NDArrayOrSymbol(x))).ToArray(), "input");
                for (int i = 0; i < args_sym.Count; i++)
                {
                    inputs.Add(Symbol.Variable($"data{i}"));
                }

                var grouped_inputs = Regroup(new List<NDArrayOrSymbol[]>() { inputs.ToNDArrayOrSymbols() }, _in_format.ToList()).Item1;

                Dictionary<string, Symbol> @params = new Dictionary<string, Symbol>();
                foreach (var item in reg_params)
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

        private void BuildCache(NDArray[] args)
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

            var flags = new Dictionary<string, NDArray>() { { "data_indices", new NDArray(data_indices.ToArray()) }, { "param_indices", new NDArray(param_indices.ToArray()) } };
            foreach (var item in _flags)
            {
                flags.Add(item.Key, item.Value);
            }

            _cached_op = new CachedOp(@out, flags);
        }

        private void DeferredInferShape(NDArray[] args)
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

        private NDArray[] CallCachedOp(NDArray[] args)
        {
            if (_cached_op == null)
                BuildCache(args);

            var (args_sym, fmt) = Flatten(args.ToList().ToNDArrayOrSymbols(), "input");
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
            catch
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
            return Regroup(new List<NDArrayOrSymbol[]>() { @out.ToList().ToNDArrayOrSymbols() }, _out_format).Item1.ToList().ToNDArrays();
        }

        private void ClearCachedOp()
        {
            _cached_graph = null;
            _cached_op = null;
        }

        public override void RegisterChild(Block block, string name = null)
        {
            throw new NotImplementedException();
        }

        public override void Hybridize(bool active = true, bool static_alloc = false, bool static_shape = false)
        {
            throw new NotImplementedException();
        }

        public override void Cast(DType dtype)
        {
            throw new NotImplementedException();
        }

        private void InterAttrs(string infer_fn, string attr, Symbol[] args) => throw new NotImplementedException();

        public void InferShape(NDArray[] args) => throw new NotImplementedException();

        public void InferType(NDArray[] args) => throw new NotImplementedException();

        public void Export(string path, int epoch = 0, bool remove_amp_cast = true) => throw new NotImplementedException();

        public override NDArray Forward(NDArray input, params NDArray[] args)
        {
            throw new NotImplementedException();
        }

        public abstract NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args);
    }
}
