using MxNet;
using MxNet.Image;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.GluonCV.Data
{
    public class SegmentationDataset : VisionDataset
    {
        public int BaseSize;

        public int CropSize;

        public string Mode;

        public string Root;

        public string Split;

        public Func<NDArray, NDArray> Transform;

        public SegmentationDataset(string root, string split, string mode, Func<NDArray, NDArray> transform, int base_size= 520, int crop_size= 480)
            : base(root)
        {
            this.Root = root;
            this.Transform = transform;
            this.Split = split;
            this.Mode = mode != null ? mode : split;
            this.BaseSize = base_size;
            this.CropSize = crop_size;
        }

        internal (NDArray, NDArray) ValSyncTransform(NDArray img, NDArray mask)
        {
            int ow;
            int oh;
            var outsize = this.CropSize;
            var short_size = outsize;
            var w = img.Shape[1];
            var h = img.Shape[2];
            if (w > h)
            {
                oh = short_size;
                ow = Convert.ToInt32(1 * w * oh / h);
            }
            else
            {
                ow = short_size;
                oh = Convert.ToInt32(1.0 * h * ow / w);
            }
            img = Img.ImResize(img, ow, oh, ImgInterp.Bilinear);
            mask = Img.ImResize(mask, ow, oh, ImgInterp.Nearest_Neighbors);
            // center crop
            w = img.Shape[1];
            h = img.Shape[2];
            var x1 = Convert.ToInt32(Math.Round((w - outsize) / 2.0));
            var y1 = Convert.ToInt32(Math.Round((h - outsize) / 2.0));
            img = Img.FixedCrop(img, x1, y1, x1 + outsize, y1 + outsize);
            mask = Img.FixedCrop(mask, x1, y1, x1 + outsize, y1 + outsize);
            // final transform
            img = this.ImgTransform(img);
            mask = this.MaskTransform(mask);
            return (img, mask);
        }

        internal (NDArray, NDArray) SyncTransform(NDArray img, NDArray mask)
        {
            int short_size;
            int ow;
            int oh;
            // random mirror
            if (new Random().NextDouble() < 0.5)
            {
                img = img.Transpose(new Shape(0, 2, 1));
                mask = mask.Transpose(new Shape(0, 2, 1));
            }

            // random scale (short edge)
            var long_size = new Random().Next(Convert.ToInt32(this.BaseSize * 0.5), Convert.ToInt32(this.BaseSize * 2.0));
            var w = img.Shape[1];
            var h = img.Shape[2];
            if (h > w)
            {
                oh = long_size;
                ow = Convert.ToInt32(1.0 * w * long_size / h + 0.5);
                short_size = ow;
            }
            else
            {
                ow = long_size;
                oh = Convert.ToInt32(1.0 * h * long_size / w + 0.5);
                short_size = oh;
            }
            img = Img.ImResize(img, ow, oh, ImgInterp.Bilinear);
            mask = Img.ImResize(mask, ow, oh, ImgInterp.Nearest_Neighbors);
            // pad crop
            if (short_size < CropSize)
            {
                var padh = oh < CropSize ? CropSize - oh : 0;
                var padw = ow < CropSize ? CropSize - ow : 0;
                
                img = nd.Pad(img, PadMode.Constant, new Shape(0, 0, padw, padh), constant_value: 0);
                mask = nd.Pad(mask, PadMode.Constant, new Shape(0, 0, padw, padh), constant_value: 0);
            }

            // random crop crop_size
            w = img.Shape[1];
            h = img.Shape[2];
            var x1 = new Random().Next(0, w - CropSize);
            var y1 = new Random().Next(0, h - CropSize);
            img = Img.FixedCrop(img, x1, y1, x1 + CropSize, y1 + CropSize);
            mask = Img.FixedCrop(mask, x1, y1, x1 + CropSize, y1 + CropSize);
            // gaussian blur as in PSP
            if (new Random().NextDouble() < 0.5)
            {
                //img = img.filter(ImageFilter.GaussianBlur(radius: random.random())); //ToDo: Implement GaussianBlur
            }
            // final transform
            img = this.ImgTransform(img);
            mask = this.MaskTransform(mask);
            return (img, mask);
        }

        internal NDArray ImgTransform(NDArray img)
        {
            return img.AsInContext(mx.Cpu());
        }

        internal virtual NDArray MaskTransform(NDArray mask)
        {
            return mask.AsInContext(mx.Cpu()).AsType(DType.Int32);
        }

        public override int NumClass => NumClass;

        public virtual int PredOffset => 0;

        public static NDArrayList MsBatchifyFn(NDArrayList data) => throw new NotImplementedException();
    }
}
