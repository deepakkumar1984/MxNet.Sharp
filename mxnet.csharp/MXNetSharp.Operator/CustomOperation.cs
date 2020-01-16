using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Collections.Generic;

namespace MXNetSharp.Operator
{
	[Serializable]
	[AbstractClass]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public abstract class CustomOperation : ICustomOperationProperties
	{
		public abstract override ICustomOperation CreateOperator(Context context, int[][] inShapes, TypeFlag[] inDataTypes);

		public CustomOperation()
		{
		}

		public override int[] DeclareBackwardDependency(int[] outGrad, int[] inData, int[] outData)
		{
			return SeqModule.ToArray<int>((IEnumerable<int>)(object)new _0024Customop.DeclareBackwardDependency_004067(outGrad, outData, inData, null, null, 0, 0));
		}

		public override void InferBackwardStorageType(BackwardStorageTypes storageTypes)
		{
			for (int m = 0; m < storageTypes.Auxiliary_0040.Length; m++)
			{
				storageTypes.Auxiliary_0040[m] = StorageType.Default;
			}
			for (int l = 0; l < storageTypes.Input_0040.Length; l++)
			{
				storageTypes.Input_0040[l] = StorageType.Default;
			}
			for (int k = 0; k < storageTypes.Output_0040.Length; k++)
			{
				storageTypes.Output_0040[k] = StorageType.Default;
			}
			for (int j = 0; j < storageTypes.InputGrad_0040.Length; j++)
			{
				storageTypes.InputGrad_0040[j] = StorageType.Default;
			}
			for (int i = 0; i < storageTypes.OutputGrad_0040.Length; i++)
			{
				storageTypes.OutputGrad_0040[i] = StorageType.Default;
			}
		}

		public override Tuple<int[][], int[][], int[][]> InferShape(int[][] inShape)
		{
			string[] array = ListOutputs();
			FSharpFunc<string, int[]> val = new _0024Customop.outType_004078(inShape);
			string[] array2 = array;
			if (array2 == null)
			{
				throw new ArgumentNullException("array");
			}
			int[][] array3 = new int[array2.Length][];
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i] = val.Invoke(array2[i]);
			}
			int[][] outType = array3;
			return new Tuple<int[][], int[][], int[][]>(inShape, outType, ArrayModule.Empty<int[]>());
		}

		public override Tuple<StorageType[], StorageType[], StorageType[]> InferStorageType(StorageType[] inputStorageTypes)
		{
			string[] array = ListOutputs();
			FSharpFunc<string, StorageType> val = new _0024Customop.outType_004081_002D1();
			string[] array2 = array;
			if (array2 == null)
			{
				throw new ArgumentNullException("array");
			}
			StorageType[] array3 = new StorageType[array2.Length];
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i] = val.Invoke(array2[i]);
			}
			StorageType[] outType = array3;
			string[] array4 = ListAuxiliaryStates();
			FSharpFunc<string, StorageType> val2 = new _0024Customop.auxType_004082();
			string[] array5 = array4;
			if (array5 == null)
			{
				throw new ArgumentNullException("array");
			}
			StorageType[] array6 = new StorageType[array5.Length];
			for (int j = 0; j < array6.Length; j++)
			{
				array6[j] = val2.Invoke(array5[j]);
			}
			StorageType[] auxType = array6;
			return new Tuple<StorageType[], StorageType[], StorageType[]>(inputStorageTypes, outType, auxType);
		}

		public override Tuple<TypeFlag[], TypeFlag[], TypeFlag[]> InferType(TypeFlag[] inType)
		{
			string[] array = ListOutputs();
			FSharpFunc<string, TypeFlag> val = new _0024Customop.outType_004085_002D2(inType);
			string[] array2 = array;
			if (array2 == null)
			{
				throw new ArgumentNullException("array");
			}
			TypeFlag[] array3 = new TypeFlag[array2.Length];
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i] = val.Invoke(array2[i]);
			}
			TypeFlag[] outType = array3;
			string[] array4 = ListAuxiliaryStates();
			FSharpFunc<string, TypeFlag> val2 = new _0024Customop.auxType_004086_002D1(inType);
			string[] array5 = array4;
			if (array5 == null)
			{
				throw new ArgumentNullException("array");
			}
			TypeFlag[] array6 = new TypeFlag[array5.Length];
			for (int j = 0; j < array6.Length; j++)
			{
				array6[j] = val2.Invoke(array5[j]);
			}
			TypeFlag[] auxType = array6;
			return new Tuple<TypeFlag[], TypeFlag[], TypeFlag[]>(inType, outType, auxType);
		}

		public override string[] ListArguments()
		{
			return new string[1]
			{
				"data"
			};
		}

		public override string[] ListAuxiliaryStates()
		{
			return ArrayModule.Empty<string>();
		}

		public override string[] ListOutputs()
		{
			return new string[1]
			{
				"output"
			};
		}

		private virtual ICustomOperation MXNetSharp_002DOperator_002DICustomOperationProperties_002DCreateOperator(Context context, int[][] inShapes, TypeFlag[] inDataTypes)
		{
			return CreateOperator(context, inShapes, inDataTypes);
		}

		ICustomOperation ICustomOperationProperties.CreateOperator(Context context, int[][] inShapes, TypeFlag[] inDataTypes)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MXNetSharp-Operator-ICustomOperationProperties-CreateOperator
			return this.MXNetSharp_002DOperator_002DICustomOperationProperties_002DCreateOperator(context, inShapes, inDataTypes);
		}

		private virtual int[] MXNetSharp_002DOperator_002DICustomOperationProperties_002DDeclareBackwardDependency(int[] outGrad, int[] inData, int[] outData)
		{
			return DeclareBackwardDependency(outGrad, inData, outData);
		}

		int[] ICustomOperationProperties.DeclareBackwardDependency(int[] outGrad, int[] inData, int[] outData)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MXNetSharp-Operator-ICustomOperationProperties-DeclareBackwardDependency
			return this.MXNetSharp_002DOperator_002DICustomOperationProperties_002DDeclareBackwardDependency(outGrad, inData, outData);
		}

		private virtual void MXNetSharp_002DOperator_002DICustomOperationProperties_002DInferBackwardStorageType(BackwardStorageTypes storageTypes)
		{
			InferBackwardStorageType(storageTypes);
		}

		void ICustomOperationProperties.InferBackwardStorageType(BackwardStorageTypes storageTypes)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MXNetSharp-Operator-ICustomOperationProperties-InferBackwardStorageType
			this.MXNetSharp_002DOperator_002DICustomOperationProperties_002DInferBackwardStorageType(storageTypes);
		}

		private virtual Tuple<int[][], int[][], int[][]> MXNetSharp_002DOperator_002DICustomOperationProperties_002DInferShape(int[][] inShape)
		{
			return InferShape(inShape);
		}

		Tuple<int[][], int[][], int[][]> ICustomOperationProperties.InferShape(int[][] inShape)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MXNetSharp-Operator-ICustomOperationProperties-InferShape
			return this.MXNetSharp_002DOperator_002DICustomOperationProperties_002DInferShape(inShape);
		}

		private virtual Tuple<StorageType[], StorageType[], StorageType[]> MXNetSharp_002DOperator_002DICustomOperationProperties_002DInferStorageType(StorageType[] inputStorageTypes)
		{
			return InferStorageType(inputStorageTypes);
		}

		Tuple<StorageType[], StorageType[], StorageType[]> ICustomOperationProperties.InferStorageType(StorageType[] inputStorageTypes)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MXNetSharp-Operator-ICustomOperationProperties-InferStorageType
			return this.MXNetSharp_002DOperator_002DICustomOperationProperties_002DInferStorageType(inputStorageTypes);
		}

		private virtual Tuple<TypeFlag[], TypeFlag[], TypeFlag[]> MXNetSharp_002DOperator_002DICustomOperationProperties_002DInferType(TypeFlag[] inType)
		{
			return InferType(inType);
		}

		Tuple<TypeFlag[], TypeFlag[], TypeFlag[]> ICustomOperationProperties.InferType(TypeFlag[] inType)
		{
			//ILSpy generated this explicit interface implementation from .override directive in MXNetSharp-Operator-ICustomOperationProperties-InferType
			return this.MXNetSharp_002DOperator_002DICustomOperationProperties_002DInferType(inType);
		}

		private virtual string[] MXNetSharp_002DOperator_002DICustomOperationProperties_002DListAuxiliaryStates()
		{
			return ListAuxiliaryStates();
		}

		string[] ICustomOperationProperties.ListAuxiliaryStates()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MXNetSharp-Operator-ICustomOperationProperties-ListAuxiliaryStates
			return this.MXNetSharp_002DOperator_002DICustomOperationProperties_002DListAuxiliaryStates();
		}

		private virtual string[] MXNetSharp_002DOperator_002DICustomOperationProperties_002DListOutputs()
		{
			return ListOutputs();
		}

		string[] ICustomOperationProperties.ListOutputs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MXNetSharp-Operator-ICustomOperationProperties-ListOutputs
			return this.MXNetSharp_002DOperator_002DICustomOperationProperties_002DListOutputs();
		}

		private virtual string[] MXNetSharp_002DOperator_002DICustomOperationProperties_002DListArguments()
		{
			return ListArguments();
		}

		string[] ICustomOperationProperties.ListArguments()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MXNetSharp-Operator-ICustomOperationProperties-ListArguments
			return this.MXNetSharp_002DOperator_002DICustomOperationProperties_002DListArguments();
		}
	}
}
