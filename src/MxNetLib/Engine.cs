using System;
using System.Collections.Generic;
using System.Text;

namespace MxNetLib
{
    public class Engine
    {
        public class _BulkScope : MxDisposable
        {
            public _BulkScope(int size)
            {
                throw new NotImplementedException();
            }

            public override void Enter()
            {
                throw new NotImplementedException();
            }

            public override void Exit()
            {
                throw new NotImplementedException();
            }
        }

        public int SetBulkSize(int size) => throw new NotImplementedException();

        public _BulkScope Bulk(int size) => throw new NotImplementedException();
    }
}
