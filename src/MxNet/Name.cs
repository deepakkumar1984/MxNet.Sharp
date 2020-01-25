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

            public NameManager()
            {
                throw new NotImplementedException();
            }

            public override void Enter()
            {
                throw new NotImplementedException();
            }

            public override void Exit()
            {
                throw new NotImplementedException();
            }

            public virtual string Get(string name, string hint)
            {
                throw new NotImplementedException();
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
