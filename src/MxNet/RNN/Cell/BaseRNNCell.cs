using MxNet.Gluon.RNN;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace MxNet.RecurrentLayer
{
    public abstract class BaseRNNCell
    {
        private bool _own_params;
        private string _prefix;
        private RNNParams _params;
        private bool _modified;
        private int _init_counter;
        private int _counter;
        private int _num_hidden;
        private List<BaseRNNCell> _cells = new List<BaseRNNCell>();

        public virtual RNNParams Params
        {
            get
            {
                _own_params = false;
                return _params;
            }
        }

        public abstract StateInfo[] StateInfo { get; }

        public virtual Shape[] StateShape
        {
            get
            {
                return StateInfo.Select(x => (x.Shape)).ToArray();
            }
        }

        public virtual string[] GateNames
        {
            get
            {
                return new string[0];
            }
        }

        public BaseRNNCell(string prefix, RNNParams @params = null)
        {
            if (@params == null)
            {
                @params = new RNNParams(prefix);
                _own_params = true;
            }
            else
                _own_params = false;

            _prefix = prefix;
            _params = @params;
            _modified = false;

            Reset();
        }

        public virtual void Reset()
        {
            _init_counter = -1;
            _counter = -1;
            foreach (var cell in _cells)
            {
                cell.Reset();
            }
        }

        public abstract void Call(Symbol inputs, SymbolList states);

        public virtual SymbolList BeginState(string func = "sym.Zeros", FuncArgs kwargs = null)
        {
            if (_modified)
                throw new Exception("After applying modifier cells (e.g. DropoutCell) the base "  +
                                        "cell cannot be called directly. Call the modifier cell instead.");

            SymbolList states = new SymbolList();
            for (int i = 0; i < StateInfo.Length; i++)
            {
                var info = StateInfo[i];
                Symbol state = null;
                _init_counter++;
                kwargs.Add("name", $"{_prefix}begin_state_{_init_counter}");
                if (info == null)
                {
                    info = new StateInfo(kwargs);
                }
                else
                {
                    info.Update(kwargs);
                }

                var obj = new sym();
                var m = typeof(sym).GetMethod(func.Replace("sym.", ""), BindingFlags.Static);
                var keys = m.GetParameters().Select(x => x.Name).ToArray();
                var paramArgs = info.GetArgs(keys);
                states.Add((Symbol)m.Invoke(obj, paramArgs));
            }

            return states;
        }

        public virtual NDArrayDict UnpackWeights(NDArrayDict args)
        {
            if (GateNames == null)
                return args;

            var h = _num_hidden;
            foreach (var group_name in new string[] { "i2h", "h2h" })
            {
                var weight = args[$"{_prefix}{group_name}_weight"];
                var bias = args[$"{_prefix}{group_name}_bias"];
                for (int j = 0; j < GateNames.Length; j++)
                {
                    var gate = GateNames[j];
                    string wname = $"{_prefix}{group_name}{gate}_weight";
                    args[wname] = weight[$"{j * h}:{(j + 1) * h}"].Copy();
                    string bname = $"{_prefix}{group_name}{gate}_bias";
                    args[bname] = weight[$"{j * h}:{(j + 1) * h}"].Copy();
                }
            }

            return args;
        }

        public virtual NDArrayDict PackWeights(NDArrayDict args)
        {
            throw new NotImplementedException();
        }

        public virtual (Symbol, SymbolList) Unroll(int length, SymbolList inputs, SymbolList begin_state = null, string layout = "NTC", bool? merge_outputs = null)
        {
            throw new NotImplementedException();
        }
    }
}
