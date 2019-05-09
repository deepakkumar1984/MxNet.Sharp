using MxNetLib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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
            var eq = nd.Equal(p, labels);

            this.Values.Add(eq.Values.Average());
        }

        #endregion

    }
}
