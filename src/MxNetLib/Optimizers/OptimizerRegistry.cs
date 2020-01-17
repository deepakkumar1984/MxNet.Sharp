using MxNetLib;
using System;
using System.Collections.Generic;
using System.Text;
using MxNetLib.Optimizers;
using MxNetLib.NN;

namespace MxNetLib
{
    public class OptimizerRegistry
    {
        public static Optimizer SGD(float lr = 0.01f, float momentum = 1e-7f, float decay = 0)
        {
            return new SGD(lr, momentum, decay);
        }

        public static Optimizer Signum(float lr = 0.01f, float decay = 0, float momentum = 1e-7f)
        {
            return new Signum(lr, decay, momentum);
        }

        public static Optimizer RMSprop(float lr = 0.01f, float rho = 0.95f, float epsilon = 1e-7f, float decay = 0)
        {
            return new RMSProp(lr, rho, decay, epsilon);
        }

        public static Optimizer Adagrad(float lr = 0.01f, float epsilon = 1e-7f, float decay = 0)
        {
            return new Adagrad(lr, decay, epsilon);
        }

        public static Optimizer Adadelta(float lr = 1.0f, float rho = 0.95f, float epsilon = 1e-7f, float decay = 0)
        {
            return new AdaDelta(lr, rho, decay, epsilon);
        }

        public static Optimizer Adam(float lr = 0.001f, float beta_1 = 0.9f, float beta_2 = 0.999f, float decay = 0,  float epsilon = 1e-7f)
        {
            return new Adam(lr, beta_1, beta_2, decay, epsilon);
        }

        internal static Optimizer Get(OptimizerType optimizerType)
        {
            Optimizer opt = null;
            switch (optimizerType)
            {
                case OptimizerType.SGD:
                    opt = SGD();
                    break;
                case OptimizerType.Signum:
                    opt = Signum();
                    break;
                case OptimizerType.RMSprop:
                    opt = RMSprop();
                    break;
                case OptimizerType.Adagrad:
                    opt = Adagrad();
                    break;
                case OptimizerType.Adadelta:
                    opt = Adadelta();
                    break;
                case OptimizerType.Adam:
                    opt = Adam();
                    break;
                default:
                    break;
            }

            return opt;
        }
    }
}
