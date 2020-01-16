using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace MXNetSharp.Interop
{
	[Serializable]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public class MXNetException : Exception, IStructuralEquatable
	{
		internal string Data0_0040;

		internal string Data1_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public string Data0 => Data0_0040;

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public string Data1 => Data1_0040;

		public override string Message
		{
			get
			{
				MXNetException ex = this as MXNetException;
				if (ex != null)
				{
					string msg = Data1;
					string data = Data0;
					FSharpFunc<string, FSharpFunc<string, string>> clo = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<string, FSharpFunc<string, string>>>((PrintfFormat<FSharpFunc<string, FSharpFunc<string, string>>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<string, FSharpFunc<string, string>>, Unit, string, string, Tuple<string, string>>("%s: %s"));
					return FSharpFunc<string, string>.InvokeFast<string>((FSharpFunc<string, FSharpFunc<string, string>>)new _0024Interop.get_Message_0040113(clo), data, msg);
				}
				string text = "unreachable";
				throw Operators.Failure(text);
			}
		}

		public MXNetException(string data0, string data1)
		{
			Data0_0040 = data0;
			Data1_0040 = data1;
		}

		public MXNetException()
		{
		}

		protected MXNetException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		[CompilerGenerated]
		public override int GetHashCode(IEqualityComparer comp)
		{
			if (this != null)
			{
				int num = 0;
				num = -1640531527 + ((Data1?.GetHashCode() ?? 0) + ((num << 6) + (num >> 2)));
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
					if (IntrinsicFunctions.TypeTestGeneric<MXNetException>((object)ex))
					{
						if (string.Equals(Data0, ((MXNetException)ex2).Data0))
						{
							return string.Equals(Data1, ((MXNetException)ex2).Data1);
						}
						return false;
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
					if (IntrinsicFunctions.TypeTestGeneric<MXNetException>((object)obj))
					{
						if (string.Equals(Data0, ((MXNetException)obj).Data0))
						{
							return string.Equals(Data1, ((MXNetException)obj).Data1);
						}
						return false;
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
