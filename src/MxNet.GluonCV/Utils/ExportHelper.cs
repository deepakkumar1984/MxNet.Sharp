using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MxNet.GluonCV.Utils
{
    public class ExportHelper
    {
        public static void ExportBlock(string path, HybridBlock block, Shape data_shape= null, int epoch= 0, HybridBlock preprocess = null, string layout= "HWC", Context ctx= null)
        {
            if (ctx == null)
                ctx = mx.Cpu();

            NDArray x;
            int t;
            int c;
            int w;
            int h;
            HybridSequential wrapper_block;
            List<Shape> data_shapes = new List<Shape>();
            // input image layout
            layout = layout.ToUpper();
            if (data_shape == null)
            {
                if (layout == "HWC")
                {
                    data_shapes = (from s in new int[] { 224, 256, 299, 300, 320, 416, 512, 600 }
                                   select new Shape(s, s, 3)).ToList();
                }
                else if (layout == "CHW")
                {
                    data_shapes = (from s in new int[] { 224, 256, 299, 300, 320, 416, 512, 600 }
                                   select new Shape(3, s, s)).ToList();
                }
                else
                {
                    throw new Exception("Unable to predict data_shape, please specify.");
                }
            }
            else
            {
                data_shapes.Add(data_shape);
            }

            if (preprocess != null)
            {
                wrapper_block = new HybridSequential();
                preprocess.Initialize(ctx: new Context[] { ctx });
                wrapper_block.Add(preprocess);
                wrapper_block.Add(block);
            }
            else
            {
                wrapper_block = new HybridSequential();
                preprocess.Initialize(ctx: new Context[] { ctx });
                wrapper_block.Add(block);
                Debug.Assert(new string[] { "CHW", "CTHW"}.Contains(layout), $"Default layout is CHW for 2D models and CTHW for 3D models if preprocess is None, provided {layout}.");
            }

            wrapper_block.CollectParams().ResetCtx(ctx);
            // try different data_shape if possible, until one fits the network
            object last_exception = null;
            foreach (var dshape in data_shapes)
            {
                if (layout == "HWC")
                {
                    (h, w, c) = dshape;
                    x = nd.Zeros(new Shape(1, h, w, c), ctx: ctx);
                }
                else if (layout == "CHW")
                {
                    (c, h, w) = dshape;
                    x = nd.Zeros(new Shape(1, c, h, w), ctx: ctx);
                }
                else if (layout == "THWC")
                {
                    (t, h, w, c) = dshape;
                    x = nd.Zeros(new Shape(1, t, h, w, c), ctx: ctx);
                }
                else if (layout == "CTHW")
                {
                    (c, t, h, w) = dshape;
                    x = nd.Zeros(new Shape(1, c, t, h, w), ctx: ctx);
                }
                else
                {
                    throw new Exception(String.Format("Input layout {0} is not supported yet.", layout));
                }

                // hybridize and forward once
                wrapper_block.Hybridize();
                try
                {
                    wrapper_block.Call(x);
                    wrapper_block.Export(path, epoch);
                    last_exception = null;
                    break;
                }
                catch (MXNetException ex)
                {
                    last_exception = ex;
                }
            }
            if (last_exception != null)
            {
                throw new Exception(last_exception.ToString().Split('\n')[0]);
            }
        }
    }
}
