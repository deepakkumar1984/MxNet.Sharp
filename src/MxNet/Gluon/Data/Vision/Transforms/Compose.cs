using System.Collections.Generic;
using MxNet.Gluon.NN;

namespace MxNet.Gluon.Data.Vision.Transforms
{
    public class Compose : Sequential
    {
        public Compose(HybridBlock[] transforms)
        {
            var hybrid = new List<HybridBlock>();
            foreach (var item in transforms)
            {
                if (item.GetType().Name == "HybridBlock")
                {
                    hybrid.Add(item);
                    continue;
                }

                if (hybrid.Count == 1)
                {
                    Add(hybrid[0]);
                    hybrid.Clear();
                }
                else if (hybrid.Count > 1)
                {
                    var hblock = new HybridSequential();
                    foreach (var j in hybrid) hblock.Add(j);

                    hblock.Hybridize();
                    Add(hblock);
                    hybrid.Clear();
                }

                Add(item);
            }
        }
    }
}