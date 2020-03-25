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
using MxNet.Gluon.Data;

namespace MxNet.Gluon.Contrib.Data
{
    public class IntervalSampler : Sampler
    {
        private readonly int _interval;

        private readonly int _length;

        private readonly bool _rollover;

        public IntervalSampler(int length, int interval, bool rollover = true)
        {
            _interval = interval;
            _rollover = rollover;
            _length = length;
        }

        public override int Length => _length;

        public override IEnumerator<int> GetEnumerator()
        {
            var n = _rollover ? _interval : 1;
            for (var i = 0; i < n; i++)
            for (var j = i; j < _length; j = j + _interval)
                yield return j;
        }
    }
}