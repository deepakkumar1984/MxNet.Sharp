using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Recordio
{
    public class MXIndexedRecordIO : MXRecordIO
    {
        public MXIndexedRecordIO(string idx_path, string uri, string flag, Type key_type = null) : base(uri, flag)
        {
            throw new NotImplementedException();
        }

        public override void Open()
        {
            base.Open();
            throw new NotImplementedException();
        }

        public override void Close()
        {
            base.Close();
            throw new NotImplementedException();
        }

        public override Dictionary<string, object> GetState()
        {
            var d = base.GetState();
            d["fidx"] = null;
            return d;
        }

        public void Seek(int idx) => throw new NotImplementedException();

        public int Tell() => throw new NotImplementedException();

        public byte[] ReadIdx(int idx) => throw new NotImplementedException();

        public void WriteIdx(int idx, byte[] buf) => throw new NotImplementedException();
    }
}
