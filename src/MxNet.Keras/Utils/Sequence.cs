using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Utils
{
    public abstract class Sequence<T> : IEnumerable<T>
    {
        public abstract T this[int index] { get; }

        public abstract int Length { get; }

        public virtual IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public virtual void OnEpochEnd()
        {
            return;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
