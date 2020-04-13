using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.ActionRecognition
{
    public class SlowFast : HybridBlock
    {
        public SlowFast(int nclass,
                 string block= "Bottleneck",
                 int[] layers= null,
                 int? num_block_temp_kernel_fast= null,
                 int? num_block_temp_kernel_slow= null,
                 bool pretrained= false,
                 bool pretrained_base= false,
                 bool feat_ext= false,
                 int num_segments= 1,
                 int num_crop= 1,
                 bool bn_eval= true,
                 bool bn_frozen= false,
                 bool partial_bn= false,
                 int frozen_stages= -1,
                 float dropout_ratio= 0.5f,
                 float init_std= 0.01f,
                 int alpha= 8,
                 int beta_inv= 8,
                 float fusion_conv_channel_ratio= 2,
                 int fusion_kernel_size= 5,
                 int width_per_group= 64,
                 int num_groups= 1,
                 int slow_temporal_stride= 16,
                 int fast_temporal_stride= 2,
                 int slow_frames= 4,
                 int fast_frames= 32,
                 string norm_layer= "BatchNorm",
                 FuncArgs norm_kwargs= null,
                 Context ctx= null, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public NDArrayOrSymbol SlowPath(NDArrayOrSymbol x, NDArrayOrSymbolList lateral)
        {
            throw new NotImplementedException();
        }

        public (NDArrayOrSymbol, NDArrayOrSymbolList) FastPath(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        public static HybridSequential MakeLayerFast(int inplanes, int planes, int num_blocks, int? num_block_temp_kernel_fast= null, string block= "Bottleneck",
                                                    int strides= 1, int head_conv= 1, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null, string layer_name= "")
        {
            throw new NotImplementedException();
        }

        public static HybridSequential MakeLayerSlow(int inplanes, int planes, int num_blocks, int? num_block_temp_kernel_slow = null, string block = "Bottleneck",
                                                   int strides = 1, int head_conv = 1, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null, string layer_name = "")
        {
            throw new NotImplementedException();
        }

        public class Bottleneck : HybridBlock
        {
            public Bottleneck(int inplanes, int planes, int strides= 1, bool downsample= false, int head_conv= 1, string norm_layer= "BatchNorm", FuncArgs norm_kwargs = null,
                                string layer_name= "",string prefix = "", ParameterDict @params = null) : base(prefix, @params)
            {
                throw new NotImplementedException();
            }

            public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
            {
                throw new NotImplementedException();
            }
        }
    }
}
