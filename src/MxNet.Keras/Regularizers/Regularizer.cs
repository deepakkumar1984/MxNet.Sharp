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

        public static Regularizer FromConfig(Type cls, ConfigDict config)
        {
            throw new NotImplementedException();
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

        public static string Serialize(Regularizer regularizer)
        {
            throw new NotImplementedException();
        }

        public static Regularizer Deserialize(ConfigDict config, object[] custom_objects = null)
        {
            throw new NotImplementedException();
        }

        public static Regularizer Get(object identifier)
        {
            throw new NotImplementedException();
        }
    }
}
