namespace MxNet.Callbacks
{
    public interface IIterEndCallback
    {
        void Invoke(int epoch);
    }
}