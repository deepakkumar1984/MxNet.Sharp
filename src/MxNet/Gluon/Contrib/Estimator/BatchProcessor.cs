using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.Contrib
{
    public class BatchProcessor
    {
        public (NDArray, NDArray) GetDataAndLabel(int batch, Context ctx, int batch_axis = 0)
        {
            throw new NotImplementedRelease1Exception();
        }

        public (NDArray, NDArray, NDArray, NDArray) FitBatch(Estimator estimator, (NDArray, NDArray) train_batch, int batch_axis = 0)
        {
            throw new NotImplementedRelease1Exception();
        }

        public (NDArray, NDArray, NDArray, NDArray) EvaluateBatch(Estimator estimator, (NDArray, NDArray) val_batch, int batch_axis = 0)
        {
            throw new NotImplementedRelease1Exception();
        }
    }
}
