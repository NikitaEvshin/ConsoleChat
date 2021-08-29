using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ConsoleApp15;
using Dapper;
using Npgsql;

namespace Message
{
    class Program
    {
        static void Main(string[] args)
        {
            NpgsqlConnection connection = new NpgsqlConnection("User ID=user1;Password=changeme;Host=130.193.55.186;Port=5432;Database=tododb;");

            try
            {
                Console.WriteLine("Введите имя");

                string userName = Console.ReadLine();
                while (string.IsNullOrEmpty(userName))
                {
                    Console.WriteLine("Недопустимое имя");
                    userName = Console.ReadLine();
                }
                User user = new(userName);
                Console.WriteLine("Введите сообщение");
                Console.WriteLine("Для закрытия чата пропишите <Закрыть чат>");
                UpdatTimer tm = new UpdatTimer();
                
                while (true)
                {
                        string messages = Console.ReadLine();
                        if (string.IsNullOrEmpty(messages))
                        {
                            Console.WriteLine("Пустое сообщение");
                            messages = Console.ReadLine();
                        }
                        if (messages == "Закрыть чат")
                    {
                        Environment.Exit(0);
                    }
                    connection.Query($"Insert into \"Messages\" (\"Name\", \"Message\", \"Time\") values ('{user.Name}', '{messages}', '{DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm")}')");
                }
            }
            finally
            {
                connection.Dispose();
            }
        }
    }
}
