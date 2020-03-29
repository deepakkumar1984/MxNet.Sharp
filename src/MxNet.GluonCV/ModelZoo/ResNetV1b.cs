using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo
{
    public class ResNetV1b : HybridBlock
    {
        public ResNetV1b(string block, int[] layers, int classes= 1000, bool dilated= false, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null, bool last_gamma= false, bool deep_stem= false, int stem_width= 32, bool avg_down= false, float final_drop= 0, bool use_global_stats= false, string name_prefix= "", string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeLayer(int stage_index, string block, int planes, int blocks, int strides= 1, int dilation= 1, bool avg_down= false, string norm_layer= "", bool last_gamma= false)
        {
            throw new NotImplementedException();
        }

        public static ResNetV1b ResNet18_V1B(bool pretrained= false, string root= "~/.mxnet/models", Context ctx= null, bool dilated = false, bool last_gamma = false, bool deep_stem = false, int stem_width = 32, bool avg_down = false, float final_drop = 0, bool use_global_stats = false)
        {
            throw new NotImplementedException();
        }

        public static ResNetV1b ResNet34_V1B(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool dilated = false, bool last_gamma = false, bool deep_stem = false, int stem_width = 32, bool avg_down = false, float final_drop = 0, bool use_global_stats = false)
        {
            throw new NotImplementedException();
        }

        public static ResNetV1b ResNet50_V1B(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool dilated = false, bool last_gamma = false, bool deep_stem = false, int stem_width = 32, bool avg_down = false, float final_drop = 0, bool use_global_stats = false)
        {
            throw new NotImplementedException();
        }

        public static ResNetV1b ResNet50_V1B_GN(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool dilated = false, bool last_gamma = false, bool deep_stem = false, int stem_width = 32, bool avg_down = false, float final_drop = 0, bool use_global_stats = false)
        {
            throw new NotImplementedException();
        }

        public static ResNetV1b ResNet101_V1B(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool dilated = false, bool last_gamma = false, bool deep_stem = false, int stem_width = 32, bool avg_down = false, float final_drop = 0, bool use_global_stats = false)
        {
            throw new NotImplementedException();
        }

        public static ResNetV1b ResNet101_V1B_GN(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool dilated = false, bool last_gamma = false, bool deep_stem = false, int stem_width = 32, bool avg_down = false, float final_drop = 0, bool use_global_stats = false)
        {
            throw new NotImplementedException();
        }

        public static ResNetV1b ResNet152_V1B(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool dilated = false, bool last_gamma = false, bool deep_stem = false, int stem_width = 32, bool avg_down = false, float final_drop = 0, bool use_global_stats = false)
        {
            throw new NotImplementedException();
        }

        public static ResNetV1b ResNet50_V1C(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool dilated = false, bool last_gamma = false, bool deep_stem = false, int stem_width = 32, bool avg_down = false, float final_drop = 0, bool use_global_stats = false)
        {
            throw new NotImplementedException();
        }

        public static ResNetV1b ResNet101_V1C(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool dilated = false, bool last_gamma = false, bool deep_stem = false, int stem_width = 32, bool avg_down = false, float final_drop = 0, bool use_global_stats = false)
        {
            throw new NotImplementedException();
        }

        public static ResNetV1b ResNet152_V1C(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool dilated = false, bool last_gamma = false, bool deep_stem = false, int stem_width = 32, bool avg_down = false, float final_drop = 0, bool use_global_stats = false)
        {
            throw new NotImplementedException();
        }

        public static ResNetV1b ResNet50_V1D(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool dilated = false, bool last_gamma = false, bool deep_stem = false, int stem_width = 32, bool avg_down = false, float final_drop = 0, bool use_global_stats = false)
        {
            throw new NotImplementedException();
        }

        public static ResNetV1b ResNet101_V1D(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool dilated = false, bool last_gamma = false, bool deep_stem = false, int stem_width = 32, bool avg_down = false, float final_drop = 0, bool use_global_stats = false)
        {
            throw new NotImplementedException();
        }

        public static ResNetV1b ResNet152_V1D(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool dilated = false, bool last_gamma = false, bool deep_stem = false, int stem_width = 32, bool avg_down = false, float final_drop = 0, bool use_global_stats = false)
        {
            throw new NotImplementedException();
        }

        public static ResNetV1b ResNet50_V1E(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool dilated = false, bool last_gamma = false, bool deep_stem = false, int stem_width = 32, bool avg_down = false, float final_drop = 0, bool use_global_stats = false)
        {
            throw new NotImplementedException();
        }

        public static ResNetV1b ResNet101_V1E(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool dilated = false, bool last_gamma = false, bool deep_stem = false, int stem_width = 32, bool avg_down = false, float final_drop = 0, bool use_global_stats = false)
        {
            throw new NotImplementedException();
        }

        public static ResNetV1b ResNet152_V1E(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool dilated = false, bool last_gamma = false, bool deep_stem = false, int stem_width = 32, bool avg_down = false, float final_drop = 0, bool use_global_stats = false)
        {
            throw new NotImplementedException();
        }

        public static ResNetV1b ResNet50_V1S(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool dilated = false, bool last_gamma = false, bool deep_stem = false, int stem_width = 32, bool avg_down = false, float final_drop = 0, bool use_global_stats = false)
        {
            throw new NotImplementedException();
        }

        public static ResNetV1b ResNet101_V1S(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool dilated = false, bool last_gamma = false, bool deep_stem = false, int stem_width = 32, bool avg_down = false, float final_drop = 0, bool use_global_stats = false)
        {
            throw new NotImplementedException();
        }

        public static ResNetV1b ResNet152_V1S(bool pretrained = false, string root = "~/.mxnet/models", Context ctx = null, bool dilated = false, bool last_gamma = false, bool deep_stem = false, int stem_width = 32, bool avg_down = false, float final_drop = 0, bool use_global_stats = false)
        {
            throw new NotImplementedException();
        }
    }

    public class BasicBlockV1b : HybridBlock
    {
        public BasicBlockV1b(int planes, int strides= 1, int dilation= 1, HybridBlock downsample= null, int previous_dilation= 1, string norm_layer= "", FuncArgs norm_kwargs = null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }

    class BottleneckV1b : HybridBlock
    {
        public BottleneckV1b(int planes, int strides = 1, int dilation = 1, HybridBlock downsample = null, int previous_dilation = 1, string norm_layer = "", FuncArgs norm_kwargs = null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
