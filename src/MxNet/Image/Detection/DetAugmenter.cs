using Newtonsoft.Json;

namespace MxNet.Image
{
    public abstract class DetAugmenter
    {
        public virtual string Dumps()
        {
            return JsonConvert.SerializeObject(this);
        }

        public abstract (NDArray, NDArray) Call(NDArray src, NDArray label);
    }
}