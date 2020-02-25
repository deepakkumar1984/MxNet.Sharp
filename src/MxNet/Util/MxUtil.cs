using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNet
{
    public class MxUtil
    {
        public static string EnumToString<TEnum>(TEnum? _enum, List<string> convert) where TEnum : struct, IConvertible
        {
            if (_enum.HasValue)
            {
                var v = _enum.Value as object;
                return convert[(int)v];
            }

            return null;

        }

        public static void ValidateParam(string name, string value, params string[] validValues)
        {
            if (!validValues.Contains(value))
            {
                string message = "Invalid value for " + name + ". Valid values are " + string.Join(", ", validValues);
                throw new Exception(message);
            }
        }

        public static IntPtr[] GetNDArrayHandles(NDArrayList list)
        {
            return list.Select(x => (x.GetHandle())).ToArray();
        }

        public static List<T> Set<T>(List<T> keys)
        {
            return keys.Distinct().OrderBy(x => x).ToList();
        }

        public static (int,int,int,int) GetSliceNotation(string slice, Shape shape)
        {
            int rowBegin = 0, rowEnd = shape[0], colBegin = 0, colEnd = 0;

            if (slice.Contains(","))
            {
                string[] splitRowCol = slice.Split(',');
                string rowSpan = splitRowCol[0];
                string colSpan = splitRowCol[1];
                string[] rowRange = rowSpan.Contains(":") ? rowSpan.Split(':') : null;
                if (rowRange != null)
                {
                    rowBegin = !string.IsNullOrEmpty(rowRange[0]) ? Convert.ToInt32(rowRange[0].Trim()) : rowBegin;
                    rowEnd = !string.IsNullOrEmpty(rowRange[1]) ? Convert.ToInt32(rowRange[1].Trim()) : rowEnd;
                }
                else
                {
                    if(!string.IsNullOrWhiteSpace(rowSpan))
                    {
                        rowEnd = Convert.ToInt32(rowSpan.Trim());
                        rowBegin = rowEnd - 1;
                    }
                }

                string[] colRange = colSpan.Contains(":") ? colSpan.Split(':') : null;
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
                string[] rowRange = slice.Contains(":") ? slice.Split(':') : null;
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
