using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public partial class DataLoader
    {
        public static NDArrayList DefaultPadBatchifyFn(NDArrayList data)
        {
            throw new NotImplementedException();
        }

        public static NDArrayList DefaultMpPadBatchifyFn(NDArrayList data)
        {
            throw new NotImplementedException();
        }

        public static NDArrayList TsnMpBatchifyFn(NDArrayList data)
        {
            throw new NotImplementedException();
        }
    }
}
