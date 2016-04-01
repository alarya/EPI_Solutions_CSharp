using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
       Q8.6) Design an algorithm that processes buildings as they are presented to it and tracks the buildings that have a view of the sunset.
             The number of the buildings is not known in advance. Buildings are given in east-to-west order and are specified by their heights. 
             The amount of memory your algorithm uses should depend solely on the number of buildings that have a view; in particular it should not 
             depend on the number of buildings processed.
*/

namespace EPI8_6
{
    class Program
    {
        static int maxSoFar = 0;
        static void addBuilding(ref Stack<int> buildingsWithView, int building)
        {
            if(building >= maxSoFar)
            {
                //remove all previous buildings, add this building, and update maxSoFar
                while (buildingsWithView.Count() != 0)
                    buildingsWithView.Pop();

                buildingsWithView.Push(building);
                maxSoFar = building;
            }
            else
            {
                buildingsWithView.Push(building);
            }

            printstack(ref buildingsWithView);
        }
        static void printstack (ref Stack<int> buildingsWithView)
        {
            Console.Out.WriteLine("Current buildings with view:");
            List<int> buildings = new List<int>();
            while (buildingsWithView.Count != 0)
                buildings.Add(buildingsWithView.Pop());

            foreach (int building in buildings)
            {
                Console.Out.Write(building + " ");
            }

            Console.Out.WriteLine();

            while(buildings.Count != 0)
            {
                buildingsWithView.Push(buildings.Last());
                buildings.RemoveAt(buildings.Count-1);
            }
        }
#if (TEST_Q6)
        static void Main(string[] args)
        {

            Stack<int> buildingsWithView = new Stack<int>();

            addBuilding(ref buildingsWithView, 20);

            addBuilding(ref buildingsWithView, 15);

            addBuilding(ref buildingsWithView, 14);

            addBuilding(ref buildingsWithView, 20);

            addBuilding(ref buildingsWithView, 100);
            Console.ReadKey();
        }
#endif

    }
}
