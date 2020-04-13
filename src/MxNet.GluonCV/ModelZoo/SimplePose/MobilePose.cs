using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.SimplePose
{
    public class MobilePose : HybridBlock
    {
        public MobilePose(string base_name, string[] base_attrs= null, int num_joints= 17, bool pretrained_base= false, Context pretrained_ctx= null, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public static MobilePose GetMobilePose(string base_name, Context ctx = null, bool pretrained = false, string root = "~/mxnet", string[] base_attrs = null, int num_joints = 17, bool pretrained_base = false, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static MobilePose MobilePose_Resnet18_V1B(Context ctx = null, bool pretrained = false, string root = "~/mxnet", int num_joints = 17, bool pretrained_base = false, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static MobilePose MobilePose_Resnet50_V1B(Context ctx = null, bool pretrained = false, string root = "~/mxnet", int num_joints = 17, bool pretrained_base = false, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static MobilePose MobilePose_Mobilenet1_0(Context ctx = null, bool pretrained = false, string root = "~/mxnet", int num_joints = 17, bool pretrained_base = false, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static MobilePose MobilePose_MobilenetV2_1_0(Context ctx = null, bool pretrained = false, string root = "~/mxnet", int num_joints = 17, bool pretrained_base = false, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static MobilePose MobilePose_MobilenetV3_Small(Context ctx = null, bool pretrained = false, string root = "~/mxnet", int num_joints = 17, bool pretrained_base = false, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static MobilePose MobilePose_MobilenetV3_Large(Context ctx = null, bool pretrained = false, string root = "~/mxnet", int num_joints = 17, bool pretrained_base = false, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }
    }
}
