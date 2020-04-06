using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras
{
    public class KerasSymbol
    {
        public Symbol Symbol
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public NDArray Tensor
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DType DType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Shape Shape
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public KerasSymbol(Symbol mxnet_symbol, StorageStype stype = StorageStype.Default, KerasSymbol[] neighbors = null, bool is_var = false)
        {
            throw new NotImplementedException();
        }

        public void Bind(NDArray data)
        {
            throw new NotImplementedException();
        }

        public void AddNeighbour(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public KerasSymbol[] GetNeighbour()
        {
            throw new NotImplementedException();
        }

        public NDArrayList GetBindValues()
        {
            throw new NotImplementedException();
        }

        public StorageStype GetSType()
        {
            throw new NotImplementedException();
        }

        public NDArray Eval()
        {
            throw new NotImplementedException();
        }

        internal Shape _get_shape()
        {
            throw new NotImplementedException();
        }

        internal DType _get_type()
        {
            throw new NotImplementedException();
        }

        public KerasSymbol this[params int[] in_slice]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public KerasSymbol Abs()
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol operator +(KerasSymbol lhs, KerasSymbol rhs)
        {
            return sym.BroadcastAdd(lhs, rhs);
        }

        public static KerasSymbol operator +(KerasSymbol lhs, float scalar)
        {
            return sym.PlusScalar(lhs, scalar);
        }

        public static KerasSymbol operator +(float scalar, KerasSymbol rhs)
        {
            return sym.PlusScalar(rhs, scalar);
        }

        public static KerasSymbol operator -(KerasSymbol lhs, KerasSymbol rhs)
        {
            return sym.BroadcastSub(lhs, rhs);
        }

        public static KerasSymbol operator -(KerasSymbol lhs, float scalar)
        {
            return sym.MinusScalar(lhs, scalar);
        }

        public static KerasSymbol operator -(float scalar, KerasSymbol rhs)
        {
            return sym.RminusScalar(rhs, scalar);
        }

        public static KerasSymbol operator *(KerasSymbol lhs, KerasSymbol rhs)
        {
            return sym.BroadcastMul(lhs, rhs);
        }

        public static KerasSymbol operator *(KerasSymbol lhs, float scalar)
        {
            return sym.MulScalar(lhs, scalar);
        }

        public static KerasSymbol operator *(float scalar, KerasSymbol rhs)
        {
            return sym.MulScalar(rhs, scalar);
        }

        public static KerasSymbol operator /(KerasSymbol lhs, KerasSymbol rhs)
        {
            return sym.BroadcastDiv(lhs, rhs);
        }

        public static KerasSymbol operator /(KerasSymbol lhs, float scalar)
        {
            return sym.DivScalar(lhs, scalar);
        }

        public static KerasSymbol operator /(float scalar, KerasSymbol rhs)
        {
            return sym.RdivScalar(rhs, scalar);
        }

        public static KerasSymbol operator %(KerasSymbol lhs, float scalar)
        {
            KerasSymbol ret = null;
            using (var op = new Operator("_mod_scalar"))
            {
                ret = op.Set(lhs, scalar).CreateSymbol("mod");
            }

            return ret;
        }

        public static KerasSymbol operator %(KerasSymbol lhs, KerasSymbol rhs)
        {
            KerasSymbol ret = null;
            using (var op = new Operator("_mod"))
            {
                ret = op.Set(lhs, rhs).CreateSymbol("mod");
            }

            return ret;
        }

        public static KerasSymbol operator >(KerasSymbol lhs, KerasSymbol rhs)
        {
            return sym.BroadcastGreater(lhs, rhs);
        }

        public static KerasSymbol operator >=(KerasSymbol lhs, KerasSymbol rhs)
        {
            return sym.BroadcastGreaterEqual(lhs, rhs);
        }

        public static KerasSymbol operator >(KerasSymbol lhs, float rhs)
        {
            return sym.GreaterScalar(lhs, rhs);
        }

        public static KerasSymbol operator >=(KerasSymbol lhs, float rhs)
        {
            return sym.GreaterEqualScalar(lhs, rhs);
        }

        public static KerasSymbol operator >(float lhs, KerasSymbol rhs)
        {
            return sym.GreaterScalar(rhs, lhs);
        }

        public static KerasSymbol operator >=(float lhs, KerasSymbol rhs)
        {
            return sym.GreaterEqualScalar(rhs, lhs);
        }

        public static KerasSymbol operator <(KerasSymbol lhs, KerasSymbol rhs)
        {
            return sym.BroadcastLesser(lhs, rhs);
        }

        public static KerasSymbol operator <=(KerasSymbol lhs, KerasSymbol rhs)
        {
            return sym.BroadcastLesserEqual(lhs, rhs);
        }

        public static KerasSymbol operator <(KerasSymbol lhs, float rhs)
        {
            return sym.LesserScalar(lhs, rhs);
        }

        public static KerasSymbol operator <=(KerasSymbol lhs, float rhs)
        {
            return sym.LesserEqualScalar(lhs, rhs);
        }

        public static KerasSymbol operator <(float lhs, KerasSymbol rhs)
        {
            return sym.LesserScalar(rhs, lhs);
        }

        public static KerasSymbol operator <=(float lhs, KerasSymbol rhs)
        {
            return sym.LesserEqualScalar(rhs, lhs);
        }

        public KerasSymbol Pow(float power)
        {
            return sym.PowerScalar(this, power);
        }

        public static implicit operator KerasSymbol(Symbol s) => new KerasSymbol(s);

        public static implicit operator Symbol(KerasSymbol s) => s.Symbol;
    }
}
