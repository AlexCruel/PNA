﻿using System;
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
                byte[] data = new byte[256];
                int bytes = stream.Read(data, 0, data.Length); // Читаем сообщение 
                // Отображаем сообщение 
                Console.WriteLine(Encoding.UTF8.GetString(data, 0, bytes));

                //отправка полученного сообщения обратно клиенту
                byte[] data1 = Encoding.UTF8.GetBytes("happy");
                stream.Write(data1, 0, data1.Length);

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
