using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace pz_001
{
    class Program
    {
        public static Random uuu = new();

        static int SearchBinaryHash(ICollection a, int x)
        {
            int middle, left = 0, right = a.Count - 1;
            do
            {
                middle = (left + right) / 2;
                if (x > a[middle])
                    left = middle + 1;
                else
                    right = middle - 1;
            }
            while (a[middle] != x && left <= right);
            if (a[middle] == x)
                return middle;
            else
                return -1;
        }
        static int SearchBinaryList(List<int> a,int x)
        {
            int middle, left = 0, right = a.Count - 1;
            do
            {
                middle = (left + right) / 2;
                if (x > a[middle])
                    left = middle + 1;
                else
                    right = middle - 1;
            }
            while (a[middle] != x && left <= right);
            if (a[middle] == x)
                return middle;
            else
                return -1;
        }
        static void Main(string[] args)
        {






           // !!! СДЕЛАТЬ ПОИСК БИНАРНЫЙ МАССИВА !! ++ ВЕЗДЕ TIMING СДЕЛАТЬ ДОПОЛНИТЕЛЬНО






            #region Работаем просто список
            List<int> listint = new List<int>();
            for (int i = 0; i<7500; i++)
            {
                listint.Add(uuu.Next());
            }
            Console.Write("каво исчем: ");
            int y = Int32.Parse(Console.ReadLine());
            int res00 = -1;
            int i3 = 0;
            Stopwatch stap = new Stopwatch();
            stap.Start();
            while (i3 < listint.Count && listint[i3] != y)
            {
                i3++;
                if (i3 < listint.Count) res00 = i3;
            }
            stap.Stop();
            Console.WriteLine("Результат найден за {0} (в тикетах)", stap.ElapsedTicks);
            #endregion

            #region Работаем бинарный список
            List<int> intlist = new List<int>();
            for (int i = 0; i < 7500; i++)
            {
                intlist.Add(uuu.Next());
            }
            Console.WriteLine("enter the int");
            int g = int.Parse(Console.ReadLine());
            Stopwatch sap = new();
            sap.Start();
            SearchBinaryList(intlist, g);
            sap.Stop();
            Console.WriteLine("Результат найден за {0} (в тикетах)", sap.ElapsedTicks);
            #endregion

            #region Хэштаблицы


            Hashtable ht = new();
            for (int i=0;i<7500;i++)
            {
                ht.Add(uuu.Next(), uuu.Next());
            }


            //ICollection col = ht.Keys;

            //foreach (var item in col)
            //{
            //    Console.WriteLine(item+": "+ht[item]);
            //}



            Console.Write("каво исчем: ");
            int p = Int32.Parse(Console.ReadLine());
            int res000 = -1;
            int i4 = 0;
            Stopwatch stappy = new Stopwatch();
            stappy.Start();
            while (i4 < ht.Count && ht.Contains(i4))
            {
                i4++;
                if (i4 < listint.Count) res000 = i4;
            }
            stappy.Stop();
            Console.WriteLine("Результат найден за {0} (в тикетах)", stappy.ElapsedTicks);


            SearchBinaryHash(ht.Keys, i4);


            #endregion
        }
    }
}
