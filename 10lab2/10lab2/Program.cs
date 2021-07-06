﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace _10lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            //string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TUTOR;Integrated Security=True";
            //string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //Console.WriteLine(connectionString);

            //Console.Read();

            string connectionString = @"Data Source=DESKTOP-OD6F0DG;Initial Catalog=TUTOR;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.OpenAsync();
                Console.WriteLine("Подключение открыто");
                // Вывод информации о подключении
                Console.WriteLine("Свойства подключения:");
                Console.WriteLine("\tСтрока подключения: {0}", connection.ConnectionString);
                Console.WriteLine("\tБаза данных: {0}", connection.Database);
                Console.WriteLine("\tСервер: {0}", connection.DataSource);
                //Console.WriteLine("\tВерсия сервера: {0}", connection.ServerVersion);
                Console.WriteLine("\tСостояние: {0}", connection.State);
                Console.WriteLine("\tWorkstationld: {0}", connection.WorkstationId);
            }
            Console.WriteLine("Подключение закрыто...");

            Console.Read();
        }
    }
}