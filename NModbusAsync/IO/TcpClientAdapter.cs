﻿using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using NModbusAsync.Utility;

namespace NModbusAsync.IO
{
    internal class TcpClientAdapter : IStreamResource
    {
        private TcpClient tcpClient;

        internal TcpClientAdapter(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient ?? throw new ArgumentNullException(nameof(tcpClient));
        }

        public int ReadTimeout
        {
            get => tcpClient.GetStream().ReadTimeout;
            set => tcpClient.GetStream().ReadTimeout = value;
        }

        public int WriteTimeout
        {
            get => tcpClient.GetStream().WriteTimeout;
            set => tcpClient.GetStream().WriteTimeout = value;
        }

        public Task WriteAsync(byte[] buffer, int offset, int count)
        {
            return WriteAsync(buffer, offset, count, default);
        }

        public Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken token)
        {
            return tcpClient.GetStream().WriteAsync(buffer, offset, count, token);
        }

        public Task<int> ReadAsync(byte[] buffer, int offset, int count)
        {
            return ReadAsync(buffer, offset, count, default);
        }

        public Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken token)
        {
            return tcpClient.GetStream().ReadAsync(buffer, offset, count, token);
        }

        public Task FlushAsync()
        {
            return FlushAsync(default);
        }

        public Task FlushAsync(CancellationToken token)
        {
            return tcpClient.GetStream().FlushAsync(token);
        }

        public void Dispose()
        {
            DisposableUtility.Dispose(ref tcpClient);
        }
    }
}