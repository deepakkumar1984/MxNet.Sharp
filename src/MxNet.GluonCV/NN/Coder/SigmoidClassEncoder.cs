using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class SigmoidClassEncoder
    {
        public (NDArray, NDArray) Call(NDArray samples)
        {
            var target = (samples + 1) / 2;
            target = nd.Where(nd.Abs(samples) < 1e-05f, nd.Full(-1, target.Shape), target);
            // output: 1: pos, 0: negative, -1: ignore
            var mask = nd.Where(nd.Abs(samples) > 1e-05f, nd.OnesLike(samples), nd.ZerosLike(samples));
            return (target, mask);
        }
    }
}
