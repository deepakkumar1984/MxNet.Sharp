using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision.Datasets
{
    public class ImageFolderDataset : Dataset<(NDArray, int)>
    {
        public ImageFolderDataset(string root, int flag= 1, Func<(NDArray, int), (NDArray, int)> transform= null)
        {
            throw new NotImplementedException();
        }

        private List<(string, int)> ListImages(string root) => throw new NotImplementedException();

        public override (NDArray, int) this[int idx] => throw new NotImplementedException();

        public override int Length => throw new NotImplementedException();
    }
}
