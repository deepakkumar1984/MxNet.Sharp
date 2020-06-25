using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Engine
{
    public class Node
    {
        public object arguments;

        public Layer[] inbound_layers;

        public KerasSymbol[] input_masks;

        public Shape[] input_shapes;

        public KerasSymbol[] input_tensors;

        public int[] node_indices;

        public Layer outbound_layer;

        public KerasSymbol[] output_masks;

        public Shape[] output_shapes;

        public KerasSymbol[] output_tensors;

        public int[] tensor_indices;

        public Node(Layer outbound_layer, Layer[] inbound_layers, int[] node_indices, int[] tensor_indices, KerasSymbol[] input_tensors, KerasSymbol[] output_tensors, KerasSymbol[] input_masks, KerasSymbol[] output_masks, Shape[] input_shapes, Shape[] output_shapes,
          FuncArgs arguments = null)
        {
            // Layer instance (NOT a list).
            // this is the layer that takes a list of input tensors
            // and turns them into a list of output tensors.
            // the current node will be added to
            // the inbound_nodes of outbound_layer.
            this.outbound_layer = outbound_layer;
            // The following 3 properties describe where
            // the input tensors come from: which layers,
            // and for each layer, which node and which
            // tensor output of each node.
            // List of layer instances.
            this.inbound_layers = inbound_layers;
            // List of integers, 1:1 mapping with inbound_layers.
            this.node_indices = node_indices;
            // List of integers, 1:1 mapping with inbound_layers.
            this.tensor_indices = tensor_indices;
            // Following 2 properties:
            // tensor inputs and outputs of outbound_layer.
            // List of tensors. 1:1 mapping with inbound_layers.
            this.input_tensors = input_tensors;
            // List of tensors, created by outbound_layer.call().
            this.output_tensors = output_tensors;
            // Following 2 properties: input and output masks.
            // List of tensors, 1:1 mapping with input_tensor.
            this.input_masks = input_masks;
            // List of tensors, created by outbound_layer.compute_mask().
            this.output_masks = output_masks;
            // Following 2 properties: input and output shapes.
            // List of shape tuples, shapes of input_tensors.
            this.input_shapes = input_shapes;
            // List of shape tuples, shapes of output_tensors.
            this.output_shapes = output_shapes;
            // Optional keyword arguments to layer's `call`.
            this.arguments = arguments;
            // Add nodes to all layers involved.
            foreach (var layer in inbound_layers)
            {
                if (layer != null)
                {
                    layer._outbound_nodes.Add(this);
                }
            }

            outbound_layer._inbound_nodes.Add(this);
        }

        public ConfigDict GetConfig()
        {
            string outbound_layer_name;
            var inbound_names = new List<string>();
            foreach (var layer in this.inbound_layers)
            {
                if (layer != null)
                {
                    inbound_names.Add(layer.name);
                }
                else
                {
                    inbound_names.Add(null);
                }
            }

            if (this.outbound_layer != null)
            {
                outbound_layer_name = this.outbound_layer.name;
            }
            else
            {
                outbound_layer_name = null;
            }

            return new ConfigDict 
            {
                {
                    "outbound_layer",
                    outbound_layer},
                {
                    "inbound_layers",
                    inbound_names},
                {
                    "node_indices",
                    this.node_indices},
                {
                    "tensor_indices",
                    this.tensor_indices
                }
            };
        }
    }
}
