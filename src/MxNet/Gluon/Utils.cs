using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon
{
    public class Utils
    {
        public static NDArray[] SplitData(NDArray data, int num_slice, int batch_axis = 0, bool even_split = true)
        {
            var size = (int)data.Shape[(uint)batch_axis];
            if (even_split && size % num_slice != 0)
            {
                throw new ArgumentException(string.Format("data with shape {0} cannot be evenly split into {1} slices along axis {2}. " +
                                                "Use a batch size that's multiple of {3} or set even_split=False to allow " +
                                                "uneven partitioning of data.", data.Shape, num_slice, batch_axis, num_slice));
            }

            int step = (int)Math.Truncate((double)size / num_slice);

            if (!even_split && size < num_slice)
            {
                step = 1;
                num_slice = size;
            }

            List<NDArray> slices = new List<NDArray>();
            if(batch_axis == 0)
            {
                for(int i=0; i<num_slice;i++)
                {
                    if (i < num_slice - 1)
                        slices.Add(data[string.Format("{0}:{1}", i * step, (i + 1) * step)]);
                }
            }
            else if (even_split)
            {
                slices.AddRange(nd.Split(data, num_outputs: num_slice, axis: batch_axis));
            }
            else
            {
                for (int i = 0; i < num_slice; i++)
                {
                    if (i < num_slice - 1)
                        slices.Add(data[string.Format("{0}:{1}", i * step, (i + 1) * step)]);
                    else
                        slices.Add(nd.SliceAxis(data, axis: batch_axis, i * step, (i + 1) * step));
                }
            }

            return slices.ToArray();
        }

        public static NDArray[] SplitAndLoad(NDArray data, Context[] ctx_list, int batch_axis = 0, bool even_split = true)
        {
            if (ctx_list.Length == 1)
                return new NDArray[] { data.AsInContext(ctx_list[0]) };

            var slices = SplitData(data, ctx_list.Length, batch_axis, even_split);

            List<NDArray> result = new List<NDArray>();
            Enumerable.Zip(slices, ctx_list, (i, ctx) => {
                result.Add(i.AsInContext(ctx));
                return true;
            });

            return result.ToArray();
        }

        public static NDArray clip_global_norm(NDArray[] arrays,float  max_norm, bool check_isfinite= true)
        {
            Func<NDArray, NDArray> norm = (array) => 
            {
                if(array.SType == StorageStype.Default)
                {
                    var x = array.Reshape(-1);
                    return nd.Dot(x, x);
                }

                return array.Norm().Square();
            };

            if (arrays.Length == 0)
                throw new ArgumentException("arrays.Length == 0");

            var ctx = arrays[0].context;
            var total_norm = nd.AddN(arrays.Select(x => (x.AsInContext(ctx))).ToArray());
            total_norm = total_norm.Sqrt();
            if(check_isfinite)
            {
                if (float.IsInfinity(total_norm.AsScalar<float>()))
                    Logger.Warning("nan or inf is detected. " + 
                                        "Clipping results will be undefined.");
            }

            var scale = max_norm / (total_norm + 1e-8f);
            scale = nd.Min(nd.Concat(new NDArray[] { scale, nd.Ones(new Shape(1), ctx: ctx) }, num_args: 2, dim: 0));
            for(int i=0;i< arrays.Length;i++)
            {
                arrays[i] *= scale.AsInContext(arrays[i].context);
            }

            return total_norm;
        }

        private string Indent(string s_, int numSpaces)
        {
            var s = s_.Split('\n');
            if (s.Length == 1)
                return s_;

            var first = s[0];
            s.ToList().RemoveAt(0);
            var result = first;
            foreach (var item in s)
            {
                result += "\n";

                for (int i = 0; i < numSpaces; i++)
                    result += " ";

                result += item;
            }

            return result;
        }

        public bool CheckSha1(string filename, string sha1_hash)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                byte[] hash = SHA256.Create().ComputeHash(stream);
            }
        }

        public void Download(string url, string path= "", bool overwrite= false, string sha1_hash= "", int retries= 5, bool verify_ssl= true) => throw new NotImplementedException();

        private string _get_repo_url() => throw new NotImplementedException();

        private string _get_repo_url(string @namespace, string filename) => throw new NotImplementedException();

        private void _brief_print_list<T>(List<T> lst, int limit= 7) => throw new NotImplementedException();

        public bool shape_is_known(Shape shape) => throw new NotImplementedException();

        public bool _check_same_symbol_type(Symbol[] symbols) => throw new NotImplementedException();

        public void _check_all_np_ndarrays(object @out) => throw new NotImplementedException();
    }
}
