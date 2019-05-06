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

            var result = NDArray.Mean(NDArray.Square(preds - labels)).AsArray();

            this.Values.Add(result.Length > 0 ? result[0] : 0);
        }

        #endregion

    }
}
