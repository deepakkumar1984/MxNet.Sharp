using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon
{
    public abstract class HybridBlock : Block
    {
        public HybridBlock(string prefix = null , ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public Parameter this[string name]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private void GetGraph(Symbol[] args) => throw new NotImplementedException();

        private void BuildCache(Symbol[] args) => throw new NotImplementedException();

        private void DeferredInferShape(Symbol[] args) => throw new NotImplementedException();

        private void CallCachedOp(Symbol[] args) => throw new NotImplementedException();

        private void ClearCachedOp() => throw new NotImplementedException();

        public override void RegisterChild(Block block, string name)
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

        public void InferShape(Symbol[] args) => throw new NotImplementedException();

        public void InferType(Symbol[] args) => throw new NotImplementedException();

        public void Export(string path, int epoch = 0, bool remove_amp_cast = true) => throw new NotImplementedException();

        public override NDArray Forward(NDArray input, params NDArray[] args)
        {
            throw new NotImplementedException();
        }

        public abstract NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args);
    }
}
