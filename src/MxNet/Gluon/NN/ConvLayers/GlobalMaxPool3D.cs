using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.NN
{
    public class GlobalMaxPool3D : _Pooling
    {
        public GlobalMaxPool3D(string layout = "NCDHW", string prefix = null, ParameterDict @params = null)
                        : base(new int[] { 1, 1, 1 }, null, new int[] { 0, 0, 0 }, true, true, "max", layout, null, prefix, @params)
        {
            throw new NotImplementedException();
        }
    }
}
