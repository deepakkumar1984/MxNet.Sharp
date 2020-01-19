using System;
namespace MxNetLib.Metrics
{
    public class Torch : Loss
    {
        public Torch(string output_name = null, string label_name = null) : base("torch", output_name, label_name)
        {
        }
    }
}
