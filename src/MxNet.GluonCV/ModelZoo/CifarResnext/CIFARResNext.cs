using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.CifarResnext
{
    public class CIFARResNext : HybridBlock
    {
        public CIFARResNext(int[] layers, int cardinality, int bottleneck_width, int classes = 10, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeLayer(int channels, int num_layer, int stride, int stage_index, string norm_layer = "BatchNorm", FuncArgs norm_kwargs = null)
        {
            throw new NotImplementedException();
        }

        public static CIFARResNext GetCIFARResNext(int num_layers, int cardinality= 16, int bottleneck_width= 64, bool pretrained= false, Context ctx= null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static CIFARResNext Cifar_ResNext29_32x4d(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }

        public static CIFARResNext Cifar_ResNext29_16x4d(bool pretrained = false, Context ctx = null, string root = "~/mxnet/models")
        {
            throw new NotImplementedException();
        }
    }
}
