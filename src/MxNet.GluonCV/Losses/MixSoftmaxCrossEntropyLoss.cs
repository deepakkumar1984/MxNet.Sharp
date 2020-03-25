using MxNet.Gluon;
using MxNet;
using System;
using System.Collections.Generic;
using System.Text;
using MxNet.Gluon.Losses;

namespace MxNet.GluonCV.Losses
{
    public class MixSoftmaxCrossEntropyLoss : SoftmaxCrossEntropyLoss
    {
        public MixSoftmaxCrossEntropyLoss(bool aux= true, bool mixup = false, float aux_weight= 0.2f, int axis = -1, bool sparse_label = true, bool from_logits = false, float? weight = null, int? batch_axis = 0, string prefix = null, ParameterDict @params = null) : base(axis, sparse_label, from_logits, weight, batch_axis, prefix, @params)
        {
            throw new NotImplementedException();
        }

        private NDArrayOrSymbol AuxForward(NDArrayOrSymbol pred1, NDArrayOrSymbol pred2, NDArrayOrSymbol label, NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            throw new NotImplementedException();
        }

        private NDArrayOrSymbol AuxMixupForward(NDArrayOrSymbol pred1, NDArrayOrSymbol pred2, NDArrayOrSymbol label1, NDArrayOrSymbol label2, NDArrayOrSymbol lam, NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            throw new NotImplementedException();
        }

        private NDArrayOrSymbol MixupForward(NDArrayOrSymbol pred, NDArrayOrSymbol label1, NDArrayOrSymbol label2, NDArrayOrSymbol lam, NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
