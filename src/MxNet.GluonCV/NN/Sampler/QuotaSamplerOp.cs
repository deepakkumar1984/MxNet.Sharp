using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class QuotaSamplerOp : CustomOp
    {
        public QuotaSamplerOp(int num_sample, float pos_thresh, float neg_thresh_high= 0.5f, float neg_thresh_low= float.NegativeInfinity,
                 float pos_ratio= 0.5f, float? neg_ratio= null, bool fill_negative= true)
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
