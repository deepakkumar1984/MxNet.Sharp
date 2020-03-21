using System;
using System.Collections.Generic;
using static MxNet.Gluon.Block;

namespace MxNet.Gluon
{
    public class HookHandle : MxDisposable
    {
        private WeakReference<Dictionary<int, Hook>> _hooks_dict_ref;
        private int _id;

        public HookHandle()
        {
            _hooks_dict_ref = null;
        }

        public (WeakReference<Dictionary<int, Hook>>, int) State
        {
            get => (_hooks_dict_ref, _id);
            set
            {
                if (value.Item1 == null)
                    _hooks_dict_ref = new WeakReference<Dictionary<int, Hook>>(new Dictionary<int, Hook>());
                else
                    _hooks_dict_ref = value.Item1;

                _id = value.Item2;
            }
        }

        public void Attach(Dictionary<int, Hook> hooks_dict, Hook hook)
        {
            if (_hooks_dict_ref == null)
                throw new Exception("The same handle cannot be attached twice.");

            _id = hook.GetHashCode();
            hooks_dict[_id] = hook;
            _hooks_dict_ref = new WeakReference<Dictionary<int, Hook>>(hooks_dict);
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