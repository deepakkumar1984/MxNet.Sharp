using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Initializers
{
    public class Load
    {
        public NDArrayDict Param { get; set; }

        public Initializer DefaultInit { get; set; }

        public bool Verbose { get; set; }

        public Load(NDArrayDict param, Initializer default_init= null, bool verbose= false)
        {
            Param = new NDArrayDict();
            foreach (var p in param)
            {
                if (p.Key.StartsWith("arg:") || p.Key.StartsWith("aux:"))
                    Param[p.Key.Substring(4)] = p.Value;
                else
                    Param[p.Key] = p.Value;
            }

            DefaultInit = default_init;
            Verbose = verbose;
        }

        public void Call(string name, NDArray arr)
        {
            if(Param.Contains(name))
            {
                if (arr.Shape != Param[name].Shape)
                    throw new MXNetException(string.Format("Shape mismatch, target {0} vs loaded {1}", arr.Shape, Param[name].Shape));

                arr = Param[name];
                if (Verbose)
                    Logger.Log(string.Format("Initialized {0} by loading", name));
            }
            else
            {
                if (DefaultInit == null)
                    throw new MXNetException(string.Format("Cannot Initialize {0}. Not found in loaded param and no default Initializer is provided", name));

                DefaultInit.InitWeight(name, ref arr);
                if (Verbose)
                    Logger.Log(string.Format("Initialized {0} by default", name));
            }
        }
    }
}
