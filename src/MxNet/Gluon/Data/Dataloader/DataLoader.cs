using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision
{
    public class DataLoader
    {
        public static NDArray RebuildArray(int shared_pid, int shared_id, Shape shape, DType dtype) => throw new NotImplementedException();

        public static (NDArray, IntPtr) ReduceNDArray(NDArray data) => throw new NotImplementedException();

        public static NDArray DefaultBatchifyFn(NDArray data) => throw new NotImplementedException();

        public static NDArray DefaultMPBatchifyFn(NDArray data) => throw new NotImplementedException();
    }
}
