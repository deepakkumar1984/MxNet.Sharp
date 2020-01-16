using Microsoft.FSharp.Core;
using System;

namespace MXNetSharp.Operator
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public interface ICustomOperation
	{
		override void Forward(bool isTrain, OpReqType[] req, NDArray[] inData, NDArray[] outData, NDArray[] auxData);

		override void Backward(OpReqType[] req, NDArray[] inData, NDArray[] outData, NDArray[] inGrad, NDArray[] outGrad, NDArray[] auxData);
	}
}
