using System;
using System.Collections.Generic;
using System.Text;
using MxNet;
using MxNet.Gluon;
namespace MxNet.GluonCV
{
    public class YOLOV3Loss : Loss
    {
        public YOLOV3Loss(float? weight = null, int? batch_axis = null, string prefix = null, ParameterDict @params = null) : base(weight, batch_axis, prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol pred, NDArrayOrSymbol label, NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
