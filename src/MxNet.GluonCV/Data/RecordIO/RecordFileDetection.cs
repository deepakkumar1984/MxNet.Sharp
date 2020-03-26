using MxNet.Gluon.Data.Vision.Datasets;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class RecordFileDetection : ImageRecordDataset
    {
        public RecordFileDetection(string filename, bool coord_normalized = true) : base(filename)
        {
            throw new NotImplementedException();
        }

        public override byte[] this[int idx] => throw new NotImplementedException();
    }
}
