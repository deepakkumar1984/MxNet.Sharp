using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MxNet
{
    public class SymbolList : IEnumerable<Symbol>
    {
        public List<Symbol> data;

        public SymbolList()
        {
            data = new List<Symbol>();
        }

        public SymbolList(int length)
        {
            data = new List<Symbol>();
            for (int i = 0; i < length; i++)
                data.Add(new Symbol());
        }

        public SymbolList(params Symbol[] args)
        {
            data = args.ToList();
        }

        public SymbolList((Symbol, Symbol) args)
        {
            data = new List<Symbol> { args.Item1, args.Item2 };
        }

        public SymbolList((Symbol, Symbol, Symbol) args)
        {
            data = new List<Symbol> { args.Item1, args.Item2, args.Item3 };
        }

        public Symbol[] Data => data.ToArray();

        public IntPtr[] Handles
        {
            get
            {
                List<IntPtr> ret = new List<IntPtr>();
                foreach (var item in Data)
                {
                    if (item == null)
                        continue;

                    ret.Add(item.NativePtr);
                }

                return ret.ToArray();
            }

        }

        public NDArrayOrSymbol[] NDArrayOrSymbol => data.Select(x => new NDArrayOrSymbol(x)).ToArray();

        public Symbol this[int i]
        {
            get => data[i];
            set => data[i] = value;
        }

        public int Length => data.Count;

        public IEnumerator<Symbol> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        public void Add(params Symbol[] x)
        {
            if (x == null)
                return;

            data.AddRange(x);
        }

        public static implicit operator SymbolList(Symbol[] x)
        {
            return new SymbolList(x);
        }

        public static implicit operator SymbolList(Symbol x)
        {
            return new SymbolList(x);
        }

        public static implicit operator SymbolList(List<Symbol> x)
        {
            return new SymbolList(x.ToArray());
        }

        public static implicit operator SymbolList(NDArrayOrSymbol[] x)
        {
            return new SymbolList(x.Select(i => i.SymX).ToArray());
        }

        public static implicit operator SymbolList(NDArrayOrSymbol x)
        {
            return new SymbolList(x);
        }

        public static implicit operator SymbolList(List<NDArrayOrSymbol> x)
        {
            return new SymbolList(x.Select(i => i.SymX).ToArray());
        }

        public static implicit operator Symbol(SymbolList x)
        {
            return x.data.Count > 0 ? x[0] : null;
        }

        public static implicit operator List<Symbol>(SymbolList x)
        {
            return x.data.ToList();
        }

        public static implicit operator Symbol[](SymbolList x)
        {
            if (x == null)
                return null;

            return x.data.ToArray();
        }
    }
}