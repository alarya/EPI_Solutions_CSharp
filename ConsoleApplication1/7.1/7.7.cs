using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q7.7) Let v be a node in a singly linked list L. Node v is not the tail; delete it in O(1) time.
*/
namespace EPI7_7
{
    class node
    {
        public int value;
        public node next;
    }
    class Program
    {
        static void deleteNode(node n)
        {
            n.value = n.next.value;
            n.next = n.next.next;
        }

#if (TEST_Q7)
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

            Console.Out.WriteLine("Linked List Before: ");
            node ptr = head;
            while (ptr != null)
            {
                Console.Out.Write(ptr.value + " ");
                ptr = ptr.next;
            }

            deleteNode(node4);

            Console.Out.WriteLine("\nLinked List After: ");
            ptr = head;
            while (ptr != null)
            {
                Console.Out.Write(ptr.value + " ");
                ptr = ptr.next;
            }

            Console.ReadKey();
        }
#endif

    }
}
