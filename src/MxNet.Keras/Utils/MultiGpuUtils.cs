using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Utils
{
    public class MultiGpuUtils
    {
        public static string NormalizeDeviceName(string name)
        {
            var list = name.ToLower().Replace("/", "").Split(':');
            name = "/" + string.Join(":", list.Take(list.Length - 2));
            return name;
        }

        public static Model MultiGpuModel(Model model, int gpus, bool cpu_merge = true, bool cpu_relocation = false)
        {
            model.SetMxNetContext(gpus);
            return model;
        }
    }
}
