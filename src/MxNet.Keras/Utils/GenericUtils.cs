using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            throw new NotImplementedException();
        }

        public static bool IsAllNone<T>(T[] iterable_or_element)
        {
            throw new NotImplementedException();
        }

        public static T[] SliceArrays<T>(T[] arrays, int? start = null, int? end = null)
        {
            throw new NotImplementedException();
        }

        public static int[] TransposeShape(int[] shape, string target_format, int[] spatial_axes)
        {
            throw new NotImplementedException();
        }
    }
}
