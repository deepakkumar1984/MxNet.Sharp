using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision
{
    public class DataLoaderV1 : IEnumerable
    {
        

        public DataLoaderV1(Dataset<NDArray> dataset, int? batch_size= null, bool  shuffle= false,Sampler sampler= null,
                        string last_batch= null, BatchSampler batch_sampler= null, Func<NDArrayList, NDArray> batchify_fn= null,
                        int num_workers= 0, bool pin_memory= false, int pin_device_id= 0)
        {
            
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int Len() => throw new NotImplementedException();
    }
}
