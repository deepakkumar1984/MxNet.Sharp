using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNetLib.Gluon
{
    public class Block
    {
        public Block(string prefix, ParameterDict @params)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public void SetAttr<T>(string name, T value)
        {
            throw new NotImplementedException();
        }

        public virtual string Alias() => throw new NotImplementedException();

        private void CheckContainerWithBlock() => throw new NotImplementedException();

        private ParameterDict CollectParamsWithPrefix() => throw new NotImplementedException();

        public void SaveParameters(string filename, bool deduplicate = false) => throw new NotImplementedException();

        public void LoadParameters(string filename, Context ctx= null, bool allow_missing= false,
                        bool ignore_extra= false, bool cast_dtype= false, string dtype_source= "current") => throw new NotImplementedException();

        public void RegisterChild(Block block, string name) => throw new NotImplementedException();
    }
}
