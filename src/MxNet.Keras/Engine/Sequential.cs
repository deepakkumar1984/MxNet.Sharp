using MxNet.Gluon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Engine
{
    public class Sequential : Model
    {
        private Shape _build_input_shape = null;
        public Model Model
        {
            get
            {
                return this;
            }
        }

        public new Layer[] Layers
        {
            get
            {
                // Historically, `sequential.layers` only returns layers that were added
                // via `add`, and omits the auto-generated `InputLayer`
                // that comes at the bottom of the stack.
                if (this._layers != null && this._layers[0] is InputLayer)
                {
                    return this._layers.Skip(1).ToArray();
                }

                if(this._layers != null)
                    return this._layers.ToArray();

                return new Layer[0];
            }
        }

        public Sequential(Layer[] layers = null, string name = "", Context context = null, string kvstore = "device")
            : base(name, context, kvstore)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                var prefix = this.GetType().Name.ToLower();
                this.name = prefix + "_" + K.GetUid(prefix).ToString();
            }
            
            this.batch_input_shape = null;
            // Add to the model any layers passed to the constructor.
            
            if (layers != null)
            {
                foreach (var layer in layers)
                {
                    this.Add(layer);
                }
            }
        }

        public void Add(Layer layer)
        {
            this.built = false;
            if (this._layers.Count == 0)
            {
                var set_inputs = false;
                // First layer in model: check that it is an input layer.
                if (!(layer is InputLayer))
                {
                    // Create an input tensor and call `layer` on the input tensor.
                    // First, we need to infer the expected input shape and dtype.
                    var first_layer = layer;
                    if (first_layer.batch_input_shape != null)
                    {
                        var batch_shape = first_layer.batch_input_shape;
                        var dtype = first_layer.dtype;
                        // Instantiate the input layer.
                        var x = InputLayer.CreateInput(batch_shape: batch_shape, dtype: dtype, name: layer.name + "_input");
                        // This will build the current layer
                        // and create the node connecting the current layer
                        // to the input layer we just created.
                        layer.Build(batch_shape);
                        layer.Call(x, null);
                        set_inputs = true;
                    }
                }
                else
                {
                    // Corner case where the user passes an InputLayer via `add`.
                    Debug.Assert(layer._inbound_nodes.Last().output_tensors.Length == 1);
                    set_inputs = true;
                }

                if (set_inputs)
                {
                    if (layer._inbound_nodes.Last().output_tensors.Length != 1)
                    {
                        throw new Exception("All layers in a Sequential model should have a single output tensor. For multi-output layers, use the functional API.");
                    }

                    this.outputs = new List<KerasSymbol> {
                            layer._inbound_nodes[-1].output_tensors[0]
                        };
                    
                    this.inputs = MxNet.Keras.Utils.LayerUtils.GetSourceInputs(this.outputs[0]).ToList();
                }
            }
            else if (this.outputs != null)
            {
                var output_tensor = layer.Call(new KerasSymbol[] { this.outputs[0] }, null);
                if (output_tensor.Length > 1)
                {
                    throw new Exception("All layers in a Sequential model should have a single output tensor. For multi-output layers, use the functional API.");
                }

                this.outputs = output_tensor.ToList();
            }

            if (this.inputs != null)
            {
                this.Build();
            }
            else
            {
                this._layers.Add(layer);
            }
        }

        public void Add(Model layer)
        {
            this.built = false;
            if (this._layers.Count == 0)
            {
                var set_inputs = false;
                // First layer in model: check that it is an input layer.
                if (layer is Model || layer is Sequential)
                {
                    // Create an input tensor and call `layer` on the input tensor.
                    // First, we need to infer the expected input shape and dtype.
                    if (layer.Layers == null)
                    {
                        throw new Exception("Cannot add an empty model to a `Sequential` model.");
                    }
                    // In case of nested models: recover the first layer
                    // of the deepest model to infer input shape and dtype.
                    object first_layer = layer.Layers[0];
                    while (first_layer is Model || first_layer is Sequential)
                    {
                        first_layer = ((Model)first_layer).Layers[0];
                    }

                    if (((Layer)first_layer).batch_input_shape != null)
                    {
                        var batch_shape = ((Layer)first_layer).batch_input_shape;
                        var dtype = ((Layer)first_layer).dtype;
                        // Instantiate the input layer.
                        var x = InputLayer.CreateInput(batch_shape: batch_shape, dtype: dtype, name: layer.name + "_input");
                        // This will build the current layer
                        // and create the node connecting the current layer
                        // to the input layer we just created.
                        layer.Build(batch_shape);
                        layer.Call(x, null);
                        set_inputs = true;
                    }
                }
                else
                {
                    // Corner case where the user passes an InputLayer via `add`.
                    Debug.Assert(layer._inbound_nodes.Last().output_tensors.Length == 1);
                    set_inputs = true;
                }

                if (set_inputs)
                {
                    if (layer._inbound_nodes.Last().output_tensors.Length != 1)
                    {
                        throw new Exception("All layers in a Sequential model should have a single output tensor. For multi-output layers, use the functional API.");
                    }

                    this.outputs = new List<KerasSymbol> {
                            layer._inbound_nodes[-1].output_tensors[0]
                        };

                    this.inputs = MxNet.Keras.Utils.LayerUtils.GetSourceInputs(this.outputs[0]).ToList();
                }
            }
            else if (this.outputs != null)
            {
                var output_tensor = layer.Call(new KerasSymbol[] { this.outputs[0] }, null);
                if (output_tensor.Length > 1)
                {
                    throw new Exception("All layers in a Sequential model should have a single output tensor. For multi-output layers, use the functional API.");
                }

                this.outputs = output_tensor.ToList();
            }

            if (this.inputs != null)
            {
                this.Build();
            }
            else
            {
                this._layers.Add(layer);
            }
        }

        public void Pop()
        {
            if (this.Layers.Length == 0)
            {
                throw new Exception("There are no layers in the model.");
            }

            this._layers.RemoveAt(this._layers.Count);
            this.built = false;
            if (this.Layers.Length == 0)
            {
                this.outputs = null;
                this.inputs = null;
            }
            else if (this.outputs != null)
            {
                this.Layers.Last()._outbound_nodes = new List<Node>();
                this.outputs = new List<KerasSymbol> {
                        this.Layers.Last().Output
                    };

                this.Build();
            }
        }

        public override void Build(Shape input_shape = null)
        {
            if (input_shape != null && this.inputs == null)
            {
                var batch_shape = input_shape;
                var dtype = K.FloatX();
                var x = InputLayer.CreateInput(batch_shape: batch_shape, dtype: dtype, name: this.name + "_input");
                this.inputs = x.ToList();
                foreach (var layer in this._layers)
                {
                    x = layer.Call(x, null);
                }

                this.outputs = x.ToList();
                this._build_input_shape = input_shape;
            }
            if (this.inputs != null)
            {
                this.InitGraphNetwork(this.inputs.ToArray(), this.outputs.ToArray(), name: this.name);
                this.built = true;
            }
        }

        public NDArray PredictProba(NDArray x, int batch_size= 32, int verbose= 0)
        {
            var preds = this.Predict(x, batch_size, verbose);
            if (preds.Min().AsScalar<float>() < 0 || preds.Max().AsScalar<float>() > 1)
            {
                Logger.Warning("Network returning invalid probability values. The last layer might not normalize predictions into probabilities (like softmax or sigmoid would).");
            }

            return preds;
        }

        public NDArray PredictClasses(NDArray x, int batch_size = 32, int verbose = 0)
        {
            var proba = this.Predict(x, batch_size: batch_size, verbose: verbose);
            if (proba.Shape.Data.Last() > 1)
            {
                return proba.Argmax(axis: -1);
            }
            else
            {
                return (proba > 0.5).AsType(DType.Int32);
            }
        }

        public override ConfigDict GetConfig()
        {
            var layer_configs = new List<ConfigDict>();
            foreach (var layer in this.Layers)
            {
                layer_configs.Add(new ConfigDict{
                        {
                            "class_name",
                            layer.GetType().Name.ToLower() },
                        {
                            "config",
                            layer.GetConfig()}});
            }
            var config = new ConfigDict {
                    {
                        "name",
                        this.name},
                    {
                        "layers",
                        layer_configs
                }
            };

            if (this._build_input_shape != null)
            {
                config["build_input_shape"] = this._build_input_shape;
            }

            return config;
        }

        public static new Sequential FromConfig(ConfigDict config, CustomObjects custom_objects = null)
        {
            List<ConfigDict> layer_configs = null;
            string name = "";
            Shape build_input_shape  = null;
            if (config.ContainsKey("name"))
            {
                name = config["name"].ToString();
                build_input_shape = config.ContainsKey("build_input_shape") ? (Shape)config["build_input_shape"] : null;
                layer_configs = (List<ConfigDict>)config["layers"];
            }
            else
            {
                // legacy config file
                name = null;
                layer_configs = new List<ConfigDict>() { config };
            }

            var t = Type.GetType(name, true, true);
            Sequential model = (Sequential)Activator.CreateInstance(t);
            foreach (var conf in layer_configs)
            {
                var layer = Layer.FromConfig(conf.First().Key, (ConfigDict)conf.First().Value, custom_objects);
                model.Add(layer);
            }
            if (model.inputs == null && build_input_shape != null)
            {
                model.Build(build_input_shape);
            }

            return model;
        }
    }
}
