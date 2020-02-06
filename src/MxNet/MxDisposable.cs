using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MxNet
{
    public abstract class MxDisposable : IDisposable
    {
        public abstract MxDisposable Enter();

        public abstract void Exit();

        public void Dispose()
        {
            Exit();   
        }
    }
}
