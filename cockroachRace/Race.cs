using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cockroachRace
{
    public class Race
    {
        private static Tarcoon[] tarcoons;
        private static int MaxSiz; 
        private Race() 
        { 
        
        }
        
        public static void CreateTarcoons(int quantityOfTarcoonns, int maxSpeed, int minSpeed)
        {
            tarcoons = new Tarcoon[quantityOfTarcoonns];
            for (int i = 0; i < quantityOfTarcoonns; i++)
            {
                Random random = new Random();
                tarcoons[0] = new Tarcoon(random.Next(minSpeed, maxSpeed));
            }
        }
        public static void CreateField(int ciels)
        {
            for (int i = 0; i < tarcoons.Length; i++)
            {
            }
        }
    }
}
