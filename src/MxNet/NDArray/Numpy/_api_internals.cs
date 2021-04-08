using MxNet.Numpy;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace MxNet.ND.Numpy
{
    internal class _api_internals : DynamicObject
    {
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = null;
            bool multiple = false;
            var op = new Operator("_npi_" + binder.Name);
            Dictionary<string, object> arguments = new Dictionary<string, object>();
            foreach (var item in binder.CallInfo.ArgumentNames)
            {
                arguments.Add(item, null);
            }

            

            if (arguments.Count > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    arguments[binder.CallInfo.ArgumentNames[i]] = args[i];
                }
                foreach (var (k, v) in arguments)
                {
                    object value = v;
                    if (k == "multi" && (bool)value == true)
                    {
                        multiple = true;
                        continue;
                    }

                    if (k == "dtype" && value == null)
                        value = np.Float32;

                    if (k == "ctx" && value == null)
                        value = Context.CurrentContext;

                    if (value == null)
                        continue;

                    var argType = value.GetType();
                    if (argType.Name == "ndarray")
                    {
                        op.SetInput(k, (ndarray)value);
                    }
                    else
                    {
                        op.SetParam(k, value);
                    }
                }
            }
            else
            {
                //foreach (var v in args)
                //{
                //    object value = v;
                //    if (value.GetType().Name == "DType" && value == null)
                //        value = np.Float32;

                //    if (value.GetType().Name == "Context" && value == null)
                //        value = Context.CurrentContext;
                //}

                op.Set(args);
            }

            if (multiple)
            {
                NDArrayList list = new NDArrayList();
                op.Invoke(list);
                result = list;
            }
            else
                result = op.Invoke();

            return true;
        }
    }
}
