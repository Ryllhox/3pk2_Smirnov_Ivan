using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_003
{
    internal class TreeNode
    {
        private int info;

        public int Info
        {
            get { return info; }
            set { info = value; }
        }

        private TreeNode left;

        public TreeNode Left
        {
            get { return left; }
            set { left = value; }
        }
        private TreeNode right;
        public TreeNode Right
        {
            get { return right; }
            set { right = value; }
        }

        public TreeNode()
        {

        }
        public TreeNode(int info)
        {
            Info = info;
        }
        public TreeNode(int info, TreeNode left, TreeNode right)
        {
            Info = info;
            Left = left;
            Right = right;
        }

        public void Create(int n, TreeNode treeNode)
        {
            int x;
            TreeNode root;

            if (n == 0) root = null;
            else
            {
                Console.Write($"info {n} (char):");
                x = int.Parse(Console.ReadLine());
                Console.Clear();
                root = new TreeNode(x);

                root.Left.Create(n / 2,
            this);
                root.Right.Create(n - n / 2 - 1,
            this);
            }

            treeNode = root;
        }
    }
}
