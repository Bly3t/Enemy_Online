using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace enemyOnline
{
    class Program
    {
        private static List<String> enemiesList = new List<String>(); // List of all enemies
        public static List<String> Player_Online = new List<String>(); // All online players
        static readonly string textFile =  "enemies.txt";

        private static void GetEnemies()
        {
            String[] enemyArray = File.ReadAllLines(textFile);

            foreach (var enemy in enemyArray)
            {
                enemiesList.Add(enemy);
            }
        }


        static void Main(string[] args)
        {
            GetEnemies();
            Player_Online = Enemy.RunApi();
            foreach (var item in Player_Online)
            {
                foreach (var item2 in enemiesList)
                {
                    if (item2.Equals(item))
                    {
                        Console.WriteLine(item2);
                    }
                }
            }
            Console.ReadKey();

            
        }
    }
}
