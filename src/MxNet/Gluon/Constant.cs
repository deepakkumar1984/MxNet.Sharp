using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon
{
    public class Constant : Parameter
    {
        public class CInit : Initializers.Initializer
        {
            private NDArray _value;
            
            public CInit(NDArray value)
            {
                _value = value;
            }

            public override void InitWeight(string name, NDArray arr)
            {
                _value.CopyTo(arr);
            }
        }

        public override OpGradReq GradReg
        {
            get
            {
                return OpGradReq.Null;
            }
            set
            {
                if (value != OpGradReq.Null)
                    throw new Exception("Constant parameter only support grad_req->null");
            }
        }

        public NDArray Value { get; set; }

        public string InitName { get; set; }

        public Constant(string name, NDArray value) : base(name: name, grad_req: OpGradReq.Null, shape: value.Shape, dtype: value.DataType, init: new CInit(value))
        {
            Value = value;
            InitName = $"Constant_{Name}_{this.GetHashCode()}";
            
        }
    }
}
