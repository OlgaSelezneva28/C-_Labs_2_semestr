using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    //Класс продавцов
    public class Seller
    {
        public String name; // Имя
        public Int64 number;// Телефон

        public Seller() { }

        public Seller(String n, Int64 num)
        {
            name = n;
            number = num;
        }

        //Перегрузка вывода 
        public override string ToString()
        {

            String Rec = " ";

            Rec += "Продавец: ";
            Rec += name;
            Rec += " ( ";

            Rec += "Телефон: ";
            Rec += number;
            Rec += " ) ";
            Rec += " ";

            return Rec;

        }

        

        //Получить имя продавца 
        public String GetName()
        {
            return name;
        }

        //Получить номер продавца
        public Int64 GetNumber()
        {
            return number;
        }

        //Перегрузка операций 

        //!= 
        public static bool operator !=(Seller a, Seller b)
        {
            if ((a.name != b.name) || (a.number != b.number))
                return true;
            else
                return false;
        }

        //==
        public static bool operator ==(Seller a, Seller b)
        {
            if ((a.name == b.name) && (a.number == b.number))
                return true;
            else
                return false;
        }


        public static bool operator <(Seller a, Seller b)
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

        public static bool operator >(Seller a, Seller b)
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
        public static bool operator <=(Seller a, Seller b)
        {
            if ((a < b) || (a == b))
                return true;

            else return false;
        }

        //>=
        public static bool operator >=(Seller a, Seller b)
        {
            if ((a > b) || (a == b))
                return true;

            else return false;
        }

        //Для строк

        //+
        public static Seller operator +(Seller a, Seller b)
        {
            return new Seller { name = a.name + ", " + b.name, number = a.number };
        }

        //+= вызывает +     
    }
}
