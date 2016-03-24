using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
    Q)7.2 Given a reference to the head of a singly linked List L, how would you determine whether L ends
          in a null or reaches a cycle of nodes? Write a function that returns null if there does not exist
          a cycle, and the reference to the start of the cycle if a cycle is present.
*/

namespace EPI7_Q2
{
    class node
    {
        public int data =0;
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
        /* Works perfect when space is not a concern */
        public static node containsCycle(LinkedList L)
        {
            HashSet<node> nodeEncountered = new HashSet<node>();

            node curr = L.head;

            while(curr != null)
            {
                if (nodeEncountered.Contains(curr))
                    return curr;

                nodeEncountered.Add(curr);
                curr = curr.next;
            }

            return null;
        }

        /* Another Approach which can be used without using extra storage is to use two pointers
           slow - moves over every node, fast- moves over by skipping a node.
           Eventually both pointers will meet if there is a loop(fast will eventually hit null before slow)
           They would meet k steps before the head of the loop. we can start another pointer from the head 
           and from the collision spot and they will meet at the node where cycle starts.
        */

#if (TEST_Q2)
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
            n3.next = n1;

            node cycleStart = containsCycle(l);
            if (cycleStart != null)
            {
                Console.Out.WriteLine("Contains cycle starting at: {0}", cycleStart.data);
            }
            else
                Console.Out.WriteLine("Does not contain cycle");

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

            cycleStart = containsCycle(h);
            if (cycleStart != null)
            {
                Console.Out.WriteLine("Contains cycle starting at: {0}", cycleStart.data);
            }
            else
                Console.Out.WriteLine("Does not contain cycle");

            Console.ReadKey();
        }
#endif
    }
}
