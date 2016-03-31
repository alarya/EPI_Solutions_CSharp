using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q6.15) Implement a function which takes a 2D array A and prints A in spiral order.


*/

namespace EPI6_15
{

    class Program
    {
        static void SpiralPrint(int[,] Arr)
        {
            int rows = Arr.GetUpperBound(0);
            int columns = Arr.GetUpperBound(1);

            int rowIndex = 0;
            int columnIndex = 0;
            int layer = 0;
            while(rowIndex <= rows/2 && columnIndex <= columns/2)
            {
                {
                    int layerRow = rowIndex;
                    int layerColumn = columnIndex;
                    while(layerColumn < columns - layer)
                    {
                        Console.Out.Write(Arr[layerRow, layerColumn] + " ");
                        layerColumn++;
                    }
                    while(layerRow < rows - layer)
                    {
                        Console.Out.Write(Arr[layerRow, layerColumn] + " ");
                        layerRow++;
                    }
                    while(layerColumn > layer)
                    {
                        Console.Out.Write(Arr[layerRow, layerColumn] + " ");
                        layerColumn--;
                    }
                    while(layerRow > layer )
                    {
                        Console.Out.Write(Arr[layerRow, layerColumn] + " ");
                        layerRow--;
                    }                   
                }
                Console.Out.WriteLine();
                layer++;
                rowIndex++;
                columnIndex++;
            }
        }

#if(TEST_Q13)
        static void Main(string[] args)
        {
            int[,] Arr = new int[,] {
                                        { 1, 2, 3, 4},
                                        { 5, 6, 7, 8},
                                        { 9, 10, 11, 12},
                                        { 13, 14, 15, 16}
                                    };

            SpiralPrint(Arr);

            Arr = new int[,] {
                                        { 1, 2, 3, 4, 5, 6},
                                        { 10, 11, 12, 13, 14, 15},
                                        { 19, 20, 21, 22, 23, 24},
                                        { 28, 29, 30, 31, 32, 33},
                                        { 37, 38, 39, 40, 41, 42},
                                        
                                    };

            SpiralPrint(Arr);
            Console.ReadKey();
        }
#endif

    }
}
