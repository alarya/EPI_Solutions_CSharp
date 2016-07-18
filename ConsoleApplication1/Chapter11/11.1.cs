using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q11.1) Write a method that takes a sorted array A and a key k and returns the index of the first occurence of k
            in A. Return -1 if k does not appear in A. 
*/

namespace EPI11_Q1
{
    class Program
    {
        static int findK(int[] Arr, int k)
        {
            int L = 0;
            int U = Arr.Count() - 1;
            int foundIndex = -1;
            while(L <= U)
            {
                int M = L + (U - L) / 2;
                if (Arr[M] == k)
                {
                    foundIndex = M;
                    U = M - 1;
                }
                else if (k > Arr[M])
                {
                    L = M + 1;
                }
                else
                    U = M - 1;
            }

            return foundIndex;
        }

#if(TEST_Q1)
        static void Main(string[] args)
        {

            //int[] Arr = new int[] { -14, -10, 2, 108, 108, 243, 285, 285, 285, 401 };
            int[] Arr = new int[] { 108, 108, 108, 108, 108, 243, 285, 285, 285, 401 };

            int index = findK(Arr, 285);
            Console.Out.WriteLine("Found at: {0}", index);

            Console.ReadKey();
        }
#endif

    }
}
