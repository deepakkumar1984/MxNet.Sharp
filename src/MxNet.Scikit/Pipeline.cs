using MxNet.SciKit.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MxNet.SciKit
{
    public class Pipeline : _BaseComposition, IEnumerable<(int, string, TransformerMixin)>
    {
        public int Length => throw new NotImplementedException();

        public BaseEstimator this[int ind]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string EstimatorType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Dictionary<string, TransformerMixin> NamedSteps
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public BaseEstimator FinalEstimator
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public NDArray Transform
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public NDArray InverseTransform
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string[] Classes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Pairwise
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Pipeline(Dictionary<string, BaseEstimator> steps, MemoryStream[] memory = null, bool verbose= false )
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

        internal void ValidateSteps()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<(int, string, TransformerMixin)> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal string LogMessage(int step_idx)
        {
            throw new NotImplementedException();
        }

        private (NDArray, FuncArgs) _Fit(NDArray X, NDArray y= null, FuncArgs fit_params = null)
        {
            throw new NotImplementedException();
        }

        public Pipeline Fit(NDArray X, NDArray y = null, FuncArgs fit_params = null)
        {
            throw new NotImplementedException();
        }

        public NDArray FitTransform(NDArray X, NDArray y = null, FuncArgs fit_params = null)
        {
            throw new NotImplementedException();
        }

        public NDArray Predict(NDArray X, FuncArgs predict_params = null)
        {
            throw new NotImplementedException();
        }

        public NDArray FitPredict(NDArray X, NDArray y = null, FuncArgs fit_params = null)
        {
            throw new NotImplementedException();
        }

        public NDArray PredictProba(NDArray X)
        {
            throw new NotImplementedException();
        }

        public NDArray DecisionFunction(NDArray X)
        {
            throw new NotImplementedException();
        }

        public NDArray ScoreSamples(NDArray X)
        {
            throw new NotImplementedException();
        }

        public NDArray PredictLogProba(NDArray X)
        {
            throw new NotImplementedException();
        }

        private NDArray _Transform(NDArray X)
        {
            throw new NotImplementedException();
        }

        private NDArray _InverseTransform(NDArray X)
        {
            throw new NotImplementedException();
        }

        public NDArray Score(NDArray X, NDArray y = null, NDArray sample_weight = null)
        {
            throw new NotImplementedException();
        }

        public static string[] NameEstimators(BaseEstimator[] estimators)
        {
            throw new NotImplementedException();
        }

        public static Pipeline MakePipeline(BaseEstimator[] steps, MemoryStream[] memory = null, bool verbose = false)
        {
            throw new NotImplementedException();
        }

        internal static Pipeline TransformOne(BaseEstimator transformer, NDArray X, NDArray y, NDArray weight, FuncArgs fit_params)
        {
            throw new NotImplementedException();
        }

        internal static Pipeline FitTransformOne(BaseEstimator transformer, NDArray X, NDArray y, NDArray weight, string message_clsname = "", string message = "", FuncArgs fit_params = null)
        {
            throw new NotImplementedException();
        }

        internal static Pipeline FitOne(BaseEstimator transformer, NDArray X, NDArray y, NDArray weight, string message_clsname = "", string message = "", FuncArgs fit_params = null)
        {
            throw new NotImplementedException();
        }

        public static FeatureUnion MakeUnion(BaseEstimator[] transformers, int n_jobs = 1, bool vberbose = false)
        {
            throw new NotImplementedException();
        }
    }
}
