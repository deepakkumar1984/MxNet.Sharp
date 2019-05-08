namespace MxNetLib.NN.EventArgs
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