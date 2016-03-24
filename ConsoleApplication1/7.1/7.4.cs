using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q7.4) Let h1 and h2 be the heads of lists L1 and L2, respectively. Assume that L1 and L2 are well-formed, that is each
          consists of a finite sequence of nodes (and no cycles). How would you determine if there exists a node r reachable 
          from both h1 and h2 by following the next fields? If such a node exists, find the node that appears earliest when
          traversing the lists. You are constrained to use no more than constant additional storage.
 */

namespace EPI7_Q4
{
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

        /*
            Alright the idea is to use two pointers, for every node in one LL, traverse all nodes of the other LL to check
            if the first node is present in the second list. this will be O(n^2).. but what's you get for constant space 
        */
        static void findFirstCommonNode(LinkedList L1, LinkedList L2)
        {
            node h1 = L1.head;

            while(h1 != null)
            {
                node h2 = L2.head;
                while (h2!= null)
                {
                    if(h1 == h2)
                    {
                        Console.Out.WriteLine("Common node: {0}", h1.data);
                        return;
                    }
                    h2 = h2.next;
                }
                h1 = h1.next;
            }
            if (h1 == null)
                Console.Out.WriteLine("No common node exists");
        }

        /* So yeah the previous method is super inefficient
            Instead use this approach
            1) First to find if ther overlap, treaverse both LL and stop and the tail and check if they are common.
               To be a common LL they have to have a common tail.
            2) now while doing so, also calculate the Length of the two LL's (lets say LengthLL1 and LengthLL2)
            3) Now whichever is the longer list. advance a pointer to |L1| - |L2| position and then start another pointer
               from the head of the other LL in lockstep with the other pointer which was already advanced.
               They will meet at the first common node

            runs O(LengthLL1 + LengthLL2)
        */
        static void findFirstCommonNode1(LinkedList L1, LinkedList L2)
        {
            int LengthL1 = 0;
            int LengthL2 = 0;
            node h1 = L1.head;
            node h2 = L2.head;

            while (h1.next != null)
            {
                ++LengthL1;
                h1 = h1.next;
            }

            while (h2.next != null)
            {
                ++LengthL2;
                h2 = h2.next;
            }

            if(h1 != h2)
            {
                Console.Out.WriteLine("No common node exists");
                return;
            }
            if(LengthL1 > LengthL2)
            {
                int difference = LengthL1 - LengthL2;
                h1 = L1.head;
                h2 = L2.head;
                for (int i = 1; i <= difference; i++)
                    h1 = h1.next;

                while(h1 != h2)
                {
                    h1 = h1.next;
                    h2 = h2.next;
                }
                Console.Out.WriteLine("Common node: {0}", h1.data);
            }
            else
            {
                int difference = LengthL2 - LengthL1;
                h1 = L1.head;
                h2 = L2.head;
                for (int i = 1; i <= difference; i++)
                    h2 = h2.next;

                while (h1 != h2)
                {
                    h1 = h1.next;
                    h2 = h2.next;
                }
                Console.Out.WriteLine("Common node: {0}", h1.data);
            }
        }

#if (TEST_Q4)
        static void Main(string[] args)
        {
            //Linked list with cycle
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

            //n3.next = n5; //adding common node

            findFirstCommonNode1(l, h);
            Console.ReadKey();
        }
#endif
    }
}
