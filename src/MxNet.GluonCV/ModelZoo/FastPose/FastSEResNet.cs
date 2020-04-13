using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.FastPose
{
    public class FastSEResNet : HybridBlock
    {
        public FastSEResNet(string architecture, string norm_layer = "BatchNorm", FuncArgs kwargs = null, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public HybridSequential[] Stages
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public HybridSequential MakeLayer(HybridBlock block, int planes, int blocks, int stride= 1)
        {
            throw new NotImplementedException();
        }
    }
}
