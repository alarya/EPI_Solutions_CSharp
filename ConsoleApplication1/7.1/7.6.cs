using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI7_6
{
    /*
        Q7.6) Write a function that takes a singly linked list L, and reorders the elements of L so that the new list represent even-odd(L). Your function 
              should use O(1) additional storage. The only field you can change in a node is next.

    */

    class node
    {
        public int value;
        public node next;
    }
    class Program
    {
        static void evenOdd(node head)
        {
            Console.Out.WriteLine("Linked List Before: ");
            node ptr = head;
            while (ptr != null)
            {
                Console.Out.Write(ptr.value + " ");
                ptr = ptr.next;
            }

            node LLEven = head;
            node LLOdd = LLEven.next;
            node LLOddHead = LLOdd;

            while (LLEven.next != null && LLEven.next.next != null)
            {
                if (LLEven.next != null)
                {
                    LLEven.next =  LLEven.next.next;
                    LLEven = LLEven.next;
                }
                if (LLOdd.next != null)
                {
                    LLOdd.next = LLOdd.next.next ;
                    LLOdd = LLOdd.next;
                }
            }

            LLEven.next = LLOddHead ;

            Console.Out.WriteLine("\nLinked List After: ");
            ptr = head;
            while (ptr != null)
            {
                Console.Out.Write(ptr.value + " ");
                ptr = ptr.next;
            }
        }

#if (TEST_Q6 )
        static void Main(string[] args)
        {
            node head = new node();
            head.value = 0;

            node node1 = new node();
            node1.value = 1;

            head.next = node1;

            node node2 = new node();
            node2.value = 2;

            node1.next = node2;

            node node3 = new node();
            node3.value = 3;

            node2.next = node3;

            node node4 = new node();
            node4.value = 4;

            node3.next = node4;

            node node5 = new node();
            node5.value = 5;

            node4.next = node5;

            node node6 = new node();
            node6.value = 6;

            node5.next = node6;

            evenOdd(head);

            Console.ReadKey();
        }
#endif

    }
}
