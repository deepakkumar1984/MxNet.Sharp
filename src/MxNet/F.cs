using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet
{
    public class F
    {
        public static NDArrayOrSymbol zeros(Shape shape, DType dtype = null, string order = "C", Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol ones(Shape shape, DType dtype = null, string order = "C", Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol broadcast_to(NDArrayOrSymbol array, Shape shape)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol full(Shape shape, double fill_value, DType dtype = null, string order = "C", Context ctx = null, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol empty_like(NDArrayOrSymbol prototype, double fill_value, DType dtype = null, string order = "C", bool subok = false, Shape shape = null)
        {
            throw new NotImplementedException();
        }

        public static bool all(NDArrayOrSymbol a)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol all(NDArrayOrSymbol a, int axis, NDArrayOrSymbol @out = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static bool any(NDArrayOrSymbol a)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol any(NDArrayOrSymbol a, int axis, NDArrayOrSymbol @out = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol identity(int n, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol take(NDArrayOrSymbol a, NDArrayOrSymbol indices, int? axis = null, string mode = "raise", NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol unique(NDArrayOrSymbol ar, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static (NDArrayOrSymbol, NDArrayOrSymbol, NDArrayOrSymbol, NDArrayOrSymbol) unique(NDArrayOrSymbol ar, bool return_index = false, bool return_inverse = false, bool return_counts = false, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol add(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol subtract(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol multiply(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol divide(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol true_divide(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol mod(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol fmod(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol matmul(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol remainder(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol power(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol gcd(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol lcm(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol sin(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol cos(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol sinh(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol cosh(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol tanh(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol log10(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol sqrt(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol cbrt(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol abs(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol fabs(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol absolute(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol exp(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol expm1(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol arcsin(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol arccos(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol arctan(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol sign(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol log(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol rint(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol log2(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol log1p(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol degrees(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol rad2deg(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol radians(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol deg2rad(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol reciprocal(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol square(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol negative(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol fix(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol tan(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol ceil(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol floor(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol invert(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol bitwise_not(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol trunc(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol logical_not(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol arcsinh(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol arccosh(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol arctanh(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol argsort(NDArrayOrSymbol x, int axis = -1, string kind = null, string order = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol sort(NDArrayOrSymbol x, int axis = -1, string kind = null, string order = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol tensordot(NDArrayOrSymbol a, NDArrayOrSymbol b, int axes = 2)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol histogram(NDArrayOrSymbol a, int bins = 10, (float, float)? range = null, bool? normed = null, NDArrayOrSymbol weights = null, bool? density = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol histogram(NDArrayOrSymbol a, NDArrayOrSymbol bins, (float, float)? range = null, bool? normed = null, NDArrayOrSymbol weights = null, bool? density = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol eye(int N, int? M = null, int k = 0, DType dtype = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol linspace(float start, float stop, int num = 50, bool endpoint = true, bool retstep = false, DType dtype = null, int axis = 0, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol logspace(float start, float stop, int num = 50, bool endpoint = true, bool retstep = false, DType dtype = null, int axis = 0, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol expand_dims(NDArrayOrSymbol a, int axis)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol tile(NDArrayOrSymbol a, params int[] reps)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol trace(NDArrayOrSymbol a, int offset = 0, int axis1 = 0, int axis2 = 1, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol transpose(NDArrayOrSymbol a, params int[] axes)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol repeat(NDArrayOrSymbol a, int repeats, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol tril(NDArrayOrSymbol m, int k = 0)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol tri(int N, int? M = null, int k = 0, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol triu_indices(int n, int k = 0, int? m = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol triu_indices_from(NDArrayOrSymbol NDArrayOrSymbol, int k = 0)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol tril_indices(int n, int k = 0, int? m = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol triu(int n, int k = 0)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol arange(int start, int? stop = null, int step = 1, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol[] split(NDArrayOrSymbol ary, int[] indices_or_sections, int axis = 0)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol[] array_split(NDArrayOrSymbol ary, int[] indices_or_sections, int axis = 0)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol vsplit(NDArrayOrSymbol ary, int[] indices_or_sections)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol dsplit(NDArrayOrSymbol ary, int[] indices_or_sections)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol concatenate(NDArrayOrSymbol[] seq, int axis = 0, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol append(NDArrayOrSymbol arr, NDArrayOrSymbol values, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol stack(NDArrayOrSymbol[] arrays, int axis = 0, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol vstack(NDArrayOrSymbol[] arrays, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol row_stack(NDArrayOrSymbol[] arrays)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol column_stack(NDArrayOrSymbol[] arrays)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol hstack(NDArrayOrSymbol[] arrays)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol dstack(NDArrayOrSymbol[] arrays)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol maximum(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol fmax(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol minimum(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol fmin(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol max(NDArrayOrSymbol a, int? axis = null, NDArrayOrSymbol @out = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol min(NDArrayOrSymbol a, int? axis = null, NDArrayOrSymbol @out = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol swapaxes(NDArrayOrSymbol a, int axis1, int axis2)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol clip(NDArrayOrSymbol a, float a_min, float a_max, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol argmax(NDArrayOrSymbol a, int? axis = null, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol argmin(NDArrayOrSymbol a, int? axis = null, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol amax(NDArrayOrSymbol a, int? axis = null, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol amin(NDArrayOrSymbol a, int? axis = null, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol average(NDArrayOrSymbol a, int? axis = null, NDArrayOrSymbol weights = null, bool returned = false, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol mean(NDArrayOrSymbol a, int? axis = null, DType dtype = null, NDArrayOrSymbol @out = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol std(NDArrayOrSymbol a, int? axis = null, DType dtype = null, NDArrayOrSymbol @out = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol delete(NDArrayOrSymbol arr, int obj, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol delete(NDArrayOrSymbol arr, int[] obj, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol delete(NDArrayOrSymbol arr, NDArrayOrSymbol obj, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol var(NDArrayOrSymbol a, int? axis = null, DType dtype = null, NDArrayOrSymbol @out = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol indices(Shape dimensions, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol copysign(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol ravel(NDArrayOrSymbol x, string order = "x")
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol unravel_index(NDArrayOrSymbol indices, Shape shape, string order = "x")
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol flatnonzero(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol diag_indices_from(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol hanning(int M, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol hamming(int M, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol blackman(int M, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol flip(NDArrayOrSymbol m, int? axis = null, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol flipud(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol fliplr(NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol around(NDArrayOrSymbol x, int decimals = 0, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol round(NDArrayOrSymbol x, int decimals = 0, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol round_(NDArrayOrSymbol x, int decimals = 0, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol arctan2(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol hypot(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol bitwise_and(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol bitwise_xor(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol bitwise_or(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol ldexp(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol vdot(NDArrayOrSymbol a, NDArrayOrSymbol b)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol inner(NDArrayOrSymbol a, NDArrayOrSymbol b)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol outer(NDArrayOrSymbol a, NDArrayOrSymbol b)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol cross(NDArrayOrSymbol a, NDArrayOrSymbol b, int axisa = -1, int axisb = -1, int axisc = -1, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol kron(NDArrayOrSymbol a, NDArrayOrSymbol b)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol equal(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol not_equal(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol greater(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol less(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol logical_and(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }


        public static NDArrayOrSymbol logical_or(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol logical_xor(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol greater_equal(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol less_equal(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol roll(NDArrayOrSymbol a, int shift, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol roll(NDArrayOrSymbol a, int[] shift, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol rot90(NDArrayOrSymbol m, int k = 1, params int[] axes)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol hsplit(NDArrayOrSymbol ary, params int[] indices_or_sections)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol einsum(string subscripts, NDArrayOrSymbol[] operands, NDArrayOrSymbol @out = null, bool optimize = false)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol insert(NDArrayOrSymbol arr, int obj, NDArrayOrSymbol values, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol insert(NDArrayOrSymbol arr, NDArrayOrSymbol obj, NDArrayOrSymbol values, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol nonzero(NDArrayOrSymbol a)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol percentile(NDArrayOrSymbol a, NDArrayOrSymbol q, int? axis = null, NDArrayOrSymbol @out = null, bool? overwrite_input = null, string interpolation = "linear", bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol median(NDArrayOrSymbol a, int? axis = null, NDArrayOrSymbol @out = null, bool? overwrite_input = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol quantile(NDArrayOrSymbol a, NDArrayOrSymbol q, int? axis = null, NDArrayOrSymbol @out = null, bool? overwrite_input = null, string interpolation = "linear", bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static bool shares_memory(NDArrayOrSymbol a, NDArrayOrSymbol b, int? max_work = null)
        {
            throw new NotImplementedException();
        }

        public static bool may_share_memory(NDArrayOrSymbol a, NDArrayOrSymbol b, int? max_work = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol diff(NDArrayOrSymbol a, int n = 1, int axis = -1, NDArrayOrSymbol prepend = null, NDArrayOrSymbol append = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol ediff1d(NDArrayOrSymbol ary, NDArrayOrSymbol to_end = null, NDArrayOrSymbol to_begin = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol resize(NDArrayOrSymbol a, Shape new_shape)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol interp(NDArrayOrSymbol x, float[] xp, float[] fp, float? left = null, float? right = null, float? period = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol full_like(NDArrayOrSymbol a, float fill_value, DType dtype = null, string order = "C", Context ctx = null, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol zeros_like(NDArrayOrSymbol a, DType dtype = null, string order = "C", Context ctx = null, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol ones_like(NDArrayOrSymbol a, DType dtype = null, string order = "C", Context ctx = null, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol fill_diagonal(NDArrayOrSymbol a, float val, bool wrap = false)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol nan_to_num(NDArrayOrSymbol x, bool copy = true, float nan = 0, float? posinf = null, float? neginf = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol squeeze(NDArrayOrSymbol a, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol isnan(NDArrayOrSymbol a, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol isinf(NDArrayOrSymbol a, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol isposinf(NDArrayOrSymbol a, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol isneginf(NDArrayOrSymbol a, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol isfinite(NDArrayOrSymbol a, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol where(NDArrayOrSymbol condition, NDArrayOrSymbol x = null, NDArrayOrSymbol y = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol polyval(NDArrayOrSymbol p, NDArrayOrSymbol x)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol bincount(NDArrayOrSymbol x, NDArrayOrSymbol weights = null, int minlength = 0)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol atleast_1d(params NDArrayOrSymbol[] arys)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol atleast_2d(params NDArrayOrSymbol[] arys)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol atleast_3d(params NDArrayOrSymbol[] arys)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol pad(NDArrayOrSymbol x, int[] pad_width = null, string mode = "constant")
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol prod(NDArrayOrSymbol a, int? axis = null, DType dtype = null, NDArrayOrSymbol @out = null, bool keepdims = false, float? initial = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol dot(NDArrayOrSymbol a, NDArrayOrSymbol b, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol cumsum(NDArrayOrSymbol a, int? axis = null, DType dtype = null, NDArrayOrSymbol @out = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol reshape(NDArrayOrSymbol a, Shape newshape, bool reverse = false, string order = "C")
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol moveaxis(NDArrayOrSymbol a, int source, int destination)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol moveaxis(NDArrayOrSymbol a, int[] source, int[] destination)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol copy(NDArrayOrSymbol a)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol rollaxis(NDArrayOrSymbol a, int axis, int start = 0)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol diag(NDArrayOrSymbol v, int k = 0)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol diagflat(NDArrayOrSymbol v, int k = 0)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol diagonal(NDArrayOrSymbol a, int offset = 0, int axis1 = 0, int axis2 = 1)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol sum(NDArrayOrSymbol a, int? axis = null, DType dtype = null, NDArrayOrSymbol @out = null, bool keepdims = false, float? initial = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol meshgrid(NDArrayOrSymbol[] xi, string indexing = "xy", bool sparse = false, bool copy = true)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol relu(NDArrayOrSymbol data)
        {
            return activation(data);
        }

        public static NDArrayOrSymbol sigmoid(NDArrayOrSymbol data)
        {
            return activation(data, "sigmoid");
        }

        public static NDArrayOrSymbol activation(NDArrayOrSymbol data, string act_type = "relu")
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol batch_norm(NDArrayOrSymbol x, NDArrayOrSymbol gamma, NDArrayOrSymbol beta, NDArrayOrSymbol running_mean,
                                        NDArrayOrSymbol running_var, float eps = 0.001f, float momentum = 0.9f, bool fix_gamma = true,
                                        bool use_global_stats = false, bool output_mean_var = false, int axis = 1, bool cudnn_off = false,
                                        float? min_calib_range = null, float? max_calib_range = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol convolution(NDArrayOrSymbol data, NDArrayOrSymbol weight, NDArrayOrSymbol bias = null, int[] kernel = null,
                                        int[] stride = null, int[] dilate = null, int[] pad = null, int num_filter = 1, int num_group = 1,
                                        int workspace = 1024, bool no_bias = false, string cudnn_tune = null, bool cudnn_off = false, string layout = null)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol dropout(NDArrayOrSymbol data, float p = 0.5f, string mode = "training", Shape axes = null, bool cudnn_off = true)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol embedding(NDArrayOrSymbol data, NDArrayOrSymbol weight, int input_dim, int output_dim, DType dtype = null, bool sparse_grad = false)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol fully_connected(NDArrayOrSymbol x, NDArrayOrSymbol weight, NDArrayOrSymbol bias, int num_hidden, bool no_bias = true, bool flatten = true)
        {
            throw new NotImplementedException();
        }

        public static NDArrayOrSymbol layer_norm(NDArrayOrSymbol data, NDArrayOrSymbol gamma, NDArrayOrSymbol beta, int axis = -1, float eps = 9.99999975e-06f, bool output_mean_var = false)
        {
            throw new NotImplementedException();
        }
    }
}
