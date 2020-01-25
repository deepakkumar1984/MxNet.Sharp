using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.RTC
{
    public class CudaModule : IDisposable
    {
        public CudaModule(string source, string[] options= null, string[] exports= null)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public CudaKernel GetKernel(string name, string signature) => throw new NotImplementedException();
    }
}
