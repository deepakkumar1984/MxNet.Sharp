using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data
{
    public class _TransformFirstClosure<T>
    {
        private Func<T, T> _fn;
        public _TransformFirstClosure(Func<T, T> fn)
        {
            _fn = fn;
        }

        public T[] Call(T x, T[] args)
        {
            if(args != null)
            {
                List<T> list = new List<T>();
                list.Add(_fn(x));
                list.AddRange(args);
                return list.ToArray();
            }

            return new T[] { _fn(x) };
        }
    }
}
