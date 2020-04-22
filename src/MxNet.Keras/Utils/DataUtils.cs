using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace MxNet.Keras.Utils
{
    public class DataUtils
    {
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0);

        public static Dictionary<int, Sequence<NDArrayList>> _SHARED_SEQUENCES = new Dictionary<int, Sequence<NDArrayList>>();
        public static int? _SEQUENCE_COUNTER = 0;
        private static Dictionary<int, int> currentSample = new Dictionary<int, int>();

        public static string UrlRetrieve(string url, string filename, Action<int, int, int> reporthook= null, byte[] data= null)
        {
            string path = "./" + filename;

            using (var client = new WebClient())
            {
                var ur = new Uri(url);
                // client.Credentials = new NetworkCredential("username", "password");
                client.DownloadProgressChanged += WebClientDownloadProgressChanged;
                client.DownloadFileCompleted += WebClientDownloadCompleted;
                Console.WriteLine(@"Downloading file:" + url);
                client.DownloadFileAsync(ur, path);
                _semaphore.Wait();
            }

            return path;
        }

        private static void WebClientDownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var _result = !e.Cancelled;
            if (!_result) Console.Write(e.Error.ToString());

            Console.WriteLine(Environment.NewLine + "Download finished!");
            _semaphore.Release();
        }

        private static void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.Write("\r     -->    {0}%.", e.ProgressPercentage);
        }

        public static void ExtractArchive(string file_path, string path = "./", string archive_format = "auto")
        {
            if(archive_format != "auto")
            {
                if (archive_format != Path.GetExtension(file_path))
                    throw new Exception($"Archive format expected {archive_format} but got {Path.GetExtension(file_path)}");
            }

            using (ZipArchive zip = new ZipArchive(File.OpenRead(file_path)))
            {
                zip.ExtractToDirectory(path);
            }

            File.Delete(file_path);
        }

        public static string GetFile(string stfname, string origin, bool untar= false, string file_hash= "", string cache_subdir= "datasets",
                                    string hash_algorithm= "auto", bool extract= false, string archive_format= "auto", string cache_dir= null)
        {
            throw new NotImplementedException();
        }

        private static string HashFile(string fpath, string algorithm = "sha256", int chunk_size = 65535)
        {
            HashAlgorithm hasher = null;
            string ret = "";
            if (algorithm == "sha256" || (algorithm == "auto" && HashAlgorithm.Create().Hash.Length == 64))
            {
                hasher = SHA256.Create();
            }
            else
            {
                hasher = MD5.Create();
            }

            using (var fpath_file = File.OpenRead(fpath))
            {
                byte[] filedata = new byte[fpath_file.Length];
                fpath_file.Read(filedata, 0, filedata.Length);
                var hash = hasher.ComputeHash(filedata);
                ret = HexStringFromBytes(hash);
            }

            return ret;
        }

        public static string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }

        public static bool ValidateFile(string fpath, string file_hash, string algorithm = "auto", int chunk_size = 65535)
        {
            if (HashFile(fpath, algorithm, chunk_size).ToString() == file_hash.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static NDArray PrepareSlicedSparseData(NDArray data, int batch_size)
        {
            if (data == null || data.Shape[0] < batch_size)
            {
                Logger.Warning("MXNet Backend: Cannot slice data");
                return data;
            }

            var n = Convert.ToInt32(Math.Floor(Convert.ToDouble(data.Shape[0]) / batch_size));
            return data[$":{(n * batch_size)}"];
        }

        public static void InitPool(Sequence<NDArrayList>[] seqs)
        {
            for (int i = 0; i < seqs.Length; i++)
            {
                _SHARED_SEQUENCES.Add(i, seqs[i]);
                currentSample.Add(i, 0);
            }
        }

        public static NDArrayList GetIndex(int uid, int i)
        {
            return _SHARED_SEQUENCES[uid][i];
        }

        public static void InitPoolGenerator(Sequence<NDArrayList>[] gens, int? random_seed = null)
        {
            for (int i = 0; i < gens.Length; i++)
            {
                _SHARED_SEQUENCES.Add(i, gens[i]);
                currentSample.Add(i, 0);
            }

            if(random_seed.HasValue)
            {
                mx.Seed(random_seed.Value + Process.GetCurrentProcess().Id);
            }
        }

        public static NDArrayList NextSample(int uid)
        {
            var ret = _SHARED_SEQUENCES[uid][currentSample[uid]];
            currentSample[uid]++;
            return ret;
        }
    }
}
