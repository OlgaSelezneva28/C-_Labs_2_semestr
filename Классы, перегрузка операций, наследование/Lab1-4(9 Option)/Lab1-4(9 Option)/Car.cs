﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_4_9_Option_
{
    //Класс дат
    class Date
    {
        public Int32[] date;

        public Date()
        {
            date = new Int32[3];
        }

        public Date(Int32[] dd) 
        {
            date = new Int32[3];
            for (int i = 0; i < 3; i ++)
                date[i] = dd[i];
        }

        //Ввод
        public void input()
        {
            Console.WriteLine("Введите дату в формате дд.мм.гггг");
            String Date = Console.ReadLine();
            String tmp = "";
            int j = 0;
            for (int i = 0; i < Date.Count(); i++)
            {
                if (Date[i] == '.')
                {
                    date[j] = Convert.ToInt32(tmp);
                    tmp = "";
                    j++;
                }
                else
                    tmp += Date[i];
            }
            if (j == 2)
                date[j] = Convert.ToInt32(tmp);
            else
            {
                Console.WriteLine("Некорректно введены данные. Попробуйте еще раз");
                input();
            }

            while (validate() == false)
            {
                input();
            }
        }

         //Проверка корректности даты 
        public bool validate_Data(Int32[] Data)
        {
            try
            {

                if ((Data[1] == 1) || (Data[1] == 3) || (Data[1] == 5) || (Data[1] == 7) || (Data[1] == 8) || (Data[1] == 10) || (Data[1] == 12))
                {
                    if (Data[0] <= 0)
                        return false;
                    if (Data[0] >= 32)
                        return false;
                }
                else
                {
                    if (Data[1] != 2)
                    {
                        if (Data[0] <= 0)
                            return false;
                        if (Data[0] >= 31)
                            return false;
                    }
                    if (Data[1] == 2)
                    {
                        //Для високосного года 
                        if (Data[2] % 4 == 0)
                        {
                            if ((Data[2] % 400 != 0) && (Data[2] % 100 == 0))
                            {
                                //Невисокосный
                                if (Data[0] >= 29)
                                    return false;
                            }
                            else
                            {
                                //Високосный
                                if (Data[0] >= 30)
                                    return false;
                            }
                        }
                        else
                        {
                            //Невисокосный
                            if (Data[0] >= 29)
                                return false;
                        }
                    }

                }

                return true;

            }
            catch
            {
                //Console.WriteLine("Текущая дата пустая или введена некорректно");
                return false;
            }
        }
        //Проверка корректности
        public bool validate()
        {
                    if ((date[0] <= 0) || (date[0] >= 32))
                    {
                        //Console.WriteLine(" Некорректно введен день выпуска автомобиля");
                        return false;
                    }
                    if ((date[1] <= 0) || (date[1] >= 13))
                    {
                        //Console.WriteLine(" Некорректно введен месяц выпуска автомобиля");
                        return false;
                    }
                    if ((date[2] <= 1885) || (date[2] >= 2023))
                    {
                        //Console.WriteLine(" Некорректно введен год выпуска автомобиля");
                        return false;
                    }
                    if (validate_Data(date) == false)
                    {
                        //Console.WriteLine(" Некорректно введена дата");
                        return false;
                    }
                    return true;

        }

        //Перегрузка вывода 
        public override string ToString()
        {
            String Rec = " ";

            Rec += " (  ";
            Rec += date[0].ToString();
            Rec += ".";
            Rec += date[1].ToString();
            Rec += ".";
            Rec += date[2].ToString();
            Rec += " )  ";;

            Rec += " ";
            return Rec;

        }

        //Перегрузка операций

        //!= 
        public static bool operator !=(Date a, Date b)
        {
            if ((a.date[0] != b.date[0]) || (a.date[1] != b.date[1]) || (a.date[2] != b.date[2]))
                return true;
            else
                return false;
        }

        //==
        public static bool operator ==(Date a, Date b)
        {
            if ((a.date[0] == b.date[0]) || (a.date[1] == b.date[1]) || (a.date[2] == b.date[2]))
                return true;
            else
                return false;
        }

        // <=
        public static bool operator <=(Date a, Date b)
        {
            if (a.date[2] > b.date[2])
                return false;
            else
            {
                if (a.date[2] < b.date[2])
                    return true;
                else 
                {
                    if (a.date[1] > b.date[1])
                        return false;
                    else
                    {
                        if (a.date[1] < b.date[2])
                            return true;
                        else
                        {
                            if (a.date[0] > b.date[0])
                                return false;
                            else return true;
                        }
                    }
                }
            }
        }

        //>=
        public static bool operator >=(Date a, Date b)
        {
            if (a == b)
                return true;
            if (a <= b)
                return false;
            else
                return true;
        }

        
        //Для даты
        //++
        public static Date operator ++(Date a)
        {
            Int32 old_d = a.date[0];
            Int32 old_m = a.date[1];

            a.date[0] ++;
            if (a.validate() == false)
                a.date[0] --;
            else 
                return a; 

            a.date[1] ++;
            a.date[0] = 1;
            if (a.validate() == false)
            {
                a.date[1] --;
                a.date[0] = old_d;
            }
            else 
                return a;

            a.date[2] ++;
            a.date[1] = 1; 
            a.date[1] = 1;

                return a;

        }

        //--
        public static Date operator --(Date a)
        {
            Int32 old_d = a.date[0];
            Int32 old_m = a.date[1];

            a.date[0] --;
            if (a.validate() == false)
                a.date[0] ++;
            else 
                return a; 

            a.date[1] --;
            a.date[0] = 31;
            if (a.validate() == false)
            {
                a.date[0] = 30;
                if (a.validate() == false)
                {
                    a.date[0] = 29;
                    if (a.validate() == false)
                    {
                        a.date[0] = 28;
                        if (a.validate() == false)
                        {
                            a.date[0] = old_d;
                            a.date[1] = old_m;
                        }
                        else return a;
                    }
                    else 
                        return a;
                }
                else
                    return a;
            }
            else 
                return a;

            a.date[2] --;
            a.date[1] = 12; 
            a.date[1] = 31;

                return a;
        }
    }

    //Класс, описывающий машину
    class Car
    {
        public String title; //Название
        public Date date_release; // Дата создания
        public Double price; // Цена
        public Date date_sale; // Дата продажи

        public Car()
        {
            date_release = new Date();
            date_sale = new Date();
        }

        public Car(String T, Date dr, Double p, Date ds)
        {
            title = T;
            price = p;
            date_release = new Date();
            date_sale = new Date();

            date_release = dr;
            date_sale = ds;

            if ( !validate("Price_Auto"))
            {
                Console.WriteLine("Цена некорректна. Пожалуйста, исправьте");
            }
            if ((!date_release.validate()) || (!date_sale.validate()))
            {
                Console.WriteLine("Дата некорректна. Пожалуйста, исправьте");
            }
        }

        public String GetName()
        {
            return title;
        }

        public Double GetPrice()
        {
            return price;
        }

        public Date GetDataRelease()
        {
            return date_release;
        }

        public Date GetDataSale()
        {
            return date_sale;
        }

        //Проверка корректности цены
        public bool validate(String param)
        {
                    if (price <= 0)
                    {
                        Console.WriteLine(" Проверьте цену продажи автомобиля. Она не может быть меньше нуля");
                        return false;
                    }
                    if (price != Math.Round(price, 2))
                    {
                        Console.WriteLine(" Проверьте цену продажи автомобиля. После запятой не может быть более 2 цифр");
                        return false;
                    }

                    return true;
        }

        public void input_Name_Care()
        {
            Console.WriteLine("Введите название автомобиля");
            title = Console.ReadLine();
            if (title == "")
                input_Name_Care();
        }
        public void input_Release_Date()
        {
            Console.WriteLine("Введите дату создания");
            date_release.input();
        }
        public void input_Date_Sale()
        {
            Console.WriteLine("Введите дату продажи автомобиля");
            date_sale.input();
        }
        public void input_Price_Sale()
        {
            Console.WriteLine("Введите цену, за которую был продан автомобиль");
            try
            {
                price = Convert.ToDouble(Console.ReadLine());
                String parametr = "Price_Auto";
                while (validate(parametr) == false)
                {
                    input_Price_Sale();
                }
            }
            catch
            {
                Console.WriteLine(" Проверьте цену продажи автомобиля. Если цена дробная, то надо ввести копейки через ',' ");
                input_Price_Sale();
            }
        }

        //Ввод 
        public void input()
        {
            //
            input_Name_Care();

            //
            input_Release_Date();

           
            //
            input_Date_Sale();

            //
            input_Price_Sale();


        }
        
       
         //Перегрузка вывода 
        public override string ToString()
        {
            String Rec = " ";
            
            Rec += title;

            Rec += date_release;

            Rec += ",  ";
            Rec += price;
            Rec += " $";

            Rec += date_sale;

            Rec += " ";
            return Rec;

        }

        //Перегрузка операций 

        //!= 
        public static bool operator !=(Car a, Car b)
        {
            if ((a.title != b.title) || (a.price != b.price) || (a.date_release != b.date_release)  || (a.date_sale != b.date_sale))
                return true;
            else
                return false;
        }

        //==
        public static bool operator ==(Car a, Car b)
        {
            if ((a.title == b.title) && (a.price == b.price) && (a.date_release == b.date_release)  && (a.date_sale == b.date_sale))
                return true;
            else
                return false;
        }


        public static bool operator <(Car a, Car b)
        {

            for (int i = 0; i < Math.Min(a.title.Count(), b.title.Count()); i++)
            {
                if (a.title[i] < b.title[i])
                    return true;
                if (a.title[i] > b.title[i])
                    return false;
            }

            if (a.title.Count() == b.title.Count())
                return true;

            if (a.title.Count() < b.title.Count())
                return true;
            else
                return false;
        }

        public static bool operator >(Car a, Car b)
        {
            for (int i = 0; i < Math.Min(a.title.Count(), b.title.Count()); i++)
            {
                if (a.title[i] > b.title[i])
                    return true;
                if (a.title[i] < b.title[i])
                    return false;
            }

            if (a.title.Count() == b.title.Count())
                return true;

            if (a.title.Count() > b.title.Count())
                return true;
            else
                return false;
        }

        //<=
        public static bool operator <=(Car a, Car b)
        {
            if ((a < b) || (a == b))
                return true;
            
            else return false;
        }

        //>=
        public static bool operator >=(Car a, Car b)
        {
            if ((a > b) || (a == b))
                return true;
            
            else return false;
        }

        //Для строк
        
        //+
        public static Car operator +(Car a, Car b)
        {
            return new Car {title = a.title + ", " + b.title, price = a.price + b.price};
        }

        //+= вызывает + 
        
    }
}
