using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class CSVLogger : Callback
    {
        public Dictionary<string, string> _open_args;

        public bool append;

        public bool append_header;

        public TextWriter csv_file;

        public string file_flags;

        public string filename;

        public string[] keys;

        public string sep;

        public CsvWriter writer;

        public CSVLogger(string filename, string separator= ",", bool append= false)
        {
            this.sep = separator;
            this.filename = filename;
            this.append = append;
            this.writer = null;
            this.keys = null;
            this.append_header = true;
            this.file_flags = "";
            this._open_args = new Dictionary<string, string> {
                    {
                        "newline",
                        "\n"
                    }
            };
        }

        public override void OnTrainBegin(Dictionary<string, float> logs = null)
        {
            if (this.append)
            {
                if (File.Exists(this.filename))
                {
                    this.append_header = !(File.ReadAllLines(filename).Length > 0);
                }
            }

            csv_file = File.AppendText(filename);
        }

        public override void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            logs = logs != null ? logs : new Dictionary<string, float>();
            if (this.keys == null)
            {
                this.keys = logs.Keys.OrderBy(_p_1 => _p_1).ToArray();
            }

            if (this.model.stop_training)
            {
                foreach (var k in keys)
                {
                    if (!logs.ContainsKey(k))
                        logs.Add(k, float.NaN);
                }

            }

            if (this.writer != null)
            {
                var fieldnames = new List<string> {
                    "epoch"
                };

                logs.Add("epoch", epoch);
                fieldnames.AddRange(this.keys);
                this.writer = new CsvWriter(csv_file, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = "," });

                dynamic logsDyno = logs.BuildCsvObject();
                if (this.append_header)
                {
                    writer.WriteDynamicHeader(logsDyno);
                    writer.NextRecord();
                }

                this.writer.WriteRecords(logs.Values);
            }
        }

        public override void OnTrainEnd(Dictionary<string, float> logs = null)
        {
            csv_file.Close();
            writer = null;
        }
    }
}
