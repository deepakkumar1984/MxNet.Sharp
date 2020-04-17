using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MxNet.Keras
{
    public class KerasSymbol
    {
        internal NDArrayDict _bind_values;

        internal string _name;

        internal List<KerasSymbol> _neighbors;

        internal Symbol _pred_sym;

        internal StorageStype _stype;

        internal Symbol _train_sym;

        internal NDArray _tensor;

        internal Shape _keras_shape;

        internal bool _uses_learning_phase;

        internal bool _is_vector;

        internal bool _mxnet_placeholder;

        public Symbol Symbol
        {
            get
            {
                var sym = MxNetBackend.LearningPhase() ? this._train_sym : this._pred_sym;
                Debug.Assert(sym != null, $"[Debug Info] {this._train_sym.Name}, {this._pred_sym.Name}");
                return sym;
            }
        }

        public NDArray Tensor
        {
            get
            {
                return _tensor;
            }
        }

        public string Name
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_name))
                    return _name;
                else
                    return Symbol.Name;
            }
        }

        public DType DType
        {
            get
            {
                return GetDtype();
            }
        }

        public Shape Shape
        {
            get
            {
                return GetShape();
            }
        }

        public KerasSymbol(Symbol mxnet_symbol, StorageStype stype = StorageStype.Default, KerasSymbol[] neighbors = null, bool is_var = false)
        {
            if (is_var)
            {
                this._train_sym = mxnet_symbol;
                this._pred_sym = mxnet_symbol;
            }
            else
            {
                this._train_sym = MxNetBackend.LearningPhase() ? mxnet_symbol : null;
                this._pred_sym = MxNetBackend.LearningPhase() ? null : mxnet_symbol;
            }
            this._name = null;
            this._neighbors = new List<KerasSymbol>();
            if (neighbors != null)
            {
                foreach (var node in neighbors)
                {
                    this.AddNeighbour(node);
                }
            }
            this._bind_values = new NDArrayDict();
            this._tensor = null;
            this._stype = stype;
        }

        public void Bind(NDArray data)
        {
            this._tensor = data;

            if (this._bind_values.Contains(this._name))
            {
                Debug.Assert(this._bind_values[this._name].Shape.ToString() == data.Shape.ToString(), $"Redefinition of variable {_name}");
                Debug.Assert(this._bind_values[this._name].DataType.Name == data.DataType.Name, $"Redefinition of variable {_name}");
                if (MxNetBackend._MODEL != null && MxNetBackend._MODEL._args.Contains(_name))
                {
                    NDArrayDict argparams = new NDArrayDict();
                    argparams[_name] = data;
                    MxNetBackend._MODEL.SetWeights(argparams, new NDArrayDict());
                }

                if (MxNetBackend._MODEL != null && MxNetBackend._MODEL._auxs.Contains(this._name))
                {
                    NDArrayDict auxparams = new NDArrayDict();
                    auxparams[_name] = data;
                    MxNetBackend._MODEL.SetWeights(new NDArrayDict(), auxparams);
                }
                else
                {
                    this._bind_values[this._name] = data;
                }
            }
            else
            {
                this._bind_values[this._name] = data;
            }
        }

        public void AddNeighbour(KerasSymbol x)
        {
            var node = _neighbors.Where(n => (n.Name == x.Name)).FirstOrDefault();
            if (node == null)
                _neighbors.Add(x);
        }

        public KerasSymbol[] GetNeighbour()
        {
            return _neighbors.ToArray();
        }

        public NDArrayDict GetBindValues()
        {
            return _bind_values;
        }

        public StorageStype GetSType()
        {
            return _stype;
        }

        public NDArray Eval()
        {
            return _tensor;
        }

        internal Shape GetShape()
        {
            if (_keras_shape != null)
                return _keras_shape;

            var (out_shape, _, _) = Symbol.InferShapePartial(new Dictionary<string, Shape>());
            return out_shape[0];
        }

        internal DType GetDtype()
        {
            var (out_type, _, _) = Symbol.InferType();
            return out_type[0];
        }

        public KerasSymbol this[params int[] in_slice]
        {
            get
            {
                var begin = new List<int>();
                var end = new List<int>();
               
                var slice_axis = false;
                var sliced_dim = (from d in Enumerable.Range(0, in_slice.Length)
                                  where in_slice[d] == -1
                                  select d).ToList();
                foreach (var i in in_slice)
                {
                    // Want to slice the complete axis
                    if (i < -1)
                    {
                        throw new NotImplementedException("MXNet Backend: Does not support slicing with < -1 indexing. Given - " + i);
                    }
                    else if (i == -1)
                    {
                        begin.Add(-1);
                        end.Add(-1);
                        slice_axis = true;
                    }
                    else
                    {
                        begin.Add(i);
                        end.Add(i + 1);
                    }
                }

                var sliced_res = sym.Slice(this.Symbol, begin: new Shape(begin), end: new Shape(end));
                if (slice_axis)
                {
                    var num_sliced_axis = 0;
                    foreach (var dim in sliced_dim)
                    {
                        sliced_res = sym.Squeeze(sliced_res, axis: new Shape(dim - num_sliced_axis));
                        num_sliced_axis += 1;
                    }
                }
                var sliced_keras_symbol = new KerasSymbol(sliced_res, neighbors: new KerasSymbol[] { this });
                // MXNet does not support Scalars. To overcome that,
                // we have introduced a logic to identify (1, ) shaped tensor as vector or scalar.
                // See eval() function for more details.
                // Output of slicing is always a Vector. Without this flag, eval(a tensor with (1,) shape)
                // will be returned as Scalar.
                sliced_keras_symbol._is_vector = true;
                return sliced_keras_symbol;
            }
        }

        public KerasSymbol this[params Slice[] in_slice]
        {
            get
            {
                var begin = new List<int>();
                var end = new List<int>();

                var slice_axis = false;
                var sliced_dim = (from d in Enumerable.Range(0, in_slice.Length)
                                  where in_slice[d] == null
                                  select d).ToList();
                foreach (var i in in_slice)
                {
                    begin.Add(i.Begin);
                    end.Add(i.End.Value);
                }

                var sliced_res = sym.Slice(this.Symbol, begin: new Shape(begin), end: new Shape(end));
                if (slice_axis)
                {
                    var num_sliced_axis = 0;
                    foreach (var dim in sliced_dim)
                    {
                        sliced_res = sym.Squeeze(sliced_res, axis: new Shape(dim - num_sliced_axis));
                        num_sliced_axis += 1;
                    }
                }

                var sliced_keras_symbol = new KerasSymbol(sliced_res, neighbors: new KerasSymbol[] { this });
                // MXNet does not support Scalars. To overcome that,
                // we have introduced a logic to identify (1, ) shaped tensor as vector or scalar.
                // See eval() function for more details.
                // Output of slicing is always a Vector. Without this flag, eval(a tensor with (1,) shape)
                // will be returned as Scalar.
                sliced_keras_symbol._is_vector = true;
                return sliced_keras_symbol;
            }
        }

        public KerasSymbol Abs()
        {
            return new KerasSymbol(sym.Abs(Symbol), neighbors: new KerasSymbol[] { this });
        }

        public static KerasSymbol operator +(KerasSymbol lhs, KerasSymbol rhs)
        {
            return sym.BroadcastAdd(lhs.Symbol, rhs.Symbol);
        }

        public static KerasSymbol operator +(KerasSymbol lhs, float scalar)
        {
            return sym.PlusScalar(lhs.Symbol, scalar);
        }

        public static KerasSymbol operator +(float scalar, KerasSymbol rhs)
        {
            return sym.PlusScalar(rhs.Symbol, scalar);
        }

        public static KerasSymbol operator -(KerasSymbol lhs, KerasSymbol rhs)
        {
            return sym.BroadcastSub(lhs.Symbol, rhs.Symbol);
        }

        public static KerasSymbol operator -(KerasSymbol lhs, float scalar)
        {
            return sym.MinusScalar(lhs.Symbol, scalar);
        }

        public static KerasSymbol operator -(float scalar, KerasSymbol rhs)
        {
            return sym.RminusScalar(rhs.Symbol, scalar);
        }

        public static KerasSymbol operator *(KerasSymbol lhs, KerasSymbol rhs)
        {
            return sym.BroadcastMul(lhs.Symbol, rhs.Symbol);
        }

        public static KerasSymbol operator *(KerasSymbol lhs, float scalar)
        {
            return sym.MulScalar(lhs.Symbol, scalar);
        }

        public static KerasSymbol operator *(float scalar, KerasSymbol rhs)
        {
            return sym.MulScalar(rhs.Symbol, scalar);
        }

        public static KerasSymbol operator /(KerasSymbol lhs, KerasSymbol rhs)
        {
            return sym.BroadcastDiv(lhs.Symbol, rhs.Symbol);
        }

        public static KerasSymbol operator /(KerasSymbol lhs, float scalar)
        {
            return sym.DivScalar(lhs.Symbol, scalar);
        }

        public static KerasSymbol operator /(float scalar, KerasSymbol rhs)
        {
            return sym.RdivScalar(rhs.Symbol, scalar);
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
            return sym.BroadcastGreater(lhs.Symbol, rhs.Symbol);
        }

        public static KerasSymbol operator >=(KerasSymbol lhs, KerasSymbol rhs)
        {
            return sym.BroadcastGreaterEqual(lhs.Symbol, rhs.Symbol);
        }

        public static KerasSymbol operator >(KerasSymbol lhs, float rhs)
        {
            return sym.GreaterScalar(lhs.Symbol, rhs);
        }

        public static KerasSymbol operator >=(KerasSymbol lhs, float rhs)
        {
            return sym.GreaterEqualScalar(lhs.Symbol, rhs);
        }

        public static KerasSymbol operator >(float lhs, KerasSymbol rhs)
        {
            return sym.GreaterScalar(rhs.Symbol, lhs);
        }

        public static KerasSymbol operator >=(float lhs, KerasSymbol rhs)
        {
            return sym.GreaterEqualScalar(rhs.Symbol, lhs);
        }

        public static KerasSymbol operator <(KerasSymbol lhs, KerasSymbol rhs)
        {
            return sym.BroadcastLesser(lhs.Symbol, rhs.Symbol);
        }

        public static KerasSymbol operator <=(KerasSymbol lhs, KerasSymbol rhs)
        {
            return sym.BroadcastLesserEqual(lhs.Symbol, rhs.Symbol);
        }

        public static KerasSymbol operator <(KerasSymbol lhs, float rhs)
        {
            return sym.LesserScalar(lhs.Symbol, rhs);
        }

        public static KerasSymbol operator <=(KerasSymbol lhs, float rhs)
        {
            return sym.LesserEqualScalar(lhs.Symbol, rhs);
        }

        public static KerasSymbol operator <(float lhs, KerasSymbol rhs)
        {
            return sym.LesserScalar(rhs.Symbol, lhs);
        }

        public static KerasSymbol operator <=(float lhs, KerasSymbol rhs)
        {
            return sym.LesserEqualScalar(rhs.Symbol, lhs);
        }

        public KerasSymbol Pow(float power)
        {
            return sym.PowerScalar(this.Symbol, power);
        }

        public static implicit operator KerasSymbol(Symbol s) => new KerasSymbol(s);
    }
}
