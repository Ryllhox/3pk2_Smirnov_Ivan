using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_007
{
    abstract public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public static float GetDiscount(Client x)
        {
            if (x.AllPurchases == 0) return 0.1f;
            else if (x.AllPurchases > 20_000) return 0.15f;
            else if (x.AllPurchases > 5_000) return 0.2f;
            else return -1;
        }
    }
}
