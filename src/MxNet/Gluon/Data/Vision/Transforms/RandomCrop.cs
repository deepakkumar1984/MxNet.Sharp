using MxNet.Image;
using MxNet.Numpy;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class RandomCrop : HybridBlock
    {
        private int _pad_value;

        private (int, int, int, int, int, int, int, int, int, int)? nd_pad;

        private ((int, int), (int, int), (int, int))? np_pad;

        private (int, int) size;

        private InterpolationFlags interpolation;

        public RandomCrop((int, int) size, int pad, int pad_value = 0, InterpolationFlags interpolation = InterpolationFlags.Linear)
        {
            this.size= size;
            this.interpolation = interpolation;
            this._pad_value = pad_value;
            this.nd_pad = (0, 0, 0, 0, pad, pad, pad, pad, 0, 0);
            this.np_pad = ((pad, pad), (pad, pad), (0, 0));
        }

        public RandomCrop((int, int) size, List<int> pad, int pad_value = 0, InterpolationFlags interpolation = InterpolationFlags.Linear)
        {
            this.size = size;
            this.interpolation = interpolation;
            this._pad_value = pad_value;
            if (pad != null)
            {
                Debug.Assert(pad.Count >= 4);
                this.nd_pad = (0, 0, 0, 0, pad[0], pad[1], pad[2], pad[3], 0, 0);
                this.np_pad = ((pad[0], pad[1]), (pad[2], pad[3]), (0, 0));
            }
        }

        public override NDArrayOrSymbolList Forward(NDArrayOrSymbolList inputs)
        {
            var x = inputs[0];
            if (this.np_pad.HasValue)
            {
                List<int> npPadList = new List<int>();
                npPadList.Add(np_pad.Value.Item1.Item1);
                npPadList.Add(np_pad.Value.Item1.Item2);
                npPadList.Add(np_pad.Value.Item2.Item1);
                npPadList.Add(np_pad.Value.Item2.Item2);
                npPadList.Add(np_pad.Value.Item3.Item1);
                npPadList.Add(np_pad.Value.Item3.Item2);
                if (x.IsNDArray)
                    x = np.pad(x, pad_width: npPadList.ToArray(), mode: "constant", constant_values: this._pad_value);
                else
                    x = sym.pad(x, pad_width: npPadList.ToArray(), mode: "constant", constant_values: this._pad_value);
            }

            return Img.RandomCrop(x, size, interpolation).Item1;
        }
    }
}
