using MxNet.Keras.Layers;
using NumpyDotNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MxNet.Keras
{
    public class NameScope : IDisposable
    {
        private string Name { get; }

        public NameScope(string name)
        {
            Name = name;
            MxNetBackend.NAME_SCOPE_STACK.Push(name);
        }

        public void Dispose()
        {
            MxNetBackend.NAME_SCOPE_STACK.Pop();
        }
    }

    public class MxNetBackend
    {
        public static Stack<string> NAME_SCOPE_STACK = new Stack<string>();

        public static bool _REENTRY = false;

        public static Model _MODEL = null;

        public static bool IsReEntry()
        {
            return _REENTRY;
        }

        public static void SetReEntry(bool value)
        {
            _REENTRY = value;
        }

        public static void SetModel(Model model)
        {
            _MODEL = model;
        }

        public static void ClearSession()
        {
            throw new NotImplementedException();
        }

        public static float LearningPhase()
        {
            throw new NotImplementedException();
        }

        public static void SetLearningPhase(float value)
        {
            throw new NotImplementedException();
        }

        public static ndarray CastToFloatX(ndarray x)
        {
            throw new NotImplementedException();
        }

        public static NDArray CastToFloatX(NDArray x)
        {
            throw new NotImplementedException();
        }

        public static bool IsSparse()
        {
            throw new NotImplementedException();
        }

        public static NDArray ToDense(NDArray tensor)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol ToDense(KerasSymbol tensor)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Variable(NDArray value, DType dtype = null, string name = "", Constraint constraint = null, bool sparse_weight = false)
        {
            throw new NotImplementedException();
        }

        public static NDArray Constant(float value, DType dtype= null, Shape shape= null, string name= "")
        {
            throw new NotImplementedException();
        }

        public static bool IsKerasTensor(object x)
        {
            throw new NotImplementedException();
        }

        public static bool IsTensor(object x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Placeholder(Shape shape= null, int? ndim= null, DType dtype= null, bool sparse= false, string name= "")
        {
            throw new NotImplementedException();
        }

        public static bool IsPlaceholder(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static Shape Shape(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static int[] IntShape(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static int NDim(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static DType DType(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static NDArray Eval(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Zeros(Shape shape, DType dtype = null, string name = "")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Ones(Shape shape, DType dtype = null, string name = "")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Eye(int size, DType dtype = null, string name = "")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol ZerosLike(KerasSymbol x, DType dtype = null, string name = "")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol OnesLike(KerasSymbol x, DType dtype = null, string name = "")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Identity(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol RandomUniformVariable(Shape shape, float low, float high, DType dtype= null, string name= "", int? seed= null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol RandomNormalVariable(Shape shape, float mean, float scale, DType dtype = null, string name = "", int? seed = null)
        {
            throw new NotImplementedException();
        }

        public static int CountParams(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Cast(KerasSymbol x, DType dtype)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Update(KerasSymbol x, NDArray new_x)
        {
            throw new NotSupportedException("MXNet Backend: Update operations are not supported yet.");
        }

        public static KerasSymbol UpdateAdd(KerasSymbol x, NDArray new_x)
        {
            throw new NotSupportedException("MXNet Backend: Update operations are not supported yet.");
        }

        public static KerasSymbol UpdateSub(KerasSymbol x, NDArray new_x)
        {
            throw new NotSupportedException("MXNet Backend: Update operations are not supported yet.");
        }

        public static KerasSymbol MovingAverageUpdate(KerasSymbol x, NDArray value, float momentum)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Dot(KerasSymbol x, KerasSymbol y)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol BatchDot(KerasSymbol x, KerasSymbol y, Shape axes = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Transpose(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Gather(KerasSymbol reference, KerasSymbol indices)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Embedding(KerasSymbol data, KerasSymbol weight, int input_dim, int output_dim, bool sparse_grad= false)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Max(KerasSymbol x, int axis, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Min(KerasSymbol x, int axis, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Sum(KerasSymbol x, int axis, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Prod(KerasSymbol x, int axis, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol CumSum(KerasSymbol x, int axis = 0)
        {
            throw new NotSupportedException("MXNet Backend: CumSum operations are not supported yet.");
        }

        public static KerasSymbol CumProd(KerasSymbol x, int axis = 0)
        {
            throw new NotSupportedException("MXNet Backend: CumProd operations are not supported yet.");
        }

        public static Symbol MxNetVariance(Symbol x, int? axis = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Var(Symbol x, int? axis = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Mean(Symbol x, int? axis = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Any(Symbol x, int? axis = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol All(Symbol x, int? axis = null, bool keepdims = false)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Argmax(Symbol x, int axis = -1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Argmin(Symbol x, int axis = -1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Square(Symbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Abs(Symbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Sqrt(Symbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Exp(Symbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Log(Symbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol LogSumExp(Symbol x, int? axis = null, bool keepdims = false)
        {
            throw new NotSupportedException("MXNet Backend: LogSumExp operations are not supported yet.");
        }

        public static KerasSymbol Round(Symbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Sign(Symbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Pow(Symbol x, Symbol a)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Clip(Symbol x, float min_value, float max_value)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Equal(Symbol x, Symbol y)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol NotEqual(Symbol x, Symbol y)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Greater(Symbol x, Symbol y)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol GreaterEqual(Symbol x, Symbol y)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Less(Symbol x, Symbol y)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol LessEqual(Symbol x, Symbol y)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Maximum(Symbol x, Symbol y)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Minimum(Symbol x, Symbol y)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Sin(Symbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Cos(Symbol x)
        {
            throw new NotImplementedException();
        }

        public static (Symbol, KerasSymbol, KerasSymbol) NormalizeBatchInTraining(Symbol x, Symbol gamma, Symbol beta, Symbol reduction_axes, float epsilon= 1e-3f)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol BatchNormalization(Symbol x, Symbol gamma, Symbol beta, Symbol reduction_axes, float epsilon = 1e-3f)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol MxNetBatchNorm(Symbol x, Symbol gamma, Symbol beta, Symbol moving_mean, Symbol moving_var, float momentum= 0.9f, int axis= 1, float epsilon = 1e-3f)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Concatenate(Symbol x, int axis = 1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Reshape(Symbol x, Shape shape)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol PermuteDimensions(Symbol x, Shape shape)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol ResizeImage(Symbol x, int height_factor, int width_factor, string data_format, string interpolation= "nearest")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol ResizeVolumses(Symbol x, int depth_factor, int height_factor, int width_factor, string data_format)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol RepeatElements(Symbol x, int rep, int axis)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Repeat(Symbol x, int n)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Arange(int start, int? stop = null, int step = 1, DType dtype = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Tile(Symbol x, int n)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Flatten(Symbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol BatchFlatten(Symbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol ExpandDims(Symbol x, int axis = -1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Squeeze(Symbol x, int axis)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol TemporalPadding(Symbol x, (int, int)? padding= null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Spatial2DPadding(Symbol x, ((int, int), (int, int))? padding = null, string data_format = "")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Spatial3DPadding(Symbol x, ((int, int), (int, int), (int, int))? padding = null, string data_format = "")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Stack(Symbol x, int axis = 0)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol OneHot(Symbol indices, int num_classes)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Reverse(Symbol x, Shape axes)
        {
            throw new NotImplementedException();
        }

        public static NDArray GetValue(Symbol x)
        {
            throw new NotImplementedException();
        }

        public static NDArray[] GetValue(KerasSymbol[] ops)
        {
            throw new NotImplementedException();
        }

        public static void SetValue(Symbol x, NDArray value)
        {
            throw new NotImplementedException();
        }

        public static void BatchSetValue(List<(Symbol, NDArray)> tuples)
        {
            throw new NotImplementedException();
        }

        public static Shape GetVariableShape(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static void PrintTensor(KerasSymbol x, string message = "")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Group(KerasSymbol[] variables)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol MakeLoss(KerasSymbol[] variables)
        {
            throw new NotImplementedException();
        }

        public static Function Func(KerasSymbol[] inputs, KerasSymbol output, KerasSymbol[] updates)
        {
            throw new NotImplementedException();
        }

        public static void StopGradient(KerasSymbol[] variables)
        {
            throw new NotImplementedException();
        }

        public static (KerasSymbol, KerasSymbol[], KerasSymbol[]) RNN(Func<KerasSymbol[], KerasSymbol[], KerasSymbol[]> step_function, KerasSymbol[]  inputs, KerasSymbol[]  initial_states, bool go_backwards= false, KerasSymbol mask= null, float[] constants= null,
            bool unroll= false, int? input_length= null, SimpleRNNCell cell = null, bool? training= null)
        {
            throw new NotImplementedException();
        }

        public static Symbol DotRnn(Symbol x, Symbol y)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol GenerateDropoutMask(Symbol ones, float rate, bool? training = null, int count = 1)
        {
            throw new NotImplementedException();
        }

        public static Symbol Switch(Symbol condition, Symbol then_expression, Symbol else_expression)
        {
            throw new NotImplementedException();
        }

        public static Symbol InTrainPhase(Symbol x, Symbol alt, bool? training= null)
        {
            throw new NotImplementedException();
        }

        public static Symbol InTestPhase(Symbol x, Symbol alt, bool? training = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Relu(KerasSymbol x, float alpha= 0, float? max_value= null, float threshold= 0)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Elu(KerasSymbol x, float alpha = 1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Softmax(KerasSymbol x, int axis = -1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Softplus(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Softsign(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol CategoricalCrossentropy(KerasSymbol target, KerasSymbol output, bool from_logits= false, int axis= -1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol SparseCategoricalCrossentropy(KerasSymbol target, KerasSymbol output, bool from_logits = false, int axis = -1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol MultiHotSparseCategoricalCrossentropy(KerasSymbol target, KerasSymbol output, bool from_logits = false, int axis = -1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol BinaryCrossentropy(KerasSymbol target, KerasSymbol output, bool from_logits = false)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Sigmoid(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol HardSigmoid(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Tanh(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Dropout(KerasSymbol x, float level, Shape noise_shape, int? seed = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol L2Normalize(KerasSymbol x, int axis = -1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol InTopK(KerasSymbol predictions, KerasSymbol targets, int k)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Conv1D(KerasSymbol x, KerasSymbol kernel, int strides= 1, string padding= "valid", string data_format= "",                                int dilation_rate= 1)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Conv2D(KerasSymbol x, KerasSymbol kernel, (int, int)? strides = null, string padding = "valid", string data_format = "", (int, int)? dilation_rate = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Conv2DTranspose(KerasSymbol x, KerasSymbol kernel, Shape output_shape, (int, int)? strides = null, string padding = "valid", string data_format = "", (int, int)? dilation_rate = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol SeparableConv2D(KerasSymbol x, KerasSymbol depthwise_kernel, KerasSymbol pointwise_kernel, (int, int)? strides = null, string padding = "valid", string data_format = "", (int, int)? dilation_rate = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol DepthwiseConv2D(KerasSymbol x, KerasSymbol depthwise_kernel, (int, int)? strides = null, string padding = "valid", string data_format = "", (int, int)? dilation_rate = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Conv3D(KerasSymbol x, KerasSymbol kernel, (int, int, int)? strides = null, string padding = "valid", string data_format = "", (int, int, int)? dilation_rate = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Conv3DTranspose(KerasSymbol x, KerasSymbol kernel, Shape output_shape, (int, int, int)? strides = null, string padding = "valid", string data_format = "")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Pool2D(KerasSymbol x, (int, int) pool_size, (int, int)? strides = null, string padding = "valid", string data_format = "", string pool_mode = "max")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol Pool3D(KerasSymbol x, (int, int, int) pool_size, (int, int, int)? strides = null, string padding = "valid", string data_format = "", string pool_mode = "max")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol BiasAdd(KerasSymbol x, KerasSymbol bias, string data_format= "channels_last")
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol RandomNormal(Shape shape, float mean = 0, float stddev = 1, DType dtype = null, int? seed = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol RandomUniform(Shape shape, float minval = 0, float maxval = 1, DType dtype = null, int? seed = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol NormalBinomial(Shape shape, float p = 0, DType dtype = null, int? seed = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol TruncatedNormal(Shape shape, float mean = 0, float stddev = 1, DType dtype = null, int? seed = null)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol CTCBatchCost(KerasSymbol y_true, KerasSymbol y_pred, KerasSymbol input_length, KerasSymbol label_length)
        {
            throw new NotImplementedException();
        }

        public static int GetUid(string prefix = "")
        {
            throw new NotImplementedException();
        }

        public static void ResetUids()
        {
            throw new NotImplementedException();
        }

        private static string PrepareName(string name, string @default)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol[] DfsGetBindValues(Symbol node_start)
        {
            throw new NotImplementedException();
        }

        public static KerasSymbol ForwardPass(KerasSymbol x)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol KerasVariable(string name, Shape shape, DType dtype, StorageStype stype= StorageStype.Default, bool is_vector= false)
        {
            throw new NotImplementedException();
        }

        private static DType ConvertStringDType(DType dtype)
        {
            throw new NotImplementedException();
        }

        private static string ConvertDTypeString(DType dtype)
        {
            throw new NotImplementedException();
        }

        private static Shape NormalizeAxis(Shape axis, int ndim)
        {
            throw new NotImplementedException();
        }

        private static void ValidateDataFormat(string data_format)
        {
            throw new NotImplementedException();
        }

        private static void ValidatePoolMode(string pool_mode)
        {
            throw new NotImplementedException();
        }

        private static void ValidatePaddingMode(string padding)
        {
            throw new NotImplementedException();
        }

        private static int CalculateConvOutputSize(int input_length, int filter_size, int padding, int stride,int dilation= 1)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol PreprocessConvNDInput(KerasSymbol data_var, string data_format)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol PreprocessConvNDOutput(KerasSymbol x, string data_format)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol PreprocessConvNDKernel(KerasSymbol kernel, string data_format)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol PreprocessConvDWKernel(KerasSymbol kernel, string data_format)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol PreprocessConvNDTransposeOutput(Shape output_shape, string data_format)
        {
            throw new NotImplementedException();
        }

        private static void ValidateConvInputShape(Shape input_shape)
        {
            throw new NotImplementedException();
        }

        private static int CalculatePaddingRequirement(Shape input_shape, KerasSymbol kernel, int strides, int dilation, string border_mode)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol LayoutKernel(KerasSymbol kernel)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol MxSpConv(KerasSymbol data, int num_in_channel, int num_out_channel, (int, int)? dw_kernel_shape= null,                           KerasSymbol dw_kernel_weight= null, (int,int)? pw_kernel_shape= null, KerasSymbol pw_kernel_weight = null,
                                (int, int)? stride= null, (int, int)? pad = null, string name= "", float depth_mult= 1)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol SpConvNd(KerasSymbol x, KerasSymbol depthwise_kernel, KerasSymbol pointwise_kernel, int[] strides, int[] filter_dilation, string name= "", string padding_mode= "valid", string data_format= "default")
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol DWConv(KerasSymbol x, KerasSymbol kernel, int[] strides, int[] filter_dilation, string name= null, string padding_mode= "valid", string data_format= "default")
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol ConvNd(KerasSymbol x, KerasSymbol kernel, int[] strides, int[] filter_dilation, string name = null, string padding_mode = "valid", string data_format = "default")
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol ConvNdTranspose(KerasSymbol x, KerasSymbol kernel, Shape output_shape, int[] strides, int[] filter_dilation, string name = null, string padding_mode = "valid", string data_format = "default")
        {
            throw new NotImplementedException();
        }

        private static int CalculatePoolOutputSize(int input_length, int filter_size, int padding, int stride, int dilation= 1)
        {
            throw new NotImplementedException();
        }

        private static void ValidatePoolInputShape(Shape input_shape)
        {
            throw new NotImplementedException();
        }

        private static (int, int, int) CalculatePoolPaddingRequirement(string padding_mode, Shape input_shape, int[] kernel, int[] strides)
        {
            throw new NotImplementedException();
        }

        private static KerasSymbol PoolNd(KerasSymbol x, string name, int[] pool_size, int[] strides, string padding_mode= "valid", string data_format= "", string pool_mode= "max")
        {
            throw new NotImplementedException();
        }

        public static Model GetMxNetModelInfo(Model model)
        {
            throw new NotImplementedException();
        }

        public static int GetNumGpus()
        {
            throw new NotImplementedException();
        }

        public static Context[] GetMxNetContexts(Context context)
        {
            throw new NotImplementedException();
        }
    }
}
