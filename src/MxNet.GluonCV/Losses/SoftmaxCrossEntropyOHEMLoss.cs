using System;
using System.Collections.Generic;
using System.Text;
using MxNet;
using MxNet.Gluon;
using MxNet.Gluon.Losses;

namespace MxNet.GluonCV.Losses
{
    public class SoftmaxCrossEntropyOHEMLoss : Loss
    {
        private int _ignore_label;

        private bool _size_average;

        private bool _sparse_label;

        public SoftmaxCrossEntropyOHEMLoss(bool sparse_label= true, int batch_axis = 0, int ignore_label = -1, bool size_average = true, float? weight = null, string prefix = null, ParameterDict @params = null) : base(weight, batch_axis, prefix, @params)
        {
            this._sparse_label = sparse_label;
            this._ignore_label = ignore_label;
            this._size_average = size_average;
            throw new NotSupportedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol pred, NDArrayOrSymbol label, NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            throw new NotSupportedException();
        }
    }
}
