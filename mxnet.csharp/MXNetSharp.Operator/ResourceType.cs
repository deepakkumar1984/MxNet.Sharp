using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp.Operator
{
	[Serializable]
	[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
	[NoComparison]
	[DebuggerDisplay("{__DebugDisplay(),nq}")]
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public abstract class ResourceType : IEquatable<ResourceType>, IStructuralEquatable
	{
		public static class Tags
		{
			public const int Disposable = 0;

			public const int ReferenceHolder = 1;
		}

		[Serializable]
		[DebuggerTypeProxy(typeof(Disposable_0040DebugTypeProxy))]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		public class Disposable : ResourceType
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly IDisposable item;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			[field: DebuggerNonUserCode]
			public IDisposable Item
			{
				[DebuggerNonUserCode]
				get;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal Disposable(IDisposable item)
			{
				this.item = item;
			}
		}

		[Serializable]
		[DebuggerTypeProxy(typeof(ReferenceHolder_0040DebugTypeProxy))]
		[DebuggerDisplay("{__DebugDisplay(),nq}")]
		public class ReferenceHolder : ResourceType
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal readonly object item;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			[field: DebuggerNonUserCode]
			public object Item
			{
				[DebuggerNonUserCode]
				get;
			}

			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal ReferenceHolder(object item)
			{
				this.item = item;
			}
		}

		internal class Disposable_0040DebugTypeProxy
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal Disposable _obj;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public IDisposable Item
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
			public Disposable_0040DebugTypeProxy(Disposable obj)
			{
				_obj = obj;
			}
		}

		internal class ReferenceHolder_0040DebugTypeProxy
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			internal ReferenceHolder _obj;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			[CompilerGenerated]
			[DebuggerNonUserCode]
			public object Item
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
			public ReferenceHolder_0040DebugTypeProxy(ReferenceHolder obj)
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
				return (this is ReferenceHolder) ? 1 : 0;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsDisposable
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			get
			{
				return this is Disposable;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool IsReferenceHolder
		{
			[CompilerGenerated]
			[DebuggerNonUserCode]
			get
			{
				return this is ReferenceHolder;
			}
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal ResourceType()
		{
		}

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static ResourceType NewDisposable(IDisposable item)
		{
			return new Disposable(item);
		}

		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public static ResourceType NewReferenceHolder(object item)
		{
			return new ReferenceHolder(item);
		}

		[CompilerGenerated]
		[DebuggerNonUserCode]
		internal object __DebugDisplay()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ResourceType, string>>((PrintfFormat<FSharpFunc<ResourceType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ResourceType, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
		}

		[CompilerGenerated]
		public override string ToString()
		{
			return ExtraTopLevelOperators.PrintFormatToString<FSharpFunc<ResourceType, string>>((PrintfFormat<FSharpFunc<ResourceType, string>, Unit, string, string>)(object)new PrintfFormat<FSharpFunc<ResourceType, string>, Unit, string, string, ResourceType>("%+A")).Invoke(this);
		}

		[CompilerGenerated]
		public sealed override int GetHashCode(IEqualityComparer comp)
		{
			if (this != null)
			{
				int num = 0;
				if (this is Disposable)
				{
					Disposable disposable = (Disposable)this;
					num = 0;
					return -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<IDisposable>(comp, disposable.item) + ((num << 6) + (num >> 2)));
				}
				ReferenceHolder referenceHolder = (ReferenceHolder)this;
				num = 1;
				return -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<object>(comp, referenceHolder.item) + ((num << 6) + (num >> 2)));
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
				ResourceType resourceType = obj as ResourceType;
				if (resourceType != null)
				{
					ResourceType resourceType2 = resourceType;
					int num = (this is ReferenceHolder) ? 1 : 0;
					ResourceType resourceType3 = resourceType2;
					int num2 = (resourceType3 is ReferenceHolder) ? 1 : 0;
					if (num == num2)
					{
						if (this is Disposable)
						{
							Disposable disposable = (Disposable)this;
							Disposable disposable2 = (Disposable)resourceType2;
							return HashCompare.GenericEqualityWithComparerIntrinsic<IDisposable>(comp, disposable.item, disposable2.item);
						}
						ReferenceHolder referenceHolder = (ReferenceHolder)this;
						ReferenceHolder referenceHolder2 = (ReferenceHolder)resourceType2;
						return HashCompare.GenericEqualityWithComparerIntrinsic<object>(comp, referenceHolder.item, referenceHolder2.item);
					}
					return false;
				}
				return false;
			}
			return obj == null;
		}

		[CompilerGenerated]
		public sealed override bool Equals(ResourceType obj)
		{
			if (this != null)
			{
				if (obj != null)
				{
					int num = (this is ReferenceHolder) ? 1 : 0;
					int num2 = (obj is ReferenceHolder) ? 1 : 0;
					if (num == num2)
					{
						if (this is Disposable)
						{
							Disposable disposable = (Disposable)this;
							Disposable disposable2 = (Disposable)obj;
							return HashCompare.GenericEqualityERIntrinsic<IDisposable>(disposable.item, disposable2.item);
						}
						ReferenceHolder referenceHolder = (ReferenceHolder)this;
						ReferenceHolder referenceHolder2 = (ReferenceHolder)obj;
						return HashCompare.GenericEqualityERIntrinsic<object>(referenceHolder.item, referenceHolder2.item);
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
			ResourceType resourceType = obj as ResourceType;
			if (resourceType != null)
			{
				return Equals(resourceType);
			}
			return false;
		}
	}
}
