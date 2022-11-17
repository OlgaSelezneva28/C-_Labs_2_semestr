using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная1_Вариант_9_
{
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
            String[] Adr = new String[4];
            Adr[0] = "Нижегородская область";
            Adr[1] = "Нижний Новгород";
            Adr[2] = "Проспект Гагарина ";
            Adr[3] = "65Б";
            Int32[] date2 = new Int32[3];
            date2[0] = 5;
            date2[1] = 3;
            date2[2] = 2015;
            Receipt kv1 = new Receipt("Audi A3", date, "АвтоДромиум", Adr, "Алексей", 343513, date2, 784.87);
            //Console.WriteLine(kv1);

            //2
            Int32[] date3 = new Int32[3];
            date3[0] = 1;
            date3[1] = 2;
            date3[2] = 2020;
            String[] Adr2 = new String[4];
            Adr2[0] = "Нижегородская область";
            Adr2[1] = "Нижний Новгород";
            Adr2[2] = "Комсомольское шоссе";
            Adr2[3] = "14А";
            Int32[] date4 = new Int32[3];
            date4[0] = 6;
            date4[1] = 5;
            date4[2] = 2022;
            Receipt kv2 = new Receipt("Nissan Murano", date3, "Nissan Нижегородец", Adr2, "Василий", 350548, date4, 4750);
            //Console.WriteLine(kv2);

            //3
            Int32[] date5 = new Int32[3];
            date5[0] = 10;
            date5[1] = 1;
            date5[2] = 2022;
            String[] Adr3 = new String[4];
            Adr3[0] = "Нижегородская область";
            Adr3[1] = "Нижний Новгород";
            Adr3[2] = "Проспект Ленина";
            Adr3[3] = "93Д";
            Int32[] date6 = new Int32[3];
            date6[0] = 25;
            date6[1] = 4;
            date6[2] = 2022;
            Receipt kv3 = new Receipt("Tiguan Urban Sport", date5, "АвтоКлаус центр", Adr3, "Валерия", 200400, date6, 4933.3);
            //Console.WriteLine(kv2);

            //4
            Int32[] date7 = new Int32[3];
            date7[0] = 29;
            date7[1] = 7;
            date7[2] = 2021;
            String[] Adr4 = new String[4];
            Adr4[0] = "Москва";
            Adr4[1] = "Москва";
            Adr4[2] = "Автозаводская улица";
            Adr4[3] = "23 (5)";
            Int32[] date8 = new Int32[3];
            date8[0] = 10;
            date8[1] = 5;
            date8[2] = 2022;
            Receipt kv4 = new Receipt("Audi RS 5 Sportback", date7, "Audi Авилон", Adr4, "Ирина", 450997, date8, 10687.65);
            //Console.WriteLine(kv2);

            //5
            Int32[] date9 = new Int32[3];
            date9[0] = 30;
            date9[1] = 11;
            date9[2] = 2016;
            String[] Adr5 = new String[4];
            Adr5[0] = "Ленинградская область";
            Adr5[1] = "Санкт-Петербург";
            Adr5[2] = "улица Кузнецовская";
            Adr5[3] = "41";
            Int32[] date10 = new Int32[3];
            date10[0] = 28;
            date10[1] = 6;
            date10[2] = 2017;
            Receipt kv5 = new Receipt("Audi A6", date9, "Ауди Центр Витебский", Adr5, "Екатерина", 88122106465, date10, 1900);
            //Console.WriteLine(kv2);

            //Table
            TT = new Table();

            TT.insert(kv1);
            TT.insert(kv2);
            TT.insert(kv3);
            TT.insert(kv4);
            TT.insert(kv5);

        }

        //Готовая запись для вставки
        public static void test2()
        {
            //1
            Int32[] date = new Int32[3];
            date[0] = 8;
            date[1] = 12;
            date[2] = 2010;
            String[] Adr = new String[4];
            Adr[0] = "Нижегородская область";
            Adr[1] = "Нижний Новгород";
            Adr[2] = "Проспект Гагарина ";
            Adr[3] = "65Б";
            Int32[] date2 = new Int32[3];
            date2[0] = 7;
            date2[1] = 7;
            date2[2] = 2017;
            Receipt kv1 = new Receipt("Audi A3", date, "АвтоДромиум", Adr, "Даниил", 765432, date2, 389.76);

            TT.insert(kv1);
        }

        //Новая запись для замены
        public static Receipt test3()
        {
            Int32[] date7 = new Int32[3];
            date7[0] = 29;
            date7[1] = 7;
            date7[2] = 2021;
            String[] Adr4 = new String[4];
            Adr4[0] = "Москва";
            Adr4[1] = "Москва";
            Adr4[2] = "Автозаводская улица";
            Adr4[3] = "23 (5)";
            Int32[] date8 = new Int32[3];
            date8[0] = 10;
            date8[1] = 3;
            date8[2] = 2022;
            Receipt kv4 = new Receipt("Audi RS 2", date7, "Авилон", Adr4, "Ирина", 499997, date8, 3456.7);

            return kv4;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("<1> Вывести записи");
            Console.WriteLine("<2> Добавить новую запись");
            Console.WriteLine("<3> Удалить запись");
            Console.WriteLine("<4> Изменить запись");
            Console.WriteLine("<5> Отсортировать записи по названию машин");
            Console.WriteLine("<6> Отсортировать запись по цене машин");
            Console.WriteLine("<7> Отсортировать запись по дате выпуска машин");
            Console.WriteLine("<8> Отсортировать запись по дате продажи машин");
            Console.WriteLine("<9> Найти запись");
            Console.WriteLine("<10> Сохранить в файл");
            Console.WriteLine("<11> Считать из файла");
            Console.WriteLine("<12> Очистить список");
            Console.WriteLine("<13> Выход");
            Console.WriteLine("");
            Console.WriteLine("");
            

            Console.WriteLine("Введите действие с таблицей (только номер)");
            String str = Console.ReadLine();
            switch (str)
            {
                case "1":
                    if (TT == null)
                        test1();
                    
                    TT.print2();
                    Main(args);
                    break;
                case "2":
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
                                TT.insert(nr);
                                Console.WriteLine("Новая таблица: ");
                                TT.print2();
                                break;
                            case "2":
                                test2();
                                Console.WriteLine("Новая таблица: ");
                                TT.print2();
                                break;

                            default:
                                Console.WriteLine("Нет такого варианта ответа");
                                break;
                        }
                        Main(args);
                    break;
                case "3":
                    if (TT == null)
                        test1();
                    Console.WriteLine("");
                    Console.WriteLine("<3> Удалить запись");
                    Console.WriteLine("");
                    Console.WriteLine("Введите порядковый номер записи, которую хотите удалить");
                    Int32 num = Convert.ToInt32(Console.ReadLine()) - 1;
                    TT.delete_ind(num);
                    Console.WriteLine("Новая таблица: ");
                    TT.print2();
                    Main(args);
                    break;
                case "4":
                    if (TT == null)
                        test1();
                    Console.WriteLine("");
                    Console.WriteLine("Изменить запись");
                    Console.WriteLine("");
                    Console.WriteLine("Введите порядковый номер записи, которую хотите изменить");
                    Int32 num2 = Convert.ToInt32(Console.ReadLine()) - 1;
                    Receipt old = new Receipt();
                    old = TT.find_ind(num2);
                    while (old == null)
                    {
                        Console.WriteLine("Не существует такого элемента");
                        old = new Receipt();
                        old = TT.find_ind(num2);
                    }

                    Console.WriteLine("1. Ввести свою запись;  2. Изменить на готовую запись");
                    String str3 = Console.ReadLine();
                        switch (str3)
                        {
                            case "1":
                                Receipt neww = new Receipt();
                                neww.input();
                                TT.replace(old, neww);
                                Console.WriteLine("Новая таблица: ");
                                TT.print2();
                                break;
                            case "2":
                                Receipt newww = new Receipt();
                                newww = test3();
                                TT.replace(old, newww);
                                Console.WriteLine("Новая таблица: ");
                                TT.print2();
                                break;

                            default:
                                Console.WriteLine("Нет такого варианта ответа");
                                break;
                        }
                        Main(args);

                    break;
                case "5":
                    if (TT == null)
                        test1();
                    TT.sort_name_car();
                    Console.WriteLine("");
                    Console.WriteLine("Таблица, отсортированная по названию автомобилей: ");
                    Console.WriteLine("");
                    TT.print2();
                    Main(args);
                    break;
                case "6":
                    if (TT == null)
                        test1();

                    TT.sort_price();
                    Console.WriteLine("");
                    Console.WriteLine("Таблица, отсортированная по цене автомобилей: ");
                    Console.WriteLine("");
                    TT.print2();
                    Main(args);
                    break;
                case "7":
                    if (TT == null)
                        test1();
                    
                    TT.sort_data_release();
                    Console.WriteLine("");
                    Console.WriteLine("Таблица, отсортированная по дате выпуска автомобилей: ");
                    Console.WriteLine("");
                    TT.print2();
                    Main(args);
                    break;
                case "8":
                    if (TT == null)
                        test1();

                    TT.sort_data_sale();
                   Console.WriteLine("");
                    Console.WriteLine("Таблица, отсортированная по дате продажи автомобилей: ");
                    Console.WriteLine("");
                    TT.print2();
                    Main(args);
                    break;
                case "9":
                    if (TT == null)
                        test1();
                    
                    Console.WriteLine("");
                    Console.WriteLine("<9> Найти запись");
                    Console.WriteLine("");

                    Console.WriteLine("1. Выполнить поиск по всем данным;    2. Выполнить поиск по названию автомобиля");
                    String str4 = Console.ReadLine();
                        switch (str4)
                        {
                            case "1":
                                Console.WriteLine("Введите полностью запись, которую надо найти");
                                Receipt n = new Receipt();
                                n.input();
                                Int32 index = TT.find(n);
                                if (index == -1)
                                    Console.WriteLine("Такого элемента нет");
                                else
                                    Console.WriteLine("Порядковый номер данного элемента:",  index + 1);
                                break;
                            case "2":
                                Console.WriteLine("Введите название автомобиля, который надо найти");
                                String str5 = Console.ReadLine();
                                Int32 index2 = TT.find_name_auto(str5);
                                if (index2 == -1)
                                    Console.WriteLine("Такого элемента нет");
                                else
                                    Console.Write("Порядковый номер данного элемента: ");
                                Console.WriteLine(index2 + 1);
                                break;

                            default:
                                Console.WriteLine("Нет такого варианта ответа");
                                break;
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
                    TT = new Table();
                    TT.reading_from_file();
                    TT.print2();

                    Main(args);
                    break;
                case "12":
                    if (TT == null)
                        test1();

                    TT.clear();
                    Console.WriteLine("Таблица очищена");
                    Main(args);
                    break;
                case "13":
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
