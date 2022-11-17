using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_4_9_Option_
{
    //9.	Квитанция продажи автомобилей

    //В данной лабораторной продемонстрированы:
    // 1. Классы данных
    // 2. Перегрузка операций классов дата и строка
    // 3. Использование наследования

    class Program
    {
        public static Table TT;

        //Заполнение таблицы
        public static void test1()
        {
            //1
            Int32[] date = new Int32[3];
            date[0] = 27;
            date[1] = 2;
            date[2] = 2014;
            String Adr = "Нижегородская область, Нижний Новгород, Проспект Гагарина, 65Б";
            Int32[] date2 = new Int32[3];
            date2[0] = 5;
            date2[1] = 3;
            date2[2] = 2015;
            
            Date d1 = new Date(date);
            Date d2 = new Date(date2);
            Car c1 = new Car("Audi A3", d1, 784.8, d2);
            Seller s1 = new Seller("Алексей", 343513);
            Car_Dealership cd1 = new Car_Dealership("АвтоДромиум", Adr);

            //2
            Int32[] date3 = new Int32[3];
            date3[0] = 1;
            date3[1] = 2;
            date3[2] = 2020;
            String Adr2 = "Нижегородская область, Нижний Новгород, Комсомольское шоссе, 14А";
            Int32[] date4 = new Int32[3];
            date4[0] = 6;
            date4[1] = 5;
            date4[2] = 2022;

            Date d3 = new Date(date3);
            Date d4 = new Date(date4);
            Car c2 = new Car("Nissan Murano", d3,  4750, d4);
            Seller s2 = new Seller("Василий", 350548);
            Car_Dealership cd2 = new Car_Dealership("Nissan Нижегородец", Adr2);

            //3
            Int32[] date5 = new Int32[3];
            date5[0] = 10;
            date5[1] = 1;
            date5[2] = 2022;
            String Adr3 = "Нижегородская область, Нижний Новгород, Проспект Ленина, 93Д";
            Int32[] date6 = new Int32[3];
            date6[0] = 25;
            date6[1] = 4;
            date6[2] = 2022;

            Date d5 = new Date(date5);
            Date d6 = new Date(date6);
            Car c3 = new Car("Tiguan Urban Sport", d5, 4933.3, d5);
            Seller s3 = new Seller("Валерия", 200400);
            Car_Dealership cd3 = new Car_Dealership("АвтоКлаус центр", Adr3);

            //4
            Int32[] date7 = new Int32[3];
            date7[0] = 29;
            date7[1] = 7;
            date7[2] = 2021;
            String Adr4 = "Москва, Москва, Автозаводская улица, 23 (5)";
            Int32[] date8 = new Int32[3];
            date8[0] = 10;
            date8[1] = 5;
            date8[2] = 2022;

            Date d7 = new Date(date7);
            Date d8 = new Date(date8);
            Car c4 = new Car("Audi RS 5 Sportback", d7, 10687.65, d8);
            Seller s4 = new Seller("Ирина", 450997);
            Car_Dealership cd4 = new Car_Dealership("Audi Авилон", Adr4);

            //5
            Int32[] date9 = new Int32[3];
            date9[0] = 30;
            date9[1] = 11;
            date9[2] = 2016;
            String Adr5 = "Ленинградская область, Санкт-Петербург, улица Кузнецовская, 41";
            Int32[] date10 = new Int32[3];
            date10[0] = 28;
            date10[1] = 6;
            date10[2] = 2017;
            
            Date d9 = new Date(date9);
            Date d10 = new Date(date10);
            Car c5 = new Car("Audi A6", d9,  1900, d10);
            Seller s5 = new Seller("Ирина", 450997);
            Car_Dealership cd5 = new Car_Dealership("Ауди Центр Витебский", Adr5);

            //Рецепты 
            Receipt r1 = new Receipt(c1, s1, cd1);
            Receipt r2 = new Receipt(c2, s2, cd1);
            Receipt r3 = new Receipt(c3, s1, cd1);
            Receipt r4 = new Receipt(c4, s4, cd2);
            Receipt r5 = new Receipt(c5, s5, cd2);

            //Таблица рецептов
            TT = new Table();

            TT.Add(r1);
            TT.Add(r2);
            TT.Add(r3);
            TT.Add(r4);
            TT.Add(r5);

        }

        //Готовая запись для вставки
        public static void test2()
        {
            //1
            Int32[] date = new Int32[3];
            date[0] = 8;
            date[1] = 12;
            date[2] = 2010;
            String Adr = "Нижегородская область, Нижний Новгород, Проспект Гагарина, 65Б";
            Int32[] date2 = new Int32[3];
            date2[0] = 7;
            date2[1] = 7;
            date2[2] = 2017;
            Date d = new Date(date);
            Date dd = new Date(date2);
            Receipt kv1 = new Receipt("Audi A3", d, 389.76, dd,"Даниил", 765432, "АвтоДромиум", Adr);

            TT.Add(kv1);
        }

        //Новая запись для замены
        public static Receipt test3()
        {
            Int32[] date7 = new Int32[3];
            date7[0] = 29;
            date7[1] = 7;
            date7[2] = 2021;
            String Adr4 = "Москва, Москва, Автозаводская улица, 23 (5)";
            Int32[] date8 = new Int32[3];
            date8[0] = 10;
            date8[1] = 3;
            date8[2] = 2022;
            Date d1 = new Date(date7);
            Date d2 = new Date(date8);
            Receipt kv4 = new Receipt("Audi RS 2", d1, 3456.7, d2, "Ирина", 499997, "Авилон", Adr4);

            return kv4;
        }

        //Добавить запись в таблицу 
        public static void test4()
        {
            if (TT == null)
                test1();
            Console.WriteLine("");
            Console.WriteLine("<2> Добавить новую запись");
            Console.WriteLine("");

            Console.WriteLine("1. Ввести свою запись;  2. Добавить готовую запись");
            String str2 = Console.ReadLine();
            switch (str2)
            {
                case "1":
                    Receipt nr = new Receipt();
                    nr.input();
                    TT.Add(nr);
                    Console.WriteLine("Новая таблица: ");
                    Console.WriteLine(TT);
                    break;
                case "2":
                    test2();
                    Console.WriteLine("Новая таблица: ");
                    Console.WriteLine(TT);
                    break;

                default:
                    Console.WriteLine("Нет такого варианта ответа");
                    break;
            }

        }


        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("<1> Вывести записи таблицы");
            Console.WriteLine("<2> Добавить новую запись");
            Console.WriteLine("<3> Очистить таблицу");
            Console.WriteLine("<4> Отсортировать записи по названию машин");
            Console.WriteLine("<5> Отсортировать запись по цене машин");
            Console.WriteLine("<6> Отсортировать запись по дате выпуска машин");
            Console.WriteLine("<7> Вывести список машин проданных в конкретном автосалоне");
            Console.WriteLine("<8> Вывести список машин проданных конкретным работником"); 
            Console.WriteLine("<9> Вывести список работников конкретного автосалона");
            Console.WriteLine("<10> Сохранить в файл");
            Console.WriteLine("<11> Выход");
            Console.WriteLine("");
            Console.WriteLine("");


            Console.WriteLine("Введите действие с таблицей (только номер)");
            String str = Console.ReadLine();
            switch (str)
            {
                case "1":
                    if (TT == null)
                        test1();

                    Console.WriteLine(TT);

                    Main(args);
                    break;
                case "2":
                    test4();

                    Main(args);
                    break;
                case "3":
                    if (TT == null)
                        test1();
                    TT.clear();
                    Console.WriteLine(TT);

                    Main(args);
                    break;
                case "4":
                    if (TT == null)
                        test1();
                    TT.sort_name_car();
                    Console.WriteLine("");
                    Console.WriteLine("Таблица, отсортированная по названию автомобилей: ");
                    Console.WriteLine("");
                    Console.WriteLine(TT);

                    Main(args);
                    break;
                case "5":
                    if (TT == null)
                        test1();

                    TT.sort_price();
                    Console.WriteLine("");
                    Console.WriteLine("Таблица, отсортированная по цене автомобилей: ");
                    Console.WriteLine("");
                    Console.WriteLine(TT);

                    Main(args);
                    break;
                case "6":
                    if (TT == null)
                        test1();

                    TT.sort_data_release();
                    Console.WriteLine("");
                    Console.WriteLine("Таблица, отсортированная по дате выпуска автомобилей: ");
                    Console.WriteLine("");
                    Console.WriteLine(TT);

                    Main(args);
                    break;
                case "7":
                    if (TT == null)
                        test1();

                    Console.WriteLine("Список машин проданных в автосалоне");
                    Console.WriteLine("Введите название автосалона");
                    String CD_name = Console.ReadLine();

                    if (TT.Car_Dealership_exist(CD_name) == false)
                    {
                        Console.WriteLine("Нет такого автосалона");
                    }
                    else
                    {
                        Sold_Car_in_Dealership TS = new Sold_Car_in_Dealership(TT.GetDealership(CD_name));
                        TS = TT.sold_car_in_dialership(TT.GetDealership(CD_name));
                        Console.WriteLine(TS);
                    }

                    Main(args);
                    break;
                case "8":
                    if (TT == null)
                        test1();

                    Console.WriteLine("Список машин проданных конкретным работником");
                    Console.WriteLine("Введите имя работника");
                    String Sname = Console.ReadLine();

                    if (TT.Seller_exist(Sname) == false)
                        Console.WriteLine("Нет такого работника");
                    else
                    {
                        Cars_Sold CS = new Cars_Sold(TT.GetSeller(Sname));
                        CS = TT.sold_car_sellers(TT.GetSeller(Sname));
                        Console.WriteLine(CS);
                    }

                    Main(args);
                    break;
                case "9":
                    if (TT == null)
                        test1();

                    Console.WriteLine("Список работников конкретного автосалона");
                    Console.WriteLine("Введите название автосалона");
                    String CDname = Console.ReadLine();

                    if (TT.Car_Dealership_exist(CDname) == false)
                    {
                        Console.WriteLine("Нет такого автосалона");
                    }
                    else
                    {
                        Workers W = new Workers(TT.GetDealership(CDname));
                        W = TT.workers(TT.GetDealership(CDname));
                        Console.WriteLine(W);
                    }
                    
                    Main(args);
                    break;
                case "10":
                    if (TT == null)
                        test1();

                    Console.WriteLine("");
                    Console.WriteLine("<10> Сохранить в файл");
                    Console.WriteLine("");

                    TT.writing_to_file();
                    Console.WriteLine("Файл создается(записывается) в папке с .sln программы");
                    Main(args);
                    break;
               
                case "11":
                    System.Environment.Exit(56789);
                    return;


                default:
                    Console.WriteLine("Нет такого варианта ответа");
                    Main(args);
                    break;

            }


            Console.ReadKey(true);
        }
    }
}
