using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon
{
    public abstract class Block
    {
        public delegate void Hook(Block block, NDArray input);

        public delegate void ApplyFn(Block block);

        public Block(string prefix, ParameterDict @params)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public void SetAttr<T>(string name, T value)
        {
            throw new NotImplementedException();
        }

        public virtual string Alias() => throw new NotImplementedException();

        private void CheckContainerWithBlock() => throw new NotImplementedException();

        private ParameterDict CollectParamsWithPrefix() => throw new NotImplementedException();

        public void SaveParameters(string filename, bool deduplicate = false) => throw new NotImplementedException();

        public void LoadParameters(string filename, Context ctx= null, bool allow_missing= false,
                        bool ignore_extra= false, bool cast_dtype= false, string dtype_source= "current") => throw new NotImplementedException();

        public void LoadParams(string filename, Context ctx= null, bool allow_missing= false,
                                bool ignore_extra= false) => throw new NotImplementedException();

        public virtual void RegisterChild(Block block, string name) => throw new NotImplementedException();

        public void RegisterForwardPreHook(Hook block) => throw new NotImplementedException();

        public void RegisterForwardHook(Hook hook) => throw new NotImplementedException();

        public void Apply(ApplyFn fn) => throw new NotImplementedException();

        public void Initialize(Initializer init= null, Context ctx= null, bool verbose= false, bool force_reinit= false) => throw new NotImplementedException();

        public virtual void Hybridize(bool active = true, bool static_alloc = false, bool static_shape = false) => throw new NotImplementedException();

        public virtual void Cast(DType dtype) => throw new NotImplementedException();

        public NDArrayOrSymbol[] Call(NDArrayOrSymbol[] args) => throw new NotImplementedException();

        public virtual NDArray Forward(NDArray input, params NDArray[] args) => throw new NotImplementedException();

        public virtual void Summary(NDArray[] inputs) => throw new NotImplementedException();

        internal static (NDArrayOrSymbol[], string[]) Flatten(List<NDArrayOrSymbol[]> args, string inout_str) => throw new NotImplementedException();

        internal static (NDArrayOrSymbol[], NDArrayOrSymbol[]) Regroup(List<NDArrayOrSymbol[]> args, int fmt) => throw new NotImplementedException();

        internal static string CommonPrefix(string[] names) => throw new NotImplementedException();

        internal static (DType[], DType[]) InferParamTypes(Symbol[] in_params, Symbol out_params, string[] arg_params, string[] aux_params, Type default_dtype= null) => throw new NotImplementedException();
    }
}
