using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.DotNet
{
    public class Tuple<TType>
    {
        private readonly List<TType> _tuple = new List<TType>();
        public Tuple(params TType[] param)
        {
            _tuple.AddRange(param);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            _tuple.ForEach(f =>
            {
                sb.Append(f);
                sb.Append(",");
            });
            sb.Append(")");
            return sb.ToString();
        }
    }
}
