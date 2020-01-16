using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;

namespace MXNetSharp.Operator
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public interface ICustomOperationProperties
	{
		override string[] ListArguments();

		override string[] ListOutputs();

		override string[] ListAuxiliaryStates();

		override Tuple<int[][], int[][], int[][]> InferShape(int[][] inShape);

		override void InferBackwardStorageType(BackwardStorageTypes storageTypes);

		override Tuple<StorageType[], StorageType[], StorageType[]> InferStorageType(StorageType[] inputStorageTypes);

		override Tuple<TypeFlag[], TypeFlag[], TypeFlag[]> InferType(TypeFlag[] inType);

		override int[] DeclareBackwardDependency(int[] outGrad, int[] inData, int[] OutData);

		override ICustomOperation CreateOperator(Context context, int[][] inShapes, TypeFlag[] inDataTypes);
	}
}
