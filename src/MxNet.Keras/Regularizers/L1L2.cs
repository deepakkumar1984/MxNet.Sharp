using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;
namespace MxNet.Keras.Regularizers
{
    public class L1L2 : Regularizer
    {
        public float l1;

        public float l2;

        public L1L2(float l1 = 0, float l2 = 0)
        {
            this.l1 = l1;
            this.l2 = l2;
        }

        public override KerasSymbol Call(KerasSymbol x)
        {
            KerasSymbol regularization = null;
            if (this.l1 > 0)
            {
                regularization += K.Sum(this.l1 * K.Abs(x), null);
            }
            if (this.l2 > 0)
            {
                regularization += K.Sum(this.l2 * K.Square(x), null);
            }

            return regularization;
        }

        public ConfigDict GetConfig()
        {
            return new ConfigDict {
                {
                    "l1",
                    this.l1
                },
                {
                    "l2",
                    this.l2
                }
              };
        }
    }
}
