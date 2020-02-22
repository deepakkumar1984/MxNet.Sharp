using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.ModelZoo.Vision
{
    public class AlexNet : HybridBlock
    {
        public HybridSequential Features { get; set; }
        public Dense Output { get; set; }

        public AlexNet(int classes = 1000, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            Features = new HybridSequential(prefix);
            Features.Add(new Conv2D(64, kernel_size: (11, 11), strides: (4, 4), padding: (2, 2), activation: ActivationActType.Relu));
            Features.Add(new MaxPool2D(pool_size: (3, 3), strides: (2, 2)));

            Features.Add(new Conv2D(192, kernel_size: (5, 5), padding: (2, 2), activation: ActivationActType.Relu));
            Features.Add(new MaxPool2D(pool_size: (3, 3), strides: (2, 2)));

            Features.Add(new Conv2D(384, kernel_size: (3, 3), padding: (1, 1), activation: ActivationActType.Relu));
            Features.Add(new Conv2D(256, kernel_size: (3, 3), padding: (1, 1), activation: ActivationActType.Relu));
            Features.Add(new Conv2D(256, kernel_size: (3, 3), padding: (1, 1), activation: ActivationActType.Relu));
            Features.Add(new MaxPool2D(pool_size: (3, 3), strides: (2, 2)));
            Features.Add(new Flatten());
            Features.Add(new Dense(4096, activation: ActivationActType.Relu));
            Features.Add(new Dropout(0.5f));
            Features.Add(new Dense(4096, activation: ActivationActType.Relu));
            Features.Add(new Dropout(0.5f));

            Output = new Dense(classes);

            RegisterChild(Features);
            RegisterChild(Output);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            x = Features.Call(x, args);
            x = Output.Call(x, args);
            return x;
        }

        public static AlexNet GetAlexNet(bool pretrained = false, Context ctx = null, string root = "")
        {
            var net = new AlexNet();
            if (ctx == null)
                ctx = Context.CurrentContext;
            if(pretrained)
            {
                net.LoadParameters(ModelStore.GetModelFile("alexnet", root), ctx);
            }

            return net;
        }
    }
}
