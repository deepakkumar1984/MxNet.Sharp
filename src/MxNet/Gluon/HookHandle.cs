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
        public (WeakReference<SortedDictionary<int, Hook>>, int) State
        {
            get
            {
                return (_hooks_dict_ref, _id);
            }
            set
            {
                if (value.Item1 == null)
                    _hooks_dict_ref = new WeakReference<SortedDictionary<int, Hook>>(new SortedDictionary<int, Hook>());
                else
                    _hooks_dict_ref = value.Item1;

                _id = value.Item2;
            }
        }

        private WeakReference<SortedDictionary<int, Hook>> _hooks_dict_ref;
        private int _id;

        public HookHandle() : base()
        {
            _hooks_dict_ref = null;
        }

        public void Attach(SortedDictionary<int, Hook> hooks_dict, Hook hook)
        {
            if (_hooks_dict_ref == null)
                throw new Exception("The same handle cannot be attached twice.");

            _id = hook.GetHashCode();
            hooks_dict[_id] = hook;
            _hooks_dict_ref = new WeakReference<SortedDictionary<int, Hook>>(hooks_dict);
        }

        public void Detach()
        {
            _hooks_dict_ref.TryGetTarget(out var hooks_dict);
            if (hooks_dict != null && hooks_dict.ContainsKey(_id))
                hooks_dict.Remove(_id);
        }

        public override MxDisposable Enter()
        {
            return this;
        }

        public override void Exit()
        {
            Detach();
        }
    }
}
