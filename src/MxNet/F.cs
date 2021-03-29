using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet
{
    public class F
    {
        public static NDArrayOrSymbol DepthToSpace(NDArrayOrSymbol data, Int32 block_size)
        {
            if (data.IsNDArray)
            {
                return nd.DepthToSpace(data, block_size);
            }
            return sym.DepthToSpace(data, block_size);
        }
        public static NDArrayOrSymbol SpaceToDepth(NDArrayOrSymbol data, Int32 block_size)
        {
            if (data.IsNDArray)
            {
                return nd.SpaceToDepth(data, block_size);
            }
            return sym.SpaceToDepth(data, block_size);
        }
        public static NDArrayOrSymbolList SplitV2(NDArrayOrSymbol data, Shape indices, Int32 axis, Boolean squeeze_axis, Int32 sections)
        {
            if (data.IsNDArray)
            {
                return nd.SplitV2(data, indices, axis, squeeze_axis, sections);
            }
            return sym.SplitV2(data, indices, axis, squeeze_axis, sections).ToList();
        }
        public static NDArrayOrSymbolList Split(NDArrayOrSymbol data, Int32 num_outputs, Int32 axis, Boolean squeeze_axis)
        {
            if (data.IsNDArray)
            {
                return nd.Split(data, num_outputs, axis, squeeze_axis);
            }
            return sym.Split(data, num_outputs, axis, squeeze_axis).ToList();
        }
        public static NDArrayOrSymbol Topk(NDArrayOrSymbol data, Int32? axis, Int32 k, TopkRetTyp ret_typ, Boolean is_ascend, DType dtype)
        {
            if (data.IsNDArray)
            {
                return nd.Topk(data, axis, k, ret_typ, is_ascend, dtype);
            }
            return sym.Topk(data, axis, k, ret_typ, is_ascend, dtype);
        }
        public static NDArrayOrSymbol Sort(NDArrayOrSymbol data, Int32? axis, Boolean is_ascend)
        {
            if (data.IsNDArray)
            {
                return nd.Sort(data, axis, is_ascend);
            }
            return sym.Sort(data, axis, is_ascend);
        }
        public static NDArrayOrSymbol Argsort(NDArrayOrSymbol data, Int32? axis, Boolean is_ascend, DType dtype)
        {
            if (data.IsNDArray)
            {
                return nd.Argsort(data, axis, is_ascend, dtype);
            }
            return sym.Argsort(data, axis, is_ascend, dtype);
        }
        public static NDArrayOrSymbol RavelMultiIndex(NDArrayOrSymbol data, Shape shape)
        {
            if (data.IsNDArray)
            {
                return nd.RavelMultiIndex(data, shape);
            }
            return sym.RavelMultiIndex(data, shape);
        }
        public static NDArrayOrSymbol UnravelIndex(NDArrayOrSymbol data, Shape shape)
        {
            if (data.IsNDArray)
            {
                return nd.UnravelIndex(data, shape);
            }
            return sym.UnravelIndex(data, shape);
        }
        public static NDArrayOrSymbol SparseRetain(NDArrayOrSymbol data, NDArrayOrSymbol indices)
        {
            if (data.IsNDArray)
            {
                return nd.SparseRetain(data, indices);
            }
            return sym.SparseRetain(data, indices);
        }
        public static NDArrayOrSymbol SquareSum(NDArrayOrSymbol data, Shape axis, Boolean keepdims, Boolean exclude)
        {
            if (data.IsNDArray)
            {
                return nd.SquareSum(data, axis, keepdims, exclude);
            }
            return sym.SquareSum(data, axis, keepdims, exclude);
        }
        public static NDArrayOrSymbol BilinearSampler(NDArrayOrSymbol data, NDArrayOrSymbol grid, Boolean? cudnn_off)
        {
            if (data.IsNDArray)
            {
                return nd.BilinearSampler(data, grid, cudnn_off);
            }
            return sym.BilinearSampler(data, grid, cudnn_off);
        }
        public static NDArrayOrSymbol ConvolutionV1(NDArrayOrSymbol data, NDArrayOrSymbol weight, NDArrayOrSymbol bias, Shape kernel, UInt32 num_filter, Shape stride, Shape dilate, Shape pad, UInt32 num_group, UInt64 workspace, Boolean no_bias, ConvolutionV1CudnnTune? cudnn_tune, Boolean cudnn_off, ConvolutionV1Layout? layout)
        {
            if (data.IsNDArray)
            {
                return nd.ConvolutionV1(data, weight, bias, kernel, num_filter, stride, dilate, pad, num_group, workspace, no_bias, cudnn_tune, cudnn_off, layout);
            }
            return sym.ConvolutionV1(data, weight, bias, kernel, num_filter, stride, dilate, pad, num_group, workspace, no_bias, cudnn_tune, cudnn_off, layout);
        }
        public static NDArrayOrSymbol Correlation(NDArrayOrSymbol data1, NDArrayOrSymbol data2, UInt32 kernel_size, UInt32 max_displacement, UInt32 stride1, UInt32 stride2, UInt32 pad_size, Boolean is_multiply)
        {
            if (data1.IsNDArray)
            {
                return nd.Correlation(data1, data2, kernel_size, max_displacement, stride1, stride2, pad_size, is_multiply);
            }
            return sym.Correlation(data1, data2, kernel_size, max_displacement, stride1, stride2, pad_size, is_multiply);
        }
        public static NDArrayOrSymbol Crop(NDArrayOrSymbolList data, Int32 num_args, Shape offset, Shape h_w, Boolean center_crop)
        {
            if (data[0].IsNDArray)
            {
                return nd.Crop(data.NDArrays, num_args, offset, h_w, center_crop);
            }
            return sym.Crop(data.Symbols, num_args, offset, h_w, center_crop);
        }
        public static NDArrayOrSymbol Native(NDArrayOrSymbolList data, IntPtr info, Boolean need_top_grad)
        {
            if (data[0].IsNDArray)
            {
                return nd.Native(data.NDArrays, info, need_top_grad);
            }
            return sym.Native(data.Symbols, info, need_top_grad);
        }
        public static NDArrayOrSymbol GridGenerator(NDArrayOrSymbol data, GridgeneratorTransformType transform_type, Shape target_shape)
        {
            if (data.IsNDArray)
            {
                return nd.GridGenerator(data, transform_type, target_shape);
            }
            return sym.GridGenerator(data, transform_type, target_shape);
        }
        public static NDArrayOrSymbol InstanceNorm(NDArrayOrSymbol data, NDArrayOrSymbol gamma, NDArrayOrSymbol beta, Single eps)
        {
            if (data.IsNDArray)
            {
                return nd.InstanceNorm(data, gamma, beta, eps);
            }
            return sym.InstanceNorm(data, gamma, beta, eps);
        }
        public static NDArrayOrSymbol L2Normalization(NDArrayOrSymbol data, Single eps, L2normalizationMode mode)
        {
            if (data.IsNDArray)
            {
                return nd.L2Normalization(data, eps, mode);
            }
            return sym.L2Normalization(data, eps, mode);
        }
        public static NDArrayOrSymbol MakeLoss(NDArrayOrSymbol data, Single grad_scale, Single valid_thresh, MakelossNormalization normalization)
        {
            if (data.IsNDArray)
            {
                return nd.MakeLoss(data, grad_scale, valid_thresh, normalization);
            }
            return sym.MakeLoss(data, grad_scale, valid_thresh, normalization);
        }
        public static NDArrayOrSymbol PoolingV1(NDArrayOrSymbol data, Shape kernel, PoolingV1PoolType pool_type, Boolean global_pool, PoolingV1PoolingConvention pooling_convention, Shape stride, Shape pad)
        {
            if (data.IsNDArray)
            {
                return nd.PoolingV1(data, kernel, pool_type, global_pool, pooling_convention, stride, pad);
            }
            return sym.PoolingV1(data, kernel, pool_type, global_pool, pooling_convention, stride, pad);
        }
        public static NDArrayOrSymbol ROIPooling(NDArrayOrSymbol data, NDArrayOrSymbol rois, Shape pooled_size, Single spatial_scale)
        {
            if (data.IsNDArray)
            {
                return nd.ROIPooling(data, rois, pooled_size, spatial_scale);
            }
            return sym.ROIPooling(data, rois, pooled_size, spatial_scale);
        }
        public static NDArrayOrSymbol SequenceLast(NDArrayOrSymbol data, NDArrayOrSymbol sequence_length, Boolean use_sequence_length, Int32 axis)
        {
            if (data.IsNDArray)
            {
                return nd.SequenceLast(data, sequence_length, use_sequence_length, axis);
            }
            return sym.SequenceLast(data, sequence_length, use_sequence_length, axis);
        }
        public static NDArrayOrSymbol SequenceMask(NDArrayOrSymbol data, NDArrayOrSymbol sequence_length, Boolean use_sequence_length, Single value, Int32 axis)
        {
            if (data.IsNDArray)
            {
                return nd.SequenceMask(data, sequence_length, use_sequence_length, value, axis);
            }
            return sym.SequenceMask(data, sequence_length, use_sequence_length, value, axis);
        }
        public static NDArrayOrSymbol SequenceReverse(NDArrayOrSymbol data, NDArrayOrSymbol sequence_length, Boolean use_sequence_length, Int32 axis)
        {
            if (data.IsNDArray)
            {
                return nd.SequenceReverse(data, sequence_length, use_sequence_length, axis);
            }
            return sym.SequenceReverse(data, sequence_length, use_sequence_length, axis);
        }
        public static NDArrayOrSymbol SpatialTransformer(NDArrayOrSymbol data, NDArrayOrSymbol loc, SpatialtransformerTransformType transform_type, SpatialtransformerSamplerType sampler_type, Shape target_shape, Boolean? cudnn_off)
        {
            if (data.IsNDArray)
            {
                return nd.SpatialTransformer(data, loc, transform_type, sampler_type, target_shape, cudnn_off);
            }
            return sym.SpatialTransformer(data, loc, transform_type, sampler_type, target_shape, cudnn_off);
        }
        public static NDArrayOrSymbol SVMOutput(NDArrayOrSymbol data, NDArrayOrSymbol label, Single margin, Single regularization_coefficient, Boolean use_linear)
        {
            if (data.IsNDArray)
            {
                return nd.SVMOutput(data, label, margin, regularization_coefficient, use_linear);
            }
            return sym.SVMOutput(data, label, margin, regularization_coefficient, use_linear);
        }
        public static NDArrayOrSymbol OnehotEncode(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.OnehotEncode(lhs, rhs);
            }
            return sym.OnehotEncode(lhs, rhs);
        }
        public static NDArrayOrSymbol FillElement0Index(NDArrayOrSymbol lhs, NDArrayOrSymbol mhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.FillElement0Index(lhs, mhs, rhs);
            }
            return sym.FillElement0Index(lhs, mhs, rhs);
        }
        public static NDArrayOrSymbol Imdecode(NDArrayOrSymbol mean, Int32 index, Int32 x0, Int32 y0, Int32 x1, Int32 y1, Int32 c, Int32 size)
        {
            if (mean.IsNDArray)
            {
                return nd.Imdecode(mean, index, x0, y0, x1, y1, c, size);
            }
            return sym.Imdecode(mean, index, x0, y0, x1, y1, c, size);
        }
        public static NDArrayOrSymbol StopGradient(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.StopGradient(data);
            }
            return sym.StopGradient(data);
        }
        public static NDArrayOrSymbol GroupNorm(NDArrayOrSymbol data, NDArrayOrSymbol gamma, NDArrayOrSymbol beta, Single eps)
        {
            if (data.IsNDArray)
            {
                return nd.GroupNorm(data, gamma, beta, eps);
            }
            return sym.GroupNorm(data, gamma, beta, eps);
        }
       
        public static NDArrayOrSymbolList MultiSumSq(NDArrayOrSymbolList arrays, Int32 num_arrays)
        {
            if (arrays[0].IsNDArray)
            {
                return nd.MultiSumSq(arrays.NDArrays, num_arrays);
            }

            return sym.MultiSumSq(arrays.Symbols, num_arrays);
        }
      
        public static NDArrayOrSymbol ShapeArray(NDArrayOrSymbol data, Int32? lhs_begin, Int32? lhs_end, Int32? rhs_begin, Int32? rhs_end)
        {
            if (data.IsNDArray)
            {
                return nd.ShapeArray(data, lhs_begin, lhs_end, rhs_begin, rhs_end);
            }
            return sym.ShapeArray(data, lhs_begin, lhs_end, rhs_begin, rhs_end);
        }
        public static NDArrayOrSymbol SizeArray(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.SizeArray(data);
            }
            return sym.SizeArray(data);
        }
        public static NDArrayOrSymbol Cast(NDArrayOrSymbol data, DType dtype)
        {
            if (data.IsNDArray)
            {
                return nd.Cast(data, dtype);
            }
            return sym.Cast(data, dtype);
        }
        public static NDArrayOrSymbol Negative(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Negative(data);
            }
            return sym.Negative(data);
        }
        public static NDArrayOrSymbol Reciprocal(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Reciprocal(data);
            }
            return sym.Reciprocal(data);
        }
        public static NDArrayOrSymbol Abs(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Abs(data);
            }
            return sym.Abs(data);
        }
        public static NDArrayOrSymbol Sign(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Sign(data);
            }
            return sym.Sign(data);
        }
        public static NDArrayOrSymbol Round(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Round(data);
            }
            return sym.Round(data);
        }
        public static NDArrayOrSymbol Rint(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Rint(data);
            }
            return sym.Rint(data);
        }
        public static NDArrayOrSymbol Ceil(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Ceil(data);
            }
            return sym.Ceil(data);
        }
        public static NDArrayOrSymbol Floor(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Floor(data);
            }
            return sym.Floor(data);
        }
        public static NDArrayOrSymbol Trunc(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Trunc(data);
            }
            return sym.Trunc(data);
        }
        public static NDArrayOrSymbol Fix(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Fix(data);
            }
            return sym.Fix(data);
        }
        public static NDArrayOrSymbol Square(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Square(data);
            }
            return sym.Square(data);
        }
        public static NDArrayOrSymbol Sqrt(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Sqrt(data);
            }
            return sym.Sqrt(data);
        }
        public static NDArrayOrSymbol Rsqrt(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Rsqrt(data);
            }
            return sym.Rsqrt(data);
        }
        public static NDArrayOrSymbol Cbrt(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Cbrt(data);
            }
            return sym.Cbrt(data);
        }
        public static NDArrayOrSymbol Erf(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Erf(data);
            }
            return sym.Erf(data);
        }
        public static NDArrayOrSymbol Erfinv(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Erfinv(data);
            }
            return sym.Erfinv(data);
        }
        public static NDArrayOrSymbol Rcbrt(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Rcbrt(data);
            }
            return sym.Rcbrt(data);
        }
        public static NDArrayOrSymbol Exp(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Exp(data);
            }
            return sym.Exp(data);
        }
        public static NDArrayOrSymbol Log(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Log(data);
            }
            return sym.Log(data);
        }
        public static NDArrayOrSymbol Log10(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Log10(data);
            }
            return sym.Log10(data);
        }
        public static NDArrayOrSymbol Log2(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Log2(data);
            }
            return sym.Log2(data);
        }
        public static NDArrayOrSymbol Log1P(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Log1P(data);
            }
            return sym.Log1P(data);
        }
        public static NDArrayOrSymbol Expm1(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Expm1(data);
            }
            return sym.Expm1(data);
        }
        public static NDArrayOrSymbol Gamma(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Gamma(data);
            }
            return sym.Gamma(data);
        }
        public static NDArrayOrSymbol Gammaln(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Gammaln(data);
            }
            return sym.Gammaln(data);
        }
        public static NDArrayOrSymbol LogicalNot(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.LogicalNot(data);
            }
            return sym.LogicalNot(data);
        }
        public static NDArrayOrSymbol Sin(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Sin(data);
            }
            return sym.Sin(data);
        }
        public static NDArrayOrSymbol Cos(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Cos(data);
            }
            return sym.Cos(data);
        }
        public static NDArrayOrSymbol Tan(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Tan(data);
            }
            return sym.Tan(data);
        }
        public static NDArrayOrSymbol Arcsin(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Arcsin(data);
            }
            return sym.Arcsin(data);
        }
        public static NDArrayOrSymbol Arccos(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Arccos(data);
            }
            return sym.Arccos(data);
        }
        public static NDArrayOrSymbol Arctan(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Arctan(data);
            }
            return sym.Arctan(data);
        }
        public static NDArrayOrSymbol Degrees(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Degrees(data);
            }
            return sym.Degrees(data);
        }
        public static NDArrayOrSymbol Radians(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Radians(data);
            }
            return sym.Radians(data);
        }
        public static NDArrayOrSymbol Sinh(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Sinh(data);
            }
            return sym.Sinh(data);
        }
        public static NDArrayOrSymbol Cosh(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Cosh(data);
            }
            return sym.Cosh(data);
        }
        public static NDArrayOrSymbol Tanh(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Tanh(data);
            }
            return sym.Tanh(data);
        }
        public static NDArrayOrSymbol Arcsinh(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Arcsinh(data);
            }
            return sym.Arcsinh(data);
        }
        public static NDArrayOrSymbol Arccosh(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Arccosh(data);
            }
            return sym.Arccosh(data);
        }
        public static NDArrayOrSymbol Arctanh(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Arctanh(data);
            }
            return sym.Arctanh(data);
        }
        public static NDArrayOrSymbol Histogram(NDArrayOrSymbol data, NDArrayOrSymbol bins, Int32? bin_cnt, Tuple<Double> range)
        {
            if (data.IsNDArray)
            {
                return nd.Histogram(data, bins, bin_cnt, range);
            }
            return sym.Histogram(data, bins, bin_cnt, range);
        }
        public static NDArrayOrSymbol Embedding(NDArrayOrSymbol data, NDArrayOrSymbol weight, Int32 input_dim, Int32 output_dim, DType dtype, Boolean sparse_grad)
        {
            if (data.IsNDArray)
            {
                return nd.Embedding(data, weight, input_dim, output_dim, dtype, sparse_grad);
            }
            return sym.Embedding(data, weight, input_dim, output_dim, dtype, sparse_grad);
        }
        public static NDArrayOrSymbol Take(NDArrayOrSymbol a, NDArrayOrSymbol indices, Int32 axis, TakeMode mode)
        {
            if (a.IsNDArray)
            {
                return nd.Take(a, indices, axis, mode);
            }
            return sym.Take(a, indices, axis, mode);
        }
        public static NDArrayOrSymbol BatchTake(NDArrayOrSymbol a, NDArrayOrSymbol indices)
        {
            if (a.IsNDArray)
            {
                return nd.BatchTake(a, indices);
            }
            return sym.BatchTake(a, indices);
        }
        public static NDArrayOrSymbol OneHot(NDArrayOrSymbol indices, Int32 depth, Double on_value, Double off_value, DType dtype)
        {
            if (indices.IsNDArray)
            {
                return nd.OneHot(indices, depth, on_value, off_value, dtype);
            }
            return sym.OneHot(indices, depth, on_value, off_value, dtype);
        }
        public static NDArrayOrSymbol GatherNd(NDArrayOrSymbol data, NDArrayOrSymbol indices)
        {
            if (data.IsNDArray)
            {
                return nd.GatherNd(data, indices);
            }
            return sym.GatherNd(data, indices);
        }
        public static NDArrayOrSymbol ScatterNd(NDArrayOrSymbol data, NDArrayOrSymbol indices, Shape shape)
        {
            if (data.IsNDArray)
            {
                return nd.ScatterNd(data, indices, shape);
            }
            return sym.ScatterNd(data, indices, shape);
        }
        public static NDArrayOrSymbol ScatterSetNd(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs, NDArrayOrSymbol indices, Shape shape)
        {
            if (lhs.IsNDArray)
            {
                return nd.ScatterSetNd(lhs, rhs, indices, shape);
            }
            return sym.ScatterSetNd(lhs, rhs, indices, shape);
        }
        public static NDArrayOrSymbol ZerosLike(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.ZerosLike(data);
            }
            return sym.ZerosLike(data);
        }
        public static NDArrayOrSymbol OnesLike(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.OnesLike(data);
            }
            return sym.OnesLike(data);
        }
        public static NDArrayOrSymbol LinalgGemm(NDArrayOrSymbol A, NDArrayOrSymbol B, NDArrayOrSymbol C, Boolean transpose_a, Boolean transpose_b, Double alpha, Double beta, Int32 axis)
        {
            if (A.IsNDArray)
            {
                return nd.LinalgGemm(A, B, C, transpose_a, transpose_b, alpha, beta, axis);
            }
            return sym.LinalgGemm(A, B, C, transpose_a, transpose_b, alpha, beta, axis);
        }
        public static NDArrayOrSymbol LinalgGemm2(NDArrayOrSymbol A, NDArrayOrSymbol B, Boolean transpose_a, Boolean transpose_b, Double alpha, Int32 axis)
        {
            if (A.IsNDArray)
            {
                return nd.LinalgGemm2(A, B, transpose_a, transpose_b, alpha, axis);
            }
            return sym.LinalgGemm2(A, B, transpose_a, transpose_b, alpha, axis);
        }
        public static NDArrayOrSymbol LinalgPotrf(NDArrayOrSymbol A)
        {
            if (A.IsNDArray)
            {
                return nd.LinalgPotrf(A);
            }
            return sym.LinalgPotrf(A);
        }
        public static NDArrayOrSymbol LinalgPotri(NDArrayOrSymbol A)
        {
            if (A.IsNDArray)
            {
                return nd.LinalgPotri(A);
            }
            return sym.LinalgPotri(A);
        }
        public static NDArrayOrSymbol LinalgTrmm(NDArrayOrSymbol A, NDArrayOrSymbol B, Boolean transpose, Boolean rightside, Boolean lower, Double alpha)
        {
            if (A.IsNDArray)
            {
                return nd.LinalgTrmm(A, B, transpose, rightside, lower, alpha);
            }
            return sym.LinalgTrmm(A, B, transpose, rightside, lower, alpha);
        }
        public static NDArrayOrSymbol LinalgTrsm(NDArrayOrSymbol A, NDArrayOrSymbol B, Boolean transpose, Boolean rightside, Boolean lower, Double alpha)
        {
            if (A.IsNDArray)
            {
                return nd.LinalgTrsm(A, B, transpose, rightside, lower, alpha);
            }
            return sym.LinalgTrsm(A, B, transpose, rightside, lower, alpha);
        }
        public static NDArrayOrSymbol LinalgSumlogdiag(NDArrayOrSymbol A)
        {
            if (A.IsNDArray)
            {
                return nd.LinalgSumlogdiag(A);
            }
            return sym.LinalgSumlogdiag(A);
        }
        public static NDArrayOrSymbol LinalgSyrk(NDArrayOrSymbol A, Boolean transpose, Double alpha)
        {
            if (A.IsNDArray)
            {
                return nd.LinalgSyrk(A, transpose, alpha);
            }
            return sym.LinalgSyrk(A, transpose, alpha);
        }
        public static NDArrayOrSymbol LinalgGelqf(NDArrayOrSymbol A)
        {
            if (A.IsNDArray)
            {
                return nd.LinalgGelqf(A);
            }
            return sym.LinalgGelqf(A);
        }
        public static (NDArrayOrSymbol, NDArrayOrSymbol) LinalgSyevd(NDArrayOrSymbol A)
        {
            if (A.IsNDArray)
            {
                return nd.LinalgSyevd(A);
            }

            return sym.LinalgSyevd(A);
        }
        public static NDArrayOrSymbol Reshape(NDArrayOrSymbol data, Shape shape, Boolean reverse)
        {
            if (data.IsNDArray)
            {
                return nd.Reshape(data, shape, reverse);
            }
            return sym.Reshape(data, shape, reverse);
        }
        public static NDArrayOrSymbol Transpose(NDArrayOrSymbol data, Shape axes)
        {
            if (data.IsNDArray)
            {
                return nd.Transpose(data, axes);
            }
            return sym.Transpose(data, axes);
        }
        public static NDArrayOrSymbol ExpandDims(NDArrayOrSymbol data, Int32 axis)
        {
            if (data.IsNDArray)
            {
                return nd.ExpandDims(data, axis);
            }
            return sym.ExpandDims(data, axis);
        }
        public static NDArrayOrSymbol Slice(NDArrayOrSymbol data, Shape begin, Shape end, Shape step)
        {
            if (data.IsNDArray)
            {
                return nd.Slice(data, begin, end, step);
            }
            return sym.Slice(data, begin, end, step);
        }
        public static NDArrayOrSymbol SliceAssign(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs, Shape begin, Shape end, Shape step)
        {
            if (lhs.IsNDArray)
            {
                return nd.SliceAssign(lhs, rhs, begin, end, step);
            }
            return sym.SliceAssign(lhs, rhs, begin, end, step);
        }
        public static NDArrayOrSymbol SliceAssignScalar(NDArrayOrSymbol data, Shape begin, Shape end, Double scalar, Shape step)
        {
            if (data.IsNDArray)
            {
                return nd.SliceAssignScalar(data, begin, end, scalar, step);
            }
            return sym.SliceAssignScalar(data, begin, end, scalar, step);
        }
        public static NDArrayOrSymbol SliceAxis(NDArrayOrSymbol data, Int32 axis, Int32 begin, Int32? end)
        {
            if (data.IsNDArray)
            {
                return nd.SliceAxis(data, axis, begin, end);
            }
            return sym.SliceAxis(data, axis, begin, end);
        }
        public static NDArrayOrSymbol SliceLike(NDArrayOrSymbol data, NDArrayOrSymbol shape_like, Shape axes)
        {
            if (data.IsNDArray)
            {
                return nd.SliceLike(data, shape_like, axes);
            }
            return sym.SliceLike(data, shape_like, axes);
        }
        public static NDArrayOrSymbol Clip(NDArrayOrSymbol data, Single a_min, Single a_max)
        {
            if (data.IsNDArray)
            {
                return nd.Clip(data, a_min, a_max);
            }
            return sym.Clip(data, a_min, a_max);
        }
        public static NDArrayOrSymbol Repeat(NDArrayOrSymbol data, Int32 repeats, Int32? axis)
        {
            if (data.IsNDArray)
            {
                return nd.Repeat(data, repeats, axis);
            }
            return sym.Repeat(data, repeats, axis);
        }
        public static NDArrayOrSymbol Tile(NDArrayOrSymbol data, Shape reps)
        {
            if (data.IsNDArray)
            {
                return nd.Tile(data, reps);
            }
            return sym.Tile(data, reps);
        }
        public static NDArrayOrSymbol Reverse(NDArrayOrSymbol data, Shape axis)
        {
            if (data.IsNDArray)
            {
                return nd.Reverse(data, axis);
            }
            return sym.Reverse(data, axis);
        }
        public static NDArrayOrSymbol Flip(NDArrayOrSymbol data, Int32 axis)
        {
            if (data.IsNDArray)
            {
                return nd.Flip(data, axis);
            }
            return sym.Flip(data, axis);
        }
        public static NDArrayOrSymbol Stack(NDArrayOrSymbolList data, Int32 num_args, Int32 axis)
        {
            if (data[0].IsNDArray)
            {
                return nd.Stack(data.NDArrays, num_args, axis);
            }
            return sym.Stack(data.Symbols, num_args, axis);
        }
        public static NDArrayOrSymbol Squeeze(NDArrayOrSymbolList data, Shape axis)
        {
            if (data[0].IsNDArray)
            {
                return nd.Squeeze(data.NDArrays, axis);
            }
            return sym.Squeeze(data.Symbols, axis);
        }
        public static NDArrayOrSymbol Nanprod(NDArrayOrSymbol data, Shape axis, Boolean keepdims, Boolean exclude)
        {
            if (data.IsNDArray)
            {
                return nd.Nanprod(data, axis, keepdims, exclude);
            }
            return sym.Nanprod(data, axis, keepdims, exclude);
        }
        public static NDArrayOrSymbol Max(NDArrayOrSymbol data, Shape axis, Boolean keepdims, Boolean exclude)
        {
            if (data.IsNDArray)
            {
                return nd.Max(data, axis, keepdims, exclude);
            }
            return sym.Max(data, axis, keepdims, exclude);
        }
        public static NDArrayOrSymbol Min(NDArrayOrSymbol data, Shape axis, Boolean keepdims, Boolean exclude)
        {
            if (data.IsNDArray)
            {
                return nd.Min(data, axis, keepdims, exclude);
            }
            return sym.Min(data, axis, keepdims, exclude);
        }
        public static NDArrayOrSymbol BroadcastAxis(NDArrayOrSymbol data, Shape axis, Shape size)
        {
            if (data.IsNDArray)
            {
                return nd.BroadcastAxis(data, axis, size);
            }
            return sym.BroadcastAxis(data, axis, size);
        }
        public static NDArrayOrSymbol BroadcastTo(NDArrayOrSymbol data, Shape shape)
        {
            if (data.IsNDArray)
            {
                return nd.BroadcastTo(data, shape);
            }
            return sym.BroadcastTo(data, shape);
        }
        public static NDArrayOrSymbol BroadcastLike(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs, Shape lhs_axes, Shape rhs_axes)
        {
            if (lhs.IsNDArray)
            {
                return nd.BroadcastLike(lhs, rhs, lhs_axes, rhs_axes);
            }
            return sym.BroadcastLike(lhs, rhs, lhs_axes, rhs_axes);
        }
        public static NDArrayOrSymbol Norm(NDArrayOrSymbol data, Int32 ord, Shape axis, NormOutDtype? out_dtype, Boolean keepdims)
        {
            if (data.IsNDArray)
            {
                return nd.Norm(data, ord, axis, out_dtype, keepdims);
            }
            return sym.Norm(data, ord, axis, out_dtype, keepdims);
        }
        public static NDArrayOrSymbol CastStorage(NDArrayOrSymbol data, StorageStype stype)
        {
            if (data.IsNDArray)
            {
                return nd.CastStorage(data, stype);
            }
            return sym.CastStorage(data, stype);
        }
        public static NDArrayOrSymbol Where(NDArrayOrSymbol condition, NDArrayOrSymbol x, NDArrayOrSymbol y)
        {
            if (condition.IsNDArray)
            {
                return nd.Where(condition, x, y);
            }
            return sym.Where(condition, x, y);
        }
        public static NDArrayOrSymbol Diag(NDArrayOrSymbol data, Int32 k, Int32 axis1, Int32 axis2)
        {
            if (data.IsNDArray)
            {
                return nd.Diag(data, k, axis1, axis2);
            }
            return sym.Diag(data, k, axis1, axis2);
        }
        public static NDArrayOrSymbol Dot(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs, Boolean transpose_a, Boolean transpose_b, DotForwardStype? forward_stype)
        {
            if (lhs.IsNDArray)
            {
                return nd.Dot(lhs, rhs, transpose_a, transpose_b, forward_stype);
            }
            return sym.Dot(lhs, rhs, transpose_a, transpose_b, forward_stype);
        }
        public static NDArrayOrSymbol BatchDot(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs, Boolean transpose_a, Boolean transpose_b, BatchDotForwardStype? forward_stype)
        {
            if (lhs.IsNDArray)
            {
                return nd.BatchDot(lhs, rhs, transpose_a, transpose_b, forward_stype);
            }
            return sym.BatchDot(lhs, rhs, transpose_a, transpose_b, forward_stype);
        }
        public static NDArrayOrSymbol BroadcastAdd(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.BroadcastAdd(lhs, rhs);
            }
            return sym.BroadcastAdd(lhs, rhs);
        }
        public static NDArrayOrSymbol BroadcastSub(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.BroadcastSub(lhs, rhs);
            }
            return sym.BroadcastSub(lhs, rhs);
        }
        public static NDArrayOrSymbol BroadcastMul(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.BroadcastMul(lhs, rhs);
            }
            return sym.BroadcastMul(lhs, rhs);
        }
        public static NDArrayOrSymbol BroadcastDiv(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.BroadcastDiv(lhs, rhs);
            }
            return sym.BroadcastDiv(lhs, rhs);
        }
        public static NDArrayOrSymbol BroadcastMod(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.BroadcastMod(lhs, rhs);
            }
            return sym.BroadcastMod(lhs, rhs);
        }
        public static NDArrayOrSymbol BroadcastPower(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.BroadcastPower(lhs, rhs);
            }
            return sym.BroadcastPower(lhs, rhs);
        }
        public static NDArrayOrSymbol BroadcastMaximum(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.BroadcastMaximum(lhs, rhs);
            }
            return sym.BroadcastMaximum(lhs, rhs);
        }
        public static NDArrayOrSymbol BroadcastMinimum(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.BroadcastMinimum(lhs, rhs);
            }
            return sym.BroadcastMinimum(lhs, rhs);
        }
        public static NDArrayOrSymbol BroadcastHypot(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.BroadcastHypot(lhs, rhs);
            }
            return sym.BroadcastHypot(lhs, rhs);
        }
        public static NDArrayOrSymbol BroadcastEqual(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.BroadcastEqual(lhs, rhs);
            }
            return sym.BroadcastEqual(lhs, rhs);
        }
        public static NDArrayOrSymbol BroadcastNotEqual(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.BroadcastNotEqual(lhs, rhs);
            }
            return sym.BroadcastNotEqual(lhs, rhs);
        }
        public static NDArrayOrSymbol BroadcastGreater(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.BroadcastGreater(lhs, rhs);
            }
            return sym.BroadcastGreater(lhs, rhs);
        }
        public static NDArrayOrSymbol BroadcastGreaterEqual(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.BroadcastGreaterEqual(lhs, rhs);
            }
            return sym.BroadcastGreaterEqual(lhs, rhs);
        }
        public static NDArrayOrSymbol BroadcastLesser(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.BroadcastLesser(lhs, rhs);
            }
            return sym.BroadcastLesser(lhs, rhs);
        }
        public static NDArrayOrSymbol BroadcastLesserEqual(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.BroadcastLesserEqual(lhs, rhs);
            }
            return sym.BroadcastLesserEqual(lhs, rhs);
        }
        public static NDArrayOrSymbol BroadcastLogicalAnd(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.BroadcastLogicalAnd(lhs, rhs);
            }
            return sym.BroadcastLogicalAnd(lhs, rhs);
        }
        public static NDArrayOrSymbol BroadcastLogicalOr(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.BroadcastLogicalOr(lhs, rhs);
            }
            return sym.BroadcastLogicalOr(lhs, rhs);
        }
        public static NDArrayOrSymbol BroadcastLogicalXor(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.BroadcastLogicalXor(lhs, rhs);
            }
            return sym.BroadcastLogicalXor(lhs, rhs);
        }
        public static NDArrayOrSymbol ElemwiseAdd(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.ElemwiseAdd(lhs, rhs);
            }
            return sym.ElemwiseAdd(lhs, rhs);
        }
        public static NDArrayOrSymbol GradAdd(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.GradAdd(lhs, rhs);
            }
            return sym.GradAdd(lhs, rhs);
        }
        public static NDArrayOrSymbol ElemwiseSub(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.ElemwiseSub(lhs, rhs);
            }
            return sym.ElemwiseSub(lhs, rhs);
        }
        public static NDArrayOrSymbol ElemwiseMul(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.ElemwiseMul(lhs, rhs);
            }
            return sym.ElemwiseMul(lhs, rhs);
        }
        public static NDArrayOrSymbol ElemwiseDiv(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.ElemwiseDiv(lhs, rhs);
            }
            return sym.ElemwiseDiv(lhs, rhs);
        }
        public static NDArrayOrSymbol Mod(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.Mod(lhs, rhs);
            }
            return sym.Mod(lhs, rhs);
        }
        public static NDArrayOrSymbol Power(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.Power(lhs, rhs);
            }
            return sym.Power(lhs, rhs);
        }
        public static NDArrayOrSymbol Maximum(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.Maximum(lhs, rhs);
            }
            return sym.Maximum(lhs, rhs);
        }
        public static NDArrayOrSymbol Minimum(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.Minimum(lhs, rhs);
            }
            return sym.Minimum(lhs, rhs);
        }
        public static NDArrayOrSymbol Hypot(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.Hypot(lhs, rhs);
            }
            return sym.Hypot(lhs, rhs);
        }
        public static NDArrayOrSymbol Equal(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.Equal(lhs, rhs);
            }
            return sym.Equal(lhs, rhs);
        }
        public static NDArrayOrSymbol NotEqual(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.NotEqual(lhs, rhs);
            }
            return sym.NotEqual(lhs, rhs);
        }
        public static NDArrayOrSymbol Greater(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.Greater(lhs, rhs);
            }
            return sym.Greater(lhs, rhs);
        }
        public static NDArrayOrSymbol GreaterEqual(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.GreaterEqual(lhs, rhs);
            }
            return sym.GreaterEqual(lhs, rhs);
        }
        public static NDArrayOrSymbol Lesser(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.Lesser(lhs, rhs);
            }
            return sym.Lesser(lhs, rhs);
        }
        public static NDArrayOrSymbol LesserEqual(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.LesserEqual(lhs, rhs);
            }
            return sym.LesserEqual(lhs, rhs);
        }
        public static NDArrayOrSymbol LogicalAnd(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.LogicalAnd(lhs, rhs);
            }
            return sym.LogicalAnd(lhs, rhs);
        }
        public static NDArrayOrSymbol LogicalOr(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.LogicalOr(lhs, rhs);
            }
            return sym.LogicalOr(lhs, rhs);
        }
        public static NDArrayOrSymbol LogicalXor(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.LogicalXor(lhs, rhs);
            }
            return sym.LogicalXor(lhs, rhs);
        }
        public static NDArrayOrSymbol PlusScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.PlusScalar(data, scalar);
            }
            return sym.PlusScalar(data, scalar);
        }
        public static NDArrayOrSymbol MinusScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.MinusScalar(data, scalar);
            }
            return sym.MinusScalar(data, scalar);
        }
        public static NDArrayOrSymbol RminusScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.RminusScalar(data, scalar);
            }
            return sym.RminusScalar(data, scalar);
        }
        public static NDArrayOrSymbol MulScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.MulScalar(data, scalar);
            }
            return sym.MulScalar(data, scalar);
        }
        public static NDArrayOrSymbol DivScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.DivScalar(data, scalar);
            }
            return sym.DivScalar(data, scalar);
        }
        public static NDArrayOrSymbol RdivScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.RdivScalar(data, scalar);
            }
            return sym.RdivScalar(data, scalar);
        }
        public static NDArrayOrSymbol ModScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.ModScalar(data, scalar);
            }
            return sym.ModScalar(data, scalar);
        }
        public static NDArrayOrSymbol RmodScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.RmodScalar(data, scalar);
            }
            return sym.RmodScalar(data, scalar);
        }
        public static NDArrayOrSymbol MaximumScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.MaximumScalar(data, scalar);
            }
            return sym.MaximumScalar(data, scalar);
        }
        public static NDArrayOrSymbol MinimumScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.MinimumScalar(data, scalar);
            }
            return sym.MinimumScalar(data, scalar);
        }
        public static NDArrayOrSymbol PowerScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.PowerScalar(data, scalar);
            }
            return sym.PowerScalar(data, scalar);
        }
        public static NDArrayOrSymbol RpowerScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.RpowerScalar(data, scalar);
            }
            return sym.RpowerScalar(data, scalar);
        }
        public static NDArrayOrSymbol HypotScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.HypotScalar(data, scalar);
            }
            return sym.HypotScalar(data, scalar);
        }
        public static NDArrayOrSymbol SmoothL1(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.SmoothL1(data, scalar);
            }
            return sym.SmoothL1(data, scalar);
        }
        public static NDArrayOrSymbol EqualScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.EqualScalar(data, scalar);
            }
            return sym.EqualScalar(data, scalar);
        }
        public static NDArrayOrSymbol NotEqualScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.NotEqualScalar(data, scalar);
            }
            return sym.NotEqualScalar(data, scalar);
        }
        public static NDArrayOrSymbol GreaterScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.GreaterScalar(data, scalar);
            }
            return sym.GreaterScalar(data, scalar);
        }
        public static NDArrayOrSymbol GreaterEqualScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.GreaterEqualScalar(data, scalar);
            }
            return sym.GreaterEqualScalar(data, scalar);
        }
        public static NDArrayOrSymbol LesserScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.LesserScalar(data, scalar);
            }
            return sym.LesserScalar(data, scalar);
        }
        public static NDArrayOrSymbol LesserEqualScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.LesserEqualScalar(data, scalar);
            }
            return sym.LesserEqualScalar(data, scalar);
        }
        public static NDArrayOrSymbol LogicalAndScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.LogicalAndScalar(data, scalar);
            }
            return sym.LogicalAndScalar(data, scalar);
        }
        public static NDArrayOrSymbol LogicalOrScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.LogicalOrScalar(data, scalar);
            }
            return sym.LogicalOrScalar(data, scalar);
        }
        public static NDArrayOrSymbol LogicalXorScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.LogicalXorScalar(data, scalar);
            }
            return sym.LogicalXorScalar(data, scalar);
        }
        public static NDArrayOrSymbol ScatterElemwiseDiv(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.ScatterElemwiseDiv(lhs, rhs);
            }
            return sym.ScatterElemwiseDiv(lhs, rhs);
        }
        public static NDArrayOrSymbol ScatterPlusScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.ScatterPlusScalar(data, scalar);
            }
            return sym.ScatterPlusScalar(data, scalar);
        }
        public static NDArrayOrSymbol ScatterMinusScalar(NDArrayOrSymbol data, Single scalar)
        {
            if (data.IsNDArray)
            {
                return nd.ScatterMinusScalar(data, scalar);
            }
            return sym.ScatterMinusScalar(data, scalar);
        }
        public static NDArrayOrSymbol AddN(NDArrayOrSymbolList args)
        {
            if (args[0].IsNDArray)
            {
                return nd.AddN(args.NDArrays);
            }
            return sym.AddN(args.Symbols);
        }
        public static NDArrayOrSymbol Relu(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Relu(data);
            }
            return sym.Relu(data);
        }
        public static NDArrayOrSymbol Sigmoid(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Sigmoid(data);
            }
            return sym.Sigmoid(data);
        }
        public static NDArrayOrSymbol HardSigmoid(NDArrayOrSymbol data, Single alpha, Single beta)
        {
            if (data.IsNDArray)
            {
                return nd.HardSigmoid(data, alpha, beta);
            }
            return sym.HardSigmoid(data, alpha, beta);
        }
        public static NDArrayOrSymbol Softsign(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Softsign(data);
            }
            return sym.Softsign(data);
        }
        public static NDArrayOrSymbol Copy(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Copy(data);
            }
            return sym.Copy(data);
        }
        public static NDArrayOrSymbol BlockGrad(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.BlockGrad(data);
            }
            return sym.BlockGrad(data);
        }
        
        public static NDArrayOrSymbol IdentityWithAttrLikeRhs(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.IdentityWithAttrLikeRhs(lhs, rhs);
            }
            return sym.IdentityWithAttrLikeRhs(lhs, rhs);
        }
        public static NDArrayOrSymbol ReshapeLike(NDArrayOrSymbol lhs, NDArrayOrSymbol rhs)
        {
            if (lhs.IsNDArray)
            {
                return nd.ReshapeLike(lhs, rhs);
            }
            return sym.ReshapeLike(lhs, rhs);
        }
        public static NDArrayOrSymbol CachedOp(NDArrayOrSymbolList data)
        {
            if (data[0].IsNDArray)
            {
                return nd.CachedOp(data.NDArrays);
            }
            return sym.CachedOp(data.Symbols);
        }
        public static NDArrayOrSymbol Cvimresize(NDArrayOrSymbol data, Int32 w, Int32 h, Int32 interp)
        {
            if (data.IsNDArray)
            {
                return nd.Cvimresize(data, w, h, interp);
            }
            return sym.Cvimresize(data, w, h, interp);
        }
        public static NDArrayOrSymbol CvcopyMakeBorder(NDArrayOrSymbol data, Int32 top, Int32 bot, Int32 left, Int32 right, Int32 type, Tuple<Double> values)
        {
            if (data.IsNDArray)
            {
                return nd.CvcopyMakeBorder(data, top, bot, left, right, type, values);
            }
            return sym.CvcopyMakeBorder(data, top, bot, left, right, type, values);
        }
        public static NDArrayOrSymbol BatchNormV1(NDArrayOrSymbol data, NDArrayOrSymbol gamma, NDArrayOrSymbol beta, Single eps, Single momentum, Boolean fix_gamma, Boolean use_global_stats, Boolean output_mean_var)
        {
            if (data.IsNDArray)
            {
                return nd.BatchNormV1(data, gamma, beta, eps, momentum, fix_gamma, use_global_stats, output_mean_var);
            }
            return sym.BatchNormV1(data, gamma, beta, eps, momentum, fix_gamma, use_global_stats, output_mean_var);
        }
        public static NDArrayOrSymbol MpAdamWUpdate(NDArrayOrSymbol weight, NDArrayOrSymbol grad, NDArrayOrSymbol mean, NDArrayOrSymbol var, NDArrayOrSymbol weight32, NDArrayOrSymbol rescale_grad, Single lr, Single eta, Single beta1, Single beta2, Single epsilon, Single wd, Single clip_gradient)
        {
            if (weight.IsNDArray)
            {
                return nd.MpAdamWUpdate(weight, grad, mean, var, weight32, rescale_grad, lr, eta, beta1, beta2, epsilon, wd, clip_gradient);
            }
            return sym.MpAdamWUpdate(weight, grad, mean, var, weight32, rescale_grad, lr, eta, beta1, beta2, epsilon, wd, clip_gradient);
        }
        public static NDArrayOrSymbol AdamWUpdate(NDArrayOrSymbol weight, NDArrayOrSymbol grad, NDArrayOrSymbol mean, NDArrayOrSymbol var, NDArrayOrSymbol rescale_grad, Single lr, Single eta, Single beta1, Single beta2, Single epsilon, Single wd, Single clip_gradient)
        {
            if (weight.IsNDArray)
            {
                return nd.AdamWUpdate(weight, grad, mean, var, rescale_grad, lr, eta, beta1, beta2, epsilon, wd, clip_gradient);
            }
            return sym.AdamWUpdate(weight, grad, mean, var, rescale_grad, lr, eta, beta1, beta2, epsilon, wd, clip_gradient);
        }
        public static NDArrayOrSymbol KhatriRao(NDArrayOrSymbolList args)
        {
            if (args[0].IsNDArray)
            {
                return nd.KhatriRao(args.NDArrays);
            }
            return sym.KhatriRao(args.Symbols);
        }
        public static NDArrayOrSymbol Foreach(NDArrayOrSymbol fn, NDArrayOrSymbolList data, Int32 num_args, Int32 num_outputs, Int32 num_out_data, Tuple<Double> in_state_locs, Tuple<Double> in_data_locs, Tuple<Double> remain_locs)
        {
            if (fn.IsNDArray)
            {
                return nd.Foreach(fn, data.NDArrays, num_args, num_outputs, num_out_data, in_state_locs, in_data_locs, remain_locs);
            }
            return sym.Foreach(fn, data.Symbols, num_args, num_outputs, num_out_data, in_state_locs, in_data_locs, remain_locs);
        }
        public static NDArrayOrSymbol WhileLoop(NDArrayOrSymbol cond, NDArrayOrSymbol func, NDArrayOrSymbolList data, Int32 num_args, Int32 num_outputs, Int32 num_out_data, Int32 max_iterations, Tuple<Double> cond_input_locs, Tuple<Double> func_input_locs, Tuple<Double> func_var_locs)
        {
            if (cond.IsNDArray)
            {
                return nd.WhileLoop(cond, func, data.NDArrays, num_args, num_outputs, num_out_data, max_iterations, cond_input_locs, func_input_locs, func_var_locs);
            }
            return sym.WhileLoop(cond, func, data.Symbols, num_args, num_outputs, num_out_data, max_iterations, cond_input_locs, func_input_locs, func_var_locs);
        }
        public static NDArrayOrSymbol Cond(NDArrayOrSymbol cond, NDArrayOrSymbol then_branch, NDArrayOrSymbol else_branch, NDArrayOrSymbolList data, Int32 num_args, Int32 num_outputs, Tuple<Double> cond_input_locs, Tuple<Double> then_input_locs, Tuple<Double> else_input_locs)
        {
            if (cond.IsNDArray)
            {
                return nd.Cond(cond, then_branch, else_branch, data.NDArrays, num_args, num_outputs, cond_input_locs, then_input_locs, else_input_locs);
            }
            return sym.Cond(cond, then_branch, else_branch, data.Symbols, num_args, num_outputs, cond_input_locs, then_input_locs, else_input_locs);
        }
        public static NDArrayOrSymbol Custom(NDArrayOrSymbolList data, String op_type)
        {
            if (data[0].IsNDArray)
            {
                return nd.Custom(data.NDArrays, op_type);
            }
            return sym.Custom(data.Symbols, op_type);
        }
        public static NDArrayOrSymbol IdentityAttachKLSparseReg(NDArrayOrSymbol data, Single sparseness_target, Single penalty, Single momentum)
        {
            if (data.IsNDArray)
            {
                return nd.IdentityAttachKLSparseReg(data, sparseness_target, penalty, momentum);
            }
            return sym.IdentityAttachKLSparseReg(data, sparseness_target, penalty, momentum);
        }
        public static NDArrayOrSymbol LeakyReLU(NDArrayOrSymbol data, NDArrayOrSymbol gamma, ReluActType act_type, Single slope, Single lower_bound, Single upper_bound)
        {
            if (data.IsNDArray)
            {
                return nd.LeakyReLU(data, gamma, act_type, slope, lower_bound, upper_bound);
            }
            return sym.LeakyReLU(data, gamma, act_type, slope, lower_bound, upper_bound);
        }
        public static NDArrayOrSymbol SoftmaxCrossEntropy(NDArrayOrSymbol data, NDArrayOrSymbol label)
        {
            if (data.IsNDArray)
            {
                return nd.SoftmaxCrossEntropy(data, label);
            }
            return sym.SoftmaxCrossEntropy(data, label);
        }
        public static NDArrayOrSymbol Activation(NDArrayOrSymbol data, ActivationType act_type)
        {
            if (data.IsNDArray)
            {
                return nd.Activation(data, act_type);
            }
            return sym.Activation(data, act_type);
        }
        public static NDArrayOrSymbol BatchNorm(NDArrayOrSymbol data, NDArrayOrSymbol gamma, NDArrayOrSymbol beta, NDArrayOrSymbol moving_mean, NDArrayOrSymbol moving_var, Double eps, Single momentum, Boolean fix_gamma, Boolean use_global_stats, Boolean output_mean_var, Int32 axis, Boolean cudnn_off)
        {
            if (data.IsNDArray)
            {
                return nd.BatchNorm(data, gamma, beta, moving_mean, moving_var, eps, momentum, fix_gamma, use_global_stats, output_mean_var, axis, cudnn_off);
            }
            return sym.BatchNorm(data, gamma, beta, moving_mean, moving_var, eps, momentum, fix_gamma, use_global_stats, output_mean_var, axis, cudnn_off);
        }
        public static NDArrayOrSymbol Concat(NDArrayOrSymbolList data, Int32 dim)
        {
            if (data[0].IsNDArray)
            {
                return nd.Concat(data.NDArrays, dim);
            }
            return sym.Concat(data.Symbols, dim);
        }
        public static NDArrayOrSymbol RnnParamConcat(NDArrayOrSymbolList data, Int32 num_args, Int32 dim)
        {
            if (data[0].IsNDArray)
            {
                return nd.RnnParamConcat(data.NDArrays, num_args, dim);
            }
            return sym.RnnParamConcat(data.Symbols, num_args, dim);
        }
        public static NDArrayOrSymbol Convolution(NDArrayOrSymbol data, NDArrayOrSymbol weight, NDArrayOrSymbol bias, Shape kernel, Int32 num_filter, Shape stride, Shape dilate, Shape pad, Int32 num_group, UInt64 workspace, Boolean no_bias, ConvolutionCudnnTune? cudnn_tune, Boolean cudnn_off, ConvolutionLayout? layout)
        {
            if (data.IsNDArray)
            {
                return nd.Convolution(data, weight, bias, kernel, num_filter, stride, dilate, pad, num_group, workspace, no_bias, cudnn_tune, cudnn_off, layout);
            }
            return sym.Convolution(data, weight, bias, kernel, num_filter, stride, dilate, pad, num_group, workspace, no_bias, cudnn_tune, cudnn_off, layout);
        }
        public static NDArrayOrSymbol CTCLoss(NDArrayOrSymbol data, NDArrayOrSymbol label, NDArrayOrSymbol data_lengths, NDArrayOrSymbol label_lengths, Boolean use_data_lengths, Boolean use_label_lengths, CtclossBlankLabel blank_label)
        {
            if (data.IsNDArray)
            {
                return nd.CTCLoss(data, label, data_lengths, label_lengths, use_data_lengths, use_label_lengths, blank_label);
            }
            return sym.CTCLoss(data, label, data_lengths, label_lengths, use_data_lengths, use_label_lengths, blank_label);
        }
        public static NDArrayOrSymbol Deconvolution(NDArrayOrSymbol data, NDArrayOrSymbol weight, NDArrayOrSymbol bias, Shape kernel, UInt32 num_filter, Shape stride, Shape dilate, Shape pad, Shape adj, Shape target_shape, UInt32 num_group, UInt64 workspace, Boolean no_bias, DeconvolutionCudnnTune? cudnn_tune, Boolean cudnn_off, DeconvolutionLayout? layout)
        {
            if (data.IsNDArray)
            {
                return nd.Deconvolution(data, weight, bias, kernel, num_filter, stride, dilate, pad, adj, target_shape, num_group, workspace, no_bias, cudnn_tune, cudnn_off, layout);
            }
            return sym.Deconvolution(data, weight, bias, kernel, num_filter, stride, dilate, pad, adj, target_shape, num_group, workspace, no_bias, cudnn_tune, cudnn_off, layout);
        }
        public static NDArrayOrSymbol Dropout(NDArrayOrSymbol data, Single p, DropoutMode mode, Shape axes, Boolean? cudnn_off)
        {
            if (data.IsNDArray)
            {
                return nd.Dropout(data, p, mode, axes, cudnn_off);
            }
            return sym.Dropout(data, p, mode, axes, cudnn_off);
        }
        public static NDArrayOrSymbol FullyConnected(NDArrayOrSymbol data, NDArrayOrSymbol weight, NDArrayOrSymbol bias, Int32 num_hidden, Boolean no_bias, Boolean flatten)
        {
            if (data.IsNDArray)
            {
                return nd.FullyConnected(data, weight, bias, num_hidden, no_bias, flatten);
            }
            return sym.FullyConnected(data, weight, bias, num_hidden, no_bias, flatten);
        }
        public static NDArrayOrSymbol LayerNorm(NDArrayOrSymbol data, NDArrayOrSymbol gamma, NDArrayOrSymbol beta, Int32 axis, Single eps, Boolean output_mean_var)
        {
            if (data.IsNDArray)
            {
                return nd.LayerNorm(data, gamma, beta, axis, eps, output_mean_var);
            }
            return sym.LayerNorm(data, gamma, beta, axis, eps, output_mean_var);
        }
        public static NDArrayOrSymbol LRN(NDArrayOrSymbol data, UInt32 nsize, Single alpha, Single beta, Single knorm)
        {
            if (data.IsNDArray)
            {
                return nd.LRN(data, nsize, alpha, beta, knorm);
            }
            return sym.LRN(data, nsize, alpha, beta, knorm);
        }
        public static NDArrayOrSymbol Pooling(NDArrayOrSymbol data, Shape kernel, PoolingType pool_type, Boolean global_pool, Boolean cudnn_off, PoolingConvention pooling_convention, Shape stride, Shape pad, Int32? p_value, Boolean? count_include_pad, String layout)
        {
            if (data.IsNDArray)
            {
                return nd.Pooling(data, kernel, pool_type, global_pool, cudnn_off, pooling_convention, stride, pad, p_value, count_include_pad, layout);
            }
            return sym.Pooling(data, kernel, pool_type, global_pool, cudnn_off, pooling_convention, stride, pad, p_value, count_include_pad, layout);
        }
        public static NDArrayOrSymbol Softmax(NDArrayOrSymbol data, Int32 axis, Double? temperature, DType dtype)
        {
            if (data.IsNDArray)
            {
                return nd.Softmax(data, axis, temperature, dtype);
            }
            return sym.Softmax(data, axis, temperature, dtype);
        }
        public static NDArrayOrSymbol Softmin(NDArrayOrSymbol data, Int32 axis, Double? temperature, DType dtype)
        {
            if (data.IsNDArray)
            {
                return nd.Softmin(data, axis, temperature, dtype);
            }
            return sym.Softmin(data, axis, temperature, dtype);
        }
        public static NDArrayOrSymbol LogSoftmax(NDArrayOrSymbol data, Int32 axis, Double? temperature, DType dtype)
        {
            if (data.IsNDArray)
            {
                return nd.LogSoftmax(data, axis, temperature, dtype);
            }
            return sym.LogSoftmax(data, axis, temperature, dtype);
        }
        public static NDArrayOrSymbol SoftmaxActivation(NDArrayOrSymbol data, SoftmaxMode mode)
        {
            if (data.IsNDArray)
            {
                return nd.SoftmaxActivation(data, mode);
            }
            return sym.SoftmaxActivation(data, mode);
        }
        public static NDArrayOrSymbol UpSampling(NDArrayOrSymbolList data, Int32 scale, UpsamplingSampleType sample_type, Int32 num_args, Int32 num_filter, UpsamplingMultiInputMode multi_input_mode, UInt64 workspace)
        {
            if (data[0].IsNDArray)
            {
                return nd.UpSampling(data.NDArrays, scale, sample_type, num_args, num_filter, multi_input_mode, workspace);
            }
            return sym.UpSampling(data.Symbols, scale, sample_type, num_args, num_filter, multi_input_mode, workspace);
        }
        public static NDArrayOrSymbol SignsgdUpdate(NDArrayOrSymbol weight, NDArrayOrSymbol grad, Single lr, Single wd, Single rescale_grad, Single clip_gradient)
        {
            if (weight.IsNDArray)
            {
                return nd.SignsgdUpdate(weight, grad, lr, wd, rescale_grad, clip_gradient);
            }
            return sym.SignsgdUpdate(weight, grad, lr, wd, rescale_grad, clip_gradient);
        }
        public static NDArrayOrSymbol SignumUpdate(NDArrayOrSymbol weight, NDArrayOrSymbol grad, NDArrayOrSymbol mom, Single lr, Single momentum, Single wd, Single rescale_grad, Single clip_gradient, Single wd_lh)
        {
            if (weight.IsNDArray)
            {
                return nd.SignumUpdate(weight, grad, mom, lr, momentum, wd, rescale_grad, clip_gradient, wd_lh);
            }
            return sym.SignumUpdate(weight, grad, mom, lr, momentum, wd, rescale_grad, clip_gradient, wd_lh);
        }
        public static NDArrayOrSymbolList MultiSgdUpdate(NDArrayOrSymbolList data, Single[] lrs, Single[] wds, Single rescale_grad, Single clip_gradient, Int32 num_weights, NDArrayOrSymbolList outputs)
        {
            if (data[0].IsNDArray)
            {
                return nd.MultiSgdUpdate(data.NDArrays, lrs, wds, rescale_grad, clip_gradient, num_weights, outputs.NDArrays);
            }

            return sym.MultiSgdUpdate(data.Symbols, lrs, wds, rescale_grad, clip_gradient, num_weights).ToList();
        }
        public static NDArrayOrSymbolList MultiSgdMomUpdate(NDArrayOrSymbolList data, Single[] lrs, Single[] wds, Single momentum, Single rescale_grad, Single clip_gradient, Int32 num_weights, NDArrayOrSymbolList outputs)
        {
            if (data[0].IsNDArray)
            {
                return nd.MultiSgdMomUpdate(data.NDArrays, lrs, wds, momentum, rescale_grad, clip_gradient, num_weights, outputs.NDArrays);
            }
            return sym.MultiSgdMomUpdate(data.Symbols, lrs, wds, momentum, rescale_grad, clip_gradient, num_weights).ToList();
        }
        public static NDArrayOrSymbolList MultiMpSgdUpdate(NDArrayOrSymbolList data, Single[] lrs, Single[] wds, Single rescale_grad, Single clip_gradient, Int32 num_weights, NDArrayOrSymbolList outputs)
        {
            if (data[0].IsNDArray)
            {
                return nd.MultiMpSgdUpdate(data.NDArrays, lrs, wds, rescale_grad, clip_gradient, num_weights, outputs.NDArrays);
            }
            return sym.MultiMpSgdUpdate(data.Symbols, lrs, wds, rescale_grad, clip_gradient, num_weights).ToList();
        }
        public static NDArrayOrSymbolList MultiMpSgdMomUpdate(NDArrayOrSymbolList data, Single[] lrs, Single[] wds, Single momentum, Single rescale_grad, Single clip_gradient, Int32 num_weights, NDArrayOrSymbolList outputs)
        {
            if (data[0].IsNDArray)
            {
                return nd.MultiMpSgdMomUpdate(data.NDArrays, lrs, wds, momentum, rescale_grad, clip_gradient, num_weights, outputs.NDArrays);
            }
            return sym.MultiMpSgdMomUpdate(data.Symbols, lrs, wds, momentum, rescale_grad, clip_gradient, num_weights).ToList();
        }
        public static NDArrayOrSymbol SgdUpdate(NDArrayOrSymbol weight, NDArrayOrSymbol grad, Single lr, Single wd, Single rescale_grad, Single clip_gradient, Boolean lazy_update)
        {
            if (weight.IsNDArray)
            {
                return nd.SgdUpdate(weight, grad, lr, wd, rescale_grad, clip_gradient, lazy_update);
            }
            return sym.SgdUpdate(weight, grad, lr, wd, rescale_grad, clip_gradient, lazy_update);
        }
        public static NDArrayOrSymbol SgdMomUpdate(NDArrayOrSymbol weight, NDArrayOrSymbol grad, NDArrayOrSymbol mom, Single lr, Single momentum, Single wd, Single rescale_grad, Single clip_gradient, Boolean lazy_update)
        {
            if (weight.IsNDArray)
            {
                return nd.SgdMomUpdate(weight, grad, mom, lr, momentum, wd, rescale_grad, clip_gradient, lazy_update);
            }
            return sym.SgdMomUpdate(weight, grad, mom, lr, momentum, wd, rescale_grad, clip_gradient, lazy_update);
        }
        public static NDArrayOrSymbol MpSgdUpdate(NDArrayOrSymbol weight, NDArrayOrSymbol grad, NDArrayOrSymbol weight32, Single lr, Single wd, Single rescale_grad, Single clip_gradient, Boolean lazy_update)
        {
            if (weight.IsNDArray)
            {
                return nd.MpSgdUpdate(weight, grad, weight32, lr, wd, rescale_grad, clip_gradient, lazy_update);
            }
            return sym.MpSgdUpdate(weight, grad, weight32, lr, wd, rescale_grad, clip_gradient, lazy_update);
        }
        public static NDArrayOrSymbol MpSgdMomUpdate(NDArrayOrSymbol weight, NDArrayOrSymbol grad, NDArrayOrSymbol mom, NDArrayOrSymbol weight32, Single lr, Single momentum, Single wd, Single rescale_grad, Single clip_gradient, Boolean lazy_update)
        {
            if (weight.IsNDArray)
            {
                return nd.MpSgdMomUpdate(weight, grad, mom, weight32, lr, momentum, wd, rescale_grad, clip_gradient, lazy_update);
            }
            return sym.MpSgdMomUpdate(weight, grad, mom, weight32, lr, momentum, wd, rescale_grad, clip_gradient, lazy_update);
        }
        public static NDArrayOrSymbol FtmlUpdate(NDArrayOrSymbol weight, NDArrayOrSymbol grad, NDArrayOrSymbol d, NDArrayOrSymbol v, NDArrayOrSymbol z, Single lr, Int32 t, Single beta1, Single beta2, Double epsilon, Single wd, Single rescale_grad, Single clip_grad)
        {
            if (weight.IsNDArray)
            {
                return nd.FtmlUpdate(weight, grad, d, v, z, lr, t, beta1, beta2, epsilon, wd, rescale_grad, clip_grad);
            }
            return sym.FtmlUpdate(weight, grad, d, v, z, lr, t, beta1, beta2, epsilon, wd, rescale_grad, clip_grad);
        }
        public static NDArrayOrSymbol AdamUpdate(NDArrayOrSymbol weight, NDArrayOrSymbol grad, NDArrayOrSymbol mean, NDArrayOrSymbol var, Single lr, Single beta1, Single beta2, Single epsilon, Single wd, Single rescale_grad, Single clip_gradient, Boolean lazy_update)
        {
            if (weight.IsNDArray)
            {
                return nd.AdamUpdate(weight, grad, mean, var, lr, beta1, beta2, epsilon, wd, rescale_grad, clip_gradient, lazy_update);
            }
            return sym.AdamUpdate(weight, grad, mean, var, lr, beta1, beta2, epsilon, wd, rescale_grad, clip_gradient, lazy_update);
        }
        public static NDArrayOrSymbol RmspropUpdate(NDArrayOrSymbol weight, NDArrayOrSymbol grad, NDArrayOrSymbol n, Single lr, Single gamma1, Single epsilon, Single wd, Single rescale_grad, Single clip_gradient, Single clip_weights)
        {
            if (weight.IsNDArray)
            {
                return nd.RmspropUpdate(weight, grad, n, lr, gamma1, epsilon, wd, rescale_grad, clip_gradient, clip_weights);
            }
            return sym.RmspropUpdate(weight, grad, n, lr, gamma1, epsilon, wd, rescale_grad, clip_gradient, clip_weights);
        }
        public static NDArrayOrSymbol RmspropalexUpdate(NDArrayOrSymbol weight, NDArrayOrSymbol grad, NDArrayOrSymbol n, NDArrayOrSymbol g, NDArrayOrSymbol delta, Single lr, Single gamma1, Single gamma2, Single epsilon, Single wd, Single rescale_grad, Single clip_gradient, Single clip_weights)
        {
            if (weight.IsNDArray)
            {
                return nd.RmspropalexUpdate(weight, grad, n, g, delta, lr, gamma1, gamma2, epsilon, wd, rescale_grad, clip_gradient, clip_weights);
            }
            return sym.RmspropalexUpdate(weight, grad, n, g, delta, lr, gamma1, gamma2, epsilon, wd, rescale_grad, clip_gradient, clip_weights);
        }
        public static NDArrayOrSymbol FtrlUpdate(NDArrayOrSymbol weight, NDArrayOrSymbol grad, NDArrayOrSymbol z, NDArrayOrSymbol n, Single lr, Single lamda1, Single beta, Single wd, Single rescale_grad, Single clip_gradient)
        {
            if (weight.IsNDArray)
            {
                return nd.FtrlUpdate(weight, grad, z, n, lr, lamda1, beta, wd, rescale_grad, clip_gradient);
            }
            return sym.FtrlUpdate(weight, grad, z, n, lr, lamda1, beta, wd, rescale_grad, clip_gradient);
        }
        public static NDArrayOrSymbol NAGMomUpdate(NDArrayOrSymbol weight, NDArrayOrSymbol grad, NDArrayOrSymbol mom, Single lr, Single momentum, Single wd, Single rescale_grad, Single clip_gradient)
        {
            if (weight.IsNDArray)
            {
                return nd.NAGMomUpdate(weight, grad, mom, lr, momentum, wd, rescale_grad, clip_gradient);
            }
            return sym.NAGMomUpdate(weight, grad, mom, lr, momentum, wd, rescale_grad, clip_gradient);
        }
        public static NDArrayOrSymbol MPNAGMomUpdate(NDArrayOrSymbol weight, NDArrayOrSymbol grad, NDArrayOrSymbol mom, NDArrayOrSymbol weight32, Single lr, Single momentum, Single wd, Single rescale_grad, Single clip_gradient)
        {
            if (weight.IsNDArray)
            {
                return nd.MPNAGMomUpdate(weight, grad, mom, weight32, lr, momentum, wd, rescale_grad, clip_gradient);
            }
            return sym.MPNAGMomUpdate(weight, grad, mom, weight32, lr, momentum, wd, rescale_grad, clip_gradient);
        }
        public static NDArrayOrSymbol SparseAdagradUpdate(NDArrayOrSymbol weight, NDArrayOrSymbol grad, NDArrayOrSymbol history, Single lr, Single epsilon, Single wd, Single rescale_grad, Single clip_gradient)
        {
            if (weight.IsNDArray)
            {
                return nd.SparseAdagradUpdate(weight, grad, history, lr, epsilon, wd, rescale_grad, clip_gradient);
            }
            return sym.SparseAdagradUpdate(weight, grad, history, lr, epsilon, wd, rescale_grad, clip_gradient);
        }
        public static NDArrayOrSymbol Pad(NDArrayOrSymbol data, PadMode mode, Shape pad_width, Double constant_value)
        {
            if (data.IsNDArray)
            {
                return nd.Pad(data, mode, pad_width, constant_value);
            }
            return sym.Pad(data, mode, pad_width, constant_value);
        }
        public static NDArrayOrSymbol Flatten(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Flatten(data);
            }
            return sym.Flatten(data);
        }
        public static NDArrayOrSymbol SampleUniform(NDArrayOrSymbol low, NDArrayOrSymbol high, Shape shape, DType dtype)
        {
            if (low.IsNDArray)
            {
                return nd.SampleUniform(low, high, shape, dtype);
            }
            return sym.SampleUniform(low, high, shape, dtype);
        }
        public static NDArrayOrSymbol SampleNormal(NDArrayOrSymbol mu, NDArrayOrSymbol sigma, Shape shape, DType dtype)
        {
            if (mu.IsNDArray)
            {
                return nd.SampleNormal(mu, sigma, shape, dtype);
            }
            return sym.SampleNormal(mu, sigma, shape, dtype);
        }
        public static NDArrayOrSymbol SampleGamma(NDArrayOrSymbol alpha, NDArrayOrSymbol beta, Shape shape, DType dtype)
        {
            if (alpha.IsNDArray)
            {
                return nd.SampleGamma(alpha, beta, shape, dtype);
            }
            return sym.SampleGamma(alpha, beta, shape, dtype);
        }
        public static NDArrayOrSymbol SampleExponential(NDArrayOrSymbol lam, Shape shape, DType dtype)
        {
            if (lam.IsNDArray)
            {
                return nd.SampleExponential(lam, shape, dtype);
            }
            return sym.SampleExponential(lam, shape, dtype);
        }
        public static NDArrayOrSymbol SamplePoisson(NDArrayOrSymbol lam, Shape shape, DType dtype)
        {
            if (lam.IsNDArray)
            {
                return nd.SamplePoisson(lam, shape, dtype);
            }
            return sym.SamplePoisson(lam, shape, dtype);
        }
        public static NDArrayOrSymbol SampleNegativeBinomial(NDArrayOrSymbol k, NDArrayOrSymbol p, Shape shape, DType dtype)
        {
            if (k.IsNDArray)
            {
                return nd.SampleNegativeBinomial(k, p, shape, dtype);
            }
            return sym.SampleNegativeBinomial(k, p, shape, dtype);
        }
        public static NDArrayOrSymbol SampleGeneralizedNegativeBinomial(NDArrayOrSymbol mu, NDArrayOrSymbol alpha, Shape shape, DType dtype)
        {
            if (mu.IsNDArray)
            {
                return nd.SampleGeneralizedNegativeBinomial(mu, alpha, shape, dtype);
            }
            return sym.SampleGeneralizedNegativeBinomial(mu, alpha, shape, dtype);
        }
        public static NDArrayOrSymbol SampleMultinomial(NDArrayOrSymbol data, Shape shape, Boolean get_prob, DType dtype)
        {
            if (data.IsNDArray)
            {
                return nd.SampleMultinomial(data, shape, get_prob, dtype);
            }
            return sym.SampleMultinomial(data, shape, get_prob, dtype);
        }
        public static NDArrayOrSymbol Shuffle(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.Shuffle(data);
            }
            return sym.Shuffle(data);
        }
        public static NDArrayOrSymbol LinearRegressionOutput(NDArrayOrSymbol data, NDArrayOrSymbol label, Single grad_scale)
        {
            if (data.IsNDArray)
            {
                return nd.LinearRegressionOutput(data, label, grad_scale);
            }
            return sym.LinearRegressionOutput(data, label, grad_scale);
        }
        public static NDArrayOrSymbol MAERegressionOutput(NDArrayOrSymbol data, NDArrayOrSymbol label, Single grad_scale)
        {
            if (data.IsNDArray)
            {
                return nd.MAERegressionOutput(data, label, grad_scale);
            }
            return sym.MAERegressionOutput(data, label, grad_scale);
        }
        public static NDArrayOrSymbol LogisticRegressionOutput(NDArrayOrSymbol data, NDArrayOrSymbol label, Single grad_scale)
        {
            if (data.IsNDArray)
            {
                return nd.LogisticRegressionOutput(data, label, grad_scale);
            }
            return sym.LogisticRegressionOutput(data, label, grad_scale);
        }
        public static NDArrayOrSymbol RNN(NDArrayOrSymbol data, NDArrayOrSymbol parameters, NDArrayOrSymbol state, NDArrayOrSymbol state_cell, UInt32 state_size, UInt32 num_layers, RNNMode mode, Boolean bidirectional, Single p, Boolean state_outputs, Int32? projection_size, Double? lstm_state_clip_min, Double? lstm_state_clip_max, Boolean lstm_state_clip_nan)
        {
            if (data.IsNDArray)
            {
                return nd.RNN(data, parameters, state, state_cell, state_size, num_layers, mode, bidirectional, p, state_outputs, projection_size, lstm_state_clip_min, lstm_state_clip_max, lstm_state_clip_nan);
            }
            return sym.RNN(data, parameters, state, state_cell, state_size, num_layers, mode, bidirectional, p, state_outputs, projection_size, lstm_state_clip_min, lstm_state_clip_max, lstm_state_clip_nan);
        }
        public static NDArrayOrSymbol SliceChannel(NDArrayOrSymbol data, Int32 num_outputs, Int32 axis, Boolean squeeze_axis)
        {
            if (data.IsNDArray)
            {
                return nd.SliceChannel(data, num_outputs, axis, squeeze_axis);
            }
            return sym.SliceChannel(data, num_outputs, axis, squeeze_axis);
        }
        public static NDArrayOrSymbol SoftmaxOutput(NDArrayOrSymbol data, NDArrayOrSymbol label, Single grad_scale, Single ignore_label, Boolean multi_output, Boolean use_ignore, Boolean preserve_shape, SoftmaxoutputNormalization normalization, Boolean out_grad, Single smooth_alpha)
        {
            if (data.IsNDArray)
            {
                return nd.SoftmaxOutput(data, label, grad_scale, ignore_label, multi_output, use_ignore, preserve_shape, normalization, out_grad, smooth_alpha);
            }
            return sym.SoftmaxOutput(data, label, grad_scale, ignore_label, multi_output, use_ignore, preserve_shape, normalization, out_grad, smooth_alpha);
        }
        public static NDArrayOrSymbol SwapAxis(NDArrayOrSymbol data, UInt32 dim1, UInt32 dim2)
        {
            if (data.IsNDArray)
            {
                return nd.SwapAxis(data, dim1, dim2);
            }
            return sym.SwapAxis(data, dim1, dim2);
        }
        public static NDArrayOrSymbol Argmax(NDArrayOrSymbol data, Int32? axis, Boolean keepdims)
        {
            if (data.IsNDArray)
            {
                return nd.Argmax(data, axis, keepdims);
            }
            return sym.Argmax(data, axis, keepdims);
        }
        public static NDArrayOrSymbol Argmin(NDArrayOrSymbol data, Int32? axis, Boolean keepdims)
        {
            if (data.IsNDArray)
            {
                return nd.Argmin(data, axis, keepdims);
            }
            return sym.Argmin(data, axis, keepdims);
        }
        public static NDArrayOrSymbol ArgmaxChannel(NDArrayOrSymbol data)
        {
            if (data.IsNDArray)
            {
                return nd.ArgmaxChannel(data);
            }
            return sym.ArgmaxChannel(data);
        }
        public static NDArrayOrSymbol Pick(NDArrayOrSymbol data, NDArrayOrSymbol index, Int32? axis, Boolean keepdims, PickMode mode)
        {
            if (data.IsNDArray)
            {
                return nd.Pick(data, index, axis, keepdims, mode);
            }
            return sym.Pick(data, index, axis, keepdims, mode);
        }
        public static NDArrayOrSymbol Sum(NDArrayOrSymbol data, Shape axis, Boolean keepdims, Boolean exclude)
        {
            if (data.IsNDArray)
            {
                return nd.Sum(data, axis, keepdims, exclude);
            }
            return sym.Sum(data, axis, keepdims, exclude);
        }
        public static NDArrayOrSymbol Sum(NDArrayOrSymbol data, Int32 axis, Boolean keepdims, Boolean exclude)
        {
            if (data.IsNDArray)
            {
                return nd.Sum(data, axis, keepdims, exclude);
            }
            return sym.Sum(data, axis, keepdims, exclude);
        }
        public static NDArrayOrSymbol Mean(NDArrayOrSymbol data, Shape axis, Boolean keepdims, Boolean exclude)
        {
            if (data.IsNDArray)
            {
                return nd.Mean(data, axis, keepdims, exclude);
            }
            return sym.Mean(data, axis, keepdims, exclude);
        }
        public static NDArrayOrSymbol Mean(NDArrayOrSymbol data, Int32 axis, Boolean keepdims, Boolean exclude)
        {
            if (data.IsNDArray)
            {
                return nd.Mean(data, axis, keepdims, exclude);
            }
            return sym.Mean(data, axis, keepdims, exclude);
        }
        public static NDArrayOrSymbol Prod(NDArrayOrSymbol data, Shape axis, Boolean keepdims, Boolean exclude)
        {
            if (data.IsNDArray)
            {
                return nd.Prod(data, axis, keepdims, exclude);
            }
            return sym.Prod(data, axis, keepdims, exclude);
        }
        public static NDArrayOrSymbol Nansum(NDArrayOrSymbol data, Shape axis, Boolean keepdims, Boolean exclude)
        {
            if (data.IsNDArray)
            {
                return nd.Nansum(data, axis, keepdims, exclude);
            }
            return sym.Nansum(data, axis, keepdims, exclude);
        }


    }
}
