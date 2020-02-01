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
        private static System.Threading.ThreadLocal<_BlockScope> current = new System.Threading.ThreadLocal<_BlockScope>();

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
            current.Value = _BlockScope.current.IsValueCreated ? _BlockScope.current.Value : null;
            if (!current.IsValueCreated)
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

                current.Value.Params = @params;

                return (prefix, @params);
            }

            if(string.IsNullOrWhiteSpace(prefix))
            {
                int count = current.Value._counter.ContainsKey(hint) ? current.Value._counter[hint] : 0;
                prefix = hint + count;
                current.Value._counter[hint] = count + 1;
            }

            if(@params == null)
            {
                var parent = current.Value._block.Params;
                @params = new ParameterDict(parent.Prefix + prefix, parent.Shared);
            }
            else
            {
                @params = new ParameterDict(@params.Prefix + prefix, @params);
            }

            return (current.Value._block.Prefix + prefix, @params);
        }

        public override void Enter()
        {
            if (string.IsNullOrWhiteSpace(_block.Prefix))
                return;

            _old_scope = _BlockScope.current.Value;
            _name_scope = new Prefix(_block.Prefix);
            _name_scope.Enter();
        }

        public override void Exit()
        {
            if (string.IsNullOrWhiteSpace(_block.Prefix))
                return;

            _name_scope.Exit();
            _name_scope = null;
            _BlockScope.current.Value = _old_scope;
        }
    }
}
