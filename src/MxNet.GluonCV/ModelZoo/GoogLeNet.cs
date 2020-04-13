using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo
{
    public class GoogLeNet : HybridBlock
    {
        public GoogLeNet(int classes= 1000, string norm_layer= "BatchNorm", float dropout_ratio= 0.4f, bool aux_logits= false, FuncArgs norm_kwargs= null, bool partial_bn= false, bool pretrained_base= true,Context ctx= null, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public static GoogLeNet GetGoogLeNet(int classes= 1000, bool pretrained= false, bool pretrained_base= true, Context ctx= null, float dropout_ratio= 0.4f, bool aux_logits= false, string root= "", bool partial_bn= false)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeBasicConv(int in_channels, int channels, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeBranch(bool use_pool, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null, int? channels = null, (int, int)? kernel_size = null, (int, int)? strides = null, (int, int)? padding = null)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeMixed3A(int in_channels, int pool_features, string prefix, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeMixed3B(int in_channels, int pool_features, string prefix, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeMixed4A(int in_channels, int pool_features, string prefix, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeMixed4B(int in_channels, int pool_features, string prefix, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeMixed4C(int in_channels, int pool_features, string prefix, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeMixed4D(int in_channels, int pool_features, string prefix, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeMixed4E(int in_channels, int pool_features, string prefix, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeMixed5A(int in_channels, int pool_features, string prefix, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeMixed5B(int in_channels, int pool_features, string prefix, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeAux(int in_channels, int classes, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }
    }
}
