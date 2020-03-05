using System;
using MxNet.Interop;

// ReSharper disable once CheckNamespace
namespace MxNet
{
    public sealed class NDBlob : DisposableMXNetObject
    {
        #region Properties

        public IntPtr Handle => NativePtr;

        #endregion

        #region Methods

        #region Overrides

        protected override void DisposeUnmanaged()
        {
            Dispose();
            NativeMethods.MXNDArrayFree(NativePtr);
        }

        #endregion

        #endregion

        #region Constructors

        public NDBlob()
            : this(IntPtr.Zero)
        {
        }

        public NDBlob(IntPtr handle)
        {
            NativePtr = handle;
        }

        ~NDBlob()
        {
            DisposeUnmanaged();
        }

        #endregion
    }
}