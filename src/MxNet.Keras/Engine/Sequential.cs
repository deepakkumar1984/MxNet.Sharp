using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Engine
{
    public class Sequential : Model
    {
        private List<Layer> _layers;

        public Layer[] Layers => _layers.ToArray();

        public Model Model { get; set; }

        public Sequential(Layer[] layers = null, string name = "", Context context = null, string kvstore = "device")
            : base(name, context, kvstore)
        {
            throw new NotImplementedException();
        }

        public void Add(Layer l)
        {
            throw new NotImplementedException();
        }

        public Layer Pop()
        {
            throw new NotImplementedException();
        }

        public override void Build(Shape input_shape = null)
        {
            throw new NotImplementedException();
        }

        public NDArray PredictProba(NDArray x, int batch_size= 32, int verbose= 0)
        {
            throw new NotImplementedException();
        }

        public NDArray PredictClasses(NDArray x, int batch_size = 32, int verbose = 0)
        {
            throw new NotImplementedException();
        }

        public override ConfigDict GetConfig()
        {
            throw new NotImplementedException();
        }

        public static Sequential FromConfig(ConfigDict config, CustomObjects custom_objects = null)
        {
            throw new NotImplementedException();
        }
    }
}
