using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.Cluster
{
    public class DBSCAN : ClusterMixin
    {
        public DBSCAN(float eps = 0.5f, int min_samples = 5, string metric = "euclidean", FuncArgs metric_params = null, string algorithm = "auto", int leaf_size = 30, int p = 2, int? n_jobs = null)
        {
            throw new NotImplementedException();
        }

        public static (NDArray, NDArray) DBScan(NDArray X, float eps= 0.5f,int min_samples= 5, string metric= "minkowski", FuncArgs metric_params = null, string algorithm= "auto", int leaf_size= 30, int p= 2, NDArray sample_weight = null,
           int? n_jobs= null)
        {
            throw new NotImplementedException();
        }

        public override NDArray Fit(NDArray X, NDArray y = null, NDArray sample_weight = null)
        {
            throw new NotImplementedException();
        }

        public override NDArray Predict(NDArray X, NDArray sample_weight = null)
        {
            throw new NotImplementedException();
        }

        public override NDArray FitPredict(NDArray X, NDArray y = null, NDArray sample_weight = null)
        {
            throw new NotImplementedException();
        }

        internal static void DBScanInner(NDArray is_core, NDArray neighborhoods, NDArray labels)
        {
            throw new NotImplementedException();
        }
    }
}
