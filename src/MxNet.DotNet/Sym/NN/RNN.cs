using mx_float = System.Single;
using uint32_t = System.UInt32;

// ReSharper disable once CheckNamespace
namespace MxNet.DotNet
{
    public enum RNNMode
    {
        GRU = 0,
        LSTM = 1,
        RNNReLU = 2,
        RNNTanh = 3
    }

    public partial class NeuralNet
    {

        #region Fields

        private readonly string[] RNNModeValues =
        {
            "gru",
            "lstm",
            "rnn_relu",
            "rnn_tanh"
        };

        #endregion

        #region Methods

        public Symbol RNN(Symbol data,
                                 Symbol parameters,
                                 Symbol state,
                                 Symbol stateCell,
                                 uint32_t stateSize,
                                 uint32_t numLayers,
                                 RNNMode mode,
                                 bool bidirectional = false,
                                 mx_float p = 0,
                                 bool stateOutputs = false,
                                 int? projection_size = null,
                                 double? lstm_state_clip_min = null,
                                 double? lstm_state_clip_max = null,
                                 bool lstm_state_clip_nan = false,
                                 string name = "")
        {
            var op = new Operator("RNN").SetParam("state_size", stateSize)
                                      .SetParam("num_layers", numLayers)
                                      .SetParam("mode", RNNModeValues[(int)mode])
                                      .SetParam("bidirectional", bidirectional)
                                      .SetParam("p", p)
                                      .SetParam("state_outputs", stateOutputs)
                                      .SetParam("lstm_state_clip_nan", lstm_state_clip_nan)
                                      .SetInput("data", data)
                                      .SetInput("parameters", parameters)
                                      .SetInput("state", state)
                                      .SetInput("state_cell", stateCell);


            if (projection_size.HasValue)
                op.SetParam("projection_size", projection_size.Value);

            if (lstm_state_clip_min.HasValue)
                op.SetParam("lstm_state_clip_min", lstm_state_clip_min.Value);

            if (lstm_state_clip_max.HasValue)
                op.SetParam("lstm_state_clip_max", lstm_state_clip_max.Value);

            return op.CreateSymbol(name);
        }

        #endregion

    }

}
