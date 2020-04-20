using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Initializers
{
    public class Identity : Initializer
    {
        private readonly float gain;

        public Identity(float gain = 1)
        {
            this.gain = gain;
        }

        public override KerasSymbol Call(Shape shape, DType dtype = null)
        {
            if (shape.Dimension != 2)
            {
                throw new Exception("Identity matrix initializer can only be used for 2D matrices.");
            }

            if (shape.Data.Max() % shape.Data.Min() != 0)
            {
                throw new Exception("Long side should be multiple of short side.");
            }

            if (shape[0] == shape[1])
            {
                return this.gain * sym.Eye(shape[0]);
            }
            else if (shape[0] > shape[1])
            {
                List<Symbol> list = new List<Symbol>();
                for(int i = 0; i< shape[0] / shape[1]; i++)
                {
                    list.Add(sym.Eye(shape[1]));
                }
                
                return this.gain * sym.Concat(list, dim: 0);
            }
            else
            {
                List<Symbol> list = new List<Symbol>();
                for (int i = 0; i < shape[1] / shape[0]; i++)
                {
                    list.Add(sym.Eye(shape[1]));
                }

                return this.gain * sym.Concat(list, dim: 0);
            }
        }

        public override ConfigDict GetConfig()
        {
            return new ConfigDict {
                {
                    "gain",
                    this.gain
                }
            };
        }
    }
}
