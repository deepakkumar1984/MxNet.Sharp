using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon
{
    public class Utils
    {
        public static NDArray[] SplitData(NDArray data, int num_slice, int batch_axis = 0, bool even_split = true) => throw new NotImplementedException();

        public static NDArray[] SplitAndLoad(NDArray data, Context[] ctx_list, int batch_axis = 0, bool even_split = true) => throw new NotImplementedException();

        public static NDArray clip_global_norm(NDArray[] arrays,float  max_norm, bool check_isfinite= true) => throw new NotImplementedException();

        private string Indent(string s, int _numSpaces) => throw new NotImplementedException();

        public bool check_sha1(string filename, string sha1_hash) => throw new NotImplementedException();

        public void Download(string url, string path= "", bool overwrite= false, string sha1_hash= "", int retries= 5, bool verify_ssl= true) => throw new NotImplementedException();

        private string _get_repo_url() => throw new NotImplementedException();

        private string _get_repo_url(string @namespace, string filename) => throw new NotImplementedException();

        private void _brief_print_list<T>(List<T> lst, int limit= 7) => throw new NotImplementedException();

        public bool shape_is_known(Shape shape) => throw new NotImplementedException();

        public bool _check_same_symbol_type(Symbol[] symbols) => throw new NotImplementedException();

        public void _check_all_np_ndarrays(object @out) => throw new NotImplementedException();
    }
}
