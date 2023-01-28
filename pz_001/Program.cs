using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace pz_001
{
    internal class Timing // код класса timing из вашей презентации
    {
        TimeSpan duration;
        TimeSpan[] threads;
        public Timing()
        {
            duration = new TimeSpan(0);
            threads = new TimeSpan[Process.GetCurrentProcess().Threads.Count];
        }
        public void StartTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            for (int i = 0; i < threads.Length; i++)
                threads[i] = Process.GetCurrentProcess().Threads[i].UserProcessorTime;
        }
        public void StopTime()
        {
            TimeSpan tmp;
            for (int i=0;i<threads.Length;i++)
            {
                tmp = Process.GetCurrentProcess().Threads[i].UserProcessorTime.Subtract(threads[i]);
                if (tmp > TimeSpan.Zero)
                    duration = tmp;
            }
        }
        public TimeSpan Result()
        {
            return duration;
        }
    }
    class Program
    {
        public static Random uuu = new(); // это чтобы рандомом всё заполнять везде объявим его 
        public static void FillIntArray(int[] a) // цикл на заполнение массива рандомными числами
        {
            for (int i = 0; i < a.Length; i++) a[i] = uuu.Next(0, 1000000); // рандомные числа
        }
        static int SearchBinaryList(List<int> a,int x) // бинарный поиск по List, принимает List а, переменная x это число, которое мы вводим для поиска.
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
        static int SearchBinaryArray(int[] a, int x) // бинарный поиск по массиву, принимает Array a, переменная х это число, которое мы вводим для поиска
        {
            int middle, left = 0, right = a.Length - 1;
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

            Console.WriteLine("Класс Timing ведёт себя очень странно, то он нормально выдаёт результаты,\n то он крашится под предлогом выхода за массив,\nпросто предупреждаю, что без Timing программа нормально работает\nя добавил этот класс по презентации и вроде всё должно быть нормально, но увы.");


            // СОРТИРОВКА
            // 1 ЗАДАНИЕ
            #region Sorting

            Timing objT = new(); 
            Stopwatch whatTime = new(); // для времени
            int[] a = new int[7500]; // массив на 7500 элементов
            FillIntArray(a); // заполнение массива рандомом
            int l = a.Length; // переменная для цикла
            int min = 0, imin = 0, s; // тоже для цикла
            whatTime.Start(); // поехали
            objT.StartTime(); 
            for (s = 0; s < l - 1; s++) // цикл на проходку по массиву и сортировке его
            {
                min = a[s];
                imin = s;
                for (int j = 0; j < l; j++)
                {
                    if (a[j] < min)
                    {
                        min = a[j];
                        imin = j;
                    }
                }
                if (s != imin)
                {
                    a[imin] = a[s];
                    a[s] = min;
                }

            }
            whatTime.Stop(); // остудим пыл
            objT.StopTime();
            Console.WriteLine("Результат сортировки в милисекундах: {0}, {1} (Stopwatch, Timing)", whatTime.ElapsedMilliseconds, objT.Result()); // вывод

            #endregion

            // ПОИСК МАССИВ
            // 2 ЗАДАНИЕ
            #region Простой массив

            Timing objB = new();
            Stopwatch stw = new(); // для времени
            int[] b = new int[500000]; // массив
            FillIntArray(b); // заполняем массивчик рандомом
            Console.Write("Простой поиск по массиву, что ищем: ");
            int x = Int32.Parse(Console.ReadLine()); // переменная для поиска
            int res0 = -1; // затычка такая для возвращение значения если ничего не найдём
            int i2 = 0; // для цикла
            stw.Start(); // стартуем
            objB.StartTime();
            while (i2 < b.Length && b[i2] != x) // цикл на прохождение по массиву и поиска элемента
            {
                i2++;
                if (i2 < b.Length) res0 = i2;
            }
            stw.Stop(); // конец времени
            objB.StopTime();
            Console.WriteLine("Простой поиск по массиву, результат в тиках: {0}, {1} (Stopwatch, Timing)", stw.ElapsedTicks, objB.Result()); // вывод

            #endregion

            #region Бинарный массив

            Timing objZ = new();
            int[] f = new int[7500];
            FillIntArray(f);
            Console.Write("Бинарный поиск по массиву, введите целое число: ");
            int r = Int32.Parse(Console.ReadLine()); // принимаем переменную которую будем искать
            Stopwatch pas = new Stopwatch(); // для времени
            pas.Start(); // старт
            objZ.StartTime();
            SearchBinaryArray(f, r);
            pas.Stop(); // конец времени я его отменяю всем спать
            objZ.StopTime();
            Console.WriteLine("Бинарный поиск по массиву, результат найден за {0}, {1} (в тиках, Stopwatch, Timing)", pas.ElapsedTicks, objZ.Result()); // вывод

            #endregion

            // ВЕЗДЕ TIMING СДЕЛАТЬ ДОПОЛНИТЕЛЬНО

            // ПОИСК СПИСОК
            // 3 ЗАДАНИЕ
            #region Просто список

            Timing objV = new();
            List<int> listint = new List<int>(); // объявление списка
            for (int i = 0; i<7500; i++) // цикл на заполнение списка
            {
                listint.Add(uuu.Next()); // заполнение рандомом
            }
            Console.Write("Простой поиск по LIST, введите целое число: ");
            int y = Int32.Parse(Console.ReadLine()); // принимаем переменную которую будем искать
            int res00 = -1; // переменная, которую вернёт система в случае неудачного поиска
            int i3 = 0; // для цикла
            Stopwatch stap = new Stopwatch(); // для времени
            stap.Start(); // старт
            objV.StartTime();
            while (i3 < listint.Count && listint[i3] != y) // цикл который проверяет не соответствует ли элемент который перебирает цикл тому, которого мы ищем
            {
                i3++;
                if (i3 < listint.Count) res00 = i3;
            }
            stap.Stop(); // конец времени я его отменяю всем спать
            objV.StopTime();
            Console.WriteLine("Простой поиск по списку, результат найден за {0}, {1} (в тиках, Stopwatch, Timing)", stap.ElapsedTicks, objV.Result()); // вывод

            #endregion

            #region Бинарный список

            Timing objK = new();
            List<int> intlist = new List<int>(); // объявление списка
            for (int i = 0; i < 7500; i++) // цикл на заполнение списка
            {
                intlist.Add(uuu.Next()); // заполнение рандомом
            }
            Console.WriteLine("Бинарный поиск по LIST, введите целое число: ");
            int g = int.Parse(Console.ReadLine()); // принимаем переменную которую будем искать
            Stopwatch sap = new(); // для времени
            sap.Start(); // стартуем
            objK.StartTime();
            SearchBinaryList(intlist, g); // используем метод бинарного поиска
            sap.Stop(); // конец времени
            objK.StopTime();
            Console.WriteLine("Бинарный поиск по списку, результат найден за {0}, {1} (в тиках, Stopwatch, Timing)", sap.ElapsedTicks, objK.Result()); // вывод

            #endregion

            // ПОИСК ХЭШТАБЛИЦА
            // 4 ЗАДАНИЕ
            #region Хэштаблицы

            Timing objH = new();
            Hashtable ht = new(); // объявление хэштаблицы
            for (int i=0;i<7500;i++) // цикл на заполнение хэштаблицы
            {
                ht.Add(uuu.Next(), uuu.Next()); // заполняем рандомом
            }
            Console.Write("Хэш таблицы. Что ищем: ");
            int p = Int32.Parse(Console.ReadLine()); // переменная которую будем использовать для поиска
            int res000 = -1; // вывод в случае исключения
            int i4 = 0; // для цикла 
            Stopwatch stappy = new Stopwatch(); // для времени
            stappy.Start(); // стартуем
            objH.StartTime();
            while (i4 < ht.Count && ht.Contains(i4)) // цикл который проверяет не соответствует ли элемент который перебирает цикл тому, которого мы ищем
            {
                i4++;
                if (i4 < listint.Count) res000 = i4;
            }
            stappy.Stop(); // конец времени
            objH.StopTime();
            Console.WriteLine("Простой поиск по хэштаблице, результат найден за {0}, {1} (в тиках, Stopwatch, Timing)", stappy.ElapsedTicks, objH.Result()); // вывод

            #endregion
        }
    }
}
