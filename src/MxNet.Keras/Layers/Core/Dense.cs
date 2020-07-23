using MxNet.Keras.Constraints;
using MxNet.Keras.Engine;
using MxNet.Keras.Initializers;
using MxNet.Keras.Layers.Core;
using MxNet.Keras.Regularizers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Layers
{
    public class Dense : Layer
    {
        public Activation activation;

        public KerasSymbol bias;

        public Constraint bias_constraint;

        public Initializer bias_initializer;

        public Regularizer bias_regularizer;

        public bool built;

        public KerasSymbol kernel;

        public Constraint kernel_constraint;

        public Initializer kernel_initializer;

        public Regularizer kernel_regularizer;

        public bool sparse_weight;

        public int units;

        public bool use_bias;

        public Dense(int units,
                     string activation= "",
                     bool use_bias= true,
                     Initializer kernel_initializer = null,
                     Initializer bias_initializer = null,
                     Regularizer kernel_regularizer= null,
                     Regularizer bias_regularizer = null,
                     Regularizer activity_regularizer = null,
                     Constraint kernel_constraint= null,
                     Constraint bias_constraint= null,
                     bool sparse_weight= false,
                     Shape input_shape = null,
                     int? input_dim = null)
            : base(input_dim.HasValue ? new Shape(input_dim.Value) : input_shape)
        {
            this.units = units;
            this.activation = new Activation(activation, null);
            this.use_bias = use_bias;
            this.kernel_initializer = kernel_initializer ?? new GlorotUniform(null);
            this.bias_initializer = bias_initializer ?? new Zeros();
            this.kernel_regularizer = kernel_regularizer;
            this.bias_regularizer = bias_regularizer;
            this.activity_regularizer = activity_regularizer;
            this.kernel_constraint = kernel_constraint;
            this.bias_constraint = bias_constraint;
            this.input_spec = new InputSpec[] { new InputSpec(min_ndim: 2) };
            this.supports_masking = true;
            this.sparse_weight = sparse_weight;
        }

        public override KerasSymbol[] Invoke(KerasSymbol[] inputs, FuncArgs kwargs = null)
        {
            List<KerasSymbol> result = new List<KerasSymbol>();
            foreach (var input in inputs)
            {
                var output = K.Dot(input, this.kernel);
                if (this.use_bias)
                {
                    output = K.BiasAdd(output, this.bias, data_format: "channels_last");
                }

                result.Add(output);
            }

            if (this.activation != null)
            {
                return this.activation.Invoke(result.ToArray());
            }

            return result.ToArray();
        }

        public override void Build(Shape input_shape)
        {
            Debug.Assert(input_shape.Dimension >= 2);
            var input_dim = input_shape[-1];
            this.kernel = this.AddWeight(shape: (input_dim, this.units), initializer: this.kernel_initializer, name: "kernel", regularizer: this.kernel_regularizer, constraint: this.kernel_constraint, sparse_weight: this.sparse_weight);
            if (this.use_bias)
            {
                this.bias = this.AddWeight(shape: new Shape(this.units), initializer: this.bias_initializer, name: "bias", regularizer: this.bias_regularizer, constraint: this.bias_constraint);
            }
            else
            {
                this.bias = null;
            }
            this.input_spec = new InputSpec[] {new InputSpec(min_ndim: 2, axes: new Dictionary<int, int> {
                    {
                        -1,
                        input_dim}})
            };
            this.built = true;
        }

        public override Shape[] ComputeOutputShape(Shape[] input_shapes)
        {
            List<Shape> result = new List<Shape>();
            foreach (var input_shape in input_shapes)
            {
                Debug.Assert(input_shape != null && input_shape.Dimension >= 2);
                Debug.Assert(input_shape.Data.Last() > 0);
                var output_shape = input_shape;
                output_shape[-1] = this.units;
                result.Add(output_shape);
            }

            return result.ToArray();
        }

        public override ConfigDict GetConfig()
        {
            var config = new ConfigDict {
                    {
                        "units",
                        this.units},
                    {
                        "activation",
                        Activations.Serialize(this.activation)},
                    {
                        "use_bias",
                        this.use_bias},
                    {
                        "kernel_initializer",
                        Initializer.Serialize(this.kernel_initializer)},
                    {
                        "bias_initializer",
                        Initializer.Serialize(this.bias_initializer)},
                    {
                        "kernel_regularizer",
                        Regularizer.Serialize(this.kernel_regularizer)},
                    {
                        "bias_regularizer",
                        Regularizer.Serialize(this.bias_regularizer)},
                    {
                        "activity_regularizer",
                        Regularizer.Serialize(this.activity_regularizer)},
                    {
                        "kernel_constraint",
                        Constraint.Serialize(this.kernel_constraint)},
                    {
                        "bias_constraint",
                        Constraint.Serialize(this.bias_constraint)}};
            var base_config = base.GetConfig();
            base_config.Update(config);
            return base_config;
        }
    }
}
