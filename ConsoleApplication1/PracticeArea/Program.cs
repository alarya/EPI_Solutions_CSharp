using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeArea
{
    class Program
    {
        static int partition(ref int[] Arr, int low, int high)
        {
            int mid = low + (high - low) / 2;
            int pivot = Arr[mid];   //assume mid to be pivot

            //move mid to front
            swap(ref Arr, mid, low);

            int start = low + 1;
            int end = high;
            while(start <= end)
            {
                while (start <= end && Arr[start] < pivot)
                    start++;

                while (start <= end && Arr[end] > pivot)
                    end--;

                if(start < end)                
                    swap(ref Arr, start, end);
            }
            swap(ref Arr, start-1, low);

            return start - 1;
        }

        static void quickSort(ref int[] Arr, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = partition(ref Arr, low, high);

                quickSort(ref Arr, low, pivotIndex - 1);
                quickSort(ref Arr, pivotIndex + 1, high);
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
            int[] Array = { 7, 4, 1, 3, 0, 10, 8 };

            quickSort(ref Array, 0, 6);

            //partition(ref Array, 0, 6);

            Console.Out.WriteLine();
            foreach (var a in Array)
                Console.Out.Write(a +" ");
            Console.Out.WriteLine();

            Console.ReadKey();
        }
    }
}
