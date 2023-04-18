using pz_008.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_008.Model.Factory
{
    internal abstract class ContactFactory
    {
        public abstract IContact GetContact();
    }
}
