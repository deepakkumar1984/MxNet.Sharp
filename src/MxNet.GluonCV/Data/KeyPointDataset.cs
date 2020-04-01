using MxNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class KeyPointDataset : VisionDataset
    {
        public KeyPointDataset(string root) : base(root)
        {
            throw new NotImplementedException();
        }

        public override (NDArray, NDArray, NDArray) this[int idx] => throw new NotImplementedException();

        public override int Length => throw new NotImplementedException();

        public override string[] Classes => throw new NotImplementedException();

        public virtual int NumJoints => 0;

        public virtual List<(int, int)> JointPairs => new List<(int, int)>();

        public virtual Dictionary<int, int> ParentJoints => new Dictionary<int, int>();
    }
}
