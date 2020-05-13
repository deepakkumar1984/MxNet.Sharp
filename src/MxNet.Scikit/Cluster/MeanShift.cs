using MxNet.SciKit.Neighbours;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.Cluster
{
    public class MeanShift : ClusterMixin
    {
        public MeanShift(float? bandwidth= null, int? seeds= null, bool bin_seeding= false, int min_bin_freq= 1, bool cluster_all= true, int? n_jobs= null, int max_iter= 300)
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

        public static float EstimateBandwidth(NDArray X, float quantile= 0.3f, int? n_samples= null, int random_state= 0,
                       int? n_jobs= null)
        {
            throw new NotImplementedException();
        }

        public static (NDArray, int, int) MeanShiftSingleSeed(NDArray my_mean, NDArray X, NearestNeighbors nbrs, int max_iter)
        {
            throw new NotImplementedException();
        }

        public static (NDArray, NDArray) mean_shift(NDArray X, float? bandwidth= null, int? seeds= null, bool bin_seeding= false,
                                            int min_bin_freq= 1, bool cluster_all= true, int max_iter= 300, int? n_jobs= null)
        {
            throw new NotImplementedException();
        }

        public static NDArray GetBinSeeds(NDArray X, int bin_size, int min_bin_freq= 1)
        {
            throw new NotImplementedException();
        }
    }
}
