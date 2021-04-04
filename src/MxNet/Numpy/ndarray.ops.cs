using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Numpy
{
    public partial class ndarray
    {
        public ndarray broadcast_to(Shape shape)
        {
            throw new NotImplementedException();
        }

        public ndarray empty_like(double fill_value, DType dtype = null, string order = "C", bool subok = false, Shape shape = null)
        {
            throw new NotImplementedException();
        }

        public bool all()
        {
            throw new NotImplementedException();
        }

        public ndarray all(int axis, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public bool any()
        {
            throw new NotImplementedException();
        }

        public ndarray any(int axis, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public ndarray identity(int n, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public ndarray take(int? axis = null, string mode = "raise")
        {
            throw new NotImplementedException();
        }

        public ndarray unique(int? axis = null)
        {
            throw new NotImplementedException();
        }

        public (ndarray, ndarray, ndarray, ndarray) unique(bool return_index = false, bool return_inverse = false, bool return_counts = false, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public ndarray mod()
        {
            throw new NotImplementedException();
        }

        public ndarray fmod()
        {
            throw new NotImplementedException();
        }

        public ndarray matmul(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray remainder(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray power(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray power(float x)
        {
            throw new NotImplementedException();
        }

        public ndarray gcd(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray lcm(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray sin()
        {
            throw new NotImplementedException();
        }

        public ndarray cos()
        {
            throw new NotImplementedException();
        }

        public ndarray sinh()
        {
            throw new NotImplementedException();
        }

        public ndarray cosh()
        {
            throw new NotImplementedException();
        }

        public ndarray tanh()
        {
            throw new NotImplementedException();
        }

        public ndarray log10()
        {
            throw new NotImplementedException();
        }

        public ndarray sqrt()
        {
            throw new NotImplementedException();
        }

        public ndarray cbrt()
        {
            throw new NotImplementedException();
        }

        public ndarray abs()
        {
            throw new NotImplementedException();
        }

        public ndarray fabs()
        {
            throw new NotImplementedException();
        }

        public ndarray absolute()
        {
            throw new NotImplementedException();
        }

        public ndarray exp()
        {
            throw new NotImplementedException();
        }

        public ndarray expm1()
        {
            throw new NotImplementedException();
        }

        public ndarray arcsin()
        {
            throw new NotImplementedException();
        }

        public ndarray arccos()
        {
            throw new NotImplementedException();
        }

        public ndarray arctan()
        {
            throw new NotImplementedException();
        }

        public ndarray sign()
        {
            throw new NotImplementedException();
        }

        public ndarray log()
        {
            throw new NotImplementedException();
        }

        public ndarray rint()
        {
            throw new NotImplementedException();
        }

        public ndarray log2()
        {
            throw new NotImplementedException();
        }

        public ndarray log1p()
        {
            throw new NotImplementedException();
        }

        public ndarray degrees()
        {
            throw new NotImplementedException();
        }

        public ndarray rad2deg()
        {
            throw new NotImplementedException();
        }

        public ndarray radians()
        {
            throw new NotImplementedException();
        }

        public ndarray deg2rad()
        {
            throw new NotImplementedException();
        }

        public ndarray reciprocal()
        {
            throw new NotImplementedException();
        }

        public ndarray square()
        {
            throw new NotImplementedException();
        }

        public ndarray negative()
        {
            throw new NotImplementedException();
        }

        public ndarray fix()
        {
            throw new NotImplementedException();
        }

        public ndarray tan()
        {
            throw new NotImplementedException();
        }

        public ndarray ceil()
        {
            throw new NotImplementedException();
        }

        public ndarray floor()
        {
            throw new NotImplementedException();
        }

        public ndarray invert()
        {
            throw new NotImplementedException();
        }

        public ndarray bitwise_not()
        {
            throw new NotImplementedException();
        }

        public ndarray trunc()
        {
            throw new NotImplementedException();
        }

        public ndarray logical_not()
        {
            throw new NotImplementedException();
        }

        public ndarray arcsinh()
        {
            throw new NotImplementedException();
        }

        public ndarray arccosh()
        {
            throw new NotImplementedException();
        }

        public ndarray arctanh()
        {
            throw new NotImplementedException();
        }

        public ndarray argsort(int axis = -1, string kind = null, string order = null)
        {
            throw new NotImplementedException();
        }

        public ndarray sort(int axis = -1, string kind = null, string order = null)
        {
            throw new NotImplementedException();
        }

        public ndarray tensordot(ndarray b, int axes = 2)
        {
            throw new NotImplementedException();
        }

        public ndarray histogram(int bins = 10, (float, float)? range = null, bool? normed = null, ndarray weights = null, bool? density = null)
        {
            throw new NotImplementedException();
        }

        public ndarray histogram(ndarray bins, (float, float)? range = null, bool? normed = null, ndarray weights = null, bool? density = null)
        {
            throw new NotImplementedException();
        }

        public ndarray eye(int N, int? M = null, int k = 0, DType dtype = null)
        {
            throw new NotImplementedException();
        }

        public ndarray linspace(float start, float stop, int num = 50, bool endpoint = true, bool retstep = false, DType dtype = null, int axis = 0, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public ndarray logspace(float start, float stop, int num = 50, bool endpoint = true, bool retstep = false, DType dtype = null, int axis = 0, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public ndarray expand_dims(int axis)
        {
            throw new NotImplementedException();
        }

        public ndarray tile(params int[] reps)
        {
            throw new NotImplementedException();
        }

        public ndarray trace(int offset = 0, int axis1 = 0, int axis2 = 1)
        {
            throw new NotImplementedException();
        }

        public ndarray transpose(params int[] axes)
        {
            throw new NotImplementedException();
        }

        public ndarray repeat(int repeats, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public ndarray tril(ndarray m, int k = 0)
        {
            throw new NotImplementedException();
        }

        public ndarray tri(int N, int? M = null, int k = 0, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public ndarray triu_indices(int n, int k = 0, int? m = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public ndarray triu_indices_from(ndarray ndarray, int k = 0)
        {
            throw new NotImplementedException();
        }

        public ndarray tril_indices(int n, int k = 0, int? m = null)
        {
            throw new NotImplementedException();
        }

        public ndarray triu(int n, int k = 0)
        {
            throw new NotImplementedException();
        }

        public ndarray arange(int start, int? stop = null, int step = 1, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public ndarray[] split(int[] indices_or_sections, int axis = 0)
        {
            throw new NotImplementedException();
        }

        public ndarray[] array_split(int[] indices_or_sections, int axis = 0)
        {
            throw new NotImplementedException();
        }

        public ndarray vsplit(int[] indices_or_sections)
        {
            throw new NotImplementedException();
        }

        public ndarray dsplit(int[] indices_or_sections)
        {
            throw new NotImplementedException();
        }

        public ndarray append(ndarray values, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public ndarray maximum(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray fmax(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray minimum(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray fmin(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray max(int? axis = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public ndarray min(int? axis = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public ndarray swapaxes(int axis1, int axis2)
        {
            throw new NotImplementedException();
        }

        public ndarray clip(float a_min, float a_max)
        {
            throw new NotImplementedException();
        }

        public ndarray argmax(int? axis = null)
        {
            throw new NotImplementedException();
        }

        public ndarray argmin(int? axis = null)
        {
            throw new NotImplementedException();
        }

        public ndarray amax(int? axis = null)
        {
            throw new NotImplementedException();
        }

        public ndarray amin(int? axis = null)
        {
            throw new NotImplementedException();
        }

        public ndarray average(int? axis = null, ndarray weights = null, bool returned = false)
        {
            throw new NotImplementedException();
        }

        public ndarray mean(int? axis = null, DType dtype = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public ndarray std(int? axis = null, DType dtype = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }
        public ndarray var(int? axis = null, DType dtype = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public ndarray indices(Shape dimensions, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public ndarray copysign(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray ravel(string order = "x")
        {
            throw new NotImplementedException();
        }

        public ndarray flatnonzero()
        {
            throw new NotImplementedException();
        }

        public ndarray diag_indices_from()
        {
            throw new NotImplementedException();
        }

        public ndarray hanning(int M, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public ndarray hamming(int M, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public ndarray blackman(int M, DType dtype = null, Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public ndarray flip(int? axis = null)
        {
            throw new NotImplementedException();
        }

        public ndarray flipud()
        {
            throw new NotImplementedException();
        }

        public ndarray fliplr()
        {
            throw new NotImplementedException();
        }

        public ndarray around(int decimals = 0)
        {
            throw new NotImplementedException();
        }

        public ndarray round(int decimals = 0)
        {
            throw new NotImplementedException();
        }

        public ndarray round_(int decimals = 0)
        {
            throw new NotImplementedException();
        }

        public ndarray arctan2(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray hypot(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray bitwise_and(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray bitwise_xor(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray bitwise_or(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray ldexp(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray vdot(ndarray b)
        {
            throw new NotImplementedException();
        }

        public ndarray inner(ndarray b)
        {
            throw new NotImplementedException();
        }

        public ndarray outer(ndarray b)
        {
            throw new NotImplementedException();
        }

        public ndarray cross(ndarray b, int axisa = -1, int axisb = -1, int axisc = -1, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public ndarray kron(ndarray b)
        {
            throw new NotImplementedException();
        }

        public ndarray equal(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray not_equal(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray greater(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray less(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray logical_and(ndarray x)
        {
            throw new NotImplementedException();
        }


        public ndarray logical_or(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray logical_xor(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray greater_equal(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray less_equal(ndarray x)
        {
            throw new NotImplementedException();
        }

        public ndarray roll(int shift, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public ndarray roll(int[] shift, int? axis = null)
        {
            throw new NotImplementedException();
        }

        public ndarray rot90(int k = 1, params int[] axes)
        {
            throw new NotImplementedException();
        }

        public ndarray hsplit(params int[] indices_or_sections)
        {
            throw new NotImplementedException();
        }

        public ndarray einsum(string subscripts, ndarray[] operands, bool optimize = false)
        {
            throw new NotImplementedException();
        }

        public ndarray nonzero(ndarray a)
        {
            throw new NotImplementedException();
        }

        public ndarray median(int? axis = null, bool? overwrite_input = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public bool shares_memory(ndarray b, int? max_work = null)
        {
            throw new NotImplementedException();
        }

        public bool may_share_memory(ndarray b, int? max_work = null)
        {
            throw new NotImplementedException();
        }

        public ndarray diff(int n = 1, int axis = -1, ndarray prepend = null, ndarray append = null)
        {
            throw new NotImplementedException();
        }

        public ndarray ediff1d(ndarray to_end = null, ndarray to_begin = null)
        {
            throw new NotImplementedException();
        }

        public ndarray resize(Shape new_shape)
        {
            throw new NotImplementedException();
        }

        public ndarray interp(float[] xp, float[] fp, float? left = null, float? right = null, float? period = null)
        {
            throw new NotImplementedException();
        }

        public ndarray full_like(float fill_value, DType dtype = null, string order = "C", Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public ndarray zeros_like(DType dtype = null, string order = "C", Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public ndarray ones_like(DType dtype = null, string order = "C", Context ctx = null)
        {
            throw new NotImplementedException();
        }

        public ndarray fill_diagonal(float val, bool wrap = false)
        {
            throw new NotImplementedException();
        }

        public ndarray nan_to_num(bool copy = true, float nan = 0, float? posinf = null, float? neginf = null)
        {
            throw new NotImplementedException();
        }

        public ndarray squeeze(int? axis = null)
        {
            throw new NotImplementedException();
        }

        public ndarray isnan()
        {
            throw new NotImplementedException();
        }

        public ndarray isinf()
        {
            throw new NotImplementedException();
        }

        public ndarray isposinf()
        {
            throw new NotImplementedException();
        }

        public ndarray isneginf()
        {
            throw new NotImplementedException();
        }

        public ndarray isfinite()
        {
            throw new NotImplementedException();
        }

        public ndarray where(ndarray x = null, ndarray y = null)
        {
            throw new NotImplementedException();
        }

        public ndarray polyval(ndarray p)
        {
            throw new NotImplementedException();
        }

        public ndarray bincount(ndarray weights = null, int minlength = 0)
        {
            throw new NotImplementedException();
        }

        public ndarray pad(int[] pad_width = null, string mode = "constant")
        {
            throw new NotImplementedException();
        }

        public ndarray prod(int? axis = null, DType dtype = null, bool keepdims = false, float? initial = null)
        {
            throw new NotImplementedException();
        }

        public ndarray dot(ndarray b)
        {
            throw new NotImplementedException();
        }

        public ndarray cumsum(int? axis = null, DType dtype = null)
        {
            throw new NotImplementedException();
        }

        public ndarray reshape(Shape newshape, bool reverse = false, string order = "C")
        {
            throw new NotImplementedException();
        }

        public ndarray moveaxis(int source, int destination)
        {
            throw new NotImplementedException();
        }

        public ndarray moveaxis(int[] source, int[] destination)
        {
            throw new NotImplementedException();
        }

        public ndarray copy()
        {
            throw new NotImplementedException();
        }

        public ndarray rollaxis(int axis, int start = 0)
        {
            throw new NotImplementedException();
        }

        public ndarray diag(int k = 0)
        {
            throw new NotImplementedException();
        }

        public ndarray diagflat(int k = 0)
        {
            throw new NotImplementedException();
        }

        public ndarray diagonal(int offset = 0, int axis1 = 0, int axis2 = 1)
        {
            throw new NotImplementedException();
        }

        public ndarray sum(int? axis = null, DType dtype = null, bool keepdims = false, float? initial = null)
        {
            throw new NotImplementedException();
        }
    }
}
