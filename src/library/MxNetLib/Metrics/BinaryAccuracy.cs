using MxNetLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Metrics
{
    public sealed class BinaryAccuracy : BaseMetric
    {
        #region Constructors

        public BinaryAccuracy() : base("binary_accuracy") { }

        #endregion

        #region Methods

        public override void Update(NDArray labels, NDArray preds)
        {
            if (labels == null)
                throw new ArgumentNullException(nameof(labels));
            if (preds == null)
                throw new ArgumentNullException(nameof(preds));

            var p = NDArray.Round(preds);
            this.Values.Add(NDArray.Mean(NDArray.BroadcastEqual(p, labels)).AsArray()[0]);
        }

        #endregion

    }
}
