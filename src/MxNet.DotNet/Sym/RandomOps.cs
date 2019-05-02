using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.DotNet
{
    public partial class SymbolOps
    {
        public Random Random = new Random();
    }

    public class Random
    {
        public Symbol Exponential(float scale = 1, Shape shape = null, DType dtype = null, string name = "")
        {
            if (shape == null)
                shape = new Shape();

            if (dtype == null)
                dtype = DType.Float32;

            return new Operator("_random_exponential").Set(scale, shape, dtype).CreateSymbol(name);
        }

        public Symbol Gamma(float alpha = 1, float beta = 1, Shape shape = null, DType dtype = null, string name = "")
        {
            if (shape == null)
                shape = new Shape();

            if (dtype == null)
                dtype = DType.Float32;

            return new Operator("_random_gamma").Set(alpha, beta, shape, dtype).CreateSymbol(name);
        }

        public Symbol NegativeBinomial(float k = 1, float p = 1, Shape shape = null, DType dtype = null, string name = "")
        {
            if (shape == null)
                shape = new Shape();

            if (dtype == null)
                dtype = DType.Float32;

            return new Operator("_random_negative_binomial").Set(k, p, shape, dtype).CreateSymbol(name);
        }

        public Symbol GeneralizedNegativeBinomial(float mu = 1, float alpha = 1, Shape shape = null, DType dtype = null, string name = "")
        {
            if (shape == null)
                shape = new Shape();

            if (dtype == null)
                dtype = DType.Float32;

            return new Operator("_random_generalized_negative_binomia").Set(mu, alpha, shape, dtype).CreateSymbol(name);
        }

        public Symbol Multinomial(Symbol data, Shape shape = null, bool get_prob = true, DType dtype = null, string name = "")
        {
            if (shape == null)
                shape = new Shape();

            if (dtype == null)
                dtype = DType.Float32;

            return new Operator("_random_multinomial").Set(data, shape, get_prob, dtype).CreateSymbol(name);
        }

        public Symbol Shuffle(Symbol data, string name = "")
        {
            return new Operator("_random_shuffle").Set(data).CreateSymbol(name);
        }

        public Symbol Normal(float loc = 0, float scale = 1, Shape shape = null, DType dtype = null, string name = "")
        {
            if (shape == null)
                shape = new Shape();

            if (dtype == null)
                dtype = DType.Float32;

            return new Operator("_random_normal").Set(loc, scale, shape, dtype).CreateSymbol(name);
        }

        public Symbol Uniform(float low = 0, float high = 1, Shape shape = null, DType dtype = null, string name = "")
        {
            if (shape == null)
                shape = new Shape();

            if (dtype == null)
                dtype = DType.Float32;

            return new Operator("_random_uniform").Set(low, high, shape, dtype).CreateSymbol(name);
        }

        public Symbol Poisson(float lam = 1, Shape shape = null, DType dtype = null, string name = "")
        {
            if (shape == null)
                shape = new Shape();

            if (dtype == null)
                dtype = DType.Float32;

            return new Operator("_random_poisson").Set(lam, shape, dtype).CreateSymbol(name);
        }
    }
}
