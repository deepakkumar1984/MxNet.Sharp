using System;
using System.Collections.Generic;
using System.Text;
using MxNet.ND.Numpy;
using MxNet.Sym.Numpy;

namespace MxNet
{
    public class F
    {
        public static NDArrayOrSymbol nan_to_num(NDArrayOrSymbol x, Boolean copy, Single nan, Single? posinf, Single? neginf)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.nan_to_num(x, copy, nan, posinf, neginf);
            }
            return sym_np_ops.nan_to_num(x, copy, nan, posinf, neginf);
        }
        public static NDArrayOrSymbol squeeze(NDArrayOrSymbol a, Int32? axis)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.squeeze(a, axis);
            }
            return sym_np_ops.squeeze(a, axis);
        }
        public static NDArrayOrSymbol isnan(NDArrayOrSymbol a, NDArrayOrSymbol @out = null)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.isnan(a, @out);
            }
            return sym_np_ops.isnan(a, @out);
        }
        public static NDArrayOrSymbol isinf(NDArrayOrSymbol a, NDArrayOrSymbol @out = null)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.isinf(a, @out);
            }
            return sym_np_ops.isinf(a, @out);
        }
        public static NDArrayOrSymbol isposinf(NDArrayOrSymbol a, NDArrayOrSymbol @out = null)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.isposinf(a, @out);
            }
            return sym_np_ops.isposinf(a, @out);
        }
        public static NDArrayOrSymbol isneginf(NDArrayOrSymbol a, NDArrayOrSymbol @out = null)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.isneginf(a, @out);
            }
            return sym_np_ops.isneginf(a, @out);
        }
        public static NDArrayOrSymbol isfinite(NDArrayOrSymbol a, NDArrayOrSymbol @out = null)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.isfinite(a, @out);
            }
            return sym_np_ops.isfinite(a, @out);
        }
        public static NDArrayOrSymbol where(NDArrayOrSymbol condition, NDArrayOrSymbol x, NDArrayOrSymbol y)
        {
            if (condition.IsNDArray)
            {
                return nd_np_ops.where(condition, x, y);
            }
            return sym_np_ops.where(condition, x, y);
        }
        public static NDArrayOrSymbol polyval(NDArrayOrSymbol p, NDArrayOrSymbol x)
        {
            if (p.IsNDArray)
            {
                return nd_np_ops.polyval(p, x);
            }
            return sym_np_ops.polyval(p, x);
        }
        public static NDArrayOrSymbol bincount(NDArrayOrSymbol x, NDArrayOrSymbol weights, Int32 minlength)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.bincount(x, weights, minlength);
            }
            return sym_np_ops.bincount(x, weights, minlength);
        }
        public static NDArrayOrSymbol pad(NDArrayOrSymbol x, Int32[] pad_width, String mode)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.pad(x, pad_width, mode);
            }
            return sym_np_ops.pad(x, pad_width, mode);
        }
        public static NDArrayOrSymbol prod(NDArrayOrSymbol a, Int32? axis, DType dtype, NDArrayOrSymbol @out, Boolean keepdims, Single? initial)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.prod(a, axis, dtype, @out, keepdims, initial);
            }
            return sym_np_ops.prod(a, axis, dtype, @out, keepdims, initial);
        }
        public static NDArrayOrSymbol dot(NDArrayOrSymbol a, NDArrayOrSymbol b, NDArrayOrSymbol @out = null)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.dot(a, b, @out);
            }
            return sym_np_ops.dot(a, b, @out);
        }
        public static NDArrayOrSymbol cumsum(NDArrayOrSymbol a, Int32? axis, DType dtype, NDArrayOrSymbol @out = null)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.cumsum(a, axis, dtype, @out);
            }
            return sym_np_ops.cumsum(a, axis, dtype, @out);
        }
        public static NDArrayOrSymbol reshape(NDArrayOrSymbol a, Shape newshape, Boolean reverse, String order)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.reshape(a, newshape, reverse, order);
            }
            return sym_np_ops.reshape(a, newshape, reverse, order);
        }
        public static NDArrayOrSymbol moveaxis(NDArrayOrSymbol a, Int32 source, Int32 destination)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.moveaxis(a, source, destination);
            }
            return sym_np_ops.moveaxis(a, source, destination);
        }
        public static NDArrayOrSymbol moveaxis(NDArrayOrSymbol a, Int32[] source, Int32[] destination)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.moveaxis(a, source, destination);
            }
            return sym_np_ops.moveaxis(a, source, destination);
        }
        public static NDArrayOrSymbol copy(NDArrayOrSymbol a)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.copy(a);
            }
            return sym_np_ops.copy(a);
        }
        public static NDArrayOrSymbol rollaxis(NDArrayOrSymbol a, Int32 axis, Int32 start)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.rollaxis(a, axis, start);
            }
            return sym_np_ops.rollaxis(a, axis, start);
        }
        public static NDArrayOrSymbol diag(NDArrayOrSymbol v, Int32 k)
        {
            if (v.IsNDArray)
            {
                return nd_np_ops.diag(v, k);
            }
            return sym_np_ops.diag(v, k);
        }
        public static NDArrayOrSymbol diagflat(NDArrayOrSymbol v, Int32 k)
        {
            if (v.IsNDArray)
            {
                return nd_np_ops.diagflat(v, k);
            }
            return sym_np_ops.diagflat(v, k);
        }
        public static NDArrayOrSymbol diagonal(NDArrayOrSymbol a, Int32 offset, Int32 axis1, Int32 axis2)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.diagonal(a, offset, axis1, axis2);
            }
            return sym_np_ops.diagonal(a, offset, axis1, axis2);
        }
        public static NDArrayOrSymbol sum(NDArrayOrSymbol a, Int32? axis, DType dtype, NDArrayOrSymbol @out, Boolean keepdims, Single? initial)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.sum(a, axis, dtype, @out, keepdims, initial);
            }
            return sym_np_ops.sum(a, axis, dtype, @out, keepdims, initial);
        }
        public static NDArrayOrSymbol relu(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.relu(data);
            }
            return Sym.Numpy.npx.relu(data);
        }
        public static NDArrayOrSymbol activation(NDArrayOrSymbol data, String act_type)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.activation(data, act_type);
            }
            return Sym.Numpy.npx.activation(data, act_type);
        }
        public static NDArrayOrSymbol batch_norm(NDArrayOrSymbol x, NDArrayOrSymbol gamma, NDArrayOrSymbol beta, NDArrayOrSymbol running_mean, NDArrayOrSymbol running_var, Single eps, Single momentum, Boolean fix_gamma, Boolean use_global_stats, Boolean output_mean_var, Int32 axis, Boolean cudnn_off, Single? min_calib_range, Single? max_calib_range)
        {
            if (x.IsNDArray)
            {
                return ND.Numpy.npx.batch_norm(x, gamma, beta, running_mean, running_var, eps, momentum, fix_gamma, use_global_stats, output_mean_var, axis, cudnn_off, min_calib_range, max_calib_range);
            }
            return Sym.Numpy.npx.batch_norm(x, gamma, beta, running_mean, running_var, eps, momentum, fix_gamma, use_global_stats, output_mean_var, axis, cudnn_off, min_calib_range, max_calib_range);
        }
        public static NDArrayOrSymbol convolution(NDArrayOrSymbol data, NDArrayOrSymbol weight, NDArrayOrSymbol bias, Int32[] kernel, Int32[] stride, Int32[] dilate, Int32[] pad, Int32 num_filter, Int32 num_group, Int32 workspace, Boolean no_bias, String cudnn_tune, Boolean cudnn_off, String layout)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.convolution(data, weight, bias, kernel, stride, dilate, pad, num_filter, num_group, workspace, no_bias, cudnn_tune, cudnn_off, layout);
            }
            return Sym.Numpy.npx.convolution(data, weight, bias, kernel, stride, dilate, pad, num_filter, num_group, workspace, no_bias, cudnn_tune, cudnn_off, layout);
        }
        public static NDArrayOrSymbol dropout(NDArrayOrSymbol data, Single p, String mode, Shape axes, Boolean cudnn_off)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.dropout(data, p, mode, axes, cudnn_off);
            }
            return Sym.Numpy.npx.dropout(data, p, mode, axes, cudnn_off);
        }
        public static NDArrayOrSymbol embedding(NDArrayOrSymbol data, NDArrayOrSymbol weight, Int32 input_dim, Int32 output_dim, DType dtype, Boolean sparse_grad)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.embedding(data, weight, input_dim, output_dim, dtype, sparse_grad);
            }
            return Sym.Numpy.npx.embedding(data, weight, input_dim, output_dim, dtype, sparse_grad);
        }
        public static NDArrayOrSymbol fully_connected(NDArrayOrSymbol x, NDArrayOrSymbol weight, NDArrayOrSymbol bias, Int32 num_hidden, Boolean no_bias, Boolean flatten)
        {
            if (x.IsNDArray)
            {
                return ND.Numpy.npx.fully_connected(x, weight, bias, num_hidden, no_bias, flatten);
            }
            return Sym.Numpy.npx.fully_connected(x, weight, bias, num_hidden, no_bias, flatten);
        }
        public static NDArrayOrSymbol layer_norm(NDArrayOrSymbol data, NDArrayOrSymbol gamma, NDArrayOrSymbol beta, Int32 axis, Single eps, Boolean output_mean_var)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.layer_norm(data, gamma, beta, axis, eps, output_mean_var);
            }
            return Sym.Numpy.npx.layer_norm(data, gamma, beta, axis, eps, output_mean_var);
        }
        public static NDArrayOrSymbol pooling(NDArrayOrSymbol data, Int32[] kernel, Int32[] stride, Int32[] pad, String pool_type, String pooling_convention, Boolean global_pool, Boolean cudnn_off, Int32? p_value, Int32? count_include_pad, String layout)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.pooling(data, kernel, stride, pad, pool_type, pooling_convention, global_pool, cudnn_off, p_value, count_include_pad, layout);
            }
            return Sym.Numpy.npx.pooling(data, kernel, stride, pad, pool_type, pooling_convention, global_pool, cudnn_off, p_value, count_include_pad, layout);
        }
        public static NDArrayOrSymbol rnn(NDArrayOrSymbol data, NDArrayOrSymbol parameters, NDArrayOrSymbol state, NDArrayOrSymbol state_cell, NDArrayOrSymbol sequence_length, String mode, Int32? state_size, Int32? num_layers, Boolean bidirectional, Boolean state_outputs, Single p, Boolean use_sequence_length, Int32? projection_size, Double? lstm_state_clip_min, Double? lstm_state_clip_max, Double? lstm_state_clip_nan)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.rnn(data, parameters, state, state_cell, sequence_length, mode, state_size, num_layers, bidirectional, state_outputs, p, use_sequence_length, projection_size, lstm_state_clip_min, lstm_state_clip_max, lstm_state_clip_nan);
            }
            return Sym.Numpy.npx.rnn(data, parameters, state, state_cell, sequence_length, mode, state_size, num_layers, bidirectional, state_outputs, p, use_sequence_length, projection_size, lstm_state_clip_min, lstm_state_clip_max, lstm_state_clip_nan);
        }
        public static NDArrayOrSymbol leaky_relu(NDArrayOrSymbol data, NDArrayOrSymbol gamma, String act_type, Single slope, Single lower_bound, Single upper_bound)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.leaky_relu(data, gamma, act_type, slope, lower_bound, upper_bound);
            }
            return Sym.Numpy.npx.leaky_relu(data, gamma, act_type, slope, lower_bound, upper_bound);
        }
        public static NDArrayOrSymbol multibox_detection(NDArrayOrSymbol cls_prob, NDArrayOrSymbol loc_pred, NDArrayOrSymbol anchor, Boolean clip, Single threshold, Int32 background_id, Single nms_threshold, Boolean force_suppress, Single[] variances, Int32 nms_topk)
        {
            if (cls_prob.IsNDArray)
            {
                return ND.Numpy.npx.multibox_detection(cls_prob, loc_pred, anchor, clip, threshold, background_id, nms_threshold, force_suppress, variances, nms_topk);
            }
            return Sym.Numpy.npx.multibox_detection(cls_prob, loc_pred, anchor, clip, threshold, background_id, nms_threshold, force_suppress, variances, nms_topk);
        }
        public static NDArrayOrSymbol multibox_prior(NDArrayOrSymbol data, Single[] sizes, Single[] ratios, Boolean clip, Single[] steps, Single[] offsets)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.multibox_prior(data, sizes, ratios, clip, steps, offsets);
            }
            return Sym.Numpy.npx.multibox_prior(data, sizes, ratios, clip, steps, offsets);
        }
        public static NDArrayOrSymbol multibox_target(NDArrayOrSymbol anchor, NDArrayOrSymbol label, NDArrayOrSymbol cls_pred, Single overlap_threshold, Single ignore_label, Single negative_mining_ratio, Single negative_mining_thresh, Int32 minimum_negative_samples, Single[] variances)
        {
            if (anchor.IsNDArray)
            {
                return ND.Numpy.npx.multibox_target(anchor, label, cls_pred, overlap_threshold, ignore_label, negative_mining_ratio, negative_mining_thresh, minimum_negative_samples, variances);
            }
            return Sym.Numpy.npx.multibox_target(anchor, label, cls_pred, overlap_threshold, ignore_label, negative_mining_ratio, negative_mining_thresh, minimum_negative_samples, variances);
        }
        public static NDArrayOrSymbol roi_pooling(NDArrayOrSymbol data, NDArrayOrSymbol rois, Int32[] pooled_size, Single spatial_scale)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.roi_pooling(data, rois, pooled_size, spatial_scale);
            }
            return Sym.Numpy.npx.roi_pooling(data, rois, pooled_size, spatial_scale);
        }
        public static NDArrayOrSymbol smooth_l1(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.smooth_l1(data, scalar);
            }
            return Sym.Numpy.npx.smooth_l1(data, scalar);
        }
        public static NDArrayOrSymbol sigmoid(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.sigmoid(data);
            }
            return Sym.Numpy.npx.sigmoid(data);
        }
        public static NDArrayOrSymbol softmax(NDArrayOrSymbol data, Int32 axis, NDArrayOrSymbol length, Double? temperature, Boolean use_length, DType dtype)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.softmax(data, axis, length, temperature, use_length, dtype);
            }
            return Sym.Numpy.npx.softmax(data, axis, length, temperature, use_length, dtype);
        }
        public static NDArrayOrSymbol log_softmax(NDArrayOrSymbol data, Int32 axis, NDArrayOrSymbol length, Double? temperature, Boolean use_length, DType dtype)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.log_softmax(data, axis, length, temperature, use_length, dtype);
            }
            return Sym.Numpy.npx.log_softmax(data, axis, length, temperature, use_length, dtype);
        }
        public static NDArrayOrSymbol topk(NDArrayOrSymbol data, Int32 axis, Int32 k, String ret_typ, Boolean is_ascend, DType dtype)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.topk(data, axis, k, ret_typ, is_ascend, dtype);
            }
            return Sym.Numpy.npx.topk(data, axis, k, ret_typ, is_ascend, dtype);
        }
        public static NDArrayOrSymbol one_hot(NDArrayOrSymbol data, Int64 depth, Double on_value, Double off_value, DType dtype)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.one_hot(data, depth, on_value, off_value, dtype);
            }
            return Sym.Numpy.npx.one_hot(data, depth, on_value, off_value, dtype);
        }
        public static NDArrayOrSymbol pick(NDArrayOrSymbol data, NDArrayOrSymbol index, Int32 axis, String mode, Boolean keepdims)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.pick(data, index, axis, mode, keepdims);
            }
            return Sym.Numpy.npx.pick(data, index, axis, mode, keepdims);
        }
        public static NDArrayOrSymbol reshape_like(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs, Int32? lhs_begin, Int32? lhs_end, Int32? rhs_begin, Int32? rhs_end)
        {
            if (lhs.IsNDArray)
            {
                return ND.Numpy.npx.reshape_like(lhs, rhs, lhs_begin, lhs_end, rhs_begin, rhs_end);
            }
            return Sym.Numpy.npx.reshape_like(lhs, rhs, lhs_begin, lhs_end, rhs_begin, rhs_end);
        }
        public static NDArrayOrSymbol batch_flatten(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.batch_flatten(data);
            }
            return Sym.Numpy.npx.batch_flatten(data);
        }
        public static NDArrayOrSymbol batch_dot(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs, Boolean transpose_a, Boolean transpose_b, String forward_stype)
        {
            if (lhs.IsNDArray)
            {
                return ND.Numpy.npx.batch_dot(lhs, rhs, transpose_a, transpose_b, forward_stype);
            }
            return Sym.Numpy.npx.batch_dot(lhs, rhs, transpose_a, transpose_b, forward_stype);
        }
        public static NDArrayOrSymbol gamma(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.gamma(data);
            }
            return Sym.Numpy.npx.gamma(data);
        }
        public static NDArrayOrSymbol sequence_mask(NDArrayOrSymbol data, NDArrayOrSymbol sequence_length, Boolean use_sequence_length, Single value, Int32 axis)
        {
            if (data.IsNDArray)
            {
                return ND.Numpy.npx.sequence_mask(data, sequence_length, use_sequence_length, value, axis);
            }
            return Sym.Numpy.npx.sequence_mask(data, sequence_length, use_sequence_length, value, axis);
        }
        public static NDArrayOrSymbolList array_split(NDArrayOrSymbol ary, Int32[] indices_or_sections, Int32 axis)
        {
            if (ary.IsNDArray)
            {
                return nd_np_ops.array_split(ary, indices_or_sections, axis);
            }

            return sym_np_ops.array_split(ary, indices_or_sections, axis);
        }
        public static NDArrayOrSymbol vsplit(NDArrayOrSymbol ary, Int32[] indices_or_sections)
        {
            if (ary.IsNDArray)
            {
                return nd_np_ops.vsplit(ary, indices_or_sections);
            }
            return sym_np_ops.vsplit(ary, indices_or_sections);
        }
        public static NDArrayOrSymbol dsplit(NDArrayOrSymbol ary, Int32[] indices_or_sections)
        {
            if (ary.IsNDArray)
            {
                return nd_np_ops.dsplit(ary, indices_or_sections);
            }
            return sym_np_ops.dsplit(ary, indices_or_sections);
        }
        public static NDArrayOrSymbol concatenate(NDArrayOrSymbolList seq, Int32 axis, NDArrayOrSymbol @out = null)
        {
            if (seq[0].IsNDArray)
{
                return nd_np_ops.concatenate(seq.NDArrays, axis, @out);
            }
            return sym_np_ops.concatenate(seq.Symbols, axis, @out);
        }
        public static NDArrayOrSymbol append(NDArrayOrSymbol arr, NDArrayOrSymbol values, Int32? axis)
        {
            if (arr.IsNDArray)
            {
                return nd_np_ops.append(arr, values, axis);
            }
            return sym_np_ops.append(arr, values, axis);
        }
        public static NDArrayOrSymbol stack(NDArrayOrSymbolList arrays, Int32 axis, NDArrayOrSymbol @out = null)
        {
            if (arrays[0].IsNDArray)
{
                return nd_np_ops.stack(arrays.NDArrays, axis, @out);
            }

            return sym_np_ops.stack(arrays.Symbols, axis, @out);
        }
        public static NDArrayOrSymbol vstack(NDArrayOrSymbolList arrays, NDArrayOrSymbol @out = null)
        {
            if (arrays[0].IsNDArray)
{
                return nd_np_ops.vstack(arrays.NDArrays, @out);
            }

            return sym_np_ops.vstack(arrays.Symbols, @out);
        }
        public static NDArrayOrSymbol maximum(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.maximum(x1, x2, @out);
            }
            return sym_np_ops.maximum(x1, x2, @out);
        }
        public static NDArrayOrSymbol fmax(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.fmax(x1, x2, @out);
            }
            return sym_np_ops.fmax(x1, x2, @out);
        }
        public static NDArrayOrSymbol minimum(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.minimum(x1, x2, @out);
            }
            return sym_np_ops.minimum(x1, x2, @out);
        }
        public static NDArrayOrSymbol fmin(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.fmin(x1, x2, @out);
            }
            return sym_np_ops.fmin(x1, x2, @out);
        }
        public static NDArrayOrSymbol max(NDArrayOrSymbol a, Int32? axis, NDArrayOrSymbol @out, Boolean keepdims)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.max(a, axis, @out, keepdims);
            }
            return sym_np_ops.max(a, axis, @out, keepdims);
        }
        public static NDArrayOrSymbol min(NDArrayOrSymbol a, Int32? axis, NDArrayOrSymbol @out, Boolean keepdims)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.min(a, axis, @out, keepdims);
            }
            return sym_np_ops.min(a, axis, @out, keepdims);
        }
        public static NDArrayOrSymbol swapaxes(NDArrayOrSymbol a, Int32 axis1, Int32 axis2)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.swapaxes(a, axis1, axis2);
            }
            return sym_np_ops.swapaxes(a, axis1, axis2);
        }
        public static NDArrayOrSymbol clip(NDArrayOrSymbol a, Single a_min, Single a_max, NDArrayOrSymbol @out = null)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.clip(a, a_min, a_max, @out);
            }
            return sym_np_ops.clip(a, a_min, a_max, @out);
        }
        public static NDArrayOrSymbol argmax(NDArrayOrSymbol a, Int32? axis, NDArrayOrSymbol @out = null)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.argmax(a, axis, @out);
            }
            return sym_np_ops.argmax(a, axis, @out);
        }
        public static NDArrayOrSymbol argmin(NDArrayOrSymbol a, Int32? axis, NDArrayOrSymbol @out = null)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.argmin(a, axis, @out);
            }
            return sym_np_ops.argmin(a, axis, @out);
        }
        public static NDArrayOrSymbol amax(NDArrayOrSymbol a, Int32? axis, NDArrayOrSymbol @out = null)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.amax(a, axis, @out);
            }
            return sym_np_ops.amax(a, axis, @out);
        }
        public static NDArrayOrSymbol amin(NDArrayOrSymbol a, Int32? axis, NDArrayOrSymbol @out = null)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.amin(a, axis, @out);
            }
            return sym_np_ops.amin(a, axis, @out);
        }
        public static NDArrayOrSymbol average(NDArrayOrSymbol a, Int32? axis, NDArrayOrSymbol weights, Boolean returned, NDArrayOrSymbol @out = null)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.average(a, axis, weights, returned, @out);
            }
            return sym_np_ops.average(a, axis, weights, returned, @out);
        }
        public static NDArrayOrSymbol mean(NDArrayOrSymbol a, Int32? axis, DType dtype, NDArrayOrSymbol @out, Boolean keepdims)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.mean(a, axis, dtype, @out, keepdims);
            }
            return sym_np_ops.mean(a, axis, dtype, @out, keepdims);
        }
        public static NDArrayOrSymbol std(NDArrayOrSymbol a, Int32? axis, DType dtype, NDArrayOrSymbol @out, Boolean keepdims)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.std(a, axis, dtype, @out, keepdims);
            }
            return sym_np_ops.std(a, axis, dtype, @out, keepdims);
        }
        public static NDArrayOrSymbol delete(NDArrayOrSymbol arr, Int32 obj, Int32? axis)
        {
            if (arr.IsNDArray)
            {
                return nd_np_ops.delete(arr, obj, axis);
            }
            return sym_np_ops.delete(arr, obj, axis);
        }
        public static NDArrayOrSymbol delete(NDArrayOrSymbol arr, Int32[] obj, Int32? axis)
        {
            if (arr.IsNDArray)
            {
                return nd_np_ops.delete(arr, obj, axis);
            }
            return sym_np_ops.delete(arr, obj, axis);
        }
        public static NDArrayOrSymbol delete(NDArrayOrSymbol arr, NDArrayOrSymbol obj, Int32? axis)
        {
            if (arr.IsNDArray)
            {
                return nd_np_ops.delete(arr, obj, axis);
            }
            return sym_np_ops.delete(arr, obj, axis);
        }
        public static NDArrayOrSymbol var(NDArrayOrSymbol a, Int32? axis, DType dtype, NDArrayOrSymbol @out, Boolean keepdims)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.var(a, axis, dtype, @out, keepdims);
            }
            return sym_np_ops.var(a, axis, dtype, @out, keepdims);
        }
        public static NDArrayOrSymbol copysign(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.copysign(x1, x2, @out);
            }
            return sym_np_ops.copysign(x1, x2, @out);
        }
        public static NDArrayOrSymbol ravel(NDArrayOrSymbol x, String order)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.ravel(x, order);
            }
            return sym_np_ops.ravel(x, order);
        }
        public static NDArrayOrSymbol unravel_index(NDArrayOrSymbol indices, Shape shape, String order)
        {
            if (indices.IsNDArray)
            {
                return nd_np_ops.unravel_index(indices, shape, order);
            }
            return sym_np_ops.unravel_index(indices, shape, order);
        }
        public static NDArrayOrSymbol flatnonzero(NDArrayOrSymbol x)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.flatnonzero(x);
            }
            return sym_np_ops.flatnonzero(x);
        }
        public static NDArrayOrSymbol diag_indices_from(NDArrayOrSymbol x)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.diag_indices_from(x);
            }
            return sym_np_ops.diag_indices_from(x);
        }
        public static NDArrayOrSymbol flip(NDArrayOrSymbol m, Int32? axis, NDArrayOrSymbol @out = null)
        {
            if (m.IsNDArray)
            {
                return nd_np_ops.flip(m, axis, @out);
            }
            return sym_np_ops.flip(m, axis, @out);
        }
        public static NDArrayOrSymbol flipud(NDArrayOrSymbol x)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.flipud(x);
            }
            return sym_np_ops.flipud(x);
        }
        public static NDArrayOrSymbol fliplr(NDArrayOrSymbol x)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.fliplr(x);
            }
            return sym_np_ops.fliplr(x);
        }
        public static NDArrayOrSymbol around(NDArrayOrSymbol x, Int32 decimals, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.around(x, decimals, @out);
            }
            return sym_np_ops.around(x, decimals, @out);
        }
        public static NDArrayOrSymbol round(NDArrayOrSymbol x, Int32 decimals, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.round(x, decimals, @out);
            }
            return sym_np_ops.round(x, decimals, @out);
        }
        public static NDArrayOrSymbol round_(NDArrayOrSymbol x, Int32 decimals, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.round_(x, decimals, @out);
            }
            return sym_np_ops.round_(x, decimals, @out);
        }
        public static NDArrayOrSymbol arctan2(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.arctan2(x1, x2, @out);
            }
            return sym_np_ops.arctan2(x1, x2, @out);
        }
        public static NDArrayOrSymbol hypot(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.hypot(x1, x2, @out);
            }
            return sym_np_ops.hypot(x1, x2, @out);
        }
        public static NDArrayOrSymbol bitwise_and(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.bitwise_and(x1, x2, @out);
            }
            return sym_np_ops.bitwise_and(x1, x2, @out);
        }
        public static NDArrayOrSymbol bitwise_xor(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.bitwise_xor(x1, x2, @out);
            }
            return sym_np_ops.bitwise_xor(x1, x2, @out);
        }
        public static NDArrayOrSymbol bitwise_or(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.bitwise_or(x1, x2, @out);
            }
            return sym_np_ops.bitwise_or(x1, x2, @out);
        }
        public static NDArrayOrSymbol ldexp(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.ldexp(x1, x2, @out);
            }
            return sym_np_ops.ldexp(x1, x2, @out);
        }
        public static NDArrayOrSymbol vdot(NDArrayOrSymbol a, NDArrayOrSymbol b)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.vdot(a, b);
            }
            return sym_np_ops.vdot(a, b);
        }
        public static NDArrayOrSymbol inner(NDArrayOrSymbol a, NDArrayOrSymbol b)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.inner(a, b);
            }
            return sym_np_ops.inner(a, b);
        }
        public static NDArrayOrSymbol @outer(NDArrayOrSymbol a, NDArrayOrSymbol b)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.outer(a, b);
            }
            return sym_np_ops.outer(a, b);
        }
        public static NDArrayOrSymbol cross(NDArrayOrSymbol a, NDArrayOrSymbol b, Int32 axisa, Int32 axisb, Int32 axisc, Int32? axis)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.cross(a, b, axisa, axisb, axisc, axis);
            }
            return sym_np_ops.cross(a, b, axisa, axisb, axisc, axis);
        }
        public static NDArrayOrSymbol kron(NDArrayOrSymbol a, NDArrayOrSymbol b)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.kron(a, b);
            }
            return sym_np_ops.kron(a, b);
        }
        public static NDArrayOrSymbol equal(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.equal(x1, x2, @out);
            }
            return sym_np_ops.equal(x1, x2, @out);
        }
        public static NDArrayOrSymbol not_equal(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.not_equal(x1, x2, @out);
            }
            return sym_np_ops.not_equal(x1, x2, @out);
        }
        public static NDArrayOrSymbol greater(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.greater(x1, x2, @out);
            }
            return sym_np_ops.greater(x1, x2, @out);
        }
        public static NDArrayOrSymbol less(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.less(x1, x2, @out);
            }
            return sym_np_ops.less(x1, x2, @out);
        }
        public static NDArrayOrSymbol logical_and(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.logical_and(x1, x2, @out);
            }

            return sym_np_ops.logical_and(x1, x2, @out);
        }
        public static NDArrayOrSymbol logical_or(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.logical_or(x1, x2, @out);
            }
            return sym_np_ops.logical_or(x1, x2, @out);
        }
        public static NDArrayOrSymbol logical_xor(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.logical_xor(x1, x2, @out);
            }
            return sym_np_ops.logical_xor(x1, x2, @out);
        }
        public static NDArrayOrSymbol greater_equal(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.greater_equal(x1, x2, @out);
            }
            return sym_np_ops.greater_equal(x1, x2, @out);
        }
        public static NDArrayOrSymbol less_equal(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.less_equal(x1, x2, @out);
            }
            return sym_np_ops.less_equal(x1, x2, @out);
        }
        public static NDArrayOrSymbol roll(NDArrayOrSymbol a, Int32 shift, Int32? axis)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.roll(a, shift, axis);
            }
            return sym_np_ops.roll(a, shift, axis);
        }
        public static NDArrayOrSymbol roll(NDArrayOrSymbol a, Int32[] shift, Int32? axis)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.roll(a, shift, axis);
            }
            return sym_np_ops.roll(a, shift, axis);
        }
        public static NDArrayOrSymbol rot90(NDArrayOrSymbol m, Int32 k, Int32[] axes)
        {
            if (m.IsNDArray)
            {
                return nd_np_ops.rot90(m, k, axes);
            }
            return sym_np_ops.rot90(m, k, axes);
        }
        public static NDArrayOrSymbol hsplit(NDArrayOrSymbol ary, Int32[] indices_or_sections)
        {
            if (ary.IsNDArray)
            {
                return nd_np_ops.hsplit(ary, indices_or_sections);
            }
            return sym_np_ops.hsplit(ary, indices_or_sections);
        }
        public static NDArrayOrSymbol insert(NDArrayOrSymbol arr, Int32 obj, NDArrayOrSymbol values, Int32? axis)
        {
            if (arr.IsNDArray)
            {
                return nd_np_ops.insert(arr, obj, values, axis);
            }
            return sym_np_ops.insert(arr, obj, values, axis);
        }
        public static NDArrayOrSymbol insert(NDArrayOrSymbol arr, NDArrayOrSymbol obj, NDArrayOrSymbol values, Int32? axis)
        {
            if (arr.IsNDArray)
            {
                return nd_np_ops.insert(arr, obj, values, axis);
            }
            return sym_np_ops.insert(arr, obj, values, axis);
        }
        public static NDArrayOrSymbol nonzero(NDArrayOrSymbol a)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.nonzero(a);
            }
            return sym_np_ops.nonzero(a);
        }
        public static NDArrayOrSymbol percentile(NDArrayOrSymbol a, NDArrayOrSymbol q, Int32? axis, NDArrayOrSymbol @out, Boolean? overwrite_input, String interpolation, Boolean keepdims)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.percentile(a, q, axis, @out, overwrite_input, interpolation, keepdims);
            }
            return sym_np_ops.percentile(a, q, axis, @out, overwrite_input, interpolation, keepdims);
        }
        public static NDArrayOrSymbol median(NDArrayOrSymbol a, Int32? axis, NDArrayOrSymbol @out, Boolean? overwrite_input, Boolean keepdims)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.median(a, axis, @out, overwrite_input, keepdims);
            }
            return sym_np_ops.median(a, axis, @out, overwrite_input, keepdims);
        }
        public static NDArrayOrSymbol quantile(NDArrayOrSymbol a, NDArrayOrSymbol q, Int32? axis, NDArrayOrSymbol @out, Boolean? overwrite_input, String interpolation, Boolean keepdims)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.quantile(a, q, axis, @out, overwrite_input, interpolation, keepdims);
            }
            return sym_np_ops.quantile(a, q, axis, @out, overwrite_input, interpolation, keepdims);
        }
        public static Boolean shares_memory(NDArrayOrSymbol a, NDArrayOrSymbol b, Int32? max_work)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.shares_memory(a, b, max_work);
            }
            return sym_np_ops.shares_memory(a, b, max_work);
        }
        public static Boolean may_share_memory(NDArrayOrSymbol a, NDArrayOrSymbol b, Int32? max_work)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.may_share_memory(a, b, max_work);
            }
            return sym_np_ops.may_share_memory(a, b, max_work);
        }
        public static NDArrayOrSymbol diff(NDArrayOrSymbol a, Int32 n, Int32 axis, NDArrayOrSymbol prepend, NDArrayOrSymbol append)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.diff(a, n, axis, prepend, append);
            }
            return sym_np_ops.diff(a, n, axis, prepend, append);
        }
        public static NDArrayOrSymbol ediff1d(NDArrayOrSymbol ary, NDArrayOrSymbol to_end, NDArrayOrSymbol to_begin)
        {
            if (ary.IsNDArray)
            {
                return nd_np_ops.ediff1d(ary, to_end, to_begin);
            }
            return sym_np_ops.ediff1d(ary, to_end, to_begin);
        }
        public static NDArrayOrSymbol resize(NDArrayOrSymbol a, Shape new_shape)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.resize(a, new_shape);
            }
            return sym_np_ops.resize(a, new_shape);
        }
        public static NDArrayOrSymbol interp(NDArrayOrSymbol x, Single[] xp, Single[] fp, Single? left, Single? right, Single? period)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.interp(x, xp, fp, left, right, period);
            }
            return sym_np_ops.interp(x, xp, fp, left, right, period);
        }
        public static NDArrayOrSymbol full_like(NDArrayOrSymbol a, Single fill_value, DType dtype, String order, Context ctx, NDArrayOrSymbol @out = null)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.full_like(a, fill_value, dtype, order, ctx, @out);
            }
            return sym_np_ops.full_like(a, fill_value, dtype, order, ctx, @out);
        }
        public static NDArrayOrSymbol zeros_like(NDArrayOrSymbol a, DType dtype, String order, Context ctx, NDArrayOrSymbol @out = null)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.zeros_like(a, dtype, order, ctx, @out);
            }
            return sym_np_ops.zeros_like(a, dtype, order, ctx, @out);
        }
        public static NDArrayOrSymbol ones_like(NDArrayOrSymbol a, DType dtype, String order, Context ctx, NDArrayOrSymbol @out = null)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.ones_like(a, dtype, order, ctx, @out);
            }
            return sym_np_ops.ones_like(a, dtype, order, ctx, @out);
        }
        public static NDArrayOrSymbol fill_diagonal(NDArrayOrSymbol a, Single val, Boolean wrap)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.fill_diagonal(a, val, wrap);
            }
            return sym_np_ops.fill_diagonal(a, val, wrap);
        }
        public static NDArrayOrSymbol broadcast_to(NDArrayOrSymbol array, Shape shape)
        {
            if (array.IsNDArray)
            {
                return nd_np_ops.broadcast_to(array, shape);
            }
            return sym_np_ops.broadcast_to(array, shape);
        }
        public static NDArrayOrSymbol full(Shape shape, Double fill_value, DType dtype, String order, Context ctx, NDArrayOrSymbol @out, Boolean is_symbol)
        {
            if (!is_symbol)
{
                return nd_np_ops.full(shape, fill_value, dtype, order, ctx, @out);
            }
            return sym_np_ops.full(shape, fill_value, dtype, order, ctx, @out);
        }

        public static NDArrayOrSymbol empty_like(NDArrayOrSymbol prototype, Double fill_value, DType dtype, String order, Boolean subok, Shape shape)
        {
            if (prototype.IsNDArray)
            {
                return nd_np_ops.empty_like(prototype, fill_value, dtype, order, subok, shape);
            }
            return sym_np_ops.empty_like(prototype, fill_value, dtype, order, subok, shape);
        }
        public static Boolean all(NDArrayOrSymbol a)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.all(a);
            }
            return sym_np_ops.all(a);
        }
        public static NDArrayOrSymbol all(NDArrayOrSymbol a, Int32 axis, NDArrayOrSymbol @out, Boolean keepdims)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.all(a, axis, @out, keepdims);
            }
            return sym_np_ops.all(a, axis, @out, keepdims);
        }
        public static Boolean any(NDArrayOrSymbol a)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.any(a);
            }
            return sym_np_ops.any(a);
        }
        public static NDArrayOrSymbol any(NDArrayOrSymbol a, Int32 axis, NDArrayOrSymbol @out, Boolean keepdims)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.any(a, axis, @out, keepdims);
            }
            return sym_np_ops.any(a, axis, @out, keepdims);
        }
        public static NDArrayOrSymbol take(NDArrayOrSymbol a, NDArrayOrSymbol indices, Int32? axis, String mode, NDArrayOrSymbol @out = null)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.take(a, indices, axis, mode, @out);
            }
            return sym_np_ops.take(a, indices, axis, mode, @out);
        }
        public static NDArrayOrSymbol unique(NDArrayOrSymbol ar, Int32? axis)
        {
            if (ar.IsNDArray)
            {
                return nd_np_ops.unique(ar, axis);
            }
            return sym_np_ops.unique(ar, axis);
        }
        public static (NDArrayOrSymbol, NDArrayOrSymbol, NDArrayOrSymbol, NDArrayOrSymbol) unique(NDArrayOrSymbol ar, Boolean return_index, Boolean return_inverse, Boolean return_counts, Int32? axis)
        {
            if (ar.IsNDArray)
            {
                var ret = nd_np_ops.unique(ar, return_index, return_inverse, return_counts, axis);
                return (new NDArrayOrSymbol(ret.Item1), new NDArrayOrSymbol(ret.Item2), new NDArrayOrSymbol(ret.Item3), new NDArrayOrSymbol(ret.Item4));
            }

            var ret1 = sym_np_ops.unique(ar, return_index, return_inverse, return_counts, axis);
            return (new NDArrayOrSymbol(ret1.Item1), new NDArrayOrSymbol(ret1.Item2), new NDArrayOrSymbol(ret1.Item3), new NDArrayOrSymbol(ret1.Item4));
        }
        public static NDArrayOrSymbol add(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.add(x1, x2, @out);
            }
            return sym_np_ops.add(x1, x2, @out);
        }
        public static NDArrayOrSymbol subtract(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.subtract(x1, x2, @out);
            }
            return sym_np_ops.subtract(x1, x2, @out);
        }
        public static NDArrayOrSymbol multiply(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.multiply(x1, x2, @out);
            }
            return sym_np_ops.multiply(x1, x2, @out);
        }
        public static NDArrayOrSymbol divide(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.divide(x1, x2, @out);
            }
            return sym_np_ops.divide(x1, x2, @out);
        }
        public static NDArrayOrSymbol true_divide(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.true_divide(x1, x2, @out);
            }
            return sym_np_ops.true_divide(x1, x2, @out);
        }
        public static NDArrayOrSymbol mod(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.mod(x1, x2, @out);
            }
            return sym_np_ops.mod(x1, x2, @out);
        }
        public static NDArrayOrSymbol fmod(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.fmod(x1, x2, @out);
            }
            return sym_np_ops.fmod(x1, x2, @out);
        }
        public static NDArrayOrSymbol matmul(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.matmul(x1, x2, @out);
            }
            return sym_np_ops.matmul(x1, x2, @out);
        }
        public static NDArrayOrSymbol remainder(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.remainder(x1, x2, @out);
            }
            return sym_np_ops.remainder(x1, x2, @out);
        }
        public static NDArrayOrSymbol power(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.power(x1, x2, @out);
            }
            return sym_np_ops.power(x1, x2, @out);
        }
        public static NDArrayOrSymbol gcd(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.gcd(x1, x2, @out);
            }
            return sym_np_ops.gcd(x1, x2, @out);
        }
        public static NDArrayOrSymbol lcm(NDArrayOrSymbol x1, NDArrayOrSymbol x2, NDArrayOrSymbol @out = null)
        {
            if (x1.IsNDArray)
            {
                return nd_np_ops.lcm(x1, x2, @out);
            }
            return sym_np_ops.lcm(x1, x2, @out);
        }
        public static NDArrayOrSymbol sin(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.sin(x, @out);
            }
            return sym_np_ops.sin(x, @out);
        }
        public static NDArrayOrSymbol cos(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.cos(x, @out);
            }
            return sym_np_ops.cos(x, @out);
        }
        public static NDArrayOrSymbol sinh(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.sinh(x, @out);
            }
            return sym_np_ops.sinh(x, @out);
        }
        public static NDArrayOrSymbol cosh(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.cosh(x, @out);
            }
            return sym_np_ops.cosh(x, @out);
        }
        public static NDArrayOrSymbol tanh(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.tanh(x, @out);
            }
            return sym_np_ops.tanh(x, @out);
        }
        public static NDArrayOrSymbol log10(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.log10(x, @out);
            }
            return sym_np_ops.log10(x, @out);
        }
        public static NDArrayOrSymbol sqrt(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.sqrt(x, @out);
            }
            return sym_np_ops.sqrt(x, @out);
        }
        public static NDArrayOrSymbol cbrt(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.cbrt(x, @out);
            }
            return sym_np_ops.cbrt(x, @out);
        }
        public static NDArrayOrSymbol abs(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.abs(x, @out);
            }
            return sym_np_ops.abs(x, @out);
        }
        public static NDArrayOrSymbol fabs(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.fabs(x, @out);
            }
            return sym_np_ops.fabs(x, @out);
        }
        public static NDArrayOrSymbol absolute(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.absolute(x, @out);
            }
            return sym_np_ops.absolute(x, @out);
        }
        public static NDArrayOrSymbol exp(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.exp(x, @out);
            }
            return sym_np_ops.exp(x, @out);
        }
        public static NDArrayOrSymbol expm1(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.expm1(x, @out);
            }
            return sym_np_ops.expm1(x, @out);
        }
        public static NDArrayOrSymbol arcsin(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.arcsin(x, @out);
            }
            return sym_np_ops.arcsin(x, @out);
        }
        public static NDArrayOrSymbol arccos(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.arccos(x, @out);
            }
            return sym_np_ops.arccos(x, @out);
        }
        public static NDArrayOrSymbol arctan(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.arctan(x, @out);
            }
            return sym_np_ops.arctan(x, @out);
        }
        public static NDArrayOrSymbol sign(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.sign(x, @out);
            }
            return sym_np_ops.sign(x, @out);
        }
        public static NDArrayOrSymbol log(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.log(x, @out);
            }
            return sym_np_ops.log(x, @out);
        }
        public static NDArrayOrSymbol rint(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.rint(x, @out);
            }
            return sym_np_ops.rint(x, @out);
        }
        public static NDArrayOrSymbol log2(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.log2(x, @out);
            }
            return sym_np_ops.log2(x, @out);
        }
        public static NDArrayOrSymbol log1p(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.log1p(x, @out);
            }
            return sym_np_ops.log1p(x, @out);
        }
        public static NDArrayOrSymbol degrees(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.degrees(x, @out);
            }
            return sym_np_ops.degrees(x, @out);
        }
        public static NDArrayOrSymbol rad2deg(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.rad2deg(x, @out);
            }
            return sym_np_ops.rad2deg(x, @out);
        }
        public static NDArrayOrSymbol radians(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.radians(x, @out);
            }
            return sym_np_ops.radians(x, @out);
        }
        public static NDArrayOrSymbol deg2rad(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.deg2rad(x, @out);
            }
            return sym_np_ops.deg2rad(x, @out);
        }
        public static NDArrayOrSymbol reciprocal(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.reciprocal(x, @out);
            }
            return sym_np_ops.reciprocal(x, @out);
        }
        public static NDArrayOrSymbol square(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.square(x, @out);
            }
            return sym_np_ops.square(x, @out);
        }
        public static NDArrayOrSymbol negative(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.negative(x, @out);
            }
            return sym_np_ops.negative(x, @out);
        }
        public static NDArrayOrSymbol fix(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.fix(x, @out);
            }
            return sym_np_ops.fix(x, @out);
        }
        public static NDArrayOrSymbol tan(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.tan(x, @out);
            }
            return sym_np_ops.tan(x, @out);
        }
        public static NDArrayOrSymbol ceil(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.ceil(x, @out);
            }
            return sym_np_ops.ceil(x, @out);
        }
        public static NDArrayOrSymbol floor(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.floor(x, @out);
            }
            return sym_np_ops.floor(x, @out);
        }
        public static NDArrayOrSymbol invert(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.invert(x, @out);
            }
            return sym_np_ops.invert(x, @out);
        }
        public static NDArrayOrSymbol bitwise_not(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.bitwise_not(x, @out);
            }
            return sym_np_ops.bitwise_not(x, @out);
        }
        public static NDArrayOrSymbol trunc(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.trunc(x, @out);
            }
            return sym_np_ops.trunc(x, @out);
        }
        public static NDArrayOrSymbol logical_not(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.logical_not(x, @out);
            }
            return sym_np_ops.logical_not(x, @out);
        }
        public static NDArrayOrSymbol arcsinh(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.arcsinh(x, @out);
            }
            return sym_np_ops.arcsinh(x, @out);
        }
        public static NDArrayOrSymbol arccosh(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.arccosh(x, @out);
            }
            return sym_np_ops.arccosh(x, @out);
        }
        public static NDArrayOrSymbol arctanh(NDArrayOrSymbol x, NDArrayOrSymbol @out = null)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.arctanh(x, @out);
            }
            return sym_np_ops.arctanh(x, @out);
        }
        public static NDArrayOrSymbol argsort(NDArrayOrSymbol x, Int32 axis, String kind, String order)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.argsort(x, axis, kind, order);
            }
            return sym_np_ops.argsort(x, axis, kind, order);
        }
        public static NDArrayOrSymbol sort(NDArrayOrSymbol x, Int32 axis, String kind, String order)
        {
            if (x.IsNDArray)
            {
                return nd_np_ops.sort(x, axis, kind, order);
            }
            return sym_np_ops.sort(x, axis, kind, order);
        }
        public static NDArrayOrSymbol tensordot(NDArrayOrSymbol a, NDArrayOrSymbol b, Int32 axes)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.tensordot(a, b, axes);
            }
            return sym_np_ops.tensordot(a, b, axes);
        }
        public static NDArrayOrSymbol histogram(NDArrayOrSymbol a, Int32 bins, (float, float)? range, Boolean? normed, NDArrayOrSymbol weights, Boolean? density)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.histogram(a, bins, range, normed, weights, density);
            }
            return sym_np_ops.histogram(a, bins, range, normed, weights, density);
        }
        public static NDArrayOrSymbol histogram(NDArrayOrSymbol a, NDArrayOrSymbol bins, (float, float)? range, Boolean? normed, NDArrayOrSymbol weights, Boolean? density)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.histogram(a, bins, range, normed, weights, density);
            }
            return sym_np_ops.histogram(a, bins, range, normed, weights, density);
        }
        public static NDArrayOrSymbol expand_dims(NDArrayOrSymbol a, Int32 axis)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.expand_dims(a, axis);
            }
            return sym_np_ops.expand_dims(a, axis);
        }
        public static NDArrayOrSymbol tile(NDArrayOrSymbol a, Int32[] reps)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.tile(a, reps);
            }
            return sym_np_ops.tile(a, reps);
        }
        public static NDArrayOrSymbol trace(NDArrayOrSymbol a, Int32 offset, Int32 axis1, Int32 axis2, NDArrayOrSymbol @out = null)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.trace(a, offset, axis1, axis2, @out);
            }
            return sym_np_ops.trace(a, offset, axis1, axis2, @out);
        }
        public static NDArrayOrSymbol transpose(NDArrayOrSymbol a, Int32[] axes)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.transpose(a, axes);
            }
            return sym_np_ops.transpose(a, axes);
        }
        public static NDArrayOrSymbol repeat(NDArrayOrSymbol a, Int32 repeats, Int32? axis)
        {
            if (a.IsNDArray)
            {
                return nd_np_ops.repeat(a, repeats, axis);
            }
            return sym_np_ops.repeat(a, repeats, axis);
        }
        public static NDArrayOrSymbol tril(NDArrayOrSymbol m, Int32 k)
        {
            if (m.IsNDArray)
            {
                return nd_np_ops.tril(m, k);
            }
            return sym_np_ops.tril(m, k);
        }
        public static NDArrayOrSymbol triu_indices_from(NDArrayOrSymbol NDArrayOrSymbol, Int32 k)
        {
            if (NDArrayOrSymbol.IsNDArray)
            {
                return nd_np_ops.triu_indices_from(NDArrayOrSymbol, k);
            }
            return sym_np_ops.triu_indices_from(NDArrayOrSymbol, k);
        }

        public static NDArrayOrSymbolList split(NDArrayOrSymbol ary, Int32[] indices_or_sections, Int32 axis)
        {
            if (ary.IsNDArray)
            {
                return nd_np_ops.split(ary, indices_or_sections, axis);
            }
            return sym_np_ops.split(ary, indices_or_sections, axis);
        }
    }
}
