using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q7.8) Given a singly Linked List L and a number k, write a function to remove the k-th last element from L.
          Your algorithm cannot use more than a few words of storage, regardless of the length of the list. In particular, 
          you cannot assume that it is possible to record the length of the list. 

*/
namespace EPI7_8
{
    class node
    {
        public int value;
        public node next;
    }

    class Program
    {
        static void findKthLast(node head, int k)
        {
            node Ptr1 = head;
            for (int i = 0; i < k; i++)
                Ptr1 = Ptr1.next;

            node Ptr2 = head;
            while (Ptr1 != null)
            {
                Ptr1 = Ptr1.next;
                Ptr2 = Ptr2.next;
            }

            Console.Out.Write("{0}'th last element: {1}", k, Ptr2.value);
        }

#if (TEST_Q8)
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

            Console.Out.WriteLine("Linked List : ");
            node ptr = head;
            while (ptr != null)
            {
                Console.Out.Write(ptr.value + " ");
                ptr = ptr.next;
            }
            Console.Out.WriteLine();
            findKthLast(head, 2);

            Console.ReadKey();
        }
#endif

    }
}
