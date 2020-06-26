using MxNet.Keras.Constraints;
using MxNet.Keras.Engine;
using MxNet.Keras.Initializers;
using MxNet.Keras.Regularizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNet.Keras.Layers.AdvancedActivations
{
    public class PReLU : Layer
    {
        public KerasSymbol alpha;

        public Constraint alpha_constraint;

        public Initializer alpha_initializer;

        public Regularizer alpha_regularizer;

        public bool built;

        public InputSpec input_spec;

        public List<bool> param_broadcast;

        public Shape shared_axes;

        public PReLU(Initializer alpha_initializer = null, Regularizer alpha_regularizer= null, Constraint alpha_constraint= null, Shape shared_axes = null)
        {
            if (alpha_initializer == null)
                alpha_initializer = new Zeros();

            this.supports_masking = true;
            this.alpha_initializer = alpha_initializer;
            this.alpha_regularizer = alpha_regularizer;
            this.alpha_constraint = alpha_constraint;
            if (shared_axes == null)
            {
                this.shared_axes = null;
            }
            else
            {
                this.shared_axes = shared_axes;
            }
        }

        public override KerasSymbol[] Call(KerasSymbol[] inputs, FuncArgs kwargs)
        {
            throw new NotImplementedException();
        }

        public override void Build(Shape input_shape)
        {
            var param_shape = input_shape.Data.Skip(1).ToArray();
            this.param_broadcast = new List<bool>();
            for (int i = 0; i < param_shape.Length; i++)
                param_broadcast.Add(false);

            if (this.shared_axes != null)
            {
                foreach (var i in this.shared_axes.Data)
                {
                    param_shape[i - 1] = 1;
                    this.param_broadcast[i - 1] = true;
                }
            }

            this.alpha = this.AddWeight(shape: new Shape(param_shape), name: "alpha", initializer: this.alpha_initializer, regularizer: this.alpha_regularizer, constraint: this.alpha_constraint);
            // Set input spec
            var axes = new Dictionary<int, int>();

            if (this.shared_axes.Dimension > 0)
            {
                foreach (var i in Enumerable.Range(1, input_shape.Dimension - 1))
                {
                    if (!this.shared_axes.Data.Contains(i))
                    {
                        axes[i] = input_shape[i];
                    }
                }
            }

            this.input_spec = new InputSpec(ndim: input_shape.Dimension, axes: axes);
            this.built = true;
        }

        public override ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }

        public override Shape[] ComputeOutputShape(Shape[] input_shape)
        {
            throw new NotImplementedException();
        }
    }
}
