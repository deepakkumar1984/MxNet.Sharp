using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MxNet.Keras.Engine
{
    public class BaseLayers
    {
        public static KerasSymbol[] CollectPreviousMask(KerasSymbol[]  input_tensors)
        {
            var masks = new List<KerasSymbol>();
            foreach (var x in input_tensors)
            {
                if (x._keras_history != null)
                {
                    var (inbound_layer, node_index, tensor_index) = x._keras_history.Value;
                    var node = inbound_layer._inbound_nodes[node_index];
                    var mask = node.output_masks[tensor_index];
                    masks.Add(mask);
                }
                else
                {
                    masks.Add(null);
                }
            }
            return masks.ToArray();
        }

        public static string ToSnakeCase(string name)
        {
            var intermediate = Regex.Match(name, "(.)([A-Z][a-z0-9]+)").Value;
            var insecure = Regex.Match(intermediate, "([a-z])([A-Z])").Value.ToLower();
            // If the class is private the name starts with "_" which is not secure
            // for creating scopes. We prefix the name with "private" in this case.
            if (insecure[0] != '_')
            {
                return insecure;
            }

            return "private" + insecure;
        }

        public static Shape[] CollectInputShape(KerasSymbol[] input_tensors)
        {
            var shapes = new List<Shape>();
            foreach (var x in input_tensors)
            {
                try
                {
                    shapes.Add(x.Shape);
                }
                catch (Exception)
                {
                    shapes.Add(null);
                }
            }

            return shapes.ToArray();
        }
    }
}
