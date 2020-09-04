using MxNet.IO;
using MxNet.Keras.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MxNet.Keras.Engine
{
    public class Saving
    {
        public static (string[], DataDesc[]) SaveMxnetModel(Model model, string prefix, int epoch= 0)
        {
            Debug.Assert(model != null, "MXNet Backend: Invalid state. Model cannot be None.");
            if (!model.compiled)
            {
                throw new Exception("MXNet Backend: Model is not compiled. Cannot save the MXNet model!");
            }
            // Saving MXNet model for Inference in native MXNet engine.
            var symbol = model._pred_mxnet_symbol;
            var module = model._module;
            Debug.Assert(symbol != null, "MXNet Backend: Invalid state. MXNet Symbol cannot be None.");
            Debug.Assert(module != null, "MXNet Backend: Invalid state. MXNet Module cannot be None.");
            // Get Module Input data_names and data_shapes.
            // This info will be useful for users to easily bind the exported model in MXNet.
            var pred_module = module._buckets[2];
            var data_names = pred_module.DataNames;
            var data_shapes = pred_module.DataShapes;
            var symbol_fname = String.Format("%s-symbol.json", prefix);
            var params_fname = String.Format("%s-%04d.params", prefix, epoch);
            symbol.Save(symbol_fname);
            module.SaveParams(params_fname);
            Console.WriteLine("MXNet Backend: Successfully exported the model as MXNet model!");
            Console.WriteLine("MXNet symbol file - ", symbol_fname);
            Console.WriteLine("MXNet params file - ", params_fname);
            Console.WriteLine("\n\nModel input data_names and data_shapes are: ");
            Console.WriteLine("data_names : ", data_names);
            Console.WriteLine("data_shapes : ", data_shapes);
            Console.WriteLine("\n\nNote: In the above data_shapes, the first dimension represent the batch_size used for model training. ");
            Console.WriteLine("You can change the batch_size for binding the module based on your inference batch_size.");
            return (data_names, data_shapes);
        }

        private static void SerializeModel(Model model, H5Dict f, bool include_optimizer= true)
        {
            throw new NotImplementedException();
        }

        private static Model DeserializeModel(H5Dict f, CustomObjects custom_objects = null, bool compile = true)
        {
            throw new NotImplementedException();
        }

        public static void SaveModel(Network model, string filepath, bool overwrite = true, bool include_optimizer = true)
        {
            throw new NotImplementedException();
        }

        public static Model LoadModel(string filepath, CustomObjects custom_objects= null, bool compile= true)
        {
            throw new NotImplementedException();
        }

        public static H5Dict PickleModel(Model model)
        {
            throw new NotImplementedException();
        }

        public static Model UnpickleModel(H5Dict state)
        {
            throw new NotImplementedException();
        }

        public static Model ModelFromConfig(ConfigDict config, CustomObjects custom_objects= null)
        {
            throw new NotImplementedException();
        }

        public static Model ModelFromYaml(string yaml_string, CustomObjects custom_objects = null)
        {
            throw new NotImplementedException();
        }

        public static Model ModelFromJson(string json_string, CustomObjects custom_objects = null)
        {
            throw new NotImplementedException();
        }

        public static void SaveAttributesToHDF5Group(IntPtr group, string name, Array data)
        {
            throw new NotImplementedException();
        }

        public static Array LoadAttributesFromHDF5Group(IntPtr group, string name)
        {
            throw new NotImplementedException();
        }

        public static void SaveWeightsToHdf5Group(H5Dict f, Layer[] layers)
        {
            throw new NotImplementedException();
        }

        public static NDArrayList PreprocessWeightsForLoading(Layer layer, NDArrayList weights, string original_keras_version= null, string original_backend= null, bool reshape= false)
        {
            throw new NotImplementedException();
        }

        private static NDArrayList ConvertRNNWeights(Layer layer, NDArrayList weights)
        {
            throw new NotImplementedException();
        }

        public static void LoadWeightsFromHdf5Group(H5Dict f, Layer[] layers, bool reshape= false)
        {
            throw new NotImplementedException();
        }

        public static void LoadWeightsFromHdf5GroupByName(H5Dict f, Layer[] layers, bool skip_mismatch = false, bool reshape = false)
        {
            throw new NotImplementedException();
        }
    }
}
