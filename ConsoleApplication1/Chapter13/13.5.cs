using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q13.5) Given sorted arrays A and B of lengths n and m respectively, return an array C containing elements common 
           to A and B. The array C should be free of duplicates. How would you perform this intersection if 1) n ~~ m 
           2) n << m 

    The solution i have used works best for any case, regardless of the sizes of n and m
*/

namespace EPI13_Q5
{
    class Program
    {
        static int[] getIntersection(int[] A, int[] B)
        {
            List<int> intersection = new List<int>();

            int indexA = 0;
            int indexB = 0;
            while(indexA < A.Length && indexB < B.Length)
            {
                if (A[indexA] < B[indexB])
                    indexA++;
                else if (A[indexA] > B[indexB])
                    indexB++;
                else
                {
                    intersection.Add(A[indexA]);
                    indexA++; indexB++;
                }
            }
            return intersection.ToArray();    
        }

#if(TEST_Q5)
        static void Main(string[] args)
        {
            int[] A = new int[] { 1, 2, 3, 6, 7, 8, 9, 10 };
            int[] B = new int[] { 4, 5, 6, 7, 8, 11, 12 };

            foreach(int a in getIntersection(A,B))
            {
                Console.Out.Write(a + " ");
            }
            
            Console.ReadKey();
        }
#endif
    }
}
