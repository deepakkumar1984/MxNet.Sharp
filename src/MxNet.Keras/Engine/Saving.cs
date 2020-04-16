using MxNet.Keras.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Keras.Engine
{
    public class Saving
    {
        public static void SaveMxnetModel(Model model, int prefix, int epoch= 0)
        {
            throw new NotImplementedException();
        }

        private static void SerializeModel(Model model, H5Dict f, bool include_optimizer= true)
        {
            throw new NotImplementedException();
        }

        private static Model DeserializeModel(H5Dict f, CustomObjects custom_objects = null, bool compile = true)
        {
            throw new NotImplementedException();
        }

        public static void SaveModel(Model model, string filepath, bool overwrite = true, bool include_optimizer = true)
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
