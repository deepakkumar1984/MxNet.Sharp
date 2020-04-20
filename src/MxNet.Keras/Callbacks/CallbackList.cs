using MxNet.Keras.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MxNet.Keras.Callbacks
{
    public class CallbackList
    {
        public double _delta_t_batch;

        public List<double> _delta_ts_batch_begin;

        public List<double> _delta_ts_batch_end;

        public DateTime _t_enter_batch;

        public List<Callback> callbacks;

        public int queue_length;

        public CallbackList(Callback[] callbacks = null, int queue_length = 10)
        {
            if (callbacks != null)
                this.callbacks = callbacks.ToList();
            else
                this.callbacks = new List<Callback>();

            this.queue_length = queue_length;
        }

        public void Append(Callback callback)
        {
            this.callbacks.Add(callback);
        }

        public void SetParams(Dictionary<string, object> @params)
        {
            foreach (var callback in this.callbacks)
            {
                callback.SetParams(@params);
            }
        }

        public void SetModel(Model model)
        {
            foreach (var callback in this.callbacks)
            {
                callback.SetModel(model);
            }
        }

        public void OnEpochBegin(int epoch, Dictionary<string, float> logs = null)
        {
            if (logs == null)
                logs = new Dictionary<string, float>();

            foreach (var callback in this.callbacks)
            {
                callback.OnEpochBegin(epoch, logs);
            }

            _delta_t_batch = 0;
        }

        public void OnEpochEnd(int epoch, Dictionary<string, float> logs = null)
        {
            if (logs == null)
                logs = new Dictionary<string, float>();

            foreach (var callback in this.callbacks)
            {
                callback.OnEpochEnd(epoch, logs);
            }
        }

        public void OnBatchBegin(int batch, Dictionary<string, float> logs = null)
        {
            if (logs == null)
                logs = new Dictionary<string, float>();

            var t_before_callbacks = DateTime.Now;
            foreach (var callback in this.callbacks)
            {
                callback.OnBatchBegin(batch, logs);
            }
            this._delta_ts_batch_begin.Add((DateTime.Now - t_before_callbacks).TotalMilliseconds);
            var delta_t_median = _delta_ts_batch_begin.Average();
            if (this._delta_t_batch > 0.0 && delta_t_median > 0.95 * this._delta_t_batch && delta_t_median > 0.1)
            {
                Logger.Warning($"Method on_batch_begin() is slow compared to the batch update ({delta_t_median}). Check your callbacks.");
            }

            this._t_enter_batch = DateTime.Now;
        }

        public void OnBatchEnd(int batch, Dictionary<string, float> logs = null)
        {
            if (logs == null)
                logs = new Dictionary<string, float>();

            this._delta_t_batch = (DateTime.Now - this._t_enter_batch).TotalMilliseconds;
            var t_before_callbacks = DateTime.Now;
            foreach (var callback in this.callbacks)
            {
                callback.OnBatchEnd(batch, logs);
            }
            this._delta_ts_batch_end.Add((DateTime.Now - t_before_callbacks).TotalMilliseconds);
            var delta_t_median = _delta_ts_batch_end.Average();
            if (this._delta_t_batch > 0.0 && (delta_t_median > 0.95 * this._delta_t_batch && delta_t_median > 0.1))
            {
                Logger.Warning($"In your callbacks, method `on_batch_end()` is slow compared to a model step ({delta_t_median} vs {_delta_t_batch}). Check your callbacks.");
            }
        }

        public void OnTrainBegin(Dictionary<string, float> logs = null)
        {
            if (logs == null)
                logs = new Dictionary<string, float>();

            foreach (var callback in this.callbacks)
            {
                callback.OnTrainBegin(logs);
            }
        }

        public void OnTrainEnd(Dictionary<string, float> logs = null)
        {
            if (logs == null)
                logs = new Dictionary<string, float>();

            foreach (var callback in this.callbacks)
            {
                callback.OnTrainEnd(logs);
            }
        }
    }
}
