using System;
using MxNet.Initializers;

namespace MxNet.Gluon
{
    public class Constant : Parameter
    {
        public Constant(string name, NDArray value) : base(name, OpGradReq.Null, value.Shape, value.DataType,
            init: new CInit(value))
        {
            Value = value;
            InitName = $"Constant_{Name}_{GetHashCode()}";
        }

        public override OpGradReq GradReg
        {
            get => OpGradReq.Null;
            set
            {
                if (value != OpGradReq.Null)
                    throw new Exception("Constant parameter only support grad_req->null");
            }
        }

        public NDArray Value { get; set; }

        public string InitName { get; set; }

        public class CInit : Initializer
        {
            private readonly NDArray _value;

            public CInit(NDArray value)
            {
                _value = value;
            }

            public override void InitWeight(string name, ref NDArray arr)
            {
                _value.CopyTo(arr);
            }
        }
    }
}