using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Utils
{
    public class DataUtils
    {
        public static void UrlRetrieve(string url, string filename, Action<int, int, int> reporthook= null, byte[] data= null)
        {
            throw new NotImplementedException();
        }

        public static void ExtractArchive(string file_path, string path = ".", string archive_format = "auto")
        {
            throw new NotImplementedException();
        }

        public static string GetFile(string stfname, string origin, bool untar= false, string file_hash= "", string cache_subdir= "datasets",
                                    string hash_algorithm= "auto", bool extract= false, string archive_format= "auto", string cache_dir= null)
        {
            throw new NotImplementedException();
        }

        private static string HashFile(string fpath, string algorithm = "sha256", int chunk_size = 65535)
        {
            throw new NotImplementedException();
        }

        public static  bool ValidateFile(string fpath, string file_hash, string algorithm= "auto", int chunk_size= 65535)
        {
            throw new NotImplementedException();
        }

        public static NDArray PrepareSlicedSparseData(NDArray data, int batch_size)
        {
            throw new NotImplementedException();
        }

        public static void InitPool(Sequence[] seqs)
        {
            throw new NotImplementedException();
        }

        public static int GetIndex(int uid, int i)
        {
            throw new NotImplementedException();
        }

        public static void InitPoolGenerator(Sequence[] gens, int? random_seed = null)
        {
            throw new NotImplementedException();
        }

        public static int NextSample(int uid)
        {
            throw new NotImplementedException();
        }
    }
}
