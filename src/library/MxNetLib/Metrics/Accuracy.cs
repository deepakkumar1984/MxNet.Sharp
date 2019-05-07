using MxNetLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Metrics
{
    public sealed class Accuracy : BaseMetric
    {
        #region Constructors

        public Accuracy() : base("accuracy") { }

        #endregion

        #region Methods

        public override void Update(NDArray labels, NDArray preds)
        {
            if (labels == null)
                throw new ArgumentNullException(nameof(labels));
            if (preds == null)
                throw new ArgumentNullException(nameof(preds));

            var p = nd.Argmax(preds, 1);
            this.Values.Add(nd.Mean(nd.BroadcastEqual(p, labels)).AsArray()[0]);
        }

        #endregion

    }
}
