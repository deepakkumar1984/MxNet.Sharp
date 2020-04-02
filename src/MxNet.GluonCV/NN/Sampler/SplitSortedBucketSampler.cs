using MxNet.Gluon.Data;
using NumpyDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.NN
{
    public class SplitSortedBucketSampler : Sampler<int[]>
    {
        public int _batch_size;

        public int _end;

        public float _mult;

        public int _num_parts;

        public int _seed;

        public bool _shuffle;

        public ndarray _shuffled_ids;

        public Array _sort_keys;

        public int _start;

        public SplitSortedBucketSampler(Array sort_keys, int batch_size, int mult= 32, int num_parts= 1, int part_index= 0, bool shuffle= false, int seed= 233)
        {
            Debug.Assert(sort_keys.Length > 0);
            Debug.Assert(batch_size > 0);
            Debug.Assert(mult >= 1, "Bucket size multiplier must be greater or equal to 1");
            this._sort_keys = sort_keys;
            var length = sort_keys.Length;
            this._batch_size = batch_size;
            this._mult = mult;
            this._shuffle = shuffle;
            // Compute the length of each partition
            var part_len = Convert.ToInt32(np.ceil(length / num_parts));
            // Compute the start index for this partition
            this._start = part_len * part_index;
            // Compute the end index for this partition
            this._end = this._start + part_len;
            if (part_index == num_parts - 1)
            {
                // last part
                this._end = length;
                this._start = length - part_len;
            }
            this._num_parts = num_parts;
            this._seed = seed;
            
            this._shuffled_ids = new np.random(new NumpyDotNet.RandomAPI.RandomState()).permutation(Enumerable.Range(0, length));
        }

        public override int Length => throw new NotImplementedException();

        public override IEnumerator<int[]> GetEnumerator()
        {
            ndarray sample_ids = null;
            if (this._num_parts > 1)
            {
                this._shuffled_ids = new np.random(new NumpyDotNet.RandomAPI.RandomState()).permutation(this._shuffled_ids);
            }
            if (this._shuffle)
            {
                sample_ids = new np.random().permutation(this._shuffled_ids[$"{_start}:{_end}"]);
            }
            else
            {
                sample_ids = np.array(Enumerable.Range(_start, this._end - this._start).ToArray());
            }
            var bucket_size = Convert.ToInt32(this._mult * this._batch_size);
            var buckets = Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sample_ids.Size - 0) / bucket_size))).Select(_x_1 => 0 + _x_1 * bucket_size).ToList();
            for(int bucket_begin = 0; bucket_begin < buckets.Count; bucket_begin++)
            {
                var bucket_end = (int)Math.Min(bucket_begin + bucket_size, sample_ids.Size);
                if (bucket_end - bucket_begin < this._batch_size)
                {
                    bucket_begin = bucket_end - this._batch_size;
                }

                var sorted_sample_ids = (ndarray)sample_ids[$"{bucket_begin}:{bucket_end}"];
                sorted_sample_ids = np.sort(sorted_sample_ids, kind: NumpyLib.NPY_SORTKIND.NPY_QUICKSORT);

                var batch_begins = Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sorted_sample_ids.Size - 0) / this._batch_size))).Select(_x_2 => 0 + _x_2 * this._batch_size).ToList();
                if (this._shuffle)
                {
                    batch_begins.Shuffle();
                }
                foreach (var batch_begin in batch_begins)
                {
                    var batch_end = Math.Min(batch_begin + this._batch_size, sorted_sample_ids.Size);
                    if (batch_end - batch_begin < this._batch_size)
                    {
                        yield return ((ndarray)sorted_sample_ids[$"{(batch_end - _batch_size)}:{batch_end}"]).AsInt32Array();
                    }
                    else
                    {
                        yield return ((ndarray)sorted_sample_ids[$"{batch_begin}:{batch_end}"]).AsInt32Array();
                    }
                }
            }
        }
    }
}
