using System;
using MxNet.Interop;

// ReSharper disable once CheckNamespace
namespace MxNet
{
    public sealed class MXDataIterBlob : MXNetSharedObject
    {
        #region Methods

        #region Overrids

        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();
            if (Handle != IntPtr.Zero)
                NativeMethods.MXDataIterFree(Handle);
        }

        #endregion

        #endregion

        #region Constructors

        public MXDataIterBlob()
        {
        }

        public MXDataIterBlob(IntPtr handle)
        {
            Handle = handle;
        }

        #endregion
    }
}