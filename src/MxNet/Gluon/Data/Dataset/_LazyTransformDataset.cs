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

namespace MxNet.Gluon.Data
{
    public class _LazyTransformDataset<T> : Dataset<T>
    {
        private readonly Dataset<T> _data;
        private Func<T, T> _fn;

        public _LazyTransformDataset(Dataset<T> data, Func<T, T> fn)
        {
            _data = data;
            _fn = fn;
        }

        public override T this[int idx] => _data[idx];

        public override int Length => _data.Length;
    }
}