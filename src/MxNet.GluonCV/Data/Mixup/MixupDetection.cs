using MxNet.Gluon.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class MixupDetection : Dataset<(NDArray, NDArray)>
    {
        public MixupDetection(Dataset<(NDArray, NDArray)> dataset, Random mixup = null)
        {
            throw new NotImplementedException();
        }

        public void SetMixup(Random mixup = null)
        {
            throw new NotImplementedException();
        }

        public override (NDArray, NDArray) this[int idx] => throw new NotImplementedException();

        public override int Length => throw new NotImplementedException();
    }
}
