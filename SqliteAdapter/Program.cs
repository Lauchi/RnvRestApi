using System;

namespace SqliteAdapter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new RnvScotlandYardContext())
            {
                db.GameSessions.Add(new GameSessionDb());
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var gameSession in db.GameSessions)
                {
                    Console.WriteLine(" - {0}", gameSession.GameSessionId);
                }
            }
        }
    }
}