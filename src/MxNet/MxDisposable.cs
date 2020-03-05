using System;

namespace MxNet
{
    public abstract class MxDisposable : IDisposable
    {
        public void Dispose()
        {
            Exit();
        }

        public abstract MxDisposable Enter();

        public abstract void Exit();
    }
}