using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class CSVLogger : Callback
    {
        public Dictionary<string, string> _open_args;

        public bool append;

        public bool append_header;

        public FileStream csv_file;

        public string file_flags;

        public string filename;

        public object keys;

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
            object mode;
            if (this.append)
            {
                if (File.Exists(this.filename))
                {
                    append_header = File.ReadAllLines(filename).Length > 0;
                }
                
                mode = "a";
            }
            else
            {
                mode = "w";
            }

            this.csv_file = File.OpenWrite(filename);
        }

        public override void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            throw new NotImplementedException();
        }

        public override void OnTrainEnd(Dictionary<string, float> logs = null)
        {
            csv_file.Close();
            writer = null;
        }
    }
}
