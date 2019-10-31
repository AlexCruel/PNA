using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebSocket
{
    class Program
    {
        // Client
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main(string[] args)
        {
            socket.Connect("127.0.0.1", 904);

            string message = Console.ReadLine();
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            socket.Send(buffer);
            Console.ReadLine();
        }
    }
}
