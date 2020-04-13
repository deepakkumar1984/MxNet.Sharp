using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Rcnn
{
    public class Mask : HybridBlock
    {
        public Mask(int batch_images, string[] classes, int mask_channels, int num_fcn_convs= 0, string norm_layer= "",
                 FuncArgs norm_kwargs= null, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public virtual void ResetClass(string[] classes, NDArrayDict reuse_weights = null)
        {
            throw new NotImplementedException();
        }
    }
}
