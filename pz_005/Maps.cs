using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_005
{
    internal class Maps
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Maps()
        {

        }

        public Maps(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
