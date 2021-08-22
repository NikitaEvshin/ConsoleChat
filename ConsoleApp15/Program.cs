using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Dapper;
using Npgsql;

namespace ConsoleApp15
{
    class Program
    {
        static void Main(string[] args)
        {
            NpgsqlConnection connection = new NpgsqlConnection("User ID=user1;Password=changeme;Host=130.193.55.186;Port=5432;Database=tododb;");

            try
            {
                Console.WriteLine("Введите имя");

                string UserName = Console.ReadLine();
                while (string.IsNullOrEmpty(UserName))
                {
                        Console.WriteLine("Недопустимое имя");
                        UserName = Console.ReadLine();
                }
                User user = new(UserName);
                Console.WriteLine("Введите сообщение");
                List<Friend> message = connection.Query<Friend>("SELECT * FROM \"Messages\"").ToList();
                UpdatTimer tm = new UpdatTimer(message);
                Timer timer = new Timer(tm.TimerChat, null, 1, 5000);
                while (true)
                {
                    if (true)
                    {
                        string Message = Console.ReadLine();
                        connection.Query($"Insert into \"Messages\" (\"Name\", \"Message\", \"Time\") values ('{user.Name}', '{Message}', '{DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm")}')");
                        while (string.IsNullOrEmpty(Message))
                        {
                            Console.WriteLine("Пустое сообщение");
                            Message = Console.ReadLine();
                        }
                    }
                }

            }
            finally
            {
                connection.Dispose();
            }
        }
    }
}
