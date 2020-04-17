using MxNet.Keras.Backend;
using MxNet.Keras.Engine;
using MxNet.Keras.Layers;
using MxNet.Sparse;
using NumpyDotNet;
using System;
using System.Collections.Generic;
using System.Data;
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

    public class MxNetBackend
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
            if (Common.FloatX() == "float32")
                return x.astype(np.Float32);
            else if (Common.FloatX() == "float64")
                return x.astype(np.Float64);

            return x;
        }

        public static NDArray CastToFloatX(NDArray x)
        {
            return x.AsType(Common.FloatX());
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
                dtype = Common.FloatX();
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
                dtype = Common.FloatX();
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
                dtype = Common.FloatX();
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
                dtype = Common.FloatX();
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
                dtype = Common.FloatX();
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
                dtype = Common.FloatX();
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
                x = Cast(x, Common.FloatX());
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

        public static KerasSymbol GreaterEqual(KerasSymbol x, KerasSymbol y)
        {
            return new KerasSymbol(sym.BroadcastGreaterEqual(x.Symbol, y.Symbol));
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

        public static KerasSymbol Minimum(KerasSymbol x, KerasSymbol y)
        {
            return new KerasSymbol(sym.Minimum(x.Symbol, y.Symbol));
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
            throw new NotImplementedException();
        }

        public static KerasSymbol MxNetBatchNorm(Symbol x, Symbol gamma, Symbol beta, Symbol moving_mean, Symbol moving_var, float momentum= 0.9f, int axis= 1, float epsilon = 1e-3f)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Concatenate(Symbol x, int axis = 1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Reshape(Symbol x, Shape shape)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol PermuteDimensions(Symbol x, Shape shape)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol ResizeImage(KerasSymbol x, int height_factor, int width_factor, string data_format, string interpolation= "nearest")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol ResizeVolumses(KerasSymbol x, int depth_factor, int height_factor, int width_factor, string data_format)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol RepeatElements(KerasSymbol x, int rep, int axis)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Repeat(KerasSymbol x, int n)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Arange(int start, int? stop = null, int step = 1, DType dtype = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Tile(KerasSymbol x, int n)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Flatten(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol BatchFlatten(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol ExpandDims(KerasSymbol x, int axis = -1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Squeeze(KerasSymbol x, int axis)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol TemporalPadding(KerasSymbol x, (int, int)? padding= null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Spatial2DPadding(KerasSymbol x, ((int, int), (int, int))? padding = null, string data_format = "")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Spatial3DPadding(KerasSymbol x, ((int, int), (int, int), (int, int))? padding = null, string data_format = "")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Stack(Symbol x, int axis = 0)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol OneHot(Symbol indices, int num_classes)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Reverse(Symbol x, Shape axes)
        {
            throw new NotImplementedException();
        }

        public static NDArray GetValue(Symbol x)
        {
            throw new NotImplementedException();
        }

        public static NDArray[] GetValue(KerasSymbol[] ops)
        {
            throw new NotImplementedException();
        }

        public static void SetValue(Symbol x, NDArray value)
        {
            throw new NotImplementedException();
        }

        public static void BatchSetValue(List<(Symbol, NDArray)> tuples)
        {
            throw new NotImplementedException();
        }

        public static Shape GetVariableShape(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static void PrintTensor(KerasSymbol x, string message = "")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Group(KerasSymbol[] variables)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol MakeLoss(KerasSymbol[] variables)
        {
            throw new NotImplementedException();
        }

        public static Function Func(KerasSymbol[] inputs, KerasSymbol output, KerasSymbol[] updates)
        {
            throw new NotImplementedException();
        }

        public static void StopGradient(KerasSymbol[] variables)
        {
            throw new NotImplementedException();
        }

        public static (KerasSymbol, KerasSymbol[], KerasSymbol[]) RNN(Func<KerasSymbol[], KerasSymbol[], KerasSymbol[]> step_function, KerasSymbol[]  inputs, KerasSymbol[]  initial_states, bool go_backwards= false, KerasSymbol mask= null, float[] constants= null,
            bool unroll= false, int? input_length= null, SimpleRNNCell cell = null, bool? training= null)
        {
            throw new NotImplementedException();
        }

        public static Symbol DotRnn(Symbol x, Symbol y)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol GenerateDropoutMask(Symbol ones, float rate, bool? training = null, int count = 1)
        {
            throw new NotImplementedException();
        }

        public static Symbol Switch(Symbol condition, Symbol then_expression, Symbol else_expression)
        {
            throw new NotImplementedException();
        }

        public static Symbol InTrainPhase(Symbol x, Symbol alt, bool? training= null)
        {
            throw new NotImplementedException();
        }

        public static Symbol InTestPhase(Symbol x, Symbol alt, bool? training = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Relu(KerasSymbol x, float alpha= 0, float? max_value= null, float threshold= 0)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Elu(KerasSymbol x, float alpha = 1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Softmax(KerasSymbol x, int axis = -1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Softplus(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Softsign(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol CategoricalCrossentropy(KerasSymbol target, KerasSymbol output, bool from_logits= false, int axis= -1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol SparseCategoricalCrossentropy(KerasSymbol target, KerasSymbol output, bool from_logits = false, int axis = -1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol MultiHotSparseCategoricalCrossentropy(KerasSymbol target, KerasSymbol output, bool from_logits = false, int axis = -1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol BinaryCrossentropy(KerasSymbol target, KerasSymbol output, bool from_logits = false)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Sigmoid(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol HardSigmoid(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Tanh(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Dropout(KerasSymbol x, float level, Shape noise_shape, int? seed = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol L2Normalize(KerasSymbol x, int axis = -1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol InTopK(KerasSymbol predictions, KerasSymbol targets, int k)
        {
            throw new NotImplementedException();
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

        public static KerasSymbol[] DfsGetBindValues(Symbol node_start)
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

        private static KerasSymbol PreprocessConvNDInput(KerasSymbol data_var, string data_format)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol PreprocessConvNDOutput(KerasSymbol x, string data_format)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol PreprocessConvNDKernel(KerasSymbol kernel, string data_format)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol PreprocessConvDWKernel(KerasSymbol kernel, string data_format)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol PreprocessConvNDTransposeOutput(Shape output_shape, string data_format)
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
