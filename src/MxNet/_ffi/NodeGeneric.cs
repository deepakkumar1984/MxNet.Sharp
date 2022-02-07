using MxNet.ND.Numpy;
using MxNet.Numpy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNet._ffi
{
    public class NodeGeneric
    {
        private static dynamic _api_internal = new _api_internals();
        public static DType ScalarTypeInference(object value)
        {
            DType dtype = null;
            if (value.GetType().Name == "NDArray")
                dtype = ((NDArray)value).DataType;
            if (value.GetType().Name == "NDArrayOrSymbol")
                dtype = ((NDArrayOrSymbol)value).IsNDArray ? ((NDArrayOrSymbol)value).NdX.dtype : null;
            else if (value.GetType().Name == "Single")
                dtype = DType.Float32;
            else if (value.GetType().Name == "Int32")
                dtype = DType.Int32;

            return dtype;
        }

        public static dynamic ConvertToNode(object value)
        {
            if (value is object || value is ndarray)
            {
                return value;
            }
            else if (value is int)
            {
                return _api_internal._Integer(value);
            }
            else if (value is float)
            {
                return _api_internal._Float(value);
            }
            else if (value is string)
            {
                return _api_internal._String(value);
            }
            else if (value is List<object>)
            {
                List<object> list = (List<object>)value;
                var value1 = (from x in list
                         select ConvertToNode(x)).ToList();
                return _api_internal._ADT(value);
            }
            else if (value is Dictionary<string, object>)
            {
                Dictionary<string, object> vlist = (Dictionary<string, object>)value;
                Dictionary<string, object> mapping = new Dictionary<string, object>();
                foreach (var item in vlist)
                {
                    mapping.Add(item.Key, ConvertToNode(item.Value));
                }

                return _api_internal._Map(mapping);
            }

            throw new Exception(String.Format("don't know how to convert type {0} to node", value.GetType().Name));
        }

        public static dynamic Const(float value, DType dtype = null)
        {
            if (dtype == null)
            {
                dtype = ScalarTypeInference(value);
            }

            return _api_internal._const(value, dtype);
        }
    }
}
