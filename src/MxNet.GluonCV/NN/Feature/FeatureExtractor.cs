using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class FeatureExtractor : SymbolBlock
    {
        public FeatureExtractor(HybridBlock network, string[] outputs, string[] inputs = null, bool pretrained = false, ParameterDict @params = null) : base(null, null, @params)
        {
            throw new NotImplementedException();
        }

        public FeatureExtractor(Symbol network, string[] outputs, string[] inputs = null, bool pretrained = false, ParameterDict @params = null) : base(null, null, @params)
        {
            throw new NotImplementedException();
        }

        public FeatureExtractor(string network, string[] outputs, string[] inputs = null, bool pretrained = false, ParameterDict @params = null) : base(null, null, @params)
        {
            throw new NotImplementedException();
        }
    }
}
