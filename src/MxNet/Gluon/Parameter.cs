using MxNet.Initializers;
using MxNet.NN.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon
{
    public class Parameter
    {
        public float LRMult { get; set; }

        public float WDMult { get; set; }

        public virtual string GradReg
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

        public bool DataType
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

        public bool Shape
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

        public Parameter(string name, string grad_req= "write", Shape shape= null, string dtype= "float32",
                 float lr_mult= 1.0f, float wd_mult= 1.0f, BaseInitializer init= null, bool allow_deferred_init= false,
                 bool differentiable= true, string stype= "default", string grad_stype= "default")
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        internal void SetTrainer(Trainer trainer) => throw new NotImplementedException();

        internal NDArray[] CheckAndGet(NDArray[] arr_list, Context ctx) => throw new NotImplementedException();

        internal NDArray[] GetRpwSparse(NDArray[] arr_list, Context ctx, int row_id) => throw new NotImplementedException();

        internal void LoadInit(NDArray data, Context ctx, bool cast_dtype= false, string dtype_source= "current") => throw new NotImplementedException();

        internal void FinishDeferredInit() => throw new NotImplementedException();

        internal void InitImpl(NDArray data, Context[] ctx_list) => throw new NotImplementedException();

        internal void InitGrad() => throw new NotImplementedException();

        internal void Reduce() => throw new NotImplementedException();

        public void Initialize(Initializer init= null, Context ctx= null, Initializer default_init= null, bool force_reinit= false) => throw new NotImplementedException();

        public void ResetCtx(Context ctx) => throw new NotImplementedException();

        public void SetData(NDArray data) => throw new NotImplementedException();

        public void RowSparseData(int row_id) => throw new NotImplementedException();

        public void ListRowSparseData(NDArray row_id) => throw new NotImplementedException();

        public NDArray Data(Context ctx = null) => throw new NotImplementedException();

        public NDArray[] ListData() => throw new NotImplementedException();

        public NDArray[] Grad(Context ctx = null) => throw new NotImplementedException();

        public NDArray[] ListGrad() => throw new NotImplementedException();

        public Context[] ListCtx() => throw new NotImplementedException();

        public NDArray[] ZeroGrad() => throw new NotImplementedException();

        public Symbol Var() => throw new NotImplementedException();

        public void Cast(DType dtype) => throw new NotImplementedException();
    }
}
