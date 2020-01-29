using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class CenterCrop : Block
    {
        public CenterCrop((int , int)size, int interpolation= 1) : base(null, null)
        {
            throw new NotImplementedException();
        }

        public override NDArray Forward(NDArray input, params NDArray[] args)
        {
            throw new NotImplementedException();
        }
    }
}
