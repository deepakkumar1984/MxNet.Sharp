using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.ActionRecognition
{
    public class I3D_ResNetV1
    {
        public interface IBuildingBlock
        {
            int Expansion { get; set; }
        }

        public class Bottleneck : HybridBlock, IBuildingBlock
        {
            public Bottleneck(int inplanes, int planes, int spatial_stride = 1, int temporal_stride = 1, int dilation = 1, bool downsample = false, bool if_inflate = true, string inflate_style = "3x1x1", string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null, string layer_name = "", string prefix = null, ParameterDict @params = null) : base(prefix, @params)
            {
            }

            public int Expansion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
            {
                throw new NotImplementedException();
            }
        }

        public class BasicBlock : HybridBlock, IBuildingBlock
        {
            public BasicBlock(int inplanes, int planes, int spatial_stride= 1, int temporal_stride= 1, int dilation= 1, bool downsample= false, bool if_inflate= true, string inflate_style = "", string norm_layer= "BatchNorm", FuncArgs norm_kwargs = null, string layer_name= "", string prefix = null, ParameterDict @params = null) : base(prefix, @params)
            {
                throw new NotImplementedException();
            }

            public int Expansion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
            {
                throw new NotImplementedException();
            }
        }

        private Conv3D Conv3x3x3(int in_planes, int out_planes, int spatial_stride= 1, int temporal_stride= 1, int dilation= 1)
        {
            throw new NotImplementedException();
        }

        private Conv3D Conv1x3x3(int in_planes, int out_planes, int spatial_stride = 1, int temporal_stride = 1, int dilation = 1)
        {
            throw new NotImplementedException();
        }

        public static I3D_ResNetV1 MakeResLayer(IBuildingBlock block, int inplanes, int planes, HybridBlock[] blocks, int spatial_stride= 1, int temporal_stride= 1, int dilation= 1,
                   int inflate_freq= 1, string inflate_style= "3x1x1", int nonlocal_freq= 1, FuncArgs nonlocal_cfg= null, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null,
                   string layer_name= "")
        {
            throw new NotImplementedException();
        }

        public static I3D_ResNetV1 I3D_ResNet50_V1_Kinetics400(int nclass = 400, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "~/.mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static I3D_ResNetV1 I3D_ResNet101_V1_Kinetics400(int nclass = 400, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "~/.mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static I3D_ResNetV1 I3D_NL5_ResNet50_V1_Kinetics400(int nclass = 400, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "~/.mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static I3D_ResNetV1 I3D__NL5_ResNet101_V1_Kinetics400(int nclass = 400, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "~/.mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static I3D_ResNetV1 I3D_NL10_ResNet50_V1_Kinetics400(int nclass = 400, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "~/.mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static I3D_ResNetV1 I3D__NL10_ResNet101_V1_Kinetics400(int nclass = 400, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "~/.mxnet/models")
        {
            throw new NotImplementedException();
        }
        
        public static I3D_ResNetV1 I3D_ResNet50_V1_SthSthV2(int nclass = 174, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "~/.mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static I3D_ResNetV1 I3D_ResNet50_V1_HMDB51(int nclass = 51, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "~/.mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static I3D_ResNetV1 I3D_ResNet50_V1_UCF101(int nclass = 101, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "~/.mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static I3D_ResNetV1 I3D_ResNet50_V1_Custom(int nclass = 400, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "~/.mxnet/models")
        {
            throw new NotImplementedException();
        }
    }
}
