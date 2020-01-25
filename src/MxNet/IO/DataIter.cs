// ReSharper disable once CheckNamespace
namespace MxNet.IO
{

    public abstract class DataIter : DisposableMXNetObject
    {
        public uint BatchSize { get; set; }

        public DataDesc[] ProvideData { get; set; }

        public DataDesc[] ProvideLabel { get; set; }

        public int DefaultBucketKey { get; set; }

        public DataIter(uint batch_size = 0)
        {
            BatchSize = batch_size;
        }

        public abstract NDArray[] GetData();

        public abstract NDArray[] GetLabel();

        public abstract int[] GetIndex();

        public abstract int GetPad();

        public abstract void Reset();

        public abstract bool IterNext();

        public virtual DataBatch Next()
        {
            if(IterNext())
            {
                return new DataBatch(GetData(), GetLabel(), GetPad(), GetIndex());
            }
            else
            {
                throw new MXNetException("Stop Iteration");
            }
        }
    }
}