using System;
using System.Collections.Generic;
using System.Text;


namespace MxNet.Keras.Regularizers
{
    public class Regularizer
    {
        public virtual KerasSymbol Call(KerasSymbol x)
        {
            return x;
        }

        public static Regularizer FromConfig(ConfigDict config)
        {
            return Deserialize(config);
        }

        public static Regularizer L1(float l = 0.01f)
        {
            return new L1L2(l1: l);
        }

        public static Regularizer L2(float l = 0.01f)
        {
            return new L1L2(l2: l);
        }

        public static Regularizer L1_L2(float l1 = 0.01f, float l2 = 0.01f)
        {
            return new L1L2(l1: l1, l2: l2);
        }

        public static ConfigDict Serialize(Regularizer regularizer)
        {
            return Utils.GenericUtils.SerializeKerasObject(regularizer);
        }

        public static Regularizer Deserialize(ConfigDict config, CustomObjects custom_objects = null)
        {
            return (Regularizer)Utils.GenericUtils.DeserializeKerasObject(config, custom_objects: custom_objects, printable_module_name: "regularizer");
        }

        public static Regularizer Get(object identifier)
        {
            if (identifier == null)
            {
                return null;
            }

            if (identifier is ConfigDict)
            {
                return Deserialize((ConfigDict)identifier);
            }

            else if (identifier is string)
            {
                ConfigDict config = new ConfigDict {
                    {
                        "class_name",
                        identifier.ToString()},
                    {
                        "config",
                        new Dictionary<object, object>()
                    }
                };
                return Deserialize(config);
            }
            else
            {
                throw new Exception("Could not interpret regularizer identifier: " + identifier.ToString());
            }
        }
    }
}
