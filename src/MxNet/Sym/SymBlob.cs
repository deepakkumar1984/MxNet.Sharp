using System;
using MxNet.Interop;

// ReSharper disable once CheckNamespace
namespace MxNet
{
    public sealed class SymBlob : DisposableMXNetObject
    {
        #region Properties

        public IntPtr Handle
        {
            get
            {
                ThrowIfDisposed();
                return NativePtr;
            }
        }

        #endregion

        #region Methods

        #region Overrides

        protected override void DisposeUnmanaged()
        {
            Dispose();

            if (NativePtr != IntPtr.Zero)
                NativeMethods.MXSymbolFree(NativePtr);
        }

        #endregion

        #endregion

        #region Constructors

        public SymBlob()
            : this(IntPtr.Zero)
        {
        }

        public SymBlob(IntPtr handle)
        {
            NativePtr = handle;
        }

        #endregion
    }
}