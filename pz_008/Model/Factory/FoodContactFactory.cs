using pz_008.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_008.Model.Factory
{
    internal class FoodContactFactory : ContactFactory
    {
        public string Name { get; }
        public long Phone { get; }
        public string Adress { get; }
        public string Description { get; }
        public string[] Menu { get; }

        public FoodContactFactory(string name, long phone, string adress, string description, string[] menu)
        {
            Name = name;
            Phone = phone;
            Adress = adress;
            Description = description;
            Menu = menu;
        }

        public override IContact GetContact()
        {
            return new FoodContact(Name, Phone, Adress, Description, Menu);
        }
    }
}
