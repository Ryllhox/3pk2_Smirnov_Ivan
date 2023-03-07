namespace pz_004
{
    internal class Program
    {
        static Random uuu = new();

        static void Print(object a)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(a.ToString());
            Console.ResetColor();
        }
        // метод отрисовки визуализация дерева нашего крутого 
        static void Print_DTree(DTreeNode x, int lvl = 0)
        {
            // уровень дерева на котором мы щас находимся (глубина) , по умолчанию при первом вызове = 0
            int currentLvl = lvl;

            // если листочек не равен нулю выполняем искусство рисования пикассо вангог моцарт черчилль
            if (x != null)
            {
                lvl++;
                // если правый листик не равен нулю, значит его нужно отрисовать справа
                if (x.Right != null) Print_DTree(x.Right, lvl);
                // делаем табуляцию до уровня глубины нашего деревца столетний дуб с золотой цепью
                for (int i = 0; i < lvl; i++) Console.Write("\t");
                // отображаем листик наш осенний уже пришла весна значит зелёный почки
                Console.WriteLine(x.Key.ToString());
                // ну а если левый не равен нулю, значит его нужно отрисовать слева всё логично не путаем право и лево
                if (x.Left != null) Print_DTree(x.Left, lvl);
            }
        }

        static void Main(string[] args)
        {
            #region TreeCreating
            // создание дерева с info 0 и значением ключа от 0 до 1001
            var tree = new DixotomyTree(new('0', uuu.Next(0, 1001)));

            //  хорошая идея присваивать рандом (чар) 58-128

            List<int> a = new();
            // просьба ввести кол-во листочков
            Console.Write($"leafs count>> ");
            // переменная для количества листочков
            int countLeafs = -1;
            int.TryParse(Console.ReadLine(), out countLeafs);

            for (int i = 0; i < countLeafs; i++)
            {
                // алгоритм создания последовательности неповторяющихся символов 
                var temp = new DTreeNode((char)uuu.Next(58, 128), uuu.Next(0, 1001));
                // проверка на неповторяемость символа
                if (!a.Contains(temp.Key))
                {
                    // добавляем бандита в ключ
                    a.Add(temp.Key);
                    DixotomyTree.Insert_DNode(tree.Root, temp);
                }
                // если повторились то отменяем кандидата на занос в список желаемых сотрудников нашего деревовидного офиса
                else i--;
            }
            // вывод начального значения самого первого ключа дерева
            Console.WriteLine("start with: {0}", tree.Root.Key + "\n\n");
            // рисуем деревце 
            Print_DTree(tree.Root);
            // вывод значений листиков (key)
            Print($"\n\n{string.Join('—', a)}\n\n");

            #endregion

            #region CountLeefs
            // массив для сбора info 
            var result1 = new List<char>();
            // метод с помощью которого получаем info sum схема простая всё расписано в самом методе в классе его
            DixotomyTree.InfoSum(tree.Root, result1);
            // выводит эту инфосум как и листики в регионе TreeCreating сверху
            Print(string.Join('—', result1));

            #endregion

            #region CountBnchs

            Console.WriteLine(DixotomyTree.HowMuchBenchInTheTree(tree.Root));

            #endregion


        }
    }
}