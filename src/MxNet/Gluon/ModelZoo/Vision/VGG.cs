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

        public static VGG GetVgg(int num_layers, bool pretrained = false, Context ctx = null, string root = "./models", bool batch_norm = false) => throw new NotImplementedException();

        public static VGG Vgg11(bool pretrained = false, Context ctx = null, string root = "./models") => GetVgg(11, pretrained, ctx, root);

        public static VGG Vgg13(bool pretrained = false, Context ctx = null, string root = "./models") => GetVgg(13, pretrained, ctx, root);

        public static VGG Vgg16(bool pretrained = false, Context ctx = null, string root = "./models") => GetVgg(16, pretrained, ctx, root);

        public static VGG Vgg19(bool pretrained = false, Context ctx = null, string root = "./models") => GetVgg(19, pretrained, ctx, root);

        public static VGG Vgg11_BN(bool pretrained = false, Context ctx = null, string root = "./models") => GetVgg(11, pretrained, ctx, root, true);

        public static VGG Vgg13_BN(bool pretrained = false, Context ctx = null, string root = "./models") => GetVgg(13, pretrained, ctx, root, true);

        public static VGG Vgg16_BN(bool pretrained = false, Context ctx = null, string root = "./models") => GetVgg(16, pretrained, ctx, root, true);

        public static VGG Vgg19_BN(bool pretrained = false, Context ctx = null, string root = "./models") => GetVgg(19, pretrained, ctx, root, true);
    }
}
