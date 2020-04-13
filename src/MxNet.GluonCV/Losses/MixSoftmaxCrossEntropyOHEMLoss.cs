using MxNet.Gluon;
using MxNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Losses
{
    public class MixSoftmaxCrossEntropyOHEMLoss : SoftmaxCrossEntropyOHEMLoss
    {
        public MixSoftmaxCrossEntropyOHEMLoss(bool aux= true, float aux_weight= 0.2f, int axis = -1, bool sparse_label = true, bool from_logits = false, float? weight = null, int? batch_axis = 0, string prefix = "", ParameterDict @params = null) : base(sparse_label, batch_axis.Value, prefix: prefix, @params: @params)
        {
            throw new NotSupportedException();
        }

        private NDArrayOrSymbol AuxForward(NDArrayOrSymbol pred1, NDArrayOrSymbol pred2, NDArrayOrSymbol label, NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            throw new NotSupportedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotSupportedException();
        }
    }
}
