/*****************************************************************************
   Copyright 2018 The MxNet.Sharp Authors. All Rights Reserved.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************/
using MxNet.Gluon.NN;

namespace MxNet.Gluon.ModelZoo.Vision
{
    public class AlexNet : HybridBlock
    {
        public AlexNet(int classes = 1000, string prefix = null, ParameterDict @params = null) : base("", @params)
        {
            Features = new HybridSequential("");
            Features.Add(new Conv2D(64, (11, 11), (4, 4), (2, 2), activation: ActivationType.Relu, prefix: prefix));
            Features.Add(new MaxPool2D((3, 3), (2, 2), prefix: prefix));

            Features.Add(new Conv2D(192, (5, 5), padding: (2, 2), activation: ActivationType.Relu, prefix: prefix));
            Features.Add(new MaxPool2D((3, 3), (2, 2), prefix: prefix));

            Features.Add(new Conv2D(384, (3, 3), padding: (1, 1), activation: ActivationType.Relu, prefix: prefix));
            Features.Add(new Conv2D(256, (3, 3), padding: (1, 1), activation: ActivationType.Relu, prefix: prefix));
            Features.Add(new Conv2D(256, (3, 3), padding: (1, 1), activation: ActivationType.Relu, prefix: prefix));
            Features.Add(new MaxPool2D((3, 3), (2, 2), prefix: prefix));
            Features.Add(new Flatten(prefix: prefix));
            Features.Add(new Dense(4096, ActivationType.Relu, prefix: prefix));
            Features.Add(new Dropout(0.5f, prefix: prefix));
            Features.Add(new Dense(4096, ActivationType.Relu, prefix: prefix));
            Features.Add(new Dropout(0.5f, prefix: prefix));

            Output = new Dense(classes, prefix: prefix);

            RegisterChild(Features, "");
            RegisterChild(Output, "");
        }

        public HybridSequential Features { get; set; }
        public Dense Output { get; set; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            x = Features.Call(x, args);
            x = Output.Call(x, args);
            return x;
        }

        public static AlexNet GetAlexNet(bool pretrained = false, Context ctx = null, string root = "", string prefix = null, ParameterDict @params = null)
        {
            var net = new AlexNet(prefix: prefix, @params: @params);
            if (ctx == null)
                ctx = Context.CurrentContext;
            if (pretrained) net.LoadParameters(ModelStore.GetModelFile("alexnet", root), ctx);

            return net;
        }
    }
}