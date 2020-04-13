using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Yolo
{
    public class YOLODetectionBlockV3 : HybridBlock
    {
        public HybridSequential body;

        public HybridSequential tip;

        public YOLODetectionBlockV3(int channel, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            Debug.Assert(channel % 2 == 0, $"channel {channel} cannot be divided by 2");
            this.body = new HybridSequential(prefix: "body");
            foreach (var _ in Enumerable.Range(0, 2))
            {
                // 1x1 reduce
                this.body.Add(DarknetV3.Conv2d(channel, 1, 0, 1, norm_layer: norm_layer, norm_kwargs: norm_kwargs));
                // 3x3 expand
                this.body.Add(DarknetV3.Conv2d(channel * 2, 3, 1, 1, norm_layer: norm_layer, norm_kwargs: norm_kwargs));
            }

            this.body.Add(DarknetV3.Conv2d(channel, 1, 0, 1, norm_layer: norm_layer, norm_kwargs: norm_kwargs));
            this.tip = DarknetV3.Conv2d(channel * 2, 3, 1, 1, norm_layer: norm_layer, norm_kwargs: norm_kwargs);
            RegisterChild(body, "body");
            RegisterChild(tip, "tip");
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            var route = this.body.Call(x);
            var tip = this.tip.Call(route);
            if(x.IsNDArray)
                return new NDArrayOrSymbol(route.NdX, tip);

            return new NDArrayOrSymbol(route.SymX, tip);
        }
    }
}
