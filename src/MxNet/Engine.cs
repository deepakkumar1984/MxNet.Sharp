using MxNet.Interop;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet
{
    public class Engine
    {
        public class _BulkScope : MxDisposable
        {
            private int _size;
            private int _old_size;

            public _BulkScope(int size)
            {
                _size = size;    
            }

            public override void Enter()
            {
                _old_size = SetBulkSize(_size);
            }

            public override void Exit()
            {
                SetBulkSize(_old_size);
            }
        }

        public static int SetBulkSize(int size)
        {
            int prev = 0;
            NativeMethods.MXEngineSetBulkSize(size, ref prev);
            return prev;
        }

        public static _BulkScope Bulk(int size)
        {
            return new _BulkScope(size);
        }
    }
}
