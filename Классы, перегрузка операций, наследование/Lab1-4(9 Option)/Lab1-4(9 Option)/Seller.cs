using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_4_9_Option_
{
    //Класс продавцов
    class Seller
    {
        public String name; // Имя
        public Int64 number;// Телефон

        public Seller(){}

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

        //Ввод имени продавца
        public void input_Name()
        {
            Console.WriteLine("Введите имя продавца");
            name = Console.ReadLine();
            if (name == "")
                input_Name();
        }
        //Ввод номера продавца
        public void input_Number()
        {
            Console.WriteLine("Введите номер продавца");
            String nn = Console.ReadLine();
            number = Convert.ToInt64(nn);
            if ((nn == "") || (number <= 0))
                input_Number();
        }
        //Ввод 
        public void input()
        {
            input_Name();
            input_Number();
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
            return new Seller { name = a.name + ", " + b.name, number = a.number};
        }

        //+= вызывает +     
    }

    //Класс проданных машин продавцом
    class Cars_Sold : Seller
    {

        List<Car> CarsSold; // Список проданных продавцом машин

        public Cars_Sold(String name, Int64 number, List<Car> LC)
            : base(name, number)
        {
            CarsSold = new List<Car>();
            for (int i = 0; i < LC.Count(); i++)
                CarsSold.Add(LC[i]);
        }

        public Cars_Sold(String name, Int64 number)
            : base(name, number)
        {
            CarsSold = new List<Car>();
        }

        public Cars_Sold(Seller s)
        {
            CarsSold = new List<Car>();
            name = s.GetName();
            number = s.GetNumber();
        }

        //Добавить машину в список проданных продавцом
        public void AddCar(Car C)
        {
            if (CarsSold == null)
            {
                CarsSold = new List<Car>();
                CarsSold.Add(C);
            }
            else
            {
                CarsSold.Add(C);
            }
        }

        //Получить число проданных машин
        public Int32 GetCountCarSold()
        {
            if (CarsSold == null)
                return 0;

            return CarsSold.Count();
        }

        //Вывести на экран проданные машины с их данными 
        public void Print()
        {
            Console.Write("Продавец  ");
            Console.Write(name);
            Console.WriteLine("  продал следующие машины: ");

            if (CarsSold == null)
            {
                Console.WriteLine(" Список пуст ");
                return;
            }

            for (int i = 0; i < CarsSold.Count(); i++)
            {
                Console.Write(i + 1);
                Console.Write("  ");
                Console.Write(CarsSold[i]);
                Console.WriteLine(" ");
            }
        }

        //Ввод
        public void input()
        {
            Console.Write("Введите сколько машин продал продавец ");
            Console.WriteLine(name);
            Int32 size = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                Car nc = new Car();
                nc.input();
                CarsSold.Add(nc);
            }

        }

        //Перегрузка вывода 
        public override string ToString()
        {

            String Rec = " ";

            Rec += "Продавец: ";
            Rec += name;
            Rec += "   продал следующие машины:  ";
            Rec += "\r\n";

            if (CarsSold == null)
            {
                Rec += " Список пуст ";
                return Rec;
            }
            else
            {
                for (int i = 0; i < CarsSold.Count(); i++)
                {
                    Rec += Convert.ToString(i + 1);
                    Rec += " ";
                    Rec += CarsSold[i];
                    Rec += ",  ";
                    Rec += "\r\n";
                }
            }
            
            return Rec;

        }

        //Поиск машины по названию
        public Car find(String Name)
        {
            for (int i = 0; i < CarsSold.Count(); i++)
            {
                if (CarsSold[i].GetName() == Name)
                    return CarsSold[i];
            }

            return null;
        }


    }
}
