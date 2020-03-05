using System;

namespace MxNet.Initializers
{
    public class LSTMBias : Initializer
    {
        public LSTMBias(float forget_bias = 1)
        {
            ForgetBias = forget_bias;
        }

        public float ForgetBias { get; set; }

        public override void InitWeight(string name, ref NDArray arr)
        {
            arr.Constant(0);
            var num_hidden = Convert.ToInt32(arr.Shape[0] / 4);
            var data = arr.GetValues<float>();
            for (var i = num_hidden; i < 2 * num_hidden; i++)
                data[i] = ForgetBias;

            arr.SyncCopyFromCPU(data);
        }
    }
}