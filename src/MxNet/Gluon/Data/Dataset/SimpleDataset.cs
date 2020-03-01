namespace MxNet.Gluon.Data
{
    internal class SimpleDataset<T> : Dataset<T>
    {
        private T[] _data;

        public SimpleDataset(params T[] data) : base(data)
        {
        }

        public override T this[int idx] => Data[idx];

        public override int Length => Data.Length;
    }
}