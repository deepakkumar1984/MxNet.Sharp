using System;

namespace MxNet.Initializers
{
    public class MSRAPrelu : Xavier
    {
        public MSRAPrelu(string factor_type = "avg", float slope = 0.25f) : base("gaussian", factor_type)
        {
            Magnitude = 2 / (1 + (float) Math.Pow(slope, 2));
        }
    }
}