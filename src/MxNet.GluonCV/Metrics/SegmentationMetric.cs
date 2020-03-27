using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Metrics
{
    public class SegmentationMetric : EvalMetric
    {
        public SegmentationMetric(int nclass) : base("pixAcc & mIoU", "")
        {
            throw new NotImplementedException();
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            throw new NotImplementedException();
        }

        public override (string, float) Get()
        {
            throw new NotImplementedException();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }

        public static (NDArray, NDArray) BatchPixAccuracy(NDArray output, NDArray target)
        {
            throw new NotImplementedException();
        }

        public static (NDArray, NDArray) BatchIntersectionUnion(NDArray output, NDArray target, int nclass)
        {
            throw new NotImplementedException();
        }

        public static (NDArray, NDArray, NDArray) PixelAccuracy(NDArray imPred, NDArray imLab)
        {
            throw new NotImplementedException();
        }

        public static (NDArray, NDArray) IntersectionAndUnion(NDArray imPred, NDArray imLab, int nclass)
        {
            throw new NotImplementedException();
        }
    }
}
