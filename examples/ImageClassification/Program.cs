using MxNet;
using MxNet.Gluon.ModelZoo.Vision;
using MxNet.Image;
using System;
using System.Linq;
namespace ImageClassification
{
    class Program
    {
        static void Main(string[] args)
        {
            AlexNet alex_net = AlexNet.GetAlexNet(pretrained: true);
            var image = Img.ImRead("test1.jpg");
            //image = Img.ImResize(image, 227, 227);
            image = image / 255;
            var normalized = Img.ColorNormalize(image, new NDArray(new float[] { 0.485f, 0.456f, 0.406f }), new NDArray(new float[] { 0.229f, 0.224f, 0.225f }));
            var pred = alex_net.Call(image);
            var prob = nd.Softmax(pred);
            var ind = nd.Topk(prob, k: 5).AsArray<float>().OfType<float>();

        }
    }
}
