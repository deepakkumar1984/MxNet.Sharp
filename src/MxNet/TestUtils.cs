using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using MxNet.Gluon;
using NumSharp;

namespace MxNet
{
    public class TestUtils
    {
        public static Context DefaultContext()
        {
            return Context.CurrentContext;
        }

        public static void SetDefaultContext(Context ctx)
        {
            Context.CurrentContext = ctx;
        }

        public static DType DefaultDtype()
        {
            return DType.Float32;
        }

        public static float GetAtol(float? atol = null)
        {
            return atol.HasValue ? atol.Value : 1e-20f;
        }

        public static float GetRtol(float? rtol = null)
        {
            return rtol.HasValue ? rtol.Value : 1e-5f;
        }

        //public static NDArrayList random_arrays(params Shape[] shapes) => throw new NotImplementedException();

        //public static NDArray random_sample(NDArray population, int k) => throw new NotImplementedException();

        //private static void _validate_csr_generation_inputs(int num_rows, int num_cols, float density, string distribution= "uniform") => throw new NotImplementedException();

        //public static void shuffle_csr_column_indices(int[] csr) => throw new NotImplementedException();

        //private static CSRNDArray _get_uniform_dataset_csr(int num_rows, int num_cols, float density= 0.1f, DType dtype= null,
        //                                            Initializer data_init= null, bool shuffle_csr_indices= false) => throw new NotImplementedException();

        //private static CSRNDArray _get_powerlaw_dataset_csr(int num_rows, int num_cols, float density= 0.1f, DType dtype = null) => throw new NotImplementedException();

        //public static NDArray assign_each(NDArray the_input, Func<NDArray, NDArray> function) => throw new NotImplementedException();

        //public static NDArray assign_each2(NDArray input1, NDArray input2, Func<NDArray, NDArray, NDArray> function) => throw new NotImplementedException();

        //public static T rand_sparse_ndarray<T>(Shape shape, StorageStype stype, float? density= null, DType dtype= null, string distribution= null,
        //                                       Initializer data_init= null, NDArray rsp_indices= null, Func<NDArray, NDArray>  modifier_func = null,
        //                                       bool shuffle_csr_indices= false, Context ctx= null) => throw new NotImplementedException();

        //public static NDArray rand_ndarray(Shape shape, StorageStype stype=  StorageStype.Default, float? density= null, DType dtype= null, Func<NDArray, NDArray>  modifier_func = null,
        //                                    bool shuffle_csr_indices= false, string distribution= null, Context ctx= null) => throw new NotImplementedException();

        //public static T create_sparse_array<T>(Shape shape, StorageStype stype = StorageStype.Default, Initializer data_init = null,
        //                                        NDArray rsp_indices = null, DType dtype = null, Func<NDArray, NDArray> modifier_func = null, float density = 0.5f,
        //                                   bool shuffle_csr_indices = false) => throw new NotImplementedException();

        //public static T create_sparse_array_zd<T>(Shape shape, StorageStype stype, Initializer data_init = null,
        //                                      NDArray rsp_indices = null, DType dtype = null, Func<NDArray, NDArray> modifier_func = null, float density = 0.5f,
        //                                 bool shuffle_csr_indices = false) => throw new NotImplementedException();

        //public static Shape rand_shape_2d(int dim0= 10, int dim1= 10) => throw new NotImplementedException();

        //public static Shape rand_shape_3d(int dim0 = 10, int dim1 = 10, int dim2 = 10) => throw new NotImplementedException();

        //public static Shape rand_shape_nd(int num_dim, int dim1 = 10) => throw new NotImplementedException();

        //public static (int, int) rand_coord_2d(int x_low, int x_high, int y_low, int y_high) => throw new NotImplementedException();

        //public static NumSharp.NDArray np_reduce(NumSharp.NDArray dat, int axis, bool keepdims, Func<NumSharp.NDArray, NumSharp.NDArray> numpy_reduce_func) => throw new NotImplementedException();

        //public static (float, float) find_max_violation(NumSharp.NDArray a, NumSharp.NDArray b,float? rtol= null, float? atol= null) => throw new NotImplementedException();

        //public static bool same(NumSharp.NDArray a, NumSharp.NDArray b) => throw new NotImplementedException();

        //public static bool almost_equal(NumSharp.NDArray a, NumSharp.NDArray b, float? rtol= null, float? atol= null,bool equal_nan= false) => throw new NotImplementedException();

        //public static bool assert_almost_equal(NumSharp.NDArray a, NumSharp.NDArray b, float? rtol= null, float? atol= null, (string, string)? names= null, bool equal_nan= false) => throw new NotImplementedException();

        //public static bool assert_almost_equal_with_err(NumSharp.NDArray a, NumSharp.NDArray b, float? rtol = null, float? atol = null, float? etol = null, (string, string)? names = null, bool equal_nan = false) => throw new NotImplementedException();

        //public static bool almost_equal_ignore_nan(NumSharp.NDArray a, NumSharp.NDArray b, float? rtol = null, float? atol = null) => throw new NotImplementedException();

        //public static bool assert_almost_equal_ignore_nan(NumSharp.NDArray a, NumSharp.NDArray b, float? rtol = null, float? atol = null, (string, string)? names = null) => throw new NotImplementedException();

        //public static void simple_forward(Symbol sym, Context ctx= null, bool is_train= false, params NDArrayList inputs) => throw new NotImplementedException();

        //private static NDArrayDict _parse_location(Symbol sym, NDArrayList location, Context ctx, DType dtype = null) => throw new NotImplementedException();

        //private static NDArrayDict _parse_aux_states(Symbol sym, NDArrayList aux_states, Context ctx, DType dtype = null) => throw new NotImplementedException();

        public static List<int> ListGpus()
        {
            return Enumerable.Range(0, Context.NumGpus()).ToList();
        }

        public static string Download(string url, string fname = null, string dirname = null, bool overwrite = false)
        {
            var path = "";
            if (string.IsNullOrWhiteSpace(dirname)) path = "./";

            if (string.IsNullOrWhiteSpace(fname)) path += Path.GetFileName(url);

            if (overwrite)
            {
                Utils.Download(url, path, overwrite);
            }
            else
            {
                if (!File.Exists(path))
                    Utils.Download(url, path, overwrite);
            }

            return path;
        }

        public static NDArrayDict GetMNIST()
        {
            var path = "http://data.mxnet.io/data/mnist/";
            var (train_lbl, train_img) = read_data(path + "train-labels-idx1-ubyte.gz",
                path + "train-images-idx3-ubyte.gz", 60000);
            var (test_lbl, test_img) =
                read_data(path + "t10k-labels-idx1-ubyte.gz", path + "t10k-images-idx3-ubyte.gz", 10000);

            var dataset = new NDArrayDict();
            dataset.Add("train_data", train_img);
            dataset.Add("train_label", train_lbl);
            dataset.Add("test_data", test_img);
            dataset.Add("test_label", test_lbl);

            return dataset;
        }

        private static (NDArray, NDArray) read_data(string label_url, string image_url, int n)
        {
            NDArray label = null;
            NDArray images = null;
            var label_file = Download(label_url);
            var file = new FileInfo(label_file);
            using (var fs = file.OpenRead())
            {
                using (var decompressionStream = new GZipStream(fs, CompressionMode.Decompress))
                {
                    var stream = new MemoryStream();
                    decompressionStream.CopyTo(stream);
                    var data = new byte[stream.Length - 8];
                    stream.Seek(8, SeekOrigin.Begin);
                    stream.Read(data, 0, data.Length);

                    label = new NDArray(data.Select(x => (float) x).ToArray(), new Shape(n));
                }
            }

            var image_file = Download(image_url);
            file = new FileInfo(image_file);
            using (var fs = file.OpenRead())
            {
                using (var decompressionStream = new GZipStream(fs, CompressionMode.Decompress))
                {
                    var stream = new MemoryStream();
                    decompressionStream.CopyTo(stream);
                    var data = new byte[stream.Length - 16];
                    stream.Seek(16, SeekOrigin.Begin);
                    stream.Read(data, 0, data.Length);
                    var x = np.frombuffer(data, typeof(byte));
                    images = new NDArray(data.Select(y => (float) y).ToArray(), new Shape(n, 1, 28, 28)) / 255;
                }
            }

            return (label, images);
        }

        //public static NDArrayDict GetMnistPkl() => throw new NotImplementedException();

        //public static NDArrayDict GetMnistUByte() => throw new NotImplementedException();

        //public static NDArrayDict GetCifar10() => throw new NotImplementedException();

        //public static (NDArrayIter, NDArrayIter) GetMnistIterator(int batch_size, Shape input_shape, int num_parts= 1, int part_index= 0) => throw new NotImplementedException();
    }
}