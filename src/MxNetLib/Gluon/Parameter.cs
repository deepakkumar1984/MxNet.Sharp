using MxNetLib.NN.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNetLib.Gluon
{
    public class Parameter
    {
        public Parameter(string name, string grad_req= "write", Shape shape= null, string dtype= "float32",
                 float lr_mult= 1.0f, float wd_mult= 1.0f, BaseInitializer init= null, bool allow_deferred_init= false,
                 bool differentiable= true, string stype= "default", string grad_stype= "default")
        {
            throw new NotImplementedException();
        }
    }
}
