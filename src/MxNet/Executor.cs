using System;
using System.Collections.Generic;
using System.Linq;
using MxNet.Interop;
using mx_uint = System.UInt32;
using ExecutorHandle = System.IntPtr;
using MxNet.IO;

// ReSharper disable once CheckNamespace
namespace MxNet
{
    public sealed class Executor : DisposableMXNetObject
    {
        #region Fields

        internal Symbol _Symbol;

        #endregion

        #region Constructors

        public Executor(Symbol symbol,
            Context context,
            NDArrayList argmentArrays,
            NDArrayList gradientArrays,
            IList<OpGradReq> gradReqs,
            NDArrayList auxiliaryArrays)
            : this(symbol, context, argmentArrays, gradientArrays, gradReqs, auxiliaryArrays,
                new Dictionary<string, Context>(), null)
        {
        }

        public Executor(Symbol symbol,
            Context context,
            NDArrayList argmentArrays,
            NDArrayList gradientArrays,
            IList<OpGradReq> gradReqs,
            NDArrayList auxiliaryArrays,
            IDictionary<string, Context> groupToCtx)
            : this(symbol, context, argmentArrays, gradientArrays, gradReqs, auxiliaryArrays, groupToCtx, null)
        {
        }

        public Executor(Symbol symbol,
            Context context,
            NDArrayList argmentArrays,
            NDArrayList gradientArrays,
            IList<OpGradReq> gradReqs,
            NDArrayList auxiliaryArrays,
            IDictionary<string, Context> groupToCtx,
            Executor sharedExec)
        {
            if (symbol == null)
                throw new ArgumentNullException(nameof(symbol));
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (argmentArrays == null)
                throw new ArgumentNullException(nameof(argmentArrays));
            if (gradientArrays == null)
                throw new ArgumentNullException(nameof(gradientArrays));
            if (gradReqs == null)
                throw new ArgumentNullException(nameof(gradReqs));
            if (auxiliaryArrays == null)
                throw new ArgumentNullException(nameof(auxiliaryArrays));
            if (groupToCtx == null)
                throw new ArgumentNullException(nameof(groupToCtx));

            ArgmentArrays = argmentArrays;
            GradientArrays = gradientArrays;
            AuxiliaryArrays = auxiliaryArrays;
            _Symbol = symbol;

            var argHandles = argmentArrays.Select(array => array.GetHandle()).ToArray();
            var gradHandles = gradientArrays.Select(array => array.GetHandle()).ToArray();
            var auxHandles = auxiliaryArrays.Select(array => array.GetHandle()).ToArray();
            var gradReqsUint = gradReqs.Select(s => (uint) s).ToArray();

            var mapKeys = new string[groupToCtx.Count];
            var devTypes = new int[groupToCtx.Count];
            var devIds = new int[groupToCtx.Count];
            var keys = groupToCtx.Keys.ToArray();
            for (var index = 0; index < keys.Length; index++)
            {
                var key = keys[index];
                mapKeys[index] = key;
                var value = groupToCtx[key];
                devTypes[index] = (int) value.GetDeviceType();
                devIds[index] = value.GetDeviceId();
            }

            var sharedExecHandle = sharedExec?.Handle ?? IntPtr.Zero;

            Logging.CHECK_EQ(NativeMethods.MXExecutorBindEX(symbol.GetHandle(),
                (int) context.GetDeviceType(),
                context.GetDeviceId(),
                (uint) groupToCtx.Count,
                mapKeys,
                devTypes,
                devIds,
                (uint) argHandles.Length,
                argHandles,
                gradHandles,
                gradReqsUint,
                (uint) auxHandles.Length,
                auxHandles,
                sharedExecHandle,
                out var handle), NativeMethods.OK);
            Handle = handle;

            Outputs = new NDArrayList();
            Logging.CHECK_EQ(NativeMethods.MXExecutorOutputs(Handle, out var outSize, out var outArray), 0);
            var outArrayArray = InteropHelper.ToPointerArray(outArray, outSize);
            for (uint i = 0; i < outSize; ++i)
                Outputs.Add(new NDArray(outArrayArray[i]));
        }

        public Executor(ExecutorHandle h, Context context,
            List<OpGradReq> gradReqs,
            Dictionary<string, Context> groupToCtx)
        {
            if (h == IntPtr.Zero)
                throw new ArgumentException("Can not pass IntPtr.Zero", nameof(h));
            Outputs = new NDArrayList();
            Handle = h;
            Logging.CHECK_EQ(NativeMethods.MXExecutorOutputs(Handle, out var outSize, out var outArray), 0);
            var outArrayArray = InteropHelper.ToPointerArray(outArray, outSize);
            for (uint i = 0; i < outSize; ++i)
                Outputs.Add(new NDArray(outArrayArray[i]));
        }

        #endregion

        #region Properties

        internal ExecutorHandle Handle { get; }

        public NDArrayList Outputs { get; }

        public NDArray Output => Outputs.First();

        public NDArrayList ArgmentArrays { get; internal set; }

        public NDArrayList GradientArrays { get; internal set; }

        public NDArrayList AuxiliaryArrays { get; internal set; }

        #endregion

        #region Methods

        public NDArrayDict ArgmentDictionary()
        {
            return GetDictionary(_Symbol.ListArguments(), ArgmentArrays);
        }

        public NDArrayDict GradientDictionary()
        {
            return GetDictionary(_Symbol.ListArguments(), GradientArrays);
        }

        public NDArrayDict AuxiliaryDictionary()
        {
            return GetDictionary(_Symbol.ListAuxiliaryStates(), AuxiliaryArrays);
        }

        public void Backward()
        {
            Backward(new NDArrayList());
        }

        public void Backward(NDArrayList headGrads)
        {
            if (headGrads == null)
                throw new ArgumentNullException(nameof(headGrads));

            var tmp = headGrads.Select(d => d.GetHandle()).ToArray();
            if (tmp.Length > 0)
                NativeMethods.MXExecutorBackward(Handle, (uint) tmp.Length, tmp);
            else
                NativeMethods.MXExecutorBackward(Handle, 0, null);
        }

        public void Forward(bool isTrain)
        {
            NativeMethods.MXExecutorForward(Handle, isTrain ? 1 : 0);
            Logging.CHECK_EQ(NativeMethods.MXExecutorOutputs(Handle, out var outSize, out var outArray), 0);
            var outArrayArray = InteropHelper.ToPointerArray(outArray, outSize);
            for (var i = 0; i < outSize; ++i)
            {
                Outputs[i]?.Dispose();
                Outputs[i] = new NDArray(outArrayArray[i]);
            }
        }

        public void CopyFromParams(NDArrayDict arg_params, NDArrayDict aux_params = null,
            bool allow_extra_params = false)
        {
            var arg_dict = ArgmentDictionary();
            var aux_dict = AuxiliaryDictionary();
            foreach (var item in arg_params)
                if (arg_dict.Contains(item.Key))
                {
                    var dst = arg_dict[item.Key];
                    item.Value.AsType(dst.DataType).CopyTo(dst);
                }
                else if (!allow_extra_params)
                {
                    throw new Exception($"Find name \"{item.Key}\" that is not in the arguments");
                }

            if (aux_params == null)
                return;

            foreach (var item in aux_params)
                if (aux_dict.Contains(item.Key))
                {
                    var dst = aux_dict[item.Key];
                    item.Value.AsType(dst.DataType).CopyTo(dst);
                }
                else if (!allow_extra_params)
                {
                    throw new Exception($"Find name \"{item.Key}\" that is not in the auxiliary states");
                }
        }

        public Executor Reshape(bool partial_shaping = false, bool allow_up_sizing = false, DataDesc[] newShapes = null)
        {
            throw new NotImplementedException();
        }

        #region Overrids

        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();
            NativeMethods.MXExecutorFree(Handle);
        }

        #endregion

        #region Helpers

        private static NDArrayDict GetDictionary(IList<string> names, NDArrayList arrays)
        {
            var ret = new NDArrayDict();

            var set = new HashSet<string>();
            foreach (var s in names)
            {
                Logging.CHECK(!set.Contains(s), $"Duplicate names detected, {s}");
                set.Add(s);
            }

            Logging.CHECK_EQ(set.Count, arrays.Length, "names size not equal to arrays size");
            for (var i = 0; i < names.Count; ++i)
                ret[names[i]] = arrays[i];

            return ret;
        }

        #endregion

        #endregion
    }
}