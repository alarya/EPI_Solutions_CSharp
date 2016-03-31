using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q6.21) Write a function which takes as input a string s, and removes each "b" and replaces each "a" by "dd". Use O(1) additional storage- assume s is stored
           in an array that has enough space for the final result 
*/
namespace EPI6_Q21
{
    class Program
    {

     static void replace(ref StringBuilder input)
     {
         for(int i=0; i < input.Length; i++)
            {
                if (input[i] == 'b')
                    removeB(ref input, i--);

                if (input[i] == 'a')
                    replaceA(ref input, i--);
            }
     }
     
     static void removeB(ref StringBuilder input, int index)
     {            
        index++;
        while (index < input.Length)
        {
            input[index - 1]  = input[index];
            index++;
        }
     }
     static void replaceA(ref StringBuilder input, int index)
     {
            input[index] = 'd' ;
            char temp = input[index + 1];
            input[index + 1] = 'd';
            index++; index++;
            while(index < input.Length)
            {
                char c = input[index];
                input[index] = temp;
                temp = c;
                index++;
            }
     }

#if (TEST_Q21)
     static void Main(string[] args)
     {
            StringBuilder input = new StringBuilder ( "abcabcdefahcaabaaabbb                                                    ");
            //removeB(ref input, 1);
            //replaceA(ref input, 0);

            replace(ref input);
            Console.Out.WriteLine(input);

            Console.ReadKey();
     }
#endif

    }
}
