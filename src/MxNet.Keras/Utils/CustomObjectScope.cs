using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Utils
{
    public class CustomObjectScope : IDisposable
    {
        public CustomObjects backup;

        public CustomObjects custom_objects;

        public CustomObjectScope(CustomObjects args)
        {
            this.custom_objects = args;
            this.backup = null;

            this.backup = GenericUtils._GLOBAL_CUSTOM_OBJECTS.Copy();
            foreach (var objects in this.custom_objects)
            {
                GenericUtils._GLOBAL_CUSTOM_OBJECTS[objects.Key] = objects.Value;
            }
        }

        public void Dispose()
        {
            GenericUtils._GLOBAL_CUSTOM_OBJECTS.Clear();
            GenericUtils._GLOBAL_CUSTOM_OBJECTS = backup;
        }
    }
}
