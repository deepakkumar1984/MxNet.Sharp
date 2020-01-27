using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision.Datasets
{
    public class ImageRecordDataset : RecordFileDataset
    {
        public ImageRecordDataset(string filename, int flag = 1, Func<NDArray, NDArray> transform = null) : base(filename)
        {
            throw new NotImplementedException();
        }
    }
}
