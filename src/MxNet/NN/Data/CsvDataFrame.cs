using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using MxNet;

namespace MxNet.NN.Data
{
    public class CsvDataFrame : DataFrame
    {
        public List<string> Columns { get; set; }

        private string _path = string.Empty;

        private bool _hasHeaders;

        private string _delimiter;

        private Encoding _encoding;

        public CsvDataFrame(string path , bool hasHeaders = false, string delimiter = ",", Encoding encoding = null)
            : base(2)
        {
            _path = path;
            _hasHeaders = hasHeaders;
            _delimiter = delimiter;
            _encoding = encoding;
        }

        public void ReadCsv()
        {
            List<float> data = new List<float>();
            using (TextReader fileReader = File.OpenText(_path))
            {
                var csv = new CsvReader(fileReader);
                csv.Configuration.Delimiter = _delimiter;
                csv.Configuration.HasHeaderRecord = _hasHeaders;

                if (_encoding != null)
                    csv.Configuration.Encoding = _encoding;

                if(_hasHeaders)
                {
                    string[] columnNames = csv.Parser.Read();
                    Shape[1] = (uint)columnNames.Length;
                    Columns = columnNames.ToList();
                }

                while (csv.Read())
                {
                    string[] rowData = csv.Parser.Context.Record;
                    if (Shape[1] == 0)
                    {
                        Shape[1] = (uint)rowData.Length;
                    }

                    foreach (string item in rowData)
                    {
                        DataList.Add(float.Parse(item));
                    }
                }
            }

            Shape[0] = (uint)DataList.Count / Shape[1];

            GenerateVariable();
        }
    }
}
