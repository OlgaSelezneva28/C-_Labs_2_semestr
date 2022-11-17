using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_4_9_Option_
{
   
    class Receipt
    {
        //Поля 

        public Car C;
        public Seller S;
        public Car_Dealership CD;

        /// <summary>
        ///  Методы и функции 
        /// </summary>
        
        //Конструктор по умолчанию 
        public Receipt()
        {
            C = new Car(); 
            S = new Seller(); 
            CD = new Car_Dealership(); 
        }

        public Receipt(String T, Date dr, Double p, Date ds, String ns, Int64 num, String nd, String Adr)
        {
            C = new Car(T, dr, p, ds);
            S = new Seller(ns, num);
            CD = new Car_Dealership(nd, Adr);
        }

        public Receipt(Car c, Seller s, Car_Dealership cd)
        {
            C = new Car();
            S = new Seller();
            CD = new Car_Dealership();

            C = c;
            S = s;
            CD = cd;
        }

        // Ввод 
        public void input()
        {
            C = new Car();
            S = new Seller();
            CD = new Car_Dealership();

            C.input();
            S.input();
            CD.input();

        }
 
        //Перегрузка вывода 
        public override string ToString()
        {
            String Rec = "";
            Rec += C;
            Rec += S;
            Rec += CD;

            return Rec;
        }


        //Перегрузка операций 

        //!= 
        public static bool operator !=(Receipt a, Receipt b)
        {
            if ((a.C != b.C) || (a.S != b.S) || (a.CD != b.CD))
                return true;
            else
                return false;
        }

        //==
        public static bool operator ==(Receipt a, Receipt b)
        {
            if ((a.C == b.C) && (a.S == b.S) && (a.CD == b.CD))
                return true;
            else
                return false;
        }


        public static bool operator <(Receipt a, Receipt b)
        {

            if (a.C.price < b.C.price)
                return true;
            else 
                return false;
        }

        public static bool operator >(Receipt a, Receipt b)
        {
            if (a.C.price > b.C.price)
                return true;
            else
                return false;
        }

        //<=
        public static bool operator <=(Receipt a, Receipt b)
        {
            if (a.C.price <= b.C.price)
                return true;
            else
                return false;
        }

        //>=
        public static bool operator >=(Receipt a, Receipt b)
        {
            if (a.C.price >= b.C.price)
                return true;
            else
                return false;
        }

        
    }
}
