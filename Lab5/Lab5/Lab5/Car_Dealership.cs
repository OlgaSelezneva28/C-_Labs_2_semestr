using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    //Класс автосалона
    public class Car_Dealership
    {
        public String name; // Название 
        public String adr; //Адрес

        public Car_Dealership() { }

        public Car_Dealership(String n, String Adr)
        {
            name = n;
            adr = Adr;
        }

        public String GetName()
        {
            return name;
        }

        public String GetAddress()
        {
            return adr;
        }
       

        //Перегрузка вывода 
        public override string ToString()
        {

            String Rec = " ";

            Rec += "Автосалон: ";
            Rec += name;
            Rec += " ";

            Rec += " по адресу: ";
            Rec += adr;
            Rec += " ";


            return Rec;

        }


        //Перегрузка операций 

        //!= 
        public static bool operator !=(Car_Dealership a, Car_Dealership b)
        {
            if ((a.name != b.name) || (a.adr != b.adr))
                return true;
            else
                return false;
        }

        //==
        public static bool operator ==(Car_Dealership a, Car_Dealership b)
        {
            if ((a.name == b.name) && (a.adr == b.adr))
                return true;
            else
                return false;
        }


        public static bool operator <(Car_Dealership a, Car_Dealership b)
        {

            for (int i = 0; i < Math.Min(a.name.Count(), b.name.Count()); i++)
            {
                if (a.name[i] > b.name[i])
                    return false;

            }

            if (a.name.Count() == b.name.Count())
                return true;

            if (a.name.Count() < b.name.Count())
                return true;
            else
                return false;
        }

        public static bool operator >(Car_Dealership a, Car_Dealership b)
        {
            for (int i = 0; i < Math.Min(a.name.Count(), b.name.Count()); i++)
            {
                if (a.name[i] < b.name[i])
                    return false;
            }

            if (a.name.Count() == b.name.Count())
                return true;

            if (a.name.Count() > b.name.Count())
                return true;
            else
                return false;
        }

        //<=
        public static bool operator <=(Car_Dealership a, Car_Dealership b)
        {
            if ((a < b) || (a == b))
                return true;

            else return false;
        }

        //>=
        public static bool operator >=(Car_Dealership a, Car_Dealership b)
        {
            if ((a > b) || (a == b))
                return true;

            else return false;
        }

        //Для строк

        //+
        public static Car_Dealership operator +(Car_Dealership a, Car_Dealership b)
        {
            return new Car_Dealership { name = a.name + ", " + b.name, adr = a.adr };
        }

        //+= вызывает +

    }
}
