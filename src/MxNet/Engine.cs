using MxNet.Interop;

namespace MxNet
{
    public class Engine
    {
        public static int SetBulkSize(int size)
        {
            var prev = 0;
            NativeMethods.MXEngineSetBulkSize(size, ref prev);
            return prev;
        }

        public static _BulkScope Bulk(int size)
        {
            return new _BulkScope(size);
        }

        public class _BulkScope : MxDisposable
        {
            private int _old_size;
            private readonly int _size;

            public _BulkScope(int size)
            {
                _size = size;
            }

            public override MxDisposable Enter()
            {
                _old_size = SetBulkSize(_size);
                return this;
            }

            public override void Exit()
            {
                SetBulkSize(_old_size);
            }
        }
    }
}