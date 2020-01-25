namespace MxNet.EventArgs
{
    public class EpochStartEventArgs : System.EventArgs
    {
        public EpochStartEventArgs(uint epoch)
        {
            Epoch = epoch;
        }

        public uint Epoch { get; }
    }
}