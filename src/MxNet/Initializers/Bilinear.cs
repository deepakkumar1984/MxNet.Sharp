using NumSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Initializers
{
    public class Bilinear : Initializer
    {
        public Bilinear()
        {
        }

        public override void InitWeight(string name, NDArray arr)
        {
            float[] weight = new float[arr.Shape.Size];
            float f = (float)Math.Ceiling(arr.Shape[3] / 2f);
            var shape = arr.Shape;
            float c = (2 * f - 1 - f % 2) / (2f * f);
            for (int i = 0; i < (int)arr.Shape.Size; i++)
            {
                var x = i % arr.Shape[3];
                var y = Math.Floor(Convert.ToDouble(i / shape[3])) % shape[2];
                weight[i] = (1 - Math.Abs(x / f - c)) * (1 - (float)Math.Abs(y / f - c));
            }

            arr.SyncCopyFromCPU(weight);
        }
    }
}
