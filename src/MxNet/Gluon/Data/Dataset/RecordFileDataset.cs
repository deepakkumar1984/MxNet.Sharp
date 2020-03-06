using System.IO;
using MxNet.Recordio;

namespace MxNet.Gluon.Data
{
    public class RecordFileDataset : Dataset<byte[]>
    {
        private readonly MXIndexedRecordIO _record;

        public RecordFileDataset(string filename)
        {
            IdxFile = Path.GetFileNameWithoutExtension(filename) + ".idx";
            Filename = filename;
            _record = new MXIndexedRecordIO(IdxFile, filename, "r");
        }

        public string IdxFile { get; set; }

        public string Filename { get; set; }

        public override byte[] this[int idx] => _record.ReadIdx(idx);

        public override int Length => _record.Keys.Count;
    }
}