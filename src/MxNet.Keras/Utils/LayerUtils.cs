using MxNet.Gluon.NN;
using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Utils
{
    public class LayerUtils
    {
        public static int CountParams(KerasSymbol[] weights)
        {
            throw new NotImplementedException();
        }

        public static void PrintSummary(Model model, int? line_length = null, int[] positions = null, Action<string> print_fn = null)
        {
            throw new NotImplementedException();
        }

        public static void ConvertAllKernelsInModel(Model model)
        {
            throw new NotImplementedException();
        }

        public static void ConvertDenseWeightsDataFormat(Dense dense, Shape previous_feature_map_shape, string target_data_format= "channels_first")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol[] GetSourceInputs(KerasSymbol tensor, Layer layer = null, int? node_index = null)
        {
            throw new NotImplementedException();
        }
    }
}
