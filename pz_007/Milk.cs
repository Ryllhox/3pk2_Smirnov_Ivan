using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_007
{
    internal class Milk : Product
    {
        public double Fat { get; set; }

        public Milk(string name, double price, double fat) : base(name, price)
        {
            Fat = fat;
        }
    }
}
