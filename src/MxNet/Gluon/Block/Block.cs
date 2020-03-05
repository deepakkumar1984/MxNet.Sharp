using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MxNet.Gluon
{
    public abstract class Block
    {
        public delegate void Hook(Block block, NDArrayOrSymbol input);

        public delegate void ApplyFn(Block block);

        public string Prefix
        {
            get;
            private set;
        }

        public virtual ParameterDict Params { get; private set; }

        public string Name { get; set; }

        public _BlockScope NameScope
        {
            get
            {
                return _scope;
            }
        }

        internal _BlockScope _scope;
        internal SortedDictionary<string, Block> _childrens;
        internal Dictionary<string, Parameter> _reg_params;
        internal SortedDictionary<int, Hook> _forward_hooks;
        internal SortedDictionary<int, Hook> _forward_pre_hooks;

        public Block(string prefix, ParameterDict @params)
        {
            (Prefix, Params) = _BlockScope.Create(prefix, @params, Alias());
            Name = prefix != null && prefix.EndsWith("_") ? prefix.Substring(0, prefix.Length - 1) : prefix;
            _scope = new _BlockScope(this);
            _childrens = new SortedDictionary<string, Block>();
            _reg_params = new Dictionary<string, Parameter>();
            _forward_hooks = new SortedDictionary<int, Hook>();
            _forward_pre_hooks = new SortedDictionary<int, Hook>();
        }

        public void SetAttr(string name, Block value)
        {
            RegisterChild(value, name);
        }

        public void SetAttr(string name, Parameter value)
        {
            if (_reg_params.ContainsKey(name))
                throw new Exception("Overriding Parameter attribute %s is not allowed. " +
                                "If you want to share parameters between blocks, please set " +
                                "'params' at Block construction instead.");

            _reg_params[name] = value;
        }

        public object this[string name]
        {
            set
            {
                if(value is Parameter)
                    _reg_params[name] = (Parameter)value;

                if (value is Block)
                    RegisterChild((Block)value);
            }
        }

        public virtual string Alias()
        {
            return this.GetType().Name.ToLower();
        }

        public ParameterDict CollectParams(string select = null)
        {
            ParameterDict ret = new ParameterDict(Params.Prefix);
            if(string.IsNullOrWhiteSpace(select))
            {
                ret.Update(Params);
            }
            else
            {
                var pattern = new Regex(select);
                ParameterDict matchedParams = new ParameterDict();
                foreach (var item in Params.Items())
                {
                    if (pattern.IsMatch(item.Key))
                        matchedParams[item.Key] = item.Value;
                }

                ret.Update(matchedParams);
            }

            foreach (var item in _childrens.Values)
            {
                ret.Update(item.CollectParams(select));
            }

            return ret;
        }

        private ParameterDict CollectParamsWithPrefix(string prefix = "")
        {
            if(!string.IsNullOrWhiteSpace(prefix))
            {
                prefix += ".";
            }

            ParameterDict ret = new ParameterDict();

            foreach (var item in Params.Items())
            {
                ret[prefix + item.Key] = item.Value;
            }

            foreach (var item in _childrens.Values)
            {
                ret.Update(item.CollectParamsWithPrefix(prefix + item.Name));
            }

            return ret;
        }

        public void SaveParameters(string filename)
        {
            NDArrayDict arg_dict = new NDArrayDict();
            var collected_params = CollectParamsWithPrefix();

            foreach (var item in Params.Items())
            {
                arg_dict[item.Key] = item.Value.Reduce();
            }

            NDArray.Save(filename, arg_dict);
        }

        public void LoadParameters(string filename, Context ctx = null, bool allow_missing = false,
                        bool ignore_extra = false, bool cast_dtype = false, string dtype_source = "current")
        {
            LoadParameters(filename, new Context[] { ctx }, allow_missing, ignore_extra, cast_dtype, dtype_source);
        }

        public void LoadParameters(string filename, Context[] ctx= null, bool allow_missing= false,
                        bool ignore_extra= false, bool cast_dtype= false, string dtype_source= "current")
        {
            NDArrayDict loaded = new NDArrayDict();
            var collected_params = CollectParamsWithPrefix();
            NDArray.Load(filename, out loaded);

            if (loaded == null && collected_params == null)
                return;

            if (!loaded.Keys.Any(x => (x.Contains("."))))
            {
                loaded = null;
                CollectParams().Load(filename, ctx, allow_missing, ignore_extra, Prefix, cast_dtype: cast_dtype, dtype_source: dtype_source);
                return;
            }

            if (!allow_missing)
            {
                foreach (var name in Params.Keys())
                {
                    if (!loaded.Contains(name))
                        throw new Exception(string.Format("Parameter '{0}' is missing in file '{1}'", name, filename));
                }
            }

            foreach (var name in loaded.Keys)
            {
                if(!ignore_extra && !Params.Contains(name))
                    throw new Exception(string.Format("Parameter '{0}' loaded from file {1} is not present in ParameterDict", name, filename));

                if(Params.Contains(name))
                    Params[name].LoadInit(loaded[name], ctx, cast_dtype: cast_dtype, dtype_source: dtype_source);
            }
        }

        public virtual void RegisterChild(Block block, string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                name = _childrens.Count.ToString();

            _childrens[name] = block;
        }

        public HookHandle RegisterForwardPreHook(Hook hook)
        {
            var handle = new HookHandle();
            handle.Attach(_forward_pre_hooks, hook);
            return handle;
        }

        public HookHandle RegisterForwardHook(Hook hook)
        {
            var handle = new HookHandle();
            handle.Attach(_forward_hooks, hook);
            return handle;
        }

        public Block Apply(ApplyFn fn)
        {
            foreach (var cld in _childrens.Values)
            {
                cld.Apply(fn);
            }

            fn(this);

            return this;
        }

        public void Initialize(Initializer init= null, Context[] ctx= null, bool verbose= false, bool force_reinit= false)
        {
            init = init ?? new Uniform();
            CollectParams().Initialize(init, ctx, verbose, force_reinit);
        }

        public virtual void Hybridize(bool active = true, bool static_alloc = false, bool static_shape = false)
        {
            foreach (var cld in _childrens.Values)
            {
                cld.Hybridize(active, static_alloc, static_shape);
            }
        }

        public virtual void Cast(DType dtype)
        {
            foreach (var item in _childrens.Values)
            {
                item.Cast(dtype);
            }

            foreach (var item in Params.Items())
            {
                item.Value.Cast(dtype);
            }
        }

        public virtual NDArrayOrSymbol Call(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            foreach (var hook in _forward_pre_hooks.Values)
            {
                hook(this, x);
            }

            var @out = Forward(x, args);

            foreach (var hook in _forward_hooks.Values)
            {
                hook(this, @out);
            }

            return @out;
        }

        public abstract NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args);

        public virtual void Summary(NDArrayList inputs)
        {
            //ToDo: Implement Summmary
            foreach (var item in inputs)
            {
                
            }
        }

        internal static (List<NDArrayOrSymbol[]>, List<int>) Flatten(NDArrayOrSymbol[] args, string inout_str)
        {
            List<NDArrayOrSymbol[]> flat = new List<NDArrayOrSymbol[]>();
            List<int> fmts = new List<int>();
            foreach (var arg in args)
            {
                if(arg.IsNDArray)
                {
                    flat.Add(new NDArrayOrSymbol[] { arg.NdX });
                    fmts.Add(1);
                }
                else if(arg.IsSymbol)
                {
                    int len = arg.SymX.ListOutputs().Count;
                    flat.Add(new NDArrayOrSymbol[] { arg.SymX });
                    fmts.Add(len);
                }
            }

            return (flat, fmts);
        }

        internal static (NDArrayOrSymbol[], NDArrayOrSymbol[]) Regroup(List<NDArrayOrSymbol[]> args, List<int> fmt)
        {
            List<NDArrayOrSymbol> ret = new List<NDArrayOrSymbol>();
            List<NDArrayOrSymbol> args_ret = new List<NDArrayOrSymbol>();

            foreach (var i in fmt)
            {
                if (i == 0)
                {
                    ret.AddRange(args[0]);
                    foreach (var item in args.Skip(1))
                    {
                        args_ret.AddRange(item);
                    }

                    continue;
                }

                for (int j = 0; j < i; j++)
                    ret.AddRange(args[j]);

                for (int j = i; j < args.Count; j++)
                    args_ret.AddRange(args[j]);
            }

            return (ret.ToArray(), args_ret.ToArray());
        }

        internal static string CommonPrefix(string[] names)
        {
            if (names == null)
                return "";

            var prefix = names[0];
            foreach (var name in names)
            {
                int i = 0;
                while (i < prefix.Length && i < name.Length && prefix.ToList()[0] == name.ToList()[0])
                    i++;

                prefix = prefix.Substring(0, i);
            }

            return prefix;
        }

        internal static (DType[], DType[]) InferParamTypes(Symbol[] in_params, Symbol out_params, string[] arg_params, string[] aux_params, DType default_dtype= null)
        {
            DType[] arg_types = null;
            DType[] aux_types = null;
            DType[] _ = null;

            var input_sym_names = in_params.Select(x => x.Name).ToArray();
            List<DType> input_sym_arg_types = new List<DType>();
            bool can_infer_input_type = true;
            foreach (var in_param in in_params)
            {
                var input_sym_arg_type = in_param.InferType().Item1;
                if (input_sym_arg_type != null || input_sym_arg_type.Length < 1)
                {
                    can_infer_input_type = false;
                    break;
                }
                else
                {
                    input_sym_arg_types.Add(input_sym_arg_type[0]);
                }
            }

            if(can_infer_input_type)
            {
                Dictionary<string, DType> @params = new Dictionary<string, DType>();
                int i = 0;
                foreach (var k in input_sym_names)
                {
                    @params.Add(k, input_sym_arg_types[i]);
                    i++;
                }

                try
                {
                    (arg_types, _, aux_types) = out_params.InferType(@params);
                }
                catch(MXNetException ex)
                {
                    arg_types = null;
                    aux_types = null;
                }
            }

            if(arg_types == null || arg_types.Length != arg_params.Length)
            {
                arg_types = new DType[arg_params.Length];
                for(int i = 0;i<arg_params.Length; i++)
                {
                    arg_types[i] = default_dtype;
                }
            }

            if (aux_types == null || aux_types.Length != arg_params.Length)
            {
                aux_types = new DType[arg_params.Length];
                for (int i = 0; i < arg_params.Length; i++)
                {
                    aux_types[i] = default_dtype;
                }
            }

            return (arg_types, aux_types);
        }
    }
}
