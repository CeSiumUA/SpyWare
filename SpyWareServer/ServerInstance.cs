using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SpyWareServer
{
    public class ServerInstance
    {
        public int LocalPort = 1488;
        private UdpClient UdpListener;
        private bool Listen = true;
        public delegate void UdpPacketReceivedHanlder(string text, IPEndPoint iPEndPoint);
        public event UdpPacketReceivedHanlder UdpPacketRecievedEvent;
        public ServerInstance(int LocalPort)
        {
            this.LocalPort = LocalPort;
            UdpListener = new UdpClient(LocalPort);
        }
        public void Startlistener()
        {
            new Task(Listener).Start();
        }
        public void StopReceiver()
        {
            Listen = false;
        }
        private async void Listener()
        {
            while (Listen)
            {
                IPEndPoint senderIP = null;
                UdpReceiveResult byteResult = await UdpListener.ReceiveAsync();
                senderIP = byteResult.RemoteEndPoint;
                UdpPacketRecievedEvent.Invoke(Encoding.Unicode.GetString(byteResult.Buffer), senderIP);
                //Відправка відповіді, не дуже потрібна :)
                //byte[] resp = Encoding.UTF8.GetBytes("response accepted!");
                //UdpListener.Send(resp, resp.Length, senderIP);
            }
        }
    }
}
