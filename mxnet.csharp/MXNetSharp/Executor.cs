using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Collections.Generic;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class Executor : IDisposable
	{
		internal Symbol symbol;

		internal NDArray[] inArgs;

		internal SafeExecutorHandle handle;

		internal OpReqType[] gradReqType;

		internal FSharpOption<Bindings> bindMap;

		internal NDArray[] auxStates;

		internal NDArray[] argGrad;

		internal bool disposed;

		internal NDArray[] outputs_0040449;

		public Bindings Bindings
		{
			get
			{
				FSharpOption<Bindings> val = bindMap;
				if (val != null)
				{
					FSharpOption<Bindings> val2 = val;
					return val2.get_Value();
				}
				Tuple<NDArray, NDArray, OpReqType>[] args = ArrayModule.Zip3<NDArray, NDArray, OpReqType>(inArgs, argGrad, gradReqType);
				return BindingsModule.ofSeq((IEnumerable<Bind>)(object)new _0024Executor.get_Bindings_0040531(this, args, null, null, 0, null));
			}
		}

		public Symbol Symbol => symbol;

		internal IntPtr UnsafeHandle => handle.UnsafeHandle;

		public NDArray[] Outputs => outputs_0040449;

		public SafeExecutorHandle ExecutorHandle => handle;

		public NDArray this[Variable v] => Bindings.NDArray(v);

		public Executor(SafeExecutorHandle handle, Symbol symbol, Context context, IDictionary<string, Context> contextMap, NDArray[] inArgs, NDArray[] argGrad, OpReqType[] gradReqType, NDArray[] auxStates, FSharpOption<Executor> sharedExecutor, NDArray[] outputs, FSharpOption<Bindings> bindMap)
		{
			this.handle = handle;
			this.symbol = symbol;
			this.inArgs = inArgs;
			this.argGrad = argGrad;
			this.gradReqType = gradReqType;
			this.auxStates = auxStates;
			this.bindMap = bindMap;
			disposed = false;
			outputs_0040449 = outputs;
		}

		public unsafe Executor(Symbol symbol, Context context, IDictionary<string, Context> contextMap, IEnumerable<NDArray> inArgs, IEnumerable<NDArray> argGrad, IEnumerable<OpReqType> gradReqType, IEnumerable<NDArray> auxStates, FSharpOption<Executor> sharedExecutor, FSharpOption<Bindings> bindMap)
		{
			NDArray[] inArgs2 = SeqModule.ToArray<NDArray>(inArgs);
			NDArray[] argGrad2 = SeqModule.ToArray<NDArray>(argGrad);
			OpReqType[] gradReqType2 = SeqModule.ToArray<OpReqType>(gradReqType);
			NDArray[] auxStates2 = SeqModule.ToArray<NDArray>(auxStates);
			NDArray[] array = inArgs2;
			FSharpFunc<NDArray, IntPtr> val = new _0024Executor.inArgsHandles_0040455();
			NDArray[] array2 = array;
			if (array2 == null)
			{
				throw new ArgumentNullException("array");
			}
			IntPtr[] array3 = new IntPtr[array2.Length];
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i] = val.Invoke(array2[i]);
			}
			IntPtr[] inArgsHandles = array3;
			NDArray[] array4 = argGrad2;
			FSharpFunc<NDArray, IntPtr> val2 = new _0024Executor.argGradHandles_0040456();
			NDArray[] array5 = array4;
			if (array5 == null)
			{
				throw new ArgumentNullException("array");
			}
			IntPtr[] array6 = new IntPtr[array5.Length];
			for (int j = 0; j < array6.Length; j++)
			{
				array6[j] = val2.Invoke(array5[j]);
			}
			IntPtr[] argGradHandles = array6;
			OpReqType[] array7 = gradReqType2;
			FSharpFunc<OpReqType, uint> val3 = new _0024Executor.gradReqTypeHandles_0040457();
			OpReqType[] array8 = array7;
			if (array8 == null)
			{
				throw new ArgumentNullException("array");
			}
			uint[] array9 = new uint[array8.Length];
			for (int k = 0; k < array9.Length; k++)
			{
				array9[k] = val3.Invoke(array8[k]);
			}
			uint[] gradReqTypeHandles = array9;
			NDArray[] array10 = auxStates2;
			FSharpFunc<NDArray, IntPtr> val4 = new _0024Executor.auxStatesHandles_0040458();
			NDArray[] array11 = array10;
			if (array11 == null)
			{
				throw new ArgumentNullException("array");
			}
			IntPtr[] array12 = new IntPtr[array11.Length];
			for (int l = 0; l < array12.Length; l++)
			{
				array12[l] = val4.Invoke(array11[l]);
			}
			IntPtr[] auxStatesHandles = array12;
			Tuple<string[], int[], int[]> tuple = (contextMap.Count != 0) ? ArrayModule.Unzip3<string, int, int>(SeqModule.ToArray<Tuple<string, int, int>>(SeqModule.Map<KeyValuePair<string, Context>, Tuple<string, int, int>>((FSharpFunc<KeyValuePair<string, Context>, Tuple<string, int, int>>)new _0024Executor._002Dctor_0040465_002D17(), (IEnumerable<KeyValuePair<string, Context>>)contextMap))) : new Tuple<string[], int[], int[]>(null, null, null);
			IntPtr h = MXExecutor.bindEX(map_keys: tuple.Item1, map_dev_types: tuple.Item2, map_dev_ids: tuple.Item3, shared_exec: sharedExecutor?.get_Value().UnsafeHandle ?? ((IntPtr)(void*)0L), symbol_handle: symbol.UnsafeHandle, dev_type: (int)context.DeviceType, dev_id: context.DeviceId, in_args: inArgsHandles, arg_grad_store: argGradHandles, grad_req_type: gradReqTypeHandles, aux_states: auxStatesHandles);
			SafeExecutorHandle safeHandle = new SafeExecutorHandle(h, owner: true);
			IntPtr[] array13 = MXExecutor.outputs(h);
			FSharpFunc<IntPtr, NDArray> val5 = new _0024Executor.outputs_0040477_002D1711();
			IntPtr[] array14 = array13;
			if (array14 == null)
			{
				throw new ArgumentNullException("array");
			}
			NDArray[] array15 = new NDArray[array14.Length];
			for (int m = 0; m < array15.Length; m++)
			{
				array15[m] = val5.Invoke(array14[m]);
			}
			this._002Ector(safeHandle, symbol, context, contextMap, inArgs2, argGrad2, gradReqType2, auxStates2, sharedExecutor, array15, bindMap);
		}

		public Executor(Symbol symbol, Context context, IDictionary<string, Context> contextMap, IEnumerable<NDArray> inArgs, IEnumerable<NDArray> argGrad, IEnumerable<OpReqType> gradReqType, IEnumerable<NDArray> auxStates, FSharpOption<Executor> sharedExecutor)
			: this(symbol, context, contextMap, inArgs, argGrad, gradReqType, auxStates, sharedExecutor, null)
		{
		}

		public Executor(Symbol symbol, Context context, IEnumerable<NDArray> inArgs, IEnumerable<NDArray> argGrad, IEnumerable<OpReqType> gradReqType, IEnumerable<NDArray> auxStates, FSharpOption<Bindings> bindMap)
			: this(symbol, context, (IDictionary<string, Context>)MapModule.Empty<string, Context>(), inArgs, argGrad, gradReqType, auxStates, null, bindMap)
		{
		}

		public Executor(Symbol symbol, Context context, IEnumerable<NDArray> inArgs, IEnumerable<NDArray> argGrad, IEnumerable<OpReqType> gradReqType, IEnumerable<NDArray> auxStates)
			: this(symbol, context, (IDictionary<string, Context>)MapModule.Empty<string, Context>(), inArgs, argGrad, gradReqType, auxStates, null, null)
		{
		}

		public Executor(Symbol symbol, Context context, Bindings bindings)
		{
			string[] argumentNames = symbol.ArgumentNames;
			FSharpFunc<string, Tuple<NDArray, NDArray, OpReqType>> val = new _0024Executor._002Dctor_0040490_002D18(bindings);
			string[] array = argumentNames;
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			Tuple<NDArray, NDArray, OpReqType>[] array2 = new Tuple<NDArray, NDArray, OpReqType>[array.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = val.Invoke(array[i]);
			}
			Tuple<NDArray[], NDArray[], OpReqType[]> tuple = ArrayModule.Unzip3<NDArray, NDArray, OpReqType>(array2);
			NDArray[] inArgs = tuple.Item1;
			OpReqType[] gradReqType = tuple.Item3;
			NDArray[] argGrad = tuple.Item2;
			string[] auxiliaryStateNames = symbol.AuxiliaryStateNames;
			FSharpFunc<string, NDArray> val2 = new _0024Executor.aux_0040503(bindings);
			string[] array3 = auxiliaryStateNames;
			if (array3 == null)
			{
				throw new ArgumentNullException("array");
			}
			NDArray[] array4 = new NDArray[array3.Length];
			for (int j = 0; j < array4.Length; j++)
			{
				array4[j] = val2.Invoke(array3[j]);
			}
			this._002Ector(symbol, context, inArgs, argGrad, gradReqType, array4, FSharpOption<Bindings>.Some(bindings));
		}

		public bool RefreshOutputs()
		{
			bool updated = false;
			IntPtr[] handles = MXExecutor.outputs(handle.UnsafeHandle);
			if (handles.Length == outputs_0040449.Length)
			{
				int i = 0;
				int num = outputs_0040449.Length - 1;
				if (num >= i)
				{
					do
					{
						if (outputs_0040449[i].UnsafeHandle != handles[i])
						{
							outputs_0040449[i] = new NDArray(new SafeNDArrayHandle(handles[i], owner: true));
							updated = true;
						}
						i++;
					}
					while (i != num + 1);
				}
				return updated;
			}
			IntPtr[] array = handles;
			FSharpFunc<IntPtr, NDArray> val = new _0024Executor.RefreshOutputs_0040522();
			IntPtr[] array2 = array;
			if (array2 == null)
			{
				throw new ArgumentNullException("array");
			}
			NDArray[] array3 = new NDArray[array2.Length];
			for (int j = 0; j < array3.Length; j++)
			{
				array3[j] = val.Invoke(array2[j]);
			}
			outputs_0040449 = array3;
			return true;
		}

		public string Print()
		{
			return MXExecutor.print(handle.UnsafeHandle);
		}

		public void Forward(bool isTraining)
		{
			int isTrain = isTraining ? 1 : 0;
			MXExecutor.forward(handle.UnsafeHandle, isTrain);
			bool flag = RefreshOutputs();
			bool flag2 = flag;
		}

		public void Backward()
		{
			MXExecutor.backward(handle.UnsafeHandle, null);
		}

		public void Backward(IEnumerable<NDArray> grads)
		{
			IntPtr[] head_grads = SeqModule.ToArray<IntPtr>(SeqModule.Map<NDArray, IntPtr>((FSharpFunc<NDArray, IntPtr>)new _0024Executor.Backward_0040586(), grads));
			MXExecutor.backward(handle.UnsafeHandle, head_grads);
		}

		public void Dispose(bool disposing)
		{
			if (!disposed && disposing)
			{
				handle.Dispose();
			}
			disposed = true;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		private virtual void System_002DIDisposable_002DDispose()
		{
			Dispose();
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in System-IDisposable-Dispose
			this.System_002DIDisposable_002DDispose();
		}
	}
}
