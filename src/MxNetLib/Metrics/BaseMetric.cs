using MxNetLib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNetLib.Metrics
{
    public abstract class BaseMetric
    {
        public string Name { get; set; }

        #region Constructors

        protected BaseMetric(string name, int num = 0)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name));

            Values = new List<float>();
            this.Name = name;
        }

        #endregion

        #region Properties

        public List<float> Values
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void GetNameValue()
        {
        }

        public void Reset()
        {
            this.Values.Clear();
        }

        public float Get()
        {
            if (Values.Count == 0)
                return 0;

            return Values.Average();
        }

        public bool Improvement()
        {
            var prev = Values.Count > 2 ? Values[Values.Count - 2] : float.MaxValue;
            var currect = Values.Last();
            if(currect < prev)
            {
                return true;
            }

            return false;
        }

        public abstract void Update(NDArray labels, NDArray preds);

        #region Helpers

        protected static void CheckLabelShapes(NDArray labels, NDArray preds, bool strict = false)
        {
            if (strict)
            {
                Logging.CHECK_EQ(new Shape(labels.GetShape()), new Shape(preds.GetShape()));
            }
            else
            {
                Logging.CHECK_EQ(labels.Size, preds.Size);
            }
        }

        #endregion

        #endregion

    }
}
