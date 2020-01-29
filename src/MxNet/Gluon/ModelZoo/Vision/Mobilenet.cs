using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.ModelZoo.Vision
{
    public class RELU6 : HybridBlock
    {
        public RELU6(string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }

    public class LinearBottleneck : HybridBlock
    {
        public LinearBottleneck(int in_channels, int channels, int t, int stride, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }

    public class MobileNet : HybridBlock
    {
        public MobileNet(float multiplier= 1, int classes= 1000, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();

        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        internal static void AddConv(HybridSequential @out, int channels= 1, int kernel= 1, int stride= 1, int pad= 0,
                                        int num_group= 1, bool active= true, bool relu6= false)
        {
            throw new NotImplementedException();
        }

        internal static void AddConvDW(HybridSequential @out, int dw_channels, int channels = 1, int stride = 1, bool relu6 = false)
        {
            throw new NotImplementedException();
        }

        public static MobileNet GetMobileNet(float multiplier, bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();

        public static MobileNet MobileNet1_0(bool pretrained = false, Context ctx = null) => throw new NotImplementedException();

        public static MobileNet MobileNet0_75(bool pretrained = false, Context ctx = null) => throw new NotImplementedException();

        public static MobileNet MobileNet0_5(bool pretrained = false, Context ctx = null) => throw new NotImplementedException();

        public static MobileNet MobileNet0_25(bool pretrained = false, Context ctx = null) => throw new NotImplementedException();
    }

    public class MobileNetV2 : HybridBlock
    {
        public MobileNetV2(float multiplier = 1, int classes = 1000, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();

        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public static MobileNet GetMobileNetV2(float multiplier, bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();

        public static MobileNet MobileNetV2_1_0(bool pretrained = false, Context ctx = null) => throw new NotImplementedException();

        public static MobileNet MobileNetV2_0_75(bool pretrained = false, Context ctx = null) => throw new NotImplementedException();

        public static MobileNet MobileNetV2_0_5(bool pretrained = false, Context ctx = null) => throw new NotImplementedException();

        public static MobileNet MobileNetV2_0_25(bool pretrained = false, Context ctx = null) => throw new NotImplementedException();
    }
}
