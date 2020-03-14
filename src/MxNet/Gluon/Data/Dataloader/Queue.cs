using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Sockets;

namespace MxNet.Gluon.Data
{
    public class Queue<T> : ConcurrentQueue<QueueItem<T>>
    {
        private readonly ConnectionWrapper _reader;
        private _recvfn _recv;
        private _sendfn _send;
        private readonly ConnectionWrapper _writer;

        public Queue() : base(new List<QueueItem<T>>())
        {
            _reader = new ConnectionWrapper(new Socket(new SocketInformation
                {Options = SocketInformationOptions.Listening}));
            _writer = new ConnectionWrapper(new Socket(new SocketInformation
                {Options = SocketInformationOptions.Connected}));

            _send = _writer.Send;
            _recv = _reader.Recv;
        }

        public QueueItem<T> Get()
        {
            TryDequeue(out var ret);
            return ret;
        }

        private delegate void _sendfn(NDArray obj);

        private delegate NDArray _recvfn();
    }

    public class QueueItem<T>
    {
        public QueueItem(int idx, T[] samples)
        {
            Idx = idx;
            Samples = samples;
        }

        public int Idx { get; set; }

        public T[] Samples { get; set; }
    }
}