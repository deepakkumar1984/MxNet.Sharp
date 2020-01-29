using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.ModelZoo.Vision
{
    public class ResNet
    {
        internal static Conv2D Conv3x3(int channels, int stride, int in_channels)
        {
            throw new NotImplementedException();
        }

        public static ResNet GetResNet(int version, int num_layers, bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();

        public static ResNet ResNet18_v1(bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();

        public static ResNet ResNet34_v1(bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();

        public static ResNet ResNet50_v1(bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();

        public static ResNet ResNet101_v1(bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();

        public static ResNet ResNet152_v1(bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();

        public static ResNet ResNet18_v2(bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();

        public static ResNet ResNet34_v2(bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();

        public static ResNet ResNet50_v2(bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();

        public static ResNet ResNet101_v2(bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();

        public static ResNet ResNet152_v2(bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();
    }

    public class BasicBlockV1 : HybridBlock
    {
        public BasicBlockV1(int channels, int stride, bool downsample= false, int in_channels= 0, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }

    public class BasicBlockV2 : HybridBlock
    {
        public BasicBlockV2(int channels, int stride, bool downsample = false, int in_channels = 0, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }

    public class BottleneckV1 : HybridBlock
    {
        public BottleneckV1(int channels, int stride, bool downsample = false, int in_channels = 0, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }

    public class BottleneckV2 : HybridBlock
    {
        public BottleneckV2(int channels, int stride, bool downsample = false, int in_channels = 0, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }

    public class ResNetV1 : HybridBlock
    {
        public ResNetV1(HybridBlock block, int[] layers, int[] channels, int classes = 1000, bool thumbnail = false, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private void MakeLayer(HybridBlock block, int[] layers, int[] channels, int stride, int stage_index, int in_channels = 0)
        {
            throw new NotImplementedException();
        }
    }

    public class ResNetV2 : HybridBlock
    {
        public ResNetV2(HybridBlock block, int[] layers, int[] channels, int classes = 1000, bool thumbnail = false, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private void MakeLayer(HybridBlock block, int[] layers, int[] channels, int stride, int stage_index, int in_channels = 0)
        {
            throw new NotImplementedException();
        }
    }
}
