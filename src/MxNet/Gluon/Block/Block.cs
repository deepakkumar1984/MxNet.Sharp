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
        public delegate void Hook(Block block, NDArray input);

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
                return scope;
            }
        }

        internal _BlockScope scope;
        internal SortedDictionary<string, Block> childrens;
        internal Dictionary<string, Parameter> reg_params;
        internal SortedDictionary<string, Hook> forward_hooks;
        internal SortedDictionary<string, Hook> forward_pre_hooks;

        public Block(string prefix, ParameterDict @params)
        {
            (Prefix, Params) = _BlockScope.Create(prefix, @params, Alias());
            Name = prefix.EndsWith("_") ? prefix.Substring(0, prefix.Length - 1) : prefix;
            scope = new _BlockScope(this);
            childrens = new SortedDictionary<string, Block>();
            reg_params = new Dictionary<string, Parameter>();
            forward_hooks = new SortedDictionary<string, Hook>();
            forward_pre_hooks = new SortedDictionary<string, Hook>();
        }

        public override string ToString()
        {
            return Name;
        }

        public void SetAttr(string name, Block value)
        {
            RegisterChild(value, name);
        }

        public void SetAttr(string name, Parameter value)
        {
            if (reg_params.ContainsKey(name))
                throw new Exception("Overriding Parameter attribute %s is not allowed. " +
                                "If you want to share parameters between blocks, please set " +
                                "'params' at Block construction instead.");

            reg_params[name] = value;
        }

        public virtual string Alias()
        {
            return this.GetType().Name.ToLower();
        }

        public ParameterDict CollectParams(string select = null)
        {
            ParameterDict ret = new ParameterDict(Params.Prefix);
            if(!string.IsNullOrWhiteSpace(select))
            {
                ret.Update(Params);
            }
            else
            {
                var pattern = new Regex(select);
                Dictionary<string, Parameter> matchedParams = new Dictionary<string, Parameter>();
                foreach (var item in Params.Items())
                {
                    if (pattern.IsMatch(item.Key))
                        ret[item.Key] = item.Value;
                }
            }

            foreach (var item in childrens.Values)
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

            foreach (var item in childrens.Values)
            {
                ret.Update(item.CollectParamsWithPrefix(prefix));
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

        public void LoadParameters(string filename, Context ctx= null, bool allow_missing= false,
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
                    Params[name].LoadInit(loaded[name], new Context[] { ctx }, cast_dtype: cast_dtype, dtype_source: dtype_source);
            }
        }

        public virtual void RegisterChild(Block block, string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                name = childrens.Count.ToString();

            childrens[name] = block;
        }

        public HookHandle RegisterForwardPreHook(Hook hook)
        {
            var handle = new HookHandle();
            handle.Attach(forward_pre_hooks, hook);
            return handle;
        }

        public HookHandle RegisterForwardHook(Hook hook)
        {
            var handle = new HookHandle();
            handle.Attach(forward_hooks, hook);
            return handle;
        }

        public Block Apply(ApplyFn fn)
        {
            foreach (var cld in childrens.Values)
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
            foreach (var cld in childrens.Values)
            {
                cld.Hybridize(active, static_alloc, static_shape);
            }
        }

        public virtual void Cast(DType dtype)
        {
            foreach (var item in childrens.Values)
            {
                item.Cast(dtype);
            }

            foreach (var item in Params.Items())
            {
                item.Value.Cast(dtype);
            }
        }

        public NDArrayOrSymbol Call(NDArrayOrSymbol x)
        {
            foreach (var hook in forward_pre_hooks.Values)
            {
                hook(this, x.NdX);
            }

            var @out = Forward(x.NdX);

            foreach (var hook in forward_hooks.Values)
            {
                hook(this, @out);
            }

            return @out;
        }

        public virtual NDArray Forward(NDArray input, params NDArray[] args)
        {
            return input;
        }

        public virtual void Summary(NDArray[] inputs)
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

        internal static string CommonPrefix(string[] names) => throw new NotImplementedException();

        internal static (DType[], DType[]) InferParamTypes(Symbol[] in_params, Symbol out_params, string[] arg_params, string[] aux_params, Type default_dtype= null) => throw new NotImplementedException();
    }
}
