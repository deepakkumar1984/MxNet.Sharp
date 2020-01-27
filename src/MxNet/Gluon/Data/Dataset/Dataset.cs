using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data
{
    public abstract class Dataset<T>
    {
        public abstract int Length { get; }

        public abstract T this[int idx]
        {
            get;
        }
        
        public void Transform(Func<T, T> fn, bool lazy = true)
        {
            throw new NotImplementedException();
        }

        public void TransformFirst(Func<T, T> fn, bool lazy = true)
        {
            throw new NotImplementedException();
        }
    }
}
