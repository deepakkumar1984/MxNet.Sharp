using MxNet.DotNet.Interop;
using System;

// ReSharper disable once CheckNamespace
namespace MxNet.DotNet
{

    public sealed partial class MXNet
    {

        #region Methods

        public SymbolOps sym = new SymbolOps();

        public static void MXNotifyShutdown()
        {
            Logging.CHECK_EQ(NativeMethods.MXNotifyShutdown(), NativeMethods.OK);
        }

        #endregion

    }

    public abstract class MXNetObject
    {

        #region Properties

        /// <summary>
        /// Native pointer of MXNet object
        /// </summary>
        public IntPtr NativePtr
        {
            get;
            protected set;
        }

        #endregion

    }

    public sealed class MXNetException : Exception
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MXNetException"/> class.
        /// </summary>
        public MXNetException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MXNetException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public MXNetException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MXNetException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The name of the parameter that caused the current exception.</param>
        public MXNetException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion

    }

    public abstract class MXNetSharedObject
    {

        #region Fields

        private int _RefCount = 1;

        #endregion

        #region Properties

        /// <summary>
        /// Native pointer of MXNet object
        /// </summary>
        public IntPtr Handle
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void AddRef()
        {
            this._RefCount++;
        }

        public void ReleaseRef()
        {
            this._RefCount--;

            if (this._RefCount == 0)
            {
                this.DisposeManaged();
                this.DisposeUnmanaged();
            }
        }

        #region Overrides

        protected virtual void DisposeManaged()
        {

        }

        protected virtual void DisposeUnmanaged()
        {

        }

        #endregion

        #endregion

    }
}
