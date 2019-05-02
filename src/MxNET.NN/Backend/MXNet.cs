using MxNet.NN.Backend.Interop;

// ReSharper disable once CheckNamespace
namespace MxNet.NN.Backend
{

    public sealed partial class MXNet
    {

        #region Methods

        public static void MXNotifyShutdown()
        {
            Logging.CHECK_EQ(NativeMethods.MXNotifyShutdown(), NativeMethods.OK);
        }

        #endregion

    }

}
