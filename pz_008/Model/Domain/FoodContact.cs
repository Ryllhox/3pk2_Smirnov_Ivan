using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_008.Model.Domain
{
    internal class FoodContact : IContact
    {
        public string Name { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string[] Menu { get; set; }

        public FoodContact(string name, long phone, string adrecc, string description, string[] menu)
        {
            Name = name;
            Phone = phone;
            Address = adrecc;
            Description = description;
            Menu = menu;
        }

        public string[] GetInfo()
        {
            return new string[5] { Name, Phone.ToString(), Address, Description, string.Join('—', Menu) };
        }
    }
}
