using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Metrics
{
    internal class _BinaryClassificationMetrics : Base
    {
        public int true_positives = 0;
        public int false_negatives = 0;
        public int false_positives = 0;
        public int true_negatives = 0;
        
        public int global_true_positives = 0;
        public int global_false_negatives = 0;
        public int global_false_positives = 0;
        public int global_true_negatives = 0;

        public float Precision
        {
            get
            {
                if (true_positives + false_positives > 0)
                    return (float)true_positives / ((float)true_positives + (float)false_positives);
                else
                    return 0;
            }
        }

        public float GlobalPrecision
        {
            get
            {
                if (global_true_positives + global_false_positives > 0)
                    return (float)global_true_positives / ((float)global_true_positives + (float)global_false_positives);
                else
                    return 0;
            }
        }

        public float Recall
        {
            get
            {
                if (true_positives + false_negatives > 0)
                    return (float)true_positives / ((float)true_positives + (float)false_negatives);
                else
                    return 0;
            }
        }

        public float GlobalRecall
        {
            get
            {
                if (global_true_positives + global_false_negatives > 0)
                    return (float)global_true_positives / ((float)global_true_positives + (float)global_false_negatives);
                else
                    return 0;
            }
        }

        public float FScore
        {
            get
            {
                if (Precision + Recall > 0)
                    return 2f * Precision * Recall / (Precision + Recall);
                else
                    return 0;
            }
        }

        public float GlobalFScore
        {
            get
            {
                if (GlobalPrecision + GlobalRecall > 0)
                    return 2f * GlobalPrecision * GlobalRecall / (GlobalPrecision + GlobalRecall);
                else
                    return 0;
            }
        }

        public int TotalExamples
        {
            get
            {
                return false_negatives + false_positives + true_negatives + true_positives;
            }
        }

        public int GlobalTotalExamples
        {
            get
            {
                return global_false_negatives + global_false_positives + global_true_negatives + global_true_positives;
            }
        }

        public void UpdateBinaryStats(NDArray label, NDArray pred)
        {
            label = label.AsType(DType.Int32);
            var pred_label = nd.Argmax(pred, axis: 1);
            CheckLabelShapes(label, pred);
            //ToDo: check unique values and throw error for binary classification

            var pred_true =nd.EqualScalar(pred_label, 1);
            var pred_false = 1 - pred_true;
            var label_true = nd.EqualScalar(label, 1);
            var label_false = 1 - label_true;

            var true_pos = (pred_true * label_true).Sum();
            var false_pos = (pred_true * label_false).Sum();
            var false_neg = (pred_false * label_true).Sum();
            var true_neg = (pred_false * label_false).Sum();

            true_positives += (int)true_pos;
            global_true_positives += (int)true_pos;
            false_positives += (int)false_pos;
            global_false_positives += (int)false_pos;
            false_negatives += (int)false_neg;
            global_false_negatives += (int)false_neg;
            true_negatives += (int)true_neg;
            global_true_negatives += (int)true_neg;

        }

        public float MatthewsCC(bool use_global = false)
        {
            float true_pos, false_pos, false_neg, true_neg;

            if (use_global)
            {
                if (GlobalTotalExamples == 0)
                    return 0;

                true_pos = this.global_true_positives;
                false_pos = this.global_false_positives;
                false_neg = this.global_false_negatives;
                true_neg = this.global_true_negatives;
            }
            else
            {
                if (TotalExamples == 0)
                    return 0;

                true_pos = this.true_positives;
                false_pos = this.false_positives;
                false_neg = this.false_negatives;
                true_neg = this.true_negatives;
            }

            var terms = new float[] {(true_pos + false_pos),
                                     (true_pos + false_neg),
                                     (true_neg + false_pos),
                                     (true_neg + false_neg) };

            float denom = 1;

            foreach (var item in terms)
            {
                if (item == 0)
                    continue;

                denom *= item;
            }

            return ((true_pos * true_neg) - (false_pos * false_neg)) / (float)Math.Sqrt(denom);
        }

        public void LocalResetStats()
        {
            this.false_positives = 0;
            this.false_negatives = 0;
            this.true_positives = 0;
            this.true_negatives = 0;
        }

        public void ResetStats()
        {
            this.false_positives = 0;
            this.false_negatives = 0;
            this.true_positives = 0;
            this.true_negatives = 0;
            this.global_false_positives = 0;
            this.global_false_negatives = 0;
            this.global_true_positives = 0;
            this.global_true_negatives = 0;
        }
    }
}
