using MxNet.Numpy;
using MxNet.Sym.Numpy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Sym.Numpy
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

        public static _Symbol pooling(_Symbol data, int[] kernel, int[] stride = null, int[] pad = null, string pool_type = "max",
                                    string pooling_convention = "valid", bool global_pool = false, bool cudnn_off = false,
                                    int? p_value = null, int? count_include_pad = null, string layout = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol rnn(_Symbol data, _Symbol parameters, _Symbol state, _Symbol state_cell= null, _Symbol sequence_length= null, 
                                string mode= null, int? state_size= null, int? num_layers= null, bool bidirectional= false, 
                                bool state_outputs= false, float p= 0, bool use_sequence_length= false, int? projection_size= null,
                                double? lstm_state_clip_min= null, double? lstm_state_clip_max= null, double? lstm_state_clip_nan= null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol leaky_relu(_Symbol data, _Symbol gamma= null, string act_type= "leaky", float slope= 0.25f, float lower_bound= 0.125f, float upper_bound= 0.333999991f)
        {
            throw new NotImplementedException();
        }

        public static _Symbol multibox_detection(_Symbol cls_prob, _Symbol loc_pred, _Symbol anchor, bool clip= false,
                                                float threshold= 0.00999999978f, int background_id= 0, float nms_threshold= 0.5f, 
                                                bool force_suppress= false, float[] variances= null, int nms_topk= -1)
        {
            throw new NotImplementedException();
        }

        public static _Symbol multibox_prior(_Symbol data, float[] sizes = null, float[] ratios = null, bool clip = false, float[] steps = null, float[] offsets = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol multibox_target(_Symbol anchor, _Symbol label, _Symbol cls_pred, float overlap_threshold = 0.5f,
                                            float ignore_label = -1, float negative_mining_ratio = -1, float negative_mining_thresh = 0.5f,
                                            int minimum_negative_samples = 0, float[] variances = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol roi_pooling(_Symbol data, _Symbol rois, int[] pooled_size, float spatial_scale)
        {
            throw new NotImplementedException();
        }

        public static _Symbol smooth_l1(_Symbol data, float scalar)
        {
            throw new NotImplementedException();
        }

        public static _Symbol sigmoid(_Symbol data)
        {
            throw new NotImplementedException();
        }

        public static _Symbol softmax(_Symbol data, int axis = -1, _Symbol length = null, double? temperature = null, bool use_length = false, DType dtype = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol log_softmax(_Symbol data, int axis = -1, _Symbol length = null, double? temperature = null, bool use_length = false, DType dtype = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol topk(_Symbol data, int axis = -1, int k = -1, string ret_typ = "value", bool is_ascend = false, DType dtype = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol waitall()
        {
            throw new NotImplementedException();
        }

        public static SymbolDict load(string file)
        {
            throw new NotImplementedException();
        }

        public static void save(string file, _Symbol arr)
        {
            throw new NotImplementedException();
        }

        public static _Symbol one_hot(_Symbol data, long depth, double on_value = 1.0, double off_value = 0.0, DType dtype = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol pick(_Symbol data, _Symbol index, int axis= -1, string mode= "clip", bool keepdims= false)
        {
            throw new NotImplementedException();
        }

        public static _Symbol reshape_like(_Symbol lhs, _Symbol rhs, int? lhs_begin = null, int? lhs_end = null, int? rhs_begin = null, int? rhs_end = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol batch_flatten(_Symbol data)
        {
            throw new NotImplementedException();
        }

        public static _Symbol batch_dot(_Symbol lhs, _Symbol rhs, bool transpose_a = false, bool transpose_b = false, string forward_stype = null)
        {
            throw new NotImplementedException();
        }

        public static _Symbol gamma(_Symbol data)
        {
            throw new NotImplementedException();
        }

        public static _Symbol sequence_mask(_Symbol data, _Symbol sequence_length = null, bool use_sequence_length = false, float value = 0, int axis = 0)
        {
            throw new NotImplementedException();
        }
    }
}
