using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q8.1)Design a stack that supports a max operation, which returns the maximum value stored in the stack
    and throws an exception if the stack is empty. Assume elements are comparable. All operations must be
    O(1)time. You can use O(n) additional space, beyond what is required for the element themselves

*/
namespace EPI8_Q1
{
    class myStack
    {
        int[] data;
        int[] maxSoFar;
        int top;
        public myStack()
        {
            data = new int[100];   //assuming 100 elements
            maxSoFar = new int[100];
            top = -1;
        }

        public void push(int n)
        {
            if(top == -1)
            {
                top = 0;
                data[top] = n;
                maxSoFar[top] = n;
            }
            else
            {
                ++top;
                data[top] = n;
                maxSoFar[top] = n > maxSoFar[top - 1] ? n : maxSoFar[top - 1];
            }
        }

        public int pop()
        {
            if(top == -1)
                throw new Exception();

            return data[top--];
        }

        public int max()
        {
            return maxSoFar[top];
        }

        public void printStack()
        {
            Console.Out.WriteLine();
            for(int i =0; i <= top; i++)
            {
                Console.Out.Write("{0} ",data[i]);
            }
            Console.Out.WriteLine();
        }


    }
    class Program
    {
#if (TEST_Q1)
        static void Main(string[] args)
        {
            myStack stack = new myStack();

            stack.push(4);
            stack.push(1);
            stack.push(3);
            stack.push(10);
            stack.push(1);
            stack.push(11);

            stack.printStack();

            Console.Out.WriteLine("Max: {0}", stack.max());

            Console.Out.WriteLine("Popping: {0}", stack.pop());

            stack.printStack();

            Console.Out.WriteLine("Max: {0}", stack.max());

            Console.Out.WriteLine("Popping: {0}", stack.pop());

            stack.printStack();

            Console.Out.WriteLine("Max: {0}", stack.max());

            Console.Out.WriteLine("Popping: {0}", stack.pop());

            stack.printStack();

            Console.Out.WriteLine("Max: {0}", stack.max());

            Console.ReadKey();
        }
#endif
    }
}
