﻿/*****************************************************************************
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
using MxNet.Numpy;

namespace MxNet.Gluon.Metrics
{
    public class MSE : EvalMetric
    {
        public MSE(string output_name = null, string label_name = null) : base("mse", output_name, label_name, true)
        {
        }

        public override void Update(ndarray labels, ndarray preds)
        {
            if (labels.Shape.Dimension == 1)
                labels = labels.Reshape(labels.Shape[0], 1);
            if (preds.Shape.Dimension == 1)
                preds = preds.Reshape(preds.Shape[0], 1);

            var mse = nd.Square(labels - preds).Mean();

            sum_metric += mse;
            global_sum_metric += mse;
            num_inst += 1;
            global_num_inst += 1;
        }
    }
}