using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q12.9) Write a method which takes an anonymous letter L and text  from a Magazine M. Method should return true iff L can be 
            written using M i.e., if a letter appears k times in L, it must appear K or more times in L
*/
namespace EPI12_Q9
{
    class Program
    {
        static bool anonymous_letter(string L, string M)
        {
            Dictionary<char, int> letterDict = new Dictionary<char, int>();

            //first scan the Letter
            foreach(char c in L)
            {
                if (letterDict.ContainsKey(c))
                {
                    letterDict[c] += 1;
                }
                else
                    letterDict.Add(c, 1);
            }

            //scan magazine
            foreach(char c in M)
            {
                if (letterDict.ContainsKey(c))
                {
                    if (letterDict[c] == 1)
                        letterDict.Remove(c);
                    else
                        letterDict[c] -= 1;
                }
                if (letterDict.Count() == 0)
                    return true;
            }
            return false;
        }

#if(TEST_Q9)
        static void Main(string[] args)
        {
            string L = "abcddddd";
            string M =  "Write a method which takes an anonymous letter L and text  from a Magazine M. Method should return true iff L can be written using M i.e., if a letter appears k times in L, it must appear K or more times in L" ;

            Console.Out.WriteLine("{0} can be written from M: {1} ", L, anonymous_letter(L, M));

            Console.ReadKey();
        }
#endif
    }
}
