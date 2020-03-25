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
using MxNet.Gluon.RNN;
using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.RecurrentLayer
{
    public class BaseConvRNNCell : BaseRNNCell
    {
        public BaseConvRNNCell(Shape input_shape, int num_hidden, (int, int) h2h_kernel, (int, int) h2h_dilate,
                                (int, int) i2h_kernel, (int, int) i2h_stride, (int, int) i2h_pad, (int, int) i2h_dilate,
                                Initializer i2h_weight_initializer, Initializer h2h_weight_initializer, Initializer i2h_bias_initializer,
                                Initializer h2h_bias_initializer, RNNActivation activation, string prefix = "", RNNParams @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override StateInfo[] StateInfo => throw new NotImplementedException();

        public int NumGates
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override void Call(Symbol inputs, SymbolList states)
        {
            throw new NotImplementedException();
        }

        private (Symbol, Symbol) ConvForward(Symbol inputs, SymbolList states, string name)
        {
            throw new NotImplementedException();
        }
    }
}
