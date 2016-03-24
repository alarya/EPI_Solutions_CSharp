using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q8.3) Given a BST node n, print all the keys at n and its descendants. The nodes 
          should be printed in sorted order, and you cannot use recursion.

          Meaning inorder traversal
*/
namespace EPI8_Q3
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
        /*
            Since we can't use recursion we will use iteration and a Stack (Recursion is also based off of stack ultimately)
        */

        static void inorderBST(node _node)
        {
            Stack<node> _stack = new Stack<node>();
            HashSet<node> visited = new HashSet<node>();
            node curr = _node;
            while (_stack.Count != 0 || curr != null)
            {

                if(curr != null)
                {
                    _stack.Push(curr);
                    curr = curr.left;
                }
                else
                {
                    curr = _stack.Pop();
                    Console.Out.Write(curr.data + " ");
                    curr = curr.right;
                }
                   
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

#if (TEST_Q3)
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

            //inorderBST(n2);
            inorderRegular(n2);

            Console.ReadKey();
        }
#endif
    }
}
