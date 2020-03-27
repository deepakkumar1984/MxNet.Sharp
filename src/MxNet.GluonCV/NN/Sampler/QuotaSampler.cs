using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class QuotaSampler : Block
    {
        public QuotaSampler(int num_sample, float pos_thresh, float neg_thresh_high, float neg_thresh_low= float.NegativeInfinity,
                 float pos_ratio= 0.5f, float? neg_ratio= null, bool fill_negative= true, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
