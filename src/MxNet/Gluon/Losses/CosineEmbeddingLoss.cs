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
namespace MxNet.Gluon.Losses
{
    public class CosineEmbeddingLoss : Loss
    {
        public CosineEmbeddingLoss(float? weight = null, int? batch_axis = null, float margin = 0, string prefix = null,
            ParameterDict @params = null) : base(weight, batch_axis)
        {
            Margin = margin;
        }

        public float Margin { get; set; }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol input1, NDArrayOrSymbol label,
            NDArrayOrSymbol sample_weight = null, params object[] args)
        {
            var input2 = (NDArrayOrSymbol) args[0];
            if (input1.IsNDArray)
                return F(input1.NdX, input2, label, sample_weight);
            return F(input1.SymX, input2, label, sample_weight);
        }

        private NDArray F(NDArray input1, NDArray input2, NDArray label, NDArray sample_weight = null)
        {
            input1 = nd.ReshapeLike(input1, input2);
            label = label.Reshape(-1, 1);
            var cos_sim = _cosine_similarity(input1, input2);
            var y_1 = nd.EqualScalar(label, 1);
            var y_minus_1 = nd.EqualScalar(label, -1);
            var cos_sim_a = (1 - cos_sim) * y_1;
            var z_array = nd.Zeros(new Shape(1, 1));
            var cos_sim_b =
                nd.BroadcastMaximum(z_array, y_minus_1 * (cos_sim - Margin)); //ToDo: Check missing axis parameter
            var loss = cos_sim_a + cos_sim_b;
            loss = ApplyWeighting(loss, Weight, sample_weight);
            return loss;
        }

        private Symbol F(Symbol input1, Symbol input2, Symbol label, Symbol sample_weight = null)
        {
            input1 = sym.ReshapeLike(input1, input2);
            label = label.Reshape(-1, 1);
            var cos_sim = _cosine_similarity(input1, input2);
            var y_1 = sym.EqualScalar(label, 1);
            var y_minus_1 = sym.EqualScalar(label, -1);
            var cos_sim_a = (1 - cos_sim) * y_1;
            var z_array = sym.Zeros(new Shape(1, 1));
            var cos_sim_b =
                sym.BroadcastMaximum(z_array, y_minus_1 * (cos_sim - Margin)); //ToDo: Check missing axis parameter
            var loss = cos_sim_a + cos_sim_b;
            loss = ApplyWeighting(loss, Weight, sample_weight);
            return loss;
        }

        private NDArray _cosine_similarity(NDArray x, NDArray y, int axis = -1)
        {
            var x_norm = nd.Norm(x, axis: new Shape(axis)).Reshape(-1, 1);
            var y_norm = nd.Norm(y, axis: new Shape(axis)).Reshape(-1, 1);
            var x_dot_y = nd.Sum(x * y, axis).Reshape(-1, 1);
            var eps_err = new NDArray(new[] {1e-12f});
            return x_dot_y / nd.BroadcastMaximum(x_norm * y_norm, eps_err);
        }

        private Symbol _cosine_similarity(Symbol x, Symbol y, int axis = -1)
        {
            var x_norm = sym.Norm(x, axis: new Shape(axis)).Reshape(-1, 1);
            var y_norm = sym.Norm(y, axis: new Shape(axis)).Reshape(-1, 1);
            var x_dot_y = sym.Sum(x * y, axis).Reshape(-1, 1);
            var eps_err_x = new NDArray(new[] {1e-12f});
            var eps_err = new Constant("eps_err", eps_err_x).Var();

            return x_dot_y / sym.BroadcastMaximum(x_norm * y_norm, eps_err);
        }
    }
}