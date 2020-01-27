using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data
{
    public class SimpleDataset<T> : Dataset<T>
    {
        public SimpleDataset(T[] data)
        {
            throw new NotImplementedException();
        }

        public override T this[int idx] => throw new NotImplementedException();

        public override int Length => throw new NotImplementedException();
    }
}
