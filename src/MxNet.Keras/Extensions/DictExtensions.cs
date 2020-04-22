using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace MxNet.Keras
{
    public static class DictExtensions
    {
        public static dynamic BuildCsvObject(this Dictionary<string, float> document)
        {
            dynamic csvObj = new ExpandoObject();

            foreach (var p in document)
            {
                AddProperty(csvObj, p.Key, p.Value);
            }

            return csvObj;
        }

        private static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
            {
                expandoDict[propertyName] = propertyValue;
            }
            else
            {
                expandoDict.Add(propertyName, propertyValue);
            }
        }
    }
}
