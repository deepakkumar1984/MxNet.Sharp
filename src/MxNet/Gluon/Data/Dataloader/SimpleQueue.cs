using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.Data.Vision
{
    public class SimpleQueue : System.Collections.Queue
    {
        private ConnectionWrapper _reader;
        private ConnectionWrapper _writer;
        private delegate void _sendfn(NDArray obj);
        private delegate NDArray _recvfn();
        private _sendfn _send;
        private _recvfn _recv;

        public SimpleQueue() : base(new List<NDArray>())
        {
            _reader = new ConnectionWrapper(new Socket(new SocketInformation() { Options = SocketInformationOptions.Listening }));
            _writer = new ConnectionWrapper(new Socket(new SocketInformation() { Options = SocketInformationOptions.Connected }));

            _send = _writer.Send;
            _recv = _reader.Recv;
        }
    }
}
