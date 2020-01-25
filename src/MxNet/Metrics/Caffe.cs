using System;
namespace MxNet.Metrics
{
    public class Caffe : Loss
    {
        public Caffe(string output_name = null, string label_name = null) : base("caffe", output_name, label_name)
        {
        }
    }
}
