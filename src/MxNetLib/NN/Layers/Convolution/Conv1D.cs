using MxNetLib;
using System;
using System.Collections.Generic;
using System.Text;
using MxNetLib.NN.Initializers;
using MxNetLib.NN.Regularizers;
using MxNetLib.NN.Constraints;

namespace MxNetLib.NN.Layers
{
    public class Conv1D : BaseLayer
    {
        public uint Filters { get; set; }

        public uint KernalSize { get; set; }

        public uint Strides { get; set; }

        public uint? Padding { get; set; }

        public uint DialationRate { get; set; }

        public ActivationType Activation { get; set; }

        public bool UseBias { get; set; }

        public BaseInitializer BiasInitializer { get; set; }

        public BaseInitializer KernalInitializer { get; set; }

        public BaseConstraint KernalConstraint { get; set; }

        public BaseConstraint BiasConstraint { get; set; }

        public BaseRegularizer KernalRegularizer { get; set; }

        public BaseRegularizer BiasRegularizer { get; set; }

        public Conv1D(uint filters, uint kernalSize, uint strides = 1, uint? padding=null, 
                        uint dialationRate = 1, ActivationType activation = ActivationType.Linear, BaseInitializer kernalInitializer = null,
                        BaseRegularizer kernalRegularizer = null, BaseConstraint kernalConstraint = null, bool useBias = true, 
                        BaseInitializer biasInitializer = null, BaseRegularizer biasRegularizer = null, BaseConstraint biasConstraint = null)
            :base("conv1d")
        {
            Filters = filters;
            KernalSize = kernalSize;
            Strides = strides;
            Padding = padding;
            DialationRate = dialationRate;
            Activation = activation;
            UseBias = useBias;
            KernalInitializer = kernalInitializer ?? new GlorotUniform();
            BiasInitializer = biasInitializer ?? new Zeros();
            KernalConstraint = kernalConstraint;
            BiasConstraint = biasConstraint;
            KernalRegularizer = kernalRegularizer;
            BiasRegularizer = biasRegularizer;
        }

        public override Symbol Build(Symbol x)
        {
            var biasName = UUID.GetID(ID + "_b");
            var weightName = UUID.GetID(ID + "_w");
            Shape pad = null;
            if(Padding.HasValue)
            {
                pad = new Shape(Padding.Value);
            }
            else
            {
                pad = new Shape();
            }

            InitParams.Add(biasName, BiasInitializer);
            InitParams.Add(weightName, KernalInitializer);

            ConstraintParams.Add(weightName, KernalConstraint);
            ConstraintParams.Add(biasName, BiasConstraint);

            RegularizerParams.Add(weightName, KernalRegularizer);
            RegularizerParams.Add(biasName, BiasRegularizer);

            return sym.Convolution(x, Symbol.Variable(weightName),
                                            Symbol.Variable(biasName), new Shape(KernalSize), Filters, new Shape(Strides),
                                            new Shape(DialationRate), pad, 1, 1024, false, ConvolutionCudnnTune.Off, false, null, ID);
        }
    }
}
