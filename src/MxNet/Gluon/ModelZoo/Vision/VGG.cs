using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.ModelZoo.Vision
{
    public class VGG : HybridBlock
    {
        public VGG(int[] layers, int[] filters, int classes= 1000, bool batch_norm= false, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private HybridSequential MakeFeatures(int[] layers, int[] filters, bool batch_norm = false)
        {
            throw new NotImplementedException();
        }

        public static VGG GetVgg(int num_layers, bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();

        public static VGG Vgg11() => throw new NotImplementedException();

        public static VGG Vgg13() => throw new NotImplementedException();

        public static VGG Vgg16() => throw new NotImplementedException();

        public static VGG Vgg19() => throw new NotImplementedException();

        public static VGG Vgg11_BN() => throw new NotImplementedException();

        public static VGG Vgg13_BN() => throw new NotImplementedException();

        public static VGG Vgg16_BN() => throw new NotImplementedException();

        public static VGG Vgg19_BN() => throw new NotImplementedException();
    }
}
