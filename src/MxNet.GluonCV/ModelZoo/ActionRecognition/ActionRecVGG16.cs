using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.ActionRecognition
{
    public class ActionRecVGG16 : HybridBlock
    {
        public ActionRecVGG16(int nclass, bool pretrained_base = true, float dropout_ratio = 0.9f, float init_std = 0.001f, int feat_dim = 4096, int num_segments = 1, int num_crop = 1, bool partial_bn = false, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public static ActionRecVGG16 VGG16_UCF101(int nclass = 101, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "~/.mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static ActionRecVGG16 VGG16_HMDB51(int nclass = 51, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "~/.mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static ActionRecVGG16 VGG16_Kinetics400(int nclass = 400, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "~/.mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static ActionRecVGG16 VGG16_SthSthv2(int nclass = 174, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "~/.mxnet/models")
        {
            throw new NotImplementedException();
        }
    }
}
