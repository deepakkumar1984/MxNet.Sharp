using MxNet.Interop;
using System;
using System.Collections.Generic;
using System.IO;

namespace MxNet.Recordio
{
    public class MXIndexedRecordIO : MXRecordIO
    {
        public List<string> Keys { get; private set; }
        public string IdxPath { get; private set; }
        public Dictionary<object, int> Idx { get; private set; }
        public FileStream Fidx { get; private set; }

        public MXIndexedRecordIO(string idx_path, string uri, string flag) : base(uri, flag)
        {
            IdxPath = idx_path;
            Keys = new List<string>();
            Idx = new Dictionary<object, int>();
            Fidx = null;
        }

        public override void Open()
        {
            base.Open();
            Idx = new Dictionary<object, int>();
            Keys = new List<string>();
            if (Flag == "w")
                Fidx = File.OpenWrite(IdxPath);
            else if(Flag == "r")
                Fidx = File.OpenRead(IdxPath);

            if(!Writable)
            {
                var stream = new StreamReader(Fidx);
                while(!stream.EndOfStream)
                {
                    string[] line = stream.ReadLine().Split('\t');
                    var key = line[0];
                    Idx[key] = Convert.ToInt32(line[1]);
                    Keys.Add(key);
                }
            }
        }

        public override void Close()
        {
            base.Close();
            Fidx.Close();
        }

        public override Dictionary<string, object> GetState()
        {
            var d = base.GetState();
            d["fidx"] = null;
            return d;
        }

        public void Seek(int idx)
        {
            if (Writable)
                return;

            CheckPID(true);
            var pos = Idx[idx];
            NativeMethods.MXRecordIOReaderSeek(handle, pos);
        }

        public int Tell()
        {
            NativeMethods.MXRecordIOWriterTell(handle, out var pos);
            return pos;
        }

        public byte[] ReadIdx(int idx)
        {
            Seek(idx);
            return Read();
        }

        public void WriteIdx(int idx, byte[] buf)
        {
            int pos = Tell();
            Write(buf);
            StreamWriter writer = new StreamWriter(Fidx);
            writer.WriteLine($"{idx}\t{pos}");
            Idx[idx] = pos;
            Keys.Add(idx.ToString());
        }
    }
}