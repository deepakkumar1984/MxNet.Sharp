using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Rpn
{
    public class BBoxClipToImage : CustomOp
    {
        public BBoxClipToImage(int axis = -1)
        {
            throw new NotImplementedException();
        }

        public override void Backward(OpGradReq[] req, NDArrayList out_grad, NDArrayList in_data, NDArrayList out_data, NDArrayList in_grad, NDArrayList aux)
        {
            throw new NotImplementedException();
        }

        public override NDArray Forward(bool is_train, OpGradReq[] req, NDArrayList in_data, NDArrayList out_data, NDArrayList aux)
        {
            throw new NotImplementedException();
        }
    }
}
