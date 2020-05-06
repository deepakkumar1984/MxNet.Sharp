using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.Keras.Utils
{
    public class Progbar
    {
        private Action<string> _dynamic_display;
        private DateTime _last_update;
        private int _seen_so_far;
        private DateTime _start;
        private int _total_width;
        private Dictionary<string, (int, int)> _values;
        private float interval;
        private List<string> stateful_metrics;
        private int target;
        private int verbose;
        private int width;

        public Progbar(int target, int width= 30, int verbose= 1, float interval= 0.05f, string[] stateful_metrics= null)
        {
            this.target = target;
            this.width = width;
            this.verbose = verbose;
            this.interval = interval;
            if (stateful_metrics != null)
            {
                this.stateful_metrics = stateful_metrics.ToList();
            }
            else
            {
                this.stateful_metrics = new List<string>();
            }

            this._dynamic_display = Console.Write;
            this._total_width = 0;
            this._seen_so_far = 0;
            this._values = new Dictionary<string, (int, int)>();
            this._start = DateTime.Now;
            this._last_update = DateTime.MinValue;
        }

        public void Update(int current, Dictionary<string, float> values = null)
        {
            double avg;
            int time_per_unit;
            string bar;
            if (values == null)
                values = new Dictionary<string, float>();

            foreach (var item in values)
            {
                var k = item.Key;
                var v = item.Value;
                if (!this.stateful_metrics.Contains(k))
                {
                    if (!this._values.ContainsKey(k))
                    {
                        this._values[k] = ((int)v * (current - this._seen_so_far), current - this._seen_so_far);
                    }
                    else
                    {
                        this._values[k] = (this._values[k].Item1 + ((int)v * (current - this._seen_so_far)), this._values[k].Item2 + (current - this._seen_so_far));
                    }
                }
                else
                {
                    // Stateful metrics output a numeric value.  This representation
                    // means "take an average from a single value" but keeps the
                    // numeric formatting.
                    this._values[k] = ((int)v, 1);
                }
            }
            this._seen_so_far = current;
            var now = DateTime.Now;
            var info = $" - {(now - this._start).TotalSeconds}s";
            if (this.verbose == 1)
            {
                if ((now - this._last_update).TotalSeconds < this.interval && this.target == 0 && current < this.target)
                {
                    return;
                }

                var prev_total_width = this._total_width;
                if (this._dynamic_display != null)
                {
                    for (int i = 0; i < prev_total_width; i++)
                        _dynamic_display("\b");

                    _dynamic_display("\r");
                }
                else
                {
                    Console.WriteLine("\n");
                }
                if (this.target > 0)
                {
                    var numdigits = Convert.ToInt32(Math.Floor(Math.Log10(this.target))) + 1;
                    var barstr = numdigits / target;
                    bar = (barstr % current).ToString();
                    var prog = current / this.target;
                    var prog_width = Convert.ToInt32(this.width * prog);
                    if (prog_width > 0)
                    {
                        for (int i = 0; i < (prog_width - 1); i++)
                            bar += "=";

                        if (current < this.target)
                        {
                            bar += ">";
                        }
                        else
                        {
                            bar += "=";
                        }
                    }
                    for (int i = 0; i < (this.width - prog_width); i++)
                        bar += ".";

                    bar += "]";
                }
                else
                {
                    bar = $"{current}/Unknown";
                }

                this._total_width = bar.Length;
                Console.Write(bar);
                if (current > 0)
                {
                    time_per_unit = (int)(now - this._start).TotalSeconds / current;
                }
                else
                {
                    time_per_unit = 0;
                }
                if (this.target > 0 && current < this.target)
                {
                    string eta_format = "";
                    var eta = time_per_unit * (this.target - current);
                    if (eta > 3600)
                    {
                        eta_format = $"{eta / 3600}:{eta % 3600}:{eta % 60}";
                    }
                    else if (eta > 60)
                    {
                        eta_format = $"{ eta / 60}:{eta % 60}";
                    }
                    else
                    {
                        eta_format = eta.ToString();
                    }

                    info = $" - ETA: {eta_format}";
                }
                else if (time_per_unit >= 1)
                {
                    info += $" {time_per_unit}s/step";
                }
                else if (time_per_unit >= 0.001)
                {
                    info += $" {time_per_unit * 1000.0}ms/step";
                }
                else
                {
                    info += $" %{time_per_unit * 1000000.0}us/step";
                }
                foreach (var k in this._values)
                {
                    info += $" - {k.Key}:";
                    avg = k.Value.Item1 / Math.Max(1, k.Value.Item2);
                    if (Math.Abs(avg) > 0.001)
                    {
                        info += $" {avg}";
                    }
                    else
                    {
                        info +=$" {avg}";
                    }
                }

                this._total_width += info.Length;
                if (prev_total_width > this._total_width)
                {
                    for (int i = 0; i < (prev_total_width - this._total_width); i++)
                        info += " ";
                }

                if (this.target > 0 && current >= this.target)
                {
                    info += "\n";
                }

                Console.Write(info);
            }
            else if (this.verbose == 2)
            {
                if (this.target > 0 || current >= this.target)
                {
                    foreach (var k in this._values)
                    {
                        info += String.Format(" - %s:", k);
                        avg = k.Value.Item1 / Math.Max(1, k.Value.Item2);
                        if (Math.Abs(avg) > 0.001)
                        {
                            info += $" {avg}";
                        }
                        else
                        {
                            info += $" {avg}";
                        }
                    }

                    info += "\n";
                    Console.Write(info);
                }
            }
            this._last_update = now;
        }

        public void Add(int n, Dictionary<string, float> values = null)
        {
            this.Update(this._seen_so_far + n, values);
        }
    }
}
