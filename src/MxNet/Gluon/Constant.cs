using MxNet.NN.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon
{
    public class Constant : Parameter
    {
        public override string GradReg
        {
            get
            {
                return "null";
            }
            set
            {
                if (value != "null")
                    throw new Exception("Constant parameter only support grad_req->null");
            }
        }

        public Constant(string name, NDArray value) : base(name: name, grad_req: "null", shape: value.Shape, dtype: value.DataType, init: null)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
