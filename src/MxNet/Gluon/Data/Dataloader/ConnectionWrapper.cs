/*****************************************************************************
   Copyright 2018 The MxNet.Sharp Authors. All Rights Reserved.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************/
using MxNet.Numpy;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace MxNet.Gluon.Data
{
    public class ConnectionWrapper
    {
        private readonly Socket _conn;

        public ConnectionWrapper(Socket conn)
        {
            _conn = conn;
        }

        public void Send(ndarray obj)
        {
            var buffer = obj.GetBuffer();
            _conn.Send(buffer);
        }

        public ndarray Recv()
        {
            var bufferSegment = new List<ArraySegment<byte>>();
            _conn.Receive(bufferSegment);
            var buffer = new List<byte>();
            foreach (var item in bufferSegment) buffer.AddRange(item.Array);

            return ndarray.LoadFromBuffer(buffer.ToArray());
        }
    }
}