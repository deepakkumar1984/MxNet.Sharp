using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.FastPose
{
    public class AlphaPose : HybridBlock
    {
        public AlphaPose(HybridBlock preact, int num_joints, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null, string prefix = "", ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        public static AlphaPose GetAlphaPose(string name, string dataset, int num_joints, bool pretrained= false,
                  bool pretrained_base= true, Context ctx= null, string norm_layer= "BatchNorm", FuncArgs norm_kwargs= null,
                  string root= "~/mxnet", int? num_gpus = null)
        {
            throw new NotImplementedException();
        }

        public static AlphaPose AlphaPose_Resnet101_V1b_COCO(int? num_gpus = null)
        {
            throw new NotImplementedException();
        }
    }
}
