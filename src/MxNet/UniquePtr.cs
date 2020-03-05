using System;

// ReSharper disable once CheckNamespace
namespace MxNet
{
    public sealed class UniquePtr<T> : IDisposable
    {
        #region Constructors

        public UniquePtr(T obj)
        {
            Ptr = obj;
        }

        #endregion

        #region Methods

        public static void Move(UniquePtr<T> source, out UniquePtr<T> target)
        {
            target = new UniquePtr<T>(source.Ptr);

            source.IsOwner = false;
            target.IsOwner = true;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets a value indicating whether this object is already disposed.
        /// </summary>
        public bool IsDisposed { get; private set; }

        public bool IsOwner { get; private set; } = true;

        public T Ptr { get; }

        #endregion

        #region IDisposable Members

        /// <summary>
        ///     Releases all resources used by this <see cref="DisposableMXNetObject" />.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        /// <summary>
        ///     Releases all resources used by this <see cref="DisposableMXNetObject" />.
        /// </summary>
        /// <param name="disposing">Indicate value whether <see cref="IDisposable.Dispose" /> method was called.</param>
        private void Dispose(bool disposing)
        {
            if (IsDisposed) return;

            IsDisposed = true;

            if (disposing)
                if (IsOwner)
                    (Ptr as IDisposable)?.Dispose();
        }

        #endregion
    }
}