using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q6.9) Write a function that takes two strings representing integers, and returns an integer representing their product
*/

namespace EPI6_9
{
    class Program
    {
        static void multiply(string a, string b)
        {            
            string result = new string('0',a.Length + b.Length);
            int step = 0;
            for(int i=a.Count()-1; i >= 0; i--)               
            {
                StringBuilder intermediateResult = mul(b,a[i].ToString());
                intermediateResult.Append('0', step);         
                result = add(result, intermediateResult.ToString() );
                step++;
            }

            if (result[0] == '0')
                result = result.Substring(1, result.Length - 1);

            Console.Out.WriteLine("{0} * {1} = {2}",a,b,result);
        }

        //add two numbers
        static String add(string b, string a)
        {
            StringBuilder result = new StringBuilder();

            int bIndex = b.Length - 1;
            int aIndex = a.Length - 1;

            int carry = 0;
            while(bIndex >= 0 && aIndex >= 0)
            {

                int addDigits = Convert.ToInt32(b[bIndex].ToString()) + Convert.ToInt32(a[aIndex].ToString());
                addDigits += carry;

                if (addDigits > 9)
                {
                    carry = addDigits / 10;
                    addDigits = addDigits % 10;
                }
                else
                    carry = 0;

                result = result.Insert(0, addDigits.ToString());

                bIndex--; aIndex--;
            }

            if (bIndex >= 0 )
            {
                if(carry >= 0)
                {
                    while(bIndex >= 0)
                    {
                        int digit = Convert.ToInt32(b[bIndex].ToString()) + carry;
                        if (digit > 9)
                        {
                            carry = digit / 10;
                            digit = digit % 10;
                        }
                        else
                            carry = 0;

                        result = result.Insert(0, digit.ToString());
                        bIndex--;
                    }
                }
                else
                {
                    result = result.Insert(0, b.Substring(0, bIndex));
                }
            }

            if(aIndex >= 0 )
            {
                if (carry >= 0)
                {
                    while (aIndex >= 0)
                    {
                        int digit = Convert.ToInt32(a[aIndex].ToString()) + carry;
                        if (digit > 9)
                        {
                            carry = digit / 10;
                            digit = digit % 10;
                        }
                        else
                            carry = 0;

                        result = result.Insert(0, digit.ToString());
                        aIndex--;
                    }
                }
                else
                {
                    result = result.Insert(0, a.Substring(0, aIndex));
                }
            }

            if (carry != 0)
                result = result.Insert(0, carry.ToString());

            return result.ToString();
        }

        //multiply a single digit number(a) with a multi digit number(b)
        static StringBuilder mul(string b, string a)
        {
            int carry = 0;
            int aInt = Convert.ToInt32(a.ToString());
            StringBuilder result = new StringBuilder();
            for(int i = b.Count() - 1; i >= 0; i--)
            {
                int digit = Convert.ToInt32(b[i].ToString()) * aInt;
                digit += carry;

                if (digit > 9)
                {
                    carry = digit / 10;
                    digit = digit % 10;
                }
                else
                    carry = 0;

                result = result.Insert(0, digit.ToString());
            }
            if(carry !=0)
                result = result.Insert(0, carry.ToString());

            return result;
        }
#if (TEST_Q9)
        static void Main(string[] args)
        {

            //Console.Out.WriteLine(mul("789877","9"));

            //Console.Out.WriteLine(add("999999", "1"));


            multiply("11","22");

            multiply("2435672745", "29");

            multiply("243567274523523523235", "1234134235");

            Console.ReadKey();
        }
#endif
    }
}
