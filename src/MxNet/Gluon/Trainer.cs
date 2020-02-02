using MxNet.Optimizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon
{
    public class Trainer
    {
        internal bool _kv_initialized;
        internal bool _update_on_kvstore;

        internal Parameter[] _params_to_init;

        public float learning_rate
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Optimizer optimizer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Trainer(ParameterDict @params, Optimizers.Optimizer optimizer, Dictionary<string, object> optimizer_params = null, string kvstore = "device",
                 Dictionary<string, object> compression_params = null, bool? update_on_kvstore = null)
        {
            throw new NotImplementedException();
        }

        internal Context[] CheckContexts() => throw new NotImplementedException();

        internal void InitOptimizer(Optimizer optimizer, Dictionary<string, object>  optimizer_params) => throw new NotImplementedException();

        internal void InitParams() => throw new NotImplementedException();

        internal void ResetKVstore() => throw new NotImplementedException();

        internal void InitKVstore() => throw new NotImplementedException();

        internal void RowSparsePull(Parameter parameter, NDArray[] @out, NDArray row_id, bool full_idx= false) => throw new NotImplementedException();

        internal void CheckAndRescaleGrad(float scale) => throw new NotImplementedException();

        public void Step(int batch_size, bool ignore_stale_grad= false) => throw new NotImplementedException();

        public void AllReduceGrads() => throw new NotImplementedException();

        public void AllreduceGrads() => throw new NotImplementedException();

        public void Update(int batch_size, bool ignore_stale_grad = false) => throw new NotImplementedException();

        public void SaveStates(string fname) => throw new NotImplementedException();

        public void LoadStates(string fname) => throw new NotImplementedException();
    }
}
