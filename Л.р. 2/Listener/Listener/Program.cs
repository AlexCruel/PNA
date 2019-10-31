using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTcpListener
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                TcpListener server = new TcpListener(localAddr, 5001);
                // Запускаем сервер 
                server.Start();
                Console.WriteLine("Ожидание подключений... ");
                // Получаем входящее подключение 
                TcpClient client = server.AcceptTcpClient();
                // Получаем сетевой поток для чтения и записи 
                NetworkStream stream = client.GetStream();

                StringBuilder response = new StringBuilder();

                byte[] data = new byte[256];
                int bytes = stream.Read(data, 0, data.Length); // Читаем сообщение 
                response.Append(Encoding.UTF8.GetString(data, 0, bytes));
                // Отображаем сообщение 
                Console.WriteLine(Encoding.UTF8.GetString(data, 0, bytes));

                //отправка полученного сообщения обратно клиенту
                string[] arrayWords = response.ToString().Split(' ');
                if (arrayWords.Length == 2)
                {
                    int number1 = 0;
                    int number2 = 0;

                    bool word1 = int.TryParse(arrayWords[0], out number1);
                    bool word2 = int.TryParse(arrayWords[1], out number2);

                    if (word1 == true)
                        Console.WriteLine("Преобразование прошло успешно");
                    else
                        Console.WriteLine("Преобразование завершилось неудачно");

                    if (word2 == true)
                        Console.WriteLine("Преобразование прошло успешно");
                    else
                        Console.WriteLine("Преобразование завершилось неудачно");

                    if (word1 == true && word2 == true)
                    {
                        string sum = (number1 + number2).ToString() + "\n";
                        data = Encoding.UTF8.GetBytes(sum);
                    }
                }
                stream.Write(data, 0, data.Length);

                stream.Close();
                client.Close();
                // Закрываем слушающий объект 
                server.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
