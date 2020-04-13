using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Dla
{
    public class DLA : HybridBlock
    {
        public DLA(int levels, int[] channels, int classes= 1000, string block= "BasicBlock", float momentum= 0.9f, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null,
                 bool residual_root= false, bool linear_root= false, bool use_feature= false, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private Conv2D Conv3x3(int in_planes, int out_planes, int stride= 1)
        {
            throw new NotImplementedException();
        }

        public static DLA GetDLA(int layers, int[] channels, bool pretrained= false, Context ctx= null, string root= "~/mxnet", int classes = 1000, string block = "BasicBlock", float momentum = 0.9f, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null, bool residual_root = false, bool linear_root = false, bool use_feature = false)
        {
            throw new NotImplementedException();
        }

        public static DLA DLA345(bool pretrained = false, Context ctx = null, string root = "~/mxnet", int classes = 1000, float momentum = 0.9f, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null, bool residual_root = false, bool linear_root = false, bool use_feature = false)
        {
            throw new NotImplementedException();
        }
    }
}
