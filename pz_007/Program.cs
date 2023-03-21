namespace pz_007
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store shopOKSEI = new();
            #region 1stStoreProducts
            List<Product> products = new List<Product>
            {
                new Bread("Бородинский",30.0f,"Чёрный"),
                new Bread("Солнечный", 28.0f, "Белый"),
                new Beer("Балтика",40.0f,4.7f),
                new Beer("Шихан",38.0f,4.5f),
                new Milk("Летний Луг",34.0f,2.5f),
                new Milk("Красная цена",33.5f,3.2f)
            };
            Console.WriteLine("at all we have next products:");
            foreach (Product item in products)
            {
                Console.WriteLine($"\t{item.Name} - {item.Price}");
            }
            #endregion

            Console.WriteLine();

            #region Customers

            Client client1 = new() { Name = "Petor" };
            Client client2 = new() { Name = "Vasiliy", AllPurchases = 3000 };

            Console.WriteLine($"client: \t{client1.Name}\t{client1.AllPurchases}\n\t{client2.Name}\t{client2.AllPurchases}");


            #endregion

            Console.WriteLine();

            #region Carts

            shopOKSEI.SaveOrder(client1, products[0], products[2], products[4]);
            shopOKSEI.SaveOrder(client2, products[1], products[3], products[5]);
            shopOKSEI.SaveOrder(client1, products[0], products[1], products[5]);
            Console.WriteLine("today operations is:");
            for (int i = 0;i<shopOKSEI.AllPurchases.Count;i++)
            {
                Console.WriteLine(shopOKSEI.AllPurchases[i]);
            }

            Console.WriteLine($"in finally clients are having: \n\t{client1.Name}\t{client1.AllPurchases:f2}\n\t{client2.Name}\t{client2.AllPurchases:f2}");

            #endregion
        }
    }
}