using MxNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Utils.Data
{
    public class Tracking
    {
        public static int[] CropHWC(NDArray image, int[] bbox, int out_sz, (int, int, int) padding = default)
        {
            throw new NotImplementedException();
        }

        public static int[] PosS2BBox(int[] pos, int s)
        {
            throw new NotImplementedException();
        }

        public static (int, int) CropLikeSiamFC(NDArray image, int[] bbox, float context_amount = 0.5f, int exemplar_size = 127, int instance_size = 255, (int, int, int) padding = default)
        {
            throw new NotImplementedException();
        }

        public static void PrintProgress(int iteration, int total, string prefix = "", string suffix = "", int decimals = 1, int barLength = 100)
        {
            throw new NotImplementedException();
        }
    }
}
