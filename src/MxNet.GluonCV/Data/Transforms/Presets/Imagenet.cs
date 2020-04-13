using MxNet.Gluon.Data.Vision.Transforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.Data.Transforms.Presets
{
    public class Imagenet
    {
        public static NDArrayList TransformEval(NDArrayList imgs, int resize_short= 256, int crop_size= 224, (float, float, float)? mean = null, (float, float, float)? std = null)
        {
            if (!mean.HasValue)
                mean = (0.485f, 0.456f, 0.406f);

            if (!std.HasValue)
                std = (0.229f, 0.224f, 0.225f);

            var transform_fn = new Compose(new Resize((resize_short,resize_short), keep_ratio: true),
                new CenterCrop((crop_size, crop_size)),
                new ToTensor(),
                new Normalize(mean, std)
            );

            var res = (from img in imgs
                       select transform_fn.Call(img).NdX.ExpandDims(0)).ToList();
            
            return res;
        }
    }
}
