using MxNetLib.Interop;

namespace MxNetLib.Extensions
{

    internal static class NatoveMethodsExtensions
    {

        public static int ToInt32(this bool source)
        {
            return source ? NativeMethods.TRUE : NativeMethods.FALSE;
        }

    }

}
