using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.SciKit.Utils
{
    public class _BaseComposition : BaseEstimator
    {
        public override Dictionary<string, object> GetParams(bool deep = true)
        {
            throw new NotImplementedException();
        }

        public override BaseEstimator SetParams(Dictionary<string, object> @params)
        {
            throw new NotImplementedException();
        }

        public void ReplaceEstimator(BaseEstimator attr, string name, object new_val)
        {
            throw new NotImplementedException();
        }

        public void ValidateNames(string[] names)
        {
            throw new NotImplementedException();
        }
    }
}
