using System;

namespace MxNet.RTC
{
    public class CudaKernel : IDisposable
    {
        public CudaKernel(IntPtr handle, string name, bool is_ndarray, DType[] dtypes)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Launch(object[] args, Context ctx, (int, int, int) grid_dims, (int, int, int) block_dims,
            int shared_mem = 0)
        {
            throw new NotImplementedException();
        }
    }
}