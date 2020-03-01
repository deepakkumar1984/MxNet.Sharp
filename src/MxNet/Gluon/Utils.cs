using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MxNet.Gluon
{
    public class Utils
    {
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0);

        public static NDArrayList SplitData(NDArray data, int num_slice, int batch_axis = 0, bool even_split = true)
        {
            var size = (int)data.Shape[batch_axis];
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

            NDArrayList slices = new NDArrayList();
            if(batch_axis == 0)
            {
                for(int i=0; i<num_slice;i++)
                {
                    if (i < num_slice)
                        slices.Add(data[string.Format("{0}:{1}", i * step, (i + 1) * step)]);
                }
            }
            else if (even_split)
            {
                slices.Add(nd.Split(data, num_outputs: num_slice, axis: batch_axis));
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

        public static NDArrayList SplitAndLoad(NDArray data, Context[] ctx_list, int batch_axis = 0, bool even_split = true)
        {
            if (ctx_list.Length == 1)
                return data.AsInContext(ctx_list[0]);

            var slices = SplitData(data, ctx_list.Length, batch_axis, even_split);

            NDArrayList result = new NDArrayList();
            result = Enumerable.Zip(slices, ctx_list, (i, ctx) => {
                return i.AsInContext(ctx);
            }).ToList();

            return result.ToArray();
        }

        public static NDArray clip_global_norm(NDArrayList arrays,float  max_norm, bool check_isfinite= true)
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
            scale = nd.Min(nd.Concat(new NDArrayList(scale, nd.Ones(new Shape(1), ctx: ctx)), dim: 0));
            for(int i=0;i< arrays.Length;i++)
            {
                arrays[i] *= scale.AsInContext(arrays[i].context);
            }

            return total_norm;
        }

        private static string Indent(string s_, int numSpaces)
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

        public static bool CheckSha1(string filename, string sha1_hash)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                byte[] hash = SHA1.Create().ComputeHash(stream);
                string hashString = Encoding.UTF8.GetString(hash, 0, hash.Length);
                if (hashString == sha1_hash)
                    return true;
            }

            return true;
        }

        public static string Download(string url, string path= "", bool overwrite= false, string sha1_hash= "", bool verify_ssl= true)
        {
            if (!verify_ssl)
                Logger.Warning("Unverified HTTPS request is being made (verify_ssl=False). " + 
                                "Adding certificate verification is strongly advised.");

            if (string.IsNullOrWhiteSpace(path))
                path = "./";

            using (WebClient client = new WebClient())
            {
                var ur = new Uri(url);
                // client.Credentials = new NetworkCredential("username", "password");
                client.DownloadProgressChanged += WebClientDownloadProgressChanged;
                client.DownloadFileCompleted += WebClientDownloadCompleted;
                Console.WriteLine(@"Downloading file:" + url);
                client.DownloadFileAsync(ur, path);
                _semaphore.Wait();
            }

            if (sha1_hash != "")
            {
                if (!CheckSha1(path, sha1_hash))
                {
                    throw new Exception("File hash not matching");
                }
            }

            return path;
        }

        private static void WebClientDownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var _result = !e.Cancelled;
            if (!_result)
            {
                Console.Write(e.Error.ToString());
            }

            Console.WriteLine(Environment.NewLine + "Download finished!");
            _semaphore.Release();
        }

        private static void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.Write("\r     -->    {0}%.", e.ProgressPercentage);
        }

        public static string GetRepoUrl()
        {
            string default_repo = "https://apache-mxnet.s3-accelerate.dualstack.amazonaws.com/";
            string repo_url = Environment.GetEnvironmentVariable("MXNET_GLUON_REPO");
            repo_url = !string.IsNullOrEmpty(repo_url) ? repo_url : default_repo;
            if (!repo_url.EndsWith("/"))
                repo_url = repo_url + "/";

            return repo_url;
        }

        public static string GetRepoFileUrl(string @namespace, string filename)
        {
            return string.Format("{0}{1}/{2}", GetRepoUrl(), @namespace, filename);
        }

        public static string BriefPrintList<T>(List<T> lst, int limit= 7)
        {
            int counter = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var item in lst)
            {
                if(counter == 7)
                {
                    sb.AppendLine(", ...,");
                    counter = 0;
                }

                sb.AppendFormat("'{0}'", item.ToString());
                counter++;
            }

            return sb.ToString();
        }

        public static bool ShapeIsKnown(Shape shape)
        {
            if (shape == null)
                return false;

            if (shape.Dimension == 0)
                return false;

            for (int i = 0; i < shape.Dimension; i++)
            {
                if (shape[i] == 0)
                    return false;
            }

            return true;
        }
    }
}
