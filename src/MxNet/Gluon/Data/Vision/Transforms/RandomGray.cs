using MxNet.Numpy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class RandomGray : HybridBlock
    {
        private float p;

        public RandomGray(float p = 0.5f)
        {
            this.p = p;
        }

        public override NDArrayOrSymbolList Forward(NDArrayOrSymbolList inputs)
        {
            var x = inputs[0];
            var args = inputs.ToNDArrays().Skip(1).ToList();
            var mat = np.concatenate(new ndarray[] { np.full(new Shape(3, 1), 0.2989), np.full(new Shape(3, 1), 0.587), np.full(new Shape(3, 1), 0.114) }, axis: 1);
            x = x.NdX.astype(dtype: "float32");
            var gray = np.where(this.p < np.random.uniform(), x, np.dot(x, mat));
            args.Insert(0, gray);
            return new NDArrayOrSymbolList(args.ToArray());
        }
    }
}
