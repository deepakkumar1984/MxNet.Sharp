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
using System.Collections.Generic;
using System.Linq;

namespace MxNet.Gluon.Data
{
    public class SequentialSampler : Sampler<int>
    {
        private readonly int _length;
        private readonly int _start;

        public SequentialSampler(int length, int start = 0)
        {
            _length = length;
            _start = start;
        }

        public override int Length => _length;

        public override IEnumerator<int> GetEnumerator()
        {
            return Enumerable.Range(this._start, this._start + this._length - this._start).GetEnumerator();
        }
    }
}