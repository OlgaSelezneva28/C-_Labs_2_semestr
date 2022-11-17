using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
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
            String Adr = "Нижегородская область, Нижний Новгород, Проспект Гагарина, 65Б";
            Int32[] date2 = new Int32[3];
            date2[0] = 5;
            date2[1] = 3;
            date2[2] = 2015;
            Receipt kv1 = new Receipt("Audi A3",  date, 784.87, date2, "Алексей", 343513, "АвтоДромиум", Adr);
            //Console.WriteLine(kv1);

            //2
            Int32[] date3 = new Int32[3];
            date3[0] = 1;
            date3[1] = 2;
            date3[2] = 2020;
            String Adr2 =  "Нижегородская область, Нижний Новгород, Комсомольское шоссе, 14А";
            Int32[] date4 = new Int32[3];
            date4[0] = 6;
            date4[1] = 5;
            date4[2] = 2022;
            Receipt kv2 = new Receipt("Nissan Murano", date3, 4750, date4, "Василий", 350548, "Nissan Нижегородец", Adr2);
            //Console.WriteLine(kv2);

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
            Receipt kv3 = new Receipt("Tiguan Urban Sport", date5, 4933.3, date6, "Валерия", 200400, "АвтоКлаус центр", Adr3);
            //Console.WriteLine(kv2);

            //4
            Int32[] date7 = new Int32[3];
            date7[0] = 29;
            date7[1] = 7;
            date7[2] = 2021;
            String Adr4 =  "Москва, Москва, Автозаводская улица, 23 (5)";
            Int32[] date8 = new Int32[3];
            date8[0] = 10;
            date8[1] = 5;
            date8[2] = 2022;
            Receipt kv4 = new Receipt("Audi RS 5 Sportback", date7, 10687.65, date8, "Ирина", 450997, "Audi Авилон", Adr4);
            //Console.WriteLine(kv2);

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
            Receipt kv5 = new Receipt("Audi A6", date9, 1900, date10, "Екатерина", 88122106465, "Ауди Центр Витебский", Adr5);
            //Console.WriteLine(kv2);

            //Table
            TT = new Table();

            TT.Add(kv1);
            TT.Add(kv2);
            TT.Add(kv3);
            TT.Add(kv4);
            TT.Add(kv5);

        }

        //Готовая запись для вставки
        public static void test2()
        {
            //1
            Int32[] date = new Int32[3];
            date[0] = 8;
            date[1] = 12;
            date[2] = 2010;
            String Adr =  "Нижегородская область, Нижний Новгород, Проспект Гагарина, 65Б";
            Int32[] date2 = new Int32[3];
            date2[0] = 7;
            date2[1] = 7;
            date2[2] = 2017;
            Receipt kv1 = new Receipt("Audi A3", date, 389.76, date2, "Даниил", 765432, "АвтоДромиум", Adr);

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
            Receipt kv4 = new Receipt("Audi RS 2", date7, 3456.7, date8, "Ирина", 499997, "Авилон", Adr4);

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

                    Console.WriteLine(TT.ToString());
                    
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
                            TT.Add(nr);
                            Console.WriteLine("Новая таблица: ");
                            Console.WriteLine(TT.ToString());
                            break;
                        case "2":
                            test2();
                            Console.WriteLine("Новая таблица: ");
                            Console.WriteLine(TT.ToString());
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
                    TT.DeleteInd(num);
                    Console.WriteLine("Новая таблица: ");
                    Console.WriteLine(TT.ToString());
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
                    
                    while ((num2 >= TT.Count()) || (num2 <= 0))
                    {
                        Console.WriteLine("Не существует элемента с таким индексом. Введите номер записи заново");
                        num2 = Convert.ToInt32(Console.ReadLine()) - 1;
                    }

                    Console.WriteLine("1. Ввести свою запись;  2. Изменить на готовую запись");
                    String str3 = Console.ReadLine();
                    switch (str3)
                    {
                        case "1":
                            Receipt neww = new Receipt();
                            neww.input();

                            TT.Replace(num2, neww);
                            Console.WriteLine("Новая таблица: ");
                            Console.WriteLine(TT.ToString());
                            break;
                        case "2":
                            Receipt newww = new Receipt();
                            newww = test3();
                            TT.Replace(num2, newww);
                            Console.WriteLine("Новая таблица: ");
                            Console.WriteLine(TT.ToString());
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
                    Console.WriteLine(TT.ToString());
                    Main(args);
                    break;
                case "6":
                    if (TT == null)
                        test1();

                    TT.sort_price();
                    Console.WriteLine("");
                    Console.WriteLine("Таблица, отсортированная по цене автомобилей: ");
                    Console.WriteLine("");
                    Console.WriteLine(TT.ToString());
                    Main(args);
                    break;
                case "7":
                    if (TT == null)
                        test1();

                    TT.sort_data_release();
                    Console.WriteLine("");
                    Console.WriteLine("Таблица, отсортированная по дате выпуска автомобилей: ");
                    Console.WriteLine("");
                    Console.WriteLine(TT.ToString());
                    Main(args);
                    break;
                case "8":
                    if (TT == null)
                        test1();

                    TT.sort_data_sale();
                    Console.WriteLine("");
                    Console.WriteLine("Таблица, отсортированная по дате продажи автомобилей: ");
                    Console.WriteLine("");
                    Console.WriteLine(TT.ToString());
                    Main(args);
                    break;
                case "9":
                    if (TT == null)
                        test1();

                    Console.WriteLine("");
                    Console.WriteLine("<9> Найти запись");
                    Console.WriteLine("");

                    Console.WriteLine("Введите строку, которую слудует найти: ");
                    String str4 = Console.ReadLine();

                    Table TS = new Table();
                    TS = TT.Search(str4);
                    

                    Console.WriteLine("Записи, где встречается данная строка: ");
                    Console.WriteLine("");
                    Console.WriteLine(TS.ToString());

                    if (TS.Count() == 0)
                        Console.WriteLine("Данная строка не встретилась");
                    

                    Main(args);
                    break;
                case "10":
                    if (TT == null)
                        test1();

                    Console.WriteLine("");
                    Console.WriteLine("<10> Сохранить в файл");
                    Console.WriteLine("");

                    Console.WriteLine("Введите имя файла. Если такой файл уже существует, то он перезапишется");
                    String FileName = Console.ReadLine();

                    TT.input(FileName);
                    
                    Main(args);
                    break;
                case "11":

                    Console.WriteLine("");
                    Console.WriteLine("<11> Считать данные из файла");
                    Console.WriteLine("");

                    Console.WriteLine("Введите имя файла: ");
                    String FileName2 = Console.ReadLine();

                    if (TT == null)
                        TT = new Table();

                    TT.output(FileName2);
                    Console.WriteLine(TT.ToString());
                    

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
                    TT.clear();
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
