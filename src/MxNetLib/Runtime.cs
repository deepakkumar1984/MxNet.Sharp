using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNetLib
{
    public class Runtime
    {
        public static Features FeatureList() => throw new NotImplementedException();

        public class Feature
        {
            public string Name { get; set; }

            public bool Enabled { get; set; }

            public override string ToString()
            {
                if (Enabled)
                {
                    return string.Format("✔ {0}", Name);
                }
                else
                {
                    return string.Format("✖ {0}", Name);
                }
            }
        }

        public class Features
        {
            private List<Feature> _features;
            public Features(params Feature[] features)
            {
                _features = features.ToList();
            }

            public bool IsEnabled(string name)
            {
                var f = _features.FirstOrDefault(x => (x.Name == name));
                if (f != null)
                    return f.Enabled;

                return false;
            }
        }
    }
}
