using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            // Указываем локальный порт для прослушивания входящих сообщений
            UdpClient receivingUdpClient = new UdpClient(5001);
            // Адрес входящего подключения
            IPEndPoint remoteIPEndPoint = null;
            try
            {
                while (true)
                {
                    // Получаем данные
                    byte[] receiveBytes = receivingUdpClient.Receive(ref remoteIPEndPoint);
                    string returnData = Encoding.Unicode.GetString(receiveBytes);
                    Console.WriteLine("Входящее сообщение: {0}, адрес входящего подключения: {1}", returnData, remoteIPEndPoint.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                receivingUdpClient.Close();
            }
        }
    }
}
