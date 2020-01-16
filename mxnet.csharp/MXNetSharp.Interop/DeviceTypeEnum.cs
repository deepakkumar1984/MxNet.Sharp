using Microsoft.FSharp.Core;
using System;

namespace MXNetSharp.Interop
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public enum DeviceTypeEnum
	{
		CPU = 1,
		GPU,
		CPUPinned
	}
}
