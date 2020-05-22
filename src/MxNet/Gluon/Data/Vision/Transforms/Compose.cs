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
using MxNet.Gluon.NN;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class Compose : Sequential
    {
        public Compose(params Block[] transforms)
        {
            foreach (var item in transforms)
            {
                Add(item);
            }
            
            //var hybrid = new List<Block>();
            //foreach (var item in transforms)
            //{
            //    if (item.GetType().BaseType.Name == "HybridBlock")
            //    {
            //        hybrid.Add(item);
            //        continue;
            //    }
            //    else if (hybrid.Count == 1)
            //    {
            //        Add(hybrid[0]);
            //        hybrid.Clear();
            //    }
            //    else if (hybrid.Count > 1)
            //    {
            //        var hblock = new HybridSequential();
            //        foreach (var j in hybrid) hblock.Add((HybridBlock)j);

            //        hblock.Hybridize();
            //        Add(hblock);
            //        hybrid.Clear();
            //    }

            //    Add(item);
            //}
        }
    }
}