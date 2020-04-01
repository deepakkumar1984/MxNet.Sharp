using MxNet.Gluon;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.GluonCV.ModelZoo
{
    public class LayerUtils
    {
        public static HybridBlock NormLayer(string layer_name, FuncArgs kwargs)
        {
            string typeName = $"MxNet.Gluon.NN.{layer_name}";
            var normLayer = Type.GetType(typeName, true, true);
            var constructor = normLayer.GetConstructors(System.Reflection.BindingFlags.Public).FirstOrDefault();
            var constructorParams = constructor.GetParameters();
            List<object> args = new List<object>();
            foreach (var item in constructorParams)
            {
                if(kwargs.Contains(item.Name))
                {
                    args.Add(kwargs[item.Name]);
                }
                else
                {
                    args.Add(item.DefaultValue);
                }
            }

            return (HybridBlock)Activator.CreateInstance(normLayer, args.ToArray());
        }
    }
}
