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
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MxNet.Gluon.Data
{
    public class _SampledDataset<T> : Dataset<T>
    {
        private Dataset<T> _dataset;
        private Sampler<int> _sampler;
        private List<int> _indices;
        public _SampledDataset(Dataset<T> dataset, Sampler<int> sampler)
        {
            this._dataset = dataset;
            this._sampler = sampler;
            this._indices = sampler.ToList();
        }

        public override int Length => _sampler.Length;

        public override T this[int idx]
        {
            get
            {
                return this._dataset[_indices[idx]];
            }
        }
    }
}