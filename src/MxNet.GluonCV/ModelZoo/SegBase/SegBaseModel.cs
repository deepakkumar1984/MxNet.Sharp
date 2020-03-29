using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.SegBase
{
    public class SegBaseModel : HybridBlock
    {
        public SegBaseModel(int nclass, bool aux, string backbone= "resnet50", int? height= null, int? width= null, int base_size= 520, int crop_size= 480, bool pretrained_base= true, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public virtual (NDArrayOrSymbol, NDArrayOrSymbol) BaseForward(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        public virtual NDArrayOrSymbol Evaluate(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        public virtual NDArrayOrSymbol Demo(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        public virtual NDArrayOrSymbol Predict(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        internal NDArray ResizeImage(NDArray img, int w, int h)
        {
            throw new NotImplementedException();
        }

        internal NDArray PadImage(NDArray img, int crop_size = 480)
        {
            throw new NotImplementedException();
        }

        internal NDArray CropImage(NDArray img, int h0, int h1, int w0, int w1)
        {
            throw new NotImplementedException();
        }

        internal NDArray FlipImage(NDArray img)
        {
            throw new NotImplementedException();
        }
    }
}
