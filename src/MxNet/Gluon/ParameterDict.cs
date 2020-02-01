using MxNet.Initializers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon
{
    public class ParameterDict : IEnumerable
    {
        public string Prefix { get; set; }

        internal ParameterDict Shared;

        private Dictionary<string, Parameter> data;

        public ParameterDict(string prefix = "", ParameterDict shared= null)
        {
            throw new NotImplementedException();
        }

        public Parameter this[string name]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public string[] Keys()
        {
            throw new NotImplementedException();
        }

        public Parameter[] Values()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, Parameter> Items()
        {
            throw new NotImplementedException();
        }

        public bool Contains(string key) => data.ContainsKey(key);

        public Constant GetConstant(string name, float value = 0) => throw new NotImplementedException();

        public NDArray Get(string name, Shape shape, Initializers.Initializer init) => throw new NotImplementedException();

        public Constant Update(ParameterDict other) => throw new NotImplementedException();

        public void Initialize(Initializer init= null, Context ctx= null, bool verbose= false, bool force_reinit= false) => throw new NotImplementedException();

        public void ZeroGrad() => throw new NotImplementedException();

        public void ResetCtx(Context ctx) => throw new NotImplementedException();

        public void SetAttr(string name, object value) => throw new NotImplementedException();

        public void Save(string filename, string strip_prefix = "") => throw new NotImplementedException();

        public void Load(string filename, Context ctx= null, bool allow_missing= false,
                        bool ignore_extra= false, string restore_prefix= "", bool cast_dtype= false, string dtype_source= "current") => throw new NotImplementedException();
    }
}
