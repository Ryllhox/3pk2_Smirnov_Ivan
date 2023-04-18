using pz_008.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_008.Model.Factory
{
    internal class SchoolContactFactory : ContactFactory
    {
        public string Name { get; }

        public long Phone { get; }
        public string Adress { get; }
        public string Specialization { get; }
        public int StudentCount { get; }

        public SchoolContactFactory(string name, long phone, string adress, string spez, int countS)
        {
            Name = name;
            Phone = phone;
            Adress = adress;
            Specialization = spez;
            StudentCount = countS;
        }

        public override IContact GetContact()
        {
            return new SchoolContact(Name, Phone, Adress, Specialization, StudentCount);
        }
    }
}
