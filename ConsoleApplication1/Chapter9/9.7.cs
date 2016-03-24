using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Q9.7) GIven an inorder traversal order, and one of a preorder or a postorder of a binary tree
            write a function to recocnstruct the tree 
*/
namespace EPI9_Q7
{
    class node
    {
        public char data;
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
            root.data = 'A';
        }
        public node getRoot() { return root; }
        public void addLeftChild(node parent, node leftChild)
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

            while (currentNode != null)
            {
                if (lastNode == currentNode.parent) // current node left or right child of the last node
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
                if (lastNode == currentNode.left)  //done visiting left subtree
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
                if (lastNode == currentNode.right) //done visiting right subtree (move up)
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


#if(TEST_Q9)

        //static node constructTree(char[] inorder, char[] preorder)
        //{
        //    node root = new node();
        //    int indexOfRoot = inorder.Count() / 2;
        //    root.data = inorder[indexOfRoot];

        //    root.left = constructSubTree(inorder, preorder, 0, indexOfRoot - 1);
        //    root.right = constructSubTree(inorder, preorder,indexOfRoot + 1, inorder.Count()-1);

        //    return root;
        //}

        //static node constructSubTree(char[] inorder, char[] preorder, int inorderStartIndex, int inorderEndIndex)
        //{
        //    node root = new node();

        //    if(inorderEndIndex == inorderStartIndex)
        //    {
        //        root.data = 
        //    }
        //    int indexOfRoot = (inorderStartIndex + inorderEndIndex) / 2;
        //}
        static void Main(string[] args)
        {
            char[] inorder = new char[] { 'F', 'B', 'A', 'E', 'H', 'C', 'D', 'I', 'G' };
            char[] preorder = new char[] { 'H', 'B', 'F', 'E', 'A', 'C', 'D', 'G', 'I' };

            Console.ReadKey();
        }
#endif
    }
}
