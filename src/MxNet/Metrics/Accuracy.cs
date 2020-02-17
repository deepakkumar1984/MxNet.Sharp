using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Metrics
{
    public class Accuracy : EvalMetric
    {
        public int Axis { get; set; }

        public Accuracy(int axis = 1, string output_name = null, string label_name = null) : base("accuracy", output_name, label_name, true)
        {
            Axis = axis;
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            CheckLabelShapes(labels, preds, true);
            NumSharp.NDArray pred_label = null;
            if (preds.Shape != labels.Shape)
                pred_label = preds.Argmax(Axis).AsNumpy().astype(NumSharp.NPTypeCode.Int32);
            else
                pred_label = preds.AsNumpy().astype(NumSharp.NPTypeCode.Int32);
            
            var label = labels.AsNumpy().astype(NumSharp.NPTypeCode.Int32);
            label = label.flat;
            pred_label = pred_label.flat;
            var num_correct = (pred_label == label).astype(NumSharp.NPTypeCode.Float).sum().Data<float>()[0];
            sum_metric += num_correct;
            global_sum_metric += num_correct;
            num_inst += pred_label.Shape.Size;
            global_num_inst += pred_label.Shape.Size;
        }
    }
}
