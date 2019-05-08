using System;
using System.Collections.Generic;
using System.Text;
using MxNetLib;
using Newtonsoft.Json;
using MxNetLib.NN.Initializers;
using MxNetLib.NN.Layers.Activations;
using MxNetLib.NN.Regularizers;
using MxNetLib.NN.Constraints;

namespace MxNetLib.NN.Layers
{
    public class Dense : BaseLayer
    {
        public int Dim { get; set; }

        public BaseLayer Activation { get; set; }

        public bool UseBias { get; set; }

        public BaseInitializer KernalInitializer { get; set; }

        public BaseInitializer BiasInitializer { get; set; }

        public BaseConstraint KernalConstraint { get; set; }

        public BaseConstraint BiasConstraint { get; set; }

        public BaseRegularizer KernalRegularizer { get; set; }

        public BaseRegularizer BiasRegularizer { get; set; }

        public Dense(int dim, ActivationType activation = ActivationType.Linear, 
                    BaseInitializer kernalInitializer = null, BaseRegularizer kernalRegularizer = null, BaseConstraint kernalConstraint = null,
                    bool useBias = false, BaseInitializer biasInitializer = null, BaseRegularizer biasRegularizer=null, BaseConstraint biasConstraint = null)
            : base("dense")
        {
            Dim = dim;
            Activation = ActivationRegistry.Get(activation);
            UseBias = useBias;
            KernalInitializer = kernalInitializer ?? new GlorotUniform();
            BiasInitializer = biasInitializer ?? new Zeros();
            KernalConstraint = kernalConstraint;
            BiasConstraint = biasConstraint;
            KernalRegularizer = kernalRegularizer;
            BiasRegularizer = biasRegularizer;
        }

        public override Symbol Build(Symbol data)
        {
            var weightName = UUID.GetID(ID + "_w");
            var biasName = UUID.GetID(ID + "_b");

            var bias = UseBias ? Symbol.Variable(biasName) : null;

            InitParams.Add(weightName, KernalInitializer);
            if(UseBias)
                InitParams.Add(biasName, BiasInitializer);

            ConstraintParams.Add(weightName, KernalConstraint);
            if(UseBias)
                ConstraintParams.Add(biasName, BiasConstraint);

            RegularizerParams.Add(weightName, KernalRegularizer);
            if(UseBias)
                RegularizerParams.Add(biasName, BiasRegularizer);

            if (Activation != null)
            {
                return Activation.Build(sym.FullyConnected(data, Symbol.Variable(weightName), bias, Dim, !UseBias, true, ID));
            }
            else
            {
                return sym.FullyConnected(data, Symbol.Variable(weightName), bias, Dim, !UseBias, true, ID);
            }
        }
    }
}
