using MxNet.Sym.Numpy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Numpy
{
    public partial class npx
    {

        public static _Symbol relu(_Symbol data)
        {
            return activation(data);
        }

        public static _Symbol activation(_Symbol data, string act_type = "relu")
        {
            throw new NotImplementedException();
        }

        public static _Symbol batch_norm(_Symbol x, _Symbol gamma, _Symbol beta, _Symbol running_mean, 
                                        _Symbol running_var, float eps= 0.001f, float momentum= 0.9f, bool fix_gamma= true, 
                                        bool use_global_stats= false, bool output_mean_var= false, int axis= 1, bool cudnn_off= false,
                                        float? min_calib_range= null, float? max_calib_range= null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol convolution(_Symbol data, _Symbol weight, _Symbol bias = null, int[] kernel= null, 
                                        int[] stride= null, int[] dilate= null, int[] pad= null, int num_filter= 1, int num_group= 1, 
                                        int workspace= 1024, bool no_bias= false, string cudnn_tune= null, bool cudnn_off= false, string layout= null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol dropout(_Symbol data, float p= 0.5f, string mode= "training", Shape axes= null, bool cudnn_off= true)
        {
            throw new NotImplementedException();
        }

        public static _Symbol embedding(_Symbol data, _Symbol weight, int input_dim, int output_dim, DType dtype= null, bool sparse_grad= false)
        {
            throw new NotImplementedException();
        }

        public static _Symbol fully_connected(_Symbol x, _Symbol weight, _Symbol bias, int num_hidden, bool no_bias= true, bool flatten= true)
        {
            throw new NotImplementedException();
        }

        public static _Symbol layer_norm(_Symbol data, _Symbol gamma, _Symbol beta, int axis= -1, float eps= 9.99999975e-06f, bool output_mean_var= false)
        {
            throw new NotImplementedException();
        }
    }
}
