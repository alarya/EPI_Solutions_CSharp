using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    6.1 Write a function that takes an Array A and an index i into A, and rearranges the elements
    such that all elements less than A[i] appear first, followed by elements equal to A[i], followed
    by elements greater than A[i]. Your algorithm should have O(1) space complexity and O(|A|) time 
    complexity  
*/
namespace EPI6_1
{
    class Program
    {
        static void swap(ref int[] Array, int i, int j)
        {
            int temp = Array[j];
            Array[j] = Array[i];
            Array[i] = temp;
        }

        /* Book solution */
        public static void Sort(ref int[] Array, int index)
        {
            int pivot = Array[index];
            int smaller = 0;
            int equal = 0;
            int larger = Array.Count() - 1;

            while(equal <= larger)
            {
                if (Array[equal] < pivot)
                {
                    swap(ref Array, equal++, smaller++);
                }
                else if (Array[equal] == pivot)
                {
                    ++equal;
                }
                else   //A[equal]> pivot
                    swap(ref Array, equal, larger--);
            }

        }
        /*My solutions:which fails certain cases 
        public static void countSort(ref int[] Array, int index)
        {
            int number = Array[index];
            //put the element to last location
            swap(ref Array, index, Array.Count() - 1);
            index = Array.Count() - 1;
            int i = 0;
            int j = Array.Count() - 2; //2nd last element
            while(i < j)
            {
                if(Array[i] > number && Array[j] > number)
                {
                    swap(ref Array, j - 1, i);
                    swap(ref Array, j - 1, index);
                    index = j - 1;
                    j -= 2;
                    continue;
                }
                if(Array[j] > number && Array[i] < number)
                {
                    swap(ref Array, j, index);
                    index = j;
                    j--;
                    continue;
                }

                if(Array[i] > number && Array[j] < number)
                {
                    swap(ref Array, i, j);
                    swap(ref Array, index, j);
                    i++;
                    index = j;
                    j--;
                    continue;
                }
                if(Array[i] < number && Array[j] < number)
                {
                    i++;
                    continue;
                }

                if(Array[i] == number && Array[j] < number )
                {
                    swap(ref Array, j, i);
                    index--;
                    j--;
                    continue;
                }
                if (Array[i] < number && Array[j] == number)
                {
                    swap(ref Array, i, j - 1);
                    j -= 2;
                }
                if (Array[i] == number && Array[j] == number)
                {
                    swap(ref Array, i, j - 1);
                    j -= 2;
                }
            }*/

#if(TEST_Q1)
        static void Main(string[] args)
        {
            int[] Array = { 7, 8, 1, 3, 4, 10, 11 };
            Sort(ref Array, 1);
            Console.Out.WriteLine();
            for (int i =0; i < Array.Count() -1;i++)
            {
                
                Console.Out.Write("{0} ", Array[i]);
            }
            Console.Out.WriteLine();

            int[] Array1 = { 11 , 8, 0 , 6, 4, 10, 11 };
            Sort(ref Array1, 0);
            Console.Out.WriteLine();
            for (int i = 0; i < Array1.Count() - 1; i++)
            {

                Console.Out.Write("{0} ", Array1[i]);
            }
            Console.Out.WriteLine();

            int[] Array2 = { 11, 8, 0, 6, 4, 10, 11 };
            Sort(ref Array2, 1);
            Console.Out.WriteLine();
            for (int i = 0; i < Array2.Count() - 1; i++)
            {

                Console.Out.Write("{0} ", Array2[i]);
            }
            Console.Out.WriteLine();

            int[] Array3 = { 1, 2, 3, 4, 4, 10, 11 };
            Sort(ref Array3, 3);
            Console.Out.WriteLine();
            for (int i = 0; i < Array3.Count() - 1; i++)
            {

                Console.Out.Write("{0} ", Array3[i]);
            }

            Console.Out.WriteLine();

            Console.ReadKey();
        }
#endif
    }
}
