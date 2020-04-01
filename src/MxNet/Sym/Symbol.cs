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
using System.Linq;
using System.Runtime.InteropServices;
using MxNet.Initializers;
using MxNet.Interop;
using MxNet.IO;
using mx_uint = System.UInt32;
using SymbolHandle = System.IntPtr;
using ExecutorHandle = System.IntPtr;

// ReSharper disable once CheckNamespace
namespace MxNet
{
    public class Symbol : DisposableMXNetObject
    {
        #region Fields

        #endregion

        #region Constructors

        public Symbol()
            : this(SymbolHandle.Zero)
        {
        }

        public Symbol(SymbolHandle handle)
        {
            NativePtr = handle;
        }

        public Symbol(string name)
        {
            if (NativeMethods.MXSymbolCreateVariable(name, out var @out) != NativeMethods.OK)
                throw new MXNetException($"Failed to create {nameof(Symbol)}");

            NativePtr = @out;
        }

        //public Symbol(string operatorName, 
        //              string name,
        //              IList<string> inputKeys,
        //              IList<SymbolHandle> inputValues,
        //              IList<string> configKeys,
        //              IList<string> configValues)
        //{
        //    if (inputKeys == null)
        //        throw new ArgumentNullException(nameof(inputKeys));
        //    if (inputValues == null)
        //        throw new ArgumentNullException(nameof(inputValues));
        //    if (configKeys == null)
        //        throw new ArgumentNullException(nameof(configKeys));
        //    if (configValues == null)
        //        throw new ArgumentNullException(nameof(configValues));

        //    var creator = OpMap.GetSymbolCreator(operatorName);
        //    NativeMethods.MXSymbolCreateAtomicSymbol(creator, 
        //                                             (uint)configKeys.Count,
        //                                             configKeys.ToArray(),
        //                                             configValues.ToArray(),
        //                                             out var handle);

        //    NativeMethods.MXSymbolCompose(handle, 
        //                                  operatorName,
        //                                  (uint)inputKeys.Count,
        //                                  inputKeys.ToArray(),
        //                                  inputValues.ToArray());

        //    blob_ptr_ = std::make_shared<SymBlob>(handle);
        //    this.NativePtr = @out;
        //}

        #endregion

        #region Properties

        public string Name
        {
            get
            {
                ThrowIfDisposed();
                if (NativePtr == SymbolHandle.Zero)
                    return null;

                NativeMethods.MXSymbolGetName(NativePtr, out var @out, out var success);
                if (@out == SymbolHandle.Zero)
                    return null;

                return Marshal.PtrToStringAnsi(@out);
            }
        }

        public Symbol this[int index]
        {
            get
            {
                ThrowIfDisposed();

                NativeMethods.MXSymbolGetOutput(NativePtr, (uint) index, out var @out);
                return new Symbol(@out);
            }
        }

        public Symbol this[string name]
        {
            get
            {
                var names = this.ListOutputs().ToList();
                ThrowIfDisposed();

                NativeMethods.MXSymbolGetOutput(NativePtr, (uint)names.IndexOf(name), out var @out);
                return new Symbol(@out);
            }
        }

        public Symbol this[int rowBegin, int rowEnd]
        {
            get
            {
                return sym.Slice(this, new Shape(rowBegin), new Shape(rowEnd));
            }
        }

        #endregion

        #region Methods

        public Executor Bind(Context context,
            NDArrayList argArrays,
            NDArrayList gradArrays,
            IList<OpGradReq> gradReqs,
            NDArrayList auxArrays)
        {
            return new Executor(this,
                context,
                argArrays,
                gradArrays,
                gradReqs,
                auxArrays,
                new Dictionary<string, Context>());
        }

        public Executor Bind(Context context,
            NDArrayList argArrays,
            NDArrayList gradArrays,
            IList<OpGradReq> gradReqs,
            NDArrayList auxArrays,
            IDictionary<string, Context> groupToCtx)
        {
            return new Executor(this,
                context,
                argArrays,
                gradArrays,
                gradReqs,
                auxArrays,
                groupToCtx,
                null);
        }

        public Executor Bind(Context context,
            NDArrayList argArrays,
            NDArrayList gradArrays,
            IList<OpGradReq> gradReqs,
            NDArrayList auxArrays,
            IDictionary<string, Context> groupToCtx,
            Executor sharedExec)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (argArrays == null)
                throw new ArgumentNullException(nameof(argArrays));
            if (gradArrays == null)
                throw new ArgumentNullException(nameof(gradArrays));
            if (gradReqs == null)
                throw new ArgumentNullException(nameof(gradReqs));
            if (auxArrays == null)
                throw new ArgumentNullException(nameof(auxArrays));
            if (groupToCtx == null)
                throw new ArgumentNullException(nameof(groupToCtx));

            return new Executor(this,
                context,
                argArrays,
                gradArrays,
                gradReqs,
                auxArrays,
                groupToCtx,
                sharedExec);
        }

        public SymbolHandle GetHandle()
        {
            ThrowIfDisposed();
            return NativePtr;
        }

        public static Symbol Group(SymbolList symbols)
        {
            var handleList = symbols.Select(symbol => symbol.GetHandle()).ToArray();
            NativeMethods.MXSymbolCreateGroup((uint) handleList.Length, handleList, out var @out);
            return new Symbol(@out);
        }

        public void InferArgsMap(Context context,
            NDArrayDict argsMap,
            NDArrayDict knownArgs)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (argsMap == null)
                throw new ArgumentNullException(nameof(argsMap));
            if (knownArgs == null)
                throw new ArgumentNullException(nameof(knownArgs));

            ThrowIfDisposed();

            var argShapes = new Dictionary<string, Shape>();

            var argNameList = ListArguments();
            foreach (var argName in argNameList)
                if (knownArgs[argName] != null)
                    argShapes[argName] = knownArgs[argName].Shape;

            var (inShapes, outShapes, auxShapes) = InferShape(argShapes);

            for (var i = 0; i < inShapes.Length; ++i)
            {
                var shape = inShapes[i];
                var argName = argNameList[i];
                if (knownArgs[argName] != null)
                {
                    argsMap[argName] = knownArgs[argName];
                }
                else
                {
                    var array = new NDArray(shape, false);
                    argsMap[argName] = array;
                    //NDArray.SampleGaussian(0, 1, array);
                    nd.Random.Uniform(0, 1, array.Shape).CopyTo(array);
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="argShapes"></param>
        /// <returns>Return arg_shapes, out_shapes, aux_shapes</returns>
        public (Shape[], Shape[], Shape[]) InferShape(Dictionary<string, Shape> argShapes)
        {
            if (argShapes == null)
                throw new ArgumentNullException(nameof(argShapes));

            var inShape = new List<Shape>();
            var auxShape = new List<Shape>();
            var outShape = new List<Shape>();

            ThrowIfDisposed();
            var argIndPtr = new List<int> {0};
            var argShapeData = new List<int>();

            foreach (var item in argShapes.Values)
            {
                foreach (var i in item.Data)
                {
                    if (i == 0)
                        continue;

                    argShapeData.Add(i);
                }

                argIndPtr.Add(argShapeData.Count);
            }

            unsafe
            {
                var keys = argShapes.Keys.ToArray();
                var argIndPtrArray = argIndPtr.ToArray();
                var argShapeDataArray = argShapeData.ToArray();
                {
                    int inShapeSize;
                    int* inShapeNdim;
                    int** inShapeData;

                    Logging.CHECK_EQ(NativeMethods.MXSymbolInferShapeEx(NativePtr,
                        (uint) argShapes.Count,
                        keys,
                        argIndPtrArray,
                        argShapeDataArray,
                        &inShapeSize,
                        &inShapeNdim,
                        &inShapeData,
                        out var outShapeSize,
                        out var outShapeNdim,
                        out var outShapeData,
                        out var auxShapeSize,
                        out var auxShapeNdim,
                        out var auxShapeData,
                        out var complete), NativeMethods.OK);

                    if (complete == 0)
                        return (null, null, null);

                    for (var i = 0; i < inShapeSize; ++i)
                    {
                        inShape.Add(new Shape());
                        for (var j = 0; j < inShapeNdim[i]; ++j)
                            inShape[i].Add(inShapeData[i][j]);
                    }

                    for (var i = 0; i < auxShapeSize; ++i)
                    {
                        auxShape.Add(new Shape());
                        for (var j = 0; j < auxShapeNdim[i]; ++j)
                            auxShape[i].Add(auxShapeData[i][j]);
                    }

                    for (var i = 0; i < outShapeSize; ++i)
                    {
                        outShape.Add(new Shape());
                        for (var j = 0; j < outShapeNdim[i]; ++j)
                            outShape[i].Add(outShapeData[i][j]);
                    }
                }
            }

            return (inShape.ToArray(), outShape.ToArray(), auxShape.ToArray());
        }

        public (Shape[], Shape[], Shape[]) InferShapePartial(Dictionary<string, Shape> argShapes)
        {
            if (argShapes == null)
                throw new ArgumentNullException(nameof(argShapes));

            var inShape = new List<Shape>();
            var auxShape = new List<Shape>();
            var outShape = new List<Shape>();

            ThrowIfDisposed();
            var argIndPtr = new List<int> {0};
            var argShapeData = new List<int>();

            foreach (var item in argShapes.Values)
            {
                foreach (var i in item.Data)
                {
                    if (i == 0)
                        continue;

                    argShapeData.Add(i);
                }

                argIndPtr.Add(argShapeData.Count);
            }

            unsafe
            {
                var keys = argShapes.Keys.ToArray();
                var argIndPtrArray = argIndPtr.ToArray();
                var argShapeDataArray = argShapeData.ToArray();
                {
                    int inShapeSize;
                    int* inShapeNdim;
                    int** inShapeData;

                    Logging.CHECK_EQ(NativeMethods.MXSymbolInferShapePartialEx(NativePtr,
                        (uint) argShapes.Count,
                        keys,
                        argIndPtrArray,
                        argShapeDataArray,
                        &inShapeSize,
                        &inShapeNdim,
                        &inShapeData,
                        out var outShapeSize,
                        out var outShapeNdim,
                        out var outShapeData,
                        out var auxShapeSize,
                        out var auxShapeNdim,
                        out var auxShapeData,
                        out var complete), NativeMethods.OK);

                    if (complete == 0)
                        return (null, null, null);

                    for (var i = 0; i < inShapeSize; ++i)
                    {
                        inShape.Add(new Shape());
                        for (var j = 0; j < inShapeNdim[i]; ++j)
                            inShape[i].Add(inShapeData[i][j]);
                    }

                    for (var i = 0; i < auxShapeSize; ++i)
                    {
                        auxShape.Add(new Shape());
                        for (var j = 0; j < auxShapeNdim[i]; ++j)
                            auxShape[i].Add(auxShapeData[i][j]);
                    }

                    for (var i = 0; i < outShapeSize; ++i)
                    {
                        outShape.Add(new Shape());
                        for (var j = 0; j < outShapeNdim[i]; ++j)
                            outShape[i].Add(outShapeData[i][j]);
                    }
                }
            }

            return (inShape.ToArray(), outShape.ToArray(), auxShape.ToArray());
        }

        public (DType[], DType[], DType[]) InferType(Dictionary<string, DType> argTypes = null)
        {
            if (argTypes == null)
                throw new ArgumentNullException(nameof(argTypes));

            var inType = new List<DType>();
            var auxType = new List<DType>();
            var outType = new List<DType>();

            ThrowIfDisposed();
            var argTypeData = argTypes.Values.Select(x => (x.Index)).ToList();

            unsafe
            {
                var keys = argTypes.Keys.ToArray();
                var argShapeDataArray = argTypeData.ToArray();
                {
                    int inShapeSize;
                    int* inShapeData;

                    Logging.CHECK_EQ(NativeMethods.MXSymbolInferType(NativePtr,
                        (uint)argTypes.Count,
                        keys,
                        argShapeDataArray,
                        &inShapeSize,
                        &inShapeData,
                        out var outShapeSize,
                        out var outShapeData,
                        out var auxShapeSize,
                        out var auxShapeData,
                        out var complete), NativeMethods.OK);

                    if (complete == 0)
                        return (null, null, null);

                    for (var i = 0; i < inShapeSize; ++i)
                        inType.Add(DType.GetType(inShapeData[i]));

                    for (var i = 0; i < auxShapeSize; ++i)
                        auxType.Add(DType.GetType(auxShapeData[i]));

                    for (var i = 0; i < outShapeSize; ++i)
                        outType.Add(DType.GetType(outShapeData[i]));
                }
            }

            return (inType.ToArray(), outType.ToArray(), auxType.ToArray());
        }

        public (DType[], DType[], DType[]) InferTypePartial(Dictionary<string, DType> argTypes = null)
        {
            if (argTypes == null)
                throw new ArgumentNullException(nameof(argTypes));

            var inType = new List<DType>();
            var auxType = new List<DType>();
            var outType = new List<DType>();

            ThrowIfDisposed();
            var argTypeData = argTypes.Values.Select(x => (x.Index)).ToList();

            unsafe
            {
                var keys = argTypes.Keys.ToArray();
                var argShapeDataArray = argTypeData.ToArray();
                {
                    int inShapeSize;
                    int* inShapeData;

                    Logging.CHECK_EQ(NativeMethods.MXSymbolInferTypePartial(NativePtr,
                        (uint)argTypes.Count,
                        keys,
                        argShapeDataArray,
                        &inShapeSize,
                        &inShapeData,
                        out var outShapeSize,
                        out var outShapeData,
                        out var auxShapeSize,
                        out var auxShapeData,
                        out var complete), NativeMethods.OK);

                    if (complete == 0)
                        return (null, null, null);

                    for (var i = 0; i < inShapeSize; ++i)
                        inType.Add(DType.GetType(inShapeData[i]));

                    for (var i = 0; i < auxShapeSize; ++i)
                        auxType.Add(DType.GetType(auxShapeData[i]));

                    for (var i = 0; i < outShapeSize; ++i)
                        outType.Add(DType.GetType(outShapeData[i]));
                }
            }

            return (inType.ToArray(), outType.ToArray(), auxType.ToArray());
        }

        public void InferExecutorArrays(Context context,
            NDArrayList argArrays,
            NDArrayList gradArrays,
            IList<OpGradReq> gradReqs,
            NDArrayList auxArrays,
            NDArrayDict argsMap)
        {
            InferExecutorArrays(context,
                argArrays,
                gradArrays,
                gradReqs,
                auxArrays,
                argsMap,
                new NDArrayDict());
        }

        public void InferExecutorArrays(Context context,
            NDArrayList argArrays,
            NDArrayList gradArrays,
            IList<OpGradReq> gradReqs,
            NDArrayList auxArrays,
            NDArrayDict argsMap,
            NDArrayDict argGradStore)
        {
            InferExecutorArrays(context,
                argArrays,
                gradArrays,
                gradReqs,
                auxArrays,
                argsMap,
                argGradStore,
                new Dictionary<string, OpGradReq>());
        }

        public void InferExecutorArrays(Context context,
            NDArrayList argArrays,
            NDArrayList gradArrays,
            IList<OpGradReq> gradReqs,
            NDArrayList auxArrays,
            NDArrayDict argsMap,
            NDArrayDict argGradStore,
            IDictionary<string, OpGradReq> gradReqType)
        {
            InferExecutorArrays(context,
                argArrays,
                gradArrays,
                gradReqs,
                auxArrays,
                argsMap,
                argGradStore,
                gradReqType,
                new NDArrayDict());
        }

        public void InferExecutorArrays(Context context,
            NDArrayList argArrays,
            NDArrayList gradArrays,
            IList<OpGradReq> gradReqs,
            NDArrayList auxArrays,
            NDArrayDict argsMap,
            NDArrayDict argGradStore,
            IDictionary<string, OpGradReq> gradReqType,
            NDArrayDict auxMap)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (argArrays == null)
                throw new ArgumentNullException(nameof(argArrays));
            if (gradArrays == null)
                throw new ArgumentNullException(nameof(gradArrays));
            if (gradReqs == null)
                throw new ArgumentNullException(nameof(gradReqs));
            if (auxArrays == null)
                throw new ArgumentNullException(nameof(auxArrays));
            if (argsMap == null)
                throw new ArgumentNullException(nameof(argsMap));
            if (argGradStore == null)
                throw new ArgumentNullException(nameof(argGradStore));
            if (gradReqType == null)
                throw new ArgumentNullException(nameof(gradReqType));
            if (auxMap == null)
                throw new ArgumentNullException(nameof(auxMap));

            ThrowIfDisposed();

            var argNameList = ListArguments();
            var argShapes = new Dictionary<string, Shape>();

            foreach (var argName in argNameList)
                if (argsMap[argName] != null)
                    argShapes[argName] = argsMap[argName].Shape;

            var (inShapes, auxShapes, outShapes) = InferShape(argShapes);

            for (var i = 0; i < inShapes.Length; ++i)
            {
                var shape = inShapes[i];
                var argName = argNameList[i];
                if (argsMap[argName] != null)
                {
                    argArrays.Add(argsMap[argName]);
                }
                else
                {
                    argArrays.Add(new NDArray(shape, false));
                    //NDArray.SampleGaussian(0, 1, argArrays.Last());
                    var argArr = argArrays.Last();
                    nd.Random.Uniform(0, 1, argArr.Shape).CopyTo(argArr);
                }

                if (argGradStore[argName] != null)
                    gradArrays.Add(argGradStore[argName]);
                else
                    gradArrays.Add(new NDArray(shape, false));

                if (gradReqType.TryGetValue(argName, out var value3))
                    gradReqs.Add(value3);
                else if (argName.LastIndexOf("data", StringComparison.InvariantCulture) == argName.Length - 4 ||
                         argName.LastIndexOf("label", StringComparison.InvariantCulture) == argName.Length - 5)
                    gradReqs.Add(OpGradReq.Null);
                else
                    gradReqs.Add(OpGradReq.Write);
            }

            var auxNameList = ListAuxiliaryStates();
            for (var i = 0; i < auxShapes.Length; ++i)
            {
                var shape = auxShapes[i];
                var auxName = auxNameList[i];
                if (auxMap[auxName] != null)
                {
                    auxArrays.Add(auxMap[auxName]);
                }
                else
                {
                    auxArrays.Add(new NDArray(shape, false));
                    var aux = auxArrays.Last();
                    //NDArray.SampleGaussian(0, 1, auxArrays.Last());
                    nd.Random.Uniform(0, 1, aux.Shape).CopyTo(aux);
                }
            }
        }

        public IList<string> ListArguments()
        {
            ThrowIfDisposed();

            NativeMethods.MXSymbolListArguments(GetHandle(), out var size, out var sarry);
            var sarryArray = InteropHelper.ToPointerArray(sarry, size);

            var ret = new string[size];
            for (var i = 0; i < size; i++)
                ret[i] = Marshal.PtrToStringAnsi(sarryArray[i]);

            return ret;
        }

        public Dictionary<string, Dictionary<string, string>> ListAttributeDict()
        {
            ThrowIfDisposed();

            NativeMethods.MXSymbolListAuxiliaryStates(GetHandle(), out var size, out var sarry);
            var sarryArray = InteropHelper.ToPointerArray(sarry, size);

            Dictionary<string, Dictionary<string, string>> ret = new Dictionary<string, Dictionary<string, string>>();
            for (var i = 0; i < size; i++)
            {
                string[] pair = Marshal.PtrToStringAnsi(sarryArray[i * 2]).Split('$');
                string name = pair[0];
                string key = pair[1];
                string val = Marshal.PtrToStringAnsi(sarryArray[i * 2 + 1]);
                if (!ret.ContainsKey(name))
                    ret.Add(name, new Dictionary<string, string>());

                ret[name][key] = val;
            }

            return ret;
        }

        public IList<string> ListAuxiliaryStates()
        {
            ThrowIfDisposed();

            NativeMethods.MXSymbolListAuxiliaryStates(GetHandle(), out var size, out var sarry);
            var sarryArray = InteropHelper.ToPointerArray(sarry, size);

            var ret = new string[size];
            for (var i = 0; i < size; i++)
                ret[i] = Marshal.PtrToStringAnsi(sarryArray[i]);

            return ret;
        }

        public IList<string> ListOutputs()
        {
            ThrowIfDisposed();

            NativeMethods.MXSymbolListOutputs(GetHandle(), out var size, out var sarry);
            var sarryArray = InteropHelper.ToPointerArray(sarry, size);
            var ret = new string[size];
            for (var i = 0; i < size; i++)
                ret[i] = Marshal.PtrToStringAnsi(sarryArray[i]);

            return ret;
        }

        public static Symbol Load(string fileName)
        {
            Logging.CHECK_EQ(NativeMethods.MXSymbolCreateFromFile(fileName, out var handle), NativeMethods.OK);
            return new Symbol(handle);
        }

        public static Symbol LoadJSON(string json)
        {
            Logging.CHECK_EQ(NativeMethods.MXSymbolCreateFromJSON(json, out var handle), NativeMethods.OK);
            return new Symbol(handle);
        }

        public void Save(string fileName, bool remove_amp_cast = true)
        {
            if (remove_amp_cast)
            {
                Logging.CHECK_EQ(NativeMethods.MXSymbolRemoveAmpCast(GetHandle(), out var h), NativeMethods.OK);
                Logging.CHECK_EQ(NativeMethods.MXSymbolSaveToFile(h, fileName), NativeMethods.OK);
            }
            else
            {
                Logging.CHECK_EQ(NativeMethods.MXSymbolSaveToFile(GetHandle(), fileName), NativeMethods.OK);
            }
        }

        public Symbol Shallowcopy()
        {
            return (Symbol)MemberwiseClone();
        }

        public Symbol Compose(SymbolDict kwargs, string name = "")
        {
            if (kwargs == null)
                throw new ArgumentNullException("kwargs");

            int num_args = kwargs.Count;
            NativeMethods.MXSymbolCompose(NativePtr, name, num_args, kwargs.Keys.ToArray(), kwargs.Values.Select(x => x.NativePtr).ToArray());
            return this;
        }

        public Executor SimpleBind(Context ctx, Dictionary<string, OpGradReq> grad_req = null, Dictionary<string, DType> type_dict = null, Dictionary<string, StorageStype> stype_dict = null, Dictionary<string, Context> group2ctx = null, string[] shared_arg_names = null, Executor shared_exec = null, NDArrayDict shared_buffer = null, DataDesc[] kwargs = null)
        {
            int num_provided_arg_types = 0;
            string[] provided_arg_type_names = null;
            int[] provided_arg_type_data = null;
            if (type_dict != null)
            {
                provided_arg_type_names = type_dict.Keys.ToArray();
                provided_arg_type_data = type_dict.Values.Select(x => x.Index).ToArray();
                num_provided_arg_types = type_dict.Count;
            }

            int num_provided_arg_stypes = 0;
            string[] provided_arg_stype_names = null;
            int[] provided_arg_stype_data = null;
            if (stype_dict != null)
            {
                provided_arg_stype_names = stype_dict.Keys.ToArray();
                provided_arg_stype_data = stype_dict.Values.Select(x => (int)x).ToArray();
                num_provided_arg_stypes = stype_dict.Count;
            }

            List<int> provided_arg_shape_data = new List<int>();
            List<int> provided_arg_shape_idx = new List<int>() { 0 };
            List<string> provided_arg_shape_names = new List<string>();
            foreach (var desc in kwargs)
            {
                provided_arg_shape_names.Add(desc.Name);
                provided_arg_shape_data.AddRange(desc.Shape.Data.Where(x => x > 0).ToList());
                provided_arg_shape_idx.Add(provided_arg_shape_data.Count);
            }

            int provided_req_type_list_len = 0;
            string[] provided_grad_req_names = new string[0];
            string[] provided_grad_req_types = new string[0];
            if (grad_req != null)
            {
                provided_grad_req_names = grad_req.Keys.ToArray();
                provided_grad_req_types = grad_req.Values.Select(x => Enum.GetName(x.GetType(), x).ToLower()).ToArray();
                provided_req_type_list_len = grad_req.Count;
            }

            int num_ctx_map_keys = 0;
            string[] ctx_map_keys = new string[0];
            int[] ctx_map_dev_types = new int[0];
            int[] ctx_map_dev_ids = new int[0];
            if (group2ctx != null)
            {
                ctx_map_keys = group2ctx.Keys.ToArray();
                ctx_map_dev_types = group2ctx.Values.Select(x => (int)x.GetDeviceType()).ToArray();
                ctx_map_dev_ids = group2ctx.Values.Select(x => x.GetDeviceId()).ToArray();
                num_ctx_map_keys = group2ctx.Count;
            }

            string[] shared_arg_name_list = new string[0];
            if (shared_arg_names != null)
                shared_arg_name_list = shared_arg_names;

            unsafe
            {
                int shared_start = -1;
                int shared_buffer_len = shared_start;
                string[] shared_buffer_names = null;
                IntPtr[] shared_buffer_handles = null;
                if (shared_buffer.Count > 0)
                {
                    shared_buffer_len = shared_buffer.Count;
                    shared_buffer_names = shared_buffer.Keys;
                    shared_buffer_handles = shared_buffer.Values.Handles;
                }

                var shared_exec_handle = shared_exec != null ? shared_exec.Handle : new ExecutorHandle();

                char** updated_shared_buffer_names;
                SymbolHandle* updated_shared_buffer_handles;
                int num_in_args;
                SymbolHandle* in_arg_handles;
                SymbolHandle* arg_grad_handles;
                SymbolHandle* aux_state_handles;
                ExecutorHandle exe_handle;
                int num_aux_states;

                NativeMethods.MXExecutorSimpleBindEx(NativePtr, (int)ctx.GetDeviceType(), ctx.GetDeviceId(), num_ctx_map_keys, ctx_map_keys,
                                                    ctx_map_dev_types, ctx_map_dev_ids, provided_req_type_list_len, provided_grad_req_names, provided_grad_req_types,
                                                    provided_arg_shape_names.Count, provided_arg_shape_names.ToArray(), provided_arg_shape_data.ToArray(),
                                                    provided_arg_shape_idx.ToArray(), num_provided_arg_types, provided_arg_type_names, provided_arg_type_data,
                                                    num_provided_arg_stypes, provided_arg_stype_names, provided_arg_stype_data, shared_arg_name_list.Length,
                                                    shared_arg_name_list, &shared_buffer_len, shared_buffer_names, shared_buffer_handles, &updated_shared_buffer_names,
                                                    &updated_shared_buffer_handles, &num_in_args, &in_arg_handles, &arg_grad_handles,
                                                    &num_aux_states, &aux_state_handles, shared_exec_handle, &exe_handle);

                if (shared_buffer.Count > 0)
                {
                    int l = shared_buffer_len;
                    for (int i = 0; i < l; i++)
                    {
                        string k = new string(updated_shared_buffer_names[i]);
                        NDArray v = new NDArray(updated_shared_buffer_handles[i]);
                        shared_buffer[k] = v;
                    }
                }

                NDArrayList arg_arrays = new NDArrayList();
                for (int i = 0; i < num_in_args; i++)
                {
                    arg_arrays.Add(new NDArray(in_arg_handles[i]));
                }

                NDArrayList grad_arrays = new NDArrayList();
                for (int i = 0; i < num_in_args; i++)
                {
                    if (arg_grad_handles[i] == IntPtr.Zero)
                        continue;
                    grad_arrays.Add(new NDArray(arg_grad_handles[i]));
                }

                NDArrayList aux_arrays = new NDArrayList();
                for (int i = 0; i < num_aux_states; i++)
                {
                    aux_arrays.Add(new NDArray(aux_state_handles[i]));
                }

                var executor = new Executor(exe_handle, ctx, grad_req.Values.ToList(), group2ctx);
                executor.ArgmentArrays = arg_arrays;
                executor.GradientArrays = grad_arrays;
                executor.AuxiliaryArrays = aux_arrays;
                executor._Symbol = this;
                return executor;
            }
        }

        public string ToJSON()
        {
            Logging.CHECK_EQ(NativeMethods.MXSymbolSaveToJSON(GetHandle(), out var outJson), NativeMethods.OK);
            return Marshal.PtrToStringAnsi(outJson);
        }

        public static Symbol Variable(string name)
        {
            return Var(name);
        }

        public static Symbol Var(string name, Dictionary<string, string> attr = null, Shape shape = null,
            float? lr_mult = null, float? wd_mult = null,
            DType dtype = null, Initializer init = null, StorageStype? stype = null)
        {
            NativeMethods.MXSymbolCreateVariable(name, out var handle);
            var ret = new Symbol(handle);
            if (attr == null)
                attr = new Dictionary<string, string>();

            if (shape != null)
                attr.Add("__shape__", shape.ToString());

            if (lr_mult.HasValue)
                attr.Add("__lr_mult__", lr_mult.Value.ToString());

            if (wd_mult.HasValue)
                attr.Add("__wd_mult__", wd_mult.Value.ToString());

            if (dtype != null)
                attr.Add("__dtype__", dtype.Name);

            if (init != null)
            {
                var init_string = init.Dumps();
                attr.Add("__init__", init_string);
            }

            if (stype.HasValue)
                attr.Add("__storage_type__", ((int) stype).ToString());

            ret.SetAttr(attr);

            return ret;
        }

        public string Attr(string key)
        {
            NativeMethods.MXSymbolGetAttr(GetHandle(), key, out var @out, out var success);
            if (success != 0)
                return @out;

            return null;
        }

        public Dictionary<string, string> ListAttr()
        {
            NativeMethods.MXSymbolListAttrShallow(GetHandle(), out var out_size, out var pairs);

            var dict = new Dictionary<string, string>();
            var i = 0;
            while (i < out_size) dict[pairs[i * 2]] = pairs[i * 2 + 1];

            return dict;
        }

        public Dictionary<string, Dictionary<string, string>> AttrDict()
        {
            NativeMethods.MXSymbolListAttr(GetHandle(), out var out_size, out var sarray);
            var array = InteropHelper.ToPointerArray(sarray, out_size);
            List<string> pairs = array.Select(x => (Marshal.PtrToStringAnsi(x))).ToList();
            var dict = new Dictionary<string, Dictionary<string, string>>();
            var i = 0;
            while (i < out_size)
            {
                var keys = pairs[i].Split('$');
                if(!dict.ContainsKey(keys[0]))
                    dict[keys[0]] = new Dictionary<string, string>();
                if ((i + 1) != pairs.Count) 
                    dict[keys[0]][keys[1]] = pairs[i + 1];
                i = i + 2;
            }

            return dict;
        }

        public void SetAttr(Dictionary<string, string> attrs)
        {
            foreach (var attr in attrs) NativeMethods.MXSymbolSetAttr(GetHandle(), attr.Key, attr.Value);
        }

        public virtual Symbol Reshape(Shape shape, bool reverse = false)
        {
            return sym.Reshape(this, shape, reverse);
        }

        public virtual Symbol SliceAxis(int axis, int begin, int? end)
        {
            return sym.SliceAxis(this, axis, begin, end);
        }

        public virtual Symbol ExpandDims(int axis)
        {
            return sym.ExpandDims(this, axis);
        }

        public virtual Symbol Tile(Shape reps)
        {
            return sym.Tile(this, reps);
        }

        public virtual Symbol Squeeze(int axis)
        {
            return sym.Squeeze(this, new Shape(axis));
        }

        public virtual Symbol Transpose()
        {
            return sym.Transpose(this);
        }

        public virtual Symbol Transpose(Shape axes)
        {
            return sym.Transpose(this, axes);
        }

        public virtual Symbol Prod()
        {
            return sym.Prod(this);
        }

        public virtual Symbol Mean(int axis)
        {
            return sym.Mean(this, axis);
        }

        public virtual Symbol AsType(DType dtype)
        {
            return sym.Cast(this, dtype);
        }

        public virtual Symbol Reshape(params int[] shape)
        {
            //int[] targetShape = new int[shape.Length];
            //long prod = -1 * shape.Aggregate(1L, (a, b) => a * b);
            //for (int i = 0; i < targetShape.Length; i++)
            //{
            //    if (shape[i] > 0)
            //    {
            //        targetShape[i] = shape[i];
            //    }
            //    else
            //    {
            //        targetShape[i] = Size / (int)prod;
            //    }
            //}

            return Reshape(new Shape(shape));
        }

        #region Overrides

        #region Operators

        public static Symbol operator +(Symbol lhs, Symbol rhs)
        {
            if (lhs == null)
                throw new ArgumentNullException(nameof(lhs));
            if (rhs == null)
                throw new ArgumentNullException(nameof(rhs));

            lhs.ThrowIfDisposed();
            rhs.ThrowIfDisposed();

            return OperatorSupply.Plus(lhs, rhs);
        }

        public static Symbol operator -(Symbol lhs, Symbol rhs)
        {
            if (lhs == null)
                throw new ArgumentNullException(nameof(lhs));
            if (rhs == null)
                throw new ArgumentNullException(nameof(rhs));

            lhs.ThrowIfDisposed();
            rhs.ThrowIfDisposed();

            return OperatorSupply.Minus(lhs, rhs);
        }

        public static Symbol operator *(Symbol lhs, Symbol rhs)
        {
            if (lhs == null)
                throw new ArgumentNullException(nameof(lhs));
            if (rhs == null)
                throw new ArgumentNullException(nameof(rhs));

            lhs.ThrowIfDisposed();
            rhs.ThrowIfDisposed();

            return OperatorSupply.Mul(lhs, rhs);
        }

        public static Symbol operator /(Symbol lhs, Symbol rhs)
        {
            if (lhs == null)
                throw new ArgumentNullException(nameof(lhs));
            if (rhs == null)
                throw new ArgumentNullException(nameof(rhs));

            lhs.ThrowIfDisposed();
            rhs.ThrowIfDisposed();

            return OperatorSupply.Div(lhs, rhs);
        }

        public static Symbol operator %(Symbol lhs, Symbol rhs)
        {
            if (lhs == null)
                throw new ArgumentNullException(nameof(lhs));
            if (rhs == null)
                throw new ArgumentNullException(nameof(rhs));

            lhs.ThrowIfDisposed();
            rhs.ThrowIfDisposed();

            return OperatorSupply.Mod(lhs, rhs);
        }

        public static Symbol operator +(Symbol lhs, float scalar)
        {
            if (lhs == null)
                throw new ArgumentNullException(nameof(lhs));

            lhs.ThrowIfDisposed();

            return OperatorSupply.PlusScalar(lhs, scalar);
        }

        public static Symbol operator +(float lhs, Symbol rhs)
        {
            return rhs + lhs;
        }

        public static Symbol operator -(Symbol lhs, float scalar)
        {
            if (lhs == null)
                throw new ArgumentNullException(nameof(lhs));

            lhs.ThrowIfDisposed();

            return OperatorSupply.MinusScalar(lhs, scalar);
        }

        public static Symbol operator -(float lhs, Symbol rhs)
        {
            if (rhs == null)
                throw new ArgumentNullException(nameof(rhs));

            rhs.ThrowIfDisposed();

            return OperatorSupply.RMinusScalar(lhs, rhs);
        }

        public static Symbol operator *(Symbol lhs, float scalar)
        {
            if (lhs == null)
                throw new ArgumentNullException(nameof(lhs));

            lhs.ThrowIfDisposed();

            return OperatorSupply.MulScalar(lhs, scalar);
        }

        public static Symbol operator *(float lhs, Symbol rhs)
        {
            return rhs * lhs;
        }

        public static Symbol operator /(Symbol lhs, float scalar)
        {
            if (lhs == null)
                throw new ArgumentNullException(nameof(lhs));

            lhs.ThrowIfDisposed();

            return OperatorSupply.DivScalar(lhs, scalar);
        }

        public static Symbol operator /(float lhs, Symbol rhs)
        {
            if (rhs == null)
                throw new ArgumentNullException(nameof(rhs));

            rhs.ThrowIfDisposed();

            return OperatorSupply.RDivScalar(lhs, rhs);
        }

        public static Symbol operator %(Symbol lhs, float scalar)
        {
            if (lhs == null)
                throw new ArgumentNullException(nameof(lhs));

            lhs.ThrowIfDisposed();

            return OperatorSupply.ModScalar(lhs, scalar);
        }

        public static Symbol operator %(float lhs, Symbol rhs)
        {
            if (rhs == null)
                throw new ArgumentNullException(nameof(rhs));

            rhs.ThrowIfDisposed();

            return OperatorSupply.RModScalar(lhs, rhs);
        }

        public static Symbol operator >(Symbol lhs, Symbol rhs)
        {
            return sym.BroadcastGreater(lhs, rhs);
        }

        public static Symbol operator >=(Symbol lhs, Symbol rhs)
        {
            return sym.BroadcastGreaterEqual(lhs, rhs);
        }

        public static Symbol operator >(Symbol lhs, float rhs)
        {
            return sym.GreaterScalar(lhs, rhs);
        }

        public static Symbol operator >=(Symbol lhs, float rhs)
        {
            return sym.GreaterEqualScalar(lhs, rhs);
        }

        public static Symbol operator >(float lhs, Symbol rhs)
        {
            return sym.GreaterScalar(rhs, lhs);
        }

        public static Symbol operator >=(float lhs, Symbol rhs)
        {
            return sym.GreaterEqualScalar(rhs, lhs);
        }

        public static Symbol operator <(Symbol lhs, Symbol rhs)
        {
            return sym.BroadcastLesser(lhs, rhs);
        }

        public static Symbol operator <=(Symbol lhs, Symbol rhs)
        {
            return sym.BroadcastLesserEqual(lhs, rhs);
        }

        public static Symbol operator <(Symbol lhs, float rhs)
        {
            return sym.LesserScalar(lhs, rhs);
        }

        public static Symbol operator <=(Symbol lhs, float rhs)
        {
            return sym.LesserEqualScalar(lhs, rhs);
        }

        public static Symbol operator <(float lhs, Symbol rhs)
        {
            return sym.LesserScalar(rhs, lhs);
        }

        public static Symbol operator <=(float lhs, Symbol rhs)
        {
            return sym.LesserEqualScalar(rhs, lhs);
        }

        #endregion

        #endregion

        #region Overrides

        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();
            NativeMethods.MXSymbolFree(NativePtr);
        }

        #endregion

        #endregion
    }
}