using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MxNet.Recordio;

namespace MxNet.Gluon.Data
{
    public class RecordFileDataset : Dataset<string>
    {
        public string IdxFile { get; set; }

        public string Filename { get; set; }

        private MXIndexedRecordIO _record;

        public RecordFileDataset(string filename)
        {
            IdxFile = Path.GetFileNameWithoutExtension(filename) + ".idx";
            Filename = filename;
            _record = new MXIndexedRecordIO(IdxFile, filename, "r");
        }

        public override string this[int idx] => _record.ReadIdx(idx);

        public override int Length => _record.Keys.Length;
    }
}
