using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace pz_008.Model.Domain
{
    internal interface IContact
    {
        public string Name { get; }
        public long Phone { get; }
        public string[] GetInfo();
    }
}
