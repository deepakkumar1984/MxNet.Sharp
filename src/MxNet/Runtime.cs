using MxNet.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace MxNet
{
    public struct LibFeature
    {
        public string name;
        public bool enabled;
    }

    public class Runtime
    {
        public static Features FeatureList()
        {
            List<Feature> featuresList = new List<Feature>();
            
            NativeMethods.MXLibInfoFeatures(out var intPtr, out int size);
            int objsize = Marshal.SizeOf(typeof(LibFeature));
            if (size > 0)
            {
                for(int i = 0;i<size;i++)
                {
                    var f = (LibFeature)Marshal.PtrToStructure(intPtr, typeof(LibFeature));
                    intPtr += objsize;
                    featuresList.Add(new Feature() { Enabled = f.enabled, Name = f.name });
                }
            }

            return new Features(featuresList.ToArray());
        }

        public class Feature
        {
            public string Name { get; set; }

            public bool Enabled { get; set; }

            public override string ToString()
            {
                if (Enabled)
                    return string.Format("✔ {0}", Name);
                return string.Format("✖ {0}", Name);
            }
        }

        public class Features
        {
            private readonly List<Feature> _features;

            public Features(params Feature[] features)
            {
                _features = features.ToList();
            }

            public bool IsEnabled(string name)
            {
                var f = _features.FirstOrDefault(x => x.Name == name);
                if (f != null)
                    return f.Enabled;

                return false;
            }
        }
    }
}