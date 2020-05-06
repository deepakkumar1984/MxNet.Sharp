using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit
{
    public class BiClusterMixin : BaseEstimator
    {
        public (int, int) BiClusters 
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public (NDArray, NDArray) GetIndices(int i)
        {
            throw new NotImplementedException();
        }

        public Shape GetShape(int i)
        {
            throw new NotImplementedException();
        }

        public NDArray GetSubMatrix(int i, NDArray data)
        {
            throw new NotImplementedException();
        }
    }
}
