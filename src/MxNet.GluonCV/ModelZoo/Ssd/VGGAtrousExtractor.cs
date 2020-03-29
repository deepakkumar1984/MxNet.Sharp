using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Ssd
{
    public class VGGAtrousExtractor : VGGAtrousBase
    {
        public VGGAtrousExtractor(int[] layers, int[] filters, bool batch_norm = false, string prefix = null, ParameterDict @params = null) : base(layers, filters, batch_norm, prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public static VGGAtrousExtractor GetVGGAtrousExtractor(int num_layers, int im_size, bool pretrained= false, Context ctx= null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static VGGAtrousExtractor VGG16Atrous300(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static VGGAtrousExtractor VGG16Atrous512(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }
    }
}
