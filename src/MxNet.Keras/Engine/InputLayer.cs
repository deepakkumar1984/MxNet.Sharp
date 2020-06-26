using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Engine
{
    public class InputLayer : Layer
    {
        internal Shape batch_input_shape;

        internal bool built;

        internal DType dtype;

        internal bool sparse;

        internal bool supports_masking;

        internal bool trainable;

        public InputLayer(
                Shape input_shape = null,
                int? batch_size = null,
                Shape batch_input_shape = null,
                DType dtype = null,
                KerasSymbol input_tensor = null,
                bool sparse = false,
                string name = null)
        {
            if (name != null)
            {
                var prefix = "input";
                name = prefix + "_" + K.GetUid(prefix).ToString();
            }

            this.trainable = false;
            this.built = true;
            this.sparse = sparse;
            this.supports_masking = true;
            if (input_shape != null && batch_input_shape != null)
            {
                throw new Exception("Only provide the input_shape OR batch_input_shape argument to InputLayer, not both at the same time.");
            }

            if (input_tensor != null && batch_input_shape == null)
            {
                // If input_tensor is set, and batch_input_shape is not set:
                // Attempt automatic input shape inference.
                try
                {
                    batch_input_shape = input_tensor.Shape;
                }
                catch (Exception)
                {
                    if (input_shape == null && batch_input_shape == null)
                    {
                        throw new Exception("InputLayer was provided an input_tensor argument, but its input shape cannot be automatically inferred. You should pass an input_shape or batch_input_shape argument.");
                    }
                }
            }
            if (batch_input_shape == null)
            {
                if (input_shape == null)
                {
                    throw new Exception("An Input layer should be passed either a `batch_input_shape` or an `input_shape`.");
                }
                else
                {
                    var batchShapeData = input_shape.Data.ToList();
                    batchShapeData.Insert(0, batch_size.Value);
                    batch_input_shape = new Shape(batchShapeData);
                }
            }
            else
            {
                batch_input_shape = new Shape(batch_input_shape);
            }

            if (dtype == null)
            {
                if (input_tensor == null)
                {
                    dtype = K.FloatX();
                }
                else
                {
                    dtype = K.DataType(input_tensor);
                }
            }
            this.batch_input_shape = batch_input_shape;
            this.dtype = dtype;
            if (input_tensor == null)
            {
                this.is_placeholder = true;
                input_tensor = K.Placeholder(shape: batch_input_shape, dtype: dtype, sparse: this.sparse, name: this.name);
            }
            else
            {
                this.is_placeholder = false;
                input_tensor._keras_shape = batch_input_shape;
            }
            // Create an input node to add to self.outbound_node
            // and set output_tensors' _keras_history.
            input_tensor._uses_learning_phase = false;
            input_tensor._keras_history = (this, 0, 0);
            
            var node = new Node(this,
                inbound_layers: new Layer[0],
                node_indices: new int[0],
                tensor_indices: new int[0],
                input_tensors: new KerasSymbol[] {input_tensor },
                output_tensors: new KerasSymbol[] { input_tensor },
                input_masks: new KerasSymbol[] { null },
                output_masks: new KerasSymbol[] { null },
                input_shapes: new Shape[] { batch_input_shape },
                output_shapes: new Shape[] { batch_input_shape}
                );
        }

        public override KerasSymbol[] Call(KerasSymbol[] inputs, FuncArgs kwargs)
        {
            return inputs;
        }
    }
}
