using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_005
{
    internal class Country : Maps
    {
        public double Volume { get; set; }

        public Country()
        {

        }

        public Country(int id, string name, double volume) : base(id, name)
        {
            Volume = volume;
        }
    }
}
