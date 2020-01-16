using _003CStartupCode_0024MXNetSharp_003E;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;
using MXNetSharp.Interop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp
{
	[Serializable]
	[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
	[DebuggerDisplay("{__DebugDisplay(),nq}")]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public abstract class Context : IEquatable<Context>, IStructuralEquatable, IComparable<Context>, IComparable, IStructuralComparable
	{
		public static class Tags
		{
			public const int CPU = 0;

			public const int GPU = 1;

			public const int CPUPinned = 2;
		}

		[Serializable]
		[DebuggerTypeProxy(typeof(CPU_0040DebugTypeProxy))]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		public class CPU : Context
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int item;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			[field: DebuggerNonUserCode]
			public int Item
			{
				[DebuggerNonUserCode]
				get;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal CPU(int item)
			{
				this.item = item;
			}
		}

		[Serializable]
		[DebuggerTypeProxy(typeof(GPU_0040DebugTypeProxy))]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		public class GPU : Context
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int item;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			[field: DebuggerNonUserCode]
			public int Item
			{
				[DebuggerNonUserCode]
				get;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal GPU(int item)
			{
				this.item = item;
			}
		}

		[Serializable]
		[DebuggerTypeProxy(typeof(CPUPinned_0040DebugTypeProxy))]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		public class CPUPinned : Context
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly int item;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			[field: DebuggerNonUserCode]
			public int Item
			{
				[DebuggerNonUserCode]
				get;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal CPUPinned(int item)
			{
				this.item = item;
			}
		}

		internal class CPU_0040DebugTypeProxy
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal CPU _obj;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public int Item
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return _obj.item;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public CPU_0040DebugTypeProxy(CPU obj)
			{
				_obj = obj;
			}
		}

		internal class GPU_0040DebugTypeProxy
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal GPU _obj;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public int Item
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return _obj.item;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public GPU_0040DebugTypeProxy(GPU obj)
			{
				_obj = obj;
			}
		}

		internal class CPUPinned_0040DebugTypeProxy
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal CPUPinned _obj;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public int Item
			{
				[CompilerGenerated]
				[DebuggerNonUserCode]
				get
				{
					return _obj.item;
				}
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			public CPUPinned_0040DebugTypeProxy(CPUPinned obj)
			{
				_obj = obj;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int Tag
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			get
			{
				return (this is CPUPinned) ? 2 : ((this is GPU) ? 1 : 0);
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsCPU
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			get
			{
				return this is CPU;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsGPU
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			get
			{
				return this is GPU;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsCPUPinned
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			get
			{
				return this is CPUPinned;
			}
		}

		public DeviceTypeEnum DeviceType
		{
			get
			{
				if (!(this is GPU))
				{
					if (!(this is CPUPinned))
					{
						CPU cPU = (CPU)this;
						return DeviceTypeEnum.CPU;
					}
					CPUPinned cPUPinned = (CPUPinned)this;
					return DeviceTypeEnum.CPUPinned;
				}
				GPU gPU = (GPU)this;
				return DeviceTypeEnum.GPU;
			}
		}

		public int DeviceId
		{
			get
			{
				if (!(this is GPU))
				{
					if (this is CPUPinned)
					{
						return ((CPUPinned)this).item;
					}
					return ((CPU)this).item;
				}
				return ((GPU)this).item;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal Context()
		{
		}

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static Context NewCPU(int item)
		{
			return new CPU(item);
		}

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static Context NewGPU(int item)
		{
			return new GPU(item);
		}

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static Context NewCPUPinned(int item)
		{
			return new CPUPinned(item);
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal object __DebugDisplay()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<Context, string>>((PrintfFormat<FSharpFunc<Context, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<Context, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(Context obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					int num = (this is CPUPinned) ? 2 : ((this is GPU) ? 1 : 0);
					int num2 = (obj is CPUPinned) ? 2 : ((obj is GPU) ? 1 : 0);
					if (num == num2)
					{
						if (!(this is CPU))
						{
							if (this is GPU)
							{
								GPU gPU = (GPU)this;
								GPU gPU2 = (GPU)obj;
								IComparer genericComparer = LanguagePrimitives.get_GenericComparer();
								int item = gPU.item;
								int item2 = gPU2.item;
								if (item < item2)
								{
									return -1;
								}
								return (item > item2) ? 1 : 0;
							}
							if (this is CPUPinned)
							{
								CPUPinned cPUPinned = (CPUPinned)this;
								CPUPinned cPUPinned2 = (CPUPinned)obj;
								IComparer genericComparer2 = LanguagePrimitives.get_GenericComparer();
								int item3 = cPUPinned.item;
								int item4 = cPUPinned2.item;
								if (item3 < item4)
								{
									return -1;
								}
								return (item3 > item4) ? 1 : 0;
							}
						}
						CPU cPU = (CPU)this;
						CPU cPU2 = (CPU)obj;
						IComparer genericComparer3 = LanguagePrimitives.get_GenericComparer();
						int item5 = cPU.item;
						int item6 = cPU2.item;
						if (item5 < item6)
						{
							return -1;
						}
						return (item5 > item6) ? 1 : 0;
					}
					return num - num2;
				}
				return 1;
			}
			if (obj != null)
			{
				return -1;
			}
			return 0;
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj)
		{
			return CompareTo((Context)obj);
		}

		[CompilerGenerated]
		public sealed override int CompareTo(object obj, IComparer comp)
		{
			Context context = (Context)obj;
			if (this != null)
			{
				if ((Context)obj != null)
				{
					int num = (this is CPUPinned) ? 2 : ((this is GPU) ? 1 : 0);
					Context context2 = context;
					int num2 = (context2 is CPUPinned) ? 2 : ((context2 is GPU) ? 1 : 0);
					if (num == num2)
					{
						if (!(this is CPU))
						{
							if (this is GPU)
							{
								GPU gPU = (GPU)this;
								GPU gPU2 = (GPU)context;
								int item = gPU.item;
								int item2 = gPU2.item;
								if (item < item2)
								{
									return -1;
								}
								return (item > item2) ? 1 : 0;
							}
							if (this is CPUPinned)
							{
								CPUPinned cPUPinned = (CPUPinned)this;
								CPUPinned cPUPinned2 = (CPUPinned)context;
								int item3 = cPUPinned.item;
								int item4 = cPUPinned2.item;
								if (item3 < item4)
								{
									return -1;
								}
								return (item3 > item4) ? 1 : 0;
							}
						}
						CPU cPU = (CPU)this;
						CPU cPU2 = (CPU)context;
						int item5 = cPU.item;
						int item6 = cPU2.item;
						if (item5 < item6)
						{
							return -1;
						}
						return (item5 > item6) ? 1 : 0;
					}
					return num - num2;
				}
				return 1;
			}
			if ((Context)obj != null)
			{
				return -1;
			}
			return 0;
		}

		[CompilerGenerated]
		public sealed override int GetHashCode(IEqualityComparer comp)
		{
			if (this != null)
			{
				int num = 0;
				if (!(this is CPU))
				{
					if (this is GPU)
					{
						GPU gPU = (GPU)this;
						num = 1;
						return -1640531527 + (gPU.item + ((num << 6) + (num >> 2)));
					}
					if (this is CPUPinned)
					{
						CPUPinned cPUPinned = (CPUPinned)this;
						num = 2;
						return -1640531527 + (cPUPinned.item + ((num << 6) + (num >> 2)));
					}
				}
				CPU cPU = (CPU)this;
				num = 0;
				return -1640531527 + (cPU.item + ((num << 6) + (num >> 2)));
			}
			return 0;
		}

		[CompilerGenerated]
		public sealed override int GetHashCode()
		{
			return GetHashCode(LanguagePrimitives.get_GenericEqualityComparer());
		}

		[CompilerGenerated]
		public sealed override bool Equals(object obj, IEqualityComparer comp)
		{
			if (this != null)
			{
				Context context = obj as Context;
				if (context != null)
				{
					Context context2 = context;
					int num = (this is CPUPinned) ? 2 : ((this is GPU) ? 1 : 0);
					Context context3 = context2;
					int num2 = (context3 is CPUPinned) ? 2 : ((context3 is GPU) ? 1 : 0);
					if (num == num2)
					{
						if (!(this is CPU))
						{
							if (this is GPU)
							{
								GPU gPU = (GPU)this;
								GPU gPU2 = (GPU)context2;
								return gPU.item == gPU2.item;
							}
							if (this is CPUPinned)
							{
								CPUPinned cPUPinned = (CPUPinned)this;
								CPUPinned cPUPinned2 = (CPUPinned)context2;
								return cPUPinned.item == cPUPinned2.item;
							}
						}
						CPU cPU = (CPU)this;
						CPU cPU2 = (CPU)context2;
						return cPU.item == cPU2.item;
					}
					return false;
				}
				return false;
			}
			return obj == null;
		}

		public override string ToString()
		{
			if (!(this is GPU))
			{
				if (!(this is CPUPinned))
				{
					CPU cPU = (CPU)this;
					int id3 = cPU.item;
					FSharpFunc<int, string> val = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<int, string>>((PrintfFormat<FSharpFunc<int, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<int, string>, Unit, string, string, int>("cpu(%d)"));
					int num = id3;
					return val.Invoke(num);
				}
				CPUPinned cPUPinned = (CPUPinned)this;
				int id2 = cPUPinned.item;
				FSharpFunc<int, string> val2 = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<int, string>>((PrintfFormat<FSharpFunc<int, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<int, string>, Unit, string, string, int>("cpupinned(%d)"));
				int num2 = id2;
				return val2.Invoke(num2);
			}
			GPU gPU = (GPU)this;
			int id = gPU.item;
			FSharpFunc<int, string> val3 = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<int, string>>((PrintfFormat<FSharpFunc<int, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<int, string>, Unit, string, string, int>("gpu(%d)"));
			int num3 = id;
			return val3.Invoke(num3);
		}

		public static Context FromDeviceTypeAndId(DeviceTypeEnum deviceType, int id)
		{
			switch (deviceType)
			{
			case DeviceTypeEnum.CPU:
				return NewCPU(id);
			case DeviceTypeEnum.GPU:
				return NewGPU(id);
			case DeviceTypeEnum.CPUPinned:
				return NewCPUPinned(id);
			default:
			{
				string paramName = "deviceType";
				string message = ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<int, string>>((PrintfFormat<FSharpFunc<int, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<int, string>, Unit, string, string, int>("Device type %d not suported")).Invoke((int)deviceType);
				throw new ArgumentException(message, paramName);
			}
			}
		}

		public static FSharpOption<Context> TryParse(string str)
		{
			string str2 = str.Trim().ToLower();
			FSharpTypeFunc tryPrefix = (FSharpTypeFunc)(object)new _0024Coretypes.tryPrefix_0040104(str2);
			return SeqModule.TryPick<Tuple<string, FSharpFunc<int, Context>>, Context>((FSharpFunc<Tuple<string, FSharpFunc<int, Context>>, FSharpOption<Context>>)new _0024Coretypes.TryParse_0040115(tryPrefix), (IEnumerable<Tuple<string, FSharpFunc<int, Context>>>)(object)new _0024Coretypes.TryParse_0040111_002D1(0, null));
		}

		[CompilerGenerated]
		public sealed override bool Equals(Context obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					int num = (this is CPUPinned) ? 2 : ((this is GPU) ? 1 : 0);
					int num2 = (obj is CPUPinned) ? 2 : ((obj is GPU) ? 1 : 0);
					if (num == num2)
					{
						if (!(this is CPU))
						{
							if (this is GPU)
							{
								GPU gPU = (GPU)this;
								GPU gPU2 = (GPU)obj;
								return gPU.item == gPU2.item;
							}
							if (this is CPUPinned)
							{
								CPUPinned cPUPinned = (CPUPinned)this;
								CPUPinned cPUPinned2 = (CPUPinned)obj;
								return cPUPinned.item == cPUPinned2.item;
							}
						}
						CPU cPU = (CPU)this;
						CPU cPU2 = (CPU)obj;
						return cPU.item == cPU2.item;
					}
					return false;
				}
				return false;
			}
			return obj == null;
		}

		[CompilerGenerated]
		public sealed override bool Equals(object obj)
		{
			Context context = obj as Context;
			if (context != null)
			{
				return Equals(context);
			}
			return false;
		}
	}
}
