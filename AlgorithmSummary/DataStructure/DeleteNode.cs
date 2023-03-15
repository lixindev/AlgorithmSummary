using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary.DataStructure
{
    /// <summary>
    /// 给定一个二叉搜索树的根节点 root 和一个值 key，删除二叉搜索树中的 key 对应的节点，并保证二叉搜索树的性质不变。返回二叉搜索树（有可能被更新）的根节点的引用。
    /// </summary>
    public class DeleteNode
    {
        private TreeNode[] nodes = new TreeNode[2];
        public TreeNode Delete_Node(TreeNode root, int key)
        {
            if (root == null)
            {
                return root;
            }
            PreOrder(null, root, key);
            if (nodes[1] == null)
            {
                return root;
            }
            if (nodes[1].Left == null)
            {
                TransPlant(ref root, nodes[0], nodes[1], nodes[1].Right);
            }
            else if (nodes[1].Right == null)
            {
                TransPlant(ref root, nodes[0], nodes[1], nodes[1].Left);
            }
            else
            {
                TreeNode[] RightNodes = TreeMinmum(nodes[1].Right);
                TreeNode y = RightNodes[1];
                if (y != nodes[1].Right)
                {
                    TreeNode parent = RightNodes[0];
                    TransPlant(ref root, parent, y, y.Right);
                    y.Right = nodes[1].Right;
                }
                TransPlant(ref root, nodes[0], nodes[1], y);
                y.Left = nodes[1].Left;
            }

            return root;
        }

        private void PreOrder(TreeNode parent, TreeNode node, int key)
        {
            if (node.Value == key)
            {
                nodes[0] = parent;
                nodes[1] = node;
                return;
            }
            if (node.Left != null)
            {
                PreOrder(node, node.Left, key);
            }
            if (node.Right != null)
            {
                PreOrder(node, node.Right, key);
            }
        }

        private void TransPlant(ref TreeNode root, TreeNode parent, TreeNode deleted, TreeNode r)
        {
            if (parent == null)
            {
                root = r;
            }
            else if (parent.Left == deleted)
            {
                parent.Left = r;
            }
            else
            {
                parent.Right = r;
            }
        }

        private TreeNode[] TreeMinmum(TreeNode node)
        {
            TreeNode parent = null;
            TreeNode temp = node;
            while (temp.Left != null)
            {
                parent = temp;
                temp = temp.Left;
            }
            return new TreeNode[] { parent, temp };
        }
    }
}
