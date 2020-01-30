using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Densityv2.Models;

namespace Densityv2
{
    class Program
    {
        public static DensityIOClient densityClient = new DensityIOClient();

        static void Main(string[] args)
        {
            Timer t = new Timer(HandleTimerElapsed, null, 0, 5000);
            Console.ReadLine();
        }

        public static void HandleTimerElapsed(Object o)
        {
            ListOccupancyForSpaces();
        }

        public static void ListOccupancyForSpaces()
        {
            var allTheSpaces = densityClient.ListSpaces().Result;
            if (allTheSpaces != null && allTheSpaces.Any())
            {
                //don't really need to check if list has anything for purposes of this exercise, since we
                //know that spaces meeting the criteria do in fact exist
                var federalStreetSpaces =
                    allTheSpaces.Where(x => x.Ancestry.Contains(new Ancestry {Name = "800 Federal Street"})).ToList();

                foreach (var s in federalStreetSpaces)
                {
                    Console.Write($"{DateTime.UtcNow} {s.Name}: {s.CurrentCount}\n");
                }
                Console.Write("\n");
            }
            else
            {
                Console.Write("We couldn't find any spaces. Goodbye.");
            }
        }
    }
}
