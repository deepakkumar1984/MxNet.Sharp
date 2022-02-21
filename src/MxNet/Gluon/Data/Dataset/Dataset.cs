/*****************************************************************************
   Copyright 2018 The MxNet.Sharp Authors. All Rights Reserved.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MxNet.Gluon.Data
{
    public abstract class Dataset<T>
    {
        public Dataset(params T[] data)
        {
            Data = data.ToList();
        }

        public List<T> Data { get; set; }

        public abstract int Length { get; }

        public abstract T this[int idx] { get; }

        public Dataset<T> Transform(Block fn, bool lazy = true)
        {
            var trans = new _LazyTransformDataset<T>(this, fn);
            if (lazy)
                return trans;

            return new SimpleDataset<T>(trans.Data.ToArray());
        }

        private Dataset<T> Transform(_TransformFirstClosure fn, bool lazy = true)
        {
            var trans = new _LazyTransformDataset<T>(this, fn);
            if (lazy)
                return trans;

            return new SimpleDataset<T>(trans.Data.ToArray());
        }

        public Dataset<T> TransformFirst(Block fn, bool lazy = true)
        {
            return Transform(new _TransformFirstClosure(fn), lazy);
        }

        public virtual _SampledDataset<T> Filter(Func<int, bool> fn)
        {
            return new _SampledDataset<T>(this, new FilterSampler<T>(fn, this));
        }

        public virtual _SampledDataset<T> Shard(int num_shards, int index)
        {
            Debug.Assert(index < num_shards, $"Shard index of out bound: {index} out of {num_shards}");
            Debug.Assert(num_shards > 0, "Number of shards must be greater than 0");
            Debug.Assert(index >= 0, "Index must be non-negative");
            var length = this.Length;
            var shard_len = length / num_shards;
            var rest = length % num_shards;
            // Compute the start index for this partition
            var start = shard_len * index + Math.Min(index, rest);
            // Compute the end index for this partition
            var end = start + shard_len + ((index < rest) ? 1 : 0);
            return new _SampledDataset<T>(this, new SequentialSampler(end - start, start));
        }

        public virtual _SampledDataset<T> Take(int count)
        {
            if (count == null || count > this.Length)
            {
                count = this.Length;
            }
            return new _SampledDataset<T>(this, new SequentialSampler(count));
        }

        public virtual _SampledDataset<T> Sample(Sampler<int> sampler)
        {
            return new _SampledDataset<T>(this, sampler);
        }
    }
}