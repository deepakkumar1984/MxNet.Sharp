using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Yolo
{
    public class YOLOOutputV3 : HybridBlock
    {
        public YOLOOutputV3(int index, int num_class, NDArray anchors, int stride, (int, int)? alloc_size= null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public void ResetClass(string[] classes, NDArrayDict reuse_weights = null)
        {
            throw new NotImplementedException();
        }
    }
}
