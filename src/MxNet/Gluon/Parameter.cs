using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon
{
    public class Parameter
    {
        internal Symbol symvar = null;
        internal List<NDArray> _data = null;
        internal List<NDArray> _grad = null;
        internal List<Context> ctx_list = null;
        internal Dictionary<int, Context[]> ctx_map;
        internal Trainer trainer = null;
        internal (Initializer, Context[], Initializer, NDArray)? deferred_init = null;
        internal bool differentiable = false;
        internal bool allow_deferred_init;
        private OpGradReq grad_req;

        public float LRMult { get; set; }

        public float WDMult { get; set; }

        public virtual OpGradReq GradReg
        {
            get
            {
                return grad_req;
            }
            set
            {
                if (!differentiable)
                    grad_req = OpGradReq.Null;
                if (grad_req == value)
                    return;

                grad_req = value;
                if (value == OpGradReq.Null && _grad != null)
                {
                    _grad = null;
                    if (_data != null)
                    {
                        for (int i = 0; i < _data.Count; i++)
                        {
                            _data[i] = _data[i].Detach();
                        }
                    }
                }
                else if (_data != null)
                {
                    InitGrad();
                }
            }
        }

        public DType DataType { get; internal set; }

        public Shape Shape { get; internal set; }

        public string Name { get; }

        public float Lr_Mult { get; }

        public float Wd_Mult { get; }

        public Initializer Init { get; set; }
        public StorageStype Stype { get; }
        public StorageStype Grad_Stype { get; }

        public Parameter(string name, OpGradReq grad_req=  OpGradReq.Write, Shape shape= null, DType dtype= null,
                 float lr_mult= 1.0f, float wd_mult= 1.0f, Initializer init= null, bool allow_deferred_init= false,
                 bool differentiable= true, StorageStype stype = StorageStype.Default, StorageStype grad_stype = StorageStype.Default)
        {
            Name = name;
            Lr_Mult = lr_mult;
            Wd_Mult = wd_mult;
            Init = init;
            GradReg = grad_req;
            Shape = shape;
            DataType = dtype ?? DType.Float32;
            this.differentiable = differentiable;
            Stype = stype;
            Grad_Stype = grad_stype;
            this.allow_deferred_init = allow_deferred_init;
            grad_req = OpGradReq.Null;
            ctx_map = new Dictionary<int, Context[]>();

        }

        internal void SetTrainer(Trainer trainer)
        {
            if (Stype != StorageStype.Default && this.trainer != null && trainer != null)
                throw new Exception(string.Format("Failed to set the trainer for Parameter '{0}' because it was already set. " +
                                    "More than one trainers for a {1} Parameter is not supported.", Name, Stype));

            this.trainer = trainer;
        }

        internal NDArray[] CheckAndGet(NDArray[] arr_list, Context ctx)
        {
            if (arr_list == null)
                throw new ArgumentException($"Parameter '{Name}' has not been initialized. Note that " +
                                            "you should initialize parameters and create Trainer " +
                                            "with Block.collect_params() instead of Block.params " +
                                            "because the later does not include Parameters of " +
                                            "nested child Blocks");

            if(ctx == null)
            {
                if (arr_list.Length == 1)
                    return arr_list;
                else
                    ctx = Context.CurrentContext;
            }

            foreach (var item in arr_list)
            {
                if(item.context != ctx)
                {
                    throw new Exception($"Parameter '{Name}' was not initialized on context {ctx.ToString()}. " + 
                                         $"It was only initialized on {item.context.ToString()}.");
                }
            }

            if (deferred_init != null)
                throw new Exception($"Parameter '{Name}' has not been initialized yet because initialization was " +
                                    "deferred. Actual initialization happens during the first forward pass. " +
                                    "Please pass one batch of data through the network before accessing Parameters. " +
                                    "You can also avoid deferred initialization by specifying in_units, " +
                                    "num_features, etc., for network layers.");

            return arr_list;
        }

        internal NDArray[] GetRowSparse(NDArray[] arr_list, Context ctx, NDArray row_id)
        {
            if (trainer == null)
                throw new Exception($"Cannot get row_sparse data for Parameter '{Name}' when no " +
                                            "Trainer is created with it.");

            var results = CheckAndGet(arr_list, ctx);
            trainer.RowSparsePull(this, arr_list, row_id);
            return results;
        }

        internal void LoadInit(NDArray data, Context[] ctx, bool cast_dtype= false, string dtype_source= "current")
        {
            if(cast_dtype)
            {
                Assert.InList("dtype_source", dtype_source, new string[]{ "current", "saved"});
            }

            if(Shape != null)
            {
                List<uint> newshape = new List<uint>();
                Enumerable.Zip(Shape.Data, data.Shape.Data, (self_dim, data_dim) =>
                {
                    Assert.InList("self_dim", (int)self_dim, Enumerable.Range(0, (int)data_dim).ToArray(),
                                $"Failed loading Parameter '{Name}' from saved params: shape incompatible expected %{Shape} vs saved %{data.Shape}");

                    if (self_dim != 0)
                        newshape.Add(self_dim);
                    else
                        newshape.Add(data_dim);

                    return true;
                });

                Shape = new Shape(newshape);
            }

            if(DataType != null)
            {
                if (cast_dtype && DataType.Name != data.DataType.Name)
                {
                    if (dtype_source == "current")
                        data = data.AsType(DataType);
                    else if (dtype_source == "saved")
                        DataType = data.DataType;
                }
                else if (DataType.Name == data.DataType.Name)
                {
                    throw new Exception($"Failed loading Parameter '{Name}' from saved params: " +
                                                $"dtype incompatible expected {DataType} vs saved {data.DataType}. " +
                                                "Set cast_dtype=True to cast the dtype of saved params.");
                }
            }

            if (Stype != data.SType)
                data = data.ToSType(Stype);

            if(this._data == null)
            {
                if (deferred_init != null)
                {
                    if (ctx == null || MxUtil.Set<Context>(ctx.ToList()) != MxUtil.Set(deferred_init.Value.Item2.ToList()))
                    {
                        throw new Exception($"Failed to load Parameter '{Name}' on {ctx[0]} because it was " +
                                            $"previous initialized on {ListCtx()[0]}.");
                    }

                    ctx = deferred_init.Value.Item2;
                }
                else if (ctx == null)
                    ctx = new Context[] { Context.Cpu(0) };

                InitImpl(data, ctx);
            }
            else
            {
                if (ctx == null || MxUtil.Set<Context>(ctx.ToList()) != MxUtil.Set(deferred_init.Value.Item2.ToList()))
                {
                    throw new Exception($"Failed to load Parameter '{Name}' on {ctx[0]} because it was " +
                                        $"previous initialized on {ListCtx()[0]}.");
                }
            }

            deferred_init = default;
        }

        internal void FinishDeferredInit()
        {
            if (deferred_init == null)
                return;

            var (init, ctx, default_init, data) = deferred_init.Value;
            deferred_init = default;
            if(!Utils.ShapeIsKnown(Shape))
            {
                throw new Exception($"Cannot initialize Parameter '{Name}' because it has " +
                                    $"invalid shape: {Shape}. Please specify in_units, " +
                                    "in_channels, etc for `Block`s.");
            }

            using (var p = Autograd.Pause())
            {
                if(data == null)
                {
                    data = nd.Zeros(shape: Shape, dtype: DataType, ctx: Context.Cpu(0)).ToSType(Stype);
                    InitImpl(data, ctx);
                }
            }

        }

        internal void InitImpl(NDArray data, Context[] ctx_list)
        {
            ctx_map = new Dictionary<int, Context[]>();
            for (int i = 0; i < ctx_list.Length; i++)
            {
                var dev_list = ctx_map[(int)ctx_list[i].GetDeviceType() & 1].ToList();
                while (dev_list.Count <= ctx_list[i].GetDeviceId())
                    dev_list.Add(null);

                dev_list[ctx_list[i].GetDeviceId()] = ctx_list[i];
            }

            this._data = new List<NDArray>();
            foreach (var ctx in ctx_list)
            {
                this._data.Add(data.AsInContext(ctx));
            }

            InitGrad();
        }

        internal void InitGrad()
        {
            if (GradReg == OpGradReq.Null)
            {
                _grad = null;
                return;
            }

            _grad = new List<NDArray>();
            for (int i = 0; i < _data.Count; i++)
            {
                _grad.Add(nd.Zeros(_data[i].Shape, _data[i].context, _data[i].DataType).ToSType(Stype));
            }

            Autograd.MarkVariables(CheckAndGet(this._data.ToArray(), null), this._grad.ToArray(), GradReg);
        }

        internal NDArray Reduce()
        {
            var ctx = Context.Cpu();
            NDArray data = null;
            if (Stype == StorageStype.Default)
            {
                var block = ListData();
                data = nd.AddN(block.Select(x => x.AsInContext(ctx)).ToArray()) / block.Length;
            }
            else
            {
                var all_row_ids = nd.Arange(0, (int)Shape[0], dtype: DType.Int64, ctx: ctx);
                data = nd.Zeros(Shape, ctx: ctx).ToSType(StorageStype.RowSparse);
                trainer.RowSparsePull(this, new NDArray[] { data }, all_row_ids, true);
            }

            return data;
        }

        public void Initialize(Initializer init = null, Context[] ctx = null, Initializer default_init = null, bool force_reinit = false)
        {
            if (this._data != null && !force_reinit)
            {
                Logger.Warning($"Parameter '{Name}' is already initialized, ignoring. Set force_reinit=True to re-initialize.");
                return;
            }

            this._data = null;
            this._grad = null;


            if (ctx == null)
                ctx = new Context[] { Context.CurrentContext };

            if (init == null)
                init = this.Init != null ? this.Init : default_init;

            if(!Utils.ShapeIsKnown(this.Shape))
            {
                if(this.allow_deferred_init)
                {
                    deferred_init = (init, ctx, default_init, null);
                    return;
                }

                throw new Exception($"Cannot initialize Parameter '{Name}' because it has invalid shape: {Shape}.");
            }

            deferred_init = (init, ctx, default_init, null);
            FinishDeferredInit();
        }

        public void ResetCtx(Context[] ctx)
        {
            if (ctx == null)
                ctx = new Context[] { Context.CurrentContext };

            if(this._data != null)
            {
                var data = Reduce();
                using(var p = Autograd.Pause())
                {
                    InitImpl(data, ctx);
                }
            }
            else if(deferred_init.HasValue)
            {
                var (init, _, default_init, data) = deferred_init.Value;
                deferred_init = (init, ctx, default_init, data);
            }
            else
            {
                throw new Exception($"Cannot reset context for Parameter '{Name}' because it has not been initialized.");
            }
        }

        public void SetData(NDArray data)
        {
            this.Shape = data.Shape;
            if (this._data == null)
            {
                if (this.deferred_init.HasValue)
                    if (!deferred_init.HasValue)
                        throw new Exception($"Parameter '{Name}' has not been initialized");
                deferred_init = (deferred_init.Value.Item1, deferred_init.Value.Item2, deferred_init.Value.Item3, data);
                return;
            }
            
            if(trainer != null && trainer._kv_initialized && trainer._update_on_kvstore)
            {
                if(!trainer._params_to_init.Contains(this))
                {
                    trainer.ResetKVstore();
                }
            }

            var dlist = CheckAndGet(this._data.ToArray(), null);
            for (int i = 0; i < dlist.Length; i++)
            {
                dlist[i] = data;
            }
        }

        public NDArray RowSparseData(NDArray row_id)
        {
            if(Stype != StorageStype.RowSparse)
            {
                throw new Exception($"Cannot return copies of Parameter '{Name}' on all contexts via " +
                                   $"list_row_sparse_data() because its storage type is {Stype}. Please " +
                                   "use data() instead.");
            }

            return GetRowSparse(_data.ToArray(), row_id.context, row_id).FirstOrDefault();
        }

        public NDArray[] ListRowSparseData(NDArray row_id)
        {
            if (Stype != StorageStype.RowSparse)
            {
                throw new Exception($"Cannot return a copy of Parameter {Name} via row_sparse_data() " +
                                    $"because its storage type is {Stype}. Please use data() instead.");
            }

            return GetRowSparse(_data.ToArray(), null, row_id);
        }

        public NDArray Data(Context ctx = null)
        {
            if (Stype != StorageStype.Default)
            {
                throw new Exception($"Cannot return copies of Parameter '{Name}' on all contexts via " +
                                   $"list_row_sparse_data() because its storage type is {Stype}. Please " +
                                   "use RowSparseData() instead.");
            }

            return CheckAndGet(_data.ToArray(), ctx).FirstOrDefault();
        }

        public NDArray[] ListData()
        {
            if (Stype != StorageStype.Default)
            {
                throw new Exception($"Cannot return a copy of Parameter {Name} via row_sparse_data() " +
                                    $"because its storage type is {Stype}. Please use ListRowSparseData() instead.");
            }

            return CheckAndGet(this._data.ToArray(), null);
        }

        public NDArray Grad(Context ctx = null)
        {
            if(_data != null && _grad == null)
            {
                throw new Exception($"Cannot get gradient array for Parameter '{Name}' " +
                                    "because grad_req='null'");
            }

            return CheckAndGet(_grad.ToArray(), ctx).FirstOrDefault();
        }

        public NDArray[] ListGrad()
        {
            if (_data != null && _grad == null)
            {
                throw new Exception($"Cannot get gradient array for Parameter '{Name}' " +
                                    "because grad_req='null'");
            }

            return CheckAndGet(_grad.ToArray(), null);
        }

        public Context[] ListCtx()
        {
            if(_data == null)
            {
                if(deferred_init.HasValue)
                {
                    return deferred_init.Value.Item2;
                }

                throw new Exception($"Parameter '{Name}' has not been initialized");
            }

            return this.ctx_list.ToArray();
        }

        public void ZeroGrad()
        {
            if (_grad == null)
                return;

            for (int i = 0; i < _grad.Count; i++)
                this._grad[i] = nd.ZerosLike(this._grad[i]);
        }

        public Symbol Var() => throw new NotImplementedException();

        public void Cast(DType dtype) => throw new NotImplementedException();
    }
}
