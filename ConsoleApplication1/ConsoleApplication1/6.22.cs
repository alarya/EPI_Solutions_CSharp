using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q6.22) Given a cell phone keypad (specified by a mapping M that takes individual digits and returns the corresponding set of characters)
           and a number sequence, return all possible character sequences (not just legal words) that correspond to the number sequence.

*/
namespace EPI6_Q22

{
    class Program
    {
        Dictionary<int, char[]> map = new Dictionary<int, char[]>();
        public Program()
        {
            char[] letters1 = { }; 
            map.Add(1, letters1);

            char[] letters2 = { 'A', 'B', 'C' };
            map.Add(2, letters2);

            char[] letters3 = {'D','E','F' };
            map.Add(3, letters3);

            char[] letters4 = { 'G', 'H', 'I' };
            map.Add(4, letters4);

            char[] letters5 = { 'J','K','L'};
            map.Add(5, letters5);

            char[] letters6 = { 'M', 'N', 'O' };
            map.Add(6, letters6);

            char[] letters7 = { 'P', 'Q', 'R','S' };
            map.Add(7, letters7);

            char[] letters8 = { 'T', 'U', 'V' };
            map.Add(8, letters8);

            char[] letters9 = { 'W','X','Y','Z' };
            map.Add(9, letters9);

            char[] letters0 = { };
            map.Add(0, letters0);

        }
        void printSequences(int number)
        {

            int[] numberArray = intToIntArray(number);

            string s = "";
            int position = 0;
            rPrintSequences(s,numberArray,position);

            Console.Out.WriteLine(numberArray);
        }

        void rPrintSequences(string s, int[] numberArray, int position)
        {
            if (position == numberArray.Count())
            { 
                Console.WriteLine(s);
                return;
            }

            foreach(char c in map[numberArray[position]])
            {
                string resultS = s + c;
                int pos = position;
                rPrintSequences(resultS, numberArray, ++pos);
            }
        }

        public int[] intToIntArray(int number)
        {
            string sNumber = number.ToString();
            int[] result = new int[sNumber.Length];

            int modder = 10;
            int divider = 1;

            for (int i = sNumber.Length - 1; i >= 0; i--)
            {
                result[i] = (number % modder) / divider;
                modder *= 10;
                divider *= 10;
            }

            return result;
        }

#if (TEST_Q22)
        static void Main(string[] args)
        {
            Program p = new Program();
            int number = 2276696;
            p.printSequences(number);

            Console.ReadKey();
        }
#endif
    }
}
