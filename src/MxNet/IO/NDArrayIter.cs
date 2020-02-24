using MxNet;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.IO
{
    public class NDArrayIter : DataIter
    {
        private string last_batch_handle;
        private DataBatch first_batch = null;
        private NDArrayDict data;
        private NDArrayDict label;
        private int num_data;
        private int num_source;
        private bool shuffle;
        private NDArray[] _cache_data;
        private NDArray[] _cache_label;
        private NDArray idx;
        private List<NDArray> data_list = new List<NDArray>();

        public override DataDesc[] ProvideData 
        { 
            get
            {
                List<DataDesc> result = new List<DataDesc>();
                foreach (var kv in data)
                {
                    var shape = kv.Value.Shape.Data.ToList();
                    shape.RemoveAt(0);
                    shape.Insert(0, BatchSize);
                    result.Add(new DataDesc(kv.Key, new Shape(shape), kv.Value.DataType));
                }

                return result.ToArray();
            }
        }

        public override DataDesc[] ProvideLabel
        {
            get
            {
                List<DataDesc> result = new List<DataDesc>();
                foreach (var kv in label)
                {
                    var shape = kv.Value.Shape.Data.ToList();
                    shape.RemoveAt(0);
                    shape.Insert(0, BatchSize);
                    result.Add(new DataDesc(kv.Key, new Shape(shape), kv.Value.DataType));
                }

                return result.ToArray();
            }
        }

        public NDArrayIter(NDArray data, NDArray label = null, int batch_size = 1, bool shuffle = false,
                           string last_batch_handle = "pad", string data_name = "data", string label_name = "softmax_label")
            : this(new NDArray[] { data }, new NDArray[] { label }, batch_size, shuffle, last_batch_handle, data_name, label_name)
        {

        }

        public NDArrayIter(NDArray[] data, NDArray[] label = null, int batch_size = 1, bool shuffle = false,
                            string last_batch_handle = "pad", string data_name = "data", string label_name = "softmax_label")
        {
            this.data = IOUtils.InitData(data, false, data_name);
            this.label = IOUtils.InitData(label, false, label_name);
            this.BatchSize = batch_size;
            this.Cursor = batch_size;
            this.num_data = data[0].Shape[0];
            this.last_batch_handle = last_batch_handle;
            this.shuffle = shuffle;
            
            this.Reset();
            data_list.AddRange(data);
            data_list.AddRange(label);
            _cache_data = null;
            _cache_label = null;
        }

        public override NDArray[] GetData()
        {
            return _batchify(this.data);
        }

        public override int[] GetIndex()
        {
            return Enumerable.Range(0, this.data.Keys.Length).ToArray();
        }

        public override NDArray[] GetLabel()
        {
            return _batchify(this.label);
        }

        public override int GetPad()
        {
            if(last_batch_handle == "pad" && Cursor + BatchSize > num_data)
            {
                return Cursor + (int)BatchSize - (int)num_data;
            }
            else if(last_batch_handle == "roll_over" && ((int)-BatchSize < Cursor) && (Cursor < 0))
            {
                return -Cursor;
            }

            return 0;
        }

        public override bool IterNext()
        {
            Cursor += (int)BatchSize;
            return Cursor < num_data;
        }

        public override bool End()
        {
            return !(Cursor + BatchSize < num_data);
        }

        public override DataBatch Next()
        {
            if (!IterNext())
                throw new Exception("Stop Iteration");

            var d = this.GetData();
            var l = GetLabel();
            // iter should stop when last batch is not complete
            if (d[0].Shape[0] != BatchSize)
            {
                //in this case, cache it for next epoch
                _cache_data = d;
                _cache_label = l;
                throw new Exception("Stop Iteration");
            }


            return new DataBatch(data: d, label: l, pad: GetPad());
        }

        private void HardReset()
        {
            if (shuffle)
                ShuffleData();
            Cursor = (int)-BatchSize;
            _cache_data = null;
            _cache_label = null;
        }

        public override void Reset()
        {
            if (shuffle)
                ShuffleData();

            if (last_batch_handle == "roll_over" && (num_data - BatchSize < Cursor && Cursor < num_data)) // (self.cursor - self.num_data) represents the data we have for the last batch
                Cursor = (int)(Cursor - num_data - BatchSize);
            else
                Cursor = (int)-BatchSize;
        }

        public static NDArrayIter FromBatch(DataBatch data_batch)
        {
            var iter = new NDArrayIter(data_batch.Data, data_batch.Label);
            iter.DefaultBucketKey = data_batch.BucketKey.HasValue ? data_batch.BucketKey.Value : new Random().Next();
            return iter;
        }

        private void ShuffleData()
        {
            this.data = IOUtils.GetDataByIdx(data);
            this.label = IOUtils.GetDataByIdx(label);
        }

        private NDArray[] _getdata(NDArrayDict data_source, int? start= null, int? end= null)
        {
            if (!start.HasValue && !end.HasValue)
                throw new ArgumentException("Should atleast specify start or end");

            start = start.HasValue ? start : 0;
            end = end.HasValue ? end : (int)data_source.First().Value.Shape[0];

            List<NDArray> result = new List<NDArray>();
            foreach (var x in data_source)
            {
                result.Add(x.Value.Slice(start.Value, end));
            }

            return result.ToArray();
        }

        private NDArray[] _concat(NDArray[] first_data, NDArray[] second_data)
        {
            if (first_data.Length != second_data.Length)
                throw new Exception("Data source should be of same size.");

            List<NDArray> result = new List<NDArray>();
            for (int i = 0; i < first_data.Length; i++)
            {
                result.Add(
                    nd.Concat(new NDArray[] { first_data[i], second_data[i] }, 0)
                    );
            }

            return result.ToArray();
        }

        private NDArray[] _batchify(NDArrayDict data_source)
        {
            if (Cursor > num_data)
                throw new Exception("DataIter need reset");

            if(last_batch_handle == "roll_over" && ((int)-(BatchSize) < Cursor && Cursor < 0))
            {
                if (_cache_data == null && _cache_label == null)
                    throw new Exception("Next epoch should have cached data");

                var cache_data = this._cache_data != null ? this._cache_data : this._cache_label;
                var second_data = _getdata(data_source, end: Cursor + (int)BatchSize);
                if (_cache_data != null)
                    _cache_data = null;
                else
                    _cache_label = null;

                return _concat(cache_data, second_data);
            }
            else if (last_batch_handle == "pad" && (Cursor + (int)(BatchSize) > num_data))
            {
                var pad = BatchSize - num_data + Cursor;
                var first_data = _getdata(data_source, start: Cursor);
                var second_data = _getdata(data_source, end: (int)pad);
                return _concat(first_data, second_data);
            }
            else
            {
                int end_idx = 0;
                if (Cursor + BatchSize < num_data)
                {
                    end_idx = Cursor + (int)BatchSize;
                }
                else
                {
                    end_idx = (int)num_data;
                }

                return _getdata(data_source, Cursor, end_idx);
            }
        }
    }
}
