using System;
using System.Collections.Generic;
using System.Text;
using RecordIOHandle = System.IntPtr;

namespace MxNet.Recordio
{
    public class MXRecordIO : IDisposable
    {
        private RecordIOHandle handle;

        public MXRecordIO(string uri, string flag)
        {
            throw new NotImplementedException();
        }

        public virtual void Open() => throw new NotImplementedException();

        public virtual void Close() => throw new NotImplementedException();

        public virtual void Reset() => throw new NotImplementedException();

        public virtual void Write(byte[] buf) => throw new NotImplementedException();

        public virtual byte[] Read() => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public virtual Dictionary<string, object> GetState() => throw new NotImplementedException();

        public virtual void SetState(Dictionary<string, string> d) => throw new NotImplementedException();

        private void CheckPID(bool allow_reset = false) => throw new NotImplementedException();

    }
}
