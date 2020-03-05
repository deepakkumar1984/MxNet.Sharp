using System.IO;
using MxNet.Recordio;

namespace MxNet.Gluon.Data
{
    public class RecordFileDataset : Dataset<string>
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

        public override string this[int idx] => _record.ReadIdx(idx);

        public override int Length => _record.Keys.Length;
    }
}