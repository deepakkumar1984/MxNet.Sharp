using MxNet.Numpy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Sym.Numpy
{
    internal class sym_np_ops
    {
        private static bool? _INT64_TENSOR_SIZE_ENABLED = null;

        internal static bool Int64Enabled()
        {
            //if (_INT64_TENSOR_SIZE_ENABLED == null)
            //{
            //    _INT64_TENSOR_SIZE_ENABLED = Runtime.FeatureList().IsEnabled("INT64_TENSOR_SIZE");
            //}

            //return _INT64_TENSOR_SIZE_ENABLED.Value;
            return true;
        }

        public static _Symbol empty(Shape shape, DType dtype = null, string order = "C", Context ctx = null)
        {
            if (shape == null) shape = new Shape();
            if (dtype == null) dtype = np.Float32;
            if (ctx == null) ctx = Context.CurrentContext;

            return new Operator("_npi_empty")
                            .SetParam("shape", shape)
                            .SetParam("ctx", ctx.ToString())
                            .SetParam("dtype", dtype)
                            .CreateNpSymbol();
        }

        public static _Symbol array(Array obj, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static Shape shape(_Symbol a)
        {
            throw new NotImplementedException();
        }

        public static _Symbol zeros(Shape shape, DType dtype = null, string order = "C", Context ctx = null)
        {
            if (shape == null) shape = new Shape();
            if (dtype == null) dtype = np.Float32;
            if (ctx == null) ctx = Context.CurrentContext;

            return new Operator("_npi_zeros")
                            .SetParam("shape", shape)
                            .SetParam("ctx", ctx.ToString())
                            .SetParam("dtype", dtype)
                            .CreateNpSymbol();
        }

        public static _Symbol ones(Shape shape, DType dtype = null, string order = "C", Context ctx = null)
        {
            if (shape == null) shape = new Shape();
            if (dtype == null) dtype = np.Float32;
            if (ctx == null) ctx = Context.CurrentContext;

            return new Operator("_npi_ones")
                    .SetParam("shape", shape)
                    .SetParam("ctx", ctx.ToString())
                    .SetParam("dtype", dtype)
                    .CreateNpSymbol();
        }

        public static _Symbol broadcast_to(_Symbol array, Shape shape)
        {
            throw new NotImplementedException();
        }

        public static _Symbol full(Shape shape, double fill_value, DType dtype = null, string order = "C", Context ctx = null, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol empty_like(_Symbol prototype, double fill_value, DType dtype = null, string order = "C", bool subok = false, Shape shape = null)
        {
            throw new NotImplementedException();
        }

        public static bool all(_Symbol a)
        {
            throw new NotImplementedException();
        }

        public static _Symbol all(_Symbol a, int axis, _Symbol @out = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static bool any(_Symbol a)
        {
            throw new NotImplementedException();
        }

        public static _Symbol any(_Symbol a, int axis, _Symbol @out = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static _Symbol identity(int n, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol take(_Symbol a, _Symbol indices, int? axis = null, string mode = "raise", _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol unique(_Symbol ar, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static (_Symbol, _Symbol, _Symbol, _Symbol) unique(_Symbol ar, bool return_index = false, bool return_inverse = false, bool return_counts = false, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol add(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol add(_Symbol x1, float x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol add(float x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol subtract(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol subtract(_Symbol x1, float x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol subtract(float x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol mutiply(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol mutiply(_Symbol x1, float x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol mutiply(float x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol divide(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol divide(_Symbol x1, float x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol divide(float x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol true_divide(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol true_divide(_Symbol x1, float x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol true_divide(float x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol mod(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol mod(_Symbol x1, float x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol mod(float x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol fmod(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol matmul(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol remainder(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol power(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol gcd(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol lcm(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol sin(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol cos(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol sinh(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol cosh(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol tanh(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol log10(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol sqrt(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol cbrt(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol abs(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol fabs(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol absolute(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol exp(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol expm1(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol arcsin(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol arccos(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol arctan(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol sign(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol log(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol rint(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol log2(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol log1p(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol degrees(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol rad2deg(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol radians(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol deg2rad(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol reciprocal(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol square(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol negative(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol fix(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol tan(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol ceil(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol floor(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol invert(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol bitwise_not(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol trunc(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol logical_not(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol arcsinh(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol arccosh(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol arctanh(_Symbol x, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol argsort(_Symbol x, int axis = -1, string kind = null, string order = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol sort(_Symbol x, int axis = -1, string kind = null, string order = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol tensordot(_Symbol a, _Symbol b, int axes = 2)
        {
            throw new NotImplementedException();
        }

        public static _Symbol histogram(_Symbol a, int bins = 10, (float, float)? range = null, bool? normed = null, _Symbol weights = null, bool? density = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol histogram(_Symbol a, _Symbol bins, (float, float)? range = null, bool? normed = null, _Symbol weights = null, bool? density = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol eye(int N, int? M = null, int k = 0, DType dtype = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol linspace(float start, float stop, int num = 50, bool endpoint = true, bool retstep = false, DType dtype = null, int axis = 0, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol logspace(float start, float stop, int num = 50, bool endpoint = true, bool retstep = false, DType dtype = null, int axis = 0, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol expand_dims(_Symbol a, int axis)
        {
            throw new NotImplementedException();
        }

        public static _Symbol tile(_Symbol a, params int[] reps)
        {
            throw new NotImplementedException();
        }

        public static _Symbol trace(_Symbol a, int offset = 0, int axis1 = 0, int axis2 = 1, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol transpose(_Symbol a, params int[] axes)
        {
            throw new NotImplementedException();
        }

        public static _Symbol repeat(_Symbol a, int repeats, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol tril(_Symbol m, int k = 0)
        {
            throw new NotImplementedException();
        }

        public static _Symbol tri(int N, int? M = null, int k = 0, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol triu_indices(int n, int k = 0, int? m = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol triu_indices_from(_Symbol _Symbol, int k = 0)
        {
            throw new NotImplementedException();
        }

        public static _Symbol tril_indices(int n, int k = 0, int? m = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol triu(int n, int k = 0)
        {
            throw new NotImplementedException();
        }

        public static _Symbol arange(int start, int? stop = null, int step = 1, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol[] split(_Symbol ary, int[] indices_or_sections, int axis = 0)
        {
            throw new NotImplementedException();
        }

        public static _Symbol[] array_split(_Symbol ary, int[] indices_or_sections, int axis = 0)
        {
            throw new NotImplementedException();
        }

        public static _Symbol vsplit(_Symbol ary, int[] indices_or_sections)
        {
            throw new NotImplementedException();
        }

        public static _Symbol dsplit(_Symbol ary, int[] indices_or_sections)
        {
            throw new NotImplementedException();
        }

        public static _Symbol concatenate(_Symbol[] seq, int axis = 0, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol append(_Symbol arr, _Symbol values, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol stack(_Symbol[] arrays, int axis = 0, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol vstack(_Symbol[] arrays, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol row_stack(_Symbol[] arrays)
        {
            throw new NotImplementedException();
        }

        public static _Symbol column_stack(_Symbol[] arrays)
        {
            throw new NotImplementedException();
        }

        public static _Symbol hstack(_Symbol[] arrays)
        {
            throw new NotImplementedException();
        }

        public static _Symbol dstack(_Symbol[] arrays)
        {
            throw new NotImplementedException();
        }

        public static _Symbol maximum(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol fmax(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol minimum(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol fmin(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol max(_Symbol a, int? axis = null, _Symbol @out = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static _Symbol min(_Symbol a, int? axis = null, _Symbol @out = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static _Symbol swapaxes(_Symbol a, int axis1, int axis2)
        {
            throw new NotImplementedException();
        }

        public static _Symbol clip(_Symbol a, float a_min, float a_max, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol argmax(_Symbol a, int? axis = null, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol argmin(_Symbol a, int? axis = null, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol amax(_Symbol a, int? axis = null, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol amin(_Symbol a, int? axis = null, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol average(_Symbol a, int? axis = null, _Symbol weights = null, bool returned = false, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol mean(_Symbol a, int? axis = null, DType dtype = null, _Symbol @out = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static _Symbol std(_Symbol a, int? axis = null, DType dtype = null, _Symbol @out = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static _Symbol delete(_Symbol arr, int obj, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol delete(_Symbol arr, int[] obj, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol delete(_Symbol arr, _Symbol obj, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol var(_Symbol a, int? axis = null, DType dtype = null, _Symbol @out = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static _Symbol indices(Shape dimensions, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol copysign(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol ravel(_Symbol x, string order = "x")
        {
            throw new NotImplementedException();
        }

        public static _Symbol unravel_index(_Symbol indices, Shape shape, string order = "x")
        {
            throw new NotImplementedException();
        }

        public static _Symbol flatnonzero(_Symbol x)
        {
            throw new NotImplementedException();
        }

        public static _Symbol diag_indices_from(_Symbol x)
        {
            throw new NotImplementedException();
        }

        public static _Symbol hanning(int M, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol hamming(int M, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol blackman(int M, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol flip(_Symbol m, int? axis = null, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol flipud(_Symbol x)
        {
            throw new NotImplementedException();
        }

        public static _Symbol fliplr(_Symbol x)
        {
            throw new NotImplementedException();
        }

        public static _Symbol around(_Symbol x, int decimals = 0, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol round(_Symbol x, int decimals = 0, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol round_(_Symbol x, int decimals = 0, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol arctan2(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol hypot(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol bitwise_and(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol bitwise_xor(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol bitwise_or(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol ldexp(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol vdot(_Symbol a, _Symbol b)
        {
            throw new NotImplementedException();
        }

        public static _Symbol inner(_Symbol a, _Symbol b)
        {
            throw new NotImplementedException();
        }

        public static _Symbol outer(_Symbol a, _Symbol b)
        {
            throw new NotImplementedException();
        }

        public static _Symbol cross(_Symbol a, _Symbol b, int axisa = -1, int axisb = -1, int axisc = -1, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol kron(_Symbol a, _Symbol b)
        {
            throw new NotImplementedException();
        }

        public static _Symbol equal(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol equal(_Symbol x1, float x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol equal(float x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol not_equal(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol not_equal(_Symbol x1, float x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol not_equal(float x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol greater(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol greater(_Symbol x1, float x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol greater(float x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol less(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol less(_Symbol x1, float x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol less(float x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol logical_or(_Symbol x1, _Symbol x2, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol logical_xor(_Symbol x1, _Symbol x2, _Symbol @out = null)
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

        public static _Symbol roll(_Symbol a, int shift, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol roll(_Symbol a, int[] shift, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol rot90(_Symbol m, int k = 1, params int[] axes)
        {
            throw new NotImplementedException();
        }

        public static _Symbol hsplit(_Symbol ary, params int[] indices_or_sections)
        {
            throw new NotImplementedException();
        }

        public static _Symbol einsum(string subscripts, _Symbol[] operands, _Symbol @out = null, bool optimize = false)
        {
            throw new NotImplementedException();
        }

        public static _Symbol insert(_Symbol arr, int obj, _Symbol values, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol insert(_Symbol arr, _Symbol obj, _Symbol values, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol nonzero(_Symbol a)
        {
            throw new NotImplementedException();
        }

        public static _Symbol percentile(_Symbol a, _Symbol q, int? axis = null, _Symbol @out = null, bool? overwrite_input = null, string interpolation = "linear", bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static _Symbol median(_Symbol a, int? axis = null, _Symbol @out = null, bool? overwrite_input = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static _Symbol quantile(_Symbol a, _Symbol q, int? axis = null, _Symbol @out = null, bool? overwrite_input = null, string interpolation = "linear", bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static bool shares_memory(_Symbol a, _Symbol b, int? max_work = null)
        {
            throw new NotImplementedException();
        }

        public static bool may_share_memory(_Symbol a, _Symbol b, int? max_work = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol diff(_Symbol a, int n = 1, int axis = -1, _Symbol prepend = null, _Symbol append = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol ediff1d(_Symbol ary, _Symbol to_end = null, _Symbol to_begin = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol resize(_Symbol a, Shape new_shape)
        {
            throw new NotImplementedException();
        }

        public static _Symbol interp(_Symbol x, float[] xp, float[] fp, float? left = null, float? right = null, float? period = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol full_like(_Symbol a, float fill_value, DType dtype = null, string order = "C", Context ctx = null, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol zeros_like(_Symbol a, DType dtype = null, string order = "C", Context ctx = null, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol ones_like(_Symbol a, DType dtype = null, string order = "C", Context ctx = null, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol fill_diagonal(_Symbol a, float val, bool wrap = false)
        {
            throw new NotImplementedException();
        }

        public static _Symbol nan_to_num(_Symbol x, bool copy = true, float nan = 0, float? posinf = null, float? neginf = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol squeeze(_Symbol a, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol isnan(_Symbol a, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol isinf(_Symbol a, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol isposinf(_Symbol a, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol isneginf(_Symbol a, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol isfinite(_Symbol a, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol where(_Symbol condition, _Symbol x = null, _Symbol y = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol polyval(_Symbol p, _Symbol x)
        {
            throw new NotImplementedException();
        }

        public static _Symbol bincount(_Symbol x, _Symbol weights = null, int minlength = 0)
        {
            throw new NotImplementedException();
        }

        public static _Symbol atleast_1d(params _Symbol[] arys)
        {
            throw new NotImplementedException();
        }

        public static _Symbol atleast_2d(params _Symbol[] arys)
        {
            throw new NotImplementedException();
        }

        public static _Symbol atleast_3d(params _Symbol[] arys)
        {
            throw new NotImplementedException();
        }

        public static _Symbol pad(_Symbol x, int[] pad_width = null, string mode = "constant")
        {
            throw new NotImplementedException();
        }

        public static _Symbol prod(_Symbol a, int? axis = null, DType dtype = null, _Symbol @out = null, bool keepdims = false, float? initial = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol dot(_Symbol a, _Symbol b, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol cumsum(_Symbol a, int? axis = null, DType dtype = null, _Symbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol reshape(_Symbol a, Shape newshape, bool reverse = false, string order = "C")
        {
            throw new NotImplementedException();
        }

        public static _Symbol moveaxis(_Symbol a, int source, int destination)
        {
            throw new NotImplementedException();
        }

        public static _Symbol moveaxis(_Symbol a, int[] source, int[] destination)
        {
            throw new NotImplementedException();
        }

        public static _Symbol copy(_Symbol a)
        {
            throw new NotImplementedException();
        }

        public static _Symbol rollaxis(_Symbol a, int axis, int start = 0)
        {
            throw new NotImplementedException();
        }

        public static _Symbol diag(_Symbol v, int k = 0)
        {
            throw new NotImplementedException();
        }

        public static _Symbol diagflat(_Symbol v, int k = 0)
        {
            throw new NotImplementedException();
        }

        public static _Symbol diagonal(_Symbol a, int offset = 0, int axis1 = 0, int axis2 = 1)
        {
            throw new NotImplementedException();
        }

        public static _Symbol sum(_Symbol a, int? axis = null, DType dtype = null, _Symbol @out = null, bool keepdims = false, float? initial = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol meshgrid(_Symbol[] xi, string indexing = "xy", bool sparse = false, bool copy = true)
        {
            throw new NotImplementedException();
        }
    }
}
