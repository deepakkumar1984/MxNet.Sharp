using MxNetLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib.IO
{
    public class NDArrayIter : DataIter
    {
        //private NDArray _data;
        //private NDArray _label;

        //private uint num_data;

        //public NDArrayIter(NDArray data, NDArray label)
        //{
        //    _data = data;
        //    _label = label;
        //    BatchSize = 32;
        //    num_data = data.GetShape()[0];
        //    cursor = (int)-BatchSize;
        //}

        //public override void BeforeFirst()
        //{
        //    cursor = (int)-BatchSize;
        //}

        //public override NDArray GetData()
        //{
        //    uint start = (uint)cursor;
        //    uint end = (uint)cursor + BatchSize;
        //    if(end > num_data)
        //    {
        //        end = num_data;
        //    }

        //    return _data.Slice(start, end);
        //}

        //public override int[] GetIndex()
        //{
        //    uint start = (uint)cursor;
        //    uint end = (uint)cursor + BatchSize;
        //    if (end > num_data)
        //    {
        //        end = num_data;
        //    }

        //    List<int> idx = new List<int>();
        //    for (int i = (int)start; i < end; i++)
        //    {
        //        idx.Add((int)i);
        //    }

        //    return idx.ToArray();
        //}

        //public override NDArray GetLabel()
        //{
        //    if (_label == null)
        //        return null;

        //    uint start = (uint)cursor;
        //    uint end = (uint)cursor + BatchSize;
        //    if (end >= num_data)
        //    {
        //        end = num_data;
        //    }

        //    return _label.Slice(start, end).Ravel();
        //}

        //public override int GetPadNum()
        //{
        //    return 0;
        //}

        //public override bool Next()
        //{
        //    cursor += (int)BatchSize;
        //    if(cursor < num_data)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        private string last_batch_handle;
        private DataBatch first_batch = null;
        private Dictionary<string, NDArray> data;
        private Dictionary<string, NDArray> label;
        private int cursor;
        private uint num_data;
        private int num_source;
        private bool shuffle;
        private NDArray[] _cache_data;
        private NDArray[] _cache_label;

        public NDArrayIter(NDArray data, NDArray label = null, uint batch_size = 1, bool shuffle = false,
                           string last_batch_handle = "pad", string data_name = "data", string label_name = "softmax_label")
            : this(new NDArray[] { data }, new NDArray[] { label }, batch_size, shuffle, last_batch_handle, data_name, label_name)
        {

        }

        public NDArrayIter(NDArray[] data, NDArray[] label = null, uint batch_size = 1, bool shuffle = false,
                            string last_batch_handle = "pad", string data_name = "data", string label_name = "softmax_label")
        {
            this.data = Utils.InitData(data, false, data_name);
            this.label = Utils.InitData(label, false, label_name);
            BatchSize = batch_size;
            this.last_batch_handle = last_batch_handle;
            this.shuffle = shuffle;
        }

        public override NDArray[] GetData()
        {
            throw new NotImplementedException();
        }

        public override int[] GetIndex()
        {
            throw new NotImplementedException();
        }

        public override NDArray[] GetLabel()
        {
            throw new NotImplementedException();
        }

        public override int GetPad()
        {
            throw new NotImplementedException();
        }

        public override bool IterNext()
        {
            throw new NotImplementedException();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }

        public static NDArrayIter FromBatch(DataBatch data_batch)
        {
            var iter = new NDArrayIter(data_batch.Data, data_batch.Label);
            iter.DefaultBucketKey = data_batch.BucketKey.HasValue ? data_batch.BucketKey.Value : new Random().Next();
            return iter;
        }
    }
}
