using MxNet.Gluon.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class LstDetection : Dataset<NDArrayList>
    {
        public LstDetection(string filename, string root= "", int flag= 1, bool coord_normalized= true)
        {
            throw new NotImplementedException();
        }

        public override NDArrayList this[int idx] => throw new NotImplementedException();

        public override int Length => throw new NotImplementedException();
    }
}
