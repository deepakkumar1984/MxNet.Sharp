using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo
{
    public class Models
    {
        public static HybridBlock GetModel(string name, bool pretrained, int? classes = null, Context ctx = null, string root = "/models")
        {
            throw new NotImplementedException();
        }

        public static string[] GetModelList()
        {
            throw new NotImplementedException();
        }
    }
}
