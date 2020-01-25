using System;
using MxNet.Interop;

// ReSharper disable once CheckNamespace
namespace MxNet
{

    public sealed class SymBlob : DisposableMXNetObject
    {

        #region Constructors

        public SymBlob()
            : this(IntPtr.Zero)
        {
        }

        public SymBlob(IntPtr handle)
        {
            this.NativePtr = handle;
        }

        #endregion

        #region Properties

        public IntPtr Handle
        {
            get
            {
                this.ThrowIfDisposed();
                return this.NativePtr;
            }
        }

        #endregion

        #region Methods

        #region Overrides

        protected override void DisposeUnmanaged()
        {
            base.Dispose();

            if (this.NativePtr != IntPtr.Zero)
                NativeMethods.MXSymbolFree(this.NativePtr);
        }

        #endregion

        #endregion

    }
}
