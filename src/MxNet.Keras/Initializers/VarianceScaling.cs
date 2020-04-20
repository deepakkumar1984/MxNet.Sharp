using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K = MxNet.Keras.MxNetBackend;

namespace MxNet.Keras.Initializers
{
    public class VarianceScaling : Initializer
    {
        private string distribution;

        private string mode;

        private float scale;

        private int? seed;

        public VarianceScaling(float scale= 1, string mode= "fan_in", string distribution= "normal", int? seed= null)
        {
            if (scale <= 0)
            {
                throw new Exception("`scale` must be a positive float. Got:" + scale);
            }

            mode = mode.ToLower();
            if (!(new string[]{ "fan_in", "fan_out", "fan_avg"}).Contains(mode)) {
                throw new Exception("Invalid `mode` argument: expected on of {\"fan_in\", \"fan_out\", \"fan_avg\"} but got " + mode);
            }

            distribution = distribution.ToLower();
            if (!(new string[]{ "normal", "uniform"}).Contains(distribution)) {
                throw new Exception("Invalid `distribution` argument: expected one of {\"normal\", \"uniform\"} but got " + distribution);
            }

            this.scale = scale;
            this.mode = mode;
            this.distribution = distribution;
            this.seed = seed;
        }

        public static (int, int) _compute_fans(Shape shape, string data_format = "channels_last")
        {
            int receptive_field_size;
            int fan_out;
            int fan_in;
            if (shape.Dimension == 2)
            {
                fan_in = shape[0];
                fan_out = shape[1];
            }

            else if ((new int[]{3, 4, 5}).Contains(shape.Dimension)) 
            {
                // Assuming convolution kernels (1D, 2D or 3D).
                // TH kernel shape: (depth, input_depth, ...)
                // TF kernel shape: (..., input_depth, depth)
                if (data_format == "channels_first")
                {
                    receptive_field_size = shape.Data.Skip(2).ToList().Aggregate((a, b) => a * b);
                    fan_in = shape[1] * receptive_field_size;
                    fan_out = shape[0] * receptive_field_size;
                }
                else if (data_format == "channels_last")
                {
                    receptive_field_size = shape.Data.Take(shape.Data.Length - 2).ToList().Aggregate((a, b) => a * b);
                    fan_in = shape[shape.Data.Length - 2] * receptive_field_size;
                    fan_out = shape[shape.Data.Length - 1] * receptive_field_size;
                }
                else
                {
                    throw new Exception("Invalid data_format: " + data_format);
                }
            } 
            else
            {
                // No specific assumptions.
                fan_in = Convert.ToInt32(Math.Sqrt(shape.Size));
                fan_out = Convert.ToInt32(Math.Sqrt(shape.Size));
            }
            return (fan_in, fan_out);
        }

        public override KerasSymbol Call(Shape shape, DType dtype = null)
        {
            var (fan_in, fan_out) = _compute_fans(shape);
            var scale = this.scale;
            if (this.mode == "fan_in")
            {
                scale /= Math.Max(1, fan_in);
            }
            else if (this.mode == "fan_out")
            {
                scale /= Math.Max(1, fan_out);
            }
            else
            {
                scale /= Math.Max(1, (fan_in + fan_out) / 2);
            }
            if (this.distribution == "normal")
            {
                // 0.879... = scipy.stats.truncnorm.std(a=-2, b=2, loc=0., scale=1.)
                float stddev = (float)Math.Sqrt(scale) / 0.8796256610342398f;
                return K.TruncatedNormal(shape, 0, stddev, dtype: dtype, seed: this.seed);
            }
            else
            {
                float limit = (float)Math.Sqrt(3.0 * scale);
                return K.RandomUniform(shape, -limit, limit, dtype: dtype, seed: this.seed);
            }
        }

        public override ConfigDict GetConfig()
        {
            return new ConfigDict{
                {
                    "scale",
                    this.scale},
                {
                    "mode",
                    this.mode},
                {
                    "distribution",
                    this.distribution},
                {
                    "seed",
                    this.seed
                }
            };
        }
    }
}
