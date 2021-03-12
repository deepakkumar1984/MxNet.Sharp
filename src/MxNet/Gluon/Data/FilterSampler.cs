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
    public class FilterSampler : Sampler<int>
    {
        private Func<int, bool> function;
        private int[] dataset;

        public FilterSampler(Func<int, bool> fn, int[] dataset)
        {
            throw new NotImplementedException();
        }

        public override int Length => throw new NotImplementedException();;

        public override IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}