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
namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class Normalize : HybridBlock
    {
        private readonly float _mean;
        private readonly float _std;

        public Normalize(float mean = 0, float std = 1)
        {
            _mean = mean;
            _std = std;
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            if (x.IsNDArray)
                return nd.Image.Normalize(x, new Tuple<double>(_mean), new Tuple<double>(_std));

            return sym.Image.Normalize(x, new Tuple<double>(_mean), new Tuple<double>(_std));
        }
    }
}