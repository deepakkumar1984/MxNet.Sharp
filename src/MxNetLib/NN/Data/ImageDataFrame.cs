using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNetLib.NN.Data
{
    public class ImageDataFrame : DataFrame
    {
        private int imgWidth = 0;
        private int imgHeight = 0;
        private int imgChannel = 0;
        private int n = 0;

        public ImageDataFrame(uint channel, uint width, uint height) : base(3)
        {
            Shape[0] = channel;
            Shape[1] = width;
            Shape[2] = height;

            imgWidth = (int)width;
            imgHeight = (int)height;
            imgChannel = (int)channel;
        }

        public void LoadImages(params string[] files)
        {
            foreach (var item in files)
            {
                var d = ReadData(item, imgWidth, imgHeight);
                foreach (var i in d)
                {
                    DataList.Add(i);
                }

                n++;
            }
        }

        private void LoadImages(string folder, int? width = null, int? height = null, string filter = "*.*")
        {
            
        }

        private float[] ReadData(string filename, int? width = null, int? height = null)
        {
            ImreadModes mode = ImreadModes.Color;
            float[] imdata = new float[imgChannel * imgWidth * imgHeight];
            if (imgChannel == 1)
            {
                mode = ImreadModes.Grayscale;
            }
            
            using (Mat im = Cv2.ImRead(filename, mode))
            {
                var byteData = new byte[imgChannel * imgWidth * imgHeight];
                var resizedim = im.Resize(new Size(width.Value, height.Value));
                resizedim.ConvertTo(resizedim, MatType.CV_32F);
                resizedim.GetArray(0, 0, imdata);
            }

            return imdata;
        }

        internal override void GenerateVariable()
        {
            variable = new NDArray(DataList, new Shape((uint)n, (uint)imgChannel, (uint)imgWidth, (uint)imgHeight));
        }
    }
}
