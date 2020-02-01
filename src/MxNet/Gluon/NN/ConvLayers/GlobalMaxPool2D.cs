using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.NN
{
    public class GlobalMaxPool2D : _Pooling
    {
        public GlobalMaxPool2D(string layout = "NCHW", string prefix = null, ParameterDict @params = null)
                        : base(new int[] { 1, 1 }, null, new int[] { 0, 0 }, true, true, "max", layout, null, prefix, @params)
        {
            if (layout != "NCHW" && layout != "NHWC")
                throw new Exception("Only NCHW and NHWC layouts are valid for 2D Pooling");
        }
    }
}
