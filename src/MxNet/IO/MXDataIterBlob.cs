using System;
using MxNet.Interop;

// ReSharper disable once CheckNamespace
namespace MxNet
{

    public sealed class MXDataIterBlob : MXNetSharedObject
    {

        #region Constructors

        public MXDataIterBlob()
        {
        }

        public MXDataIterBlob(IntPtr handle)
        {
            this.Handle = handle;
        }

        #endregion

        #region Methods

        #region Overrids

        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();
            if (this.Handle != IntPtr.Zero)
                NativeMethods.MXDataIterFree(this.Handle);
        }

        #endregion

        #endregion
        
    }

}