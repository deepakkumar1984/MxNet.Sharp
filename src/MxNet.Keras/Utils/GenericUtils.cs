using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace MxNet.Keras.Utils
{
    public class GenericUtils
    {
        public static CustomObjects _GLOBAL_CUSTOM_OBJECTS = new CustomObjects();

        public static CustomObjectScope CustomObjectScope(CustomObjects args)
        {
            return new CustomObjectScope(args);
        }

        public static CustomObjects GetCustomObjects()
        {
            return _GLOBAL_CUSTOM_OBJECTS;
        }

        public static KerasObject SerializeKerasObject(object instance)
        {
            if (instance == null)
                return null;

            var methods = instance.GetType().GetMethods();
            var getconfig = methods.Where(x => x.Name.ToLower() == "getconfig").FirstOrDefault();
            if(getconfig == null)
            {
                return null;
            }

            ConfigDict config = (ConfigDict)getconfig.Invoke(instance, new object[0]);
            return new KerasObject(instance.GetType().FullName, config);
        }

        public static object DeserializeKerasObject(object identifier, string module_objects = "", CustomObjects custom_objects = null, string printable_module_name = "object")
        {
            throw new NotImplementedException();
        }

        public static (byte[] code, ParameterInfo[] defaults, LocalVariableInfo[] closure ) FuncDump(MethodInfo func)
        {
            var code = func.GetMethodBody().GetILAsByteArray();
            var parameters = func.GetParameters();
            var variables = func.GetMethodBody().LocalVariables.ToArray();
            return (code, parameters, variables);
        }

        public static MethodInfo FuncLoad(byte[] code, ParameterInfo[] defaults = null, LocalVariableInfo[] closure = null, Dictionary<string, object> globs = null)
        {
            throw new NotImplementedException();
        }

        public static bool HasArg(MethodInfo fn, string name, bool accept_all = false)
        {
            var args = fn.GetParameters();
            if (accept_all && args != null)
                return true;

            return args.Where(x => (x.Name == name)).Count() > 0;
        }

        public static string ObjectListUid<T>(T[] object_list)
        {
            var idList = object_list.Select(x => Math.Abs(x != null ? new ObjectIDGenerator().GetId(x, out var ft) : new object().GetHashCode())).ToList();
            return string.Join(", ", idList);
        }

        public static bool IsAllNone<T>(T[] iterable_or_element)
        {
            foreach (var item in iterable_or_element)
            {
                if (item != null)
                    return false;
            }

            return true;
        }

        public static NDArray SliceArrays(NDArray arrays, int start, int? end = null)
        {
            if (arrays == null)
            {
                return new NDArray();
            }

            return arrays.Slice(start, end);
        }

        public static NDArray[] SliceArrays(NDArray[] arrays, int start, int? end = null)
        {
            return arrays.Select(x => SliceArrays(x, start, end)).ToArray();
        }

        public static NDArray SliceArrays(NDArray arrays, Shape start, Shape end = null)
        {
            if (arrays == null)
            {
                return new NDArray();
            }

            return arrays.Slice(start, end);
        }

        public static NDArray[] SliceArrays(NDArray[] arrays, Shape start = null, Shape end = null)
        {
            return arrays.Select(x => SliceArrays(x, start, end)).ToArray();
        }

        public static Shape TransposeShape(Shape shape, string target_format, Shape spatial_axes)
        {
            if (target_format == "channels_first")
            {
                var new_values = new List<int> { shape[spatial_axes[0]] };
                new_values.Add(shape[-1]);
                new_values.AddRange((from x in spatial_axes.Data
                                    select shape[x]));
                return new Shape(new_values);
            }
            else if (target_format == "channels_last")
            {
                return shape;
            }
            else
            {
                throw new Exception("The `data_format` argument must be one of \"channels_first\", \"channels_last\". Received: " + target_format.ToString());
            }
        }
    }
}
