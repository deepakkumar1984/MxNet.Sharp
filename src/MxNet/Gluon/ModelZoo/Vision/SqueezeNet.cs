using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.ModelZoo.Vision
{
    public class SqueezeNet : HybridBlock
    {
        public SqueezeNet(string version, int classes= 1000, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private static HybridSequential MakeFire(int squeeze_channels, int expand1x1_channels, int expand3x3_channels)
        {
            throw new NotImplementedException();
        }

        private static HybridSequential MakeFireConv(int channels, (int, int) kernel_size, (int, int) padding = default)
        {
            throw new NotImplementedException();
        }

        public static SqueezeNet GetSqueezeNet(string version, bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();

        public static SqueezeNet GetSqueezeNet1_0() => throw new NotImplementedException();

        public static SqueezeNet GetSqueezeNet1_1() => throw new NotImplementedException();

    }
}
