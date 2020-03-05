namespace MxNet.Image
{
    public class RandomOrderAug : Augmenter
    {
        public RandomOrderAug(Augmenter[] ts)
        {
            Augmenters = ts;
        }

        public Augmenter[] Augmenters { get; set; }

        public override NDArray Call(NDArray src)
        {
            Augmenters.Shuffle();
            foreach (var aug in Augmenters) src = aug.Call(src);

            return src;
        }
    }
}