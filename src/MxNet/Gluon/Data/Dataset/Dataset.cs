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

        public Dataset<T> Transform(Func<T, T> fn, bool lazy = true)
        {
            var trans = new _LazyTransformDataset<T>(this, fn);
            if (lazy)
                return trans;

            return new SimpleDataset<T>(trans.Data.ToArray());
        }

        public Dataset<T> TransformFirst(Func<T, T> fn, bool lazy = true)
        {
            throw new NotImplementedException();
        }
    }
}