using pz_008.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_008.Model.Factory
{
    internal class PersonContactFactory : ContactFactory
    {
        public string ContactName { get; }
        public long ContactNumber { get; }
        public string ContactRegion { get; }

        public PersonContactFactory(string name, long num, string reg)
        {
            ContactName = name;
            ContactNumber = num;
            ContactRegion = reg;
        }

        public override IContact GetContact()
        {
            return new PersonContact(ContactName, ContactNumber, ContactRegion);
        }
    }
}
