using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q8.10) Implement a queue API using an array for storing elements. Your API should include a constructor functions, which takes as argument the capacity of the queue
           enque and dequeue functions, a size function and implement dynamic resizing.

 */
namespace EPI8_10
{
    public class CustomQueue
    {
        int[] queueElements;
        int frontIndex = -1;
        int endIndex;       

        public CustomQueue(int n)
        {
            queueElements = new int[n];
        }
        public void enqueue(int n)
        {
            if (frontIndex == queueElements.Count() - 1)
            {
                resizeQueue();
                endIndex = 0;
            }

            queueElements[++frontIndex] = n;

        }
        public int dequeue()
        {
            if (frontIndex == endIndex)
                throw new System.InvalidOperationException("Dequed on an empty queue");

            return queueElements[endIndex++];
        }
        public void resizeQueue()
        {
            int[] temp = new int[2 * queueElements.Count()];
            int index = 0;
            for (int i=endIndex; i <= frontIndex; i++)
            {
                temp[index++] = queueElements[i];
            }
            queueElements = temp;
            frontIndex = index-1;
        }
        public int Count()
        {
            return frontIndex - endIndex;
        }
        public void printQueue()
        {
            Console.Out.WriteLine();
            Console.Out.Write("Queue: ");
            for (int i = endIndex; i <= frontIndex; i++)
            {
                Console.Out.Write(queueElements[i] + " ");
            }
        }
    }
    class Program
    {


#if (TEST_Q10)
        static void Main(string[] args)
        {
            CustomQueue myQueue = new CustomQueue(4);
            myQueue.enqueue(0);
            myQueue.printQueue();
            myQueue.enqueue(1);
            myQueue.printQueue();
            myQueue.enqueue(2);
            myQueue.printQueue();
            myQueue.dequeue();
            myQueue.printQueue();
            myQueue.enqueue(3);
            myQueue.printQueue();
            myQueue.enqueue(4);
            myQueue.printQueue();
            myQueue.enqueue(5);
            myQueue.printQueue();
            myQueue.dequeue();
            myQueue.printQueue();

            Console.ReadKey();
        }
#endif       
    }
}
