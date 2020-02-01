using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Initializers
{
    public abstract class Initializer
    {
        private bool verbose;
        private Func<NDArray, string> print_func;

        public Initializer()
        {
            verbose = false;
            print_func = null;
        }

        public void SetVerbosity(bool verbose = false, Func<NDArray, string> print_func = null)
        {
            this.verbose = verbose;
            if(print_func == null)
            {
                print_func = (x) => 
                {
                    return (nd.Norm(x) / (float)Math.Sqrt(x.Size)).AsScalar<float>().ToString();
                };
            }

            this.print_func = print_func;
        }

        public abstract void InitWeight(string name, NDArray arr);

        private void VerbosePrint(InitDesc desc, string @init, NDArray arr)
        {
            if(verbose && print_func != null)
            {
                Logger.Info(string.Format("Initialized {0} as {1}: {2}", desc, @init, print_func(arr)));
            }
        }

        public string Dumps()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Initializer Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}
