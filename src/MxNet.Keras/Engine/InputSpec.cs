using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Engine
{
    public class InputSpec
    {
        internal Dictionary<int, int> axes;
        internal DType dtype;
        internal int? max_ndim;
        internal int? min_ndim;
        internal int ndim;
        internal Shape shape;

        public InputSpec(DType dtype= null, Shape shape= null, int? ndim= null, int? max_ndim= null, int? min_ndim= null, Dictionary<int, int> axes= null)
        {
            this.dtype = dtype;
            this.shape = shape;
            if (shape != null)
            {
                this.ndim = shape.Dimension;
            }
            else
            {
                this.ndim = ndim.Value;
            }
            this.max_ndim = max_ndim;
            this.min_ndim = min_ndim;
            this.axes = axes != null ? axes : new Dictionary<int, int>();
        }
    }
}
