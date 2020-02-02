using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet
{
    internal class Assert
    {
        public static void IsNull(string name, object obj, string message = "")
        {
            if (obj == null)
                throw new ArgumentException(string.IsNullOrWhiteSpace(message) ? name : message);
        }

        public static void IsEqual(string name, object obj, object obj1, string message = "")
        {
            if (obj != obj1)
                throw new ArgumentException(string.IsNullOrWhiteSpace(message) ? name : message);
        }

        public static void InList(string name, string value, string[] options, string message = "")
        {
            if(!options.Contains(value))
            {
                throw new ArgumentException(string.IsNullOrWhiteSpace(message) ? $"{name} is not in {string.Join(",", options)}" : message);
            }
        }

        public static void InList(string name, int value, int[] options, string message = "")
        {
            if (!options.Contains(value))
            {
                throw new ArgumentException(string.IsNullOrWhiteSpace(message) ? $"{name} is not in {string.Join(",", options)}" : message);
            }
        }

        public static void InList(string name, uint value, uint[] options, string message = "")
        {
            if (!options.Contains(value))
            {
                throw new ArgumentException(string.IsNullOrWhiteSpace(message) ? $"{name} is not in {string.Join(",", options)}" : message);
            }
        }
    }
}
