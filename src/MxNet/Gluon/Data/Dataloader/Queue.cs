using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision
{
    public class Queue : ConcurrentQueue<NDArray>
    {
        public Queue(IEnumerable<NDArray> collection) : base(collection)
        {
            throw new NotImplementedException();
        }
    }
}
