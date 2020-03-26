using MxNet.Gluon.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class ImageTxtDataset : Dataset<(NDArray, NDArray)>
    {
        public ImageTxtDataset(List<(string, string)> items, int flag = 1, Func<(NDArray, NDArray, (NDArray, NDArray))> transform = null)
        {
            throw new NotImplementedException();
        }

        public override (NDArray, NDArray) this[int idx] => throw new NotImplementedException();

        public override int Length => throw new NotImplementedException();
    }
}
