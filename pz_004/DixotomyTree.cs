using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_004
{
    internal class DixotomyTree
    {
        private DTreeNode root;

        public DTreeNode Root
        {
            get { return root; }
            set { root = value; }
        }
        public DixotomyTree(DTreeNode start)
        {
            root = start;
        }
        public static DTreeNode Insert_DNode(DTreeNode root, DTreeNode k)
        {
            // если корень равен нулю он приравнивается к получаемому значению
            if (root == null) root = k;
            else
            {
                // если ключ вставляемый меньше ключа который есть уже в дереве то его влево вставляем
                if (k.Key < root.Key) root.Left = Insert_DNode(root.Left, k);
                // если ключ вставляемый больше ключа который есть уже в дереве то его вправо вставляем
                else if (k.Key > root.Key) root.Right = Insert_DNode(root.Right, k);
                // гениальный исход событий вы великий программист
                else Console.WriteLine("eror: !(unique key)");
            }

            return root;
        }

        public static void InfoSum(DTreeNode x, List<char> a)
        {
            // добавляем к массиву символы info (x) листика
            a.Add(x.Info);
            // если правый листик не равен нулю
            if (x.Right != null)
            {
                // добавляем в сумму правый листик
                InfoSum(x.Right, a);
            }
            // если левый листик не равен нулю
            if (x.Left != null)
            {
                // добавляем в сумму левый листик
                InfoSum(x.Left, a);
            }
        }
        // подсчёт веток в дереве
        public static int HowMuchBenchInTheTree(DTreeNode x)
        {
            // корень равен нулю или листик равен нулю (оба листика как палочки твикс съеденные) возвращаем нуль
            if (x == null || (x.Left == null && x.Right == null)) return 0;
            // в противном случае нужно вернуть 1 и по новой пройтись этим методом по листикам
            else return 1 + HowMuchBenchInTheTree(x.Left) + HowMuchBenchInTheTree(x.Right);
        }
    }
}
