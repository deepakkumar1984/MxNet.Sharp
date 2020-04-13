using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Rcnn
{
    public class RCNN : HybridBlock
    {
        public RCNN(HybridBlock features, HybridBlock top_features, string[] classes, HybridBlock box_features, int @short, int max_size, string train_patterns,
                    float nms_thresh, int nms_topk, int post_nms, string roi_mode, (int, int) roi_size, (int, int)  strides, float? clip, bool force_nms= false, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public virtual ParameterDict CollectTrainParams(string select = "")
        {
            throw new NotImplementedException();
        }

        public void set_nms(float nms_thresh= 0.3f, int nms_topk= 400, int post_nms= 100, bool force_nms= false)
        {
            throw new NotImplementedException();
        }

        public virtual void ResetClass(string[] classes, NDArrayDict reuse_weights = null)
        {
            throw new NotImplementedException();
        }
    }
}
