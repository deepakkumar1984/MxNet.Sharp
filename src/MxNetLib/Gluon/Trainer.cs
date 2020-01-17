using MxNetLib.Optimizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNetLib.Gluon
{
    public class Trainer
    {
        public float learning_rate
        {
            get
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

        private Context[] _check_contexts() => throw new NotImplementedException();

        private void _init_optimizer(Optimizer optimizer, Dictionary<string, object>  optimizer_params) => throw new NotImplementedException();

        private void _init_params() => throw new NotImplementedException();

        private void _reset_kvstore() => throw new NotImplementedException();

        private void _init_kvstore() => throw new NotImplementedException();

        public void set_learning_rate(float lr) => throw new NotImplementedException();

        private void _row_sparse_pull(Parameter parameter, NDArray @out, int[] row_id, bool full_idx= false) => throw new NotImplementedException();

        private void _check_and_rescale_grad(float scale) => throw new NotImplementedException();

        public void Step(int batch_size, bool ignore_stale_grad= false) => throw new NotImplementedException();

        public void allreduce_grads() => throw new NotImplementedException();

        public void _allreduce_grads() => throw new NotImplementedException();

        public void Update(int batch_size, bool ignore_stale_grad = false) => throw new NotImplementedException();

        private void _Update(int batch_size, bool ignore_stale_grad = false) => throw new NotImplementedException();

        public void save_states(string fname) => throw new NotImplementedException();

        public void load_states(string fname) => throw new NotImplementedException();
    }
}
