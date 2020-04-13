using System;
using System.Collections.Generic;
using System.Text;
using MxNet;
using MxNet.Gluon;
using MxNet.Gluon.Losses;

namespace MxNet.GluonCV.Losses
{
    public class DistillationSoftmaxCrossEntropyLoss : HybridBlock
    {
        private float _hard_weight;

        private float _temperature;

        public SoftmaxCrossEntropyLoss HardLoss;

        public SoftmaxCrossEntropyLoss SoftLoss;

        public DistillationSoftmaxCrossEntropyLoss(float temperature = 1, float hard_weight = 0.5f, bool sparse_label= true, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            this._temperature = temperature;
            this._hard_weight = hard_weight;
            this.SoftLoss = new SoftmaxCrossEntropyLoss(sparse_label: false, prefix: prefix, @params: @params);
            this.HardLoss = new SoftmaxCrossEntropyLoss(sparse_label: sparse_label, prefix: prefix, @params: @params);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol output, params NDArrayOrSymbol[] args)
        {
            NDArrayOrSymbol label = args[0];
            NDArrayOrSymbol soft_target = args[1];

            if (this._hard_weight == 0)
            {
                return (float)Math.Pow(this._temperature, 2) * this.SoftLoss.Call(output / this._temperature, soft_target);
            }
            else if (this._hard_weight == 1)
            {
                return this.HardLoss.Call(output, label);
            }
            else
            {
                var soft_loss = (float)Math.Pow(this._temperature, 2) * this.SoftLoss.Call(output / this._temperature, soft_target);
                var hard_loss = this.HardLoss.Call(output, label);
                return (1 - this._hard_weight) * soft_loss + this._hard_weight * hard_loss;
            }
        }
    }
}
