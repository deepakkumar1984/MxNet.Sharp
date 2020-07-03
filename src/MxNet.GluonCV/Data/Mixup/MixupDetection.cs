using MxNet.Gluon.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class MixupDetection : Dataset<(NDArray, NDArray)>
    {
        private Dataset<(NDArray, NDArray)> _dataset;

        private Random _mixup;

        public MixupDetection(Dataset<(NDArray, NDArray)> dataset, Random mixup = null)
        {
            this._dataset = dataset;
            this._mixup = mixup;
        }

        public void SetMixup(Random mixup = null)
        {
            this._mixup = mixup;
        }

        public override (NDArray, NDArray) this[int idx]
        {
            get
            {
                var _tup_1 = this._dataset[idx];
                var img1 = _tup_1.Item1;
                var label1 = _tup_1.Item2;
                var lambd = 1;
                // draw a random lambda ratio from distribution
                if (this._mixup != null)
                {
                    lambd = Math.Max(0, Math.Min(1, this._mixup.Next()));
                }
                if (lambd >= 1)
                {
                    var weights1 = nd.Ones(new Shape(label1.Shape[0], 1));
                    label1 = nd.Stack(new NDArrayList(label1, weights1), 2);
                    return (img1, label1);
                }

                // second image
                var idx2 = _mixup.Next(0, this.Length);
                var _tup_2 = this._dataset[idx2];
                var img2 = _tup_2.Item1;
                var label2 = _tup_2.Item2;
                // mixup two images
                var height = Math.Max(img1.Shape[0], img2.Shape[0]);
                var width = Math.Max(img1.Shape[1], img2.Shape[1]);
                var mix_img = nd.Zeros(shape: new Shape(height, width, 3), dtype: DType.Float32);
                mix_img[$":{img1.Shape[0]}, :{img1.Shape[1]}, :"] = img1.AsType(DType.Float32) * lambd;
                mix_img[$":{img2.Shape[0]}, :{img2.Shape[1]}, :"] += img2.AsType(DType.Float32) * (1 - lambd);
                mix_img = mix_img.AsType(DType.UInt8);
                var y1 = nd.Stack(new NDArrayList(label1, nd.Full(lambd, new Shape(label1.Shape[0], 1))), 2);
                var y2 = nd.Stack(new NDArrayList(label2, nd.Full(1 - lambd, new Shape(label2.Shape[0], 1))), 2);
                var mix_label = nd.Stack(new NDArrayList(y1, y2), 1);
                return (mix_img, mix_label);
            }
        }

        public override int Length => _dataset.Length;
    }
}
