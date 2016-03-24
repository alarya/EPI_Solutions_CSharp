using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q6.19) Implement a function for reversing the words in a string. Your function should use
            O(1) space.

            "Bob like Alice" -> "Alice likes Bob"
*/
namespace EPI6_Q19

{
    class Program
    {
        void reverseSentence(string sentence)
        {
            char[] sentenceCharArray = sentence.ToCharArray();
            
            //first reverse every word
            for(int i=0; i < sentenceCharArray.Count()-1; i++)
            {
                if(sentenceCharArray[i] == ' ')
                {
                    continue;
                }
                else   //a word has started
                {
                    //find end of the word
                    int startIndex = i;
                    while (sentenceCharArray[i] != ' ' && i < sentenceCharArray.Count()-1)
                        i++;

                    int endIndex = 0;
                    if (i < sentenceCharArray.Count() - 1)
                        endIndex = i - 1;
                    else
                        endIndex = i;   //to handle last word
                    //reverse the word
                    while (startIndex < endIndex)
                    {
                        char temp = sentenceCharArray[startIndex];
                        sentenceCharArray[startIndex] = sentenceCharArray[endIndex];
                        sentenceCharArray[endIndex] = temp;
                        startIndex++; endIndex--;
                    }
                }
            }
            //Now reverse the entire sentence
            int start = 0;
            int end = sentenceCharArray.Count() - 1;
            while (start < end)
            {
                char temp = sentenceCharArray[start];
                sentenceCharArray[start] = sentenceCharArray[end];
                sentenceCharArray[end] = temp;
                start++; end--;
            }

            Console.Out.WriteLine(sentenceCharArray);
        }

#if (TEST_Q19)
        static void Main(string[] args)
        {
            string sentence = "Bob likes Alice";
            Console.Out.WriteLine("Original: {0}", sentence);
            Program p = new Program();
            p.reverseSentence(sentence);

            sentence = "abcdef ghijklmno";
            Console.Out.WriteLine("Original: {0}", sentence);
            p.reverseSentence(sentence);

            sentence = " a b ";
            Console.Out.WriteLine("Original: {0}", sentence);
            p.reverseSentence(sentence);

            Console.ReadKey();
        }
#endif
    }
}
