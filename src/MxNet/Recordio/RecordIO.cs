using System;
using OpenCvSharp;

namespace MxNet.Recordio
{
    public class IRHeader
    {
        public IRHeader(int flag, float label, int id, int id2)
        {
            Flag = flag;
            Label = label;
            ID = id;
            ID2 = id2;
        }

        public int Flag { get; set; }

        public float Label { get; set; }

        public int ID { get; set; }

        public int ID2 { get; set; }
    }

    public class RecordIO
    {
        public static string Pack(IRHeader header, string s)
        {
            throw new NotImplementedException();
        }

        public static (IRHeader, string) UnPack(string s)
        {
            throw new NotImplementedException();
        }

        public static (IRHeader, NumSharp.NDArray) UnpackImg(string s, ImreadModes iscolor)
        {
            throw new NotImplementedException();
        }

        public static string PackImg(IRHeader header, NumSharp.NDArray img, int quality = 95, string img_fmt = ".jpg")
        {
            throw new NotImplementedException();
        }
    }
}