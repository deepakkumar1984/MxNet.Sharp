using System;
using System.Collections.Generic;
using System.Linq;

namespace MxNet.Gluon
{
    public class SymbolBlock : HybridBlock
    {
        public SymbolBlock(Symbol[] outputs, Symbol[] inputs, ParameterDict @params = null)
            : base("", new ParameterDict("", @params))
        {
            Symbol[] syms = null;
            Symbol @out = null;

            var (s, _in_format) = Flatten(inputs.ToList().ToNDArrayOrSymbols(), "input");
            var (o, _out_format) = Flatten(outputs.ToList().ToNDArrayOrSymbols(), "output");
            syms = s.ToList().ToSymbols();
            @out = Symbol.Group(o.ToList().ToSymbols());

            List<string> input_names = new List<string>();
            foreach (var item in syms)
            {
                if (item.ListOutputs().Count != 1)
                    throw new Exception($"Input symbols must be variable, but {item.Name} is an output of operators");

                if (input_names.Contains(item.Name))
                    continue;

                input_names.Add(item.Name);
            }

            //ToDo: check if any symbol is row_sparse

            var arg_params = @out.ListArguments().ToArray();
            var aux_params = @out.ListAuxiliaryStates().ToArray();
            var (arg_types, aux_types) = InferParamTypes(syms, @out, arg_params, aux_params);

            for(int i = 0;i< arg_params.Length;i++)
            {
                var arg = arg_params[i];
                if(!input_names.Contains(arg))
                {
                    Params.Get(arg, OpGradReq.Null, allow_deferred_init: true, dtype: arg_types[i]);
                }
            }

            _cached_graph = (syms, @out);
            int len_prefix = CommonPrefix(Params.Keys()).Length;
            _reg_params = new Dictionary<string, Parameter>();
            foreach (var item in Params)
            {
                _reg_params.Add(item.Key.Remove(0, len_prefix), item.Value);
            }
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            return x;
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol x, NDArrayOrSymbol[] args)
        {
            if(x.IsNDArray)
            {
                return CallCachedOp(args.ToList().ToNDArrays())[0];
            }

            int[] in_fmt = null;
            var inputs = new List<NDArrayOrSymbol>();
            inputs.Add(x);
            inputs.AddRange(args);

            (args, in_fmt) = Flatten(inputs.ToArray(), "input");
            if (in_fmt != _in_format.ToArray())
                throw new Exception("Invalid input format");

            var ret = _cached_graph.Value.Item2.Shallowcopy();
            Dictionary<string, Symbol> composeArgs = new Dictionary<string, Symbol>();
            for(int i = 0;i< _cached_graph.Value.Item1.Length;i++)
            {
                composeArgs.Add(_cached_graph.Value.Item1[0].Name, args[i]);
            }

            ret.Compose(composeArgs);

            return Regroup(new List<NDArrayOrSymbol[]>() { new NDArrayOrSymbol[] { ret } }, _out_format.ToList()).Item1[0];
        }

        public static SymbolBlock Imports(string symbol_file, string[] input_names, string param_file = null,
            Context[] ctx = null)
        {
            Symbol sym = Symbol.Load(symbol_file);
            Symbol[] inputs = null;
            if (string.IsNullOrWhiteSpace(param_file))
                inputs = input_names.Select(x => (Symbol.Var(x, dtype: DType.Float32))).ToArray();
            else
                inputs = input_names.Select(x => (Symbol.Var(x))).ToArray();

            var ret = new SymbolBlock(new Symbol[] { sym }, inputs);

            if(!string.IsNullOrWhiteSpace(param_file))
            {
                var p = ret.CollectParams();
                p.Load(param_file, ctx: ctx, cast_dtype: true, dtype_source: "saved");
            }

            return ret;
        }

        public override void ClearCachedOp()
        {
            var tmp = _cached_graph;
            base.ClearCachedOp();
            _cached_graph = tmp;
        }

        public override void Cast(DType dtype)
        {
            ClearCachedOp();
            base.Cast(dtype);
        }
    }
}