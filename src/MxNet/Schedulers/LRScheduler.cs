using System;

// ReSharper disable once CheckNamespace
namespace MxNet
{

    public abstract class LRScheduler
    {

        #region Constructors

        protected LRScheduler(float base_lr = 0.01f, int warmup_steps = 0, float warmup_begin_lr = 0, string warmup_mode = "linear")
        {
            this.BaseLearningRate = base_lr;
        }

        #endregion

        #region Properties

        protected float BaseLearningRate
        {
            get;
            set;
        }

        #endregion

        #region Methods
        public float GetWarmupLR(uint num_update)
        {
            throw new NotImplementedException();
        }

        public abstract float Call(uint num_update);

        #endregion

    }

}
