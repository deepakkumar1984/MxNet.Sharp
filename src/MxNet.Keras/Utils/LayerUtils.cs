using MxNet.Gluon.NN;
using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Utils
{
    public class LayerUtils
    {
        public static int CountParams(KerasSymbol[] weights)
        {
            return weights.Select(x => K.CountParams(x)).ToList().Sum();
        }

        public static void PrintSummary(Model model, int? line_length = null, double[] positions = null, Action<string> print_fn = null)
        {
            int trainable_count = 0;
            List<string> to_display = new List<string>();
            bool sequential_like = false;
            var relevant_nodes = new List<Node>();
            if (print_fn == null)
            {
                print_fn = Console.WriteLine;
            }
            
            if (model.GetType().Name == "Sequential")
            {
                sequential_like = true;
            }
            else if (!model._is_graph_network)
            {
                // We treat subclassed models as a simple sequence of layers,
                // for logging purposes.
                sequential_like = true;
            }
            else
            {
                sequential_like = true;
                var nodes_by_depth = model._nodes_by_depth.Values;
                var nodes = new List<Node>();
                foreach (var v in nodes_by_depth)
                {
                    if (v.Count > 1 || v.Count == 1 && v[0].inbound_layers.Length > 1)
                    {
                        // if the model has multiple nodes
                        // or if the nodes have multiple inbound_layers
                        // the model is no longer sequential
                        sequential_like = false;
                        break;
                    }

                    nodes.AddRange(v);
                }
                if (sequential_like)
                {
                    // search for shared layers
                    foreach (var layer in model.Layers)
                    {
                        var flag = false;
                        foreach (var node in layer._inbound_nodes)
                        {
                            if (nodes.Contains(node))
                            {
                                if (flag)
                                {
                                    sequential_like = false;
                                    break;
                                }
                                else
                                {
                                    flag = true;
                                }
                            }
                        }
                        if (!sequential_like)
                        {
                            break;
                        }
                    }
                }
            }
            if (sequential_like)
            {
                line_length = line_length ?? 65;
                positions = positions ?? new double[] {
                    0.45,
                    0.85,
                    1.0
                };

                if (positions.Last() <= 1)
                {
                    positions = (from p in positions
                                 select line_length.Value * p).ToArray();
                }

                // header names for the different log elements
                to_display = new List<string> {
                    "Layer (type)",
                    "Output Shape",
                    "Param #"
                };
            }
            else
            {
                line_length = line_length ?? 98;
                positions = positions ?? new double[] {
                    0.33,
                    0.55,
                    0.67,
                    1.0
                };

                if (positions.Last() <= 1)
                {
                    positions = (from p in positions
                                 select line_length.Value * p).ToArray();
                }
                // header names for the different log elements
                to_display = new List<string> {
                    "Layer (type)",
                    "Output Shape",
                    "Param #",
                    "Connected to"
                };
                
                foreach (var v in model._nodes_by_depth.Values)
                {
                    relevant_nodes.AddRange(v);
                }
            }

            Action<string[], double[]> print_row = (fields, _positions) => {
                var line = "";
                foreach (var i in Enumerable.Range(0, fields.Length))
                {
                    if (i > 0)
                    {
                        line = line.Substring(0, line.Length - 1) + " ";
                    }

                    line += fields[i].ToString();
                    line = line.Substring(0, Convert.ToInt32(_positions[i]));
                    var lineCharCount = Convert.ToInt32(_positions[i] - line.Length);
                    foreach (var item in Enumerable.Range(0, lineCharCount))
                    {
                        line += " ";
                    }
                }

                print_fn(line);
            };

            string msg = "";
            foreach (var item in Enumerable.Range(0, line_length.Value))
            {
                msg += "_";
            }

            print_fn(msg);
            print_row(to_display.ToArray(), positions);

            msg = "";
            foreach (var item in Enumerable.Range(0, line_length.Value))
            {
                msg += "=";
            }
            print_fn(msg);

            Action<Layer> print_layer_summary = layer => {
                string output_shape;
                try
                {
                    output_shape = layer.OutputShape.ToString();
                }
                catch (Exception)
                {
                    output_shape = "multiple";
                }

                var name = layer.name;
                var cls_name = layer.GetType().Name;
                var fields = new List<string> {
                    name + " (" + cls_name + ")",
                    output_shape.ToString(),
                    layer.CountParams().ToString()
                };

                print_row(fields.ToArray(), positions);
            };

            Action<Layer> print_layer_summary_with_connections = layer => {
                string first_connection;
                string output_shape;
                try
                {
                    output_shape = layer.OutputShape.ToString();
                }
                catch (Exception)
                {
                    output_shape = "multiple";
                }

                var connections = new List<string>();
                foreach (var node in layer._inbound_nodes)
                {
                    if (relevant_nodes.Count > 0 && !relevant_nodes.Contains(node))
                    {
                        // node is not part of the current network
                        continue;
                    }
                    foreach (var i in Enumerable.Range(0, node.inbound_layers.Length))
                    {
                        var inbound_layer = node.inbound_layers[i].name;
                        var inbound_node_index = node.node_indices[i];
                        var inbound_tensor_index = node.tensor_indices[i];
                        connections.Add(inbound_layer + "[" + inbound_node_index.ToString() + "][" + inbound_tensor_index.ToString() + "]");
                    }
                }

                var name = layer.name;
                var cls_name = layer.GetType().Name;
                if (connections.Count == 0)
                {
                    first_connection = "";
                }
                else
                {
                    first_connection = connections[0];
                }

                var fields = new List<string> {
                    name + " (" + cls_name + ")",
                    output_shape,
                    layer.CountParams().ToString(),
                    first_connection
                };
                print_row(fields.ToArray(), positions);
                if (connections.Count > 1)
                {
                    foreach (var i in Enumerable.Range(1, connections.Count - 1))
                    {
                        fields = new List<string> {
                            "",
                            "",
                            "",
                            connections[i]
                        };
                        print_row(fields.ToArray(), positions);
                    }
                }
            };

            var layers = model.Layers;
            foreach (var i in Enumerable.Range(0, layers.Length))
            {
                if (sequential_like)
                {
                    print_layer_summary(layers[i]);
                }
                else
                {
                    print_layer_summary_with_connections(layers[i]);
                }
                if (i == layers.Length - 1)
                {
                    msg = "";
                    foreach (var item in Enumerable.Range(0, line_length.Value))
                    {
                        msg += "=";
                    }

                    print_fn(msg);
                }
                else
                {
                    msg = "";
                    foreach (var item in Enumerable.Range(0, line_length.Value))
                    {
                        msg += "=";
                    }

                    print_fn(msg);
                }
            }

            if (model._collected_trainable_weights != null)
            {
                trainable_count = model._collected_trainable_weights.Select(x => K.CountParams(x)).Sum();
            }
            else
            {
                trainable_count = model.TrainableWeights.Select(x => K.CountParams(x)).Sum();
            }

            var non_trainable_count = model.NonTrainableWeights.Select(x => K.CountParams(x)).Sum();

            print_fn($"Total params: {trainable_count + non_trainable_count}");
            print_fn($"Trainable params: {trainable_count}");
            print_fn($"Non-trainable params: {non_trainable_count}");
            msg = "";
            foreach (var item in Enumerable.Range(0, line_length.Value))
            {
                msg += "_";
            }

            print_fn(msg);
        }

        public static KerasSymbol[] GetSourceInputs(KerasSymbol tensor, Layer layer = null, int? node_index = null)
        {
            if (tensor._keras_history == null)
            {
                return new KerasSymbol[] { tensor };
            }

            if (layer == null || node_index.HasValue)
            {
                (layer, node_index, _) = tensor._keras_history.Value;
            }
            if (layer._inbound_nodes == null)
            {
                return new KerasSymbol[] { tensor };
            }
            else
            {
                var node = layer._inbound_nodes[node_index.Value];
                if (node.inbound_layers == null)
                {
                    // Reached an Input layer, stop recursion.
                    return node.input_tensors;
                }
                else
                {
                    var source_tensors = new List<KerasSymbol>();
                    foreach (var i in Enumerable.Range(0, node.inbound_layers.Length))
                    {
                        var x = node.input_tensors[i];
                        layer = node.inbound_layers[i];
                        node_index = node.node_indices[i];
                        var previous_sources = GetSourceInputs(x, layer, node_index);
                        // Avoid input redundancy.
                        foreach (var ps in previous_sources)
                        {
                            if (!source_tensors.Contains(ps))
                            {
                                source_tensors.Add(ps);
                            }
                        }
                    }

                    return source_tensors.ToArray();
                }
            }
        }
    }
}
