using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp15
{
  class UpdatTimer
    {
       static List<Friend> Message;


        public UpdatTimer(List<Friend> message)
        {
            Message = message;
        }

       public void TimerChat(object o)
        {
            NpgsqlConnection Connection = new NpgsqlConnection("User ID=user1;Password=changeme;Host=130.193.55.186;Port=5432;Database=tododb;");
            try
            {
            Console.Clear();
            Message = Connection.Query<Friend>("SELECT * FROM \"Messages\" Order by \"Id\"").ToList();
            foreach (Friend friend in Message)
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
