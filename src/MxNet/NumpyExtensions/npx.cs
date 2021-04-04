using MxNet.Sym.Numpy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Numpy
{
    public partial class npx
    {
        public static void set_np(bool shape= true,bool array= true, bool dtype= false)
        {
            throw new NotImplementedException();
        }

        public static void reset_np()
        {
            throw new NotImplementedException();
        }

        public static Context cpu(int device_id)
        {
            throw new NotImplementedException();
        }

        public static Context cpu_pinned(int device_id)
        {
            throw new NotImplementedException();
        }

        public static Context gpu(int device_id)
        {
            throw new NotImplementedException();
        }

        public static (int, int) gpu_memory_info(int device_id)
        {
            throw new NotImplementedException();
        }

        public static Context current_context()
        {
            throw new NotImplementedException();
        }

        public static int num_gpus()
        {
            throw new NotImplementedException();
        }

        public static ndarray relu(ndarray data)
        {
            return activation(data);
        }

        public static ndarray activation(ndarray data, string act_type = "relu")
        {
            throw new NotImplementedException();
        }

        public static ndarray batch_norm(ndarray x, ndarray gamma, ndarray beta, ndarray running_mean, 
                                        ndarray running_var, float eps= 0.001f, float momentum= 0.9f, bool fix_gamma= true, 
                                        bool use_global_stats= false, bool output_mean_var= false, int axis= 1, bool cudnn_off= false,
                                        float? min_calib_range= null, float? max_calib_range= null)
        {
            throw new NotImplementedException();
        }

        public static ndarray convolution(ndarray data, ndarray weight, ndarray bias = null, int[] kernel= null, 
                                        int[] stride= null, int[] dilate= null, int[] pad= null, int num_filter= 1, int num_group= 1, 
                                        int workspace= 1024, bool no_bias= false, string cudnn_tune= null, bool cudnn_off= false, string layout= null)
        {
            throw new NotImplementedException();
        }

        public static ndarray dropout(ndarray data, float p= 0.5f, string mode= "training", Shape axes= null, bool cudnn_off= true)
        {
            throw new NotImplementedException();
        }

        public static ndarray embedding(ndarray data, ndarray weight, int input_dim, int output_dim, DType dtype= null, bool sparse_grad= false)
        {
            throw new NotImplementedException();
        }

        public static ndarray fully_connected(ndarray x, ndarray weight, ndarray bias, int num_hidden, bool no_bias= true, bool flatten= true)
        {
            throw new NotImplementedException();
        }

        public static ndarray layer_norm(ndarray data, ndarray gamma, ndarray beta, int axis= -1, float eps= 9.99999975e-06f, bool output_mean_var= false)
        {
            throw new NotImplementedException();
        }
    }
}
