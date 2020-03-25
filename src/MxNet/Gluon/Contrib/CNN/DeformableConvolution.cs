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

namespace MxNet.Gluon.Contrib.CNN
{
    public class DeformableConvolution : HybridBlock
    {
        public DeformableConvolution(int channels, (int, int)? kernel_size = null, (int, int)? strides = null,
            (int, int)? padding = null,
            (int, int)? dilation = null, int groups = 1, int num_deformable_group = 1, string layout = "NCHW",
            bool use_bias = true, int in_channels = 0, string activation = null, string weight_initializer = null,
            string bias_initializer = "zeros", string offset_weight_initializer = "zeros",
            string offset_bias_initializer = "zeros", bool offset_use_bias = true,
            string op_name = "DeformableConvolution", (int, int)? adj = null,
            string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}