﻿using System;
using System.IO;
using System.Net.Sockets;

namespace NModbusAsync.IO
{
    internal sealed class TcpClientAdapter<TResource> : IStreamResource<TResource> where TResource : TcpClient
    {
        internal TcpClientAdapter(TResource tcpClient)
        {
            Resource = tcpClient ?? throw new ArgumentNullException(nameof(tcpClient));
        }

        public TResource Resource { get; }

        public Stream GetStream()
        {
            return Resource.GetStream();
        }

        public void Dispose()
        {
            Resource.Dispose();
        }
    }
}