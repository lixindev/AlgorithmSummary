using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    //非递归遍历二叉树
    public class TraverseBinaryTree
    {
        public void PreOrderTraverse(TreeNode root)
        {
            if (root == null) return;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;

            while (cur != null || stack.Count > 0)
            {
                if (cur != null)
                {
                    //优先遍历左子树，把当前节点压入栈中
                    Console.WriteLine(cur.Value);
                    stack.Push(cur);
                    cur = cur.Left;
                }
                else
                {
                    //左子树遍历完，从栈中取出节点遍历右子树
                    cur = stack.Pop();
                    cur = cur.Right;
                }
            }
        }

        public void InOrderTraverse(TreeNode root)
        {
            if (root == null) return;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;

            while (cur != null || stack.Count > 0)
            {
                if (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.Left;
                }
                else
                {
                    cur = stack.Pop();
                    Console.WriteLine(cur.Value);
                    cur = cur.Right;
                }
            }
        }

        public void PostOrderTraverse(TreeNode root)
        {
            if (root == null) return;
            Stack<TreeNode> stack1 = new Stack<TreeNode>();
            Stack<TreeNode> stack2 = new Stack<TreeNode>();
            TreeNode top;
            stack1.Push(root);
            //先把左节点压入栈1，然后是右节点
            while (stack1.Count > 0)
            {
                top = stack1.Pop();
                stack2.Push(top);
                if (top.Left != null)
                {
                    stack1.Push(top.Left);
                } 
                else if (top.Right != null)
                {
                    stack1.Push(top.Right);
                }
            }

            while(stack2.Count > 0)
            {
                Console.WriteLine(stack2.Pop().Value);
            }
        }
    }
}
