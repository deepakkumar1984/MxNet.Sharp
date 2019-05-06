using MxNetLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Metrics
{
    public sealed class MAPE : BaseMetric
    {
        #region Constructors

        public MAPE() : base("mape") { }

        #endregion

        #region Methods

        public override void Update(NDArray labels, NDArray preds)
        {
            if (labels == null)
                throw new ArgumentNullException(nameof(labels));
            if (preds == null)
                throw new ArgumentNullException(nameof(preds));

            var result = NDArray.Mean(NDArray.Abs((preds - labels) / labels)).AsArray();
            this.Values.Add(result.Length > 0 ? result[0] : 0);
        }

        #endregion

    }
}
