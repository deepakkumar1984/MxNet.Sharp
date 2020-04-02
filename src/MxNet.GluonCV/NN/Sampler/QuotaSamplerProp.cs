using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class QuotaSamplerProp : CustomOpProp
    {
        public bool fill_negative;

        public float? neg_ratio;

        public float neg_thresh_high;

        public float neg_thresh_low;

        public int num_sample;

        public float pos_ratio;

        public float pos_thresh;

        public QuotaSamplerProp(int num_sample, float pos_thresh, float neg_thresh_high = 0.5f, float neg_thresh_low = 0,
                 float pos_ratio = 0.5f, float? neg_ratio = null, bool fill_negative = true)
        {
            this.num_sample = Convert.ToInt32(num_sample);
            this.pos_thresh = pos_thresh;
            this.neg_thresh_high = neg_thresh_high;
            this.neg_thresh_low = neg_thresh_low;
            this.pos_ratio = pos_ratio;
            this.neg_ratio = neg_ratio;
            this.fill_negative = fill_negative;
        }

        public override string[] ListArguments()
        {
            return new string[] {
                    "matches",
                    "ious"
                };
        }

        public override string[] ListOutputs()
        {
            return new string[] {
                    "output"
                };
        }

        public override (Shape[], Shape[], Shape[]) InferShape(Shape[] in_shape)
        {
            return (in_shape, new Shape[] { in_shape[0] }, new Shape[0]);
        }

        public override (DType[], DType[], DType[]) InferType(DType[] in_type)
        {
            return (new DType[] {
                    in_type[0],
                    in_type[0]
                }, new DType[]  {
                    in_type[0]
                }, new DType[0]);
        }

        public QuotaSamplerOp CreateOperator(Context ctx, Shape[] in_shapes, DType[] in_dtypes)
        {
            return new QuotaSamplerOp(this.num_sample, this.pos_thresh, this.neg_thresh_high, this.neg_thresh_low, this.pos_ratio, this.neg_ratio, this.fill_negative);
        }
    }
}
