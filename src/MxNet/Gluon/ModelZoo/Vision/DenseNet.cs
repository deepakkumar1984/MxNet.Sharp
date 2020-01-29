using MxNet.Gluon.Contrib.NN;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.ModelZoo.Vision
{
    public class DenseNet : HybridBlock
    {
        public DenseNet(int num_init_features, int growth_rate, int[] block_config,
                        int bn_size= 4, float dropout= 0, int classes= 1000, 
                        string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }

        private static HybridSequential MakeDenseBlock(int num_layers, int bn_size, float growth_rate, float dropout, int stage_index) => throw new NotImplementedException();

        private static HybridConcurrent MakeDenseLayer(float growth_rate, int bn_size, float dropout) => throw new NotImplementedException();

        private static HybridSequential MakeTransition(int num_output_features) => throw new NotImplementedException();

        public static DenseNet GetDenseNet(int num_layers, bool pretrained= false, Context ctx= null, string root= "./models") => throw new NotImplementedException();

        public static DenseNet DenseNet121(bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();

        public static DenseNet DenseNet161(bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();

        public static DenseNet DenseNet169(bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();

        public static DenseNet DenseNet201(bool pretrained = false, Context ctx = null, string root = "./models") => throw new NotImplementedException();
    }
}
