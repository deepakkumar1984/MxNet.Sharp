using System.Linq;
using MxNet;
using MxNet.Gluon.ModelZoo.Vision;
using MxNet.Image;

namespace ImageClassification
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var alex_net = AlexNet.GetAlexNet(true);
            var image = Img.ImRead("test1.jpg").AsType(DType.Float32);
            image = Img.ResizeShort(image, 256);
            image = image / 255;
            var normalized = Img.ColorNormalize(image, new NDArray(new[] {0.485f, 0.456f, 0.406f}),
                new NDArray(new[] {0.229f, 0.224f, 0.225f}));
            var pred = alex_net.Call(image);
            var prob = nd.Softmax(pred);
            var ind = nd.Topk(prob, k: 5).AsArray<float>().OfType<float>();
        }
    }
}