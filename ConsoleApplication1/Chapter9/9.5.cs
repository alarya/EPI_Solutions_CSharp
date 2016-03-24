using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Let T be the root of a binary tree in which nodes have an explicit parent
    field. Design an iterative algorithm that enumerates the nodes inorder and
    uses O(1) additional space. Your algorithm cannot modify the tree.
*/
namespace Chapter9
{
    class node
    {
        public int data;
        public node left = null;
        public node right = null;
        public node parent = null;
    }

    class BTree
    {
        node root = null;
        public BTree()
        {
            root = new node();
            root.data = 1;
        }
        public node getRoot() { return root; }
        public void addLeftChild(node parent,node leftChild)
        {
            parent.left = leftChild;
            leftChild.parent = parent;
        }
        public void addRightChild(node parent, node rightChild)
        {
            parent.right = rightChild;
            rightChild.parent = parent;
        }

        public void inorderRegular(node _node)
        {

            if (_node.left != null)
                inorderRegular(_node.left);

            Console.Out.Write(_node.data + " ");

            if (_node.right != null)
                inorderRegular(_node.right);
        }

        public void inorder(node _node)
        {
            node lastNode = null;
            node currentNode = _node;
            
            while(currentNode != null)
            { 
                if(lastNode == currentNode.parent) // current node left or right child of the last node
                {
                    if (currentNode.left != null)
                    {
                        lastNode = currentNode;
                        currentNode = currentNode.left;
                        continue;
                    }
                    else
                        lastNode = null;
                }
                if(lastNode == currentNode.left)  //done visiting left subtree
                {
                    Console.Out.Write(currentNode.data + " ");

                    //start with right subtree  of current node
                    if (currentNode.right != null)
                    {
                        lastNode = currentNode;
                        currentNode = currentNode.right;
                        continue;
                    }
                    else
                        lastNode = null;
                }
                if(lastNode == currentNode.right) //done visiting right subtree (move up)
                {
                    lastNode = currentNode;
                    currentNode = currentNode.parent;
                }
            } 
        }

        public void preorderRegular(node _node)
        {
            Console.Out.Write(_node.data + " ");

            if (_node.left != null)          
                preorderRegular(_node.left);

            if (_node.right != null)            
                preorderRegular(_node.right);            
        }

        public void postorderRegular(node _node)
        {            

            if (_node.left != null)
                postorderRegular(_node.left);

            if (_node.right != null)
                postorderRegular(_node.right);

            Console.Out.Write(_node.data + " ");
        }
    }

    class Program
    {


#if(TEST_Q5)
        static void Main(string[] args)
        {
            BTree Tree = new BTree();

            node node2 = new node();
            node2.data = 2;
            Tree.addLeftChild(Tree.getRoot(), node2);

            node node3 = new node();
            node3.data = 3;
            Tree.addRightChild(Tree.getRoot(), node3);
            
            node node4 = new node();
            node4.data = 4;
            Tree.addLeftChild(node2, node4);

            node node5 = new node();
            node5.data = 5;
            Tree.addRightChild(node2, node5);

            node node6 = new node();
            node6.data = 6;
            Tree.addLeftChild(node3, node6);

            node node7 = new node();
            node7.data = 7;
            Tree.addRightChild(node3, node7);

            //Tree.inorderRegular(Tree.getRoot());

            Console.Out.WriteLine();

            //Tree.preorderRegular(Tree.getRoot());

            Console.Out.WriteLine();

            //Tree.postorderRegular(Tree.getRoot());

            Tree.inorder(Tree.getRoot());

            Console.ReadKey();
        }
#endif
    }
}
