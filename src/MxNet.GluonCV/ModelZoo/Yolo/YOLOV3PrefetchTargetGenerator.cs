using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Yolo
{
    public class YOLOV3PrefetchTargetGenerator : Block
    {
        public YOLOV3PrefetchTargetGenerator(int num_classes, string prefix, ParameterDict @params) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol Forward(NDArrayOrSymbol input, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private NDArray Slice(NDArray x, int[] num_anchors, int[] num_offsets)
        {
            throw new NotImplementedException();
        }
    }
}
