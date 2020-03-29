using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Yolo
{
    public class DarknetV3 : HybridBlock
    {
        public DarknetV3(int[] layers, int[] channels, int classes= 1000, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private HybridSequential Conv2d(int channel, int kernel, int padding, int stride, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null)
        {
            throw new NotImplementedException();
        }

        public static DarknetV3 GetDarknet(string darknet_version, int num_layers, bool pretrained= false, Context ctx= null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static DarknetV3 Darknet53(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }
    }
}
