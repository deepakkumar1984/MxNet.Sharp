using System.Collections.Generic;
using System.Runtime.InteropServices;
using MxNet.Interop;
using DataIterHandle = System.IntPtr;

// ReSharper disable once CheckNamespace
namespace MxNet
{
    public sealed class MXDataIterMap
    {
        #region Fields

        private readonly Dictionary<string, DataIterHandle> _DataIterCreators;

        #endregion

        #region Constructors

        public MXDataIterMap()
        {
            var r = NativeMethods.MXListDataIters(out var numDataIterCreators, out var dataIterCreators);
            Logging.CHECK_EQ(r, 0);


            _DataIterCreators = new Dictionary<string, DataIterHandle>((int) numDataIterCreators);

            var array = InteropHelper.ToPointerArray(dataIterCreators, numDataIterCreators);
            for (var i = 0; i < numDataIterCreators; i++)
            {
                r = NativeMethods.MXDataIterGetIterInfo(array[i],
                    out var name,
                    out var description,
                    out var num_args,
                    out var arg_names2,
                    out var arg_type_infos2,
                    out var arg_descriptions2);

                Logging.CHECK_EQ(r, 0);

                var str = Marshal.PtrToStringAnsi(name);
                _DataIterCreators.Add(str, array[i]);
            }
        }

        #endregion

        #region Methods

        public DataIterHandle GetMXDataIterCreator(string name)
        {
            return _DataIterCreators[name];
        }

        #endregion
    }
}