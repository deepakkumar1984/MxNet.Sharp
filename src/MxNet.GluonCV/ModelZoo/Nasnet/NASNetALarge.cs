using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Nasnet
{
    public class NASNetALarge : HybridBlock
    {
        public NASNetALarge(int repeat= 6, int penultimate_filters= 4032, int stem_filters= 96, int filters_multiplier= 2, int classes= 1000, bool use_aux= true,
                 string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public static NASNetALarge GetNasNet(int repeat= 6, int penultimate_filters= 4032, bool pretrained= false, Context ctx= null, string root = "~/mxnet")
        {
            throw new NotImplementedException();
        }

        public static NASNetALarge NasNet_4_1056(bool pretrained = false, Context ctx = null, string root = "~/mxnet")
        {
            throw new NotImplementedException();
        }

        public static NASNetALarge NasNet_5_1538(bool pretrained = false, Context ctx = null, string root = "~/mxnet")
        {
            throw new NotImplementedException();
        }

        public static NASNetALarge NasNet_7_1920(bool pretrained = false, Context ctx = null, string root = "~/mxnet")
        {
            throw new NotImplementedException();
        }

        public static NASNetALarge NasNet_6_4032(bool pretrained = false, Context ctx = null, string root = "~/mxnet")
        {
            throw new NotImplementedException();
        }
    }
}
