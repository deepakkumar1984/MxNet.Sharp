using SharpCV;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class CastAug : Augmenter
    {
        public DType DataType { get; set; }

        public CastAug(DType dtype)
        {
            DataType = dtype;
        }

        public override NDArray Call(NDArray src)
        {
            return src.AsType(DataType);
        }
    }
}
