using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data
{
    public class BatchSampler : Sampler
    {
        public BatchSampler(Sampler sampler, int batch_size, string last_batch= "keep")
        {
            throw new NotImplementedException();
        }

        public override IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override int Len()
        {
            throw new NotImplementedException();
        }
    }
}
