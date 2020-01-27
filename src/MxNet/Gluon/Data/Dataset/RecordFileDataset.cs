using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data
{
    public class RecordFileDataset : Dataset<string>
    {
        public RecordFileDataset(string filename)
        {
            throw new NotImplementedException();
        }

        public override string this[int idx] => throw new NotImplementedException();

        public override int Length => throw new NotImplementedException();
    }
}
