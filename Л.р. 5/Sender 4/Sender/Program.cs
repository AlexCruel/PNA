using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient(8001);
            // Формируем сообщение
            byte[] sendBytes = Encoding.Unicode.GetBytes("Ваше сообщение");
            // Отправляем сообщение, указывая IP-адрес и номер порта получателя
            udpClient.Send(sendBytes, sendBytes.Length, "127.0.0.2", 5001);
            udpClient.Close();
        }
    }
}
