using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using MxNet.Interop;
using mx_uint = System.UInt32;
using SymbolHandle = System.IntPtr;

// ReSharper disable once CheckNamespace
namespace MxNet
{

    public class Symbol : DisposableMXNetObject
    {

        #region Fields

        
        #endregion

        #region Constructors

        static Symbol()
        {
        }

        public Symbol()
            : this(IntPtr.Zero)
        {
        }

        public Symbol(IntPtr handle)
        {
            this.NativePtr = handle;
        }

        public Symbol(string name)
        {
            if (NativeMethods.MXSymbolCreateVariable(name, out var @out) != NativeMethods.OK)
                throw new MXNetException($"Failed to create {nameof(Symbol)}");

            this.NativePtr = @out;
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
                this.ThrowIfDisposed();
                if (this.NativePtr == IntPtr.Zero)
                    return null;

                NativeMethods.MXSymbolGetName(this.NativePtr, out var @out, out var success);
                if (@out == IntPtr.Zero)
                    return null;

                return Marshal.PtrToStringAnsi(@out);
            }
        }

        public Symbol this[int index]
        {
            get
            {
                this.ThrowIfDisposed();

                NativeMethods.MXSymbolGetOutput(this.NativePtr, (uint)index, out var @out);
                return new Symbol(@out);
            }
        }

        public Symbol this[string index]
        {
            get
            {
                this.ThrowIfDisposed();

                var outputs = this.ListOutputs();
                for (var i = 0; i < outputs.Count; i++)
                {
                    if (outputs[i] == index)
                        return this[i];
                }

                throw new KeyNotFoundException($"Cannot find output that matches name {index}");
            }
        }

        #endregion

        #region Methods

        public Executor Bind(Context context,
                             IList<NDArray> argArrays,
                             IList<NDArray> gradArrays,
                             IList<OpGradReq> gradReqs,
                             IList<NDArray> auxArrays)
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
                             IList<NDArray> argArrays,
                             IList<NDArray> gradArrays,
                             IList<OpGradReq> gradReqs,
                             IList<NDArray> auxArrays,
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
                             IList<NDArray> argArrays,
                             IList<NDArray> gradArrays,
                             IList<OpGradReq> gradReqs,
                             IList<NDArray> auxArrays,
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

        public IntPtr GetHandle()
        {
            this.ThrowIfDisposed();
            return this.NativePtr;
        }

        public static Symbol Group(IList<Symbol> symbols)
        {
            var handleList = symbols.Select(symbol => symbol.GetHandle()).ToArray();
            NativeMethods.MXSymbolCreateGroup((uint)handleList.Length, handleList, out var @out);
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

            this.ThrowIfDisposed();

            var argShapes = new Dictionary<string, Shape>();

            var argNameList = this.ListArguments();
            foreach (var argName in argNameList)
            {
                if (knownArgs[argName] != null)
                    argShapes[argName] = knownArgs[argName].Shape;
            }

            var (inShapes, outShapes, auxShapes) = this.InferShape(argShapes);

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
                    nd.RandomUniform(0, 1, array.Shape).CopyTo(array);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="argShapes"></param>
        /// <returns>Return arg_shapes, out_shapes, aux_shapes</returns>
        public (Shape[], Shape[], Shape[]) InferShape(Dictionary<string , Shape> argShapes)
        {
            if (argShapes == null)
                throw new ArgumentNullException(nameof(argShapes));

            List<Shape> inShape = new List<Shape>();
            List<Shape> auxShape = new List<Shape>();
            List<Shape> outShape = new List<Shape>();

            this.ThrowIfDisposed();
            var argIndPtr = new List<mx_uint>();
            var argShapeData = new List<mx_uint>();

            foreach (var item in argShapes.Values)
            {
                argIndPtr.Add((uint)argShapeData.Count);
                foreach (var i in item.Data)
                    argShapeData.Add(i);
            }

            argIndPtr.Add((uint)argShapeData.Count);

            unsafe
            {
                var keys = argShapes.Keys.ToArray();
                var argIndPtrArray = argIndPtr.ToArray();
                var argShapeDataArray = argShapeData.ToArray();
                {
                    mx_uint inShapeSize;
                    mx_uint* inShapeNdim;
                    mx_uint** inShapeData;

                    Logging.CHECK_EQ(NativeMethods.MXSymbolInferShape(this.NativePtr,
                                                                      (uint)argShapes.Count,
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

        public (DType[], DType[], DType[]) InferType(Dictionary<string, DType> args) => throw new NotImplementedException();

        public void InferExecutorArrays(Context context,
                                        IList<NDArray> argArrays,
                                        IList<NDArray> gradArrays,
                                        IList<OpGradReq> gradReqs,
                                        IList<NDArray> auxArrays,
                                        NDArrayDict argsMap)
        {
            this.InferExecutorArrays(context,
                                     argArrays,
                                     gradArrays,
                                     gradReqs,
                                     auxArrays,
                                     argsMap,
                                     new NDArrayDict());
        }

        public void InferExecutorArrays(Context context,
                                        IList<NDArray> argArrays,
                                        IList<NDArray> gradArrays,
                                        IList<OpGradReq> gradReqs,
                                        IList<NDArray> auxArrays,
                                        NDArrayDict argsMap,
                                        NDArrayDict argGradStore)
        {
            this.InferExecutorArrays(context,
                                     argArrays,
                                     gradArrays,
                                     gradReqs,
                                     auxArrays,
                                     argsMap,
                                     argGradStore,
                                     new Dictionary<string, OpGradReq>());
        }

        public void InferExecutorArrays(Context context,
                                        IList<NDArray> argArrays,
                                        IList<NDArray> gradArrays,
                                        IList<OpGradReq> gradReqs,
                                        IList<NDArray> auxArrays,
                                        NDArrayDict argsMap,
                                        NDArrayDict argGradStore,
                                        IDictionary<string, OpGradReq> gradReqType)
        {
            this.InferExecutorArrays(context,
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
                                    IList<NDArray> argArrays,
                                    IList<NDArray> gradArrays,
                                    IList<OpGradReq> gradReqs,
                                    IList<NDArray> auxArrays,
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

            this.ThrowIfDisposed();

            var argNameList = this.ListArguments();
            var argShapes = new Dictionary<string, Shape>();

            foreach (var argName in argNameList)
            {
                if (argsMap[argName] != null)
                    argShapes[argName] = argsMap[argName].Shape;
            }

            var (inShapes, auxShapes, outShapes) = this.InferShape(argShapes);

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
                    nd.RandomUniform(0, 1, argArr.Shape).CopyTo(argArr);
                }

                if (argGradStore[argName] != null)
                {
                    gradArrays.Add(argGradStore[argName]);
                }
                else
                {
                    gradArrays.Add(new NDArray(shape, false));
                }

                if (gradReqType.TryGetValue(argName, out var value3))
                {
                    gradReqs.Add(value3);
                }
                else if (argName.LastIndexOf("data", StringComparison.InvariantCulture) == argName.Length - 4 ||
                         argName.LastIndexOf("label", StringComparison.InvariantCulture) == argName.Length - 5)
                {
                    gradReqs.Add(OpGradReq.Null);
                }
                else
                {
                    gradReqs.Add(OpGradReq.Write);
                }
            }

            var auxNameList = this.ListAuxiliaryStates();
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
                    nd.RandomUniform(0, 1, aux.Shape).CopyTo(aux);
                }
            }
        }

        public IList<string> ListArguments()
        {
            this.ThrowIfDisposed();

            NativeMethods.MXSymbolListArguments(this.GetHandle(), out var size, out var sarry);
            var sarryArray = InteropHelper.ToPointerArray(sarry, size);

            var ret = new string[size];
            for (var i = 0; i < size; i++)
                ret[i] = Marshal.PtrToStringAnsi(sarryArray[i]);

            return ret;
        }

        public IList<string> ListAuxiliaryStates()
        {
            this.ThrowIfDisposed();

            NativeMethods.MXSymbolListAuxiliaryStates(this.GetHandle(), out var size, out var sarry);
            var sarryArray = InteropHelper.ToPointerArray(sarry, size);

            var ret = new string[size];
            for (var i = 0; i < size; i++)
                ret[i] = Marshal.PtrToStringAnsi(sarryArray[i]);

            return ret;
        }

        public IList<string> ListOutputs()
        {
            this.ThrowIfDisposed();

            NativeMethods.MXSymbolListOutputs(this.GetHandle(), out var size, out var sarry);
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

        public void Save(string fileName)
        {
            Logging.CHECK_EQ(NativeMethods.MXSymbolSaveToFile(this.GetHandle(), fileName), NativeMethods.OK);
        }

        public Executor SimpleBind(Context context,
                                   NDArrayDict argsMap)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (argsMap == null)
                throw new ArgumentNullException(nameof(argsMap));

            this.ThrowIfDisposed();

            return this.SimpleBind(context, argsMap, new NDArrayDict());
        }

        public Executor SimpleBind(Context context,
                                   NDArrayDict argsMap,
                                   NDArrayDict argGradStore)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (argsMap == null)
                throw new ArgumentNullException(nameof(argsMap));
            if (argGradStore == null)
                throw new ArgumentNullException(nameof(argGradStore));

            this.ThrowIfDisposed();

            return this.SimpleBind(context, argsMap, argGradStore, new Dictionary<string, OpGradReq>());
        }

        public Executor SimpleBind(Context context,
                                   NDArrayDict argsMap,
                                   NDArrayDict argGradStore,
                                   IDictionary<string, OpGradReq> gradReqType)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (argsMap == null)
                throw new ArgumentNullException(nameof(argsMap));
            if (argGradStore == null)
                throw new ArgumentNullException(nameof(argGradStore));
            if (gradReqType == null)
                throw new ArgumentNullException(nameof(gradReqType));

            this.ThrowIfDisposed();

            return this.SimpleBind(context, argsMap, argGradStore, gradReqType, new NDArrayDict());
        }

        public Executor SimpleBind(Context context,
                                   NDArrayDict argsMap,
                                   NDArrayDict argGradStore,
                                   IDictionary<string, OpGradReq> gradReqType,
                                   NDArrayDict auxMap)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (argsMap == null)
                throw new ArgumentNullException(nameof(argsMap));
            if (argGradStore == null)
                throw new ArgumentNullException(nameof(argGradStore));
            if (gradReqType == null)
                throw new ArgumentNullException(nameof(gradReqType));
            if (auxMap == null)
                throw new ArgumentNullException(nameof(auxMap));

            this.ThrowIfDisposed();

            var argArrays = new List<NDArray>();
            var gradArrays = new List<NDArray>();
            var gradReqs = new List<OpGradReq>();
            var auxArrays = new List<NDArray>();

            this.InferExecutorArrays(context,
                                     argArrays,
                                     gradArrays,
                                     gradReqs,
                                     auxArrays,
                                     argsMap,
                                     argGradStore,
                                     gradReqType,
                                     auxMap);

            return new Executor(this, context, argArrays, gradArrays, gradReqs, auxArrays);
        }

        public string ToJSON()
        {
            Logging.CHECK_EQ(NativeMethods.MXSymbolSaveToJSON(this.GetHandle(), out var outJson), NativeMethods.OK);
            return Marshal.PtrToStringAnsi(outJson);
        }

        public static Symbol Variable(string name)
        {
            return new Symbol(name);
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

        #endregion

        #endregion

        #region Overrides

        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();
            NativeMethods.MXSymbolFree(this.NativePtr);
        }

        #endregion

        #endregion

    }

}
