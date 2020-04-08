using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.PreProcessing
{
    public class ImageUtils
    {
        public static bool  ValidateFilename(string filename, string[] white_list_formats)
        {
            throw new NotImplementedException();
        }

        public static void SaveImg(string path, NDArray x, string data_format= "channels_last", string file_format= "", bool scale= true)
        {
            throw new NotImplementedException();
        }

        public static NDArray LoadImg(string path, bool grayscale= false, string color_mode= "rgb", (int, int)? target_size= null, string interpolation= "nearest")
        {
            throw new NotImplementedException();
        }

        public static string[] ListPictures(string directory, string ext = "jpg,jpeg,bmp,png,ppm,tif,tiff")
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<(string, string)> IterValidFiles(string directory, string[] white_list_formats, bool follow_links)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<(string, string)> ListValidFilenameInDirectory(string directory, string[] white_list_formats, (float, float)split, Dictionary<string, int> class_indines, bool follow_links)
        {
            throw new NotImplementedException();
        }

        public static Mat ArrayToImg(NDArray x, string data_format = "channels_last", bool scale= true, DType dtype = null)
        {
            throw new NotImplementedException();
        }

        public static NDArray ImgToArray(Mat img, string data_format = "channels_last", DType dtype = null)
        {
            throw new NotImplementedException();
        }
    }
}
