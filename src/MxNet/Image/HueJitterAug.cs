using NumSharp;
using SharpCV;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Image
{
    public class HueJitterAug : Augmenter
    {
        public float Hue { get; }

        public NDArray Tyiq { get; set; }

        public NDArray ITyiq { get; set; }

        public HueJitterAug(float hue)
        {
            Hue = hue;
            Tyiq = new NDArray(new float[] { 0.299f, 0.587f, 0.114f, 0.596f, -0.274f, -0.321f, 0.211f, -0.523f, 0.311f }).Reshape(3, 3);
            ITyiq = new NDArray(new float[] { 1, 0.956f, 0.621f, 1, -0.272f, -0.647f, 1, -1.107f, 1.705f }).Reshape(3, 3);
        }

        public override NDArray Call(NDArray src)
        {
            float alpha = np.random.uniform(-Hue, Hue);
            float u = (float)Math.Cos(alpha * np.pi);
            float w = (float)Math.Sin(alpha * np.pi);
            var bt = new NDArray(new float[] { 1, 0, 0, 0, u, -w, 0, w, u }).Reshape(3, 3);
            var t = nd.Dot(nd.Dot(ITyiq, bt), Tyiq).Transpose();
            src = nd.Dot(src, t);
            return src;
        }
    }
}
