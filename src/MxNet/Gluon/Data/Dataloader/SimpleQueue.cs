using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision
{
    public class SimpleQueue : System.Collections.Queue
    {
        public SimpleQueue(ICollection col) : base(col)
        {
            throw new NotImplementedException();
        }
    }
}
