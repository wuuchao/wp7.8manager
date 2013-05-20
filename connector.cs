using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace 背单词对战.connection
{
    class connector
    {
        private Socket _socket = null;
        private static ManualResetEvent _clientDone = new ManualResetEvent(false);
        private const int TIMEOUT_MILLISECONDS = 5000;
        private const int MAX_BUFFER_SIZE = 2048;

        public connector()
        {

        }

        public string Connect(string adressUri, int port)
        {
            string result = string.Empty;
            DnsEndPoint hostEntry = new DnsEndPoint(adressUri, port);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            SocketAsyncEventArgs _socketAsyncEventArgs = new SocketAsyncEventArgs();
            _socketAsyncEventArgs.RemoteEndPoint = hostEntry;
            _socketAsyncEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(delegate(object s, SocketAsyncEventArgs e)
                {
                    result = e.SocketError.ToString();

                    _clientDone.Set();
                }
                );
            _clientDone.Reset();

            _socket.ConnectAsync(_socketAsyncEventArgs);
            _clientDone.WaitOne(TIMEOUT_MILLISECONDS);
            return result;
        }

        public string Send(string data)
        {
            string response = "time out";
            if (_socket != null)
            {
                SocketAsyncEventArgs _socketAsyncEventArgs = new SocketAsyncEventArgs();
                _socketAsyncEventArgs.RemoteEndPoint = _socket.RemoteEndPoint;

                _socketAsyncEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(delegate(object s, SocketAsyncEventArgs e)
                    {
                        response = e.SocketError.ToString();

                        _clientDone.Set();
                    }
                    );

                byte[] payload = Encoding.UTF8.GetBytes(data);
                _socketAsyncEventArgs.SetBuffer(payload, 0, payload.Length);

                _clientDone.Reset();

                _socket.SendAsync(_socketAsyncEventArgs);

                _clientDone.WaitOne(TIMEOUT_MILLISECONDS);
            }
            else
            {
                response = "Socket is not init";
            }
            return response;
        }

        public string Receive()
        {
            string response = "time out";
            if (_socket != null)
            {
                SocketAsyncEventArgs _socketAsyncEventArgs = new SocketAsyncEventArgs();

                _socketAsyncEventArgs.RemoteEndPoint = _socket.RemoteEndPoint;
                _socketAsyncEventArgs.SetBuffer(new byte[MAX_BUFFER_SIZE], 0, MAX_BUFFER_SIZE);

                _socketAsyncEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(delegate(object s, SocketAsyncEventArgs e)
                    {
                        if (e.SocketError == SocketError.Success)
                        {
                            response = e.SocketError.ToString();
                            response = response.Trim('\0');
                        }
                        else
                            response = e.SocketError.ToString();

                        _clientDone.Set();
                    });
                _clientDone.Reset();

                _socket.ReceiveAsync(_socketAsyncEventArgs);

                _clientDone.WaitOne(TIMEOUT_MILLISECONDS);
            }
            else
            {
                response = "Socket is not init";
            }
            return response;
        }

        public void Close()
        {
            _socket.Close();
        }
    }
}
