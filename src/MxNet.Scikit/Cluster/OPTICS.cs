using MxNet.SciKit.Neighbours;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.Cluster
{
    public class OPTICS : ClusterMixin
    {
        public OPTICS(int min_samples= 5, float max_eps= float.PositiveInfinity, string metric= "minkowski", int p= 2,
                 FuncArgs metric_params= null, string cluster_method= "xi", float? eps= null, float xi= 0.05f,
                 bool predecessor_correction= true, int? min_cluster_size= null, string algorithm= "auto", int leaf_size= 30, int? n_jobs= null)
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

        internal static void ValidateSize(int size, int n_samples, string param_name)
        {
            throw new NotImplementedException();
        }

        internal static NDArray ComputeCoreDistances(NDArray X, NearestNeighbors neighbors, int min_samples, int working_memory)
        {
            throw new NotImplementedException();
        }

        internal static (NDArray, NDArray, NDArray, NDArray) ComputeOpticsDistances(NDArray X, int min_samples, float max_eps, string metric, int p, FuncArgs metric_params, string algorithm, int leaf_size, int n_jobs)
        {
            throw new NotImplementedException();
        }

        internal static void SetReachDist(NDArray core_distances_, NDArray reachability_, NDArray predecessor_,
                    int point_index, bool processed, NDArray X, NearestNeighbors nbrs, string metric, FuncArgs metric_params,
                    int p, float max_eps)
        {
            throw new NotImplementedException();
        }

        internal static NDArray ClusterOpticsDBScan(NDArray reachability, NDArray core_distances, NDArray ordering, float eps)
        {
            throw new NotImplementedException();
        }

        internal static (NDArray, NDArray) ClusterOpticsXI(NDArray reachability, NDArray predecessor, int min_samples, int? min_cluster_size = null, float xi = 0.05f, bool predecessor_correction = true)
        {
            throw new NotImplementedException();
        }

        internal static (int, int) ExtendRegion(NDArray steep_point, NDArray xward_point, int start, int min_samples)
        {
            throw new NotImplementedException();
        }

        internal static NDArray UpdateFilterSdas(Dictionary<string, float>[] sdas, float mib, float xi_complement, float[] reachability_plot)
        {
            throw new NotImplementedException();
        }

        internal static (int, int) CorrectPredecessor(NDArray reachability_plot, NDArray predecessor_plot, NDArray ordering, int s, int e)
        {
            throw new NotImplementedException();
        }

        internal static NDArray XICluster(NDArray reachability_plot, NDArray predecessor_plot, NDArray ordering, float xi, int min_samples, int min_cluster_size, bool predecessor_correction)
        {
            throw new NotImplementedException();
        }

        internal static NDArray ExtractXILabels(NDArray ordering, NDArray clusters)
        {
            throw new NotImplementedException();
        }
    }
}
