using MxNet.Keras.Utils;
using NumpyDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Datasets
{
    public class IMDB
    {
        public static ((NDArray, NDArray), (NDArray, NDArray)) LoadData(string path= "imdb.npz", int? num_words= null, int skip_top= 0, int? maxlen= null, int seed= 113, int start_char= 1, int oov_char= 2, int index_from= 3)
        {
            path = DataUtils.GetFile(path, origin: "https://s3.amazonaws.com/text-datasets/imdb.npz", file_hash: "599dadb1135973df5b59232a0e9a887c");
            var arrays = NDArray.LoadNpz(path);
            var x_train = arrays[0];
            var labels_train = arrays[1];
            var x_test = arrays[2];
            var labels_test = arrays[4];

            mx.Seed(seed);
            NDArray indices = nd.Arange(0, x_train.Shape[0]);
            indices = nd.Shuffle(indices.AsType(DType.Int32));

            x_train = x_train[indices];
            labels_train = labels_train[indices];

            indices = nd.Arange(0, x_test.Shape[0]);
            indices = nd.Shuffle(indices.AsType(DType.Int32));
            x_test = x_test[indices];
            labels_test = labels_test[indices];
            ndarray xs = nd.Concat(new List<NDArray> {
                x_train,
                x_test
            });

            ndarray labels = nd.Concat(new List<NDArray> {
                labels_train,
                labels_test
            });

            //if (start_char != 0)
            //{
            //    xs = (from x in xs
            //          select (new List<int> {
            //            start_char
            //        } + (from w in x
            //             select (w + index_from)).ToList())).ToList();
            //}
            //else if (index_from)
            //{
            //    xs = (from x in xs
            //          select (from w in x
            //                  select (w + index_from)).ToList()).ToList();
            //}
            //if (maxlen)
            //{
            //    var _tup_1 = _remove_long_seq(maxlen, xs, labels);
            //    xs = _tup_1.Item1;
            //    labels = _tup_1.Item2;
            //    if (!xs)
            //    {
            //        throw new ValueError("After filtering for sequences shorter than maxlen=" + maxlen.ToString() + ", no sequence was kept. Increase maxlen.");
            //    }
            //}
            //if (!num_words)
            //{
            //    num_words = max((from x in xs
            //                     select max(x)).ToList());
            //}
            //// by convention, use 2 as OOV word
            //// reserve 'index_from' (=3 by default) characters:
            //// 0 (padding), 1 (start), 2 (OOV)
            //if (oov_char != null)
            //{
            //    xs = (from x in xs
            //          select (from w in x
            //                  select skip_top <= w < num_words ? w : oov_char).ToList()).ToList();
            //}
            //else
            //{
            //    xs = (from x in xs
            //          select (from w in x
            //                  where skip_top <= w < num_words
            //                  select w).ToList()).ToList();
            //}
            //var idx = x_train.Count;
            //x_train = np.array(xs[::idx]);
            //var y_train = np.array(labels[::idx]);
            //x_test = np.array(xs[idx]);
            //var y_test = np.array(labels[idx]);
            //return Tuple.Create((x_train, y_train), (x_test, y_test));

            throw new NotImplementedException();
        }
    }
}
