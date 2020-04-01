using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class NumPyBBoxCornerToCenter
    {
        public NumPyBBoxCornerToCenter(int axis= -1, bool split= false)
        {
            Axis = axis;
            Split = split;
        }

        public int Axis { get; }
        public bool Split { get; }

        public NDArrayList Call(NDArray x)
        {
            var splitArray = nd.Split(x, 4, axis: this.Axis);
            var xmin = splitArray[0];
            var ymin = splitArray[1];
            var xmax = splitArray[2];
            var ymax = splitArray[3];
            // note that we do not have +1 here since our nms and box iou does not.
            // this is different that detectron.
            var width = xmax - xmin;
            var height = ymax - ymin;
            x = xmin + width * 0.5f;
            var y = ymin + height * 0.5f;
            if (!this.Split)
            {
                return nd.Concat(new NDArrayList(x, y, width, height), dim: this.Axis);
            }
            else
            {
                return new NDArrayList(x, y, width, height);
            }
        }
    }
}
