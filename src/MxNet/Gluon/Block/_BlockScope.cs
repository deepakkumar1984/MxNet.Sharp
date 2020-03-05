using System.Collections.Generic;
using System.Threading;
using static MxNet.Name;

namespace MxNet.Gluon
{
    public class _BlockScope : MxDisposable
    {
        private static readonly ThreadLocal<_BlockScope> _current = new ThreadLocal<_BlockScope>();

        private readonly Block _block;
        private readonly Dictionary<string, int> _counter = new Dictionary<string, int>();
        private Prefix _name_scope;
        private _BlockScope _old_scope;

        public _BlockScope(Block block)
        {
            _block = block;
            _old_scope = null;
            _name_scope = null;
            _counter = new Dictionary<string, int>();
        }

        public ParameterDict Params { get; set; }

        public static (string, ParameterDict) Create(string prefix, ParameterDict @params, string hint)
        {
            var current = _current.IsValueCreated ? _current.Value : null;
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

            if (string.IsNullOrWhiteSpace(prefix))
            {
                var count = current._counter.ContainsKey(hint) ? _current.Value._counter[hint] : 0;
                prefix = hint + count;
                current._counter[hint] = count + 1;
            }

            if (@params == null)
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

            _old_scope = _current.Value;
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
            _current.Value = _old_scope;
        }
    }
}