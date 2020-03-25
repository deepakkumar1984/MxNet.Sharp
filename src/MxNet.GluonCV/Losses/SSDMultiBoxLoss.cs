using MxNet;
using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Losses
{
    public class SSDMultiBoxLoss : Block
    {
        public SSDMultiBoxLoss(float negative_mining_ratio= 3, float rho= 1, float lambd= 1,
                float min_hard_negatives= 0, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
