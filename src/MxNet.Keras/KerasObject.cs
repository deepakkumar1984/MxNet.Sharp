using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras
{
    public class KerasObject
    {
        public string class_name { get; set;  }

        public ConfigDict config { get; set; }

        public KerasObject()
        {

        }

        public KerasObject(string class_name, ConfigDict config)
        {
            this.class_name = class_name;
            this.config = config;
        }
    }
}
