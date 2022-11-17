using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_4_9_Option_
{
    //Класс автосалона
    class Car_Dealership
    {
        public String name; // Название 
        public String adr; //Адрес

        public Car_Dealership(){ }

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

        //Ввод названия автосалона
        public void input_Name()
        {
            Console.WriteLine("Введите название автосалона");
            name = Console.ReadLine();
            if (name == "")
                input_Name();
        }
        //Ввод  адреса 
        public void input_Address()
        {
            Console.WriteLine("Введите адрес автосалона");
            String adr = Console.ReadLine();
            
            if (adr == "")
                input_Address();
        }
        //Ввод 
        public void input()
        {
            input_Name();
            input_Address();
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

    //Класс работников автосалона
    class Workers : Car_Dealership
    {

        public List<Seller> workers; // Список работников автосалона

        public Workers() 
        {
            input_Name();
            input_Address();
            workers = new List<Seller>();
        }

        public Workers(Car_Dealership cd)
        {
            workers = new List<Seller>();
            name = cd.GetName();
            adr = cd.GetAddress();
        }
        
        //Есть ли уже этот работник в списке
        public bool OnList(Seller S)
        {

            if (workers == null)
                return false;

            for (int i = 0; i < workers.Count(); i++)
            {
                if ((workers[i].name == S.name) && (workers[i].number == S.number))
                    return true;
            }

            return false;
        }

        //Добавить работника
        public void AddSeller(Seller S)
        {
            if (workers == null)
                workers = new List<Seller>();

            if (OnList(S))
                return; 

            workers.Add(S);
        }

        // Получить число работников 
        public Int32 GetCountSellers()
        {
            if (workers == null)
                return 0;

            return workers.Count();
        }

        // Вывести список работников с их номерами телефонов 
        public void Print()
        {
            Console.Write("В автосалоне  ");
            Console.Write(name);
            Console.WriteLine("  работают: ");

            if (workers == null)
            {
                Console.WriteLine(" Список пуст");
                return;
            }

            for (int i = 0; i < workers.Count(); i++)
            {
                Console.Write(i + 1);
                Console.Write("  ");
                Console.Write(workers[i]);
                Console.WriteLine(" ");
            }
        }

        //Ввод 
        public void input()
        {
            Console.Write("Введите число работников автосалона ");
            Console.WriteLine(name);
            Int32 size = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                Seller ns = new Seller();
                ns.input();
                workers.Add(ns);
            }
        }


        //Перегрузка вывода 
        public override string ToString()
        {

            String Rec = " В автосалоне ";
            Rec += name;
            Rec += "  работают следующие работники: ";
            Rec += "\r\n";

            if (workers == null)
            {
                Rec += " Список пуст ";
                return Rec;
            }
            else
            {
                for (int i = 0; i < workers.Count(); i++)
                {
                    Rec += Convert.ToString(i + 1);
                    Rec += " ";
                    Rec += workers[i];
                    Rec += ",  ";
                    Rec += "\r\n";
                }
            }

            return Rec;

        }

        //Поиск продавца по имени
        public Seller find(String Name)
        {
            for (int i = 0; i < workers.Count(); i++)
            {
                if (workers[i].GetName() == Name)
                    return workers[i];
            }

            return null;
        }

        //Добавить работников из таблицы



    }

    //Класс, отвечающий за проданные машины в автосалоне
    class Sold_Car_in_Dealership : Car_Dealership
    {
        public List<Car> LCS;

        public Sold_Car_in_Dealership()
        {
            LCS = new List<Car>();
            input_Name();
            input_Address();
        }

        public Sold_Car_in_Dealership(Car_Dealership D)
        {
            LCS = new List<Car>();
            name = D.GetName();
            adr = D.GetAddress();
        }

        public Int32 GetCountAuto()
        {
            if (LCS == null)
                return 0;

            return LCS.Count();
        }

        public void AddCar(Car C)
        {
            if (LCS == null)
            {
                LCS = new List<Car>();
                LCS.Add(C);
                return;
            }

            for (int i = 0; i < LCS.Count(); i++)
            {
                if (C == LCS[i])
                    return;
            }

                LCS.Add(C);
        }

        // Вывести список проданных машин
        public void Print()
        {
            Console.Write("В автосалоне  ");
            Console.Write(name);
            Console.WriteLine("  продали следующие машины: ");

            if (LCS == null)
            {
                Console.WriteLine(" Список пуст");
                return;
            }

            for (int i = 0; i < LCS.Count(); i++)
            {
                Console.Write(i + 1);
                Console.Write("  ");
                Console.Write(LCS[i]);
                Console.WriteLine(" ");
            }
        }

        //Ввод 
        public void input()
        {
            Console.Write("Введите число проданных машин автосалона ");
            Console.WriteLine(name);
            Int32 size = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                Car ns = new Car();
                ns.input();
                LCS.Add(ns);
            }
        }

        //Перегрузка вывода 
        public override string ToString()
        {

            String Rec = " В автосалоне ";
            Rec += name;
            Rec += "  были проданы следующие машины: ";
            Rec += "\r\n";

            if (LCS == null)
            {
                Rec += " Список пуст ";
                return Rec;
            }
            else
            {
                for (int i = 0; i < LCS.Count(); i++)
                {
                    Rec += Convert.ToString(i + 1);
                    Rec += " ";
                    Rec += LCS[i];
                    Rec += ",  ";
                    Rec += "\r\n";
                }
            }

            return Rec;

        }

        //Поиск машины по названию
        public Car find(String Name)
        {
            for (int i = 0; i < LCS.Count(); i++)
            {
                if (LCS[i].GetName() == Name)
                    return LCS[i];
            }

            return null;
        }

        //Добавить машины из таблицы 
        public void Add_from_Table(Table T)
        {
            if (T == null)
                return;

            for (int i = 0; i < T.Count(); i++)
            {
                if ((T.GetReceipt(i).CD.name == name) && (T.GetReceipt(i).CD.adr == adr))
                {
                    LCS.Add(T.GetReceipt(i).C);
                }
            }
        }

    }


}
