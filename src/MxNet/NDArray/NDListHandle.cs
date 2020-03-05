using System;
using MxNet.Interop;

// ReSharper disable once CheckNamespace
namespace MxNet
{
    public sealed class NDListHandle : DisposableMXNetObject
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="NDListHandle" /> class.
        /// </summary>
        /// <param name="handle">The handle of the MXAPINDList.</param>
        internal NDListHandle(IntPtr handle)
        {
            NativePtr = handle;
        }

        #endregion

        #region Methods

        #region Overrides

        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();
            if (NativeMethods.MXNDListFree(NativePtr) == NativeMethods.Error)
                throw new ApplicationException($"Failed to release {nameof(NDListHandle)}");
        }

        #endregion

        #endregion
    }
}