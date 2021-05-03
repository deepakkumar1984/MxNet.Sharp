using MxNet.Optimizers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.KVstore
{
    public class Horovod : KVStoreBase
    {
        public override int Rank => throw new NotImplementedRelease2Exception();

        public override string Type => "horovod";

        public override int NumWorkers => throw new NotImplementedRelease2Exception();

        public override void Broadcast(string key, NDArrayList value, NDArrayList @out, int priority = 0)
        {
            throw new NotImplementedRelease2Exception();
        }

        public override void Broadcast(int key, NDArrayList value, NDArrayList @out, int priority = 0)
        {
            throw new NotImplementedRelease2Exception();
        }

        public override bool IsCapable(string capability)
        {
            throw new NotImplementedRelease2Exception();
        }

        public override void LoadOptimizerStates(string fname)
        {
            throw new NotImplementedRelease2Exception();
        }

        public override void PushPull(string key, NDArrayList value, NDArrayList @out, int priority = 0)
        {
            throw new NotImplementedRelease2Exception();
        }

        public override void PushPull(int key, NDArrayList value, NDArrayList @out, int priority = 0)
        {
            throw new NotImplementedRelease2Exception();
        }

        public override void SaveOptimizerStates(string fname, bool dump_optimizer = false)
        {
            throw new NotImplementedRelease2Exception();
        }

        public override void SetOptimizer(Optimizer optimizer)
        {
            throw new NotImplementedRelease2Exception();
        }
    }
}
