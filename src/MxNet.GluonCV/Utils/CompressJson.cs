using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace MxNet.GluonCV.Utils
{
    public class CompressJson
    {
        public static string EncodeJson(string json_file, bool is_print = false)
        {
            string data;
            using (var fh = File.OpenText(json_file))
            {
                data = fh.ReadToEnd();
            }

            var zipped_str = new GZipStream(new MemoryStream(Encoding.UTF8.GetBytes(data)), CompressionMode.Compress);
            
            byte[] zipped_data = new byte[zipped_str.Length];
            zipped_str.Read(zipped_data, 0, zipped_data.Length);
            var b64_str = Convert.ToBase64String(zipped_data);
            if (is_print)
            {
                Console.WriteLine(b64_str);
            }

            return b64_str;
        }

        public static string DecodeB64(string b64_str, bool is_print = false)
        {
            byte[] data = Convert.FromBase64String(b64_str);
            var decomp_str = new GZipStream(new MemoryStream(data), CompressionMode.Decompress);
            byte[] decomp_data = new byte[decomp_str.Length];
            decomp_str.Read(decomp_data, 0, decomp_data.Length);
            return Encoding.UTF8.GetString(decomp_data);
        }

        public static string GetCompressedModel(string model_name, Dictionary<string, string> compressed_json)
        {
            var b64_str = compressed_json.ContainsKey(model_name) ? compressed_json[model_name] : "";
            if (!string.IsNullOrEmpty(b64_str))
            {
                return DecodeB64(b64_str);
            }

            throw new Exception($"Model: {model_name} is not found. Available compressed models are:\n");
        }
    }
}
