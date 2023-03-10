namespace pz_005
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Country country = new(-1, "x", 0.0f);
            Country c2 = new(-2, "y", 0.1f);

            City one = new(0, "a", country, 10.0f);
            var two = one;

            Console.WriteLine($"произошло копирование и якобы есть два объекта:\n\t{one}\n\t{two}");

            two.Name = "dfyuiwedywuef";

            Console.WriteLine($"дальше идет изменение объекта 2. результат:\n\t{one}\n\t{two}");

            var three = one.Clone() as City;
            three.Id = 1010;
            three.Coy = c2;

            Console.WriteLine($"после этого случается изменение третьего обьекта - копия первого:\n\t{one}\n\t{two}\n\t{three}");

            var four = three.Clone() as City;
            four.Id = 1011;
            four.Coy = country;

            Console.WriteLine($"появляется 4й объект - копия 3, в нем меняется страна:\n\t{one}\n\t{two}\n\t{three}\n\t{four}");

            Console.WriteLine();
            Console.WriteLine("Сравнивание по имени через интерфейс IComparable");
            City[] cityArray = new City[] { one,two,three,four };
            Array.Sort(cityArray);
            foreach( City ceetie in cityArray )
            {
                Console.WriteLine($"{ceetie.Name} - {ceetie.Id}");
            }
        }
    }
}