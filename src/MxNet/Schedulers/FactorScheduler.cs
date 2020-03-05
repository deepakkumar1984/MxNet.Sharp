// ReSharper disable once CheckNamespace

namespace MxNet
{
    public class FactorScheduler : LRScheduler
    {
        #region Constructors

        public FactorScheduler(int step, float factor = 1, float stop_factor_lr = 1e-8f,
            float base_lr = 0.01F, int warmup_steps = 0, float warmup_begin_lr = 0, string warmup_mode = "linear")
            : base(base_lr, warmup_steps, warmup_begin_lr, warmup_mode)
        {
            _Step = step;
            _Factor = factor;
            _StopFactorLearningRate = stop_factor_lr;
        }

        #endregion

        #region Methods

        public override float Call(uint numUpdate)
        {
            while (numUpdate > (uint) (_Count + _Step))
            {
                _Count += _Step;

                BaseLearningRate *= _Factor;
                if (BaseLearningRate < _StopFactorLearningRate)
                {
                    BaseLearningRate = _StopFactorLearningRate;
                    Logging.LG(
                        $"Update[{numUpdate}]: now learning rate arrived at {BaseLearningRate}, will not change in the future");
                }
                else
                {
                    Logging.LG($"Update[{numUpdate}]: Change learning rate to {BaseLearningRate}");
                }
            }

            return BaseLearningRate;
        }

        #endregion

        #region Fields

        private int _Count;

        private readonly int _Step;

        private readonly float _Factor;

        private readonly float _StopFactorLearningRate;

        #endregion
    }
}