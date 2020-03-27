using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Metrics
{
    public class VOCMApMetric : EvalMetric
    {
        public VOCMApMetric(float iou_thresh = 0.5f, string[] class_names = null) : base("VOCMeanAP", "")
        {
            throw new NotImplementedException();
        }

        public override void Update(NDArray labels, NDArray preds)
        {
            throw new NotImplementedException();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }

        public override (string, float) Get()
        {
            throw new NotImplementedException();
        }

        public void Update(NDArray pred_bboxes, NDArray pred_labels, NDArray pred_scores, NDArray gt_bboxes, NDArray gt_labels, NDArray gt_difficults = null)
        {
            throw new NotImplementedException();
        }

        public override void Update(NDArrayList labels, NDArrayList preds)
        {
            throw new Exception("Use Update(NDArray pred_bboxes, NDArray pred_labels, NDArray pred_scores, NDArray gt_bboxes, NDArray gt_labels, NDArray gt_difficults = null) method!");
        }

        public void _Update()
        {
            throw new NotImplementedException();
        }

        internal virtual (NDArray, NDArray) RecallPrec()
        {
            throw new NotImplementedException();
        }

        internal virtual NDArray AveragePrecision(NDArray rec, NDArray prec)
        {
            throw new NotImplementedException();
        }
    }
}
