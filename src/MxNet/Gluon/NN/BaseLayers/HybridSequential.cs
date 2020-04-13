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

namespace MxNet.Gluon.NN
{
    public class HybridSequential : HybridBlock
    {
        public HybridSequential(string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
        }

        public new HybridSequential this[string key]
        {
            get
            {
                var net = new HybridSequential(Prefix);
                net.Add((HybridBlock) _childrens[key]);
                return net;
            }
        }

        public HybridSequential(Dictionary<string, Block> blocks, bool loadkeys = false)
           : this()
        {
            foreach (var item in blocks)
            {
                if (loadkeys)
                    RegisterChild(item.Value, item.Key);
                else
                    RegisterChild(item.Value);
            }
        }

        public int Length => _childrens.Count;

        public void Add(params HybridBlock[] blocks)
        {
            foreach (var item in blocks) RegisterChild(item);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            foreach (var item in _childrens) x = item.Value.Call(x, args);

            return x;
        }
    }
}