using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Metrics
{
    public class TopKAccuracy : EvalMetric
    {
        public int TopK { get; set; }

        public TopKAccuracy(int top_k=1, string output_name = null, string label_name = null) : base("top_k_accuracy", output_name, label_name, true)
        {
            TopK = top_k;
            if (top_k <= 1)
                throw new ArgumentException("Please use Accuracy if top_k is no more than 1");

            Name = Name + "_" + top_k;
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            CheckLabelShapes(labels, preds);
            var pred_label = preds.Argsort().AsNumpy().astype(NumSharp.NPTypeCode.Int32); //ToDo: Use numpy argpartition
            var label = labels.AsNumpy().astype(NumSharp.NPTypeCode.Int32);
            var num_samples = pred_label.shape[0];
            var num_dims = pred_label.shape.Length;
            if (num_dims == 1)
                sum_metric += (pred_label.flat == label.flat).sum();
            else if(num_dims == 2)
            {
                var num_classes = pred_label.shape[1];
                TopK = (int)Math.Min(num_classes, TopK);
                for(int j=0;j<TopK;j++)
                {
                    float num_correct = (pred_label[":", num_classes - 1 - j].flat == label.flat).sum();
                    sum_metric += num_correct;
                    global_sum_metric += num_correct;
                }
            }

            num_inst += num_samples;
            global_num_inst += num_samples;
        }
    }
}
