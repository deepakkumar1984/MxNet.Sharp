namespace MxNet.Gluon.RNN
{
    public class ModifierCell : HybridRecurrentCell
    {
        public ModifierCell(RecurrentCell base_cell)
            : base(base_cell.Prefix + base_cell.Alias(), base_cell.Params)
        {
            BaseCell = base_cell;
        }

        public RecurrentCell BaseCell { get; }

        public override ParameterDict Params => BaseCell.Params;

        public override StateInfo[] StateInfo(int batch_size = 0)
        {
            return BaseCell.StateInfo(batch_size);
        }

        public override NDArrayOrSymbol[] BeginState(int batch_size = 0, string func = null, FuncArgs args = null)
        {
            BaseCell._modified = false;
            var begin = BaseCell.BeginState(batch_size, func, args);
            BaseCell._modified = true;
            return begin;
        }

        public override (NDArrayOrSymbol, NDArrayOrSymbol[]) HybridForward(NDArrayOrSymbol x,
            params NDArrayOrSymbol[] args)
        {
            return default;
        }
    }
}