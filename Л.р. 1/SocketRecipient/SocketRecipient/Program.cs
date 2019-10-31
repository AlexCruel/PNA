using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace SocketRecipient
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint localEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1111);
            socket.Bind(localEP);
            Console.Write("Ожидание подключений:");

            while (true) 
            {
                // получаем сообщение
                string message = null;
                byte[] data = new byte[256]; // буфер для приема данных

                // адрес, с которого пришли данные
                EndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
                int bytes = socket.ReceiveFrom(data, ref remoteEP);
                message += Encoding.UTF8.GetString(data, 0, bytes);

                // получаем данные о подключении
                IPEndPoint fullRemoteEP = remoteEP as IPEndPoint;

                // выводим сообщение
                Console.WriteLine("{0}:{1}-{2}", fullRemoteEP.Address.ToString(),
                fullRemoteEP.Port, message);


                ////////////////////////////////////////////////////////////////////////
                Console.Write("Ответить клиенту: ");
                string messageSend = Console.ReadLine();
                byte[] dataSend = Encoding.Unicode.GetBytes(messageSend);
                socket.SendTo(dataSend, remoteEP);
                ///////////////////////////////////////////////////////////////////////
            }
            


            // закрываем сокет
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            Console.ReadLine();
        }
    }
}
