using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace MxNet.Gluon.Data.Vision
{
    public class ConnectionWrapper
    {
        private readonly Socket _conn;

        public ConnectionWrapper(Socket conn)
        {
            _conn = conn;
        }

        public void Send(NDArray obj)
        {
            var buffer = obj.GetBuffer();
            _conn.Send(buffer);
        }

        public NDArray Recv()
        {
            var bufferSegment = new List<ArraySegment<byte>>();
            _conn.Receive(bufferSegment);
            var buffer = new List<byte>();
            foreach (var item in bufferSegment) buffer.AddRange(item.Array);

            return NDArray.LoadFromBuffer(buffer.ToArray());
        }
    }
}