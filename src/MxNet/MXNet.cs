/*****************************************************************************
   Copyright 2018 The MxNet.Sharp Authors. All Rights Reserved.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using MxNet.Interop;

// ReSharper disable once CheckNamespace
namespace MxNet
{
    public sealed partial class mx
    {
        private static readonly string[] DllWhiteList =
            {"libgcc_s_seh-1.dll", "libgfortran-3.dll", "libquadmath-0.dll", "libopenblas.dll", "libmxnet.dll"};

        public static string AppPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MxNet");

        #region Methods

        public static Context Device { get; set; }

        public static List<Context> MultiDevice { get; set; }

        public static bool UseCudnn { get; set; }

        public static void SetDevice(DeviceType device, params int[] deviceIds)
        {
            MultiDevice = new List<Context>();
            if (deviceIds.Length > 0)
            {
                for (var i = 0; i < deviceIds.Length; i++) MultiDevice.Add(Context.Gpu(deviceIds[i]));

                Device = MultiDevice[0];
            }
            else
            {
                if (device == DeviceType.CPU)
                    Device = Context.Cpu();
                else if (device == DeviceType.GPU)
                    Device = Context.Gpu();
            }
        }

        public static void SetMxNetPath(string mxnetFolder)
        {
            Environment.SetEnvironmentVariable("MXNET_LIBRARY_PATH", mxnetFolder);
            var dlls = Directory.EnumerateFiles(mxnetFolder).Select(Path.GetFileName).ToList();

            foreach (var dllName in DllWhiteList)
                if (dlls.Contains(dllName))
                    NativeMethods.LoadLibrary(Path.Combine(mxnetFolder, dllName));
        }

        public static void MXNotifyShutdown()
        {
            Logging.CHECK_EQ(NativeMethods.MXNotifyShutdown(), NativeMethods.OK);
        }

        public static string Version()
        {
            Logging.CHECK_EQ(NativeMethods.MXGetVersion(out int version), NativeMethods.OK);
            string ver_string = Math.Round(((float)version / 1000) - 9, 2).ToString();

            return ver_string;
        }

        public static Context Cpu(int id = 0) => Context.Cpu(id);

        public static Context Gpu(int id = 0) => Context.Gpu(id);

        public static void Seed(int seed, Context ctx = null)
        {
            if (ctx == null)
                NativeMethods.MXRandomSeed(seed);
            else
                NativeMethods.MXRandomSeedContext(seed, (int)ctx.GetDeviceType(), ctx.GetDeviceId());
        }

        public static string[] GetAllRegisteredCApiOperators()
        {
            List<string> methods = new List<string>();

            int r = NativeMethods.MXSymbolListAtomicSymbolCreators(out uint numSymbolCreators, out IntPtr symbolCreatorsPtr);
            IntPtr[] symbolCreators = new IntPtr[numSymbolCreators];
            Marshal.Copy(symbolCreatorsPtr, symbolCreators, 0, (int)numSymbolCreators);

            for (int i = 0; i < numSymbolCreators; i++)
            {
                IntPtr returnTypePtr = new IntPtr();
                
                r = NativeMethods.MXSymbolGetAtomicSymbolInfo(symbolCreators[i],
                out IntPtr namePtr,
                out IntPtr descriptionPtr,
                out uint numArgs,
                out IntPtr argNamesPtr,
                out IntPtr argTypeInfosPtr,
                out IntPtr argDescriptionsPtr,
                out IntPtr keyVarNumArgsPtr,
                ref returnTypePtr);
                string name = Marshal.PtrToStringAnsi(namePtr);
                if (name == null)
                {
                    Console.WriteLine($"error namePtr {i}");
                    continue; ;
                }

                if (name.ToLower().Contains("backward"))
                    continue;

                methods.Add(name);
                string description = Marshal.PtrToStringAnsi(descriptionPtr);

                IntPtr[] argNamesArray = new IntPtr[numArgs];
                IntPtr[] argTypeInfosArray = new IntPtr[numArgs];
                IntPtr[] argDescriptionsArray = new IntPtr[numArgs];
                if (numArgs > 0)
                {
                    Marshal.Copy(argNamesPtr, argNamesArray, 0, (int)numArgs);
                    Marshal.Copy(argTypeInfosPtr, argTypeInfosArray, 0, (int)numArgs);
                    Marshal.Copy(argDescriptionsPtr, argDescriptionsArray, 0, (int)numArgs);

                }

                List<string> args = new List<string>();
                for (int j = 0; j < numArgs; j++)
                {
                    string descriptions = Marshal.PtrToStringAnsi(argDescriptionsArray[j]);
                    if (descriptions == null || descriptions.Contains("Deprecated"))
                    {
                        continue;
                    }

                    //MxOpArg arg = new MxOpArg(name,
                    //    Marshal.PtrToStringAnsi(argNamesArray[j]),
                    //    Marshal.PtrToStringAnsi(argTypeInfosArray[j]),
                    //    descriptions
                    //    );

                    //args.Add(arg);
                }

                //ops.Add(new MxOp(name, description, args));
            }

            return methods.ToArray();
        }

        public static string[] GetAllRegisteredOperators()
        {
            int r = NativeMethods.MXListAllOpNames(out uint numSymbolCreators, out IntPtr symbolCreatorsPtr);
            IntPtr[] symbolCreators = new IntPtr[numSymbolCreators];
            Marshal.Copy(symbolCreatorsPtr, symbolCreators, 0, (int)numSymbolCreators);
            return symbolCreators.Select(x => Marshal.PtrToStringAnsi(x)).ToArray();
        }

        #endregion
    }

    public abstract class MXNetObject
    {
        #region Properties

        /// <summary>
        ///     Native pointer of MXNet object
        /// </summary>
        public IntPtr NativePtr { get; internal set; }

        #endregion
    }

    public sealed class MXNetException : Exception
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MXNetException" /> class.
        /// </summary>
        public MXNetException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MXNetException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public MXNetException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MXNetException" /> class with a specified error message and a
        ///     reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The name of the parameter that caused the current exception.</param>
        public MXNetException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion
    }

    public sealed class StopIteration : Exception
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MXNetException" /> class.
        /// </summary>
        public StopIteration()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MXNetException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public StopIteration(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MXNetException" /> class with a specified error message and a
        ///     reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The name of the parameter that caused the current exception.</param>
        public StopIteration(string message, Exception innerException)
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
        ///     Native pointer of MXNet object
        /// </summary>
        public IntPtr Handle { get; set; }

        #endregion

        #region Methods

        public void AddRef()
        {
            _RefCount++;
        }

        public void ReleaseRef()
        {
            _RefCount--;

            if (_RefCount == 0)
            {
                DisposeManaged();
                DisposeUnmanaged();
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