using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPLib
{
    public class TCPAsyncEcho : TCP
    {
        public delegate void TransmissionDataDelegate(NetworkStream stream);
        public TCPAsyncEcho(IPAddress IP, int port) : base(IP, port)
        {
        }

        protected override void AcceptClient() {
            while (true) {
                TcpClient tcpClient = TcpListener.AcceptTcpClient();
                Stream = tcpClient.GetStream();
                TransmissionDataDelegate transmissionDelegate = new TransmissionDataDelegate(BeginDataTransmission);
                //callback style
                transmissionDelegate.BeginInvoke(Stream, TransmissionCallback, tcpClient);
                // async result style
                //IAsyncResult result = transmissionDelegate.BeginInvoke(Stream, null, null);
                ////operacje......
                //while (!result.IsCompleted) ;
                ////sprzątanie
            }
        }



        protected void TransmissionCallback(IAsyncResult ar)
        {
            TcpClient tcpClient = (TcpClient)ar.AsyncState;
            tcpClient.Close();
        }
        protected override void BeginDataTransmission(NetworkStream stream)
        {
            stream.ReadTimeout = 10000;
            byte[] buffer = new byte[Buffer_size];
            while (true) {
                try {
                    int message_size = stream.Read(buffer, 0, Buffer_size);
                    stream.Write(buffer, 0, message_size);
                }
                catch (IOException e) {
                    break;
                }
            }
        }
        public override void Start()
        {
            Running = true;
            StartListening();
            //transmission starts within the accept function
            AcceptClient();
        }

    }
}
