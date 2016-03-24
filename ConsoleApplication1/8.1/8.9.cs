using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q8.9) Given the root node r of a binary tree, print all the keys and levels at r and it's descendants. The nodes
          should be printed in order of their level. You cannot use recursion. You may use a single queue, and constant
          additonal storage 
*/
namespace EPI8_Q9
{
    public class node
    {
        public int data;
        public node left = null;
        public node right = null;
    }

    public class BST
    {
        public node root;
    }

    class Program
    {

        static void BFS(node root)
        {
            Queue<node> myQueue = new Queue<node>();

            int level = 1;
            myQueue.Enqueue(root);
            while(myQueue.Count != 0)
            {
                Console.Out.Write("Level {0}: ", level);
                int currentCount = myQueue.Count;
                //enque nodes at new level
                for(int i = 0; i < currentCount; i++)
                {
                    node _node = myQueue.ElementAt(i);
                    if(_node.left != null)
                        myQueue.Enqueue(_node.left);
                    if(_node.right != null)
                        myQueue.Enqueue(_node.right);

                    //print
                    Console.Out.Write(" {0} ", _node.data);
                }
                //deque nodes at old level
                for (int i = 0; i < currentCount; i++)
                {
                    myQueue.Dequeue();                    
                }
                level++;
                Console.Out.WriteLine();
            } 
        }

        public static void inorderRegular(node _node)
        {

            if (_node.left != null)
                inorderRegular(_node.left);

            Console.Out.Write(_node.data + " ");

            if (_node.right != null)
                inorderRegular(_node.right);
        }

#if (TEST_Q9)
        static void Main(string[] args)
        {

            BST bst = new BST();
            bst.root = new node();
            bst.root.data = 19;

            node n1 = new node();
            n1.data = 7;
            node n2 = new node();
            n2.data = 43;
            bst.root.left = n1;
            bst.root.right = n2;

            node n3 = new node();
            n3.data = 3;
            node n4 = new node();
            n4.data = 11;
            n1.left = n3;
            n1.right = n4;

            node n5 = new node();
            n5.data = 23;
            node n6 = new node();
            n6.data = 47;
            n2.left = n5;
            n2.right = n6;

            node n7 = new node();
            n7.data = 37;
            n5.right = n7;
            node n8 = new node();
            n8.data = 29;
            node n9 = new node();
            n9.data = 41;
            n7.left = n8;
            n7.right = n9;
            node n10 = new node();
            n10.data = 31;
            n8.right = n10;

            node n11 = new node();
            n11.data = 53;
            n6.right = n11;

            BFS(bst.root);

            Console.ReadKey();
        }
#endif
    }
}
