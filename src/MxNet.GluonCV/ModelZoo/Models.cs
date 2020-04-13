using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo
{
    public class Models
    {
        public static T GetModel<T>(string name, bool pretrained, string[] classes = null, Context ctx = null, string root = "")
        {
            var type = typeof(T);
            var method = type.GetMethod(name);
            var parameters = method.GetParameters();
            List<object> args = new List<object>();
            foreach (var item in parameters)
            {
                if(item.Name == "pretrained")
                {
                    args.Add(pretrained);
                }
                else if (item.Name == "classes")
                {
                    args.Add(classes);
                }
                else if (item.Name == "ctx")
                {
                    args.Add(ctx);
                }
                else if (item.Name == "root")
                {
                    args.Add(root);
                }
                else
                {
                    args.Add(item.DefaultValue);
                }
            }

            return (T)method.Invoke(default(T), args.ToArray());
        }
    }
}
