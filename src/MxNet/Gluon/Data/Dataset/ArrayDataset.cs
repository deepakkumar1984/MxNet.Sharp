using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data
{
    public class ArrayDataset<T> : Dataset<TakeMode>
    {
        public ArrayDataset(List<T[]> args)
        {
            throw new NotImplementedException();
        }

        public override TakeMode this[int idx] => throw new NotImplementedException();

        public override int Length => throw new NotImplementedException();
    }
}
