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

        public AlexNet(int classes = 1000, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            Features = new HybridSequential(prefix);
            Features.Add(new Conv2D(64, kernel_size: (11, 11), strides: (4, 4), padding: (2, 2), activation: "relu"));
            Features.Add(new MaxPool2D(pool_size: (3, 3), strides: (2, 2)));

            Features.Add(new Conv2D(192, kernel_size: (5, 5), padding: (2, 2), activation: "relu"));
            Features.Add(new MaxPool2D(pool_size: (3, 3), strides: (2, 2)));

            Features.Add(new Conv2D(384, kernel_size: (3, 3), padding: (1, 1), activation: "relu"));
            Features.Add(new Conv2D(256, kernel_size: (3, 3), padding: (1, 1), activation: "relu"));
            Features.Add(new Conv2D(256, kernel_size: (3, 3), padding: (1, 1), activation: "relu"));
            Features.Add(new MaxPool2D(pool_size: (3, 3), strides: (2, 2)));
            Features.Add(new Flatten());
            Features.Add(new Dense(4096, activation: ActivationActType.Relu));
            Features.Add(new Dropout(0.5f));
            Features.Add(new Dense(4096, activation: ActivationActType.Relu));
            Features.Add(new Dropout(0.5f));

            Output = new Dense(classes);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            x = Features.Call(x);
            x = Output.Call(x);
            return x;
        }

        public static AlexNet GetAlexNet(bool pretrained = false, Context ctx = null, string root = "./models")
        {
            var net = new AlexNet();
            if(pretrained)
            {
                net.LoadParameters(ModelStore.GetModelFile("alexnet", root), ctx);
            }

            return net;
        }
    }
}
