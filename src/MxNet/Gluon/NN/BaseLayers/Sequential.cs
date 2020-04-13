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

namespace MxNet.Gluon.NN
{
    public class Sequential : Block
    {
        public Sequential(string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
        }

        public List<Block> Blocks => _childrens.Values.ToList();

        public new Sequential this[string key]
        {
            get
            {
                var net = new Sequential(Prefix);
                net.Add(_childrens[key]);
                return net;
            }
        }

        public int Length => _childrens.Count;

        public void Add(params Block[] blocks)
        {
            foreach (var item in blocks) RegisterChild(item);
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            foreach (var item in Blocks) input = item.Call(input, args);

            return input;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", GetType().Name, Name);
        }

        public override void Hybridize(bool active = true, bool static_alloc = false, bool static_shape = false)
        {
            if (_childrens.Values.All(x => x.GetType() == typeof(HybridBlock)))
                Logger.Warning(string.Format("All children of this Sequential layer '{0}' are HybridBlocks. Consider " +
                                             "using HybridSequential for the best performance.", Prefix));

            base.Hybridize(active, static_alloc, static_shape);
        }
    }
}