using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.ModelZoo.Rpn
{
    public class BBoxClipToImageProp : CustomOpProp
    {
        public BBoxClipToImageProp(int axis = -1) : base(true)
        {
            throw new NotImplementedException();
        }

        public override string[] ListArguments()
        {
            throw new NotImplementedException();
        }

        public override string[] ListOutputs()
        {
            throw new NotImplementedException();
        }

        public override (Shape[], Shape[], Shape[]) InferShape(Shape in_shape)
        {
            throw new NotImplementedException();
        }

        public override (DType[], DType[], DType[]) InferType(DType in_type)
        {
            throw new NotImplementedException();
        }

        public BBoxClipToImageProp CreateOperator(Context ctx, Shape[] in_shapes, DType[] in_dtypes)
        {
            throw new NotImplementedException();
        }
    }
}
