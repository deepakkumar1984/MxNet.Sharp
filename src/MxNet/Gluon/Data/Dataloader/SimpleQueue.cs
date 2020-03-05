using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;

namespace MxNet.Gluon.Data.Vision
{
    public class SimpleQueue : Queue
    {
        private readonly ConnectionWrapper _reader;
        private _recvfn _recv;
        private _sendfn _send;
        private readonly ConnectionWrapper _writer;

        public SimpleQueue() : base(new List<NDArray>())
        {
            _reader = new ConnectionWrapper(new Socket(new SocketInformation
                {Options = SocketInformationOptions.Listening}));
            _writer = new ConnectionWrapper(new Socket(new SocketInformation
                {Options = SocketInformationOptions.Connected}));

            _send = _writer.Send;
            _recv = _reader.Recv;
        }

        private delegate void _sendfn(NDArray obj);

        private delegate NDArray _recvfn();
    }
}