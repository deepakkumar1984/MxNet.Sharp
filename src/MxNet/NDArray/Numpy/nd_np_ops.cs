using MxNet.Numpy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNet.ND.Numpy
{
    internal class nd_np_ops
    {
        private static bool? _INT64_TENSOR_SIZE_ENABLED = null;

        public static Random random = new Random();
        public static Linalg linalg = new Linalg();

        private static dynamic _api_internal = new _api_internals();

        internal static bool Int64Enabled()
        {
            //if (_INT64_TENSOR_SIZE_ENABLED == null)
            //{
            //    _INT64_TENSOR_SIZE_ENABLED = Runtime.FeatureList().IsEnabled("INT64_TENSOR_SIZE");
            //}

            //return _INT64_TENSOR_SIZE_ENABLED.Value;
            return true;
        }

        public static ndarray empty(Shape shape, DType dtype = null, string order = "C", Context ctx = null)
        {
            if (shape == null) shape = new Shape();
            if (dtype == null) dtype = np.Float32;
            if (ctx == null) ctx = Context.CurrentContext;

            return new ndarray(shape, ctx: ctx, dtype: dtype);
        }

        public static Shape shape(ndarray a)
        {
            return a.Shape;
        }

        public static ndarray zeros(Shape shape, DType dtype = null, string order = "C", Context ctx = null)
        {
            if (shape == null) shape = new Shape();
            if (dtype == null) dtype = np.Float32;
            if (ctx == null) ctx = Context.CurrentContext;

            return _api_internal.zeros(shape: shape, ctx: ctx, dtype: dtype);
        }

        public static ndarray ones(Shape shape, DType dtype = null, string order = "C", Context ctx = null)
        {
            if (shape == null) shape = new Shape();
            if (dtype == null) dtype = np.Float32;
            if (ctx == null) ctx = Context.CurrentContext;

            return _api_internal.ones(shape: shape, ctx: ctx, dtype: dtype);
        }

        public static ndarray broadcast_to(ndarray array, Shape shape)
        {
            return _api_internal.broadcast_to(array: array, shape: shape);
        }

        public static ndarray full(Shape shape, double fill_value, DType dtype = null, string order = "C", Context ctx = null, ndarray @out = null)
        {
            if (order != "C") throw new NotSupportedException("order");

            @out = _api_internal.full(shape: shape, value: fill_value, dtype: dtype, ctx: ctx);
            return @out;
        }

        public static ndarray zero_like(ndarray prototype, DType dtype = null, string order = "C", ndarray @out = null)
        {
            @out =  full_like(prototype, 0, dtype, order, @out: @out);
            return @out;
        }

        public static bool all(ndarray a)
        {
            return ((ndarray)_api_internal.all(a: a)).AsScalar<bool>();
        }

        public static ndarray all(ndarray a, int axis, ndarray @out = null, bool keepdims = false)
        {
            @out = _api_internal.all(a: a, axis: axis, keepdims: keepdims);
            return @out;
        }

        public static bool any(ndarray a)
        {
            return ((ndarray)_api_internal.any(a: a)).AsScalar<bool>();
        }

        public static ndarray any(ndarray a, int axis, ndarray @out = null, bool keepdims = false)
        {
            @out = _api_internal.any(a: a, axis: axis, keepdims: keepdims);
            return @out;
        }

        public static ndarray identity(int n, DType dtype = null, Context ctx = null)
        {
            return _api_internal.identity(shape: new Shape(n, n), dtype: dtype, ctx: ctx);
        }

        public static ndarray take(ndarray a, ndarray indices, int? axis = null, string mode = "raise", ndarray @out = null)
        {
            if (!new string[] { "wrap", "clip", "raise" }.Contains(mode))
            {
                throw new NotImplementedException($"function take does not support mode '{mode}'");
            }
            if (axis == null)
            {
                return _api_internal.take(a: reshape(a, -1), indices: indices, axis: 0, mode: mode);
            }
            else
            {
                return _api_internal.take(a: a, indices: indices, axis: axis, mode: mode);
            }
        }

        public static ndarray unique(ndarray ar, int? axis = null)
        {
            var list = (NDArrayList)_api_internal.unique(ar: ar, axis: axis, multi: true);
            return list[0];
        }

        public static (ndarray, ndarray, ndarray, ndarray) unique(ndarray ar, bool return_index = false, bool return_inverse = false, bool return_counts = false, int? axis = null)
        {
            var ret = (NDArrayList)_api_internal.unique(ar: ar, return_index: return_index, return_inverse: return_inverse, return_counts: return_counts, axis: axis,  multi: true);
            return (ret[0], ret[1], ret[2], ret[3]);
        }

        public static ndarray add(ndarray x1, ndarray x2, ndarray @out = null)
        {
            @out = _api_internal.add(x1: x1, x2: x2);
            return @out;
        }

        public static ndarray add(ndarray x1, float x2, ndarray @out = null)
        {
            return add(x1, full_like(x1, x2));
        }

        public static ndarray add(float x1, ndarray x2, ndarray @out = null)
        {
            return add(full_like(x2, x1), x2);
        }

        public static ndarray subtract(ndarray x1, ndarray x2, ndarray @out = null)
        {
            @out = _api_internal.subtract(x1: x1, x2: x2);
            return @out;
        }

        public static ndarray subtract(ndarray x1, float x2, ndarray @out = null)
        {
            return subtract(x1, full_like(x1, x2));
        }

        public static ndarray subtract(float x1, ndarray x2, ndarray @out = null)
        {
            return subtract(full_like(x2, x1), x2);
        }

        public static ndarray multiply(ndarray x1, ndarray x2, ndarray @out = null)
        {
            @out = _api_internal.multiply(x1: x1, x2: x2);
            return @out;
        }

        public static ndarray multiply(ndarray x1, float x2, ndarray @out = null)
        {
            return multiply(x1, full_like(x1, x2));
        }

        public static ndarray multiply(float x1, ndarray x2, ndarray @out = null)
        {
            return multiply(full_like(x2, x1), x2);
        }

        public static ndarray divide(ndarray x1, ndarray x2, ndarray @out = null)
        {
            @out = _api_internal.divide(x1: x1, x2: x2);
            return @out;
        }

        public static ndarray divide(ndarray x1, float x2, ndarray @out = null)
        {
            return divide(x1, full_like(x1, x2));
        }

        public static ndarray divide(float x1, ndarray x2, ndarray @out = null)
        {
            return divide(full_like(x2, x1), x2);
        }

        public static ndarray true_divide(ndarray x1, ndarray x2, ndarray @out = null)
        {
            @out = _api_internal.true_divide(x1: x1, x2: x2);
            return @out;
        }

        public static ndarray true_divide(ndarray x1, float x2, ndarray @out = null)
        {
            return true_divide(x1, full_like(x1, x2));
        }

        public static ndarray true_divide(float x1, ndarray x2, ndarray @out = null)
        {
            return true_divide(full_like(x2, x1), x2);
        }

        public static ndarray mod(ndarray x1, ndarray x2, ndarray @out = null)
        {
            @out = _api_internal.mod(x1: x1, x2: x2);
            return @out;
        }

        public static ndarray mod(ndarray x1, float x2, ndarray @out = null)
        {
            return mod(x1, full_like(x1, x2));
        }

        public static ndarray mod(float x1, ndarray x2, ndarray @out = null)
        {
            return mod(full_like(x2, x1), x2);
        }

        public static ndarray fmod(ndarray x1, ndarray x2, ndarray @out = null)
        {
            @out = _api_internal.fmod(x1: x1, x2: x2);
            return @out;
        }

        public static ndarray matmul(ndarray x1, ndarray x2, ndarray @out = null)
        {
            @out = _api_internal.matmul(x1: x1, x2: x2);
            return @out;
        }

        public static ndarray remainder(ndarray x1, ndarray x2, ndarray @out = null)
        {
            @out = _api_internal.remainder(x1: x1, x2: x2);
            return @out;
        }

        public static ndarray power(ndarray x1, ndarray x2, ndarray @out = null)
        {
            @out = _api_internal.power(x1: x1, x2: x2);
            return @out;
        }

        public static ndarray power(ndarray x1, float x2, ndarray @out = null)
        {
            return power(x1, full_like(x1, x2));
        }

        public static ndarray gcd(ndarray x1, ndarray x2, ndarray @out = null)
        {
            @out = _api_internal.gcd(x1: x1, x2: x2);
            return @out;
        }

        public static ndarray lcm(ndarray x1, ndarray x2, ndarray @out = null)
        {
            @out = _api_internal.lcm(x1: x1, x2: x2);
            return @out;
        }

        public static ndarray sin(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.sin(x: x);
            return @out;
        }

        public static ndarray cos(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.cos(x: x);
            return @out;
        }

        public static ndarray sinh(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.sinh(x: x);
            return @out;
        }

        public static ndarray cosh(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.cosh(x: x);
            return @out;
        }

        public static ndarray tanh(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.tanh(x: x);
            return @out;
        }

        public static ndarray log10(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.log10(x: x);
            return @out;
        }

        public static ndarray sqrt(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.sqrt(x: x);
            return @out;
        }

        public static ndarray cbrt(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.cbrt(x: x);
            return @out;
        }

        public static ndarray abs(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.abs(x: x);
            return @out;
        }

        public static ndarray fabs(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.fabs(x: x);
            return @out;
        }

        public static ndarray absolute(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.absolute(x: x);
            return @out;
        }

        public static ndarray exp(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.exp(x: x);
            return @out;
        }

        public static ndarray expm1(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.expm1(x: x);
            return @out;
        }

        public static ndarray arcsin(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.arcsin(x: x);
            return @out;
        }

        public static ndarray arccos(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.arccos(x: x);
            return @out;
        }

        public static ndarray arctan(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.arctan(x: x);
            return @out;
        }

        public static ndarray sign(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.sign(x: x);
            return @out;
        }

        public static ndarray log(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.log(x: x);
            return @out;
        }

        public static ndarray rint(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.rint(x: x);
            return @out;
        }

        public static ndarray log2(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.log2(x: x);
            return @out;
        }

        public static ndarray log1p(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.log1p(x: x);
            return @out;
        }

        public static ndarray degrees(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.degrees(x: x);
            return @out;
        }

        public static ndarray rad2deg(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.rad2deg(x: x);
            return @out;
        }

        public static ndarray radians(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.radians(x: x);
            return @out;
        }

        public static ndarray deg2rad(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.deg2rad(x: x);
            return @out;
        }

        public static ndarray reciprocal(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.reciprocal(x: x);
            return @out;
        }

        public static ndarray square(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.square(x: x);
            return @out;
        }

        public static ndarray negative(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.negative(x: x);
            return @out;
        }

        public static ndarray fix(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.fix(x: x);
            return @out;
        }

        public static ndarray tan(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.tan(x: x);
            return @out;
        }

        public static ndarray ceil(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.ceil(x: x);
            return @out;
        }

        public static ndarray floor(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.floor(x: x);
            return @out;
        }

        public static ndarray invert(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.invert(x: x);
            return @out;
        }

        public static ndarray bitwise_not(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.bitwise_not(x: x);
            return @out;
        }

        public static ndarray trunc(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.trunc(x: x);
            return @out;
        }

        public static ndarray logical_not(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.logical_not(x: x);
            return @out;
        }

        public static ndarray arcsinh(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.arcsinh(x: x);
            return @out;
        }

        public static ndarray arccosh(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.arccosh(x: x);
            return @out;
        }

        public static ndarray arctanh(ndarray x, ndarray @out = null)
        {
            @out = _api_internal.arctanh(x: x);
            return @out;
        }

        public static ndarray argsort(ndarray x, int axis = -1, string kind = null, string order = null)
        {
            if (order != null)
                throw new NotSupportedException("order is not supported");

            return _api_internal.argsort(a: x, axis: axis, is_ascend: true, dtype: np.Int64);
        }

        public static ndarray sort(ndarray x, int axis = -1, string kind = null, string order = null)
        {
            if (order != null)
                throw new NotSupportedException("order is not supported");

            return _api_internal.sort(a: x, axis: axis, is_ascend: true);
        }

        public static ndarray tensordot(ndarray a, ndarray b, int axes = 2)
        {
            return _api_internal.tensordot(a: a, b: b, axes: axes);
        }

        public static ndarray histogram(ndarray a, int bins = 10, (float, float)? range = null, bool? normed = null, ndarray weights = null, bool? density = null)
        {
            if (normed.HasValue && normed.Value)
            {
                throw new NotSupportedException("normed is not supported yet...");
            }

            if (weights != null)
            {
                throw new NotSupportedException("weights is not supported yet...");
            }

            if (density.HasValue && density.Value)
            {
                throw new NotSupportedException("density is not supported yet...");
            }

            return _api_internal.histogram(a, null, bins, new Tuple<float>(range.Value.Item1, range.Value.Item2));
        }

        public static ndarray histogram(ndarray a, ndarray bins, (float, float)? range = null, bool? normed = null, ndarray weights = null, bool? density = null)
        {
            if (normed.HasValue && normed.Value)
            {
                throw new NotSupportedException("normed is not supported yet...");
            }

            if (weights != null)
            {
                throw new NotSupportedException("weights is not supported yet...");
            }

            if (density.HasValue && density.Value)
            {
                throw new NotSupportedException("density is not supported yet...");
            }

            

            return _api_internal.histogram(a: a, bin_cnt: bins);
        }

        public static ndarray eye(int N, int? M = null, int k = 0, DType dtype = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray linspace(float start, float stop, int num = 50, bool endpoint = true, bool retstep = false, DType dtype = null, int axis = 0, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray logspace(float start, float stop, int num = 50, bool endpoint = true, bool retstep = false, DType dtype = null, int axis = 0, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray expand_dims(ndarray a, int axis)
        {
            throw new NotImplementedException();
        }

        public static ndarray tile(ndarray a, params int[] reps)
        {
            throw new NotImplementedException();
        }

        public static ndarray trace(ndarray a, int offset = 0, int axis1 = 0, int axis2 = 1, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray transpose(ndarray a, params int[] axes)
        {
            throw new NotImplementedException();
        }

        public static ndarray repeat(ndarray a, int repeats, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray tril(ndarray m, int k = 0)
        {
            throw new NotImplementedException();
        }

        public static ndarray tri(int N, int? M = null, int k = 0, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray triu_indices(int n, int k = 0, int? m = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray triu_indices_from(ndarray ndarray, int k = 0)
        {
            throw new NotImplementedException();
        }

        public static ndarray tril_indices(int n, int k = 0, int? m = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray triu(int n, int k = 0)
        {
            throw new NotImplementedException();
        }

        public static ndarray arange(int start, int? stop = null, int step = 1, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray[] split(ndarray ary, int[] indices_or_sections, int axis = 0)
        {
            throw new NotImplementedException();
        }

        public static ndarray[] array_split(ndarray ary, int[] indices_or_sections, int axis = 0)
        {
            throw new NotImplementedException();
        }

        public static ndarray vsplit(ndarray ary, int[] indices_or_sections)
        {
            throw new NotImplementedException();
        }

        public static ndarray dsplit(ndarray ary, int[] indices_or_sections)
        {
            throw new NotImplementedException();
        }

        public static ndarray concatenate(ndarray[] seq, int axis = 0, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray append(ndarray arr, ndarray values, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray stack(ndarray[] arrays, int axis = 0, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray vstack(ndarray[] arrays, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray row_stack(ndarray[] arrays)
        {
            throw new NotImplementedException();
        }

        public static ndarray column_stack(ndarray[] arrays)
        {
            throw new NotImplementedException();
        }

        public static ndarray hstack(ndarray[] arrays)
        {
            throw new NotImplementedException();
        }

        public static ndarray dstack(ndarray[] arrays)
        {
            throw new NotImplementedException();
        }

        public static ndarray maximum(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray fmax(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray minimum(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray fmin(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray max(ndarray a, int? axis = null, ndarray @out = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static ndarray min(ndarray a, int? axis = null, ndarray @out = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static ndarray swapaxes(ndarray a, int axis1, int axis2)
        {
            throw new NotImplementedException();
        }

        public static ndarray clip(ndarray a, float a_min, float a_max, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray argmax(ndarray a, int? axis = null, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray argmin(ndarray a, int? axis = null, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray amax(ndarray a, int? axis = null, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray amin(ndarray a, int? axis = null, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray average(ndarray a, int? axis = null, ndarray weights = null, bool returned = false, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray mean(ndarray a, int? axis = null, DType dtype = null, ndarray @out = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static ndarray std(ndarray a, int? axis = null, DType dtype = null, ndarray @out = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static ndarray delete(ndarray arr, int obj, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray delete(ndarray arr, int[] obj, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray delete(ndarray arr, ndarray obj, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray var(ndarray a, int? axis = null, DType dtype = null, ndarray @out = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static ndarray indices(Shape dimensions, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray copysign(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray ravel(ndarray x, string order = "x")
        {
            throw new NotImplementedException();
        }

        public static ndarray unravel_index(ndarray indices, Shape shape, string order = "x")
        {
            throw new NotImplementedException();
        }

        public static ndarray flatnonzero(ndarray x)
        {
            throw new NotImplementedException();
        }

        public static ndarray diag_indices_from(ndarray x)
        {
            throw new NotImplementedException();
        }

        public static ndarray hanning(int M, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray hamming(int M, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray blackman(int M, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray flip(ndarray m, int? axis = null, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray flipud(ndarray x)
        {
            throw new NotImplementedException();
        }

        public static ndarray fliplr(ndarray x)
        {
            throw new NotImplementedException();
        }

        public static ndarray around(ndarray x, int decimals = 0, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray round(ndarray x, int decimals = 0, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray round_(ndarray x, int decimals = 0, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray arctan2(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray hypot(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray bitwise_and(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray bitwise_xor(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray bitwise_or(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray ldexp(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray vdot(ndarray a, ndarray b)
        {
            throw new NotImplementedException();
        }

        public static ndarray inner(ndarray a, ndarray b)
        {
            throw new NotImplementedException();
        }

        public static ndarray outer(ndarray a, ndarray b)
        {
            throw new NotImplementedException();
        }

        public static ndarray cross(ndarray a, ndarray b, int axisa = -1, int axisb = -1, int axisc = -1, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray kron(ndarray a, ndarray b)
        {
            throw new NotImplementedException();
        }

        public static ndarray equal(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray equal(ndarray x1, float x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray equal(float x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray not_equal(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray not_equal(ndarray x1, float x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray not_equal(float x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray greater(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray greater(ndarray x1, float x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray greater(float x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray less(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray less(ndarray x1, float x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray less(float x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray logical_and(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray logical_or(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray logical_xor(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray greater_equal(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray greater_equal(ndarray x1, float x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray greater_equal(float x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray less_equal(ndarray x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray less_equal(ndarray x1, float x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray less_equal(float x1, ndarray x2, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray roll(ndarray a, int shift, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray roll(ndarray a, int[] shift, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray rot90(ndarray m, int k = 1, params int[] axes)
        {
            throw new NotImplementedException();
        }

        public static ndarray hsplit(ndarray ary, params int[] indices_or_sections)
        {
            throw new NotImplementedException();
        }

        public static ndarray einsum(string subscripts, ndarray[] operands, ndarray @out = null, bool optimize = false)
        {
            throw new NotImplementedException();
        }

        public static ndarray insert(ndarray arr, int obj, ndarray values, int? axis = null)
        {
            return _api_internal.insert_scalar(arr: arr, values: values, obj: obj, axis: axis);
        }

        public static ndarray insert(ndarray arr, Slice obj, ndarray values, int? axis = null)
        {
            return _api_internal.insert_slice(arr: arr, values: values, start: obj.Begin, stop: obj.End, step: obj.Step, axis: axis);
        }

        public static ndarray insert(ndarray arr, ndarray obj, ndarray values, int? axis = null)
        {
            return _api_internal.insert_tensor(arr: arr, obj: obj, values: values, axis: axis);
        }

        public static ndarray nonzero(ndarray a)
        {
            throw new NotImplementedException();
        }

        public static ndarray percentile(ndarray a, ndarray q, int? axis = null, ndarray @out = null, bool? overwrite_input = null, string interpolation = "linear", bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static ndarray median(ndarray a, int? axis = null, ndarray @out = null, bool? overwrite_input = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static ndarray quantile(ndarray a, ndarray q, int? axis = null, ndarray @out = null, bool? overwrite_input = null, string interpolation = "linear", bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static bool shares_memory(ndarray a, ndarray b, int? max_work = null)
        {
            throw new NotImplementedException();
        }

        public static bool may_share_memory(ndarray a, ndarray b, int? max_work = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray diff(ndarray a, int n = 1, int axis = -1, ndarray prepend = null, ndarray append = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray ediff1d(ndarray ary, ndarray to_end = null, ndarray to_begin = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray resize(ndarray a, Shape new_shape)
        {
            throw new NotImplementedException();
        }

        public static ndarray interp(ndarray x, float[] xp, float[] fp, float? left = null, float? right = null, float? period = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray full_like(ndarray a, double fill_value, DType dtype = null, string order = "C", Context ctx = null, ndarray @out = null)
        {
            @out = _api_internal.full_like(a: a, fill_value: fill_value, dtype: dtype, ctx: ctx);
            return @out;
        }

        public static ndarray zeros_like(ndarray a, DType dtype = null, string order = "C", Context ctx = null, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray ones_like(ndarray a, DType dtype = null, string order = "C", Context ctx = null, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray fill_diagonal(ndarray a, float val, bool wrap = false)
        {
            throw new NotImplementedException();
        }

        public static ndarray nan_to_num(ndarray x, bool copy = true, float nan = 0, float? posinf = null, float? neginf = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray squeeze(ndarray a, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray isnan(ndarray a, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray isinf(ndarray a, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray isposinf(ndarray a, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray isneginf(ndarray a, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray isfinite(ndarray a, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray where(ndarray condition, ndarray x = null, ndarray y = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray polyval(ndarray p, ndarray x)
        {
            throw new NotImplementedException();
        }

        public static ndarray bincount(ndarray x, ndarray weights = null, int minlength = 0)
        {
            throw new NotImplementedException();
        }

        public static ndarray atleast_1d(params ndarray[] arys)
        {
            throw new NotImplementedException();
        }

        public static ndarray atleast_2d(params ndarray[] arys)
        {
            throw new NotImplementedException();
        }

        public static ndarray atleast_3d(params ndarray[] arys)
        {
            throw new NotImplementedException();
        }

        public static ndarray pad(ndarray x, int[] pad_width = null, string mode = "constant")
        {
            throw new NotImplementedException();
        }

        public static ndarray prod(ndarray a, int? axis = null, DType dtype = null, ndarray @out = null, bool keepdims = false, float? initial = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray dot(ndarray a, ndarray b, ndarray @out = null)
        {
            @out = _api_internal.dot(a: a, b: b);
            return @out;
        }

        public static ndarray cumsum(ndarray a, int? axis = null, DType dtype = null, ndarray @out = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray reshape(ndarray a, Shape newshape, bool reverse = false, string order = "C")
        {
            throw new NotImplementedException();
        }

        public static ndarray moveaxis(ndarray a, int source, int destination)
        {
            throw new NotImplementedException();
        }

        public static ndarray moveaxis(ndarray a, int[] source, int[] destination)
        {
            throw new NotImplementedException();
        }

        public static ndarray copy(ndarray a)
        {
            throw new NotImplementedException();
        }

        public static ndarray rollaxis(ndarray a, int axis, int start = 0)
        {
            throw new NotImplementedException();
        }

        public static ndarray diag(ndarray v, int k = 0)
        {
            throw new NotImplementedException();
        }

        public static ndarray diagflat(ndarray v, int k = 0)
        {
            throw new NotImplementedException();
        }

        public static ndarray diagonal(ndarray a, int offset = 0, int axis1 = 0, int axis2 = 1)
        {
            throw new NotImplementedException();
        }

        public static ndarray sum(ndarray a, int? axis = null, DType dtype = null, ndarray @out = null, bool keepdims = false, float? initial = null)
        {
            throw new NotImplementedException();
        }

        public static ndarray meshgrid(ndarray[] xi, string indexing = "xy", bool sparse = false, bool copy = true)
        {
            throw new NotImplementedException();
        }
    }
}
