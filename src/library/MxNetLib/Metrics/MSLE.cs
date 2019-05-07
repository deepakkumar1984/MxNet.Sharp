using MxNetLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Metrics
{
    public sealed class MSLE : BaseMetric
    {
        #region Constructors

        public MSLE() : base("msle") { }

        #endregion

        #region Methods

        public override void Update(NDArray labels, NDArray preds)
        {
            if (labels == null)
                throw new ArgumentNullException(nameof(labels));
            if (preds == null)
                throw new ArgumentNullException(nameof(preds));

            var result = nd.Mean(nd.Square(nd.Log(preds - labels))).Value;

            this.Values.Add(result);
        }

        #endregion

    }
}
