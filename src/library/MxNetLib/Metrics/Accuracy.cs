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
            
            NDArray.WaitAll();
            var eq = nd.Equal(labels, p);
            List<int> data = new List<int>();
            for (int i = 0; i < p.Values.Length; i++)
            {
                if (p.Values[i] == labels.Values[i])
                    data.Add(1);
                else
                    data.Add(0);
            }

            this.Values.Add((float)data.Average());
        }

        #endregion

    }
}
