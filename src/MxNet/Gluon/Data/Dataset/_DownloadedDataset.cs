using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data
{
    public class _DownloadedDataset : Dataset<NDArrayDict>
    {
        public _DownloadedDataset(string root, Func<NDArrayDict, NDArrayDict> transform)
        {
            throw new NotImplementedException();
        }

        public override NDArrayDict this[int idx] => throw new NotImplementedException();

        public override int Length => throw new NotImplementedException();
    }
}
