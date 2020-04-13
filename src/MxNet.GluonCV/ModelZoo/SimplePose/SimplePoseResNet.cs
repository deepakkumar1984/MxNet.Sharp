using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.SimplePose
{
    public class SimplePoseResNet : HybridBlock
    {
        public SimplePoseResNet(string base_name= "resnet50_v1b", bool pretrained_base= false, Context pretrained_ctx= null, int num_joints= 17, int num_deconv_layers= 3, (int, int, int)? num_deconv_filters= null, (int, int, int)? num_deconv_kernels= null, int final_conv_kernel= 1, bool deconv_with_bias= false, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private (int, int, int) GetDeConvCfg(int deconv_kernel)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeDeConvLayer(int num_layers, int num_filters, int num_kernels)
        {
            throw new NotImplementedException();
        }

        public static SimplePoseResNet GetSimplePoseResNet(string base_name, bool pretrained= false, Context ctx= null, string root= "~/mxnet", int num_joints = 17, int num_deconv_layers = 3, (int, int, int)? num_deconv_filters = null, (int, int, int)? num_deconv_kernels = null, int final_conv_kernel = 1, bool deconv_with_bias = false, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static SimplePoseResNet SimplePose_Resnet18_V1B(string base_name, bool pretrained = false, Context ctx = null, string root = "~/mxnet", int num_joints = 17, int num_deconv_layers = 3, (int, int, int)? num_deconv_filters = null, (int, int, int)? num_deconv_kernels = null, int final_conv_kernel = 1, bool deconv_with_bias = false, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static SimplePoseResNet SimplePose_Resnet50_V1B(string base_name, bool pretrained = false, Context ctx = null, string root = "~/mxnet", int num_joints = 17, int num_deconv_layers = 3, (int, int, int)? num_deconv_filters = null, (int, int, int)? num_deconv_kernels = null, int final_conv_kernel = 1, bool deconv_with_bias = false, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static SimplePoseResNet SimplePose_Resnet110_V1B(string base_name, bool pretrained = false, Context ctx = null, string root = "~/mxnet", int num_joints = 17, int num_deconv_layers = 3, (int, int, int)? num_deconv_filters = null, (int, int, int)? num_deconv_kernels = null, int final_conv_kernel = 1, bool deconv_with_bias = false, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static SimplePoseResNet SimplePose_Resnet152_V1B(string base_name, bool pretrained = false, Context ctx = null, string root = "~/mxnet", int num_joints = 17, int num_deconv_layers = 3, (int, int, int)? num_deconv_filters = null, (int, int, int)? num_deconv_kernels = null, int final_conv_kernel = 1, bool deconv_with_bias = false, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static SimplePoseResNet SimplePose_Resnet50_V1D(string base_name, bool pretrained = false, Context ctx = null, string root = "~/mxnet", int num_joints = 17, int num_deconv_layers = 3, (int, int, int)? num_deconv_filters = null, (int, int, int)? num_deconv_kernels = null, int final_conv_kernel = 1, bool deconv_with_bias = false, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static SimplePoseResNet SimplePose_Resnet101_V1D(string base_name, bool pretrained = false, Context ctx = null, string root = "~/mxnet", int num_joints = 17, int num_deconv_layers = 3, (int, int, int)? num_deconv_filters = null, (int, int, int)? num_deconv_kernels = null, int final_conv_kernel = 1, bool deconv_with_bias = false, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }

        public static SimplePoseResNet SimplePose_Resnet152_V1D(string base_name, bool pretrained = false, Context ctx = null, string root = "~/mxnet", int num_joints = 17, int num_deconv_layers = 3, (int, int, int)? num_deconv_filters = null, (int, int, int)? num_deconv_kernels = null, int final_conv_kernel = 1, bool deconv_with_bias = false, string prefix = "", ParameterDict @params = null)
        {
            throw new NotImplementedException();
        }
    }
}
