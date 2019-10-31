using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTcpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Создаем клиента, используя конструктор по умолчанию 
                TcpClient tcpClient = new TcpClient();
                // Подключаемся к серверу 
                tcpClient.Connect("127.0.0.1", 5001);
                // Создаем поток, соединенный с сервером 
                NetworkStream stream = tcpClient.GetStream();

                Console.WriteLine("Введите сообщение:");
                // Формируем сообщение. Преобразуем его в массив байтов 
                byte[] data = Encoding.UTF8.GetBytes(Console.ReadLine());
                // Отправка сообщения 
                stream.Write(data, 0, data.Length);

                //принимаем ответ сервера
                byte[] data1 = new byte[256];
                int bytes = stream.Read(data1, 0, data1.Length); // Читаем сообщение 
                Console.WriteLine(Encoding.UTF8.GetString(data1, 0, bytes));

                // Закрываем потоки 
                stream.Close();
                tcpClient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
            }
            Console.WriteLine("Запрос завершен...");
            Console.Read();
        }
    }
}
