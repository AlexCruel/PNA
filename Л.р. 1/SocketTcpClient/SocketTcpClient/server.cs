using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace SocketTcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем сокет (данный сокет используется только для установки соединения)
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Устанавливаем для сокета локальную конечную точку
            IPEndPoint localEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1111);

            while (true)
            {
                try
                {
                    // Связываем сокет с локальной точкой, по которой будем принимать данные
                    socket.Bind(localEP);
                    // Начинаем слушать (ожидать подключений со стороны клиентов)
                    socket.Listen(5);
                    Console.WriteLine("Сервер запущен. Ожидание подключений...");

                    // Метод Accept извлекает из очереди ожидающих запросов первый запрос
                    // и создает для его обработки объект Socket.
                    // Если очередь запросов пуста, то метод Accept
                    // блокирует вызывающий поток до появления нового подключения

                    while (true)
                    {
                        Socket newSocket = socket.Accept();

                        // Буфер для приема входящего сообщения
                        byte[] data = new byte[1024];
                        // Метод Receive() считывает данные в буфер
                        // и возвращает число успешно прочитанных байтов
                        int bytes = newSocket.Receive(data);
                        // Преобразуем данные в строку
                        string message = null;
                        message += Encoding.UTF8.GetString(data, 0, bytes);
                        // Отображаем полученное сообщение
                        Console.Write(message);


                        /////////////////////////////////////////////////////////////////////////
                        byte[] data1 = Encoding.UTF8.GetBytes("Ответ сервера");
                        newSocket.Send(data1);
                        Console.WriteLine("\nОтправил клиенту ответ");



                        /////////////////////////////////////////////////////////////////////////

                        // Закрываем сокет созданный методом Accept()
                        newSocket.Shutdown(SocketShutdown.Both);
                        newSocket.Close();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    Console.ReadLine();
                }
            }

        }
    }
}
