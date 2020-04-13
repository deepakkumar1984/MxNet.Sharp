using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Ssd
{
    public class SSD : HybridBlock
    {
        public SSD(string network, int base_size, string[] features, int[] num_filters, float[] sizes, float[] ratios,
                 int[] steps, string[] classes, bool use_1x1_transition= true, bool use_bn= true,
                 float reduce_ratio= 1, int min_depth= 128, bool global_pool= false, bool pretrained= false,
                 float[] stds= null, float nms_thresh= 0.45f, int nms_topk= 400, int post_nms= 100,
                 (int, int)? anchor_alloc_size= null, Context ctx= null, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null,
                 string root = "~/mxnet", string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public int NumClasses => throw new NotImplementedException();

        public void SetNms(float nms_thresh= 0.45f, int nms_topk= 400, int post_nms= 100)
        {
            throw new NotImplementedException();
        }

        public void ResetClasses(string[] classes, NDArrayDict reuse_weights = null)
        {
            throw new NotImplementedException();
        }

        public static SSD GetSSD(int base_size, string[] features, float[] filters, float[] sizes, float[] ratios, int[] steps, string[] classes,
            string dataset, bool pretrained= false, bool pretrained_base= true, Context ctx= null,  string root = "~/mxnet")
        {
            throw new NotImplementedException();
        }
    }
}
