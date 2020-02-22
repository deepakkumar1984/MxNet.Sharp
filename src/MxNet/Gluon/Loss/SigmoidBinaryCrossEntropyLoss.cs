using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon
{
    public class SigmoidBinaryCrossEntropyLoss : Loss
    {
        private bool _from_sigmoid;

        public SigmoidBinaryCrossEntropyLoss(bool from_sigmoid = false, float? weight = null, int? batch_axis = 0, string prefix = null, ParameterDict @params = null) : base(weight, batch_axis, prefix, @params)
        {
            _from_sigmoid = from_sigmoid;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol pred, NDArrayOrSymbol label, NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            if (label.IsNDArray)
                label = nd.ReshapeLike(label, pred);
            else
                label = sym.ReshapeLike(label, pred);

            NDArrayOrSymbol pos_weight = null;
            NDArrayOrSymbol loss = null;

            if (args.Length > 0)
                pos_weight = args[0] is NDArray ? new NDArrayOrSymbol((NDArray)args[0]) : new NDArrayOrSymbol((Symbol)args[0]);

            if (!_from_sigmoid)
            {
                if(pos_weight  == null)
                {
                    if (label.IsNDArray)
                        loss = nd.Relu(pred) - pred.NdX * label.NdX + nd.Activation(nd.Negative(nd.Abs(pred)), ActivationActType.Softrelu);
                    else
                        loss = sym.Relu(pred) - pred.SymX * label.SymX + sym.Activation(sym.Negative(sym.Abs(pred)), ActivationActType.Softrelu);
                }
                else
                {
                    if (label.IsNDArray)
                    {
                        var log_weight = 1 + nd.BroadcastMul(pos_weight.NdX - 1, label);
                        loss = nd.Relu(pred) - pred.NdX * label.NdX + log_weight
                                    + nd.Activation(nd.Negative(nd.Abs(pred)), ActivationActType.Softrelu)
                                    + nd.Relu(nd.Negative(pred));
                    }
                    else
                    {
                        var log_weight = 1 + sym.BroadcastMul(pos_weight.SymX - 1, label);
                        loss = sym.Relu(pred) - pred.SymX * label.SymX + log_weight
                                    + sym.Activation(sym.Negative(sym.Abs(pred)), ActivationActType.Softrelu)
                                    + sym.Relu(sym.Negative(pred));
                    }
                }
            }
            else
            {
                float eps = 1e-12f;
                if(pos_weight == null)
                {
                    if(label.IsNDArray)
                        loss = nd.Negative(nd.Log(pred.NdX + eps) * label.NdX
                                    + nd.Log(1 - pred.NdX + eps) * (1 - label.NdX));
                    else
                        loss = sym.Negative(sym.Log(pred.SymX + eps) * label.SymX
                                    + sym.Log(1 - pred.SymX + eps) * (1 - label.SymX));
                }
                else
                {
                    if (label.IsNDArray)
                        loss = nd.Negative(nd.BroadcastMul(nd.Log(pred.NdX + eps) * label, pos_weight)
                         + nd.Log(1 - pred.NdX + eps) * (1 - label.NdX));
                    else
                        loss = sym.Negative(sym.BroadcastMul(sym.Log(pred.SymX + eps) * label, pos_weight)
                         + sym.Log(1 - pred.SymX + eps) * (1 - label.SymX));
                }
            }

            loss = ApplyWeighting(loss, Weight, sample_weight);
            if (loss.IsNDArray)
                return nd.Mean(loss, BatchAxis.Value, exclude: true);

            return sym.Mean(loss, BatchAxis.Value, exclude: true);
        }
    }
}
