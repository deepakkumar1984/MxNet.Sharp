using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet
{
    public abstract class CustomOpProp
    {
        public CustomOpProp(bool need_top_grad = true)
        {
            throw new NotImplementedException();
        }

        public virtual (Shape[], Shape[], Shape[]) InferShape(Shape[] in_shape)
        {
            throw new NotImplementedException();
        }

        public virtual (DType[], DType[], DType[]) InferType(DType[] in_type)
        {
            throw new NotImplementedException();
        }

        public virtual (StorageStype[], StorageStype[], StorageStype[]) InferStorageType(StorageStype[] in_stype)
        {
            throw new NotImplementedException();
        }

        public virtual (StorageStype[], StorageStype[], StorageStype[], StorageStype[], StorageStype[]) InferStorageType(StorageStype[] ograd_stype, StorageStype[] in_stype, StorageStype[] out_stype, StorageStype[] igrad_stype, StorageStype[] aux_stype)
        {
            throw new NotImplementedException();
        }

        public virtual string[] ListOutputs()
        {
            return new string[] { "output" };
        }

        public virtual string[] ListArguments()
        {
            return new string[] { "data" };
        }

        public virtual int[] DeclareBackwardDependency(int[] out_grad, int[] in_data, int[] out_data)
        {
            throw new NotImplementedException();
        }
    }
}
