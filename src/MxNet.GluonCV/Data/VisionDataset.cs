using MxNet;
using MxNet.Gluon.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class VisionDataset : Dataset<(NDArray, NDArray)>
    {
        public VisionDataset(string root)
        {
            if (!System.IO.Directory.Exists(mx.AppPath + root))
            {
                var helper_msg = $"{root} is not a valid dir. Did you forget to initialize datasets described in: " +
                                        "'http://gluon-cv.mxnet.io/build/examples_datasets/index.html'?" +
                                        "You need to initialize each dataset only once.";
                    throw new Exception(helper_msg);
            }
        }

        public override (NDArray, NDArray) this[int idx]
        {
            get
            {
                return default;
            }
        }

        public virtual string[] Classes
        {
            get
            {
                return new string[0];
            }
        }

        public virtual int NumClass => Classes.Length;

        public override int Length => throw new NotImplementedException();
    }
}
