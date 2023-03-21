using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_007
{
    internal class Beer : Product
    {
        public double Alcohol { get; set; }

        public Beer(string name, double price, double al) : base(name, price)
        {
            Alcohol = al;
        }
    }
}
