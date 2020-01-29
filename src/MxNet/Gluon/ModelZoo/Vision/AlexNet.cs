using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.ModelZoo.Vision
{
    public class AlexNet : HybridBlock
    {
        public AlexNet(int classes = 1000, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public static AlexNet GetAlexNet(bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();
    }
}
