using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Callbacks
{
    public interface IIterEndCallback
    {
        void Invoke(int epoch);
    }
}
