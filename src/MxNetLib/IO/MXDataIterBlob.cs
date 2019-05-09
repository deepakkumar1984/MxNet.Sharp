using System;
using MxNetLib.Interop;

// ReSharper disable once CheckNamespace
namespace MxNetLib
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