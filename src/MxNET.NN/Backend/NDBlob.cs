using System;
using MxNet.NN.Backend.Interop;

// ReSharper disable once CheckNamespace
namespace MxNet.NN.Backend
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

        #endregion

        #region Properties

        public IntPtr Handle => this.NativePtr;

        #endregion

        #region Methods

        #region Overrides

        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();
            NativeMethods.MXNDArrayFree(this.NativePtr);
        }

        #endregion

        #endregion

    }

}