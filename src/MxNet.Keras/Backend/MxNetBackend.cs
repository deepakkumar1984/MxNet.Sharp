using MxNet.Keras.Backend;
using MxNet.Keras.Engine;
using MxNet.Keras.Layers;
using MxNet.Sparse;
using NumpyDotNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MxNet.Keras
{
    public class NameScope : IDisposable
    {
        private string Name { get; }

        public NameScope(string name)
        {
            Name = name;
            MxNetBackend.NAME_SCOPE_STACK.Push(name);
        }

        public void Dispose()
        {
            MxNetBackend.NAME_SCOPE_STACK.Pop();
        }
    }

    public class MxNetBackend : Common
    {
        public static Stack<string> NAME_SCOPE_STACK = new Stack<string>();

        public static bool _REENTRY = false;

        public static Model _MODEL = null;

        public static Context[] _CURRENT_SCOPE_CTX;

        public static bool _LEARNING_PHASE;

        public static bool IsReEntry()
        {
            return _REENTRY;
        }

        public static void SetReEntry(bool value)
        {
            _REENTRY = value;
        }

        public static void SetModel(Model model)
        {
            _MODEL = model;
        }

        public static void ClearSession()
        {
            ResetUids();
            _MODEL = null;
        }

        public static bool LearningPhase()
        {
            return _LEARNING_PHASE;
        }

        public static void SetLearningPhase(bool value)
        {
            _LEARNING_PHASE = value;
        }

        public static ndarray CastToFloatX(ndarray x)
        {
            if (FloatX() == "float32")
                return x.astype(np.Float32);
            else if (FloatX() == "float64")
                return x.astype(np.Float64);

            return x;
        }

        public static NDArray CastToFloatX(NDArray x)
        {
            return x.AsType(FloatX());
        }

        public static bool IsSparse(KerasSymbol tensor)
        {
            return tensor._stype == StorageStype.Csr;
        }

        public static NDArray ToDense(KerasSymbol tensor)
        {
            return Eval(tensor.Symbol);
        }

        public static KerasSymbol Variable(NDArray value, DType dtype = null, string name = "", Constraint constraint = null, bool sparse_weight = false)
        {
            KerasSymbol ret = null;
            RowSparseNDArray v = null;
            if (constraint != null)
            {
                Logger.Warning("MXNet backend does not support constraints. Keyword arguments such as `kernel_constraint` and `bias_constraint`");
            }

            if (dtype == null)
            {
                dtype = FloatX();
            }

            var is_vector = false;
            if (value.Shape.Dimension == 1)
            {
                is_vector = true;
            }

            if (sparse_weight)
            {
                v = (RowSparseNDArray)value.ToSType(StorageStype.RowSparse);
                name = PrepareName(name, "variable");
                ret = KerasVariable(name, v.Shape, v.DataType, StorageStype.RowSparse, is_vector);
                ret._keras_shape = value.Shape;
                ret._uses_learning_phase = false;
                ret.Bind(v);
                return ret;
            }

            // MXNet backend do not support scalars
            if (value.Shape.Dimension == 0)
            {
                throw new Exception("MXNet Backend: Scalars are not supported. Provided value for variable");
            }

            name = PrepareName(name, "variable");
            ret = KerasVariable(name, value.Shape, value.DataType, StorageStype.Default, is_vector);
            ret.Bind(value);
            ret._keras_shape = value.Shape;
            ret._uses_learning_phase = false;
            return ret;
        }

        public static KerasSymbol Variable(float value, DType dtype = null, string name = "", Constraint constraint = null, bool sparse_weight = false)
        {
            return Variable(new NDArray(new float[] { value }), dtype, name, constraint, sparse_weight);
        }

        public static KerasSymbol Variable(KerasSymbol value, DType dtype = null, string name = "", Constraint constraint = null, bool sparse_weight = false)
        {
            return Variable(Eval(value), dtype, name, constraint, sparse_weight);
        }

        public static KerasSymbol Constant(NDArray value, DType dtype= null, Shape shape= null, string name= "")
        {
            if (dtype == null)
            {
                dtype = FloatX();
            }

            // MXNet does not support Scalars. Shape of a Scalar Tensor with MXNet is
            // (1, ) instead of (). Return is as MXNet NDArray instance as this is
            // useful in K.eval() function to return as is (1, )
            name = PrepareName(name, "constant");
            var const_var = KerasVariable(name: name, dtype: dtype, shape: value.Shape);
            const_var.Bind(value);
            return const_var;
        }

        public static KerasSymbol Constant(float value, DType dtype = null, Shape shape = null, string name = "")
        {
            if (dtype == null)
            {
                dtype = FloatX();
            }

            var x = nd.Full(value, shape, dtype: dtype);
            return Constant(x, dtype, shape, name);
        }

        public static bool IsKerasTensor(object x)
        {
            return x is KerasSymbol;
        }

        public static bool IsTensor(object x)
        {
            return x is KerasSymbol || x is Symbol || x is NDArray;
        }

        public static KerasSymbol Placeholder(Shape shape= null, int? ndim= null, DType dtype= null, bool sparse= false, string name= "")
        {
            KerasSymbol sym;
            if (dtype == null)
            {
                dtype = FloatX();
            }

            if (shape == null && ndim == null)
            {
                throw new ValueError("MXNet Backend: Specify either a shape or ndim value.");
            }

            name = PrepareName(name, "placeholder");
            if (shape == null)
            {
                shape = new Shape((from _ in Enumerable.Range(0, ndim.Value)
                               select 0).ToList());
            }
           
            if (sparse)
            {
                sym = KerasVariable(name, shape: shape, dtype: dtype, stype: StorageStype.Csr);
                sym._keras_shape = new Shape(shape.Data.Where(x => x != 0).ToList());
                sym._mxnet_placeholder = true;
                sym._uses_learning_phase = false;
                return sym;
            }

            sym = KerasVariable(name, shape: shape, dtype: dtype, stype: StorageStype.Default);
            sym._keras_shape = new Shape(shape.Data.Where(x => x != 0).ToList());
            sym._mxnet_placeholder = true;
            sym._uses_learning_phase = false;
            return sym;
        }

        public static bool IsPlaceholder(KerasSymbol x)
        {
            return x._mxnet_placeholder;
        }

        public static Shape Shape(KerasSymbol x)
        {
            return x.Shape;
        }

        public static int[] IntShape(KerasSymbol x)
        {
            return x.Shape.Data;
        }

        public static int NDim(KerasSymbol x)
        {
            return x.Shape.Dimension;
        }

        public static DType DataType(KerasSymbol x)
        {
            return x.DType;
        }

        public static NDArray Eval(KerasSymbol x)
        {
            NDArray ret;
            if (x.Tensor != null)
            {
                if (x.GetBindValues().Contains(x.Name) && _MODEL != null)
                {
                    _MODEL.SyncWeights();
                }

                ret = x.Eval();
            }
            else
            {
                ret = ForwardPass(x)[0];
            }

            return ret;
        }

        public static KerasSymbol Zeros(Shape shape, DType dtype = null, string name = "")
        {
            var value = nd.Zeros(shape, dtype: dtype);
            name = PrepareName(name, "zeroinit");
            var kvar = KerasVariable(name, value.Shape, value.DataType);
            kvar.Bind(value);
            return kvar;
        }

        public static KerasSymbol Ones(Shape shape, DType dtype = null, string name = "")
        {
            var value = nd.Ones(shape, dtype: dtype);
            name = PrepareName(name, "oneinit");
            var kvar = KerasVariable(name, value.Shape, value.DataType);
            kvar.Bind(value);
            return kvar;
        }

        public static KerasSymbol Eye(int size, DType dtype = null, string name = "")
        {
            var value = nd.Eye(new Tuple<double>(size), dtype: dtype);
            name = PrepareName(name, "eyeinit");
            var kvar = KerasVariable(name, value.Shape, value.DataType);
            kvar.Bind(value);
            return kvar;
        }

        public static KerasSymbol ZerosLike(KerasSymbol x, DType dtype = null, string name = "")
        {
            return new KerasSymbol(sym.ZerosLike(data: x.Symbol, symbol_name: PrepareName(name, "zeroslikeinit")));
        }

        public static KerasSymbol OnesLike(KerasSymbol x, DType dtype = null, string name = "")
        {
            return new KerasSymbol(sym.OnesLike(data: x.Symbol, symbol_name: PrepareName(name, "oneslikeinit")));
        }

        public static KerasSymbol Identity(KerasSymbol x)
        {
            var name = PrepareName(null, "identityinit");
            var dtype = x.DType;
            var mx_value = Eval(x);
            var mx_shape = x.Shape;
            var k_var = KerasVariable(name: name, dtype: dtype, shape: mx_shape);
            k_var.Bind(mx_value);
            return k_var;
        }

        public static KerasSymbol RandomUniformVariable(Shape shape, float low, float high, DType dtype= null, string name= "", int? seed= null)
        {
            if (dtype == null)
            {
                dtype = FloatX();
            }

            name = PrepareName(name, "randomuniform");
            if (seed.HasValue)
            {
                nd.Random.Seed(seed.Value);
            }

            var value = nd.Random.Uniform(low: low, high: high, dtype: "float32", shape: shape);
            if (dtype != "float32")
            {
                value = nd.Cast(value, dtype: dtype);
            }

            var k_var = KerasVariable(name: name, shape: shape, dtype: dtype);
            k_var.Bind(value);
            return k_var;
        }

        public static KerasSymbol RandomNormalVariable(Shape shape, float mean, float scale, DType dtype = null, string name = "", int? seed = null)
        {
            if (dtype == null)
            {
                dtype = FloatX();
            }

            name = PrepareName(name, "randomnormal");
            if (seed.HasValue)
            {
                nd.Random.Seed(seed.Value);
            }

            var value = nd.Random.Normal(mean, scale, dtype: "float32", shape: shape);
            if (dtype != "float32")
            {
                value = nd.Cast(value, dtype: dtype);
            }

            var k_var = KerasVariable(name: name, shape: shape, dtype: dtype);
            k_var.Bind(value);
            return k_var;
        }

        public static int CountParams(KerasSymbol x)
        {
            return x.Shape.Size;
        }

        public static KerasSymbol Cast(KerasSymbol x, DType dtype)
        {
            return new KerasSymbol(sym.Cast(x.Symbol, dtype));
        }

        public static KerasSymbol Update(KerasSymbol x, NDArray new_x)
        {
            throw new NotSupportedException("MXNet Backend: Update operations are not supported yet.");
        }

        public static KerasSymbol UpdateAdd(KerasSymbol x, NDArray new_x)
        {
            throw new NotSupportedException("MXNet Backend: Update operations are not supported yet.");
        }

        public static KerasSymbol UpdateSub(KerasSymbol x, NDArray new_x)
        {
            throw new NotSupportedException("MXNet Backend: Update operations are not supported yet.");
        }

        public static KerasSymbol MovingAverageUpdate(KerasSymbol x, Symbol value, float momentum)
        {
            return new KerasSymbol(x.Symbol * momentum + value * (1 - momentum));
        }

        public static KerasSymbol Dot(KerasSymbol x, KerasSymbol y)
        {
            if (IsSparse(x))
            {
                if (NDim(y) > 2)
                {
                    // Output of this is sparse
                    return new KerasSymbol(sym.Dot(x.Symbol, y.Symbol, transpose_b: true, forward_stype: DotForwardStype.RowSparse));
                }
                else
                {
                    // Output of this is dense
                    return new KerasSymbol(sym.Dot(x.Symbol, y.Symbol, transpose_b: true, forward_stype: DotForwardStype.Default));
                }
            }

            if (NDim(y) > 2)
            {
                var axis = Enumerable.Range(0, NDim(y)).ToList();
                axis.Insert(0, axis.Last());
                axis.RemoveAt(axis.Count - 1);
                y = sym.Transpose(y.Symbol, axes: new Shape(axis));
            }

            return new KerasSymbol(sym.Dot(lhs: x.Symbol, rhs: y.Symbol));
        }

        public static KerasSymbol BatchDot(KerasSymbol x, KerasSymbol y, Shape axes = null)
        {
            int idx;
            bool trans_y;
            bool trans_x;
            KerasSymbol @out;
            int diff;

            var x_ndim = NDim(x);
            var y_ndim = NDim(y);
            if (x_ndim > y_ndim)
            {
                diff = x_ndim - y_ndim;
                var yShape = Shape(y).Data.ToList();
                for (int i = 0; i < diff; i++)
                    yShape.Add(1);

                y = new KerasSymbol(sym.Reshape(y.Symbol, shape: new Shape(yShape)));
            }
            else if (y_ndim > x_ndim)
            {
                diff = y_ndim - x_ndim;
                var xShape = Shape(y).Data.ToList();
                for (int i = 0; i < diff; i++)
                    xShape.Add(1);
                x = new KerasSymbol(sym.Reshape(x.Symbol, shape: new Shape(xShape)));
            }
            else
            {
                diff = 0;
            }

            if (NDim(x) == 2 && NDim(y) == 2)
            {
                // MXNet supports only 3D. Expand_dims to make it 3D. At the end squeeze it back.
                x = ExpandDims(x, axis: 1);
                y = ExpandDims(y, axis: 2);
                diff = 1;
                if (axes[0] == axes[1])
                {
                    @out = new KerasSymbol(sym.BatchDot(lhs: x.Symbol, rhs: y.Symbol));
                }
                else
                {
                    @out = new KerasSymbol(sym.BatchDot(lhs: x.Symbol, rhs: y.Symbol, transpose_a: true));
                }
            }
            else
            {
                if (axes != null)
                {
                    trans_x = axes[0] == NDim(x) - 1 ? false : true;
                    trans_y = axes[1] == NDim(y) - 1 ? true : false;
                }
                else
                {
                    trans_x = false;
                    trans_y = false;
                }
                @out = new KerasSymbol(sym.LinalgGemm2(x.Symbol, y.Symbol, transpose_a: trans_x, transpose_b: trans_y));
            }

            if (diff > 0)
            {
                if (x_ndim > y_ndim)
                {
                    idx = x_ndim + y_ndim - 3;
                }
                else
                {
                    idx = x_ndim - 1;
                }
                @out = Squeeze(@out, idx);
            }
            if (NDim(@out) == 1)
            {
                @out = ExpandDims(@out, 1);
            }
            return @out;
        }

        public static KerasSymbol Transpose(KerasSymbol x)
        {
            return new KerasSymbol(sym.Transpose(x.Symbol));
        }

        public static KerasSymbol Gather(KerasSymbol reference, KerasSymbol indices)
        {
            var idx = sym.Cast(indices.Symbol, dtype: reference.DType);
            return new KerasSymbol(sym.Take(reference.Symbol, idx));
        }

        public static KerasSymbol Embedding(KerasSymbol data, KerasSymbol weight, int input_dim, int output_dim, bool sparse_grad= false)
        {
            if (sparse_grad)
            {
                // Refer https://mxnet.incubator.apache.org/api/python/symbol/sparse.html#mxnet.symbol.sparse.Embedding
                return new KerasSymbol(sym.Embedding(data.Symbol, weight: weight.Symbol, input_dim: input_dim, output_dim: output_dim, sparse_grad: true));
            }
            return new KerasSymbol(sym.Embedding(data.Symbol, weight: weight.Symbol, input_dim: input_dim, output_dim: output_dim));
        }

        public static KerasSymbol Max(KerasSymbol x, Shape axis, bool keepdims = false)
        {
            axis = NormalizeAxis(axis, NDim(x));
            return new KerasSymbol(sym.Max(data: x.Symbol, axis: axis, keepdims: keepdims));
        }

        public static KerasSymbol Min(KerasSymbol x, Shape axis, bool keepdims = false)
        {
            axis = NormalizeAxis(axis, NDim(x));
            return new KerasSymbol(sym.Min(data: x.Symbol, axis: axis, keepdims: keepdims));
        }

        public static KerasSymbol Sum(KerasSymbol x, Shape axis, bool keepdims = false)
        {
            axis = NormalizeAxis(axis, NDim(x));
            return new KerasSymbol(sym.Sum(data: x.Symbol, axis: axis, keepdims: keepdims));
        }

        public static KerasSymbol Prod(KerasSymbol x, Shape axis, bool keepdims = false)
        {
            axis = NormalizeAxis(axis, NDim(x));
            return new KerasSymbol(sym.Prod(data: x.Symbol, axis: axis, keepdims: keepdims));
        }

        public static KerasSymbol CumSum(KerasSymbol x, int axis = 0)
        {
            throw new NotSupportedException("MXNet Backend: CumSum operations are not supported yet.");
        }

        public static KerasSymbol CumProd(KerasSymbol x, int axis = 0)
        {
            throw new NotSupportedException("MXNet Backend: CumProd operations are not supported yet.");
        }

        public static Symbol MxNetVariance(Symbol x, Shape axis = null, bool keepdims = false)
        {
            var mean_input = sym.Mean(data: x, axis: axis, keepdims: true);
            var centered_input = sym.BroadcastSub(lhs: x, rhs: mean_input);
            var v = sym.Mean(data: sym.Square(centered_input), axis: axis, keepdims: keepdims);
            return v;
        }

        public static KerasSymbol Var(KerasSymbol x, Shape axis = null, bool keepdims = false)
        {
            axis = NormalizeAxis(axis, NDim(x));
            var v = MxNetVariance(x.Symbol, axis: axis, keepdims: keepdims);
            return new KerasSymbol(v);
        }

        public static KerasSymbol Std(KerasSymbol x, Shape axis = null, bool keepdims = false)
        {
            var v = Var(x, axis: axis, keepdims: keepdims);
            var ret = sym.Sqrt(data: v.Symbol);
            return new KerasSymbol(ret);
        }

        public static KerasSymbol Mean(KerasSymbol x, Shape axis = null, bool keepdims = false)
        {
            Symbol ret = null;
            
            axis = NormalizeAxis(axis, NDim(x));
            if (DataType(x) == "uint8")
            {
                x = Cast(x, FloatX());
            }
            if (axis != null)
            {
                ret = sym.Mean(data: x.Symbol, axis: axis, keepdims: keepdims);
            }
            else
            {
                ret = sym.Mean(data: x.Symbol, keepdims: keepdims);
            }

            return new KerasSymbol(ret);
        }

        public static KerasSymbol Any(Symbol x, Shape axis = null, bool keepdims = false)
        {
            axis = NormalizeAxis(axis, NDim(x));
            var non_zero = sym.NotEqualScalar(x, 0);
            var var_cast = sym.Cast(data: non_zero, dtype: DType.Int32);
            var var_sum = sym.Sum(data: var_cast, axis: axis, keepdims: keepdims);
            return new KerasSymbol(var_sum > 0);
        }

        public static KerasSymbol All(Symbol x, Shape axis = null, bool keepdims = false)
        {
            axis = NormalizeAxis(axis, NDim(x));
            var var_abs = sym.Abs(data: x);
            var var_min = sym.Min(data: var_abs, axis: axis, keepdims: keepdims);
            return new KerasSymbol(var_min > 0);
        }

        public static KerasSymbol Argmax(KerasSymbol x, int axis = -1)
        {
            axis = NormalizeAxis(axis, NDim(x));
            var ret = sym.Argmax(data: x.Symbol, axis: axis);
            return new KerasSymbol(ret);
        }

        public static KerasSymbol Argmin(KerasSymbol x, int axis = -1)
        {
            axis = NormalizeAxis(axis, NDim(x));
            var ret = sym.Argmin(data: x.Symbol, axis: axis);
            return new KerasSymbol(ret);
        }

        public static KerasSymbol Square(KerasSymbol x)
        {
            return new KerasSymbol(sym.Square(data: x.Symbol));
        }

        public static KerasSymbol Abs(KerasSymbol x)
        {
            return new KerasSymbol(sym.Abs(data: x.Symbol));
        }

        public static KerasSymbol Sqrt(KerasSymbol x)
        {
            var ret = sym.Activation(data: x.Symbol, act_type: ActivationType.Relu);
            ret = sym.Sqrt(data: ret);
            return new KerasSymbol(ret);
        }

        public static KerasSymbol Exp(KerasSymbol x)
        {
            return new KerasSymbol(sym.Exp(data: x.Symbol));
        }

        public static KerasSymbol Log(KerasSymbol x)
        {
            return new KerasSymbol(sym.Log(data: x.Symbol));
        }

        public static KerasSymbol LogSumExp(Symbol x, int? axis = null, bool keepdims = false)
        {
            throw new NotSupportedException("MXNet Backend: LogSumExp operations are not supported yet.");
        }

        public static KerasSymbol Round(KerasSymbol x)
        {
            return new KerasSymbol(sym.Round(data: x.Symbol));
        }

        public static KerasSymbol Sign(KerasSymbol x)
        {
            return new KerasSymbol(sym.Sign(data: x.Symbol));
        }

        public static KerasSymbol Pow(KerasSymbol x, KerasSymbol a)
        {
            return new KerasSymbol(sym.Power(x.Symbol, a.Symbol));
        }

        public static KerasSymbol Clip(KerasSymbol x, float? min_value, float? max_value)
        {
            if (max_value != null && max_value < min_value)
            {
                max_value = min_value;
            }
            if (max_value == null)
            {
                max_value = float.PositiveInfinity;
            }

            return new KerasSymbol(sym.Clip(data: x.Symbol, a_min: min_value.Value, a_max: max_value.Value));
        }

        public static KerasSymbol Equal(KerasSymbol x, KerasSymbol y)
        {
            return new KerasSymbol(sym.BroadcastEqual(x.Symbol, y.Symbol));
        }

        public static KerasSymbol NotEqual(KerasSymbol x, KerasSymbol y)
        {
            return new KerasSymbol(sym.BroadcastNotEqual(x.Symbol, y.Symbol));
        }

        public static KerasSymbol Greater(KerasSymbol x, KerasSymbol y)
        {
            return new KerasSymbol(sym.BroadcastGreater(x.Symbol, y.Symbol));
        }

        public static KerasSymbol Greater(KerasSymbol x, float y)
        {
            var y_sym = sym.Full(y, x.Shape, dtype: x.DType);
            return new KerasSymbol(sym.BroadcastGreaterEqual(x.Symbol, y_sym));
        }

        public static KerasSymbol GreaterEqual(KerasSymbol x, KerasSymbol y)
        {
            return new KerasSymbol(sym.BroadcastGreaterEqual(x.Symbol, y.Symbol));
        }

        public static KerasSymbol GreaterEqual(KerasSymbol x, float y)
        {
            var y_sym = sym.Full(y, x.Shape, dtype: x.DType);
            return new KerasSymbol(sym.BroadcastGreaterEqual(x.Symbol, y_sym));
        }

        public static KerasSymbol Less(KerasSymbol x, KerasSymbol y)
        {
            return new KerasSymbol(sym.BroadcastLesser(x.Symbol, y.Symbol));
        }

        public static KerasSymbol LessEqual(KerasSymbol x, KerasSymbol y)
        {
            return new KerasSymbol(sym.BroadcastLesserEqual(x.Symbol, y.Symbol));
        }

        public static KerasSymbol Maximum(KerasSymbol x, KerasSymbol y)
        {
            return new KerasSymbol(sym.Maximum(x.Symbol, y.Symbol));
        }

        public static KerasSymbol Maximum(float x, KerasSymbol y)
        {
            var x_sym = sym.Full(x, y.Shape, dtype: y.DType);
            return new KerasSymbol(sym.Maximum(x_sym, y.Symbol));
        }

        public static KerasSymbol Maximum(KerasSymbol x, float y)
        {
            var y_sym = sym.Full(y, x.Shape, dtype: x.DType);
            return new KerasSymbol(sym.Maximum(x.Symbol, y_sym));
        }

        public static KerasSymbol Minimum(KerasSymbol x, KerasSymbol y)
        {
            return new KerasSymbol(sym.Minimum(x.Symbol, y.Symbol));
        }

        public static KerasSymbol Minimum(KerasSymbol x, float y)
        {
            var y_sym = sym.Full(y, x.Shape, dtype: x.DType);
            return new KerasSymbol(sym.Minimum(x.Symbol, y_sym));
        }

        public static KerasSymbol Sin(KerasSymbol x)
        {
            return new KerasSymbol(sym.Sin(x.Symbol));
        }

        public static KerasSymbol Cos(KerasSymbol x)
        {
            return new KerasSymbol(sym.Cos(x.Symbol));
        }

        public static (KerasSymbol, KerasSymbol, KerasSymbol) NormalizeBatchInTraining(KerasSymbol x, KerasSymbol gamma, KerasSymbol beta, Shape reduction_axes, float epsilon= 1e-3f)
        {
            var original_x = x;
            var mean = sym.Mean(data: x.Symbol, axis: reduction_axes, keepdims: false);
            var var = MxNetVariance(x.Symbol, axis: reduction_axes, keepdims: false);
            KerasSymbol normed = null;
            if (reduction_axes.Data.OrderBy(_p_1 => _p_1).ToList() == Enumerable.Range(0, NDim(original_x)).ToArray().Reverse())
            {
                normed = BatchNormalization(x, mean, var, beta, gamma, epsilon);
            }
            else
            {
                // need broadcasting
                var target_shape = new List<int>();
                foreach (var axis in Enumerable.Range(0, NDim(original_x)))
                {
                    if (reduction_axes.Data.Contains(axis))
                    {
                        target_shape.Add(1);
                    }
                    else
                    {
                        target_shape.Add(original_x.Shape[axis]);
                    }
                }

                var broadcast_mean = sym.Reshape(data: mean, shape: new Shape(target_shape));
                var broadcast_var = sym.Reshape(data: var, shape: new Shape(target_shape));
                var broadcast_gamma = sym.Reshape(data: gamma.Symbol, shape: new Shape(target_shape));
                var broadcast_beta = sym.Reshape(data: beta.Symbol, shape: new Shape(target_shape));
                normed = BatchNormalization(x, broadcast_mean, broadcast_var, broadcast_beta, broadcast_gamma, epsilon);
            }

            return (normed, new KerasSymbol(mean), new KerasSymbol(var));
        }

        public static KerasSymbol BatchNormalization(KerasSymbol x, KerasSymbol mean, KerasSymbol var, KerasSymbol beta, KerasSymbol gamma, float epsilon = 1e-3f)
        {
            mean = sym.StopGradient(mean.Symbol);
            var = sym.StopGradient(var.Symbol);
            // gradient explode when learning gamma and beta at together.
            gamma = sym.StopGradient(gamma.Symbol);
            var std = sym.Sqrt(data: var.Symbol + epsilon);
            x = sym.BroadcastSub(x.Symbol, mean.Symbol);
            x = sym.BroadcastDiv(x.Symbol, std);
            x = sym.BroadcastMul(x.Symbol, gamma.Symbol);
            x = sym.BroadcastAdd(x.Symbol, beta.Symbol);
            return x;
        }

        public static KerasSymbol MxNetBatchNorm(KerasSymbol x, KerasSymbol gamma, KerasSymbol beta, KerasSymbol moving_mean, KerasSymbol moving_var, float momentum= 0.9f, int axis= 1, float epsilon = 1e-3f)
        {
            return new KerasSymbol(sym.BatchNorm(x.Symbol, gamma.Symbol, beta.Symbol, moving_mean.Symbol, moving_var.Symbol, momentum: momentum, axis: axis, eps: epsilon));
        }

        public static KerasSymbol Concatenate(KerasSymbol[] tensors, int axis = 1)
        {
            if (axis < 0)
            {
                var rank = NDim(tensors[0]);
                if (rank > 0)
                {
                    axis %= rank;
                }
                else
                {
                    axis = 0;
                }
            }

            var symbols = (from t in tensors
                           select t.Symbol).ToList();
            return new KerasSymbol(sym.Concat(symbols, dim: axis));
        }

        public static KerasSymbol Reshape(KerasSymbol x, Shape shape)
        {
            return new KerasSymbol(sym.Reshape(data: x.Symbol, shape: shape));
        }

        public static KerasSymbol PermuteDimensions(KerasSymbol x, Shape shape)
        {
            return new KerasSymbol(sym.Transpose(data: x.Symbol, axes: shape));
        }

        public static KerasSymbol ResizeImage(KerasSymbol x, int height_factor, int width_factor, string data_format, string interpolation= "nearest")
        {
            if (data_format == "channels_last")
            {
                x = sym.Repeat(x.Symbol, repeats: height_factor, axis: 1);
                x = sym.Repeat(x.Symbol, repeats: width_factor, axis: 2);
            }
            else if (data_format == "channels_first")
            {
                x = sym.Repeat(x.Symbol, repeats: height_factor, axis: 2);
                x = sym.Repeat(x.Symbol, repeats: width_factor, axis: 3);
            }
            else
            {
                throw new ValueError("MXNET Backend: Data format is neither channels_first or channels_last");
            }

            return x;
        }

        public static KerasSymbol ResizeVolumses(KerasSymbol x, int depth_factor, int height_factor, int width_factor, string data_format)
        {
            if (data_format == "channels_last")
            {
                
                x = sym.Repeat(x.Symbol, repeats: depth_factor, axis: 1);
                x = sym.Repeat(x.Symbol, repeats: height_factor, axis: 2);
                x = sym.Repeat(x.Symbol, repeats: width_factor, axis: 3);
            }
            else if (data_format == "channels_first")
            {
                x = sym.Repeat(x.Symbol, repeats: depth_factor, axis: 2);
                x = sym.Repeat(x.Symbol, repeats: height_factor, axis: 3);
                x = sym.Repeat(x.Symbol, repeats: width_factor, axis: 4);
            }
            else
            {
                throw new ValueError("MXNET Backend: Data format is neither channels_first or channels_last");
            }

            return x;
        }

        public static KerasSymbol RepeatElements(KerasSymbol x, int rep, int axis)
        {
            return new KerasSymbol(sym.Repeat(data: x.Symbol, repeats: rep, axis: axis));
        }

        public static KerasSymbol Repeat(KerasSymbol x, int n)
        {
            x = sym.ExpandDims(x.Symbol, axis: 1);
            x = sym.Repeat(x.Symbol, repeats: n, axis: 1);
            return x;
        }

        public static KerasSymbol Arange(int start, int? stop = null, int step = 1, DType dtype = null)
        {
            return new KerasSymbol(sym.Arange(start: start, stop: stop, step: step, dtype: dtype));
        }

        public static KerasSymbol Tile(KerasSymbol x, int n)
        {
            return new KerasSymbol(sym.Tile(x.Symbol, reps: n));
        }

        public static KerasSymbol Flatten(KerasSymbol x)
        {
            return new KerasSymbol(sym.Reshape(data: x.Symbol, shape: new Shape(-1)));
        }

        public static KerasSymbol BatchFlatten(KerasSymbol x)
        {
            return new KerasSymbol(sym.Flatten(data: x.Symbol));
        }

        public static KerasSymbol ExpandDims(KerasSymbol x, int axis = -1)
        {
            if (axis < 0)
            {
                axis %= x.Shape.Dimension + 1;
            }

            return new KerasSymbol(sym.ExpandDims(x.Symbol, axis: axis));
        }

        public static KerasSymbol Squeeze(KerasSymbol x, int axis)
        {
            var shape = x.Shape.Data.ToList();
            Debug.Assert(shape[axis] == 1, "Can only squeeze size 1 dimension");
            return new KerasSymbol(sym.Reshape(data: x.Symbol, shape: new Shape(shape)));
        }

        public static KerasSymbol TemporalPadding(KerasSymbol x, (int, int)? padding= null)
        {
            if (padding == null)
                padding = (1, 1);

            Debug.Assert(NDim(x) == 3);
            // MXNet only supports padding for 4D and 5D tensor.
            // Reshaping to 4D, perform padding, reshape back to 3D.
            var x_shape = x.Shape;
            var x_4d = sym.Reshape(x.Symbol, shape: new Shape(x_shape[0], 1, x_shape[1], x_shape[2]));
            var x_4d_padded = sym.Pad(data: x_4d, mode: PadMode.Constant, constant_value: 0, pad_width: new Shape(0, 0, 0, 0, padding.Value.Item1, padding.Value.Item2, 0, 0));
            var x_3d_padded = sym.Reshape(x_4d_padded, shape: new Shape(x_shape[0], x_shape[1] + padding.Value.Item1 + padding.Value.Item2, x_shape[2]));
            return new KerasSymbol(x_3d_padded);
        }

        public static KerasSymbol Spatial2DPadding(KerasSymbol x, ((int, int), (int, int))? padding = null, string data_format = "")
        {
            if (padding == null)
                padding = ((1, 1), (1, 1));

            Debug.Assert(NDim(x) == 4);
            if (data_format == "")
            {
                data_format = ImageDataFormat();
            }

            ValidateDataFormat(data_format);
            // Pre process input for handling data_format - channels_first/channels_last.
            // MXNet requires input to be in channels_first.
            x = PreProcessConvNDInput(x, data_format);
            var pattern = new int[] { 0, 0, 0, 0, padding.Value.Item1.Item1, padding.Value.Item1.Item2, padding.Value.Item2.Item1, padding.Value.Item2.Item2 };
            x = new KerasSymbol(sym.Pad(data: x.Symbol, mode: PadMode.Constant, constant_value: 0, pad_width: new Shape(pattern)));
            // Convert back to original data_format
            x = PostProcessConvNDOutput(x, data_format);
            return x;
        }

        public static KerasSymbol Spatial3DPadding(KerasSymbol x, ((int, int), (int, int), (int, int))? padding = null, string data_format = "")
        {
            if (padding == null)
                padding = ((1, 1), (1, 1), (1, 1));

            Debug.Assert(NDim(x) == 4);
            if (data_format == "")
            {
                data_format = ImageDataFormat();
            }

            ValidateDataFormat(data_format);
            // Pre process input for handling data_format - channels_first/channels_last.
            // MXNet requires input to be in channels_first.
            x = PreProcessConvNDInput(x, data_format);
            var pattern = new int[] { 0, 0, 0, 0, padding.Value.Item1.Item1, padding.Value.Item1.Item2, padding.Value.Item2.Item1, padding.Value.Item2.Item2, padding.Value.Item3.Item1, padding.Value.Item3.Item2 };
            x = new KerasSymbol(sym.Pad(data: x.Symbol, mode: PadMode.Constant, constant_value: 0, pad_width: new Shape(pattern)));
            // Convert back to original data_format
            x = PostProcessConvNDOutput(x, data_format);
            return x;
        }

        public static KerasSymbol Stack(KerasSymbol x, int axis = 0)
        {
            throw new NotSupportedException("MXNet Backend: Stack operation is not supported yet.");
        }

        public static KerasSymbol OneHot(KerasSymbol indices, int num_classes)
        {
            return new KerasSymbol(sym.OneHot(indices.Symbol, depth: num_classes));
        }

        public static KerasSymbol Reverse(KerasSymbol x, Shape axes)
        {
            return new KerasSymbol(sym.Reverse(data: x.Symbol, axis: axes));
        }

        public static NDArray GetValue(KerasSymbol x)
        {
            return Eval(x);
        }

        public static NDArray GetMxNetModuleArgParams(KerasSymbol x)
        {
            // retrieve from bind values first, which is up to date with
            // arg_params in mxnet module
            var ret = Eval(x);
            if (x.Tensor != null)
            {
                if (x.GetBindValues().Contains(x.Name) && _MODEL != null)
                {
                    _MODEL.SyncWeights();
                    ret = x.GetBindValues()[x.Name];
                }
            }

            return ret;
        }

        public static NDArray[] BatchGetValue(KerasSymbol[] ops)
        {
            return (from op in ops
                    select GetMxNetModuleArgParams(op)).ToArray();
        }

        public static void SetValue(KerasSymbol x, NDArray value)
        {
            x.Bind(value);
        }

        public static void BatchSetValue(List<(Symbol, NDArray)> tuples)
        {
            foreach (var (p, w) in tuples)
            {
                SetValue(p, w);
            }
        }

        public static Shape GetVariableShape(KerasSymbol x)
        {
            return x.Shape;
        }

        public static void PrintTensor(KerasSymbol x, string message = "")
        {
            Console.WriteLine(message + Eval(x));
        }

        public static KerasSymbol Group(KerasSymbol[] variables)
        {
            var var = variables.Select(x => x.Symbol).ToArray();
            var sym = Symbol.Group(var);
            return new KerasSymbol(sym);
        }

        public static KerasSymbol MakeLoss(KerasSymbol variables)
        {
            var s = sym.MakeLoss(variables.Symbol, 1);
            return new KerasSymbol(s);
        }

        public static Function Function(KerasSymbol[] inputs, KerasSymbol[] outputs, KerasSymbol[] updates)
        {
            return new Function(inputs, outputs, updates);
        }

        public static KerasSymbol[] StopGradient(KerasSymbol[] variables)
        {
            List<KerasSymbol> outputs = new List<KerasSymbol>();
            foreach (var item in variables)
            {
                outputs.Add(new KerasSymbol(sym.BlockGrad(item.Symbol)));
            }

            return outputs.ToArray();
        }

        public static KerasSymbol StopGradient(KerasSymbol variables)
        {
            return new KerasSymbol(sym.BlockGrad(variables.Symbol));
        }

        public static (KerasSymbol, KerasSymbol[], KerasSymbol[]) RNN(Func<KerasSymbol, KerasSymbol[], (KerasSymbol, KerasSymbol[])> step_function, KerasSymbol input, KerasSymbol[] initial_states, bool go_backwards= false, KerasSymbol mask= null, KerasSymbol[] constants = null,
            bool unroll= false, int? input_length= null, SimpleRNNCell cell = null, bool? training= null)
        {
            Symbol data;
            KerasSymbol last_output;
            SymbolList masks;
            SymbolList outputs;
            List<KerasSymbol> states;
            SymbolList inputs = null;
            var dtype = input.DType;
            var dshape = input.Shape;
            if (dshape.Dimension < 3)
            {
                throw new Exception("MXNet Backend: Input tensor should be at least 3-D");
            }

            if (constants == null)
            {
                constants = new KerasSymbol[0];
            }

            // Assume learning phase is a placeholder tensor.(F = test, T = train)
            // Some Keras layers (e.g. Dropout, BatchNormalization) behave differently at
            //  training time and testing time. You can tell whether a layer uses the
            // "learning phase" (train/test) by printing layer.uses_learning_phase, a
            // boolean: True if the layer has a different behavior in training mode and
            // test mode, False otherwise.
            bool uses_learning_phase = false;
            // for custom operations when K.rnn is directly called to operate
            // on tensors (mostly unit tests), no cell information is provided,
            // use unrolling by default
            if (!unroll && cell == null)
            {
                unroll = true;
                Logger.Warning("MXNet Backend: K.rnn() is called without RNN cell information, using unrolling by default.");
            }

            if (unroll)
            {
                // Split the inputs across time dimension and generate the list of inputs
                // with shape `(samples, ...)` (no time dimension)
                inputs = sym.Split(input.Symbol, axis: 1, squeeze_axis: true, num_outputs: dshape[1]).ToList();
                
                // Reverse the input sequence
                if (go_backwards)
                {
                    inputs = inputs.Reverse().ToList();
                }

                states = initial_states != null ? initial_states.ToList() : null;
                outputs = new List<Symbol>();
                KerasSymbol prev_output = null;
                if (mask != null)
                {
                    if (states == null)
                    {
                        throw new ValueError("MXNet Backend: Initial states is not provided when masking is enabled.");
                    }

                    if (mask.DType != dtype)
                    {
                        mask = Cast(mask, dtype);
                    }
                    // Split the mask across time dimension and generate the list of masks
                    // with shape `(samples, 1)` (no time dimension)
                    masks = sym.Split(mask.Symbol, axis: 1, squeeze_axis: true, num_outputs: dshape[1]).ToList();
                    // Reverse the mask sequence
                    if (go_backwards)
                    {
                        masks = masks.Reverse().ToList();
                    }
                }
                else
                {
                    masks = new SymbolList(inputs.Length);
                }
                // Iterate over a time step
                foreach (var _tup_1 in Enumerable.Zip(inputs, masks, (i , m) => (i,m)))
                {
                    var inp = _tup_1.Item1;
                    var msk = _tup_1.Item2;
                    var stateswithconstants = states;
                    stateswithconstants.AddRange(constants);
                    var _tup_2 = step_function(new KerasSymbol(inp), stateswithconstants.ToArray());
                    last_output = _tup_2.Item1;
                    var new_states = _tup_2.Item2;
                    uses_learning_phase = last_output._uses_learning_phase;

                    if (msk != null)
                    {
                        new_states = Enumerable.Zip(states, new_states, (s, ns) => {
                            return new KerasSymbol(sym.Where(msk, ns.Symbol, s.Symbol));
                        }).ToArray();

                        // Initialize the output for first time step
                        if (prev_output == null)
                        {
                            prev_output = ZerosLike(last_output);
                        }

                        last_output = new KerasSymbol(sym.Where(msk, last_output.Symbol, prev_output.Symbol));
                        prev_output = last_output;
                    }

                    states = new_states.ToList();
                    // Expand the output dimension from `(samples, output_dim)` to
                    // `(samples, 1, output_dim)` with middle axis as time dimension
                    outputs.Add(sym.ExpandDims(last_output.Symbol, axis: 1));
                }

                // Concatenate the output across time dimension
                outputs = sym.Concat(outputs, dim: 1);
            }
            else
            {
                
            }

            throw new NotImplementedException();
        }

        public static Symbol DotRnn(Symbol x, Symbol y)
        {
            var _tup_1 = y.InferShapePartial(new Dictionary<string, Shape>());
            var shape = _tup_1.Item2;
            int ndim_y = shape != null ? shape[0].Dimension : 0;
            if (ndim_y > 2)
            {
                var axis = Enumerable.Range(0, ndim_y).ToList();
                int popped = axis.Pop(-2);
                axis.Add(popped);
                y = sym.Transpose(y, axes: new Shape(axis));
            }

            return sym.Dot(x, y);
        }

        public static KerasSymbol[] GenerateDropoutMask(KerasSymbol ones, float rate, bool? training = null, int count = 1)
        {
            Func<KerasSymbol> dropped_inputs = () => {
                return Dropout(ones, rate);
            };

            if (count > 1)
            {
                return (from _ in Enumerable.Range(0, count)
                        select InTrainPhase(dropped_inputs, ones, training: training)).ToArray();
            }

            return new KerasSymbol[] { InTrainPhase(dropped_inputs, ones, training: training) };
        }

        public static KerasSymbol Switch(KerasSymbol condition, KerasSymbol then_expression, KerasSymbol else_expression)
        {
            Debug.Assert(condition is KerasSymbol && then_expression is KerasSymbol && else_expression is KerasSymbol);
            return new KerasSymbol(sym.Where(condition.Symbol, then_expression.Symbol, else_expression.Symbol));
        }

        public static KerasSymbol InTrainPhase(KerasSymbol x, KerasSymbol alt, bool? training= null)
        {
            KerasSymbol res;
            var uses_learning_phase = false;
            if (training == null)
            {
                training = LearningPhase();
                uses_learning_phase = true;
            }
            if (training.HasValue)
            {
                res = x;
                uses_learning_phase = true;
            }
            else
            {
                res = alt;
            }
            if (uses_learning_phase)
            {
                res._uses_learning_phase = true;
            }

            return res;
        }

        public static KerasSymbol InTrainPhase(Func<KerasSymbol> x, KerasSymbol alt, bool? training = null)
        {
            KerasSymbol res;
            var uses_learning_phase = false;
            if (training == null)
            {
                training = LearningPhase();
                uses_learning_phase = true;
            }
            if (training.HasValue)
            {
                res = x();
                uses_learning_phase = true;
            }
            else
            {
                res = alt;
            }
            if (uses_learning_phase)
            {
                res._uses_learning_phase = true;
            }

            return res;
        }   

        public static KerasSymbol InTestPhase(KerasSymbol x, KerasSymbol alt, bool? training = null)
        {
            return InTrainPhase(alt, x, training: training);
        }

        public static KerasSymbol Relu(KerasSymbol x, float alpha= 0, float? max_value= null, float threshold= 0)
        {
            Symbol negative_part = null;
            Symbol data = null;
            if (alpha != 0.0)
            {
                if (max_value == null && threshold == 0.0)
                {
                    return new KerasSymbol(sym.LeakyReLU(data: x.Symbol, act_type: ReluActType.Leaky, slope: alpha));
                }
                if (threshold != 0.0)
                {
                    data = sym.Negative(x.Symbol) + threshold;
                    negative_part = sym.LeakyReLU(data: data, act_type: ReluActType.Leaky, slope: 0);
                }
                else
                {
                    data = sym.Negative(x.Symbol);
                    negative_part = sym.LeakyReLU(data: data, act_type: ReluActType.Leaky, slope: 0);
                }
            }
            var clip_max = max_value != null;
            if (threshold != 0)
            {
                // computes x for x > threshold else 0
                x = x * Cast(Greater(x, threshold), FloatX());
            }
            else
            {
                x = new KerasSymbol(sym.LeakyReLU(data: x.Symbol, act_type: ReluActType.Leaky, slope: alpha));
            }
            if (clip_max)
            {
                x = new KerasSymbol(sym.Clip(x.Symbol, 0, max_value.Value));
            }
            if (alpha != 0)
            {
                negative_part = alpha * negative_part;
                x = x - new KerasSymbol(negative_part);
            }

            return x;
        }

        public static KerasSymbol Elu(KerasSymbol x, float alpha = 1)
        {
            return new KerasSymbol(sym.LeakyReLU(data: x.Symbol, act_type: ReluActType.Elu, slope: alpha));
        }

        public static KerasSymbol Softmax(KerasSymbol x, int axis = -1)
        {
            return new KerasSymbol(sym.Softmax(data: x.Symbol, axis: axis));
        }

        public static KerasSymbol Softplus(KerasSymbol x)
        {
            return new KerasSymbol(sym.Activation(data: x.Symbol, act_type: ActivationType.Softrelu));
        }

        public static KerasSymbol Softsign(KerasSymbol x)
        {
            return new KerasSymbol(x.Symbol / (1 + sym.Abs(x.Symbol)));
        }

        public static KerasSymbol CategoricalCrossentropy(KerasSymbol target, KerasSymbol output, bool from_logits= false, int axis= -1)
        {
            var output_dimensions = Enumerable.Range(0, NDim(output)).ToList();
            if (axis != -1 && !output_dimensions.Contains(axis))
            {
                throw new Exception($"Unexpected channels axis {axis}. Expected to be -1 or one of the axes of `output`, which has {IntShape(output).Length} dimensions.");
            }

            var mx_output = output.Symbol;
            // scale predictions so that the class probabilities of each sample sum to 1
            if (from_logits)
            {
                mx_output = sym.Softmax(mx_output, axis: axis);
            }
            else
            {
                mx_output = sym.BroadcastDiv(mx_output, sym.Sum(mx_output, axis: axis, keepdims: true));
            }
            // clip to prevent NaN's and Inf's
            mx_output = sym.Clip(mx_output, a_min: Epsilon(), a_max: 1 - Epsilon());
            // calc
            mx_output = sym.Negative(sym.Sum(target.Symbol * sym.Log(mx_output), axis: axis));
            return new KerasSymbol(mx_output);
        }

        public static KerasSymbol SparseCategoricalCrossentropy(KerasSymbol target, KerasSymbol output, bool from_logits = false, int axis = -1)
        {
            var output_dimensions = Enumerable.Range(0, NDim(output)).ToList();
            if (axis != -1 && !output_dimensions.Contains(axis))
            {
                throw new Exception($"Unexpected channels axis {axis}. Expected to be -1 or one of the axes of `output`, which has {IntShape(output).Length} dimensions.");
            }
            var mx_output = output.Symbol;
            // scale predictions so that the class probabilities of each sample sum to 1
            if (from_logits)
            {
                mx_output = sym.Softmax(mx_output, axis: axis);
            }
            else
            {
                mx_output = sym.BroadcastDiv(mx_output, sym.Sum(mx_output, axis: axis, keepdims: true));
            }
            // clip to prevent NaN's and Inf's
            mx_output = sym.Clip(mx_output, a_min: Epsilon(), a_max: 1 - Epsilon());
            // For this operation, the probability of a given label is considered exclusive.
            mx_output = sym.Pick(mx_output, target.Symbol, axis: axis, keepdims: true);
            mx_output = sym.Negative(sym.Log(mx_output));
            // reshape to input's shape
            return Reshape(new KerasSymbol(mx_output), target.Shape);
        }

        public static KerasSymbol MultiHotSparseCategoricalCrossentropy(KerasSymbol target, KerasSymbol output, bool from_logits = false, int axis = -1)
        {
            var output_dimensions = Enumerable.Range(0, NDim(output)).ToList();
            if (axis != -1 && !output_dimensions.Contains(axis))
            {
                throw new Exception($"Unexpected channels axis {axis}. Expected to be -1 or one of the axes of `output`, which has {IntShape(output).Length} dimensions.");
            }

            var mx_output = output.Symbol;
            // scale predictions so that the class probabilities of each sample sum to 1
            if (from_logits)
            {
                mx_output = sym.Softmax(mx_output, axis: axis);
            }
            else
            {
                mx_output = sym.BroadcastDiv(mx_output, sym.Sum(mx_output, axis: axis, keepdims: true));
            }
            // clip to prevent NaN's and Inf's
            mx_output = sym.Clip(mx_output, a_min: Epsilon(), a_max: 1 - Epsilon());
            // using control flow ops to iterate output and take target (true label)
            var outputs = sym.Take(mx_output, target.Symbol);
            // calculate loss
            // check if target is larger than 0, remove padded labels (-1)
            outputs = sym.Negative(sym.Sum(sym.BroadcastGreaterEqual(target.Symbol, sym.Zeros(new Shape(1, 1))) * sym.Log(outputs), axis: axis));
            return new KerasSymbol(outputs);
        }

        public static KerasSymbol BinaryCrossentropy(KerasSymbol target, KerasSymbol output, bool from_logits = false)
        {
            var mx_output = output.Symbol;
            if (from_logits)
            {
                mx_output = sym.Activation(mx_output, act_type: ActivationType.Sigmoid);
            }

            mx_output = sym.Clip(mx_output, a_min: Epsilon(), a_max: 1 - Epsilon());
            mx_output = sym.Negative(target.Symbol) * sym.Log(mx_output) + (1 - target.Symbol) * sym.Log(1 - mx_output);
            return new KerasSymbol(mx_output);
        }

        public static KerasSymbol Sigmoid(KerasSymbol x)
        {
            return new KerasSymbol(sym.Activation(data: x.Symbol, act_type: ActivationType.Sigmoid));
        }

        public static KerasSymbol HardSigmoid(KerasSymbol x)
        {
            return new KerasSymbol(sym.Clip(data: 0.2f * x.Symbol + 0.5f, a_min: 0, a_max: 1));
        }

        public static KerasSymbol Tanh(KerasSymbol x)
        {
            return new KerasSymbol(sym.Tanh(data: x.Symbol));
        }

        public static KerasSymbol Dropout(KerasSymbol x, float level, Shape noise_shape = null, int? seed = null)
        {
            if (!(0 <= level && level <= 1))
            {
                throw new ValueError($"MXNet Backend: Invalid level provided for dropout `{level}`. Expected between 0 and 1.");
            }

            if (seed.HasValue)
            {
                mx.Seed(seed.Value);
            }
            else
            {
                mx.Seed(10000000);
            }
            var name = PrepareName(null, "dropout");
            return new KerasSymbol(sym.Dropout(data: x.Symbol, p: level, symbol_name: name));
        }

        public static KerasSymbol L2Normalize(KerasSymbol x, int axis = -1)
        {
            var norm = sym.Sqrt(data: sym.Sum(data: sym.Square(data: x.Symbol), axis: axis, keepdims: true));
            return new KerasSymbol(sym.BroadcastDiv(x.Symbol, norm));
        }

        public static KerasSymbol InTopK(KerasSymbol predictions, KerasSymbol targets, int k)
        {
            var targets_sym = sym.Cast(targets.Symbol, dtype: DType.Int32);
            var topk_sym = sym.Cast(sym.Topk(data: predictions.Symbol, k: k, ret_typ: TopkRetTyp.Mask), dtype: DType.Uint8);
            return new KerasSymbol(sym.Pick(topk_sym, targets_sym));
        }

        public static KerasSymbol Conv1D(KerasSymbol x, KerasSymbol kernel, int strides= 1, string padding= "valid", string data_format= "",                                int dilation_rate= 1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Conv2D(KerasSymbol x, KerasSymbol kernel, (int, int)? strides = null, string padding = "valid", string data_format = "", (int, int)? dilation_rate = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Conv2DTranspose(KerasSymbol x, KerasSymbol kernel, Shape output_shape, (int, int)? strides = null, string padding = "valid", string data_format = "", (int, int)? dilation_rate = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol SeparableConv2D(KerasSymbol x, KerasSymbol depthwise_kernel, KerasSymbol pointwise_kernel, (int, int)? strides = null, string padding = "valid", string data_format = "", (int, int)? dilation_rate = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol DepthwiseConv2D(KerasSymbol x, KerasSymbol depthwise_kernel, (int, int)? strides = null, string padding = "valid", string data_format = "", (int, int)? dilation_rate = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Conv3D(KerasSymbol x, KerasSymbol kernel, (int, int, int)? strides = null, string padding = "valid", string data_format = "", (int, int, int)? dilation_rate = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Conv3DTranspose(KerasSymbol x, KerasSymbol kernel, Shape output_shape, (int, int, int)? strides = null, string padding = "valid", string data_format = "")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Pool2D(KerasSymbol x, (int, int) pool_size, (int, int)? strides = null, string padding = "valid", string data_format = "", string pool_mode = "max")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Pool3D(KerasSymbol x, (int, int, int) pool_size, (int, int, int)? strides = null, string padding = "valid", string data_format = "", string pool_mode = "max")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol BiasAdd(KerasSymbol x, KerasSymbol bias, string data_format= "channels_last")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol RandomNormal(Shape shape, float mean = 0, float stddev = 1, DType dtype = null, int? seed = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol RandomUniform(Shape shape, float minval = 0, float maxval = 1, DType dtype = null, int? seed = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol NormalBinomial(Shape shape, float p = 0, DType dtype = null, int? seed = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol TruncatedNormal(Shape shape, float mean = 0, float stddev = 1, DType dtype = null, int? seed = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol CTCBatchCost(KerasSymbol y_true, KerasSymbol y_pred, KerasSymbol input_length, KerasSymbol label_length)
        {
            throw new NotImplementedException();
        }

        public static int GetUid(string prefix = "")
        {
            throw new NotImplementedException();
        }

        public static void ResetUids()
        {
            throw new NotImplementedException();
        }

        private static string PrepareName(string name, string @default)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol[] DfsGetBindValues(KerasSymbol node_start)
        {
            throw new NotImplementedException();
        }

        public static NDArrayList ForwardPass(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol KerasVariable(string name, Shape shape, DType dtype, StorageStype stype= StorageStype.Default, bool is_vector= false)
        {
            throw new NotImplementedException();
        }

        private static DType ConvertStringDType(DType dtype)
        {
            throw new NotImplementedException();
        }

        private static string ConvertDTypeString(DType dtype)
        {
            throw new NotImplementedException();
        }

        private static Shape NormalizeAxis(Shape shape, int ndim)
        {
            var axis = shape.Data.ToList();

            if (ndim == 0)
            {
                return shape;
            }

            foreach (var _tup_1 in axis.Select((_p_1, _p_2) => Tuple.Create(_p_2, _p_1)))
            {
                var i = _tup_1.Item1;
                var a = _tup_1.Item2;
                if (a < 0)
                {
                    axis[i] = a % ndim;
                }
            }

            return new Shape(axis);
        }

        private static int NormalizeAxis(int axis, int ndim)
        {
            if (ndim == 0)
            {
                return axis;
            }

            if (axis < 0)
                return axis % ndim;

            return axis;
        }

        private static void ValidateDataFormat(string data_format)
        {
            throw new NotImplementedException();
        }

        private static void ValidatePoolMode(string pool_mode)
        {
            throw new NotImplementedException();
        }

        private static void ValidatePaddingMode(string padding)
        {
            throw new NotImplementedException();
        }

        private static int CalculateConvOutputSize(int input_length, int filter_size, int padding, int stride,int dilation= 1)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol PreProcessConvNDInput(KerasSymbol data_var, string data_format)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol PostProcessConvNDOutput(KerasSymbol x, string data_format)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol PreProcessConvNDKernel(KerasSymbol kernel, string data_format)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol PreProcessConvDWKernel(KerasSymbol kernel, string data_format)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol PreProcessConvNDTransposeOutput(Shape output_shape, string data_format)
        {
            throw new NotImplementedException();
        }

        private static void ValidateConvInputShape(Shape input_shape)
        {
            throw new NotImplementedException();
        }

        private static int CalculatePaddingRequirement(Shape input_shape, KerasSymbol kernel, int strides, int dilation, string border_mode)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol LayoutKernel(KerasSymbol kernel)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol MxSpConv(KerasSymbol data, int num_in_channel, int num_out_channel, (int, int)? dw_kernel_shape= null,                           KerasSymbol dw_kernel_weight= null, (int,int)? pw_kernel_shape= null, KerasSymbol pw_kernel_weight = null,
                                (int, int)? stride= null, (int, int)? pad = null, string name= "", float depth_mult= 1)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol SpConvNd(KerasSymbol x, KerasSymbol depthwise_kernel, KerasSymbol pointwise_kernel, int[] strides, int[] filter_dilation, string name= "", string padding_mode= "valid", string data_format= "default")
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol DWConv(KerasSymbol x, KerasSymbol kernel, int[] strides, int[] filter_dilation, string name= null, string padding_mode= "valid", string data_format= "default")
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol ConvNd(KerasSymbol x, KerasSymbol kernel, int[] strides, int[] filter_dilation, string name = null, string padding_mode = "valid", string data_format = "default")
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol ConvNdTranspose(KerasSymbol x, KerasSymbol kernel, Shape output_shape, int[] strides, int[] filter_dilation, string name = null, string padding_mode = "valid", string data_format = "default")
        {
            throw new NotImplementedException();
        }

        private static int CalculatePoolOutputSize(int input_length, int filter_size, int padding, int stride, int dilation= 1)
        {
            throw new NotImplementedException();
        }

        private static void ValidatePoolInputShape(Shape input_shape)
        {
            throw new NotImplementedException();
        }

        private static (int, int, int) CalculatePoolPaddingRequirement(string padding_mode, Shape input_shape, int[] kernel, int[] strides)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol PoolNd(KerasSymbol x, string name, int[] pool_size, int[] strides, string padding_mode= "valid", string data_format= "", string pool_mode= "max")
        {
            throw new NotImplementedException();
        }

        public static Model GetMxNetModelInfo(Model model)
        {
            throw new NotImplementedException();
        }

        public static int GetNumGpus()
        {
            throw new NotImplementedException();
        }

        public static Context[] GetMxNetContexts(Context context)
        {
            throw new NotImplementedException();
        }
    }
}
