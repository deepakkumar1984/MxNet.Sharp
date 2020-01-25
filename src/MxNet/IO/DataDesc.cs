using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.IO
{
    public class DataDesc
    {
        public string Name { get; set; }

        public Shape Shape { get; set; }

        public DType DataType { get; set; }

        public string Layout { get; set; }

        public DataDesc(string name, Shape shape, DType dtype= null, string layout= "NCHW'")
        {
            Name = name;
            Shape = shape;
            DataType = dtype ?? DType.Float32;
            Layout = layout;
        }

        public override string ToString()
        {
            return string.Format("DataDesc[{0}, {1}, {2}, {3}]", Name, Shape, DataType, Layout);
        }

        public static int GetBatchAxis(string layout)
        {
            if (string.IsNullOrWhiteSpace(layout))
                return 0;

            return layout.ToCharArray().ToList().FindIndex(x => x == 'N');
        }

        public static DataDesc[] GetList(Dictionary<string, Shape> shapes, Dictionary<string, DType> types = null)
        {
            List<DataDesc> result = new List<DataDesc>();

            if(types!=null)
            {
                foreach (var item in shapes)
                {
                    result.Add(new DataDesc(item.Key, item.Value, types[item.Key]));
                }
            }
            else
            {
                foreach (var item in shapes)
                {
                    result.Add(new DataDesc(item.Key, item.Value));
                }
            }

            return result.ToArray();
        }
    }
}
