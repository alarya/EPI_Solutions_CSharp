using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Longest contiguous increasing array

    Q6.6) Design and implement an algorithm that takes as input an array A of n elements, and returns the beginning 
          and ending indices of a longest increasing subarray of A
*/

namespace EPI6_Q6
{
    class Program
    {
        static void LCIA(int[] Arr)
        {
            int maxLength = 0;
            int startIndex = 0;
            int endIndex = 0;

            int i = 0;
            while(i < Arr.Count())
            {

                int j = i;
                while (j < Arr.Count() - 1 && Arr[j] < Arr[j + 1])
                    j++;

                if (j - i + 1 > maxLength)
                {
                    maxLength = j - i + 1;
                    startIndex = i;
                    endIndex = j;
                  
                }
                if (j > 1)
                {
                    i = j + 1;
                }
                else
                    i++;
            }

            Console.Out.WriteLine("maxlength: {0}, start: {1}, end: {2}",maxLength,startIndex,endIndex);
        }

#if (TEST_Q6)
        static void Main(string[] args)
        {
            int[] n = new int[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 3, 4, 5, 6, 7 };

            //int[] n = new int[] { 1 };

            LCIA(n);

            Console.ReadKey();
        }
#endif
    }
}
