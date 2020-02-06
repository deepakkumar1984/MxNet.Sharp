using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MxNet.Name;

namespace MxNet.Gluon
{
    public class _BlockScope : MxDisposable
    {
        private static System.Threading.ThreadLocal<_BlockScope> _current = new System.Threading.ThreadLocal<_BlockScope>();

        private Block _block;
        private Dictionary<string, int> _counter = new Dictionary<string, int>();
        private _BlockScope _old_scope;
        private Prefix _name_scope;

        public ParameterDict Params { get; set; }

        public _BlockScope(Block block) : base()
        {
            _block = block;
            _old_scope = null;
            _name_scope = null;
            _counter = new Dictionary<string, int>();
        }

        public static (string, ParameterDict) Create(string prefix, ParameterDict @params, string hint)
        {
            var current = _BlockScope._current.IsValueCreated ? _BlockScope._current.Value : null;
            if (current == null)
            {
                if (prefix == null)
                {
                    if (!NameManager.current.IsValueCreated)
                        NameManager.current.Value = new NameManager();

                    prefix = NameManager.current.Value.Get(null, hint);
                }

                if (@params == null)
                    @params = new ParameterDict(prefix);
                else
                    @params = new ParameterDict(@params.Prefix, @params);

                return (prefix, @params);
            }

            if(string.IsNullOrWhiteSpace(prefix))
            {
                int count = current._counter.ContainsKey(hint) ? _current.Value._counter[hint] : 0;
                prefix = hint + count;
                current._counter[hint] = count + 1;
            }

            if(@params == null)
            {
                var parent = current._block.Params;
                @params = new ParameterDict(parent.Prefix + prefix, parent.Shared);
            }
            else
            {
                @params = new ParameterDict(@params.Prefix + prefix, @params);
            }

            return (current._block.Prefix + prefix, @params);
        }

        public override MxDisposable Enter()
        {
            if (string.IsNullOrWhiteSpace(_block.Prefix))
                return null;

            _old_scope = _BlockScope._current.Value;
            _name_scope = new Prefix(_block.Prefix);
            _name_scope.Enter();
            return this;
        }

        public override void Exit()
        {
            if (string.IsNullOrWhiteSpace(_block.Prefix))
                return;

            _name_scope.Exit();
            _name_scope = null;
            _BlockScope._current.Value = _old_scope;
        }
    }
}
