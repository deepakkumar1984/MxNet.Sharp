using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Utils
{
    public class H5Dict : IEnumerable<object>
    {
        public H5Dict(string path, string mode ="a")
        {
            throw new NotImplementedException();
        }

        public object this[string attr]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Length => throw new NotImplementedException();

        public IEnumerator<object> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public bool Contains(string key)
        {
            throw new NotImplementedException();
        }

        public void Update(Dictionary<string, object> args)
        {
            throw new NotImplementedException();
        }

        public object Get(string key, object defaultvalue = null)
        {
            throw new NotImplementedException();
        }
    }
}
