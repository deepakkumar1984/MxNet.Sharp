using MxNet.Gluon.Probability.Distributions.Constraints;
using NumpyDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Probability.Distributions
{
    public class Bernoulli : ExponentialFamily
    {
        public NDArrayOrSymbol Prob
        {
            get
            {
                return DistributionsUtils.Logit2Prob(this.logit, true);
            }
        }

        public NDArrayOrSymbol Logit
        {
            get
            {
                return DistributionsUtils.Prob2Logit(this.prob, true);
            }
        }

        public override NDArrayOrSymbol Mean
        {
            get
            {
                return this.prob;
            }
        }

        public override NDArrayOrSymbol Variance
        {
            get
            {
                return this.prob * (1 - this.prob);
            }
        }

        public override NDArrayOrSymbolList NaturalParams
        {
            get
            {
                return new NDArrayOrSymbolList(logit);
            }
        }

        public new Dictionary<string, Constraint> arg_constraints = new Dictionary<string, Constraint> 
        {
            {
                "prob",
                new Interval(0, 1)},
            {
                "logit",
                new Real()
            }
        };

        public Bernoulli(NDArrayOrSymbol prob = null, NDArrayOrSymbol logit = null, bool? validate_args = null)
            : base(0, validate_args)
        {
            if (prob != null)
            {
                this.prob = prob;
            }
            else
            {
                this.logit = logit;
            }
        }

        public override Distribution BroadcastTo(Shape batch_shape)
        {
            var new_instance = new Distribution();
            if (this.prob != null)
            {
                new_instance.prob = this.prob.IsNDArray ? nd.BroadcastTo(this.prob, batch_shape) : sym.BroadcastTo(this.prob, batch_shape);
            }
            else
            {
                new_instance.logit = this.logit.IsNDArray ? nd.BroadcastTo(this.logit, batch_shape) : sym.BroadcastTo(this.logit, batch_shape);
            }

            new_instance.event_dim = event_dim;
            new_instance._validate_args = this._validate_args;
            return new_instance;
        }

        public override NDArrayOrSymbol LogProb(NDArrayOrSymbol value)
        {
            if (this._validate_args)
            {
                this.ValidateSamples(value);
            }
            
            if (this.prob == null)
            {
                var logit = this.logit;
                if(logit.IsNDArray)
                    return logit.NdX * (value.NdX - 1) - nd.Log(nd.Exp(nd.Negative(logit)) + 1);

                return logit.SymX * (value.SymX - 1) - sym.Log(sym.Exp(sym.Negative(logit)) + 1);
            }
            else
            {
                // Parameterized by probability
                var eps = 1E-12f;
                if(this.prob.IsNDArray)
                    return nd.Log(this.prob + eps) * value.NdX + nd.Log1P(nd.Negative(this.prob) + eps) * (1 - value.NdX);

                return sym.Log(this.prob + eps) * value.SymX + sym.Log1P(sym.Negative(this.prob) + eps) * (1 - value.SymX);
            }
        }

        public override NDArrayOrSymbol Sample(Shape size)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol SampleN(Shape size)
        {
            throw new NotImplementedException();
        }

        public override NDArrayOrSymbol LogNormalizer(NDArrayOrSymbol x)
        {
            if (x.IsNDArray)
                return nd.Log(1 + nd.Exp(x));

            return sym.Log(1 + sym.Exp(x));
        }

        public override NDArrayOrSymbol Entropy()
        {
            if (this.prob.IsNDArray)
                return nd.Negative(logit.NdX * (prob.NdX - 1) - nd.Log(nd.Exp(nd.Negative(logit)) + 1));

            return sym.Negative(logit.SymX * (prob.SymX - 1) - sym.Log(sym.Exp(sym.Negative(logit)) + 1));
        }
    }
}
