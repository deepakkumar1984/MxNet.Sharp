using System.Collections.Generic;

namespace MxNet.Image
{
    public class ColorJitterAug : RandomOrderAug
    {
        public ColorJitterAug(float brightness, float contrast, float saturation) : base(new Augmenter[] { })
        {
            Brightness = brightness;
            Contrast = contrast;
            Saturation = saturation;

            var ts = new List<Augmenter>();
            if (brightness > 0)
                ts.Add(new BrightnessJitterAug(brightness));

            if (contrast > 0)
                ts.Add(new ContrastJitterAug(contrast));

            if (saturation > 0)
                ts.Add(new SaturationJitterAug(saturation));

            Augmenters = ts.ToArray();
        }

        public float Brightness { get; set; }

        public float Contrast { get; set; }

        public float Saturation { get; set; }
    }
}