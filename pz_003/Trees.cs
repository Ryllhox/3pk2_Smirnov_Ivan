using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_003
{
    internal static class Trees
    {
        //   ветка бинарного дерева ()уравновешенного, может быть даже идеально сбалансированного
        public static TreeNode CreateBalanced(int n)
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

                root.Left = CreateBalanced(n / 2);
                root.Right = CreateBalanced(n - n / 2 - 1);
            }

            return root;
        }

        

        public static void AvgInfo(TreeNode x, out int future, int currentAvg = 0)
        {
            future = currentAvg;

            if (x != null)
            {
                future += x.Info;
                if (x.Left != null) AvgInfo(x.Left, out future, future);
                if (x.Right != null) AvgInfo(x.Right, out future, future);

            }
        }

        public static void CountPlusMinus(TreeNode x, ref int plus, ref int minus)
        {
            if (x != null)
            {
                if (x.Left != null)
                {
                    if (x.Left.Info >= 0) plus++;
                    else minus++;
                    CountPlusMinus(x.Left, ref plus, ref minus);
                }
                if (x.Right != null)
                {
                    if (x.Right.Info >= 0) plus++;
                    else minus++;
                    CountPlusMinus(x.Right, ref plus, ref minus);
                }
            }
        }

        

        public static int SearchAboutInfo(TreeNode x, int wht, int currentCount = 0)
        {
            if (x != null)
            {

                if (x.Left != null)
                {
                    if (x.Left.Info == wht) currentCount++;
                    SearchAboutInfo(x.Left, wht, currentCount);
                }
                if (x.Right != null)
                {
                    if (x.Right.Info == wht) currentCount++;
                    SearchAboutInfo(x.Right, wht, currentCount);
                }
            }
            return currentCount;
        }

    }
}
