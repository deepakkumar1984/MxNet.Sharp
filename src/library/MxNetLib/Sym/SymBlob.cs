using System;
using MxNetLib.Interop;

// ReSharper disable once CheckNamespace
namespace MxNetLib
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
            base.DisposeUnmanaged();

            if (this.NativePtr != IntPtr.Zero)
                NativeMethods.MXSymbolFree(this.NativePtr);
        }

        #endregion

        #endregion

    }
}
