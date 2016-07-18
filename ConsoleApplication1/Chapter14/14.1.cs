using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q14.1) Write a function that takes as input the root of a binary tree whose nodes have a key field, and returns true 
           iff the tree satisfies the BST property.
*/
namespace EPI14_Q1
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
        static int lastNode = int.MinValue;
        static bool isBST = true;

        /* instead of this we can store the nodes in an array in preorder and check if they are sorted */

        static void inorder(node _node)
        {
            if (_node.left != null)
            {
                inorder(_node.left);
            }

            if (_node.data < lastNode)
                isBST = false;

            Console.Out.Write(_node.data + " ");
            lastNode = _node.data;

            if (_node.right != null)
            {
                inorder(_node.right);
            }

            return;
        }
#if (TEST_Q1)
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
            //n3.data = 8;
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
            //n11.data = 44;
            n6.right = n11;

            inorder(bst.root);
            Console.Out.WriteLine("is BST ? : {0} ", Program.isBST);

            Console.ReadKey();
        }
#endif
    }
}
