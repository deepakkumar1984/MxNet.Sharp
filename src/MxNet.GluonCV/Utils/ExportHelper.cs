using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Utils
{
    public class ExportHelper
    {
        public static void ExportBlock(string path, HybridBlock block, Shape data_shape= null, int epoch= 0, bool preprocess= true, string layout= "HWC", Context ctx= null)
        {
            throw new NotImplementedException();
        }
    }
}
