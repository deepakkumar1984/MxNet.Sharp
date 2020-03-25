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

namespace MxNet.Gluon.Data.Vision.Datasets
{
    public class CIFAR100 : CIFAR10
    {
        public CIFAR100(string root = "./datasets/cifar100", bool fine_label = false, bool train = true,
            Func<NDArray, NDArray, (NDArray, NDArray)> transform = null)
            : base(root, train, transform)
        {
            throw new NotImplementedException();
        }

        internal override (NDArray, NDArray) ReadBatch()
        {
            throw new NotImplementedException();
        }
    }
}