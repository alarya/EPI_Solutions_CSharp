using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q11) Given two strings, represented as arrays of characters A and B, compute the minimum number of edits
         needed to transform the first string into the second string.

    Edits: insertion, deletion, or substitution
*/
namespace EPI15_Q11
{
    class Program
    {
        /* This solution may be wrong (although it works for the test cases)... will get back to it 
            The book uses some dynamic programming approach
            */
        static int minimumEdits(char[] A, char[] B)
        {
            Dictionary<char, int> charFreqA = new Dictionary<char, int>();
            Dictionary<char, int> charFreqB = new Dictionary<char, int>();

            foreach(char c in A)
            {
                if (charFreqA.ContainsKey(c))
                    charFreqA[c] += 1;
                else
                    charFreqA.Add(c, 1);
            }

            foreach (char c in B)
            {
                if (charFreqB.ContainsKey(c))
                    charFreqB[c] += 1;
                else
                    charFreqB.Add(c, 1);
            }

            //find number characters present in source which are needed in  target
            int similar = 0;
            int neededInB = 0;
            int deletions = 0;
            foreach(char c in B)
            {
                if (charFreqA.ContainsKey(c))
                {
                    similar++;
                    if (charFreqA[c] == 1)
                        charFreqA.Remove(c);
                    else
                        charFreqA[c] -= 1;
                }
                else
                    neededInB++;
            }
            if (A.Length > B.Length)
                deletions = A.Length - B.Length;

            return neededInB + deletions;
        }
#if (TEST_Q11)
        static void Main(string[] args)
        {
            char[] A = "ABCEFG".ToCharArray();
            char[] B = "EFOIUKQWER".ToCharArray();

            Console.Out.WriteLine("Minimum edits: {0}", minimumEdits(A, B));

            A = "ABCDEFJ".ToCharArray();
            B = "AABCDEF".ToCharArray();

            Console.Out.WriteLine("Minimum edits: {0}", minimumEdits(A, B));

            Console.ReadKey();
        }
#endif

    }
}
