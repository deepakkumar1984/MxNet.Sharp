using MxNetLib.Interop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace MxNetLib
{

    public sealed partial class MXNet
    {
        private static readonly string[] DllWhiteList = new[] { "libgcc_s_seh-1.dll", "libgfortran-3.dll", "libquadmath-0.dll", "libopenblas.dll", "libmxnet.dll" };

        #region Methods
        public static Context Device { get; set; }

        public static List<Context> MultiDevice { get; set; }

        public static bool UseCudnn { get; set; }

        public static void SetDevice(DeviceType device, params int[] deviceIds)
        {
            MultiDevice = new List<Context>();
            if (deviceIds.Length > 0)
            {
                for (int i = 0; i < deviceIds.Length; i++)
                {
                    MultiDevice.Add(Context.Gpu(deviceIds[i]));
                }

                Device = MultiDevice[0];
            }
            else
            {
                if (device == DeviceType.CPU)
                    Device = Context.Cpu();
                else if (device == DeviceType.CPU)
                {
                    Device = Context.Gpu();
                }
            }
        }

        public static void SetMxNetPath(string mxnetFolder)
        {
            Environment.SetEnvironmentVariable("MXNET_LIBRARY_PATH", mxnetFolder);
            var dlls = Directory.EnumerateFiles(mxnetFolder).Select(Path.GetFileName).ToList();
            
            foreach (var dllName in DllWhiteList)
            {
                if (dlls.Contains(dllName))
                {
                    NativeMethods.LoadLibrary(Path.Combine(mxnetFolder, dllName));
                }

            }
        }

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
