using MxNet.Keras.Constraints;
using MxNet.Keras.Initializers;
using MxNet.Keras.Regularizers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Engine
{
    public abstract class Layer
    {
        public KerasSymbol Input
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public KerasSymbol Output
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public KerasSymbol InputMask
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public KerasSymbol OutputMask
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Shape InputShape
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Shape OutputShape
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        
        public NDArray[] Weights
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public Layer(Shape input_shape = null, Shape batch_input_shape = null, int? batch_size = null, DType dtype = null, string name = null, bool? trainable = null, KerasSymbol[] weights = null)
        {
            throw new NotImplementedException();
        }

        public static string NodeKey(Layer layer, int node_index)
        {
            throw new NotImplementedException();
        }

        public Func<KerasSymbol, KerasSymbol, KerasSymbol>[] Losses => throw new NotImplementedException();

        public KerasSymbol[] Updates => throw new NotImplementedException();

        public bool Built { get; set; }

        public KerasSymbol[] TrainableWeights => throw new NotImplementedException();

        public KerasSymbol[] NonTrainableWeights => throw new NotImplementedException();

        public virtual KerasSymbol AddWeight(string name, Shape shape, DType dtype= null, Initializer initializer= null, Regularizer regularizer = null, bool trainable= true, Constraint constraint= null, bool sparse_weight= false)
        {
            throw new NotImplementedException();
        }

        public void AssertInputCompatibility(KerasSymbol[] inputs)
        {
            throw new NotImplementedException();
        }

        public abstract void Call(KerasSymbol[] inputs, FuncArgs kwargs);

        internal void _Call(KerasSymbol[] inputs, FuncArgs kwargs)
        {
            throw new NotImplementedException();
        }

        internal void AddInboundNode(KerasSymbol[] input_tensors, KerasSymbol[] output_tensors,
                                        KerasSymbol[]  input_masks, KerasSymbol[]  output_masks,
                                        Shape[] input_shapes, Shape[] output_shapes, FuncArgs arguments= null)
        {
            throw new NotImplementedException();
        }

        public virtual Shape ComputeOutputShape(Shape input_shape)
        {
            return input_shape;
        }

        public virtual KerasSymbol[] ComputeMask(KerasSymbol[] inputs, KerasSymbol mask = null)
        {
            throw new NotImplementedException();
        }

        public virtual void Build()
        {
            Built = true;
        }

        public virtual Node GetNodeAttributeAtIndex(int node_index, string attr, string attr_name)
        {
            throw new NotImplementedException();
        }

        public virtual Shape GetInputShapeAt(int node_index)
        {
            throw new NotImplementedException();
        }

        public virtual Shape GetOutputShapeAt(int node_index)
        {
            throw new NotImplementedException();
        }

        public virtual KerasSymbol GetInputAt(int node_index)
        {
            throw new NotImplementedException();
        }

        public virtual KerasSymbol GetOutputAt(int node_index)
        {
            throw new NotImplementedException();
        }

        public virtual KerasSymbol GetInputMaskAt(int node_index)
        {
            throw new NotImplementedException();
        }

        public virtual KerasSymbol GetOutputMaskAt(int node_index)
        {
            throw new NotImplementedException();
        }

        public virtual void AddLoss(KerasSymbol[] losses, KerasSymbol[]  inputs = null)
        {
            throw new NotImplementedException();
        }

        public virtual void AddUpdate(KerasSymbol[] updates, KerasSymbol[] inputs = null)
        {
            throw new NotImplementedException();
        }

        public virtual KerasSymbol[] GetUpdatesFor(KerasSymbol[] inputs)
        {
            throw new NotImplementedException();
        }

        public virtual KerasSymbol[] GetLossesFor(KerasSymbol[] inputs)
        {
            throw new NotImplementedException();
        }

        public virtual void SetWeights(NDArray[] weights)
        {
            throw new NotImplementedException();
        }

        public virtual NDArray[] GetWeights()
        {
            throw new NotImplementedException();
        }

        public virtual ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }

        public static Layer FromConfig(string cls, ConfigDict config)
        {
            throw new NotImplementedException();
        }

        public virtual int CountParams()
        {
            throw new NotImplementedException();
        }
    }
}
