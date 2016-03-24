using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    6.14 Check whether a 9*9 2D array representing a partially completed Sudoku is valid. 
        Specifically, check that no row, column, and 3*3 2D subarray contains duplicates.
        A 0-value in the 2D array indicates that entry is blank; every other entry is in [1,9]  
*/
namespace EPI6_14
{
    class Program
    {
        public bool isValidPartialSoduko(int[,] A)
        {
            int rows = A.GetUpperBound(0);
            int columns = A.GetUpperBound(1);
            //check for breakage of any row constraints
            for(int i = 0; i <= rows ; i++)
            { 
                bool[] exists = new bool[10];
                for(int j = 0; j <= columns ; j++)
                {
                    if (A[i, j] == 0)
                        continue;
                    int number = A[i,j];
                    if (exists[number] == true)
                        return false;
                    else
                        exists[number] = true;
                }
            }

            //check for breakage of any row constraints
            for (int i = 0; i <= rows; i++)
            {
                bool[] exists = new bool[10];
                for (int j = 0; j <= columns; j++)
                {
                    if (A[j, i] == 0)
                        continue;
                    int number = A[j,i];
                    if (exists[number] == true)
                        return false;
                    else
                        exists[number] = true;
                }
            }

            //check for breakage of any grid constraints
            for (int i = 0; i <= rows; i += 3)
                {
                    for (int j = 0; j <= columns; j += 3)
                    {
                        for (int ii = i; ii < i + 3; ii++)
                        {
                            bool[] exists = new bool[10];
                            for (int jj = j; jj < j + 3; jj++)
                            {
                                if (A[ii, jj] == 0)
                                    continue;
                                int number = A[ii, jj];
                                if (exists[number] == true)
                                    return false;
                                else
                                    exists[number] = true;
                            }
                        }
                    }
                }

            return true;
        }

#if(TEST_Q14)
        static void Main(string[] args)
        {
            int[,] Array = new int[,]
                {
                    { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
                    { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
                    { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
                    { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
                    { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
                    { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
                    { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
                    { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
                    { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
                };

            Program p = new Program();
            Console.Out.WriteLine(p.isValidPartialSoduko(Array));

            int[,] Array2 = new int[,]
                {
                    { 5, 3, 0, 0, 7, 0, 0, 0, 1 },
                    { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
                    { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
                    { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
                    { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
                    { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
                    { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
                    { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
                    { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
                };

            Console.Out.WriteLine(p.isValidPartialSoduko(Array2));

            Console.ReadKey();
        }
#endif
    }
}