using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class Normalize : HybridBlock
    {
        private float _mean;
        private float _std;

        public Normalize(float mean= 0, float std= 1)
        {
            _mean = mean;
            _std = std;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.Image.Normalize(x, new Tuple<double>(_mean), new Tuple<double>(_std));

            return sym.Image.Normalize(x, new Tuple<double>(_mean), new Tuple<double>(_std));
        }
    }
}
