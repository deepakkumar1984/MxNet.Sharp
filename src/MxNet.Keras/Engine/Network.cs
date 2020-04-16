using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Engine
{
    public class Network
    {
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

        public Network()
        {
            throw new NotImplementedException();
        }

        public void BaseInit(string name = null)
        {
            throw new NotImplementedException();
        }

        internal void InitGraphNetwork(Symbol[] inputs, Symbol[]  outputs, string name= null)
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

        public Symbol[] GetWeights()
        {
            throw new NotImplementedException();
        }

        public void GetWeights(Symbol[] weights)
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
