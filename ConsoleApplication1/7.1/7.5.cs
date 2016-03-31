using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q7.5) Solve the Problem 7.4 for the case where L1 and L2 may each or both have a cycle. If such a node exists, return node that appears first 
          when traversing the lists. This node may not be unique - if L1 has a cycle (n0, n1, n2, ... nk-1, n0) where n0 is the first node encountered 
          when traversing L1, then L2 may have the same cycle but a different first node.
*/

namespace EPI7_Q5
{
    class Program
    {
        static void findFirstCycleNode(LinkedList<int> LL1, LinkedList<int> LL2)
        {
            HashSet<LinkedListNode<int>> LL1Nodes = new HashSet<LinkedListNode<int>>();
            HashSet<LinkedListNode<int>> LL2Nodes = new HashSet<LinkedListNode<int>>();

            LinkedListNode<int> LL1NodePtr = LL1.First;
            LinkedListNode<int> LL2NodePtr = LL2.First;

            while (true)
            {
                if (LL1NodePtr == null)
                    break;

                LL1NodePtr = LL1NodePtr.Next;
                if (LL1Nodes.Contains(LL1NodePtr))
                    break;
                else
                    LL1Nodes.Add(LL1NodePtr);
            }

            while (true)
            {
                if (LL2NodePtr == null)
                    break;

                LL2NodePtr = LL2NodePtr.Next;
                if (LL2Nodes.Contains(LL2NodePtr))
                    break;
                else
                    LL2Nodes.Add(LL2NodePtr);
            }

            //check which comes first
            LinkedListNode<int> L1 = LL1.First ;
            LinkedListNode<int> L2 = LL2.First ;

            while (L1 != LL1NodePtr || L2 != LL2NodePtr)
            {
                L1 = L1.Next;
                L2 = L2.Next;
            }

            if (L1 == LL1NodePtr)
                Console.Out.WriteLine("{0}", L1.Value);

            if (L2 == LL2NodePtr)
                Console.Out.WriteLine("{0}", L2.Value);

        }

#if (TEST_Q5)
        static void Main(string[] args)
        {
            LinkedList<int> LL1 = new LinkedList<int>();
            LinkedList<int> LL2 = new LinkedList<int>();

            LinkedListNode<int> node1LL1 = new LinkedListNode<int>(1);
            LinkedListNode<int> node2LL1 = new LinkedListNode<int>(2);
            LinkedListNode<int> node3LL1 = new LinkedListNode<int>(3);
            LL1.AddLast(node1LL1);
            LL1.AddLast(node2LL1);
            LL1.AddLast(node3LL1);

            LinkedListNode<int> node1LL2 = new LinkedListNode<int>(4);
            LinkedListNode<int> node2LL2 = new LinkedListNode<int>(5);
            LL2.AddLast(node1LL2);
            LL2.AddLast(node2LL2);

            LinkedListNode<int> node1Common = new LinkedListNode<int>(6);
            LinkedListNode<int> node2Common = new LinkedListNode<int>(7);
            LinkedListNode<int> node3Common = new LinkedListNode<int>(8);
            LL1.AddLast(node1Common); LL2.AddLast(node1Common);
            LL1.AddLast(node2Common); LL2.AddLast(node2Common);
            LL1.AddLast(node3Common); LL2.AddLast(node3Common);
            LL1.AddAfter(node3Common, node2LL1);

            findFirstCycleNode(LL1, LL2);


            Console.ReadKey();
        }
#endif

    }
}
