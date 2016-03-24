using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
    7.1 Write a function that takes L & F, returns the merge of L and F. Your code should
    use O(1) additional storage - it should reuse the nodes from the lists provided as input
    Your function should use O(1) additional storage. The only field you can change in a node is next
*/

namespace EPI7_Q1
{

    /* quick and dirty implementation of a Linked List */
    class node
    {
        public int data;
        public node next = null;
    }

    class LinkedList
    {
        public node head;
        public LinkedList()
        {
            head = new node();
        }
        public void add(node Node)
        {
            node _p = head;
            while (_p.next != null)
                _p = _p.next;
            _p.next = Node;
        }
        public void printLL()
        {
            node _p = head;
            while (_p.next != null)
            {
                Console.Out.Write("{0} ", _p.data);
                _p = _p.next;

            }
            Console.Out.Write("{0} ", _p.data);
        }

    }
    class Program
    {
        /* My solution */

        static void Merge1(LinkedList l, LinkedList h)    //will return result in l
        {
            node l1 = l.head;
            node h1 = h.head;
            //first adjust head of result list in l
            if (l.head.data > h.head.data)
            {
                int temp = l.head.data;
                l.head.data = h.head.data;
                h.head.data = temp;
            }

            //now merge
            while (l1 != null && h1 != null)
            {
                if (l1.data < h1.data)
                {
                    if (l1.next != null)
                        while (l1.next.data < h1.data)
                        {
                            l1 = l1.next;
                            if (l1.next != null)
                                break;
                        }
                    node temp = l1.next;
                    l1.next = h1;
                    l1 = temp;
                }
                else
                {
                    if (h1.next != null)
                        while (h1.next.data < l1.data)
                        {
                            h1 = h1.next;
                            if (h1.next != null)
                                break;
                        }
                    node temp = h1.next;
                    h1.next = l1;
                    h1 = temp;
                }
            }
        }

        /* Book approach */
        static node Merge(LinkedList l, LinkedList h)
        {
            node l1 = l.head;
            node h1 = h.head;
            node newHead = new node();
            newHead.data = l1.data < h1.data ? l1.data : h1.data;
            if (l1.data < h1.data)
                l1 = l1.next;
            else
                h1 = h1.next;

            node curr = newHead;
            while(l1 != null && h1 != null)
            {
                if(l1.data < h1.data)
                {
                    curr.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    curr.next = h1;
                    h1 = h1.next;
                }
                curr = curr.next;
            }

            if (l1 == null)
            {
                curr.next = h1;
            }
            if(h1 == null)
            {
                curr.next = l1;
            }

            return newHead;

        }
#if (TEST_Q1)
        static void Main(string[] args)
        {
            LinkedList l = new LinkedList();
            l.head.data = 1;

            node n = new node();
            n.data = 3;
            l.add(n);

            node n1 = new node();
            n1.data = 5;
            l.add(n1);

            node n2 = new node();
            n2.data = 7;
            l.add(n2);

            node n3 = new node();
            n3.data = 9;
            l.add(n3);

            LinkedList h = new LinkedList();
            h.head.data = 2;

            node n4 = new node();
            n4.data = 4;
            h.add(n4);

            node n5 = new node();
            n5.data = 6;
            h.add(n5);

            node n6 = new node();
            n6.data = 8;
            h.add(n6);

            node n7 = new node();
            n7.data = 10;
            h.add(n7);

            Console.Out.WriteLine();
            l.printLL();
            Console.Out.WriteLine();

            Console.Out.WriteLine();
            h.printLL();
            Console.Out.WriteLine();


            //LinkedList result = new LinkedList();
            //result.head = Merge(l, h);
            //Console.Out.WriteLine();
            //result.printLL();

            Merge1(l, h);
            Console.Out.WriteLine();
            l.printLL();

            Console.Out.WriteLine();


            Console.ReadKey();
        }
#endif
    }
}
