using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace MxNet.Gluon.Data.Vision
{
    public class Queue<T> : ConcurrentQueue<QueueItem<T>>
    {
        private ConnectionWrapper _reader;
        private ConnectionWrapper _writer;
        private delegate void _sendfn(NDArray obj);
        private delegate NDArray _recvfn();
        private _sendfn _send;
        private _recvfn _recv;
        public Queue() : base(new List<QueueItem<T>>())
        {
            _reader = new ConnectionWrapper(new Socket(new SocketInformation() { Options = SocketInformationOptions.Listening }));
            _writer = new ConnectionWrapper(new Socket(new SocketInformation() { Options = SocketInformationOptions.Connected }));

            _send = _writer.Send;
            _recv = _reader.Recv;
        }

        public QueueItem<T> Get()
        {
            this.TryDequeue(out var ret);
            return ret;
        }
    }

    public class QueueItem<T>
    {
        public int Idx { get; set; }

        public T[] Samples { get; set; }

        public QueueItem(int idx, T[] samples)
        {
            Idx = idx;
            Samples = samples;
        }
    }
}
