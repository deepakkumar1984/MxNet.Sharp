using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class FeatureExpander : SymbolBlock
    {
        public FeatureExpander(HybridBlock network, string[] outputs, int num_filters, bool use_1x1_transition= true,
                            bool use_bn= true, float reduce_ratio= 1, int min_depth= 128, bool global_pool= false,
                            bool pretrained= false, Context ctx= null, string[] inputs= null, ParameterDict @params = null) : base(null, null, @params)
        {
        }

        public FeatureExpander(Symbol network, string[] outputs, int num_filters, bool use_1x1_transition = true,
                            bool use_bn = true, float reduce_ratio = 1, int min_depth = 128, bool global_pool = false,
                            bool pretrained = false, Context ctx = null, string[] inputs = null, ParameterDict @params = null) : base(null, null, @params)
        {
        }

        public FeatureExpander(string network, string[] outputs, int num_filters, bool use_1x1_transition = true,
                            bool use_bn = true, float reduce_ratio = 1, int min_depth = 128, bool global_pool = false,
                            bool pretrained = false, Context ctx = null, string[] inputs = null, ParameterDict @params = null) : base(null, null, @params)
        {
        }
    }
}
