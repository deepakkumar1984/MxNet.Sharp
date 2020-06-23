using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Engine
{
    public class Node
    {
        public Shape[] InputShapes { get; set; }

        public Shape[] OutputShapes { get; set; }

        public Node(Layer outbound_layer, Layer[] inbound_layers, int[] node_indices, int[] tensor_indices, KerasSymbol[] input_tensors,        KerasSymbol[]  output_tensors, KerasSymbol[] input_masks, KerasSymbol[] output_masks, Shape[] input_shapes, Shape[] output_shapes,
          FuncArgs arguments= null)
        {
            throw new NotImplementedException();
        }

        public ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }
    }
}
