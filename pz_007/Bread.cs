using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_007
{
    internal class Bread : Product
    {
        public string Color { get; set; }

        public Bread(string name, double price, string color) : base(name, price)
        {
            Color = color;
        }
    }
}
