using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace SocketTcpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                try
                {
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                    ProtocolType.Tcp);
                    IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1111);
                    // Подключаемся к серверу, используя метод Connect() и конечную удаленную точку
                    socket.Connect(remoteEP);

                    // Формируем и отправляем сообщение
                    byte[] data = Encoding.UTF8.GetBytes("Запрос клиента");
                    socket.Send(data);





                    ///////////////////////////////////////////////////////////////////////////////
                    //Socket newSocket = socket.Accept();
                    // Буфер для приема входящего сообщения
                    while (true) 
                    {
                        byte[] data1 = new byte[1024];
                        // Метод Receive() считывает данные в буфер
                        // и возвращает число успешно прочитанных байтов
                        int bytes = socket.Receive(data1);
                        // Преобразуем данные в строку
                        string message = null;
                        message += Encoding.UTF8.GetString(data1, 0, bytes);
                        // Отображаем полученное сообщение
                        Console.Write(message);
                    }
                    
                    ///////////////////////////////////////////////////////////




                    // Закрываем сокет
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    //Console.ReadLine();
                }
            }
            
          }
    }
}
