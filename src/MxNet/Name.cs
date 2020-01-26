using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MxNet
{
    public class Name
    {
        public class NameManager : MxDisposable
        {
            internal static ThreadLocal<NameManager> current = new ThreadLocal<NameManager>();

            private Dictionary<string, int> counter = new Dictionary<string, int>();
            private NameManager old_manager = null;

            public static NameManager Current
            {
                get
                {
                    if (current != null && current.IsValueCreated)
                        return current.Value;

                    return new NameManager();
                }
                set
                {
                    current.Value = value;
                }
            }

            public override void Enter()
            {
                if(!current.IsValueCreated)
                {
                    current.Value = new NameManager();
                }

                old_manager = current.Value;
                current.Value = this;
            }

            public override void Exit()
            {
                if(old_manager != null)
                {
                    current.Value = old_manager;
                }
            }

            public virtual string Get(string name, string hint)
            {
                if(!string.IsNullOrWhiteSpace(name))
                {
                    return name;
                }

                if(!counter.ContainsKey(hint))
                {
                    counter[hint] = 0;
                }

                name = hint + counter[hint];
                return name;
            }
        }

        public class Prefix : NameManager
        {
            private string _prefix;

            public Prefix(string prefix)
            {
                _prefix = prefix;
            }

            public override string Get(string name, string hint)
            {
                string r = base.Get(name, hint);
                return _prefix + r;
            }
        }

    }
}
