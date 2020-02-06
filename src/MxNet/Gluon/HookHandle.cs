using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MxNet.Gluon.Block;

namespace MxNet.Gluon
{
    public class HookHandle : MxDisposable
    {
        public WeakReference State
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

        public HookHandle() : base()
        {
            throw new NotImplementedException();
        }

        public void Attach(SortedDictionary<string, Hook> hooks_dict, Hook hook) => throw new NotImplementedException();

        public void Detach() => throw new NotImplementedException();

        public override MxDisposable Enter()
        {
            throw new NotImplementedException();
        }

        public override void Exit()
        {
            throw new NotImplementedException();
        }
    }
}
