using MxNet.Gluon;
using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class GroupNorm : HybridBlock
    {
        public int Ngroups { get; }
        public int InChannels { get; }
        public int Axis { get; }
        public float Epsilon { get; }

        public GroupNorm(int ngroups= 32, int in_channels= 0, int axis= 1, float epsilon= 1e-5f, Initializer beta_initializer= null, Initializer gamma_initializer= null, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            Ngroups = ngroups;
            InChannels = in_channels;
            Axis = axis;
            Epsilon = epsilon;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return F(x, args[0], args[1]);

            return null;
        }

        private NDArrayOrSymbol F(NDArray x, NDArray gamma, NDArray beta)
        {
            NDArray y = null;
            // normalization
            using (var ag =  Autograd.TrainMode()) 
            {
                y = x.ExpandDims(0).Reshape(0, 0, this.Ngroups, -1);
                y = y.Reshape(1, -3, -1);
                var batch = x.Shape[0];
                y = nd.BatchNorm(y, nd.Ones(new Shape(batch * this.Ngroups), ctx: x.Context), nd.Zeros(new Shape(batch * this.Ngroups), ctx: x.Context), nd.Zeros(new Shape(batch * this.Ngroups), ctx: x.Context), nd.Ones(new Shape(batch * this.Ngroups), ctx: x.Context), eps: Epsilon, axis: Axis);
            }

            // scale and shift
            y = nd.ReshapeLike(y, x).Reshape(0, 0, -1);
            y = y * gamma.Reshape(1, -1, 1) + beta.Reshape(1, -1, 1);
            return nd.ReshapeLike(y, x);
        }

        public override void Cast(DType dtype)
        {
            if (dtype.Name == "float16")
            {
                dtype = DType.Float32;
            }

            base.Cast(dtype);
        }
    }
}
