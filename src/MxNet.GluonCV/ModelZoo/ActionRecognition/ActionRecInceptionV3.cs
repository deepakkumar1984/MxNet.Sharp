using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.ActionRecognition
{
    public class ActionRecInceptionV3 : HybridBlock
    {
        public ActionRecInceptionV3(int nclass, bool pretrained_base = true, bool partial_bn = true, float dropout_ratio = 0.8f, float init_std = 0.001f,
                            int feat_dim = 2048, int num_segments = 1, int num_crop = 1, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public static ActionRecInceptionV3 InceptionV1_UCF101(int nclass = 101, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "")
        {
            throw new NotImplementedException();
        }

        public static ActionRecInceptionV3 InceptionV1_HMDB51(int nclass = 51, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "")
        {
            throw new NotImplementedException();
        }

        public static ActionRecInceptionV3 InceptionV1_Kinetics400(int nclass = 400, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "")
        {
            throw new NotImplementedException();
        }

        public static ActionRecInceptionV3 InceptionV1_SthSthv2(int nclass = 174, bool pretrained = false, bool pretrained_base = true, bool use_tsn = false, int num_segments = 1, int num_crop = 1, bool partial_bn = true, Context ctx = null, string root = "")
        {
            throw new NotImplementedException();
        }
    }
}
