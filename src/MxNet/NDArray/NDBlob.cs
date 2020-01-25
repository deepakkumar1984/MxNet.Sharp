using System;
using MxNet.Interop;

// ReSharper disable once CheckNamespace
namespace MxNet
{

    public sealed class NDBlob : DisposableMXNetObject
    {

        #region Constructors

        public NDBlob()
            : this(IntPtr.Zero)
        {
        }

        public NDBlob(IntPtr handle)
        {
            this.NativePtr = handle;
        }

        ~NDBlob()
        {
            DisposeUnmanaged();
        }

        #endregion

        #region Properties

        public IntPtr Handle => this.NativePtr;

        #endregion

        #region Methods

        #region Overrides

        protected override void DisposeUnmanaged()
        {
            base.Dispose();
            NativeMethods.MXNDArrayFree(this.NativePtr);
        }

        #endregion

        #endregion

    }

}