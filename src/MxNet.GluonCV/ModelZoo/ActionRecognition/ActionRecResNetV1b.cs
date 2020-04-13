using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.ActionRecognition
{
    public class ActionRecResNetV1b : HybridBlock
    {
        public ActionRecResNetV1b(int depth, int nclass, bool pretrained_base= true, float dropout_ratio= 0.5f, float init_std= 0.01f, int feat_dim= 2048, int num_segments= 1, int num_crop= 1, bool partial_bn= false, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public static ActionRecResNetV1b Resnet18_V1B_SthSthv2(int nclass = 174, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "")
        {
            throw new NotImplementedException();
        }

        public static ActionRecResNetV1b Resnet34_V1B_SthSthv2(int nclass = 174, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "")
        {
            throw new NotImplementedException();
        }

        public static ActionRecResNetV1b Resnet50_V1B_SthSthv2(int nclass = 174, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "")
        {
            throw new NotImplementedException();
        }

        public static ActionRecResNetV1b Resnet101_V1B_SthSthv2(int nclass = 174, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "")
        {
            throw new NotImplementedException();
        }

        public static ActionRecResNetV1b Resnet152_V1B_SthSthv2(int nclass = 174, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "")
        {
            throw new NotImplementedException();
        }

        public static ActionRecResNetV1b Resnet18_V1B_Kinetics400(int nclass = 400, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "")
        {
            throw new NotImplementedException();
        }

        public static ActionRecResNetV1b Resnet34_V1B_Kinetics400(int nclass = 400, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "")
        {
            throw new NotImplementedException();
        }

        public static ActionRecResNetV1b Resnet50_V1B_Kinetics400(int nclass = 400, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "")
        {
            throw new NotImplementedException();
        }

        public static ActionRecResNetV1b Resnet101_V1B_Kinetics400(int nclass = 400, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "")
        {
            throw new NotImplementedException();
        }

        public static ActionRecResNetV1b Resnet152_V1B_Kinetics400(int nclass = 400, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "")
        {
            throw new NotImplementedException();
        }

        public static ActionRecResNetV1b Resnet50_V1B_UCF101(int nclass = 101, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "")
        {
            throw new NotImplementedException();
        }

        public static ActionRecResNetV1b Resnet50_V1B_HMDB51(int nclass = 51, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "")
        {
            throw new NotImplementedException();
        }

        public static ActionRecResNetV1b Resnet50_V1B_Custom(int nclass = 400, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "")
        {
            throw new NotImplementedException();
        }
    }
}
