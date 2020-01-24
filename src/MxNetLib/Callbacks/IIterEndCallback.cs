using MxNetLib.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.Callbacks
{
    public interface IIterEndCallback
    {
        void Invoke(int epoch);
    }
}
