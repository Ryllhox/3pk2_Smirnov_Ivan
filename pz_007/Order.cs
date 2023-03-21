using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_007
{
    public class Order
    {
        public Client Buyer { get; set; }
        public List<Product> Items { get; set; }

        public Order(Client buyer, params Product[] a)
        {
            Buyer = buyer;

            Items = new List<Product>();

            foreach (var item in a)
            {
                Items.Add(item);
                Buyer.AllPurchases += item.Price - item.Price * Product.GetDiscount(buyer);
            }

        }

        public override string ToString()
        {
            return $"{Buyer.Name}:\n\t{string.Join('-', Items.Select(x => x.Name))}";
        }
    }
}
