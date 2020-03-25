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

        public static (int, int, int, int) GetSliceNotation(string slice, Shape shape)
        {
            int rowBegin = 0, rowEnd = shape[0], colBegin = 0, colEnd = 0;

            if (slice.Contains(","))
            {
                var splitRowCol = slice.Split(',');
                var rowSpan = splitRowCol[0];
                var colSpan = splitRowCol[1];
                var rowRange = rowSpan.Contains(":") ? rowSpan.Split(':') : null;
                if (rowRange != null)
                {
                    rowBegin = !string.IsNullOrEmpty(rowRange[0]) ? Convert.ToInt32(rowRange[0].Trim()) : rowBegin;
                    rowEnd = !string.IsNullOrEmpty(rowRange[1]) ? Convert.ToInt32(rowRange[1].Trim()) : rowEnd;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(rowSpan))
                    {
                        rowEnd = Convert.ToInt32(rowSpan.Trim());
                        rowBegin = rowEnd - 1;
                    }
                }

                var colRange = colSpan.Contains(":") ? colSpan.Split(':') : null;
                if (colRange != null)
                {
                    colBegin = !string.IsNullOrEmpty(colRange[0]) ? Convert.ToInt32(colRange[0].Trim()) : colBegin;
                    colEnd = !string.IsNullOrEmpty(colRange[1]) ? Convert.ToInt32(colRange[1].Trim()) : shape[1];
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(colSpan))
                    {
                        colEnd = Convert.ToInt32(colSpan.Trim());
                        colBegin = colEnd - 1;
                    }
                }
            }
            else
            {
                var rowRange = slice.Contains(":") ? slice.Split(':') : null;
                if (rowRange != null)
                {
                    rowBegin = !string.IsNullOrEmpty(rowRange[0]) ? Convert.ToInt32(rowRange[0].Trim()) : rowBegin;
                    rowEnd = !string.IsNullOrEmpty(rowRange[1]) ? Convert.ToInt32(rowRange[1].Trim()) : rowEnd;
                }
            }

            return (rowBegin, rowEnd, colBegin, colEnd);
        }
    }
}