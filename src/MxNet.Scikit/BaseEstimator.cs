using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MxNet.SciKit
{
    public class BaseEstimator
    {
        internal Dictionary<string, object> _DEFAULT_TAGS = new Dictionary<string, object>();

        internal Dictionary<string, object> tags = new Dictionary<string, object>();

        internal string _estimator_type = "";

        public static string[] GetParamNames(Type cls)
        {
            var construct = cls.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
            return construct.GetParameters().Select(x=>x.Name).ToArray();
        }

        public static object GetAttr(object obj, string key)
        {
            var p = obj.GetType().GetProperties().Where(x => (x.Name == key)).FirstOrDefault();
            if (p != null)
                return p.GetValue(obj);

            var f = obj.GetType().GetFields().Where(x => (x.Name == key)).FirstOrDefault();
            if (f != null)
                return f.GetValue(obj);

            return null;
        }

        public static void SetAttr(object obj, string key, object value)
        {
            var p = obj.GetType().GetProperties().Where(x => (x.Name == key)).FirstOrDefault();
            if (p != null)
                p.SetValue(obj, value);

            var f = obj.GetType().GetFields().Where(x => (x.Name == key)).FirstOrDefault();
            if (f != null)
                f.SetValue(obj, value);
        }

        public virtual Dictionary<string, object> GetParams(bool deep = true)
        {
            object value;
            var @out = new Dictionary<string, object>();
            foreach (var key in GetParamNames(this.GetType()))
            {
                try
                {
                    value = GetAttr(this, key);
                }
                catch (Exception ex)
                {
                    Logger.Warning("From version 0.24, get_params will raise an AttributeError if a parameter cannot be retrieved as an instance attribute. Previously it would return None.");
                    value = null;
                }

                if (deep)
                {
                    if (value is BaseEstimator)
                    {
                        var deep_items = ((BaseEstimator)value).GetParams();
                        foreach (var item in deep_items)
                        {
                            @out[item.Key] = item.Value;
                        }
                    }
                }

                @out[key] = value;
            }
            return @out;
        }

        public virtual BaseEstimator SetParams(Dictionary<string, object> @params)
        {
            string key;
            if (@params == null) {
                // Simple optimization to gain speed (inspect is slow)
                return this;
            }

            var valid_params = this.GetParams(deep: true);
            var nested_params = new Dictionary<string, Dictionary<string, object>>();
            foreach (var item in @params) 
            {
                key = item.Key;
                var value = item.Value;
                var splitKey = key.Split(new string[] { "__" }, StringSplitOptions.RemoveEmptyEntries);
                key = splitKey[0];
                var delim = "__";
                var sub_key = splitKey[2];
                if (!valid_params.ContainsKey(key))
                {
                    throw new Exception($"Invalid parameter {key} for estimator {this}. Check the list of available parameters with `estimator.get_params().keys()`.");
                }

                if (!string.IsNullOrWhiteSpace(delim))
                {
                    nested_params[key][sub_key] = value;
                }
                else
                {
                    SetAttr(this, key, value);
                    valid_params[key] = value;
                }
            }

            foreach (var item in nested_params)
            {
                key = item.Key;
                var sub_params = item.Value;
                ((BaseEstimator)valid_params[key]).SetParams(sub_params);
            }
            return this;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public virtual Dictionary<string, object> MoreTags()
        {
            return _DEFAULT_TAGS;
        }

        public virtual Dictionary<string, object> GetTags()
        {
            return tags;
        }

        public static bool IsClassifier(BaseEstimator estimator)
        {
            return estimator._estimator_type == "classifier";
        }

        public static bool IsRegressor(BaseEstimator estimator)
        {
            return estimator._estimator_type == "regressor";
        }

        public static bool IsOutlierDetector(BaseEstimator estimator)
        {
            return estimator._estimator_type == "outlier_detector";
        }

        public static BaseEstimator Clone(BaseEstimator estimator, bool safe = true)
        {
            return (BaseEstimator)estimator.MemberwiseClone();
        }

        public static string PPrint(Dictionary<string, object> @params, int offset = 0, Func<object, string> printer = null)
        {
            string this_repr;
            var params_list = new List<string>();
            var this_line_length = offset;
            var line_sep = ",\n";

            if(printer == null)
            {
                printer = (obj) => obj.ToString();
            }

            foreach (var item in Enumerable.Range(0, (1 + offset / 2)))
            {
                line_sep += " ";
            }

            int i = 0;
            foreach (var p in @params) {
                var k = p.Key;
                var v = p.Value;
                if (v is float)
                {
                    // use str for representing floating point numbers
                    // this way we get consistent representation across
                    // architectures and versions.
                    this_repr = $"{k}={v}";
                }
                else
                {
                    // use repr of the rest
                    this_repr = String.Format("%s=%s", k, printer(v));
                }
                if (this_repr.Length > 500)
                {
                    this_repr = this_repr.Substring(0, 300) + "..." + this_repr.Substring(this_repr.Length - 100);
                }
                if (i > 0)
                {
                    if (this_line_length + this_repr.Length >= 75 || this_repr.Contains("\n"))
                    {
                        params_list.Add(line_sep);
                        this_line_length = line_sep.Length;
                    }
                    else
                    {
                        params_list.Add(", ");
                        this_line_length += 2;
                    }
                }

                params_list.Add(this_repr);
                this_line_length += this_repr.Length;
            }

            var lines = string.Join("", params_list.Select(x => x.TrimEnd()));
            // Strip trailing space to avoid nightmare in doctests
            return lines;
        }
    }
}
