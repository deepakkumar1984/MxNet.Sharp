using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.SegBase
{
    public class MultiEvalModel
    {
        public MultiEvalModel(SegBaseModel module, int nclass, Context[] ctx_list, bool flip= true, float[] scales=null)
        {
            throw new NotImplementedException();
        }

        public NDArrayOrSymbolList ParallelForward(NDArrayOrSymbolList inputs)
        {
            throw new NotImplementedException();
        }

        public NDArrayOrSymbol Call(NDArrayOrSymbol image)
        {
            throw new NotImplementedException();
        }

        public NDArrayOrSymbol FlipInference(NDArrayOrSymbol image)
        {
            throw new NotImplementedException();
        }

        public ParameterDict CollectParams()
        {
            throw new NotImplementedException();
        }
    }
}
