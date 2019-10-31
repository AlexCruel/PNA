using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace SocketSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            EndPoint remoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1111);

            while (true) 
            {
                // формируем сообщение
                Console.Write("Введите сообщение: ");
                string message = Console.ReadLine();
                byte[] data = Encoding.Unicode.GetBytes(message);

                // отправляем сообщение
                socket.SendTo(data, remoteEP); // в метод передается массив отправляемых данных, а также адрес, по которому эти данные необходимо отправить

             
                /////////////////////////////////////////////////////////////////////////////////////
                // получаем сообщение
                string message1 = null;
                byte[] data1 = new byte[256]; // буфер для приема данных

                // адрес, с которого пришли данные
                //EndPoint remoteEP1 = new IPEndPoint(IPAddress.Any, 0);
                int bytes = socket.ReceiveFrom(data1, ref remoteEP);
                message1 += Encoding.UTF8.GetString(data1, 0, bytes);

                // получаем данные о подключении
                IPEndPoint fullRemoteEP = remoteEP as IPEndPoint;

                // выводим сообщение
                Console.WriteLine("{0}:{1}-{2}", fullRemoteEP.Address.ToString(),
                fullRemoteEP.Port, message1);
                //////////////////////////////////////////////////////////////////////////////////////
            }
            

            // закрываем сокет
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
