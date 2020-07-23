using MxNet.Keras.Constraints;
using MxNet.Keras.Initializers;
using MxNet.Keras.Regularizers;
using MxNet.Keras.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Engine
{
    public abstract class Layer
    {
        internal bool _built;
        internal List<Node> _inbound_nodes;
        internal List<KerasSymbol> _initial_weights;
        internal List<KerasSymbol> _losses;
        internal List<KerasSymbol> _non_trainable_weights;
        internal List<Node> _outbound_nodes;
        internal Dictionary<string, List<KerasSymbol>> _per_input_losses;
        internal Dictionary<string, List<(KerasSymbol, KerasSymbol)>> _per_input_updates;
        internal List<KerasSymbol> _trainable_weights;
        internal List<(KerasSymbol, KerasSymbol)> _updates;
        internal Shape batch_input_shape;
        internal DType dtype;
        internal InputSpec[] input_spec;
        internal string name;
        internal bool stateful;
        internal bool supports_masking;
        internal bool trainable;
        internal Regularizer activity_regularizer;
        internal bool is_placeholder;

        public KerasSymbol Input
        {
            get
            {
                if (this._inbound_nodes.Count > 1)
                {
                    throw new Exception("Layer " + this.name + " has multiple inbound nodes, hence the notion of \"layer input\" is ill-defined. Use `get_input_at(node_index)` instead.");
                }
                else if (this._inbound_nodes == null)
                {
                    throw new Exception("Layer " + this.name + " is not connected, no input to return.");
                }

                return GetInputAt(0);
            }
        }

        public KerasSymbol Output
        {
            get
            {
                if (this._inbound_nodes == null)
                {
                    throw new Exception("Layer " + this.name + " has no inbound nodes.");
                }

                if (this._inbound_nodes.Count > 1)
                {
                    throw new Exception("Layer " + this.name + " has multiple inbound nodes, hence the notion of \"layer output\" is ill-defined. Use `get_output_at(node_index)` instead.");
                }

                return GetOutputAt(0);
            }
        }

        public KerasSymbol InputMask
        {
            get
            {
                if (this._inbound_nodes.Count != 1)
                {
                    throw new Exception("Layer " + this.name + " has multiple inbound nodes, " + "hence the notion of \"layer input mask\" is ill-defined. Use `get_input_mask_at(node_index)` instead.");
                }

                return this.GetInputMaskAt(0);
            }
        }

        public KerasSymbol OutputMask
        {
            get
            {
                if (this._inbound_nodes.Count != 1)
                {
                    throw new Exception("Layer " + this.name + " has multiple inbound nodes, hence the notion of \"layer output mask\" is ill-defined. Use `get_output_mask_at(node_index)` instead.");
                }
                return this.GetOutputMaskAt(0);
            }
        }

        public Shape InputShape
        {
            get
            {
                if (this._inbound_nodes == null)
                {
                    throw new Exception("The layer has never been called and thus has no defined input shape.");
                }

                var all_input_shapes = new List<Shape>();
                foreach (var node in _inbound_nodes)
                {
                    all_input_shapes.AddRange(node.input_shapes);
                }

                if (all_input_shapes.Count == 1)
                {
                    var input_shapes = this._inbound_nodes[0].input_shapes;
                    return input_shapes[0];
                }
                else
                {
                    throw new Exception("The layer \"" + this.name.ToString() + " has multiple inbound nodes, with different input shapes. Hence the notion of \"input shape\" is ill-defined for the layer. Use `get_input_shape_at(node_index)` instead.");
                }
            }
        }

        public Shape OutputShape
        {
            get
            {
                if (this._inbound_nodes == null)
                {
                    throw new Exception("The layer has never been called and thus has no defined output shape.");
                }
                var all_output_shapes = new List<Shape>();
                foreach (var node in _inbound_nodes)
                {
                    all_output_shapes.AddRange(node.output_shapes);
                }

                if (all_output_shapes.Count == 1)
                {
                    var output_shapes = this._inbound_nodes[0].output_shapes;
                    return output_shapes[0];
                }
                else
                {
                    throw new Exception("The layer \"" + this.name.ToString() + " has multiple inbound nodes, with different output shapes. Hence the notion of \"output shape\" is ill-defined for the layer. Use `get_output_shape_at(node_index)` instead.");
                }
            }
        }
        
        public KerasSymbol[] Weights
        {
            get
            {
                var r =TrainableWeights.ToList();
                r.AddRange(NonTrainableWeights);
                return r.ToArray();
            }
        }

        public Layer(Shape input_shape = null, Shape batch_input_shape = null, int? batch_size = null, DType dtype = null, string name = null, bool? trainable = null, KerasSymbol[] weights = null)
        {
            this.input_spec = null;
            this.supports_masking = false;
            this.stateful = false;
            // These properties will be set upon call of this.build()
            this._trainable_weights = new List<KerasSymbol>();
            this._non_trainable_weights = new List<KerasSymbol>();
            this._losses = new List<KerasSymbol>();
            this._updates = new List<(KerasSymbol, KerasSymbol)>();
            this._per_input_losses = new Dictionary<string, List<KerasSymbol>>();
            this._per_input_updates = new Dictionary<string, List<(KerasSymbol, KerasSymbol)>>();
            this._built = false;
            // These lists will be filled via successive calls
            // to this._add_inbound_node().
            this._inbound_nodes = new List<Node>();
            this._outbound_nodes = new List<Node>();
           
            if (string.IsNullOrWhiteSpace(name))
            {
                var prefix = this.GetType().Name;
                name = prefix + "_" + K.GetUid(prefix).ToString();
            }

            this.name = name;
            this.trainable = trainable.HasValue ? trainable.Value : false;
            if (input_shape != null || batch_input_shape != null)
            {
                // In this case we will later create an input layer
                // to insert before the current layer
                if (batch_input_shape!= null)
                {
                    this.batch_input_shape = batch_input_shape;
                }
                else if (input_shape != null)
                {
                    var shapeTuple = input_shape.Data.ToList();
                    if (batch_size.HasValue)
                    {
                        shapeTuple.Insert(0, batch_size.Value);
                    }
                    else
                    {
                        shapeTuple.Insert(0, 0);
                    }

                    batch_input_shape = new Shape(shapeTuple);
                }

                this.batch_input_shape = batch_input_shape;
                // Set dtype.
                if (dtype == null)
                {
                    dtype = K.FloatX();
                }
                
                this.dtype = dtype;
            }
            if (weights != null)
            {
                this._initial_weights = weights.ToList();
            }
            else
            {
                this._initial_weights = null;
            }
        }

        public static string NodeKey(Layer layer, int node_index)
        {
            return layer.name + "_ib-" + node_index.ToString();
        }

        public KerasSymbol[] Losses => _losses.ToArray();

        public (KerasSymbol, KerasSymbol)[] Updates
        {
            get
            {
                if (!this.trainable && !this.stateful)
                {
                    return new (KerasSymbol, KerasSymbol)[0];
                }

                return this._updates.ToArray();
            }
        }

        public bool Built
        {
            get
            {
                return this._built;
            }
            set
            {
                this._built = value;
            }
        }

        public KerasSymbol[] TrainableWeights
        {
            get
            {
                if (trainable)
                {
                    return this._trainable_weights.ToArray();
                }
                else
                {
                    return new KerasSymbol[0];
                }
            }
            set
            {
                this._trainable_weights = value.ToList();
            }
        }

        public KerasSymbol[] NonTrainableWeights
        {
            get
            {
                if (!trainable)
                {
                    List<KerasSymbol> ret = new List<KerasSymbol>();
                    ret.AddRange(_trainable_weights);
                    ret.AddRange(_non_trainable_weights);
                    return ret.ToArray();
                }
                else
                {
                    return _non_trainable_weights.ToArray();
                }
            }
            set
            {
                this._trainable_weights = value.ToList();
            }
        }

        public virtual KerasSymbol AddWeight(string name, Shape shape, DType dtype= null, Initializer initializer= null, Regularizer regularizer = null, bool trainable= true, Constraint constraint= null, bool sparse_weight= false)
        {
            KerasSymbol weight = null;
            
            if (dtype == null)
            {
                dtype = K.FloatX();
            }
            // Use sparse weight only with MXNet Backend
            weight = K.Variable(initializer.Call(shape), dtype: dtype, name: name, constraint: constraint, sparse_weight: sparse_weight);

            if (regularizer != null)
            {
                using (var ns = new NameScope("weight_regularizer")) {
                    this.AddLoss(new KerasSymbol[] { regularizer.Call(weight) });
                }
            }
            if (trainable)
            {
                this._trainable_weights.Add(weight);
            }
            else
            {
                this._non_trainable_weights.Add(weight);
            }
            return weight;
        }

        public void AssertInputCompatibility(KerasSymbol[] inputs)
        {
            Shape x_shape;
            int ndim;
            foreach (var x in inputs)
            {
                try
                {
                    K.IsKerasTensor(x);
                }
                catch (Exception ex)
                {
                    throw new Exception("Layer " + this.name + " was called with an input that isn\'t a symbolic tensor. Received type: " + x.GetType().Name + ". Full input: " + inputs.ToString() + ". All inputs to the layer should be tensors.");
                }
            }
            if (this.input_spec == null)
            {
                return;
            }

            if (inputs.Length != input_spec.Length)
            {
                throw new Exception("Layer " + this.name + " expects " + input_spec.Length.ToString() + " inputs, but it received " + inputs.Length.ToString() + " input tensors. Input received: " + inputs.ToString());
            }

            for (int i = 0; i < inputs.Length; i++)
            {
                var input_index = i;
                var x = inputs[i];
                var spec = input_spec[i];
                if (spec.ndim != null)
                {
                    if (K.NDim(x) != spec.ndim)
                    {
                        throw new Exception("Input " + input_index.ToString() + " is incompatible with layer " + this.name + ": expected ndim=" + spec.ndim.ToString() + ", found ndim=" + K.NDim(x).ToString());
                    }
                }
                if (spec.max_ndim != null)
                {
                    ndim = K.NDim(x);
                    if (ndim != 0 && ndim > spec.max_ndim)
                    {
                        throw new Exception("Input " + input_index.ToString() + " is incompatible with layer " + this.name + ": expected max_ndim=" + spec.max_ndim.ToString() + ", found ndim=" + K.NDim(x).ToString());
                    }
                }

                if (spec.min_ndim != null)
                {
                    ndim = K.NDim(x);
                    if (ndim != 0 && ndim < spec.min_ndim)
                    {
                        throw new Exception("Input " + input_index.ToString() + " is incompatible with layer " + this.name + ": expected min_ndim=" + spec.min_ndim.ToString() + ", found ndim=" + K.NDim(x).ToString());
                    }
                }
                // Check dtype.
                if (spec.dtype != null)
                {
                    if (K.DataType(x).Name != spec.dtype.Name)
                    {
                        throw new Exception("Input " + input_index.ToString() + " is incompatible with layer " + this.name + ": expected dtype=" + spec.dtype.ToString() + ", found dtype=" + K.DataType(x).ToString());
                    }
                }

                if (spec.axes != null)
                {
                    try
                    {
                        x_shape = new Shape(K.IntShape(x));
                    }
                    catch
                    {
                        x_shape = null;
                    }
                    if (x_shape != null)
                    {
                        foreach (var _tup_2 in spec.axes)
                        {
                            var axis = _tup_2.Key;
                            var value = _tup_2.Value;
                            if(value != x_shape[axis])
                            {
                                throw new Exception("Input " + input_index +
                                " is incompatible with layer " +
                                name + ": expected axis " +
                                axis + " of input shape to have " +
                                "value " + value +
                                " but got shape " + x_shape);
                            }
                        }
                    }
                }

                if (spec.shape != null)
                {
                    try
                    {
                        x_shape = new Shape(K.IntShape(x));
                    }
                    catch
                    {
                        x_shape = null;
                    }

                    if (x_shape != null)
                    {
                        for(int dim_i = 0; dim_i < spec.shape.Dimension; dim_i++)
                        {
                            var spec_dim = spec.shape[dim_i];
                            var dim = x_shape[dim_i];
                            if (spec_dim != dim)
                            {
                                throw new Exception("Input " + input_index.ToString() + " is incompatible with layer " + this.name + ": expected shape=" + spec.shape.ToString() + ", found shape=" + x_shape.ToString());
                            }
                        }
                    }
                }
            }
        }

        public abstract KerasSymbol[] Invoke(KerasSymbol[] inputs, FuncArgs kwargs);

        public KerasSymbol[] Call(KerasSymbol inputs, FuncArgs kwargs = null)
        {
            return Call(new KerasSymbol[] { inputs }, kwargs);
        }

        public KerasSymbol[] Call(KerasSymbol[] inputs, FuncArgs kwargs = null)
        {
            KerasSymbol[] output = null;
            using (var ns = new NameScope(this.name)) {
                // Handle laying building (weight creating, input spec locking).
                if (!this.Built)
                {
                    // Raise exceptions in case the input is not compatible
                    // with the input_spec specified in the layer constructor.
                    this.AssertInputCompatibility(inputs);
                    // Collect input shapes to build layer.
                    var input_shapes = new List<Shape>();
                    foreach (var x_elem in inputs)
                    {
                        //ToDo: recheck this one
                        if (x_elem._keras_shape != null)
                        {
                            input_shapes.Add(x_elem._keras_shape);
                        }
                        else
                        {
                            input_shapes.Add(x_elem.Shape);
                        }
                    }


                    this.Build(input_shapes[0]);
                    this.Built = true;
                    // Load weights that were specified at layer instantiation.
                    if (this._initial_weights != null)
                    {
                        this.SetWeights(this._initial_weights.ToArray());
                    }
                }
                // Raise exceptions in case the input is not compatible
                // with the input_spec set at build time.
                this.AssertInputCompatibility(inputs);
                // Handle mask propagation.
                var previous_mask = BaseLayers.CollectPreviousMask(inputs);
                var user_kwargs = kwargs;
                if (previous_mask.Where(x=>x == null).Count() == 0)
                {
                    // The previous layer generated a mask.
                    if (!kwargs.Contains("mask"))
                    {
                        // If mask is explicitly passed to __call__,
                        // we should override the default mask.
                        kwargs["mask"] = previous_mask;
                    }
                }

                // Handle automatic shape inference (only useful for Theano).
                var input_shape = BaseLayers.CollectInputShape(inputs);
                // Actually call the layer,
                // collecting output(s), mask(s), and shape(s).
                output = this.Invoke(inputs, kwargs);
                var output_mask = this.ComputeMask(inputs, previous_mask);
                // If the layer returns tensors from its inputs, unmodified,
                // we copy them to avoid loss of tensor metadata.
                var output_ls = output;
                var inputs_ls = inputs;
                var output_ls_copy = new List<KerasSymbol>();
                for(int index = 0; index < output_ls.Length; index++)
                {
                    var x = output_ls[index];
                    //ToDo: Recheck this condition
                    //if (inputs_ls.FirstOrDefault(i => i.Name == x.Name) != null)
                    //{
                    //    x = K.Identity(x);
                    //}

                    output_ls_copy.Add(x);
                }

                output = new KerasSymbol[] { output_ls_copy[0] };
                Shape[] output_shape = null;
                // Inferring the output shape is only relevant for Theano.
                if (input_shape.Where(x=>x != null).Count() > 0)
                {
                    output_shape = this.ComputeOutputShape(input_shape);
                }
                else
                {
                    output_shape = null;
                }

                if (output_ls.Length == 1)
                {
                    // Augment the mask to match the length of the output.
                    List<KerasSymbol> omList = new List<KerasSymbol>();
                    for(int i = 0; i< output_ls.Length; i++)
                    {
                        omList.Add(output_mask[0]);
                    }

                    output_mask = omList.ToArray();
                }
                // Add an inbound node to the layer, so that it keeps track
                // of the call and of all new variables created during the call.
                // This also updates the layer history of the output tensor(s).
                // If the input tensor(s) had not previous Keras history,
                // this does nothing.
                this.AddInboundNode(input_tensors: inputs, output_tensors: output, input_masks: previous_mask, output_masks: output_mask, input_shapes: input_shape, output_shapes: output_shape, arguments: user_kwargs);
                // Apply activity regularizer if any:
                
                if (this.activity_regularizer != null)
                {
                    KerasSymbol[] regularization_losses = null;
                    using (var ns1 = new NameScope("activity_regularizer")) 
                    {
                        regularization_losses = (from x in output
                                                 select this.activity_regularizer.Call(x)).ToArray();
                    }

                    this.AddLoss(regularization_losses, inputs: inputs);
                }
            }

            return output;
        }

        internal void AddInboundNode(KerasSymbol[] input_tensors, KerasSymbol[] output_tensors,
                                        KerasSymbol[]  input_masks, KerasSymbol[]  output_masks,
                                        Shape[] input_shapes, Shape[] output_shapes, FuncArgs arguments= null)
        {
            // Collect input tensor(s) coordinates.
            var inbound_layers = new List<Layer>();
            var node_indices = new List<int>();
            var tensor_indices = new List<int>();
            foreach (var x in input_tensors)
            {
                if (x._keras_history != null)
                {
                    var _tup_1 = x._keras_history.Value;
                    var inbound_layer = _tup_1.Item1;
                    var node_index = _tup_1.Item2;
                    var tensor_index = _tup_1.Item3;
                    inbound_layers.Add(inbound_layer);
                    node_indices.Add(node_index);
                    tensor_indices.Add(tensor_index);
                }
                else
                {
                    inbound_layers.Add(null);
                    node_indices.Add(0);
                    tensor_indices.Add(0);
                }
            }

            // Create node, add it to inbound nodes.
            new Node(this, inbound_layers: inbound_layers.ToArray(), node_indices: node_indices.ToArray(), tensor_indices: tensor_indices.ToArray(), input_tensors: input_tensors, output_tensors: output_tensors, input_masks: input_masks, output_masks: output_masks, input_shapes: input_shapes, output_shapes: output_shapes, arguments: arguments);
            // Update tensor history, _keras_shape and _uses_learning_phase.
            foreach (var i in Enumerable.Range(0, output_tensors.Length))
            {
                output_tensors[i]._keras_shape = output_shapes[i];
                var uses_lp = input_tensors.Select(x => x._uses_learning_phase).Any();
                //uses_lp = getattr(this, "uses_learning_phase", false) || uses_lp;
                output_tensors[i]._uses_learning_phase = uses_lp;
                output_tensors[i]._keras_history = (this, this._inbound_nodes.Count - 1, i);
            }
        }

        public virtual Shape[] ComputeOutputShape(Shape[] input_shape)
        {
            return input_shape;
        }

        public virtual KerasSymbol[] ComputeMask(KerasSymbol[] inputs, KerasSymbol[] mask = null)
        {
            if (!this.supports_masking)
            {
                if (mask != null)
                {
                    if (mask.Count(x=>x != null) > 0)
                    {
                        throw new Exception("Layer " + this.name + " does not support masking, but was passed an input_mask: " + mask.ToString());
                    }
                }
                // masking not explicitly supported: return None as mask
                return mask;
            }
            // if masking is explicitly supported, by default
            // carry over the input mask
            return mask;
        }

        public virtual void Build(Shape input_shape)
        {
            Built = true;
        }

        public virtual T GetNodeAttributeAtIndex<T>(int node_index, string attr, string attr_name)
        {
            if (this._inbound_nodes == null)
            {
                throw new Exception("The layer has never been called and thus has no defined " + attr_name + ".");
            }

            if (!(this._inbound_nodes.Count > node_index))
            {
                throw new Exception("Asked to get " + attr_name + " at node " + node_index.ToString() + ", but the layer has only " + this._inbound_nodes.Count.ToString() + " inbound nodes.");
            }

            var array = this._inbound_nodes[node_index].GetType().GetField(attr).GetValue(this._inbound_nodes[node_index]);
            if(array != null)
            {
                T[] r = (T[])array;
                return r[0];
            }

            return default(T);
        }

        public virtual Shape GetInputShapeAt(int node_index)
        {
            return this.GetNodeAttributeAtIndex<Shape>(node_index, "input_shapes", "input shape");
        }

        public virtual Shape GetOutputShapeAt(int node_index)
        {
            return this.GetNodeAttributeAtIndex<Shape>(node_index, "output_shapes", "output shape");
        }

        public virtual KerasSymbol GetInputAt(int node_index)
        {
            return this.GetNodeAttributeAtIndex<KerasSymbol>(node_index, "input_tensors", "input");
        }

        public virtual KerasSymbol GetOutputAt(int node_index)
        {
            return this.GetNodeAttributeAtIndex<KerasSymbol>(node_index, "output_tensors", "output");
        }

        public virtual KerasSymbol GetInputMaskAt(int node_index)
        {
            return this.GetNodeAttributeAtIndex<KerasSymbol>(node_index, "input_masks", "input masks");
        }

        public virtual KerasSymbol GetOutputMaskAt(int node_index)
        {
            return this.GetNodeAttributeAtIndex<KerasSymbol>(node_index, "output_masks", "output masks");
        }

        public virtual void AddLoss(KerasSymbol[] losses, KerasSymbol[]  inputs = null)
        {
            string inputs_hash;
            if (losses == null || losses.Length == 0)
            {
                return;
            }

            if (this._losses != null)
            {
                this._losses.AddRange(losses);
            }

            if (inputs != null)
            {
                inputs_hash = GenericUtils.ObjectListUid(inputs);
            }
            else
            {
                // Updates indexed by None are unconditional
                // rather than input-dependent
                inputs_hash = null;
            }
            if (!this._per_input_losses.ContainsKey(inputs_hash))
            {
                this._per_input_losses[inputs_hash] = new List<KerasSymbol>();
            }

            this._per_input_losses[inputs_hash].AddRange(losses);
        }

        public virtual void AddUpdate((KerasSymbol, KerasSymbol)[] updates, KerasSymbol[] inputs = null)
        {
            string inputs_hash = "";
           
            if (_updates != null)
            {
                this._updates.AddRange(updates);
            }

            if (inputs != null)
            {
                inputs_hash = GenericUtils.ObjectListUid(inputs);
            }
            else
            {
                // Updates indexed by None are unconditional
                // rather than input-dependent
                inputs_hash = "";
            }

            if (!this._per_input_updates.ContainsKey(inputs_hash))
            {
                this._per_input_updates[inputs_hash] = new List<(KerasSymbol, KerasSymbol)>();
            }

            this._per_input_updates[inputs_hash].AddRange(updates);
        }

        public virtual (KerasSymbol, KerasSymbol)[] GetUpdatesFor(KerasSymbol[] inputs)
        {
            string inputs_hash = "";
            if (!this.trainable && !this.stateful)
            {
                return new (KerasSymbol, KerasSymbol)[0];
            }

            if (inputs != null)
            {
                inputs_hash = GenericUtils.ObjectListUid(inputs);
            }
            else
            {
                inputs_hash = null;
            }

            if (this._per_input_updates.ContainsKey(inputs_hash))
            {
                return this._per_input_updates[inputs_hash].ToArray();
            }

            return new (KerasSymbol, KerasSymbol)[0];
        }

        public virtual KerasSymbol[] GetLossesFor(KerasSymbol[] inputs)
        {
            string inputs_hash = "";
            if (inputs != null)
            {
                inputs_hash = GenericUtils.ObjectListUid(inputs);
            }
            else
            {
                inputs_hash = "";
            }

            if (this._per_input_losses.ContainsKey(inputs_hash))
            {
                return this._per_input_losses[inputs_hash].ToArray();
            }

            return new KerasSymbol[0];
        }

        public virtual void SetWeights(KerasSymbol[] weights)
        {
            var @params = this.Weights;
            if (@params.Length != weights.Length) {
                throw new Exception("You called `set_weights(weights)` on layer \"" + this.name + "\" with a  weight list of length " + weights.Length.ToString() + ", but the layer was expecting " + @params.Length.ToString());
            }
            if (@params == null) {
                return;
            }

            var weight_value_tuples = new List<(KerasSymbol, NDArray)>();
            var param_values = K.BatchGetValue(@params);
            for(int i = 0; i < param_values.Length; i++)
            {
                var pv = param_values[i];
                var p = @params[i];
                var w = weights[i];

                if (pv.Shape.ToString() != w.Shape.ToString())
                {
                    throw new Exception("Layer weight shape " + pv.Shape.ToString() + " not compatible with provided weight shape " + w.Shape.ToString());
                }

                weight_value_tuples.Add((w, pv));
            }
           
            K.BatchSetValue(weight_value_tuples);
        }

        public virtual NDArray[] GetWeights()
        {
            return K.BatchGetValue(Weights);
        }

        public virtual ConfigDict GetConfig()
        {
            var configDict = new ConfigDict()
            {
                    {
                        "name",
                        this.name},
                    {
                        "trainable",
                        this.trainable
                    }
            };

            if (batch_input_shape != null)
            {
                configDict["batch_input_shape"] = this.batch_input_shape;
            }
            if (dtype != null)
            {
                configDict["dtype"] = this.dtype;
            }

            return configDict;
        }

        public static Layer FromConfig(string cls, ConfigDict config, CustomObjects custom_objects = null)
        {
            var t = Type.GetType("MxNet.Keras.Layers" + cls, true, true);
            var layer = Activator.CreateInstance(t);
            foreach (var item in config)
            {
                var field = t.GetField(item.Key);
                if(field != null)
                {
                    field.SetValue(layer, item.Value);
                    continue;
                }

                var prop = t.GetProperty(item.Key);
                if (prop != null)
                {
                    prop.SetValue(layer, item.Value);
                }
            }

            return (Layer)layer;
        }

        public virtual int CountParams()
        {
            if (!this._built)
            {
                if (this.GetType().Name == "Sequential")
                {
                    this.Build(null);
                }
                else
                {
                    throw new Exception("You tried to call `count_params` on " + this.name + ", but the layer isn\'t built. You can build it manually via: `" + this.name + ".build(batch_input_shape)`.");
                }
            }
            return LayerUtils.CountParams(this.Weights);
        }

        public virtual void ResetStates()
        {
            //Base without implementation
        }
    }
}
