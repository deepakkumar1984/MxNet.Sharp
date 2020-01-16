using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MXNetSharp.Interop
{
	[CompilationMapping(/*Could not decode attribute arguments.*/)]
	public static class CApi
	{
		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate void EngineAsyncFunc(IntPtr, IntPtr, IntPtr);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate void EngineSyncFunc(IntPtr, IntPtr);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate void EngineFuncParamDeleter(IntPtr);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate void ExecutorMonitorCallback(string, IntPtr, IntPtr);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate void CachedOpMonitorCallback(string, string, IntPtr);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate void NativeOpInfo_forward(int, ref float[], int[], ref int[], int[], IntPtr);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate void NativeOpInfo_backward(int, ref float[], int[], ref int[], int[], IntPtr);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate void NativeOpInfo_infer_shape(int, int[], ref int[], IntPtr);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate void NativeOpInfo_list_outputs(ref string[], IntPtr);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate void NativeOpInfo_list_arguments(ref string[], IntPtr);

		[Serializable]
		[Struct]
		[NoComparison]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public struct NativeOpInfo : IEquatable<NativeOpInfo>, IStructuralEquatable
		{
			internal NativeOpInfo_forward forward_0040;

			internal NativeOpInfo_backward backward_0040;

			internal NativeOpInfo_infer_shape infer_shape_0040;

			internal NativeOpInfo_list_outputs list_outputs_0040;

			internal NativeOpInfo_list_arguments list_arguments_0040;

			internal IntPtr p_forward_0040;

			internal IntPtr p_backward_0040;

			internal IntPtr p_infer_shape_0040;

			internal IntPtr p_list_outputs_0040;

			internal IntPtr p_list_arguments_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public NativeOpInfo_forward forward => forward_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public NativeOpInfo_backward backward => backward_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public NativeOpInfo_infer_shape infer_shape => infer_shape_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public NativeOpInfo_list_outputs list_outputs => list_outputs_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public NativeOpInfo_list_arguments list_arguments => list_arguments_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public IntPtr p_forward => p_forward_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public IntPtr p_backward => p_backward_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public IntPtr p_infer_shape => p_infer_shape_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public IntPtr p_list_outputs => p_list_outputs_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public IntPtr p_list_arguments => p_list_arguments_0040;

			[CompilerGenerated]
			public unsafe sealed override int GetHashCode(IEqualityComparer comp)
			{
				int num = 0;
				IntPtr intPtr = p_list_arguments_0040;
				IntPtr intPtr2 = intPtr;
				num = -1640531527 + ((int)(ulong)(UIntPtr)(void*)(long)intPtr2 + ((num << 6) + (num >> 2)));
				IntPtr intPtr3 = p_list_outputs_0040;
				IntPtr intPtr4 = intPtr3;
				num = -1640531527 + ((int)(ulong)(UIntPtr)(void*)(long)intPtr4 + ((num << 6) + (num >> 2)));
				IntPtr intPtr5 = p_infer_shape_0040;
				IntPtr intPtr6 = intPtr5;
				num = -1640531527 + ((int)(ulong)(UIntPtr)(void*)(long)intPtr6 + ((num << 6) + (num >> 2)));
				IntPtr intPtr7 = p_backward_0040;
				IntPtr intPtr8 = intPtr7;
				num = -1640531527 + ((int)(ulong)(UIntPtr)(void*)(long)intPtr8 + ((num << 6) + (num >> 2)));
				IntPtr intPtr9 = p_forward_0040;
				IntPtr intPtr10 = intPtr9;
				num = -1640531527 + ((int)(ulong)(UIntPtr)(void*)(long)intPtr10 + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<NativeOpInfo_list_arguments>(comp, list_arguments_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<NativeOpInfo_list_outputs>(comp, list_outputs_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<NativeOpInfo_infer_shape>(comp, infer_shape_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<NativeOpInfo_backward>(comp, backward_0040) + ((num << 6) + (num >> 2)));
				return -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<NativeOpInfo_forward>(comp, forward_0040) + ((num << 6) + (num >> 2)));
			}

			[CompilerGenerated]
			public sealed override int GetHashCode()
			{
				return GetHashCode(LanguagePrimitives.get_GenericEqualityComparer());
			}

			[CompilerGenerated]
			public sealed override bool Equals(object obj, IEqualityComparer comp)
			{
				if (IntrinsicFunctions.TypeTestGeneric<NativeOpInfo>(obj))
				{
					NativeOpInfo nativeOpInfo = (NativeOpInfo)obj;
					if (HashCompare.GenericEqualityWithComparerIntrinsic<NativeOpInfo_forward>(comp, forward_0040, nativeOpInfo.forward_0040))
					{
						if (HashCompare.GenericEqualityWithComparerIntrinsic<NativeOpInfo_backward>(comp, backward_0040, nativeOpInfo.backward_0040))
						{
							if (HashCompare.GenericEqualityWithComparerIntrinsic<NativeOpInfo_infer_shape>(comp, infer_shape_0040, nativeOpInfo.infer_shape_0040))
							{
								if (HashCompare.GenericEqualityWithComparerIntrinsic<NativeOpInfo_list_outputs>(comp, list_outputs_0040, nativeOpInfo.list_outputs_0040))
								{
									if (HashCompare.GenericEqualityWithComparerIntrinsic<NativeOpInfo_list_arguments>(comp, list_arguments_0040, nativeOpInfo.list_arguments_0040))
									{
										if (p_forward_0040 == nativeOpInfo.p_forward_0040)
										{
											if (p_backward_0040 == nativeOpInfo.p_backward_0040)
											{
												if (p_infer_shape_0040 == nativeOpInfo.p_infer_shape_0040)
												{
													if (p_list_outputs_0040 == nativeOpInfo.p_list_outputs_0040)
													{
														return p_list_arguments_0040 == nativeOpInfo.p_list_arguments_0040;
													}
													return false;
												}
												return false;
											}
											return false;
										}
										return false;
									}
									return false;
								}
								return false;
							}
							return false;
						}
						return false;
					}
					return false;
				}
				return false;
			}

			[CompilerGenerated]
			public sealed override bool Equals(NativeOpInfo obj)
			{
				if (HashCompare.GenericEqualityERIntrinsic<NativeOpInfo_forward>(forward_0040, obj.forward_0040))
				{
					if (HashCompare.GenericEqualityERIntrinsic<NativeOpInfo_backward>(backward_0040, obj.backward_0040))
					{
						if (HashCompare.GenericEqualityERIntrinsic<NativeOpInfo_infer_shape>(infer_shape_0040, obj.infer_shape_0040))
						{
							if (HashCompare.GenericEqualityERIntrinsic<NativeOpInfo_list_outputs>(list_outputs_0040, obj.list_outputs_0040))
							{
								if (HashCompare.GenericEqualityERIntrinsic<NativeOpInfo_list_arguments>(list_arguments_0040, obj.list_arguments_0040))
								{
									if (p_forward_0040 == obj.p_forward_0040)
									{
										if (p_backward_0040 == obj.p_backward_0040)
										{
											if (p_infer_shape_0040 == obj.p_infer_shape_0040)
											{
												if (p_list_outputs_0040 == obj.p_list_outputs_0040)
												{
													return p_list_arguments_0040 == obj.p_list_arguments_0040;
												}
												return false;
											}
											return false;
										}
										return false;
									}
									return false;
								}
								return false;
							}
							return false;
						}
						return false;
					}
					return false;
				}
				return false;
			}

			[CompilerGenerated]
			public sealed override bool Equals(object obj)
			{
				if (IntrinsicFunctions.TypeTestGeneric<NativeOpInfo>(obj))
				{
					NativeOpInfo obj2 = (NativeOpInfo)obj;
					return Equals(obj2);
				}
				return false;
			}
		}

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate bool NDArrayOpInfo_forward(int, IntPtr, int[], IntPtr);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate bool NDArrayOpInfo_backward(int, IntPtr, int[], IntPtr);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate bool NDArrayOpInfo_infer_shape(int, int[], ref int[], IntPtr);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate bool NDArrayOpInfo_list_outputs(ref string[], IntPtr);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate bool NDArrayOpInfo_list_arguments(ref string[], IntPtr);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate bool NDArrayOpInfo_declare_backward_dependency(int[], int[], int[], int[], ref int[], IntPtr);

		[Serializable]
		[Struct]
		[NoComparison]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public struct NDArrayOpInfo : IEquatable<NDArrayOpInfo>, IStructuralEquatable
		{
			internal NDArrayOpInfo_forward forward_0040;

			internal NDArrayOpInfo_backward backward_0040;

			internal NDArrayOpInfo_infer_shape infer_shape_0040;

			internal NDArrayOpInfo_list_outputs list_outputs_0040;

			internal NDArrayOpInfo_list_arguments list_arguments_0040;

			internal NDArrayOpInfo_declare_backward_dependency declare_backward_dependency_0040;

			internal IntPtr p_forward_0040;

			internal IntPtr p_backward_0040;

			internal IntPtr p_infer_shape_0040;

			internal IntPtr p_list_outputs_0040;

			internal IntPtr p_list_arguments_0040;

			internal IntPtr p_declare_backward_dependency_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public NDArrayOpInfo_forward forward => forward_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public NDArrayOpInfo_backward backward => backward_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public NDArrayOpInfo_infer_shape infer_shape => infer_shape_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public NDArrayOpInfo_list_outputs list_outputs => list_outputs_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public NDArrayOpInfo_list_arguments list_arguments => list_arguments_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public NDArrayOpInfo_declare_backward_dependency declare_backward_dependency => declare_backward_dependency_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public IntPtr p_forward => p_forward_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public IntPtr p_backward => p_backward_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public IntPtr p_infer_shape => p_infer_shape_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public IntPtr p_list_outputs => p_list_outputs_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public IntPtr p_list_arguments => p_list_arguments_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public IntPtr p_declare_backward_dependency => p_declare_backward_dependency_0040;

			[CompilerGenerated]
			public unsafe sealed override int GetHashCode(IEqualityComparer comp)
			{
				int num = 0;
				IntPtr intPtr = p_declare_backward_dependency_0040;
				IntPtr intPtr2 = intPtr;
				num = -1640531527 + ((int)(ulong)(UIntPtr)(void*)(long)intPtr2 + ((num << 6) + (num >> 2)));
				IntPtr intPtr3 = p_list_arguments_0040;
				IntPtr intPtr4 = intPtr3;
				num = -1640531527 + ((int)(ulong)(UIntPtr)(void*)(long)intPtr4 + ((num << 6) + (num >> 2)));
				IntPtr intPtr5 = p_list_outputs_0040;
				IntPtr intPtr6 = intPtr5;
				num = -1640531527 + ((int)(ulong)(UIntPtr)(void*)(long)intPtr6 + ((num << 6) + (num >> 2)));
				IntPtr intPtr7 = p_infer_shape_0040;
				IntPtr intPtr8 = intPtr7;
				num = -1640531527 + ((int)(ulong)(UIntPtr)(void*)(long)intPtr8 + ((num << 6) + (num >> 2)));
				IntPtr intPtr9 = p_backward_0040;
				IntPtr intPtr10 = intPtr9;
				num = -1640531527 + ((int)(ulong)(UIntPtr)(void*)(long)intPtr10 + ((num << 6) + (num >> 2)));
				IntPtr intPtr11 = p_forward_0040;
				IntPtr intPtr12 = intPtr11;
				num = -1640531527 + ((int)(ulong)(UIntPtr)(void*)(long)intPtr12 + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<NDArrayOpInfo_declare_backward_dependency>(comp, declare_backward_dependency_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<NDArrayOpInfo_list_arguments>(comp, list_arguments_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<NDArrayOpInfo_list_outputs>(comp, list_outputs_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<NDArrayOpInfo_infer_shape>(comp, infer_shape_0040) + ((num << 6) + (num >> 2)));
				num = -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<NDArrayOpInfo_backward>(comp, backward_0040) + ((num << 6) + (num >> 2)));
				return -1640531527 + (HashCompare.GenericHashWithComparerIntrinsic<NDArrayOpInfo_forward>(comp, forward_0040) + ((num << 6) + (num >> 2)));
			}

			[CompilerGenerated]
			public sealed override int GetHashCode()
			{
				return GetHashCode(LanguagePrimitives.get_GenericEqualityComparer());
			}

			[CompilerGenerated]
			public sealed override bool Equals(object obj, IEqualityComparer comp)
			{
				if (IntrinsicFunctions.TypeTestGeneric<NDArrayOpInfo>(obj))
				{
					NDArrayOpInfo nDArrayOpInfo = (NDArrayOpInfo)obj;
					if (HashCompare.GenericEqualityWithComparerIntrinsic<NDArrayOpInfo_forward>(comp, forward_0040, nDArrayOpInfo.forward_0040))
					{
						if (HashCompare.GenericEqualityWithComparerIntrinsic<NDArrayOpInfo_backward>(comp, backward_0040, nDArrayOpInfo.backward_0040))
						{
							if (HashCompare.GenericEqualityWithComparerIntrinsic<NDArrayOpInfo_infer_shape>(comp, infer_shape_0040, nDArrayOpInfo.infer_shape_0040))
							{
								if (HashCompare.GenericEqualityWithComparerIntrinsic<NDArrayOpInfo_list_outputs>(comp, list_outputs_0040, nDArrayOpInfo.list_outputs_0040))
								{
									if (HashCompare.GenericEqualityWithComparerIntrinsic<NDArrayOpInfo_list_arguments>(comp, list_arguments_0040, nDArrayOpInfo.list_arguments_0040))
									{
										if (HashCompare.GenericEqualityWithComparerIntrinsic<NDArrayOpInfo_declare_backward_dependency>(comp, declare_backward_dependency_0040, nDArrayOpInfo.declare_backward_dependency_0040))
										{
											if (p_forward_0040 == nDArrayOpInfo.p_forward_0040)
											{
												if (p_backward_0040 == nDArrayOpInfo.p_backward_0040)
												{
													if (p_infer_shape_0040 == nDArrayOpInfo.p_infer_shape_0040)
													{
														if (p_list_outputs_0040 == nDArrayOpInfo.p_list_outputs_0040)
														{
															if (p_list_arguments_0040 == nDArrayOpInfo.p_list_arguments_0040)
															{
																return p_declare_backward_dependency_0040 == nDArrayOpInfo.p_declare_backward_dependency_0040;
															}
															return false;
														}
														return false;
													}
													return false;
												}
												return false;
											}
											return false;
										}
										return false;
									}
									return false;
								}
								return false;
							}
							return false;
						}
						return false;
					}
					return false;
				}
				return false;
			}

			[CompilerGenerated]
			public sealed override bool Equals(NDArrayOpInfo obj)
			{
				if (HashCompare.GenericEqualityERIntrinsic<NDArrayOpInfo_forward>(forward_0040, obj.forward_0040))
				{
					if (HashCompare.GenericEqualityERIntrinsic<NDArrayOpInfo_backward>(backward_0040, obj.backward_0040))
					{
						if (HashCompare.GenericEqualityERIntrinsic<NDArrayOpInfo_infer_shape>(infer_shape_0040, obj.infer_shape_0040))
						{
							if (HashCompare.GenericEqualityERIntrinsic<NDArrayOpInfo_list_outputs>(list_outputs_0040, obj.list_outputs_0040))
							{
								if (HashCompare.GenericEqualityERIntrinsic<NDArrayOpInfo_list_arguments>(list_arguments_0040, obj.list_arguments_0040))
								{
									if (HashCompare.GenericEqualityERIntrinsic<NDArrayOpInfo_declare_backward_dependency>(declare_backward_dependency_0040, obj.declare_backward_dependency_0040))
									{
										if (p_forward_0040 == obj.p_forward_0040)
										{
											if (p_backward_0040 == obj.p_backward_0040)
											{
												if (p_infer_shape_0040 == obj.p_infer_shape_0040)
												{
													if (p_list_outputs_0040 == obj.p_list_outputs_0040)
													{
														if (p_list_arguments_0040 == obj.p_list_arguments_0040)
														{
															return p_declare_backward_dependency_0040 == obj.p_declare_backward_dependency_0040;
														}
														return false;
													}
													return false;
												}
												return false;
											}
											return false;
										}
										return false;
									}
									return false;
								}
								return false;
							}
							return false;
						}
						return false;
					}
					return false;
				}
				return false;
			}

			[CompilerGenerated]
			public sealed override bool Equals(object obj)
			{
				if (IntrinsicFunctions.TypeTestGeneric<NDArrayOpInfo>(obj))
				{
					NDArrayOpInfo obj2 = (NDArrayOpInfo)obj;
					return Equals(obj2);
				}
				return false;
			}
		}

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate int MXGenericCallback();

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate int MXCallbackList_callbacks();

		[Serializable]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		[Struct]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public struct MXCallbackList : IEquatable<MXCallbackList>, IStructuralEquatable, IComparable<MXCallbackList>, IComparable, IStructuralComparable
		{
			public int num_callbacks;

			public IntPtr callbacks;

			public IntPtr contexts;

			[CompilerGenerated]
			public sealed override int CompareTo(MXCallbackList obj)
			{
				IComparer genericComparer = LanguagePrimitives.get_GenericComparer();
				int num = num_callbacks;
				int num2 = obj.num_callbacks;
				int num3 = (num >= num2) ? ((num > num2) ? 1 : 0) : (-1);
				if (num3 < 0)
				{
					return num3;
				}
				if (num3 > 0)
				{
					return num3;
				}
				IComparer genericComparer2 = LanguagePrimitives.get_GenericComparer();
				IntPtr intPtr = callbacks;
				IntPtr intPtr2 = obj.callbacks;
				int num4 = ((long)intPtr >= (long)intPtr2) ? (((long)intPtr > (long)intPtr2) ? 1 : 0) : (-1);
				if (num4 < 0)
				{
					return num4;
				}
				if (num4 > 0)
				{
					return num4;
				}
				IComparer genericComparer3 = LanguagePrimitives.get_GenericComparer();
				IntPtr intPtr3 = contexts;
				IntPtr intPtr4 = obj.contexts;
				if ((long)intPtr3 < (long)intPtr4)
				{
					return -1;
				}
				return ((long)intPtr3 > (long)intPtr4) ? 1 : 0;
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj)
			{
				return CompareTo((MXCallbackList)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				MXCallbackList mXCallbackList = (MXCallbackList)obj;
				int num = num_callbacks;
				int num2 = mXCallbackList.num_callbacks;
				int num3 = (num >= num2) ? ((num > num2) ? 1 : 0) : (-1);
				if (num3 < 0)
				{
					return num3;
				}
				if (num3 > 0)
				{
					return num3;
				}
				IntPtr intPtr = callbacks;
				IntPtr intPtr2 = mXCallbackList.callbacks;
				int num4 = ((long)intPtr >= (long)intPtr2) ? (((long)intPtr > (long)intPtr2) ? 1 : 0) : (-1);
				if (num4 < 0)
				{
					return num4;
				}
				if (num4 > 0)
				{
					return num4;
				}
				IntPtr intPtr3 = contexts;
				IntPtr intPtr4 = mXCallbackList.contexts;
				if ((long)intPtr3 < (long)intPtr4)
				{
					return -1;
				}
				return ((long)intPtr3 > (long)intPtr4) ? 1 : 0;
			}

			[CompilerGenerated]
			public unsafe sealed override int GetHashCode(IEqualityComparer comp)
			{
				int num = 0;
				IntPtr intPtr = contexts;
				IntPtr intPtr2 = intPtr;
				num = -1640531527 + ((int)(ulong)(UIntPtr)(void*)(long)intPtr2 + ((num << 6) + (num >> 2)));
				IntPtr intPtr3 = callbacks;
				IntPtr intPtr4 = intPtr3;
				num = -1640531527 + ((int)(ulong)(UIntPtr)(void*)(long)intPtr4 + ((num << 6) + (num >> 2)));
				return -1640531527 + (num_callbacks + ((num << 6) + (num >> 2)));
			}

			[CompilerGenerated]
			public sealed override int GetHashCode()
			{
				return GetHashCode(LanguagePrimitives.get_GenericEqualityComparer());
			}

			[CompilerGenerated]
			public sealed override bool Equals(object obj, IEqualityComparer comp)
			{
				if (IntrinsicFunctions.TypeTestGeneric<MXCallbackList>(obj))
				{
					MXCallbackList mXCallbackList = (MXCallbackList)obj;
					if (num_callbacks == mXCallbackList.num_callbacks)
					{
						if (callbacks == mXCallbackList.callbacks)
						{
							return contexts == mXCallbackList.contexts;
						}
						return false;
					}
					return false;
				}
				return false;
			}

			[CompilerGenerated]
			public sealed override bool Equals(MXCallbackList obj)
			{
				if (num_callbacks == obj.num_callbacks)
				{
					if (callbacks == obj.callbacks)
					{
						return contexts == obj.contexts;
					}
					return false;
				}
				return false;
			}

			[CompilerGenerated]
			public sealed override bool Equals(object obj)
			{
				if (IntrinsicFunctions.TypeTestGeneric<MXCallbackList>(obj))
				{
					MXCallbackList obj2 = (MXCallbackList)obj;
					return Equals(obj2);
				}
				return false;
			}
		}

		[Serializable]
		[Struct]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public struct LibFeature : IEquatable<LibFeature>, IStructuralEquatable, IComparable<LibFeature>, IComparable, IStructuralComparable
		{
			internal string name_0040;

			internal bool enabled_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public string name => name_0040;

			[CompilationMapping(/*Could not decode attribute arguments.*/)]
			public bool enabled => enabled_0040;

			[CompilerGenerated]
			public sealed override int CompareTo(LibFeature obj)
			{
				IComparer genericComparer = LanguagePrimitives.get_GenericComparer();
				int num = string.CompareOrdinal(name_0040, obj.name_0040);
				if (num < 0)
				{
					return num;
				}
				if (num > 0)
				{
					return num;
				}
				IComparer genericComparer2 = LanguagePrimitives.get_GenericComparer();
				bool flag = enabled_0040;
				bool flag2 = obj.enabled_0040;
				if ((flag ? 1 : 0) < (flag2 ? 1 : 0))
				{
					return -1;
				}
				return ((flag ? 1 : 0) > (flag2 ? 1 : 0)) ? 1 : 0;
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj)
			{
				return CompareTo((LibFeature)obj);
			}

			[CompilerGenerated]
			public sealed override int CompareTo(object obj, IComparer comp)
			{
				LibFeature libFeature = (LibFeature)obj;
				int num = string.CompareOrdinal(name_0040, libFeature.name_0040);
				if (num < 0)
				{
					return num;
				}
				if (num > 0)
				{
					return num;
				}
				bool flag = enabled_0040;
				bool flag2 = libFeature.enabled_0040;
				if ((flag ? 1 : 0) < (flag2 ? 1 : 0))
				{
					return -1;
				}
				return ((flag ? 1 : 0) > (flag2 ? 1 : 0)) ? 1 : 0;
			}

			[CompilerGenerated]
			public sealed override int GetHashCode(IEqualityComparer comp)
			{
				int num = 0;
				num = -1640531527 + ((enabled_0040 ? 1 : 0) + ((num << 6) + (num >> 2)));
				return -1640531527 + ((name_0040?.GetHashCode() ?? 0) + ((num << 6) + (num >> 2)));
			}

			[CompilerGenerated]
			public sealed override int GetHashCode()
			{
				return GetHashCode(LanguagePrimitives.get_GenericEqualityComparer());
			}

			[CompilerGenerated]
			public sealed override bool Equals(object obj, IEqualityComparer comp)
			{
				if (IntrinsicFunctions.TypeTestGeneric<LibFeature>(obj))
				{
					LibFeature libFeature = (LibFeature)obj;
					if (string.Equals(name_0040, libFeature.name_0040))
					{
						return enabled_0040 == libFeature.enabled_0040;
					}
					return false;
				}
				return false;
			}

			[CompilerGenerated]
			public sealed override bool Equals(LibFeature obj)
			{
				if (string.Equals(name_0040, obj.name_0040))
				{
					return enabled_0040 == obj.enabled_0040;
				}
				return false;
			}

			[CompilerGenerated]
			public sealed override bool Equals(object obj)
			{
				if (IntrinsicFunctions.TypeTestGeneric<LibFeature>(obj))
				{
					LibFeature obj2 = (LibFeature)obj;
					return Equals(obj2);
				}
				return false;
			}
		}

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public enum CustomOpCallbacks
		{
			kCustomOpDelete,
			kCustomOpForward,
			kCustomOpBackward
		}

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public enum CustomOpPropCallbacks
		{
			kCustomOpPropDelete,
			kCustomOpPropListArguments,
			kCustomOpPropListOutputs,
			kCustomOpPropListAuxiliaryStates,
			kCustomOpPropInferShape,
			kCustomOpPropDeclareBackwardDependency,
			kCustomOpPropCreateOperator,
			kCustomOpPropInferType,
			kCustomOpPropInferStorageType,
			kCustomOpPropBackwardInferStorageType
		}

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate bool CustomOpFBFunc(int size, IntPtr ptrs, IntPtr tags, IntPtr reqs, bool isTrain, IntPtr state);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate bool CustomOpDelFunc(IntPtr state);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate bool CustomOpListFunc(ref IntPtr args, IntPtr state);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate bool CustomOpInferShapeFunc(int numInput, IntPtr ndims, IntPtr shapes, IntPtr state);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate bool CustomOpInferStorageTypeFunc(int numInput, IntPtr stypes, IntPtr state);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate bool CustomOpBackwardInferStorageTypeFunc(IntPtr numInput, IntPtr stypes, IntPtr tags, IntPtr state);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate bool CustomOpInferTypeFunc(int numInput, IntPtr types, IntPtr state);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate bool CustomOpBwdDepFunc(IntPtr outGrad, IntPtr inData, IntPtr outData, ref int numDeps, ref IntPtr rdeps, IntPtr state);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate bool CustomOpCreateFunc(string context, int numInputs, IntPtr shapes, IntPtr ndims, IntPtr dtypes, ref MXCallbackList ret, IntPtr state);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate bool CustomOpPropCreator(string op_type, int numArgs, IntPtr keys, IntPtr values, ref MXCallbackList ret);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public enum CustomFunctionCallbacks
		{
			kCustomFunctionBackward,
			kCustomFunctionDelete
		}

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate bool CustomFunctionBwdFunc(int, int, IntPtr, int[], int, IntPtr);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate bool CustomFunctionDelFunc(IntPtr);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate void MXKVStoreUpdater(int, IntPtr, IntPtr, IntPtr);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate void MXKVStoreStrUpdater(string, IntPtr, IntPtr, IntPtr);

		[Serializable]
		[CompilationMapping(/*Could not decode attribute arguments.*/)]
		public delegate void MXKVStoreServerController(int, string, IntPtr);

		[Literal]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public const string MXNETLIB = "libmxnet";

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern IntPtr MXGetLastError();

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXLoadLib(string path);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXLibInfoFeatures(out IntPtr libFeature, out int size);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXRandomSeed(int seed);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXRandomSeedContext(int seed, int dev_type, int dev_id);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNotifyShutdown();

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSetProcessProfilerConfig__(int num_params, string keys, string vals, IntPtr kvstoreHandle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSetProfilerConfig__(int num_params, string keys, string vals);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSetProcessProfilerState__(int state, int profile_process, IntPtr kvStoreHandle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSetProfilerState__(int state);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXDumpProcessProfile__(int finished, int profile_process, IntPtr kvStoreHandle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXDumpProfile__(int finished);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXAggregateProfileStatsPrint__(string[] out_str, int reset);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXAggregateProfileStatsPrintEx__(string[] out_str, int reset, int format, int sort_by, int ascending);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXProcessProfilePause__(int paused, int profile_process, IntPtr kvStoreHandle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXProfilePause__(int paused);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXProfileCreateDomain__(string domain, IntPtr[] @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXProfileCreateTask__(IntPtr domain, string task_name, IntPtr[] @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXProfileCreateFrame__(IntPtr domain, string frame_name, IntPtr[] @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXProfileCreateEvent__(string event_name, IntPtr[] @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXProfileCreateCounter__(IntPtr domain, string counter_name, IntPtr[] @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXProfileDestroyHandle__(IntPtr frame_handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXProfileDurationStart__(IntPtr duration_handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXProfileDurationStop__(IntPtr duration_handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXProfileSetCounter__(IntPtr counter_handle, ulong value);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXProfileAdjustCounter__(IntPtr counter_handle, long value);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXProfileSetMarker__(IntPtr domain, string instant_marker_name, string scope);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSetNumOMPThreads__(int thread_num);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXEngineSetBulkSize__(int bulk_size, int[] prev_bulk_size);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXGetGPUCount(out int @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXGetGPUMemoryInformation__(int dev, int[] free_mem, int[] total_mem);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXGetGPUMemoryInformation64__(int dev, ulong[] free_mem, ulong[] total_mem);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXGetVersion(out int @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXLoadTVMOp__(string libpath);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayCreateNone(out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayCreate(uint[] shape, uint ndim, int dev_type, int dev_id, int delay_alloc, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayCreateEx(uint[] shape, uint ndim, int dev_type, int dev_id, int delay_alloc, int dtype, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayCreateEx64(long[] shape, int ndim, int dev_type, int dev_id, int delay_alloc, int dtype, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayCreateSparseEx(int storage_type, uint[] shape, uint ndim, int dev_type, int dev_id, int delay_alloc, int dtype, uint num_aux, int[] aux_type, uint[] aux_ndims, uint[] aux_shape, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayCreateSparseEx64(int storage_type, long[] shape, int ndim, int dev_type, int dev_id, int delay_alloc, int dtype, uint num_aux, int[] aux_type, int[] aux_ndims, long[] aux_shape, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayLoadFromRawBytes(byte[] buf, long size, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArraySaveRawBytes(IntPtr handle, out long out_size, out IntPtr out_buf);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArraySave(string fname, uint num_args, IntPtr[] args, string[] keys);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayLoad(string fname, out uint out_size, out IntPtr out_arr, out uint out_name_size, out IntPtr out_names);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayLoadFromBuffer(IntPtr ndarray_buffer, long size, out uint out_size, out IntPtr out_arr, out uint out_name_size, out IntPtr out_names);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArraySyncCopyFromCPU(IntPtr handle, IntPtr data, long size);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArraySyncCopyToCPU(IntPtr handle, IntPtr data, long size);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArraySyncCopyFromNDArray(IntPtr handle_dst, IntPtr handle_src, int i);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArraySyncCheckFormat(IntPtr handle, bool full_check);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayWaitToRead(IntPtr handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayWaitToWrite(IntPtr handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayWaitAll();

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayFree(IntPtr handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArraySlice(IntPtr handle, uint slice_begin, uint slice_end, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArraySlice64(IntPtr handle, long slice_begin, long slice_end, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayAt(IntPtr handle, uint idx, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayAt64(IntPtr handle, long idx, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayGetStorageType(IntPtr handle, out int out_storage_type);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayReshape(IntPtr handle, int ndim, int[] dims, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayReshape64(IntPtr handle, int ndim, long[] dims, bool reverse, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayGetShapeEx(IntPtr handle, out int out_dim, out IntPtr out_pdata);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayGetShapeEx64(IntPtr handle, out int out_dim, out IntPtr out_pdata);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayGetData(IntPtr handle, out IntPtr out_pdata);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayToDLPack(IntPtr handle, out IntPtr out_dlpack);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayFromDLPackEx(IntPtr dlpack, bool transient_handle, out IntPtr out_handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayCallDLPackDeleter(IntPtr dlpack);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayGetDType(IntPtr handle, out int out_dtype);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayGetAuxType(IntPtr handle, uint i, out int out_type);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayGetAuxType64(IntPtr handle, long i, out int out_type);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayGetAuxNDArray(IntPtr handle, uint i, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayGetAuxNDArray64(IntPtr handle, long i, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayGetDataNDArray(IntPtr handle, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayGetContext(IntPtr handle, out int out_dev_type, out int out_dev_id);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayGetGrad(IntPtr handle, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayDetach(IntPtr handle, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArraySetGradState(IntPtr handle, int state);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayGetGradState(IntPtr handle, out int @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXListFunctions(out uint out_size, out IntPtr out_array);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXGetFunction__(string name, IntPtr[] @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXFuncGetInfo(IntPtr fun, out IntPtr name, out IntPtr description, out uint num_args, out IntPtr arg_names, out IntPtr arg_type_infos, out IntPtr arg_descriptions, out IntPtr return_type);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXFuncDescribe__(IntPtr fun, uint[] num_use_vars, uint[] num_scalars, uint[] num_mutate_vars, int[] type_mask);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public unsafe static extern int MXFuncInvoke__(IntPtr fun, IntPtr[] use_vars, double* scalar_args, IntPtr[] mutate_vars);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public unsafe static extern int MXFuncInvokeEx__(IntPtr fun, IntPtr[] use_vars, double* scalar_args, IntPtr[] mutate_vars, int num_params, string[] param_keys, string[] param_vals);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXImperativeInvoke(IntPtr creator, int num_inputs, IntPtr[] inputs, ref int num_outputs, ref IntPtr outputs, int num_params, string[] param_keys, string[] param_vals);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXImperativeInvokeEx__(IntPtr creator, int num_inputs, IntPtr[] inputs, int[] num_outputs, ref IntPtr[] outputs, int num_params, string[] param_keys, string[] param_vals, ref int[] out_stypes);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXAutogradSetIsRecording(int is_recording, out int prev);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXAutogradSetIsTraining(int is_training, out int prev);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXAutogradIsRecording(out bool curr);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXAutogradIsTraining(out bool curr);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXIsNumpyShape(out bool curr);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSetIsNumpyShape(int is_np_shape, out int prev);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXAutogradMarkVariables(uint num_var, IntPtr[] var_handles, uint[] reqs_array, IntPtr[] grad_handles);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXAutogradComputeGradient(uint num_output, IntPtr[] output_handles);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXAutogradBackward(uint num_output, IntPtr[] output_handles, IntPtr[] ograd_handles, int retain_graph);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXAutogradBackwardEx(uint num_output, IntPtr[] output_handles, IntPtr[] ograd_handles, uint num_variables, IntPtr[] var_handles, int retain_graph, int create_graph, int is_train, out IntPtr grad_handles, out IntPtr grad_stypes);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXAutogradGetSymbol(IntPtr handle, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXCreateCachedOp__(IntPtr handle, IntPtr[] @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXCreateCachedOpEx__(IntPtr handle, int num_flags, string[] keys, string[] vals, IntPtr[] @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXFreeCachedOp__(IntPtr handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXInvokeCachedOp__(IntPtr handle, int num_inputs, IntPtr[] inputs, int[] num_outputs, ref IntPtr[] outputs);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXInvokeCachedOpEx__(IntPtr handle, int num_inputs, IntPtr[] inputs, int[] num_outputs, ref IntPtr[] outputs, ref int[] out_stypes);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXCachedOpRegisterOpHook__(IntPtr handle, CachedOpMonitorCallback callback, bool monitor_all);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXListAllOpNames(ref uint out_size, ref IntPtr out_array);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolListAtomicSymbolCreators(out uint out_size, out IntPtr out_array);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolGetAtomicSymbolName(IntPtr creator, out IntPtr name);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolGetInputSymbols(IntPtr sym, out IntPtr inputs, out int input_size);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolCutSubgraph(IntPtr sym, out IntPtr inputs, out int input_size);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolGetAtomicSymbolInfo(IntPtr creator, out IntPtr name, out IntPtr description, out uint num_args, out IntPtr arg_names, out IntPtr arg_type_infos, out IntPtr arg_descriptions, out IntPtr key_var_num_args, out IntPtr return_type);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolCreateAtomicSymbol(IntPtr creator, uint num_param, string[] keys, string[] vals, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolCreateVariable(string name, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolCreateGroup(uint num_symbols, IntPtr[] symbols, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolCreateFromFile(string fname, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolCreateFromJSON(string json, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolRemoveAmpCast(IntPtr sym_handle, out IntPtr ret_sym_handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolSaveToFile(IntPtr symbol, string fname);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolSaveToJSON(IntPtr symbol, out IntPtr out_json);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolFree(IntPtr symbol);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolCopy(IntPtr symbol, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolPrint(IntPtr symbol, out IntPtr out_str);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolGetName(IntPtr symbol, out IntPtr @out, out int success);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolGetAttr(IntPtr symbol, string key, out IntPtr @out, out int success);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolSetAttr(IntPtr symbol, string key, string value);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolListAttr(IntPtr symbol, out uint out_size, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolListAttrShallow(IntPtr symbol, out uint out_size, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolListArguments(IntPtr symbol, out uint out_size, out IntPtr out_str_array);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolListOutputs(IntPtr symbol, out uint out_size, out IntPtr out_str_array);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolGetNumOutputs(IntPtr symbol, out uint output_count);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolGetInternals(IntPtr symbol, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolGetChildren(IntPtr symbol, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolGetOutput(IntPtr symbol, uint index, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolListAuxiliaryStates(IntPtr symbol, out uint out_size, out IntPtr out_str_array);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolCompose(IntPtr sym, string name, uint num_args, string[] keys, IntPtr[] args);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolGrad(IntPtr sym, uint num_wrt, string[] wrt, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolInferShapeEx(IntPtr sym, uint num_args, string[] keys, uint[] arg_ind_ptr, int[] arg_shape_data, out uint in_shape_size, out IntPtr in_shape_ndim, out IntPtr in_shape_data, out uint out_shape_size, out IntPtr out_shape_ndim, out IntPtr out_shape_data, out uint aux_shape_size, out IntPtr aux_shape_ndim, out IntPtr aux_shape_data, out int complete);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolInferShapeEx64(IntPtr sym, uint num_args, string[] keys, long[] arg_ind_ptr, long[] arg_shape_data, out long in_shape_size, out IntPtr in_shape_ndim, out IntPtr in_shape_data, out long out_shape_size, out IntPtr out_shape_ndim, out IntPtr out_shape_data, out long aux_shape_size, out IntPtr aux_shape_ndim, out IntPtr aux_shape_data, out int complete);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolInferShapePartialEx(IntPtr sym, uint num_args, string[] keys, uint[] arg_ind_ptr, int[] arg_shape_data, out uint in_shape_size, out IntPtr in_shape_ndim, out IntPtr in_shape_data, out uint out_shape_size, out IntPtr out_shape_ndim, out IntPtr out_shape_data, out uint aux_shape_size, out IntPtr aux_shape_ndim, out IntPtr aux_shape_data, out int complete);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolInferShapePartialEx64(IntPtr sym, uint num_args, string[] keys, long[] arg_ind_ptr, long[] arg_shape_data, out long in_shape_size, out IntPtr in_shape_ndim, out IntPtr in_shape_data, out long out_shape_size, out IntPtr out_shape_ndim, out IntPtr out_shape_data, out long aux_shape_size, out IntPtr aux_shape_ndim, out IntPtr aux_shape_data, out int complete);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolInferType(IntPtr sym, uint num_args, string[] keys, int[] arg_type_data, out uint in_type_size, out IntPtr in_type_data, out uint out_type_size, out IntPtr out_type_data, out uint aux_type_size, out IntPtr aux_type_data, out int complete);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSymbolInferTypePartial(IntPtr sym, uint num_args, string[] keys, int[] arg_type_data, out uint in_type_size, out IntPtr in_type_data, out uint out_type_size, out IntPtr out_type_data, out uint aux_type_size, out IntPtr aux_type_data, out int complete);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXQuantizeSymbol(IntPtr sym_handle, out IntPtr ret_sym_handle, out int dev_type, uint num_excluded_sym_names, string[] excluded_sym_names, uint num_excluded_op_names, string[] excluded_op_names, uint num_offline, string[] offline_params, string quantized_dtype, bool calib_quantize, string quantize_mode, out uint out_num_calib_names, out IntPtr out_calib_names);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXReducePrecisionSymbol(IntPtr sym_handle, out IntPtr ret_sym_handle, uint num_args, int[] arg_type_data, uint num_ind_ptr, int[] ind_ptr, int[] target_dtype, int cast_optional_params, uint num_target_dtype_op_names, uint num_fp32_op_names, uint num_widest_dtype_op_names, uint num_conditional_fp32_op_names, uint num_excluded_symbols, uint num_model_params, string[] target_dtype_op_names, string[] fp32_op_names, string[] widest_dtype_op_names, string[] conditional_fp32_op_names, string[] excluded_symbols, string[] conditional_param_names, string[] conditional_param_vals, string[] model_param_names, string[] arg_names);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXSetCalibTableToQuantizedSymbol(IntPtr qsym_handle, uint num_layers, string[] layer_names, float[] low_quantiles, float[] high_quantiles, out IntPtr ret_sym_handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXGenBackendSubgraph(IntPtr sym_handle, string backend, out IntPtr ret_sym_handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXGenAtomicSymbolFromSymbol(IntPtr sym_handle, out IntPtr ret_sym_handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXOptimizeForBackend(IntPtr sym_handle, string backend_name, int dev_type, IntPtr[] ret_sym_handle, uint len, IntPtr[] in_args_handle, uint num_options, string[] keys, string[] vals);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXExecutorFree(IntPtr handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXExecutorPrint(IntPtr handle, out IntPtr out_str);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXExecutorForward(IntPtr handle, int is_train);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXExecutorBackward(IntPtr handle, uint len, IntPtr[] head_grads);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXExecutorBackwardEx(IntPtr handle, uint len, IntPtr[] head_grads, int is_train);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXExecutorOutputs(IntPtr handle, out uint out_size, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXExecutorBind(IntPtr symbol_handle, int dev_type, int dev_id, uint len, IntPtr[] in_args, IntPtr[] arg_grad_store, uint[] grad_req_type, uint aux_states_len, IntPtr[] aux_states, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXExecutorBindX(IntPtr symbol_handle, int dev_type, int dev_id, uint num_map_keys, string[] map_keys, int[] map_dev_types, int[] map_dev_ids, uint len, IntPtr[] in_args, IntPtr[] arg_grad_store, uint[] grad_req_type, uint aux_states_len, IntPtr[] aux_states, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXExecutorBindEX(IntPtr symbol_handle, int dev_type, int dev_id, uint num_map_keys, string[] map_keys, int[] map_dev_types, int[] map_dev_ids, uint len, IntPtr[] in_args, IntPtr[] arg_grad_store, uint[] grad_req_type, uint aux_states_len, IntPtr[] aux_states, IntPtr shared_exec, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXExecutorSimpleBindEx(IntPtr symbol_handle, int dev_type, int dev_id, uint num_g2c_keys, string[] g2c_keys, int[] g2c_dev_types, int[] g2c_dev_ids, uint provided_grad_req_list_len, string[] provided_grad_req_names, string[] provided_grad_req_types, uint num_provided_arg_shapes, string[] provided_arg_shape_names, int[] provided_arg_shape_data, uint[] provided_arg_shape_idx, uint num_provided_arg_dtypes, string[] provided_arg_dtype_names, int[] provided_arg_dtypes, uint num_provided_arg_stypes, string[] provided_arg_stype_names, int[] provided_arg_stypes, uint num_shared_arg_names, string[] shared_arg_name_list, int[] shared_buffer_len, string[] shared_buffer_name_list, IntPtr[] shared_buffer_handle_list, ref string[] updated_shared_buffer_name_list, ref IntPtr[] updated_shared_buffer_handle_list, uint[] num_in_args, ref IntPtr[] in_args, ref IntPtr[] arg_grads, uint[] num_aux_states, ref IntPtr[] aux_states, IntPtr shared_exec_handle, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXExecutorReshapeEx(int partial_shaping, int allow_up_sizing, int dev_type, int dev_id, uint num_map_keys, string[] map_keys, int[] map_dev_types, int[] map_dev_ids, uint num_provided_arg_shapes, string[] provided_arg_shape_names, int[] provided_arg_shape_data, uint[] provided_arg_shape_idx, uint num_in_args, IntPtr[] in_args, IntPtr[] arg_grads, uint num_aux_states, IntPtr[] aux_states, IntPtr shared_exec, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXExecutorGetOptimizedSymbol(IntPtr handle, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXExecutorSetMonitorCallback(IntPtr handle, ExecutorMonitorCallback callback, out IntPtr callback_handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXExecutorSetMonitorCallbackEX(IntPtr handle, ExecutorMonitorCallback callback, out IntPtr callback_handle, bool monitor_all);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXListDataIters(out uint out_size, out IntPtr out_array);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXDataIterCreateIter(IntPtr handle, uint num_param, string[] keys, string[] vals, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXDataIterGetIterInfo(IntPtr creator, out IntPtr name, out IntPtr description, out uint num_args, out IntPtr arg_names, out IntPtr arg_type_infos, out IntPtr arg_descriptions);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXDataIterFree(IntPtr handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXDataIterNext(IntPtr handle, out int @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXDataIterBeforeFirst(IntPtr handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXDataIterGetData(IntPtr handle, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXDataIterGetIndex(IntPtr handle, out IntPtr out_index, out ulong out_size);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXDataIterGetPadNum(IntPtr handle, out int pad);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXDataIterGetLabel(IntPtr handle, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXInitPSEnv(uint num_vars, string[] keys, string[] vals);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStoreCreate(string type, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStoreSetGradientCompression(IntPtr handle, uint num_params, string[] keys, string[] vals);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStoreFree(IntPtr handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStoreInit(IntPtr handle, uint num, int[] keys, IntPtr[] vals);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStoreInitEx(IntPtr handle, uint num, string[] keys, IntPtr[] vals);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStorePush(IntPtr handle, uint num, int[] keys, IntPtr[] vals, int priority);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStorePushEx(IntPtr handle, uint num, string[] keys, IntPtr[] vals, int priority);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStorePullWithSparse(IntPtr handle, uint num, int[] keys, out IntPtr vals, int priority, bool ignore_sparse);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStorePullWithSparseEx(IntPtr handle, uint num, string[] keys, out IntPtr vals, int priority, bool ignore_sparse);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStorePull(IntPtr handle, uint num, int[] keys, out IntPtr vals, int priority);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStorePullEx(IntPtr handle, uint num, string[] keys, out IntPtr vals, int priority);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStorePullRowSparse(IntPtr handle, uint num, int[] keys, out IntPtr vals, out IntPtr row_ids, int priority);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStorePullRowSparseEx(IntPtr handle, uint num, string[] keys, out IntPtr vals, out IntPtr row_ids, int priority);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStorePushPull(IntPtr handle, uint vnum, int[] vkeys, uint onum, int[] okeys, IntPtr[] vals, out IntPtr outs, int priority);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStorePushPullEx(IntPtr handle, uint vnum, string[] vkeys, uint onum, string[] okeys, IntPtr[] vals, out IntPtr outs, int priority);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStoreSetUpdater(IntPtr handle, MXKVStoreUpdater updater, IntPtr updater_handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStoreSetUpdaterEx(IntPtr handle, MXKVStoreUpdater updater, MXKVStoreStrUpdater str_updater, IntPtr updater_handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStoreGetType(IntPtr handle, out IntPtr type);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStoreGetRank__(IntPtr handle, int[] ret);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStoreGetGroupSize__(IntPtr handle, int[] ret);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStoreIsWorkerNode__(int[] ret);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStoreIsServerNode__(int[] ret);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStoreIsSchedulerNode__(int[] ret);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStoreBarrier__(IntPtr handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStoreSetBarrierBeforeExit__(IntPtr handle, int barrier_before_exit);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStoreRunServer__(IntPtr handle, MXKVStoreServerController controller, IntPtr controller_handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStoreSendCommmandToServers__(IntPtr handle, int cmd_id, string cmd_body);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXKVStoreGetNumDeadNode__(IntPtr handle, int node_id, int[] number, int timeout_sec);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXRecordIOWriterCreate__(string uri, IntPtr[] @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXRecordIOWriterFree__(IntPtr handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXRecordIOWriterWriteRecord__(IntPtr handle, string buf, long size);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXRecordIOWriterTell__(IntPtr handle, long[] pos);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXRecordIOReaderCreate__(string uri, IntPtr[] @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXRecordIOReaderFree__(IntPtr handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXRecordIOReaderReadRecord__(IntPtr handle, string[] buf, long[] size);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXRecordIOReaderSeek__(IntPtr handle, long pos);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXRecordIOReaderTell__(IntPtr handle, long[] pos);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXRtcCreate__(string name, uint num_input, uint num_output, string[] input_names, string[] output_names, IntPtr[] inputs, out IntPtr outputs, string kernel, IntPtr[] @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXRtcPush__(IntPtr handle, uint num_input, uint num_output, IntPtr[] inputs, out IntPtr outputs, uint gridDimX, uint gridDimY, uint gridDimZ, uint blockDimX, uint blockDimY, uint blockDimZ);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXRtcFree__(IntPtr handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXCustomOpRegister(string op_type, CustomOpPropCreator creator);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXCustomFunctionRecord__(int num_inputs, IntPtr[] inputs, int num_outputs, out IntPtr outputs, MXCallbackList[] callbacks);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXRtcCudaModuleCreate(string source, int num_options, string[] options, int num_exports, string[] exports, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXRtcCudaModuleFree(IntPtr handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXRtcCudaKernelCreate(IntPtr handle, string name, int num_args, int[] is_ndarray, int[] is_const, int[] arg_types, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXRtcCudaKernelFree(IntPtr handle);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXRtcCudaKernelCall(IntPtr handle, int dev_id, IntPtr[] args, uint grid_dim_x, uint grid_dim_y, uint grid_dim_z, uint block_dim_x, uint block_dim_y, uint block_dim_z, uint shared_mem);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayGetSharedMemHandle__(IntPtr handle, int[] shared_pid, int[] shared_id);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayCreateFromSharedMem__(int shared_pid, int shared_id, uint[] shape, uint ndim, int dtype, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXStorageEmptyCache__(int dev_type, int dev_id);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXNDArrayCreateFromSharedMemEx__(int shared_pid, int shared_id, int[] shape, int ndim, int dtype, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXEnginePushAsync(EngineAsyncFunc async_func, IntPtr func_param, EngineFuncParamDeleter deleter, IntPtr ctx_handle, IntPtr _vars_handle, int num_const_vars, IntPtr mutable_vars_handle, int num_mutable_vars, IntPtr prop_handle, int priority, string opr_name, bool wait);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXEnginePushSync(EngineSyncFunc sync_func, IntPtr func_param, EngineFuncParamDeleter deleter, IntPtr ctx_handle, IntPtr _vars_handle, int num_const_vars, IntPtr mutable_vars_handle, int num_mutable_vars, IntPtr prop_handle, int priority, string opr_name);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXEnginePushAsyncND(EngineAsyncFunc async_func, IntPtr func_param, EngineFuncParamDeleter deleter, IntPtr ctx_handle, IntPtr[] _nds_handle, int num_const_nds, IntPtr[] mutable_nds_handle, int num_mutable_nds, IntPtr prop_handle, int priority, string opr_name, bool wait);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXEnginePushSyncND(EngineSyncFunc sync_func, IntPtr func_param, EngineFuncParamDeleter deleter, IntPtr ctx_handle, IntPtr[] _nds_handle, int num_const_nds, IntPtr[] mutable_nds_handle, int num_mutable_nds, IntPtr prop_handle, int priority, string opr_name);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXShallowCopyNDArray__(IntPtr src, out IntPtr @out);

		[DllImport("libmxnet", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern int MXShallowCopySymbol__(IntPtr src, IntPtr[] @out);
	}
}
