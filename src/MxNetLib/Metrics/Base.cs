using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MxNetLib.Metrics
{
    public class Base
    {
        public static EvalMetric Create(string metric, FuncArgs args)
        {
            Type type = Assembly.GetExecutingAssembly().GetType("MxNetLib.Metric." + metric, true, true);
            return (EvalMetric)Activator.CreateInstance(type, args.Values);
        }

        public void CheckLabelShapes(NDArray labels, NDArray preds, bool shape = false)
        {
            Shape label_shape = null;
            Shape pred_shape = null;
            if (!shape)
            {
                label_shape = new Shape(labels.Size);
                pred_shape = new Shape(preds.Size);
            }
            else
            {
                label_shape = labels.Shape;
                pred_shape = preds.Shape;
            }

            if (label_shape.Dimension != pred_shape.Dimension && label_shape.Size != pred_shape.Size)
            {
                throw new ArgumentException(string.Format("Shape of labels {0} does not match shape of predictions {1}", label_shape.ToString(), pred_shape.ToString()));
            }
        }
    }
}
