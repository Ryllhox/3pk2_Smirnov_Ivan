using System;
using System.Collections.Generic;
using System.Linq;

namespace pz_002
{
    internal class Program
    {
        public static Random uuu;

        public static void Print(object a)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(a.ToString());
            Console.ResetColor();
        }

        /*
         1 найти самый дешевый узел
         2 обновить стоимость его соседей
         3 повторять для всех узлов
         4 результат
         */

        public static Node? FindLowestCostNode(Node[] n)
        {
            Node result = new Node(-1, int.MaxValue);

            foreach (var item in n) if (item.Weight < result.Weight) result = item;

            return result.Weight == int.MaxValue ? null : result;
        }

        public static void Dijkstra(Graph g)        //  еще что то про родителей
        {
            int currentWeight = 0;
            int newWeight = 0;
            List<Node> neighbors = new();

            List<int> weights = new();
            for (int i = 0; i < g.Size; i++) weights.Add(g.AdjList[i].Weight);

            Node a = FindLowestCostNode(g.AdjList);

            while (a != null)
            {
                currentWeight = weights[a.Id];
                neighbors = a.Link;

                foreach (var item in neighbors)
                {
                    newWeight = currentWeight + item.Weight;
                    if (weights[a.Id] > newWeight)
                    {
                        weights[a.Id] = newWeight;
                    }
                }
                g.Vector[a.Id] = true;

                a = FindLowestCostNode(g.AdjList);
            }

            Console.WriteLine(currentWeight + " " + newWeight + "\n" + String.Join(';', neighbors.Select(x => x.Weight)));
        }

        public static void DFS(Graph graph, int node)
        {
            graph.Vector[node] = true; // отметить вершину i как обработанную
            Console.Write("{0}" + ' ', node); // распечатать номер посещенной вершины
            for (int k = graph.Size - 1; k >= 0; k--)
            {
                if (graph.Adjacency[node, k] && !(graph.Vector[k])) DFS(graph, k);
            }
        }

        static void Main(string[] args)
        {
            uuu = new();
            Console.WriteLine("\n——————————");

            bool[,] O2 = new bool[5, 5]
                            {
                                            {false, false, false,true,false}, // матрица смежности графа G5.1  -- ориент
                                            {true,false,false,false,true},
                                            {false,true,false,true,false},
                                            {true,true,true,false,true},
                                            {false,false,false,true,false}
                            };
            Graph graph4 = new Graph(5, O2);

            Console.Write("\ndepth: ");
            DFS(graph4, 2);
            Console.WriteLine("\n\n\n");

            Dijkstra(graph4);
        }
    }
}
