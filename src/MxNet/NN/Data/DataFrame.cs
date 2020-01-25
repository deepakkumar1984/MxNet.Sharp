using MxNet;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using CsvHelper;

namespace MxNet.NN.Data
{
    public class DataFrame
    {
        public List<float> DataList = new List<float>();

        internal uint[] Shape;

        internal NDArray variable;

        internal DataFrame()
        {

        }

        public DataFrame(int dims)
        {
            Shape = new uint[dims];
        }

        public void Load(params float[] data)
        {
            DataList.AddRange(data);
        }

        internal virtual void GenerateVariable()
        {
            if (DataList.Count == 0)
                throw new Exception("No data to generate variable. Please add data using AddData method");

            variable = new NDArray(DataList.ToArray(), new Shape(Shape));
        }

        public NDArray ToVariable()
        {
            GenerateVariable();
            return variable;
        }

        public NDArray this[int start, int? end]
        {
            get
            {
                return variable.SliceAxis(1, start, end);
            }
        }
    }
}
