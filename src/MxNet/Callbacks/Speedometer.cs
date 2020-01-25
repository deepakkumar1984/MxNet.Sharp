using MxNet.Metrics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Callbacks
{
    public class Speedometer : IBatchEndCallback
    {
        private int _batch_size;
        private int _frequent;
        private bool _auto_reset;
        private bool init;
        private long tic;
        private int last_count;
        private Logger logging;

        public Speedometer(int batch_size, int frequent= 50, bool auto_reset= true, Logger logger = null)
        {
            _batch_size = batch_size;
            _frequent = frequent;
            _auto_reset = auto_reset;
            init = false;
            tic = 0;
            last_count = 0;
            logging = logger!=null ? logger : Logger.GetLogger();
        }

        public void Invoke(int epoch, int nbatch, EvalMetric eval_metric, FuncArgs locals = null)
        {
            var count = nbatch;
            float speed;
            string msg;

            if (last_count > count)
                init = false;

            last_count = count;

            if(init)
            {
                if(count % _frequent == 0)
                {
                    try
                    {
                        speed = (float)Math.Round((float)_frequent * (float)_batch_size / (float)(DateTime.Now.Ticks - tic));
                    }
                    catch(DivideByZeroException ex)
                    {
                        speed = float.PositiveInfinity;
                    }

                    if(eval_metric != null)
                    {
                        var name_value = eval_metric.GetNameValue();
                        if(_auto_reset)
                        {
                            eval_metric.ResetLocal();
                            msg = string.Format("Epoch[{0}] Batch [{1}-{2}]\tSpeed: {3} samples/sec", epoch, count - _frequent, count, speed);
                            foreach (var item in name_value)
                            {
                                msg += string.Format("\t {0}={1}", item.Item1, item.Item2);
                            }

                            logging.Log(msg);
                        }
                        else
                        {
                            msg = string.Format("Epoch[{0}] Batch [0-{1}]\tSpeed: {2} samples/sec", epoch, count, speed);
                            foreach (var item in name_value)
                            {
                                msg += string.Format("\t {0}={1}", item.Item1, item.Item2);
                            }

                            logging.Log(msg);
                        }
                    }
                    else
                    {
                        logging.Log(string.Format("Iter[{0}] Batch [{1}]\tSpeed: {} samples/sec", epoch, _batch_size, speed));
                    }

                    tic = DateTime.Now.Ticks;
                }
                else
                {
                    init = true;
                    tic = DateTime.Now.Ticks;
                }
            }
        }
    }
}
