using MxNet.Gluon;
using MxNet;
using System;
using System.Collections.Generic;
using System.Text;
using MxNet.Gluon.Losses;

namespace MxNet.GluonCV.Losses
{
    public class ICNetLoss : SoftmaxCrossEntropyLoss
    {
        public ICNetLoss((float, float, float)? weights = null, int? height = null, int? width = null, int crop_size = 480, int axis = -1, bool sparse_label = true, bool from_logits = false, float? weight = null, int? batch_axis = 0, string prefix = null, ParameterDict @params = null) : base(axis, sparse_label, from_logits, weight, batch_axis, prefix, @params)
        {
        }

        private NDArrayOrSymbol WeightedForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
