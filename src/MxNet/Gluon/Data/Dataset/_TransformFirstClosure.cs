using System;
using System.Collections.Generic;

namespace MxNet.Gluon.Data
{
    public class _TransformFirstClosure<T>
    {
        private readonly Func<T, T> _fn;

        public _TransformFirstClosure(Func<T, T> fn)
        {
            _fn = fn;
        }

        public T[] Call(T x, T[] args)
        {
            if (args != null)
            {
                var list = new List<T>();
                list.Add(_fn(x));
                list.AddRange(args);
                return list.ToArray();
            }

            return new[] {_fn(x)};
        }
    }
}