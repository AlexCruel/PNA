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
            UdpClient udpClient = new UdpClient();
            udpClient.Connect("127.0.0.1", 5001);
            // Формируем сообщение
            byte[] sendBytes = Encoding.Unicode.GetBytes("Ваше сообщение");
            // Отправляем сообщение, указывая IP-адрес и номер порта получателя
            udpClient.Send(sendBytes, sendBytes.Length);
            udpClient.Close();
        }
    }
}
