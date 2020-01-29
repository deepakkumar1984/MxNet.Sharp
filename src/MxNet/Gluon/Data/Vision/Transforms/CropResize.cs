using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class CropResize : HybridBlock
    {
        public CropResize(int x, int y, int width, int height, (int, int)? size= null, int? interpolation= null)
        {
            throw new NotImplementedException();
        }
        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            throw new NotImplementedException();
        }
    }
}
