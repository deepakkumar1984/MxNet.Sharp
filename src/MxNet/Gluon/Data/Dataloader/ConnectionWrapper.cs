using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision
{
    public class ConnectionWrapper
    {
        public ConnectionWrapper(Socket conn) => throw new NotImplementedException();

        public void Send(NDArray obj) => throw new NotImplementedException();

        public NDArray Recv() => throw new NotImplementedException();
    }
}
