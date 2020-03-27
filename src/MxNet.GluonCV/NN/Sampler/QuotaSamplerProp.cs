using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class QuotaSamplerProp : CustomOpProp
    {
        public QuotaSamplerProp(int num_sample, float pos_thresh, float neg_thresh_high = 0.5f, float neg_thresh_low = 0,
                 float pos_ratio = 0.5f, float? neg_ratio = null, bool fill_negative = true)
        {
            throw new NotImplementedException();
        }

        public override string[] ListArguments()
        {
            throw new NotImplementedException();
        }

        public override string[] ListOutputs()
        {
            throw new NotImplementedException();
        }

        public override (Shape[], Shape[], Shape[]) InferShape(Shape in_shape)
        {
            throw new NotImplementedException();
        }

        public override (DType[], DType[], DType[]) InferType(DType in_type)
        {
            throw new NotImplementedException();
        }

        public QuotaSamplerOp CreateOperator(Context ctx, Shape[] in_shapes, DType[] in_dtypes)
        {
            throw new NotImplementedException();
        }
    }
}
