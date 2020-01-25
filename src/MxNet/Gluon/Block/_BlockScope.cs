using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon
{
    public class _BlockScope : MxDisposable
    {
        public _BlockScope(Block block) : base()
        {

        }

        public static (string, ParameterDict) Create(string prefix, ParameterDict @params, string hint) => throw new NotImplementedException();

        public override void Enter()
        {
            throw new NotImplementedException();
        }

        public override void Exit()
        {
            throw new NotImplementedException();
        }
    }
}
