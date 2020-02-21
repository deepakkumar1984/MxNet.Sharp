using NumSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Initializers
{
    public class Orthogonal : Initializer
    {
        public float Scale { get; set; }

        public string RandType { get; set; }

        public Orthogonal(float scale = 1.414f, string rand_type = "uniform")
        {
            Scale = scale;
            RandType = rand_type;
        }

        public override void InitWeight(string name, ref NDArray arr)
        {
            var nout = arr.Shape[0];
            int nin = 1;
            NDArray tmp = null;
            NDArray res = null;
            for (int i = 1; i < arr.Shape.Dimension; i++)
                nin *= arr.Shape[i];

            if (RandType == "uniform")
                tmp = nd.Random.Uniform(-1, 1, new Shape(nout, nin));
            else if(RandType == "notmal")
                tmp = nd.Random.Normal(0, 1, new Shape(nout, nin));

            var (u, v) = nd.LinalgSyevd(tmp); //ToDo: use np.linalg.svd
            if (u.Shape == v.Shape)
                res = u;
            else
                res = v;

            res = Scale * res.Reshape(arr.Shape);
            arr = res;
        }
    }
}
