using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_005
{
    internal class City : Maps, ICloneable, IComparable<City>
    {
        public Country Coy { get; set; }
        public double Volume { get; set; }
        public City(int id, string name, Country c, double volume) : base(id, name)
        {
            Coy = c; Volume = volume;
        }

        public override string ToString()
        {
            return $"{Id}. {Name}({Coy.Name}) — ";
        }

        public object Clone()
        {
            //return MemberwiseClone();
            return new City(Id, Name, new Country(Coy.Id, Coy.Name, Coy.Volume), Volume);
        }


        // обобщённая версия компейребла 
        public int CompareTo(City? city)
        {
            if (city == null)
            {
                throw new ArgumentException("Некорректное значение параметра!");
            }
            return Name.CompareTo(city.Name);
        }


        // код снизу используется на преобразовании объекта в наш тип данных city
        // для его использования необходимо:
        // закомментить/удалить обобщённую реализацию интерфейса
        // удалить "<City>" после IComparable сверху в наследовании класса от интерфейса
        // расскоментить данный блок кода снизу

        //public int CompareTo(object o)
        //{
        //    City cityCOMPARE = o as City;
        //    if (cityCOMPARE != null)
        //    {
        //        return this.Name.CompareTo(cityCOMPARE.Name);
        //    }
        //    else
        //    {
        //        throw new Exception("Невозможно сравнить два объекта, чото намутили непонятное");
        //    }
        //}
    }
}