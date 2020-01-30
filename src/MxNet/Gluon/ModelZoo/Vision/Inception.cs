using MxNet.Gluon.Contrib.NN;
using MxNet.Gluon.NN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.ModelZoo.Vision
{
    public class Inception
    {
        private static HybridSequential MakeBasicConv(int channels, (int, int) kernel_size, (int, int) strides = default, (int, int) padding = default)
        {
            throw new NotImplementedException();
        }

        private static HybridSequential MakeBranch(string use_pool, int? channels = null, (int, int)? kernel_size = null, (int, int) strides = default, (int, int) padding = default)
        {
            throw new NotImplementedException();
        }

        private static HybridConcurrent MakeA((int, int)? strides = null, (int, int)? padding = null, string prefix = "")
        {
            throw new NotImplementedException();
        }

        private static HybridConcurrent MakeB(string prefix)
        {
            throw new NotImplementedException();
        }

        private static HybridConcurrent MakeC(int channels_7x7, string prefix)
        {
            throw new NotImplementedException();
        }

        private static HybridConcurrent MakeD(int axis = 1, string prefix = "")
        {
            throw new NotImplementedException();
        }

        private static HybridConcurrent MakeE(string prefix)
        {
            throw new NotImplementedException();
        }

        private static HybridSequential MakeAux(int classes)
        {
            throw new NotImplementedException();
        }

        public static Inception3 GetInception3(bool pretrained = false, Context ctx = null, string root = "./models")
        {
            throw new NotImplementedException();
        }
    }

    public class Inception3 : HybridBlock
    {
        public Inception3(int classes = 1000, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
