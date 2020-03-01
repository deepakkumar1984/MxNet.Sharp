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
        private Socket _conn;
        public ConnectionWrapper(Socket conn)
        {
            _conn = conn;
        }

        public void Send(NDArray obj)
        {
            byte[] buffer = obj.GetBuffer();
            _conn.Send(buffer);
        }

        public NDArray Recv()
        {
            List<ArraySegment<byte>> bufferSegment = new List<ArraySegment<byte>>();
            _conn.Receive(bufferSegment);
            var buffer = new List<byte>();
            foreach (var item in bufferSegment)
            {
                buffer.AddRange(item.Array);
            }

            return NDArray.LoadFromBuffer(buffer.ToArray());
        }
    }
}
