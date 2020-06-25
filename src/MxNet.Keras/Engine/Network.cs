using MxNet.Optimizers;
using System;
using System.Collections.Generic;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Engine
{
    public class Network
    {
        public object _compute_previous_mask;

        public bool _expects_training_arg;

        public List<string> _feed_input_names;

        public List<Shape> _feed_input_shapes;

        public List<KerasSymbol> _feed_inputs;

        public List<Node> _inbound_nodes;

        public KerasSymbol[] _initial_weights;

        public List<object> _input_coordinates;

        public List<Layer> _input_layers;

        public bool _is_compiled;

        public bool _is_graph_network;

        public List<Layer> _layers;

        public object _layers_by_depth;

        public List<KerasSymbol> _losses;

        public List<Node> _network_nodes;

        public object _nodes_by_depth;

        public List<Node> _outbound_nodes;

        public List<object> _output_coordinates;

        public List<Layer> _output_layers;

        public Dictionary<string, KerasSymbol> _output_mask_cache;

        public Dictionary<string, Shape> _output_shape_cache;

        public Dictionary<string, KerasSymbol> _output_tensor_cache;

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
                throw new NotImplementedException();
            }
        }

        public Symbol[] Updates
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Symbol[] Losses
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool UseLearningPhase
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Layer[] Stateful
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Symbol[] StateUpdates
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public KerasSymbol[] TrainableWeights
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public KerasSymbol[] NonTrainableWeights
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public InputSpec InputSpec
        {
            get
            {
                throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        internal void InitSubclassedNetwork(string name= null)
        {
            throw new NotImplementedException();
        }

        public void ResetStates()
        {
            throw new NotImplementedException();
        }

        public NDArrayList GetWeights()
        {
            throw new NotImplementedException();
        }

        public void SetWeights(NDArrayList weights)
        {
            throw new NotImplementedException();
        }

        public Symbol Call(Symbol[] inputs, Symbol mask)
        {
            throw new NotImplementedException();
        }

        public Symbol ComputeMask(Symbol[] inputs, Symbol mask)
        {
            throw new NotImplementedException();
        }

        public Shape ComputeOutputShape(Shape input_shape)
        {
            throw new NotImplementedException();
        }

        public (Symbol[], Symbol[], Shape[]) RunInternalGraph(Symbol[] inputs, Symbol mask = null)
        {
            throw new NotImplementedException();
        }

        public ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }

        public static Network FromConfig(ConfigDict config, CustomObjects custom_objects = null)
        {
            throw new NotImplementedException();
        }

        public void Save(string filepath, bool overwrite= true, bool include_optimizer= true)
        {
            throw new NotImplementedException();
        }

        public void SaveWeights(string filepath, bool overwrite = true)
        {
            throw new NotImplementedException();
        }

        public void LoadWeights(string filepath, bool by_name = false,  bool skip_mismatch = false, bool reshape = false)
        {
            throw new NotImplementedException();
        }

        private ConfigDict UpdatedConfig()
        {
            throw new NotImplementedException();
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

        internal static string MakeNodeKey(string layer_name, int node_index)
        {
            throw new NotImplementedException();
        }

        internal static (Node[], Dictionary<int, Node[]>, Layer[], Dictionary<int, Layer[]>) MakeGrapkNetwork(Symbol[] inputs, Symbol[] outputs)
        {
            throw new NotImplementedException();
        }
    }
}
