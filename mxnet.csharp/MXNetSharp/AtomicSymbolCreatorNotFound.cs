using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace MXNetSharp
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class AtomicSymbolCreatorNotFound : Exception, IStructuralEquatable
	{
		internal string Data0_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public string Data0 => Data0_0040;

		public override string Message
		{
			get
			{
				AtomicSymbolCreatorNotFound atomicSymbolCreatorNotFound = this as AtomicSymbolCreatorNotFound;
				if (atomicSymbolCreatorNotFound != null)
				{
					string name = Data0;
					FSharpFunc<string, string> val = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, string>>((PrintfFormat<FSharpFunc<string, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("Atomic symbol creator %s not found."));
					string text = name;
					return val.Invoke(text);
				}
				string text2 = "unreachable";
				throw Operators.Failure(text2);
			}
		}

		public AtomicSymbolCreatorNotFound(string data0)
		{
			Data0_0040 = data0;
		}

		public AtomicSymbolCreatorNotFound()
		{
		}

		protected AtomicSymbolCreatorNotFound(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		[CompilerGenerated]
		public override int GetHashCode(IEqualityComparer comp)
		{
			if (this != null)
			{
				int num = 0;
				return -1640531527 + ((Data0?.GetHashCode() ?? 0) + ((num << 6) + (num >> 2)));
			}
			return 0;
		}

		[CompilerGenerated]
		public override int GetHashCode()
		{
			return GetHashCode(LanguagePrimitives.get_GenericEqualityComparer());
		}

		[CompilerGenerated]
		public override bool Equals(object obj, IEqualityComparer comp)
		{
			if (this != null)
			{
				Exception ex = obj as Exception;
				if (ex != null)
				{
					Exception ex2 = ex;
					if (IntrinsicFunctions.TypeTestGeneric<AtomicSymbolCreatorNotFound>((object)ex))
					{
						return string.Equals(Data0, ((AtomicSymbolCreatorNotFound)ex2).Data0);
					}
					return false;
				}
				return false;
			}
			return obj == null;
		}

		[CompilerGenerated]
		public bool Equals(Exception obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					if (IntrinsicFunctions.TypeTestGeneric<AtomicSymbolCreatorNotFound>((object)obj))
					{
						return string.Equals(Data0, ((AtomicSymbolCreatorNotFound)obj).Data0);
					}
					return false;
				}
				return false;
			}
			return obj == null;
		}

		[CompilerGenerated]
		public override bool Equals(object obj)
		{
			Exception ex = obj as Exception;
			if (ex != null)
			{
				return Equals(ex);
			}
			return false;
		}
	}
}
