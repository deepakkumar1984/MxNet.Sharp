// ReSharper disable once CheckNamespace
namespace MxNet.IO
{

    public abstract class DataIter : DisposableMXNetObject
    {
        public int BatchSize { get; set; }

        public virtual DataDesc[] ProvideData { get; }

        public virtual DataDesc[] ProvideLabel { get; set; }

        public int DefaultBucketKey { get; set; }

        public int Cursor { get; set; }

        public DataIter(int batch_size = 0)
        {
            BatchSize = batch_size;
        }

        public abstract NDArray[] GetData();

        public abstract NDArray[] GetLabel();

        public abstract int[] GetIndex();

        public abstract int GetPad();

        public abstract void Reset();

        public abstract bool IterNext();

        public abstract bool End();

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