using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Utils
{
    public class Progbar
    {
        public Progbar(int target, int width= 30, int verbose= 1, float interval= 0.05f, string[] stateful_metrics= null)
        {
            throw new NotImplementedException();
        }

        public void Update(int current, Dictionary<string, object> values = null)
        {
            throw new NotImplementedException();
        }

        public void Add(int n, Dictionary<string, object> values = null) => throw new NotImplementedException();
    }
}
