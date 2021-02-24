/*****************************************************************************
   Copyright 2018 The MxNet.Sharp Authors. All Rights Reserved.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;

namespace MxNet
{
    public class _NumpyShapeScope : MxDisposable
    {
        public _NumpyShapeScope(bool is_np_shape)
        {
            throw new NotImplementedException();
        }

        public override void Exit()
        {
            throw new NotImplementedException();
        }

        public override MxDisposable With()
        {
            throw new NotImplementedException();
        }
    }

    public class _NumpyArrayScope : MxDisposable
    {
        public _NumpyArrayScope(bool is_np_array)
        {
            throw new NotImplementedException();
        }

        public override void Exit()
        {
            throw new NotImplementedException();
        }

        public override MxDisposable With()
        {
            throw new NotImplementedException();
        }
    }

    public class _NumpyDefaultDtypeScope : MxDisposable
    {
        public _NumpyDefaultDtypeScope(bool is_np_shape)
        {
            throw new NotImplementedException();
        }

        public override void Exit()
        {
            throw new NotImplementedException();
        }

        public override MxDisposable With()
        {
            throw new NotImplementedException();
        }
    }

    public class MxUtil
    {
        public static string EnumToString<TEnum>(TEnum? _enum, List<string> convert) where TEnum : struct, IConvertible
        {
            if (_enum.HasValue)
            {
                var v = _enum.Value as object;
                return convert[(int) v];
            }

            return null;
        }

        public static void ValidateParam(string name, string value, params string[] validValues)
        {
            if (!validValues.Contains(value))
            {
                var message = "Invalid value for " + name + ". Valid values are " + string.Join(", ", validValues);
                throw new Exception(message);
            }
        }

        public static IntPtr[] GetNDArrayHandles(NDArrayList list)
        {
            return list.Select(x => x.GetHandle()).ToArray();
        }

        public static List<T> Set<T>(List<T> keys)
        {
            return keys.Distinct().OrderBy(x => x).ToList();
        }

        public static (Shape, Shape) GetSliceNotation(string slice, Shape shape)
        {
            string[] split = slice.Split(',');
            int[] begin = new int[split.Length];
            int[] end = new int[split.Length];
            for (int i = 0; i < split.Length; i++)
            {
                begin[i] = 0;
                end[i] = shape[i];
                var range = split[i].Contains(":") ? split[i].Split(':') : null;
                if (range != null)
                {
                    begin[i] = !string.IsNullOrEmpty(range[0]) ? Convert.ToInt32(range[0].Trim()) : begin[i];
                    end[i] = !string.IsNullOrEmpty(range[1]) ? Convert.ToInt32(range[1].Trim()) : end[i];
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(split[i]))
                    {
                        begin[i] = Convert.ToInt32(split[i].Trim());
                        end[i] = begin[i] + 1;
                    }
                }
            }

            return (new Shape(begin), new Shape(end));
        }

        public static int GetGPUCount()
        {
            throw new NotImplementedException();
        }

        public static (long, long) GetGPUMemory(int gpu_dev_id)
        {
            throw new NotImplementedException();
        }

        public static bool SetNpShape(bool active)
        {
            throw new NotImplementedException();
        }

        public static bool IsNpShape()
        {
            throw new NotImplementedException();
        }

        public static _NumpyShapeScope NpShape(bool active)
        {
            throw new NotImplementedException();
        }

        public static Func<Dictionary<string, object>, NDArrayOrSymbol> UseNpShape(Func<Dictionary<string, object>, NDArrayOrSymbol> func)
        {
            throw new NotImplementedException();
        }

        public static void SanityCheckParams(string func_name, string[] unsupported_params, Dictionary<string, object> param_dict)
        {
            throw new NotImplementedException();
        }

        public static void SetModule(string module)
        {
            throw new NotImplementedException();
        }

        public static _NumpyArrayScope NpArray(bool active)
        {
            throw new NotImplementedException();
        }

        public static bool IsNpArray()
        {
            throw new NotImplementedException();
        }

        public static Func<Dictionary<string, object>, NDArrayOrSymbol> UseNpArray(Func<Dictionary<string, object>, NDArrayOrSymbol> func)
        {
            throw new NotImplementedException();
        }

        public static Func<Dictionary<string, object>, NDArrayOrSymbol> UseNp(Func<Dictionary<string, object>, NDArrayOrSymbol> func)
        {
            throw new NotImplementedException();
        }

        public static bool UseUFuncLegalOption(string key, string value)
        {
            throw new NotImplementedException();
        }

        public static Func<NDArray, NDArray> WrapNpUraryFunc(Func<NDArray, NDArray> func)
        {
            throw new NotImplementedException();
        }

        public static Func<NDArray, NDArray, NDArray> WrapNpBinaryFunc(Func<NDArray, NDArray, NDArray> func)
        {
            throw new NotImplementedException();
        }

        public static bool SetNpArray(bool active)
        {
            throw new NotImplementedException();
        }

        public static bool SetNp(bool shape = true, bool array = true, bool dtype = false)
        {
            throw new NotImplementedException();
        }

        public static void ResetNp()
        {
            SetNp(false, false, false);
        }

        public static int GetCudaComputeCapability(Context ctx)
        {
            throw new NotImplementedException();
        }

        public static NDArray DefaultArray(Array source_array, Context ctx= null, DType dtype= null)
        {
            throw new NotImplementedException();
        }

        public static _NumpyDefaultDtypeScope NpDefaultDtype(bool active = true)
        {
            throw new NotImplementedException();
        }

        public static Func<Dictionary<string, object>, NDArrayOrSymbol> UseNpDefaultDtype(Func<Dictionary<string, object>, NDArrayOrSymbol> func)
        {
            throw new NotImplementedException();
        }

        public static bool IsNpDefaultDtype()
        {
            throw new NotImplementedException();
        }

        public static bool SetNpDefaultDtype()
        {
            throw new NotImplementedException();
        }

        public static string GetEnv(string name)
        {
            throw new NotImplementedException();
        }

        public static string SetEnv(string name, string value)
        {
            throw new NotImplementedException();
        }
    }
}