using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNet.SciKit
{
    public class FeatureUnion : TransformerMixin, IEnumerable<(string, TransformerMixin, NDArray)>
    {
        public FeatureUnion(TransformerMixin[] transformer_list, int? n_jobs= null, NDArrayDict transformer_weights = null, bool verbose= false)
        {
            throw new NotImplementedException();
        }

        public override NDArray Fit(NDArray X, NDArray y = null, FuncArgs fit_params = null)
        {
            throw new NotImplementedException();
        }

        public override NDArray Transform(NDArray X)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, object> GetParams(bool deep = true)
        {
            throw new NotImplementedException();
        }

        public override BaseEstimator SetParams(Dictionary<string, object> @params)
        {
            throw new NotImplementedException();
        }

        internal void ValidateTransformers()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<(string, TransformerMixin, NDArray)> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string[] GetFeatureNames()
        {
            throw new NotImplementedException();
        }

        public override NDArray FitTransform(NDArray X, NDArray y = null, FuncArgs fit_params = null)
        {
            throw new NotImplementedException();
        }

        private string LogMessage(string name, int idx, int total)
        {
            throw new NotImplementedException();
        }

        private ParallelQuery<BaseEstimator> ParallelFunc(NDArray X, NDArray y, FuncArgs fit_params, Func<BaseEstimator, NDArray, NDArray, NDArray, string, string, FuncArgs, Pipeline> func)
        {
            throw new NotImplementedException();
        }

        private void UpdateTransformerList(BaseEstimator[] transformers)
        {
            throw new NotImplementedException();
        }
    }
}
