using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q6.3) Design an algorithm that takes a sequence of n- three dimensional coordinates to be traversed, and returns the minimum battery capacity needed to 
            complete the journey. The robot begins with a fully charged battery
*/

namespace EPI6_3
{
    struct coordinate
    {
        public int x;
        public int y;
        public int z;
    }
    class Program
    {
        static int minBatteryCapacity(List<coordinate> coordinates)
        {
            int maxAscentSoFar = 0;

            int ascent = 0;
            for(int i = 0; i < coordinates.Count() - 1; i++)
            {
                if (isAscent(coordinates.ElementAt(i), coordinates.ElementAt(i + 1)))
                    ascent += coordinates.ElementAt(i+1).z - coordinates.ElementAt(i).z;
                else
                    ascent = 0;

                if (ascent > maxAscentSoFar)
                    maxAscentSoFar = ascent;
            }

            return maxAscentSoFar;    
        }

        static int distVerticalDistBetween(coordinate from, coordinate to)
        {            
            return to.z - from.z;            
        }
        static bool isAscent(coordinate from, coordinate to)
        {
            if (to.z - from.z > 0)
                return true;

            return false;
        }

#if(TEST_Q3)
        static void Main(string[] args)
        {
            List<coordinate> coordinates = new List<coordinate>();
            coordinates.Add(new coordinate { x= 0, y=0, z=0});
            coordinates.Add(new coordinate { x = 0, y = 0, z = 1 });
            coordinates.Add(new coordinate { x = 0, y = 0, z = 2 });
            coordinates.Add(new coordinate { x = 0, y = 0, z = 1 });
            coordinates.Add(new coordinate { x = 0, y = 0, z = 0 });
            coordinates.Add(new coordinate { x = 0, y = 0, z = 1 });
            coordinates.Add(new coordinate { x = 0, y = 0, z = 2 });
            coordinates.Add(new coordinate { x = 0, y = 0, z = 1 });
            coordinates.Add(new coordinate { x = 0, y = 0, z = 4 });

            Console.Out.WriteLine("Capacity: {0}", minBatteryCapacity(coordinates));
            Console.ReadKey();
        }
#endif
    }
}
