using System;
using MxNet;
using MxNet.Gluon;
using MxNet.Gluon.NN;
using MxNet.GluonCV.Data.Transforms.Presets;
using MxNet.Image;
using NumpyDotNet;
using OpenCvSharp;

namespace ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var im_fname = Utils.Download("https://raw.githubusercontent.com/zhreshold/mxnet-ssd/master/data/demo/dog.jpg", "dog.jpg");
            var (x_img, img) = Yolo.LoadTest(im_fname, @short: 416);
            Img.ImShow(img);
            Console.ReadLine();
        }
    }
}