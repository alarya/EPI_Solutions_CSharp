using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeArea
{
    class Program
    {
        static void sort(ref int[] Arr, int index)
        {
            int number = Arr[index];
            int smaller = 0;
            int equal = 0;
            int larger = Arr.Count() - 1;

            while(equal <= larger)
            {
                if (Arr[equal] < number)
                {
                    swap(ref Arr, equal++, smaller++);
                }
                else if(Arr[equal] == number)
                {
                    ++equal;
                }
                else
                {
                    swap(ref Arr, equal, larger--);
                }
            }
            
            foreach(int n in Arr)
            {
                Console.Out.Write("{0} ",n);
            }
            
        }
        static void swap(ref int[] Arr, int i, int j)
        {
            int temp = Arr[i];
            Arr[i] = Arr[j];
            Arr[j] = temp;
        }
        static void Main(string[] args)
        {
            int[] Array = { 7, 8, 1, 3, 4, 10, 4 };
            sort(ref Array, 4);

            Console.ReadKey();
        }
    }
}
