using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q5.1) How would you go about computing the parity of a very large number of 64 bit nonnegative integers ?

*/
namespace EPI5_Q1
{
    class Program
    {


#if(TEST_Q1)
        static void Main(string[] args)
        {
            int n = 22;

            int noOf1 = 0;
            int bin = 1;
            while(bin < 18)
            {
                Console.Out.WriteLine("Mask: {0}",Convert.ToString(bin,2));
                int AND = n & bin;
                Console.Out.WriteLine("AND: {0}",Convert.ToString(AND,2));
                if (AND != 0) noOf1++;
                bin = bin  << 1;
            }

            if (noOf1 % 2 != 0) Console.Out.WriteLine("Parity: 1");
            else Console.Out.WriteLine("Parity: 0");

            Console.ReadKey();
        }
#endif
    }
}
