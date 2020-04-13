using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.ActionRecognition
{
    public class I3D_InceptionV3 : HybridBlock
    {
        public I3D_InceptionV3(int nclass = 1000, bool pretrained_base = true, int num_segments = 1, int num_crop = 1, bool feat_ext = false, float dropout_ratio = 0.5f, float init_std = 0.01f, bool partial_bn = false, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeBasicConv(int in_channels, int channels, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeBranch(bool use_pool, string norm_layer, FuncArgs norm_kwargs, int? channels = null, (int, int)? kernel_size = null, (int, int)? strides = null, (int, int)? padding = null)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeA(int in_channels, int pool_features, string prefix, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeB(string prefix, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeC(int in_channels, int channels_7x7, string prefix, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeD(string prefix, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeE(int in_channel, string prefix, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static I3D_InceptionV3 I3D_InceptionV3_Kinetics400(int nclass = 400, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "")
        {
            throw new NotImplementedException();
        }
    }
}
