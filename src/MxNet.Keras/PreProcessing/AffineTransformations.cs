using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.PreProcessing
{
    public class AffineTransformations
    {
        public static NDArray FlipAxis(NDArray x, int axis)
        {
            throw new NotImplementedException();
        }

        public static NDArray RandomRotation(NDArray x, float rg, int row_axis= 1, int col_axis= 2, int channel_axis= 0, string fill_mode= "nearest", float cval= 0, int interpolation_order= 1)
        {
            throw new NotImplementedException();
        }

        public static NDArray RandomShift(NDArray x, float wrg, float hrg, int row_axis = 1, int col_axis = 2, int channel_axis = 0, string fill_mode = "nearest", float cval = 0, int interpolation_order = 1)
        {
            throw new NotImplementedException();
        }

        public static NDArray RandomShear(NDArray x, float intensity, int row_axis = 1, int col_axis = 2, int channel_axis = 0, string fill_mode = "nearest", float cval = 0, int interpolation_order = 1)
        {
            throw new NotImplementedException();
        }

        public static NDArray RandomZoom(NDArray x, (float, float) zoom_range, int row_axis = 1, int col_axis = 2, int channel_axis = 0, string fill_mode = "nearest", float cval = 0, int interpolation_order = 1)
        {
            throw new NotImplementedException();
        }

        public static NDArray ApplyChannelShift(NDArray x, float intensity, int channel_axis = 0)
        {
            throw new NotImplementedException();
        }

        public static NDArray RandomChannelShift(NDArray x, (float, float) intensity_range, int channel_axis = 0)
        {
            throw new NotImplementedException();
        }

        public static NDArray ApplyBrightnessShift(NDArray x, float brightness)
        {
            throw new NotImplementedException();
        }

        public static NDArray RandomBrightness(NDArray x, (float, float) brightness_range)
        {
            throw new NotImplementedException();
        }

        public static NDArray TransformMatrixOffsetCenter(NDArray matrix, NDArray x, NDArray y)
        {
            throw new NotImplementedException();
        }

        public static NDArray ApplyAffineTransform(NDArray x, float theta= 0, int tx= 0, int ty= 0, float shear= 0, int zx= 1, int zy= 1,
                           int row_axis= 0, int col_axis= 1, int channel_axis= 2, string fill_mode= "nearest", float cval= 0, int order= 1)
        {
            throw new NotImplementedException();
        }
    }
}
