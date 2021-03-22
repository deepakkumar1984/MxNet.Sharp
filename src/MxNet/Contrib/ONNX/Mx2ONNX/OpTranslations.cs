using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Contrib.ONNX.Mx2ONNX
{
    public class OpTranslations
    {
        public static T ParseHelper<T>(Dictionary<string, object> attrs, string attrs_name, T alt_value= default(T))
        {
            throw new NotImplementedRelease2Exception();
        }

        public static int TransformPadding(int pad_width)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static string[] ConvertStringToList(string string_val)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static int GetBooleanAttributeValue(Dictionary<string, object> attrs, string attr_name)
        {
            throw new NotImplementedRelease2Exception();
        }

        public  static (string, dynamic[], Dictionary<string,object>) GetInputs(dynamic node, FuncArgs kwargs, bool with_shapes= false)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic CreateBasicOpNode(string op_name, dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertWeightsAndInputs(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertConvolution(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertDeconvolution(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertCrop(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertFullyConnected(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertBatchNorm(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertTanh(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertCos(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertSin(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertTan(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertAcos(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertAsin(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertAtan(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertSigmoid(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertRelu(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertActivation(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertPad(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic CreateHelperTensorNode(NDArray input_vals, string output_name, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic CreateHelperReshapeNode(string input_name, string output_name, Shape shape, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic CreateHelperTransNode(string input_name, string output_name, int[] perm = null)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic CreateHelperConcatNode(NDArrayList inputs, string output_name, int axis=0)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic CreateHelperExpandNode(string input_name, string output_name, Shape expand_shape)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic CreateHelperGatherNode(string input_name, string output_name, NDArray indices, FuncArgs kwargs, int? axis = null)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic CreateHelperBuildValuesNode(NDArrayList inputs, string output_name, DType dtype, FuncArgs kwargs, int axis = 0)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic CreateHelperShapeNode(string input_name, string output_name)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertDot(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }


        public static dynamic ConvertLinalgGemm2(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertPooling(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertExp(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertCopy(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertIdentity(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertInstantNorm(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertLeakyRelu(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertSoftmax(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertBlockgrad(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertMakeloss(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertConcat(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertRNN(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertRNNParamConcat(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertFull(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertTranspose(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertLrn(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertL2Normalization(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertDropout(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertFlatten(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertClip(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic scalar_op_helper(dynamic node, string op_name, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertMulscalar(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertMinusScalar(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertRminusScalar(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertAddScalar(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertDivScalar(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertRdivScalar(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertPowScalar(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertArgmax(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertArgmin(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertMaximum(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertMinimum(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertMin(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertMax(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertMean(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertProd(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertElementwiseAdd(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertBroadcastAdd(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertElementwiseSub(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertBroadcastSub(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertElementwiseMul(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertBroadcastMul(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertElementwiseDiv(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertBroadcastDiv(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertNegative(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertAbs(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertAddN(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertFloor(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertReshape(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertCast(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertSliceAxis(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertSliceChannel(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertExpandDims(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertSqueeze(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertLog(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertReciprocal(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertPower(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertBroatcastPower(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertDepthToSpace(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertSpaceToDepth(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertSquare(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertSum(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertShape(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertHardSigmoid(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }
        public static dynamic ConvertBroatcastGreater(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertBroatcastLesser(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertBroatcastEqual(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertBroatcastLogicalAnd(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertBroatcastLogicalOr(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertBroatcastLogicalXor(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertLogicalNot(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertSize(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertLogSoftmax(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertNorm(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertMultinomial(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertRandomNormal(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertROIPooling(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertTile(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertBroatcastTo(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertTopK(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }

        public static dynamic ConvertTake(dynamic node, FuncArgs kwargs)
        {
            throw new NotImplementedRelease2Exception();
        }
    }
}
