using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet
{
    public abstract class CustomOp
    {
        public abstract NDArray Forward(bool is_train, OpGradReq[] req, NDArrayList in_data, NDArrayList out_data, NDArrayList aux);

        public abstract void Backward(OpGradReq[] req, NDArrayList out_grad, NDArrayList in_data, NDArrayList out_data, NDArrayList in_grad, NDArrayList aux);

        public virtual void Assign(NDArray dst, OpGradReq req, NDArray src)
        {
            throw new NotImplementedException();
        }
    }
}
