namespace pz_003
{
    internal class Program
    {
        static void Print(object a)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(a.ToString());
            Console.ResetColor();
        }

        //  должен быть прямой (preorder)
        static void GoToUnderGround(TreeNode x)
        {
            if (x != null)
            {
                Console.WriteLine(x.Info);
                if (x.Left != null) GoToUnderGround(x.Left);
                if (x.Right != null) GoToUnderGround(x.Right);
            }
        }


        //  должен быть симметричный (inorder)
        static void InUnderGround(TreeNode x, int lvl = 0)
        {
            int currentLvl = lvl;

            if (x != null)
            {
                lvl++;
                if (x.Left != null) InUnderGround(x.Left, lvl);
                for (int i = 0; i < lvl; i++) Console.Write("\t");
                Console.WriteLine(x.Info.ToString());
                if (x.Right != null) InUnderGround(x.Right, lvl);
            }
        }


        //   не обязан но может быть обратный
        static void PostUnderGround(TreeNode x)
        {
            string tempXR = String.Empty;
            string tempXL = String.Empty;
            string tempXX = String.Empty;



            if (x != null)
            {
                bool tempL = x.Left != null;
                bool tempR = x.Right != null;

                if (tempL)
                {
                    tempXR += !tempR ? "null" : x.Right.Info;
                    Console.WriteLine(tempXX + tempXL + tempXR);
                    PostUnderGround(x.Left);

                }

                if (tempR)
                {
                    tempXL += !tempL ? "null" : x.Left.Info;
                    Console.WriteLine(tempXX + tempXL + tempXR);
                    PostUnderGround(x.Right);

                }


            }
        }

        /*  в итоге они отличаются лишь порядком вывода ☺☺☺☺☺☺☺☺☺
            и конкретно с последним вариантом что то не так 
                    даже до того как он сломался*/



        static void Main(string[] args)
        {
            BinaryTree tree = new();

            #region CreatTree


            int countNode;
            Console.Write("size: ");
            if (int.TryParse(Console.ReadLine(), out countNode))
            {
                Console.Clear();
                //tree.Root = Trees.CreateBalanced(countNode);
                //tree.Create(countNode);
            }
            else tree.Root = Trees.CreateBalanced(0);

            Print("\t\t\tcurrent tree\n");

            InUnderGround(tree.Root);
            #endregion

            #region avg
            //информационное поле в виде символа зачем???? может лучше инт или хотя бы байт
            Print("\n\t\t\tnodes's avg\n");
            Trees.AvgInfo(tree.Root, out int o);
            Console.WriteLine("\t\t\t" + o);
            #endregion           

            int whatWeSearch = int.Parse(Console.ReadLine()), count1 = 0;

            count1 = Trees.SearchAboutInfo(tree.Root, whatWeSearch);
            Console.WriteLine("count of right value: " + count1);
        }
    }
}