using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNetLib.Gluon
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

        public void Attach(Dictionary<string, HookHandle> hooks_dict, HookHandle hook) => throw new NotImplementedException();

        public void Detach() => throw new NotImplementedException();

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
