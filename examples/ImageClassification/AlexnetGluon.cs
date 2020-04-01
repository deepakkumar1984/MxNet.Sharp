using MxNet;
using MxNet.Gluon.ModelZoo.Vision;
using MxNet.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageClassification
{
    public class AlexnetGluon
    {
        public static void Run()
        {
            var alex_net = AlexNet.GetAlexNet(true);
            var image = Img.ImRead("goldfish.jpg");
            image = Img.ResizeShort(image, 227);
            image = image.AsType(DType.Float32) / 255;
            var normalized = Img.ColorNormalize(image, new NDArray(new[] { 0.485f, 0.456f, 0.406f }),
                new NDArray(new[] { 0.229f, 0.224f, 0.225f }));
            normalized = normalized.Transpose(new Shape(2, 0, 1));
            normalized = normalized.ExpandDims(axis: 0);
            var pred = alex_net.Call(normalized);
            NDArray prob = nd.Softmax(pred).Topk(k: 5);
            var label_index = prob.ArrayData.OfType<float>().ToList();
            var imagenet_labels = TestUtils.GetImagenetLabels();
            foreach (int i in label_index)
            {
                Console.WriteLine(imagenet_labels[i]);
            }
        }
    }
}
