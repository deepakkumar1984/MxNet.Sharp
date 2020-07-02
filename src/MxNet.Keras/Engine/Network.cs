using HDF.PInvoke;
using MxNet.Keras.Utils;
using MxNet.Optimizers;
using NumpyLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Engine
{
    public class NodeData
    {
        public string name;
        public int new_node_index;
        public int tensor_index;
        public FuncArgs kwargs;

        public NodeData(string name, int new_node_index, int tensor_index, FuncArgs kwargs)
        {
            this.name = name;
            this.new_node_index = new_node_index;
            this.tensor_index = tensor_index;
            this.kwargs = kwargs;
        }
    }

    public class Network : Layer
    {
        public object _compute_previous_mask;

        public bool _expects_training_arg;

        public List<string> _feed_input_names;

        public List<Shape> _feed_input_shapes;

        public List<KerasSymbol> _feed_inputs;

        public List<Node> _inbound_nodes;

        public KerasSymbol[] _initial_weights;

        public List<(Layer, int, int)> _input_coordinates;

        public List<Layer> _input_layers;

        public bool _is_compiled;

        public bool _is_graph_network;

        public List<Layer> _layers;

        public Dictionary<int, List<Layer>> _layers_by_depth;

        public List<KerasSymbol> _losses;

        public string[] _network_nodes;

        public Dictionary<int, List<Node>> _nodes_by_depth;

        public List<Node> _outbound_nodes;

        public List<(Layer, int, int)> _output_coordinates;

        public List<Layer> _output_layers;

        public Dictionary<string, KerasSymbol[]> _output_mask_cache;

        public Dictionary<string, Shape[]> _output_shape_cache;

        public Dictionary<string, KerasSymbol[]> _output_tensor_cache;

        public Dictionary<string, KerasSymbol> _per_input_losses;

        public Dictionary<string, (KerasSymbol, KerasSymbol)> _per_input_updates;

        public List<(KerasSymbol, KerasSymbol)> _updates;

        public bool _uses_inputs_arg;

        public bool built;

        public List<string> input_names;

        public List<KerasSymbol> inputs;

        public string name;

        public Optimizer optimizer;

        public List<string> output_names;

        public List<KerasSymbol> outputs;

        public bool supports_masking;

        public bool trainable;

        public Layer[] Layers
        {
            get
            {
                return _layers.ToArray();
            }
        }

        public new (KerasSymbol, KerasSymbol)[] Updates
        {
            get
            {
                if (!this.trainable && !this.stateful)
                {
                    return new (KerasSymbol, KerasSymbol)[0];
                }

                var updates = new List<(KerasSymbol, KerasSymbol)>();
                foreach (var layer in this.Layers)
                {
                    if (layer.Updates != null)
                    {
                        if (this._is_graph_network)
                        {
                            // Collect updates that are dependent on inputs
                            // that are part of the model.
                            foreach (var _tup_1 in layer._inbound_nodes.Select((_p_1, _p_2) => Tuple.Create(_p_2, _p_1)))
                            {
                                var node_index = _tup_1.Item1;
                                var node = _tup_1.Item2;
                                var node_key = Layer.NodeKey(layer, node_index);
                                if (this._network_nodes.Contains(node_key))
                                {
                                    // The model owns this layer node.
                                    var inputs = node.input_tensors;
                                    updates.AddRange(layer.GetUpdatesFor(inputs));
                                }
                            }

                            // Collect unconditional updates.
                            updates.AddRange(layer.GetUpdatesFor(null));
                        }
                        else
                        {
                            updates.AddRange(layer.Updates);
                        }
                    }
                }
                return updates.ToArray();
            }
        }

        public new KerasSymbol[] Losses
        {
            get
            {
                var losses = new List<KerasSymbol>();
                foreach (var layer in this.Layers)
                {
                    if (layer.Losses != null)
                    {
                        if (this._is_graph_network)
                        {
                            // Collect losses that are dependent on inputs
                            // that are part of the model.
                            foreach (var _tup_1 in layer._inbound_nodes.Select((_p_1, _p_2) => Tuple.Create(_p_2, _p_1)))
                            {
                                var node_index = _tup_1.Item1;
                                var node = _tup_1.Item2;
                                var node_key = Layer.NodeKey(layer, node_index);
                                if (this._network_nodes.Contains(node_key))
                                {
                                    // The model owns this layer node.
                                    var inputs = node.input_tensors;
                                    losses.AddRange(layer.GetLossesFor(inputs));
                                }
                            }
                            // Collect unconditional losses.
                            losses.AddRange(layer.GetLossesFor(null));
                        }
                        else
                        {
                            losses.AddRange(layer.Losses);
                        }
                    }
                }

                // Add any potential unconditional model-level loss.
                losses.AddRange(this.GetLossesFor(null));
                return losses.ToArray();
            }
        }

        public bool UseLearningPhase
        {
            get
            {
                if (this.outputs == null)
                {
                    return false;
                }

                return outputs.Select(x => x._uses_learning_phase).Any();
            }
        }

        public bool Stateful
        {
            get
            {
                return Layers.Select(x => x.stateful).Any();
            }
        }

        public (KerasSymbol, KerasSymbol)[] StateUpdates
        {
            get
            {
                var state_updates = new List<(KerasSymbol, KerasSymbol)>();
                foreach (var layer in this.Layers)
                {
                    if (layer.stateful)
                    {
                        state_updates.AddRange(layer.Updates);
                    }
                }

                return state_updates.ToArray();
            }
        }

        public new KerasSymbol[] TrainableWeights
        {
            get
            {
                if (!this.trainable)
                {
                    return new KerasSymbol[0];
                }

                var weights = new List<KerasSymbol>();
                foreach (var layer in this.Layers)
                {
                    weights.AddRange(layer.TrainableWeights);
                }

                return weights.ToArray();
            }
        }

        public new KerasSymbol[] NonTrainableWeights
        {
            get
            {
                var weights = new List<KerasSymbol>();
                foreach (var layer in this.Layers)
                {
                    weights.AddRange(layer.NonTrainableWeights);
                }

                if (!this.trainable)
                {
                    var trainable_weights = new List<KerasSymbol>();
                    foreach (var layer in this.Layers)
                    {
                        trainable_weights.AddRange(layer.TrainableWeights);
                    }

                    trainable_weights.AddRange(weights);
                    return trainable_weights.ToArray();
                }

                return weights.ToArray();
            }
        }

        public InputSpec[] InputSpec
        {
            get
            {
                if (!this._is_graph_network)
                {
                    // TODO: support it in subclassed networks after inputs are set.
                    return null;
                }

                var specs = new List<InputSpec>();
                
                foreach (var layer in _input_layers)
                {
                    if (layer.input_spec == null)
                    {
                        specs.Add(null);
                    }
                    else
                    {
                        specs.AddRange(layer.input_spec);
                    }
                }

                return specs.ToArray();
            }
        }

        public Network(KerasSymbol[] inputs = null, KerasSymbol[] outputs = null, string name = null)
        {
            if(inputs != null || outputs != null)
            {
                InitGraphNetwork(inputs, outputs);
            }
            else
            {
                InitSubclassedNetwork(name);
            }
        }

        public void BaseInit(string name = null)
        {
            // The following are implemented as property functions:
            // self.trainable_weights
            // self.non_trainable_weights
            // self.input_spec
            // self.losses
            // self.updates
            // Handle `name` argument.
            if (name == null)
            {
                var prefix = this.GetType().Name;
                name = prefix + "_" + K.GetUid(prefix).ToString();
            }
            this.name = name;
            // This acts just like the `trainable` attribute of any layer instance.
            // It does not affect users of the underlying layers, only users of the
            // Network instance.
            this.trainable = true;
            this._is_compiled = false;
            this._expects_training_arg = false;
            this._initial_weights = null;
            this.supports_masking = false;
            if (optimizer != null)
            {
                // Don't reset optimizer if already set.
                this.optimizer = null;
            }
            // Private attributes to implement compatibility with Layer.
            this._updates = new List<(KerasSymbol, KerasSymbol)>();
            this._losses = new List<KerasSymbol>();
            this._per_input_losses = new Dictionary<string, KerasSymbol>();
            this._per_input_updates = new Dictionary<string, (KerasSymbol, KerasSymbol)>();

            // All layers in order of horizontal graph traversal.
            // Entries are unique. Includes input and output layers.
            this._layers = new List<Layer>();
            // Used only in conjunction with graph-networks
            this._outbound_nodes = new List<Node>();
            this._inbound_nodes = new List<Node>();
        }

        internal void InitGraphNetwork(KerasSymbol[] inputs, KerasSymbol[]  outputs, string name= null)
        {
            KerasSymbol mask = null;
            Node node = null;
            int tensor_index = 0;
            int  node_index = 0;
            Layer layer = null;
            string cls_name;
            this._uses_inputs_arg = true;

            foreach (var x in this.inputs)
            {
                // Check that x has appropriate `_keras_history` metadata.
                if (x._keras_history == null)
                {
                    cls_name = this.GetType().Name;
                    throw new Exception("Input tensors to a " + cls_name + " " + "must come from `keras.layers.Input`. Received: " + x.ToString() + " (missing previous layer metadata).");
                }

                // Check that x is an input tensor.
                (layer, node_index, tensor_index) = x._keras_history.Value;
                if (layer._inbound_nodes.Count > 1 || layer._inbound_nodes != null && layer._inbound_nodes[0].inbound_layers != null)
                {
                    cls_name = this.GetType().Name;
                    Logger.Warning(cls_name + " inputs must come from `keras.layers.Input` (thus holding past layer metadata), they cannot be the output of a previous non-Input layer. Here, a tensor specified as input to your model was not an Input tensor, it was generated by layer " + layer.name + ".\nNote that input tensors are instantiated via `tensor = keras.layers.Input(shape)`.\nThe tensor that caused the issue was: " + x.Name.ToString());
                }
            }
            foreach (var x in this.outputs)
            {
                if (x._keras_history == null)
                {
                    cls_name = this.GetType().Name;
                    throw new Exception("Output tensors to a " + cls_name + " must be the output of a Keras `Layer` (thus holding past layer metadata). Found: " + x.ToString());
                }
            }

            this.BaseInit(name: name);
            this._compute_previous_mask = true;
            // A Network does not create weights of its own,
            // thus it is already built.
            this.built = true;
            this._is_graph_network = true;
            this._input_layers = new List<Layer>();
            this._output_layers = new List<Layer>();
            this._input_coordinates = new List<(Layer, int, int)>();
            this._output_coordinates = new List<(Layer, int, int)>();
            // This is for performance optimization when calling the Network on new
            // inputs. Every time the Network is called on a set on input tensors,
            // we compute the output tensors,
            // output masks and output shapes in one pass,
            // then cache them here. When any of these outputs is queried later, we
            // retrieve it from there instead of recomputing it.
            this._output_mask_cache = new Dictionary<string, KerasSymbol[]>();
            this._output_tensor_cache = new Dictionary<string, KerasSymbol[]>();
            this._output_shape_cache = new Dictionary<string, Shape[]>();

            // Build self._output_layers:
            foreach (var x in this.outputs)
            {
                (layer, node_index, tensor_index) = x._keras_history.Value;
                this._output_layers.Add(layer);
                this._output_coordinates.Add((layer, node_index, tensor_index));
            }

            // Build self._input_layers:
            foreach (var x in this.inputs)
            {
                (layer, node_index, tensor_index) = x._keras_history.Value;
                // It's supposed to be an input layer, so only one node
                // and one tensor output.
                Debug.Assert(node_index == 0);
                Debug.Assert(tensor_index == 0);
                this._input_layers.Add(layer);
                this._input_coordinates.Add((layer, node_index, tensor_index));
            }

            // Keep track of the network's nodes and layers.
            var (nodes, nodes_by_depth, layers, layers_by_depth) = MapGraphNetwork(this.inputs.ToArray(), this.outputs.ToArray());
            this._network_nodes = nodes.ToArray();
            this._nodes_by_depth = nodes_by_depth;
            this._layers = layers.ToList();
            this._layers_by_depth = layers_by_depth;

            new Node(outbound_layer: this,
                inbound_layers: new Layer[0],
                node_indices: new int[0],
                tensor_indices: new int[0],
                input_tensors: this.inputs.ToArray(),
                output_tensors: this.outputs.ToArray(),
                input_masks: new KerasSymbol[inputs.Length],
                output_masks: new KerasSymbol[inputs.Length],
                input_shapes: (from x in this.inputs select x._keras_shape).ToArray(),
                output_shapes: (from x in this.outputs select x._keras_shape).ToArray()); ;
            // Fill in the output mask cache.
            var masks = new List<KerasSymbol>();
            foreach (var x in this.inputs)
            {
                (layer, node_index, tensor_index) = x._keras_history.Value;
                node = layer._inbound_nodes[node_index];
                mask = node.output_masks[tensor_index];
                masks.Add(mask);
            }

            var mask_cache_key = GenericUtils.ObjectListUid(inputs);
            mask_cache_key += "_" + GenericUtils.ObjectListUid(masks.ToArray());
            masks = new List<KerasSymbol>();
            foreach (var x in this.outputs)
            {
                (layer, node_index, tensor_index) = x._keras_history.Value;
                node = layer._inbound_nodes[node_index];
                mask = node.output_masks[tensor_index];
                masks.Add(mask);
            }

            this._output_mask_cache[mask_cache_key] = masks.ToArray();
            // Build self.input_names and self.output_names.
            this.input_names = new List<string>();
            this.output_names = new List<string>();
            this._feed_input_names = new List<string>();
            this._feed_inputs = new List<KerasSymbol>();
            this._feed_input_shapes = new List<Shape>();
            foreach (var _tup_7 in this._input_layers.Select((_p_1, _p_2) => Tuple.Create(_p_2, _p_1)))
            {
                var i = _tup_7.Item1;
                layer = _tup_7.Item2;
                // Check that layer is an InputLayer.
                if (!(layer is InputLayer))
                {
                    throw new Exception($"Input layers to a `Model` must be `InputLayer` objects.");
                }

                this.input_names.Add(layer.name);
                if (layer.is_placeholder)
                {
                    this._feed_inputs.Add(layer.Input);
                    this._feed_input_names.Add(layer.name);
                    this._feed_input_shapes.Add(this.inputs[i]._keras_shape);
                }
            }
            foreach (var l in this._output_layers)
            {
                this.output_names.Add(l.name);
            }
        }

        internal void InitSubclassedNetwork(string name= null)
        {
            this.BaseInit(name: name);
            this._is_graph_network = false;
            this._expects_training_arg = trainable;
            this._uses_inputs_arg = inputs != null;
            this.outputs = null;
            this.inputs = null;
            this.built = false;
        }

        public override void ResetStates()
        {
            foreach (var layer in this._layers)
            {
                if (layer.stateful)
                {
                    layer.ResetStates();
                }
            }
        }

        public virtual Layer GetLayer(string name = null, int? index = null)
        {
            // It would be unreliable to build a dictionary
            // based on layer names, because names can potentially
            // be changed at any point by the user
            // without the network being notified of it.
            if (index != null)
            {
                if (this.Layers.Length <= index)
                {
                    throw new Exception("Was asked to retrieve layer at index " + index + " but model only has " + this.Layers.Length + " layers.");
                }
                else
                {
                    return this.Layers[index.Value];
                }
            }
            else if (name == null)
            {
                throw new Exception("Provide either a layer name or layer index.");
            }

            foreach (var layer in this.Layers)
            {
                if (layer.name == name)
                {
                    return layer;
                }
            }

            throw new Exception("No such layer: " + name);
        }

        public override NDArray[] GetWeights()
        {
            var weights = new List<KerasSymbol>();
            foreach (var layer in this.Layers)
            {
                weights.AddRange(layer.Weights);
            }

            return K.BatchGetValue(weights.ToArray());
        }

        public void SetWeights(NDArrayList weights)
        {
            var tuples = new List<(KerasSymbol, NDArray)>();
            foreach (var layer in this.Layers)
            {
                var num_param = layer.Weights.Length;
                var layer_weights = weights.Take(num_param);
                tuples = Enumerable.Zip(layer.Weights, layer_weights, (sw, w) => 
                {
                    return (sw, w);
                }).ToList();
                
                weights = weights[num_param];
            }

            K.BatchSetValue(tuples);
        }

        public KerasSymbol[] ComputeMask(KerasSymbol[] inputs, KerasSymbol mask)
        {
            List<KerasSymbol> masks = new List<KerasSymbol>();
            if (!this._is_graph_network)
            {
                return null;
            }
            
            if (mask == null)
            {
                foreach (var item in Enumerable.Range(0, inputs.Length))
                {
                    masks.Add(null);
                }
            }
            else
            {
                masks.Add(mask);
            }
            var cache_key = GenericUtils.ObjectListUid(inputs);
            cache_key += "_" + GenericUtils.ObjectListUid(masks.ToArray());
            if (this._output_mask_cache.ContainsKey(cache_key))
            {
                return this._output_mask_cache[cache_key];
            }
            else
            {
                var _tup_1 = this.RunInternalGraph(inputs, masks.ToArray());
                var output_masks = _tup_1.Item2;
                return output_masks;
            }
        }

        public Shape[] ComputeOutputShape(Shape input_shape)
        {
            int tensor_index = 0;
            int node_index = 0;
            string shape_key = null;
            Layer layer = null;
            if (!this._is_graph_network)
            {
                // Must be implemented by subclasses.
                throw new NotImplementedException();
            }

            var input_shapes = new List<Shape>() { input_shape };
            if (input_shapes.Count != this._input_layers.Count)
            {
                throw new Exception("Invalid input_shape argument " + input_shape.ToString() + ": model has " + this._input_layers.Count.ToString() + " tensor inputs.");
            }

            var cache_key = string.Join(", ", (from x in input_shapes
                                       select x.ToString()).ToList());

            if (this._output_shape_cache.ContainsKey(cache_key))
            {
                var output_shapes = this._output_shape_cache[cache_key];
                return output_shapes;
            }
            else
            {
                var output_shapes = new List<Shape>();
                // Bad luck, we have to run the graph manually.
                var layers_to_output_shapes = new Dictionary<string, Shape>
                {
                };
                foreach (var i in Enumerable.Range(0, input_shapes.Count))
                {
                    layer = this._input_layers[i];
                    input_shape = input_shapes[i];
                    // It's an input layer: compute_output_shape is identity,
                    // and there is only one node and one tensor output.
                    shape_key = layer.name + "_0_0";
                    layers_to_output_shapes[shape_key] = input_shape;
                }
                var depth_keys = this._nodes_by_depth.Keys.ToList();
                depth_keys.Reverse();
                // Iterate over nodes, by depth level.
                if (depth_keys.Count > 1)
                {
                    foreach (var depth in depth_keys)
                    {
                        var nodes = this._nodes_by_depth[depth];
                        foreach (var node in nodes)
                        {
                            // This is always a single layer, never a list.
                            layer = node.outbound_layer;
                            if (this._input_layers.Contains(layer))
                            {
                                // We've already covered the input layers
                                // a few lines above.
                                continue;
                            }
                            // Potentially redundant list,
                            // same size of node.input_tensors.
                            input_shapes = new List<Shape>();
                            foreach (var j in Enumerable.Range(0, node.inbound_layers.Length))
                            {
                                var inbound_layer = node.inbound_layers[j];
                                node_index = node.node_indices[j];
                                tensor_index = node.tensor_indices[j];
                                shape_key = inbound_layer.name;
                                shape_key += String.Format("_%s_%s", node_index, tensor_index);
                                input_shape = layers_to_output_shapes[shape_key];
                                input_shapes.Add(input_shape);
                            }

                            var output_shape = layer.ComputeOutputShape(input_shapes.ToArray());
                            
                            node_index = layer._inbound_nodes.IndexOf(node);
                            foreach (var j in Enumerable.Range(0, output_shapes.Count))
                            {
                                shape_key = layer.name + String.Format("_%s_%s", node_index, j);
                                layers_to_output_shapes[shape_key] = output_shapes[j];
                            }
                        }
                    }
                }

                // Read final output shapes from layers_to_output_shapes.
                var output_shape_keys = new List<string>();
                foreach (var i in Enumerable.Range(0, this._output_layers.Count))
                {
                    layer = this._output_layers[i];
                    node_index = this._output_coordinates[i].Item2;
                    tensor_index = this._output_coordinates[i].Item3;
                    shape_key = layer.name + String.Format($"_{node_index}_{tensor_index}");
                    output_shape_keys.Add(shape_key);
                }

                foreach (var _tup_1 in output_shape_keys.Select((_p_1, _p_2) => Tuple.Create(_p_2, _p_1)))
                {
                    var i = _tup_1.Item1;
                    var key = _tup_1.Item2;
                    Debug.Assert(layers_to_output_shapes.ContainsKey(key));
                    output_shapes.Add(layers_to_output_shapes[key]);
                }

                // Store in cache.
                this._output_shape_cache[cache_key] = output_shapes.ToArray();
                return output_shapes.ToArray();
            }
        }

        public (KerasSymbol[], KerasSymbol[], Shape[]) RunInternalGraph(KerasSymbol[] inputs, KerasSymbol[] masks = null)
        {
            Shape[] input_shapes;
            if (masks == null)
            {
                masks = new KerasSymbol[inputs.Length];
            }
            // Dictionary mapping reference tensors to tuples
            // (computed tensor, compute mask)
            // we assume a 1:1 mapping from tensor to mask
            // TODO: raise exception when a `.compute_mask()` call
            // does not return a list the same size as `call`
            var tensor_map = new Dictionary<string, (KerasSymbol, KerasSymbol)>();
            for (int i = 0; i < this.inputs.Count; i++)
            {
                var x = this.inputs[i];
                var y = inputs[i];
                var mask = masks[i];
                tensor_map[x.GetMemPtr().ToString()] = (y, mask);
            }

            var output_tensors = new List<KerasSymbol>();
            var output_masks = new List<KerasSymbol>();
            var output_shapes = new List<Shape>();

            var depth_keys = this._nodes_by_depth.Keys;
            depth_keys.Reverse();
            foreach (var depth in depth_keys)
            {
                var nodes = this._nodes_by_depth[depth];
                foreach (var node in nodes)
                {
                    // This is always a single layer, never a list.
                    var layer = node.outbound_layer;
                    var reference_input_tensors = node.input_tensors;
                    var reference_output_tensors = node.output_tensors;
                    // If all previous input tensors are available in tensor_map,
                    // then call node.inbound_layer on them.
                    var computed_data = new List<(KerasSymbol, KerasSymbol)>();
                    foreach (var x in reference_input_tensors)
                    {
                        if (tensor_map.ContainsKey(x.GetMemPtr().ToString()))
                        {
                            computed_data.Add(tensor_map[x.GetMemPtr().ToString()]);
                        }
                    }

                    var kwargs = new FuncArgs();
                    var computed_tensors = new List<KerasSymbol>();
                    var computed_masks = new List<KerasSymbol>();
                    if (computed_data.Count == reference_input_tensors.Count())
                    {
                        // call layer
                        using (var ns = new NameScope(layer.name)) {
                            if (node.arguments != null)
                            {
                                kwargs = node.arguments;
                            }
                         
                            if (computed_data.Count == 1)
                            {
                                var (computed_tensor, computed_mask) = computed_data[0];
                                if (!kwargs.Contains("mask"))
                                {
                                    kwargs["mask"] = computed_mask;
                                }

                                output_tensors = layer.Call(new KerasSymbol[] { computed_tensor }, kwargs).ToList();
                                output_masks = layer.ComputeMask(new KerasSymbol[] { computed_tensor }, new KerasSymbol[] { computed_mask }).ToList();
                                if (output_masks == null)
                                {
                                    output_masks = new List<KerasSymbol>();
                                    foreach (var _ in output_tensors)
                                    {
                                        output_masks.Add(null);
                                    }
                                }

                                computed_tensors = new List<KerasSymbol> {
                                        computed_tensor
                                    };
                                // computed_masks might be used in the future.
                                computed_masks = new List<KerasSymbol> {
                                        computed_mask
                                    };
                            }
                            else
                            {
                                computed_tensors = (from x in computed_data
                                                    select x.Item1).ToList();
                                computed_masks = (from x in computed_data
                                                  select x.Item2).ToList();

                                if (!kwargs.Contains("mask"))
                                {
                                    kwargs["mask"] = computed_masks;
                                }

                                output_tensors = layer.Call(computed_tensors.ToArray(), kwargs).ToList();
                                output_masks = layer.ComputeMask(computed_tensors.ToArray(), computed_masks.ToArray()).ToList();
                                if (output_masks == null)
                                {
                                    output_masks = new List<KerasSymbol>();
                                    foreach (var _ in output_tensors)
                                    {
                                        output_masks.Add(null);
                                    }
                                }
                            }

                            // Apply activity regularizer if any:
                            if (layer.activity_regularizer != null)
                            {
                                using (var ns1 = new NameScope("activity_regularizer")) 
                                {
                                    var regularization_losses = (from x in output_tensors
                                                             select layer.activity_regularizer.Call(x)).ToArray();

                                    layer.AddLoss(regularization_losses, computed_tensors.ToArray());
                                }
                            }
                            if (output_masks.Count != output_tensors.Count)
                            {
                                throw new Exception("Layers should have equal number of output tensors and output masks. Layer " + layer.name.ToString() + " has " + output_tensors.Count.ToString() + " output tensors and " + output_masks.Count.ToString() + " output masks.");
                            }
                        }

                        // Update model updates and losses:
                        // Keep track of updates that depend on the inputs
                        // (e.g. BN updates).
                        this.AddUpdate(layer.GetUpdatesFor(computed_tensors.ToArray()), inputs);
                        // Keep track of unconditional updates (e.g. a counter).
                        this.AddUpdate(layer.GetUpdatesFor(null), null);
                        // Keep track of losses that depend on the inputs
                        // (e.g. activity regularizers).
                        this.AddLoss(layer.GetLossesFor(computed_tensors.ToArray()), inputs);
                        // Keep track of unconditional losses
                        // (e.g. weight regularizers).
                        this.AddLoss(layer.GetLossesFor(null), null);
                        // Update _keras_shape.
                        if (computed_tensors.Select(x => x._keras_shape).All(x => x != null))
                        {
                            input_shapes = (from x in computed_tensors
                                            select x._keras_shape).ToArray();
                            var shapes = layer.ComputeOutputShape(input_shapes);
                            var uses_learning_phase = computed_tensors.Select(x => x._uses_learning_phase).Any();
                            for(int i = 0; i < output_tensors.Count; i++)
                            {
                                var x = output_tensors[i];
                                var s = shapes[i];
                                x._keras_shape = s;
                                x._uses_learning_phase = uses_learning_phase;
                            }
                        }

                        // Update tensor_map.
                        for (int i = 0; i < output_tensors.Count; i++)
                        {
                            var x = reference_output_tensors[i];
                            var y = output_tensors[i];
                            var mask = output_masks[i];
                            tensor_map[x.GetMemPtr().ToString()] = (y, mask);
                        }
                    }
                }
            }

            foreach (var x in this.outputs)
            {
                Debug.Assert(tensor_map.ContainsKey(x.GetMemPtr().ToString()), "Could not compute output " + x.ToString());
                var _tup_5 = tensor_map[x.GetMemPtr().ToString()];
                var tensor = _tup_5.Item1;
                var mask = _tup_5.Item2;
                if (x._keras_shape != null && output_shapes != null)
                {
                    var shape = tensor._keras_shape;
                    output_shapes.Add(shape);
                }
                else
                {
                    output_shapes = null;
                }

                output_tensors.Add(tensor);
                output_masks.Add(mask);
            }

            // Update cache;
            // keys are based on ids on input tensors and inputs masks.
            var cache_key = GenericUtils.ObjectListUid(inputs);
            cache_key += "_" + GenericUtils.ObjectListUid(masks);

            this._output_tensor_cache[cache_key] = output_tensors.ToArray();
            this._output_mask_cache[cache_key] = output_masks.ToArray();
            if (output_shapes != null)
            {
                input_shapes = (from x in inputs
                                select x._keras_shape).ToArray();
                cache_key = string.Join(", ", (from x in input_shapes
                                       select x.ToString()).ToList());
                
                this._output_shape_cache[cache_key] = output_shapes.ToArray();
            }

            return (output_tensors.ToArray(), output_masks.ToArray(), output_shapes.ToArray());
        }

        public override ConfigDict GetConfig()
        {
            int new_node_index = -1;
            int tensor_index = -1;
            int node_index = -1;
            FuncArgs kwargs = null;
            string node_key = "";
            Node node = null;
            int original_node_index = -1;
            int kept_nodes = -1;

            if (!this._is_graph_network)
            {
                // Subclassed networks are not serializable
                // (unless serialization is implemented by
                // the author of the subclassed network).
                throw new NotImplementedException();
            }

            var config = new ConfigDict();
            // Build a map from a layer unique name (self._node_key)
            // to the index of the nodes that are saved in the config.
            // Only nodes in network_nodes are saved.
            var node_conversion_map = new Dictionary<string, int>();
            foreach (var layer in this.Layers)
            {
                if (layer.GetType().IsSubclassOf(typeof(Network)))
                {
                    // Networks start with a pre-existing node
                    // linking their input to output.
                    kept_nodes = 1;
                }
                else
                {
                    kept_nodes = 0;
                }

                foreach (var _tup_1 in layer._inbound_nodes.Select((_p_1, _p_2) => Tuple.Create(_p_2, _p_1)))
                {
                    original_node_index = _tup_1.Item1;
                    node = _tup_1.Item2;
                    node_key = Layer.NodeKey(layer, original_node_index);
                    if (this._network_nodes.Contains(node_key))
                    {
                        // i.e. we mark it to be saved
                        node_conversion_map[node_key] = kept_nodes;
                        kept_nodes += 1;
                    }
                }
            }

            // serialize and save the layers in layer_configs
            var layer_configs = new List<ConfigDict>();
            foreach (var layer in this.Layers)
            {
                // From the earliest layers on.
                var layer_class_name = layer.GetType().Name;
                var layer_config = layer.GetConfig();
                var filtered_inbound_nodes = new List<NodeData>();
                foreach (var _tup_2 in layer._inbound_nodes.Select((_p_3, _p_4) => Tuple.Create(_p_4, _p_3)))
                {
                    original_node_index = _tup_2.Item1;
                    node = _tup_2.Item2;
                    node_key = Layer.NodeKey(layer, original_node_index);
                    if (this._network_nodes.Contains(node_key))
                    {
                        // The node is relevant to the model:
                        // add to filtered_inbound_nodes.
                        if (node.arguments != null)
                        {
                            try
                            {
                                kwargs = node.arguments;
                            }
                            catch (Exception ex)
                            {
                                Logger.Warning("Layer " + layer.name + " was passed non-serializable keyword arguments: " + node.arguments.ToString() + ". They will not be included in the serialized model (and thus will be missing at deserialization time).");
                                kwargs = new FuncArgs();
                            }
                        }

                        if (node.inbound_layers != null)
                        {
                            var node_data = new List<NodeData>();
                            foreach (var i in Enumerable.Range(0, node.inbound_layers.Length))
                            {
                                var inbound_layer = node.inbound_layers[i];
                                node_index = node.node_indices[i];
                                tensor_index = node.tensor_indices[i];
                                new_node_index = node_conversion_map.ContainsKey(Layer.NodeKey(inbound_layer, node_index)) ? node_conversion_map[Layer.NodeKey(inbound_layer, node_index)] : 0;
                                node_data.Add(new NodeData(
                                        inbound_layer.name,
                                        new_node_index,
                                        tensor_index,
                                        kwargs
                                    ));
                            }

                            filtered_inbound_nodes.AddRange(node_data);
                        }
                    }
                }

                layer_configs.Add(new ConfigDict {
                        {
                            "name",
                            layer.name},
                        {
                            "class_name",
                            layer_class_name},
                        {
                            "config",
                            layer_config},
                        {
                            "inbound_nodes",
                            filtered_inbound_nodes}}
                );
            }

            config["layers"] = layer_configs;
            // Gather info about inputs and outputs.
            var model_inputs = new List<object>();
            foreach (var i in Enumerable.Range(0, this._input_layers.Count))
            {
                var layer = this._input_layers[i];
                node_index = this._input_coordinates[i].Item2;
                node_key = Layer.NodeKey(layer, node_index);
                if (!this._network_nodes.Contains(node_key))
                {
                    continue;
                }

                new_node_index = node_conversion_map[node_key];
                tensor_index = this._input_coordinates[i].Item3;
                model_inputs.Add(new NodeData(
                        layer.name,
                        new_node_index,
                        tensor_index,
                        null
                    ));
            }

            config["input_layers"] = model_inputs;
            var model_outputs = new List<object>();
            foreach (var i in Enumerable.Range(0, this._output_layers.Count))
            {
                var layer = this._output_layers[i];
                node_index = this._output_coordinates[i].Item2;
                node_key = Layer.NodeKey(layer, node_index);
                if (!this._network_nodes.Contains(node_key))
                {
                    continue;
                }
                new_node_index = node_conversion_map[node_key];
                tensor_index = this._output_coordinates[i].Item3;
                model_outputs.Add(new NodeData(
                        layer.name,
                        new_node_index,
                        tensor_index,
                        null
                    ));
            }

            config["output_layers"] = model_outputs;
            return config;
        }

        public static Network FromConfig(ConfigDict config, CustomObjects custom_objects = null)
        {
            throw new NotImplementedException();
        }

        public void Save(string filepath, bool overwrite= true, bool include_optimizer= true)
        {
            if (!this._is_graph_network)
            {
                throw new NotSupportedException();
            }

            Saving.SaveModel(this, filepath, overwrite, include_optimizer);
        }

        public void SaveWeights(string filepath, bool overwrite = true)
        {
            // If file exists and should not be overwritten:
            if (!overwrite && File.Exists(filepath))
            {
                return;
            }

            var f = new H5Dict(filepath, "w");
            Saving.SaveWeightsToHdf5Group(f, this.Layers);
        }

        public void LoadWeights(string filepath, bool by_name = false,  bool skip_mismatch = false, bool reshape = false)
        {
            var f = new H5Dict(filepath, "r");
            if (!f.Contains("layer_names") && f.Contains("model_weights"))
            {
                f = (H5Dict)f["model_weights"];
            }
            if (by_name)
            {
                Saving.LoadWeightsFromHdf5GroupByName(f, this.Layers, skip_mismatch: skip_mismatch, reshape: reshape);
            }
            else
            {
                Saving.LoadWeightsFromHdf5Group(f, this.Layers, reshape: reshape);
            }
        }

        private ConfigDict UpdatedConfig()
        {
            var config = this.GetConfig();
            var model_config = new ConfigDict {
                    {
                        "class_name",
                        this.GetType().Name
                    },
                    {
                        "config",
                        config},
                    {
                        "keras_version",
                        "2.2.4"
                    },
                    {
                        "backend",
                        "mxnet"
                }
            };

            return model_config;
        }

        public string ToJson()
        {
            throw new NotImplementedException();
        }

        public string ToYaml()
        {
            throw new NotImplementedException();
        }

        public void PrintSummary(int? line_length = null, float[] positions = null, Action<string> print_fn=null)
        {
            throw new NotImplementedException();
        }

        public byte[] GetState()
        {
            throw new NotImplementedException();
        }

        public void SetState(byte[] state)
        {
            throw new NotImplementedException();
        }

        private static void BuildMap(KerasSymbol tensor, List<Node> finished_nodes, List<Node>  nodes_in_progress, Layer layer, int node_index, int tensor_index, ref HashSet<string> network_nodes, ref Dictionary<Layer, int>  layer_indices, ref List<Node> nodes_in_decreasing_depth)
        {
            var node = layer._inbound_nodes[node_index];
            // Prevent cycles.
            if (nodes_in_progress.Contains(node))
            {
                throw new Exception("The tensor " + tensor.ToString() + " at layer \"" + layer.name + "\" is part of a cycle.");
            }
            // Don't repeat work for shared subgraphs
            if (finished_nodes.Contains(node))
            {
                return;
            }
            var node_key = Layer.NodeKey(layer, node_index);
            // Update network_nodes.
            network_nodes.Add(node_key);
            // Store the traversal order for layer sorting.
            if (!layer_indices.ContainsKey(layer))
            {
                layer_indices[layer] = layer_indices.Count;
            }

            nodes_in_progress.Add(node);
            // Propagate to all previous tensors connected to this node.
            foreach (var i in Enumerable.Range(0, node.inbound_layers.Length))
            {
                var x = node.input_tensors[i];
                layer = node.inbound_layers[i];
                node_index = node.node_indices[i];
                tensor_index = node.tensor_indices[i];
                BuildMap(x, finished_nodes, nodes_in_progress, layer, node_index, tensor_index, ref network_nodes, ref layer_indices, ref nodes_in_decreasing_depth);
            }

            finished_nodes.Add(node);
            nodes_in_progress.Remove(node);
            nodes_in_decreasing_depth.Add(node);
        }

        internal static (string[], Dictionary<int, List<Node>>, Layer[], Dictionary<int, List<Layer>>) MapGraphNetwork(KerasSymbol[] inputs, KerasSymbol[] outputs)
        {
            int depth = -1;
            int node_index = -1;
            Layer layer = null;

            // Network_nodes: set of nodes included in the graph of layers
            // (not all nodes included in the layers are relevant to the current graph).
            var network_nodes = new HashSet<string>();
            var nodes_depths = new Dictionary<Node, int>();
            var layers_depths = new Dictionary<Layer, int>();
            var layer_indices = new Dictionary<Layer, int>();

            var finished_nodes = new List<Node>();
            var nodes_in_progress = new List<Node>();

            var nodes_in_decreasing_depth = new List<Node>();
           
            foreach (var x in outputs)
            {
                var _tup_1 = x._keras_history.Value;
                layer = _tup_1.Item1;
                node_index = _tup_1.Item2;
                var tensor_index = _tup_1.Item3;
                BuildMap(x, finished_nodes, nodes_in_progress, layer, node_index, tensor_index, ref network_nodes, ref layer_indices, ref nodes_in_decreasing_depth);
            }

            nodes_in_decreasing_depth.Reverse();
            foreach (var node in nodes_in_decreasing_depth)
            {
                // If the depth is not set, the node has no outbound nodes (depth 0).
                depth = 0;
                nodes_depths.Add(node, depth);
                // Update the depth of the corresponding layer
                var previous_depth = layers_depths.ContainsKey(node.outbound_layer) ? layers_depths[node.outbound_layer] : 0;
                // If we've seen this layer before at a higher depth,
                // we should use that depth instead of the node depth.
                // This is necessary for shared layers that have inputs at different
                // depth levels in the graph.
                depth = Math.Max(depth, previous_depth);
                layers_depths[node.outbound_layer] = depth;
                nodes_depths[node] = depth;
                // Update the depth of inbound nodes.
                // The "depth" of a node is the max of the depths
                // of all layers it is connected to.
                foreach (var i in Enumerable.Range(0, node.inbound_layers.Length))
                {
                    var inbound_layer = node.inbound_layers[i];
                    node_index = node.node_indices[i];
                    var inbound_node = inbound_layer._inbound_nodes[node_index];
                    previous_depth = nodes_depths.ContainsKey(inbound_node) ? nodes_depths[inbound_node] : 0;
                    nodes_depths[inbound_node] = Math.Max(depth + 1, previous_depth);
                }
            }
            // Build a dict {depth: list of nodes with this depth}
            var nodes_by_depth = new Dictionary<int, List<Node>>();
            foreach (var _tup_2 in nodes_depths)
            {
                var node = _tup_2.Key;
                depth = _tup_2.Value;
                if (!nodes_by_depth.ContainsKey(depth))
                {
                    nodes_by_depth[depth] = new List<Node>();
                }
                nodes_by_depth[depth].Add(node);
            }

            // Build a dict {depth: list of layers with this depth}
            var layers_by_depth = new Dictionary<int, List<Layer>>();
            foreach (var _tup_3 in layers_depths)
            {
                layer = _tup_3.Key;
                depth = _tup_3.Value;
                if (!layers_by_depth.ContainsKey(depth))
                {
                    layers_by_depth[depth] = new List<Layer>();
                }

                layers_by_depth[depth].Add(layer);
            }
            // Get sorted list of layer depths.
            var depth_keys = layers_by_depth.Keys.ToList();
            depth_keys.Reverse();
            // Set self.layers and self._layers_by_depth.
            var layers = new List<Layer>();
            foreach (var d in depth_keys)
            {
                var layers_for_depth = layers_by_depth[d];
                // Network.layers needs to have a deterministic order:
                // here we order them by traversal order.
                layers.AddRange(layers_for_depth);
            }

            // Get sorted list of node depths.
            depth_keys = nodes_by_depth.Keys.ToList();
            depth_keys.Reverse();
            // Check that all tensors required are computable.
            // computable_tensors: all tensors in the graph
            // that can be computed from the inputs provided.
            var computable_tensors = new List<KerasSymbol>();
            foreach (var x in inputs)
            {
                computable_tensors.Add(x);
            }
            var layers_with_complete_input = new List<string>();
            foreach (var d in depth_keys)
            {
                foreach (var node in nodes_by_depth[d])
                {
                    layer = node.outbound_layer;
                    if (layer != null)
                    {
                        foreach (var x in node.input_tensors)
                        {
                            if (!computable_tensors.Contains(x))
                            {
                                throw new Exception("Graph disconnected: cannot obtain value for tensor " + x.ToString() + " at layer \"" + layer.name + "\". The following previous layers were accessed without issue: " + layers_with_complete_input.ToString());
                            }
                        }
                        foreach (var x in node.output_tensors)
                        {
                            computable_tensors.Add(x);
                        }

                        layers_with_complete_input.Add(layer.name);
                    }
                }
            }
            // Ensure name unicity, which will be crucial for serialization
            // (since serialized nodes refer to layers by their name).
            var all_names = (from l in layers
                             select l.name).ToList();
            foreach (var name in all_names)
            {
                if (all_names.Count(x => x == name) != 1)
                {
                    throw new Exception("The name \"" + name + "\" is used " + all_names.Count(x => x == name).ToString() + " times in the model. All layer names should be unique.");
                }
            }

            return (network_nodes.ToArray(), nodes_by_depth, layers.ToArray(), layers_by_depth);
        }

        public override KerasSymbol[] Call(KerasSymbol[] inputs, FuncArgs kwargs = null)
        {
            var mask = kwargs.Contains("mask") ? (KerasSymbol)kwargs["mask"] : null;
            List<KerasSymbol> masks = new List<KerasSymbol>();
            if (mask == null)
            {
                foreach (var item in inputs)
                {
                    masks.Add(null);
                }
            }
            else
            {
                masks.Add(mask);
            }

            var cache_key = GenericUtils.ObjectListUid(inputs);
            cache_key += "_" + GenericUtils.ObjectListUid(masks.ToArray());
            if (this._output_tensor_cache.ContainsKey(cache_key))
            {
                return this._output_tensor_cache[cache_key];
            }
            else
            {
                var _tup_1 = this.RunInternalGraph(inputs, masks.ToArray());
                var output_tensors = _tup_1.Item1;
                return output_tensors;
            }
        }
    }
}
