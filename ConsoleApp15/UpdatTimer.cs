using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleApp15
{
   public class UpdatTimer
    {
        public Timer Timer;
        public UpdatTimer()
        {
            Timer = new Timer(TimerChat, null, 5000, 5000);
        }

    public void TimerChat(object o)
    {
        NpgsqlConnection Connection = new NpgsqlConnection("User ID=user1;Password=changeme;Host=130.193.55.186;Port=5432;Database=tododb;");
        try
        {
            Console.Clear();
            List<Friend> messages = Connection.Query<Friend>("SELECT * FROM \"Messages\" Order by \"Id\"").ToList();
            foreach (Friend friend in messages)
            {
                Console.WriteLine(friend);
            }
        }
        finally
        {
            Connection.Dispose();
        }
    }
}
}
