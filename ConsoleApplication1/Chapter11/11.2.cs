using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q11.2) Design an efficient algorithm that takes a sorted array A and a key k, and finds the index of the first occurence an
           element larger than k; return -1 if every element is less than or equal to k.
*/

namespace EPI11_Q2
{
    class Program
    {
        //static int findFirstLargerThanK(int[] Arr,int k)
        //{
        //    int L = 0;
        //    int U = Arr.Count() - 1;
        //    int index = -1;
        //    while(L <= U)
        //    {
        //        int M = L + (U - L) / 2;

        //        if(Arr[M] == k)
        //        {
        //            index = M;
        //            break;
        //        }
        //        if (k < Arr[M])
        //            U = M - 1;
        //        else
        //            L = M + 1;
        //    }
        //    if(index != -1)
        //    {
        //        while (index < Arr.Count() - 1 && Arr[index] == Arr[index + 1])
        //            index++;

        //        if (index != Arr.Count() - 1)
        //            return index + 1;
        //    }
        //    return -1;
        //}

            /* more cleaner solution */
        static int findFirstLargerThanK(int[] Arr, int k)
        {
            int L = 0;
            int U = Arr.Count() - 1;
            int index = -1;
            while (L <= U)
            {
                int M = L + (U - L) / 2;

                if (Arr[M] == k)
                {
                    index = M;
                    L = M + 1;
                }
                if (k < Arr[M])
                    U = M - 1;
                else
                    L = M + 1;
            }
            if (index != -1)
                return index + 1;

            return -1;
        }
#if(TEST_Q2)
        static void Main(string[] args)
        {
            int[] Arr = new int[] { -14, -10, 2, 108, 108, 243, 285, 285, 401,402,403 };
            //int[] Arr = new int[] { 108, 108, 108, 108, 108, 243, 285, 285, 285 };

            int index = findFirstLargerThanK(Arr, 285);

            if (index != -1)
                Console.Out.WriteLine("Found at: {0}, Number: {1}", index, Arr[index]);
            else
                Console.Out.WriteLine("Not found");
            Console.ReadKey();
        }
#endif
    }
}
