using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet._ffi
{
    public class MxObject
    {
        public static Dictionary<string, Type> OBJECT_TYPE = new Dictionary<string, Type>();

        public object _CLASS_OBJECT;

        public void SetClassObject(object object_class)
        {
            _CLASS_OBJECT = object_class;
        }

        public void RegisterObject(int index, string cls)
        {
            throw new NotImplementedException();
        }
    }

    public class ObjectBase : MxObject, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IntPtr InitHandleByConstructor(Function fconstructor, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
