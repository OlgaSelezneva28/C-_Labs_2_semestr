using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная1_Вариант_9_
{
    class Receipt
    {
        //Поля 

        //Название и дата выпуска автомобиля;
        public String Name_Car;
        public Int32[] Release_Date;

        //Название и адрес автосалона; 
        public String Name_Dealership;
        public String[] Address_Dealership;

        //Имя и телефон продавца;
        public String Name_Seller;
        public Int64 Number_Seller;

        //Дата и цена продажи.
        public Int32[] Date_Sale;
        public Double Price_Sale;

        /// <summary>
        ///  Методы и функции 
        /// </summary>

        //Конструктор по умолчанию 
        public Receipt()
        {
            Release_Date = new Int32[3];
            Address_Dealership = new String[4];
            Date_Sale = new Int32[3];

            /*
            Console.WriteLine("Необходимо ввести данные");
            Console.WriteLine("Хотите их ввести сейчас: да или нет");
            String str = Console.ReadLine();
            switch (str)
            {
                case "да":
                    input();
                    break;
                case "нет":
                    break;

                default:
                    Console.WriteLine("Нет такого варианта ответа");
                    break;
            }
            */
        }

        //Инициализирующий конструктор
        public Receipt(String name_car, Int32[] release_date, String name_dealership, String[] address_dealership, String name_seller, Int64 number_seller, Int32[] date_sale, Double price_sale)
        {
            Name_Car = name_car;

            Release_Date = new Int32[3]; // дд.мм.гггг
            Name_Dealership = name_dealership;
            Address_Dealership = new String[4]; //Регион, город, улица, дом
            for (int i = 0; i < 4; i++)
            {
                Address_Dealership[i] = address_dealership[i];
            }
            Name_Seller = name_seller;
            Number_Seller = number_seller;
            Date_Sale = new Int32[3]; // дд.мм.гггг
            Price_Sale = price_sale;

            for (int i = 0; i < 3; i++)
            {
                Release_Date[i] = release_date[i];
                Date_Sale[i] = date_sale[i];
            }



            if (!validate("Number_Seller") || !validate("Address") || !validate("Data_Release") || !validate("Data_Sale") || !validate("Price_Auto"))
            {
                Console.WriteLine("Запись некорректна. Пожалуйста, исправьте ошибки");
            }
        }

        //Конструктор копирования
        public Receipt(Receipt NRec)
        {
            Name_Car = NRec.Name_Car;
            Release_Date = new Int32[3];
            Name_Dealership = NRec.Name_Dealership;
            Address_Dealership = new String[4]; //Регион, город, улица, дом
            for (int i = 0; i < 4; i++)
            {
                Address_Dealership[i] = NRec.Address_Dealership[i];
            }
            Name_Seller = NRec.Name_Seller;
            Number_Seller = NRec.Number_Seller;
            Date_Sale = new Int32[3];
            Price_Sale = NRec.Price_Sale;

            for (int i = 0; i < 3; i++)
            {
                Release_Date[i] = NRec.Release_Date[i];
                Date_Sale[i] = NRec.Date_Sale[i];
            }
        }

        //Создание копии Квитанции
        public Receipt copy()
        {
            Receipt Copy = new Receipt();

            Copy.Name_Car = Name_Car;
            Copy.Release_Date = new Int32[3];
            Copy.Name_Dealership = Name_Dealership;
            Copy.Address_Dealership = new String[4];
            for (int i = 0; i < 4; i++)
            {
                Copy.Address_Dealership[i] = Address_Dealership[i];
            }
            Copy.Name_Seller = Name_Seller;
            Copy.Number_Seller = Number_Seller;
            Copy.Date_Sale = new Int32[3];
            Copy.Price_Sale = Price_Sale;

            for (int i = 0; i < 3; i++)
            {
                Copy.Release_Date[i] = Release_Date[i];
                Copy.Date_Sale[i] = Date_Sale[i];
            }

            return Copy;
        }

        // Освобождение памяти 
        private bool disposed = false;
        public void dispose()
        {
            // освобождаем неуправляемые ресурсы
            dispose(true);
            // подавляем финализацию
            GC.SuppressFinalize(this);
        }
        protected virtual void dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                // Освобождаем управляемые ресурсы
            }
            // освобождаем неуправляемые объекты
            disposed = true;
        }
        // Деструктор
        ~Receipt()
        {
            dispose(false);
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
                Console.WriteLine("Текущая дата пустая или введена некорректно");
                return false;
            }
        }
        public bool validate(String param)
        {
            switch (param)
            {
                case "Number_Seller":
                    String CountNumber = Number_Seller.ToString();

                    if ((CountNumber.Length == 6) || (CountNumber.Length == 11))
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine(" Некорректно введен номер продавца. Введите его в формате 6 или 11 цифр");
                        return false;
                    }



                case "Address":
                    String[] Ad = new String[4];
                    for (int i = 0; i < Address_Dealership.Count(); i++)
                    {
                        if (Ad[i] == Address_Dealership[i])
                        {
                            Console.WriteLine(" Некорректно введен адрес автосалона. Введите его в формате регион, город, улица, дом");
                            return false;
                        }
                    }
                    return true;

                case "Data_Release":
                    if ((Release_Date[0] <= 0) || (Release_Date[0] >= 32))
                    {
                        Console.WriteLine(" Некорректно введен день выпуска автомобиля");
                        return false;
                    }
                    if ((Release_Date[1] <= 0) || (Release_Date[1] >= 13))
                    {
                        Console.WriteLine(" Некорректно введен месяц выпуска автомобиля");
                        return false;
                    }
                    if ((Release_Date[2] <= 1885) || (Release_Date[2] >= 2023))
                    {
                        Console.WriteLine(" Некорректно введен год выпуска автомобиля");
                        return false;
                    }
                    if (validate_Data(Release_Date) == false)
                    {
                        Console.WriteLine(" Некорректно введена дата");
                        return false;
                    }
                    return true;

                case "Data_Sale":
                    if ((Date_Sale[0] <= 0) || (Date_Sale[0] >= 32))
                    {
                        Console.WriteLine(" Некорректно введена дата продажи автомобиля");
                        return false;
                    }
                    if ((Date_Sale[1] <= 0) || (Date_Sale[1] >= 13))
                    {
                        Console.WriteLine(" Некорректно введен месяц продажи автомобиля");
                        return false;
                    }
                    if ((Date_Sale[2] <= 1885) || (Date_Sale[2] >= 2023))
                    {
                        Console.WriteLine(" Некорректно введен год продажи автомобиля");
                        return false;
                    }
                    if (Date_Sale[2] < Release_Date[2])
                    {
                        Console.WriteLine(" Некорректно введен год продажи автомобиля. Он не может быть продан раньше года создания");
                        return false;
                    }
                    if ((Date_Sale[2] == Release_Date[2]) && (Date_Sale[1] < Release_Date[1]))
                    {
                        Console.WriteLine(" Некорректно введен месяц продажи автомобиля. Он не может быть продан раньше своего создания");
                        return false;
                    }
                    if ((Date_Sale[2] == Release_Date[2]) && (Date_Sale[1] == Release_Date[1]) && (Date_Sale[0] < Release_Date[0]))
                    {
                        Console.WriteLine(" Некорректно введен день продажи автомобиля. Он не может быть продан раньше своего создания");
                        return false;
                    }
                    if (validate_Data(Date_Sale) == false)
                    {
                        Console.WriteLine(" Некорректно введена дата");
                        return false;
                    }
                    return true;

                case "Price_Auto":
                    if (Price_Sale <= 0)
                    {
                        Console.WriteLine(" Проверьте цену продажи автомобиля. Она не может быть меньше нуля");
                        return false;
                    }
                    if (Price_Sale != Math.Round(Price_Sale, 2))
                    {
                        Console.WriteLine(" Проверьте цену продажи автомобиля. После запятой не может быть более 2 цифр");
                        return false;
                    }

                    return true;



                default:
                    Console.WriteLine("Такого параметра проверки не существует");
                    return false;

            }
        }

        //функция, проверяющая равенство значений полей записей
        public bool equal(Receipt NRec)
        {
            if (Name_Car != NRec.Name_Car)
                return false;
            if (Name_Dealership != NRec.Name_Dealership)
                return false;
            if (Name_Seller != NRec.Name_Seller)
                return false;
            if (Number_Seller != NRec.Number_Seller)
                return false;
            if (Price_Sale != NRec.Price_Sale)
                return false;

            for (int i = 0; i < 3; i++)
            {
                if ((Release_Date[i] != NRec.Release_Date[i]) || (Date_Sale[i] != NRec.Date_Sale[i]) || (Address_Dealership[i] != NRec.Address_Dealership[i]))
                    return false;
            }
            if (Address_Dealership[3] != NRec.Address_Dealership[3])
                return false;

            return true;
        }

        public bool equal_Name(String Name)
        {
            if (Name == Name_Car)
                return true;
            else
                return false; 
        }

        //Используется при поиске

        //функции, сравнивающие записи. Используются при сортировке 
        //Сравнение по цене 
        public bool cmp_Price_less(Receipt NRec)
        {
            if (Price_Sale < NRec.Price_Sale)
                return true;
            else return false;
        }
        //Сравнение по дате выпуска авто 
        public bool cmp_Release_Date_less(Receipt NRec)
        {
            if (Release_Date[2] < NRec.Release_Date[2])
                return true;
            else
            {
                if (Release_Date[2] == NRec.Release_Date[2])
                {
                    if (Release_Date[1] < NRec.Release_Date[1])
                        return true;
                    else
                    {
                        if (Release_Date[1] == NRec.Release_Date[1])
                        {
                            if (Release_Date[0] < NRec.Release_Date[0])
                                return true;
                            else return false;
                        }
                        else return false;
                    }
                }
                else return false;
            }
        }
        //Сравнение по дате продажи авто 
        public bool cmp_Sale_Date_less(Receipt NRec)
        {
            if (Date_Sale[2] < NRec.Date_Sale[2])
                return true;
            else
            {
                if (Date_Sale[2] == NRec.Date_Sale[2])
                {
                    if (Date_Sale[1] < NRec.Date_Sale[1])
                        return true;
                    else
                    {
                        if (Date_Sale[1] == NRec.Date_Sale[1])
                        {
                            if (Date_Sale[0] < NRec.Date_Sale[0])
                                return true;
                            else return false;
                        }
                        else return false;
                    }
                }
                else return false;
            }
        }
        //Сравнение по названию машин
        public bool cmp_Name_Car_less(Receipt NRec)
        {
            //
            String str1 = Name_Car.ToLower();
            String str2 = NRec.Name_Car.ToLower();

            if (str1 == str2)
                return false;

            //
            if (Name_Car.Count() == NRec.Name_Car.Count())
            {
                for (int i = 0; i < Name_Car.Count(); i++)
                {

                    if (str1[i] < str2[i])
                        return true;
                    if ((str1[i] > str2[i]) && (str1[i] != str2[i]))
                        return false;
                    if ((str1[i] == str2[i]) && (i == str1.Count() - 1))
                        return false;
                }
            }

            //
            int size = Math.Min(Name_Car.Count(), NRec.Name_Car.Count());
            for (int i = 0; i < size; i++)
            {
                if (str1[i] < str2[i])
                    return true;
                if (str1[i] > str2[i])
                    return false;
                //Oбщая часть равна. Вернем правду если слово справа короче 
                if ((str1[i] == str2[i]) && (i == size - 1))
                {
                    if (str1.Count() < str2.Count())
                        return true;
                    else
                        return false;
                }

            }
            return false;

        }

        

        //Вывод квитанции 
        public void output()
        {


            if (!validate("Number_Seller") || !validate("Address") || !validate("Data_Release") || !validate("Data_Sale") || !validate("Price_Auto"))
            {
                Console.WriteLine("Запись некорректна. Пожалуйста, исправьте ошибки");
            }
            else
            {

                Console.WriteLine("-------------------------------------------------------------");
                Console.Write("Название автомобиля: ");
                Console.WriteLine(Name_Car);

                Console.WriteLine(" ");

                Console.Write("Дата выпуска автомобиля: ");
                Console.Write(Release_Date[0]);
                Console.Write(".");
                Console.Write(Release_Date[1]);
                Console.Write(".");
                Console.WriteLine(Release_Date[2]);

                Console.WriteLine(" ");

                Console.Write("Название автосалона: ");
                Console.WriteLine(Name_Dealership);

                Console.WriteLine(" ");

                Console.Write("Адрес автосалона: ");
                Console.Write(Address_Dealership[0]);
                Console.Write(",");
                Console.Write(Address_Dealership[1]);
                Console.Write(",");
                Console.Write(Address_Dealership[2]);
                Console.Write(",");
                Console.WriteLine(Address_Dealership[3]);

                Console.WriteLine(" ");

                Console.Write("Имя продавца: ");
                Console.WriteLine(Name_Seller);

                Console.WriteLine(" ");

                Console.Write("Телефон продавца: ");
                Console.WriteLine(Number_Seller);

                Console.WriteLine(" ");

                Console.Write("Дата продажи автомобиля: ");
                Console.Write(Date_Sale[0]);
                Console.Write(".");
                Console.Write(Date_Sale[1]);
                Console.Write(".");
                Console.WriteLine(Date_Sale[2]);

                Console.WriteLine(" ");

                Console.Write("Цена продажи автомобиля: ");
                Console.WriteLine(Price_Sale);

                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine(" ");
            }
        }

        //Вывод для таблицы
        public void print()
        {


            Console.WriteLine("");

            if (!validate("Number_Seller") || !validate("Address") || !validate("Data_Release") || !validate("Data_Sale") || !validate("Price_Auto"))
            {
                Console.WriteLine("Запись некорректна. Пожалуйста, исправьте ошибки");
            }
            else
            {
                Console.WriteLine("{0}      {1}.{2}.{3}        {4}        {5},{6},{7},{8}        {9}        {10}        {11}.{12}.{13}        {14}",
                    Name_Car, Release_Date[0], Release_Date[1], Release_Date[2], Name_Dealership,
                    Address_Dealership[0], Address_Dealership[1], Address_Dealership[2], Address_Dealership[3], Name_Seller, Number_Seller,
                    Date_Sale[0], Date_Sale[1], Date_Sale[2], Price_Sale);

                //"{0}\t{1}\t.\t{2}\t.\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}",
                Console.WriteLine("");
                
            }
            Console.WriteLine("");
        }

        //Ввод квитанции
        public void input_Name_Care()
        {
            Console.WriteLine("Введите название автомобиля");
            Name_Car = Console.ReadLine();
            if (Name_Car == "")
                input_Name_Care();
        }
        public void input_Release_Date()
        {
            String parametr = "Data_Release";
            Console.WriteLine("Введите дату выпуска автомобиля в формате дд.мм.гггг");
            String Date = Console.ReadLine();
            String tmp = "";
            int j = 0;
            for (int i = 0; i < Date.Count(); i++)
            {
                if (Date[i] == '.')
                {
                    Release_Date[j] = Convert.ToInt32(tmp);
                    tmp = "";
                    j++;
                }
                else
                    tmp += Date[i];
            }
            if (j == 2)
                Release_Date[j] = Convert.ToInt32(tmp);
            else
            {
                Console.WriteLine("Некорректно введены данные. Попробуйте еще раз");
                input_Release_Date();
            }

            while (validate(parametr) == false)
            {
                input_Release_Date();
            }
        }
        public void input_Name_Dealership()
        {
            Console.WriteLine("Введите название автосалона");
            Name_Dealership = Console.ReadLine();
            if (Name_Dealership == "")
                input_Name_Dealership();
        }
        public void input_Address_Dealership()
        {
            Console.WriteLine("Введите адрес автосалона в формате регион, город, улица, дом");
            String Date = "";
            Date = Console.ReadLine();

            String parametr = "Address";
            String tmp = "";
            int j = 0;
            for (int i = 0; i < Date.Count(); i++)
            {
                if (Date[i] == ',')
                {
                    Address_Dealership[j] = tmp;
                    tmp = "";
                    j++;
                }
                else
                    tmp += Date[i];
            }
            if (j == 3)
                Address_Dealership[j] = tmp;
            else
            {
                Console.WriteLine("Некорректно введены данные. Попробуйте еще раз");
                input_Address_Dealership();
            }

            while (validate(parametr) == false)
            {
                input_Address_Dealership();
            }
        }
        public void input_Name_Seller()
        {
            Console.WriteLine("Введите имя продавца");
            Name_Seller = Console.ReadLine();
            if (Name_Seller == "")
                input_Name_Seller();
        }
        public void input_Number_Seller()
        {
            Console.WriteLine("Введите номер телефона продавца 6 или 11 цифр");
            Number_Seller = Convert.ToInt64(Console.ReadLine());
            String parametr = "Number_Seller";
            while (validate(parametr) == false)
            {
                input_Number_Seller();
            }
        }
        public void input_Date_Sale()
        {
            Console.WriteLine("Введите дату продажи автомобиля в формате дд.мм.гггг");
            String Date = "";
            Date = Console.ReadLine();
            String parametr = "Data_Sale";
            String tmp = "";
            int j = 0;
            for (int i = 0; i < Date.Count(); i++)
            {
                if (Date[i] == '.')
                {
                    Date_Sale[j] = Convert.ToInt32(tmp);
                    tmp = "";
                    j++;
                }
                else
                    tmp += Date[i];
            }
            if (j == 2)
                Date_Sale[j] = Convert.ToInt32(tmp);
            else
            {
                Console.WriteLine("Некорректно введены данные. Попробуйте еще раз");
                input_Date_Sale();
            }

            while (validate(parametr) == false)
            {
                input_Date_Sale();
            }
        }
        public void input_Price_Sale()
        {
            Console.WriteLine("Введите цену, за которую был продан автомобиль");
            try
            {
                Price_Sale = Convert.ToDouble(Console.ReadLine());
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

        public void input()
        {
            //
            input_Name_Care();

            //
            input_Release_Date();

            //
            input_Name_Dealership();

            //
            input_Address_Dealership();

            //
            input_Name_Seller();

            //
            input_Number_Seller();

            //
            input_Date_Sale();

            //
            input_Price_Sale();


        }


        //Перегрузка вывода 
        public override string ToString()
        {
            if (!validate("Number_Seller") || !validate("Address") || !validate("Data_Release") || !validate("Data_Sale") || !validate("Price_Auto"))
            {
                Console.WriteLine("Запись некорректна. Пожалуйста, исправьте ошибки");
                return "";
            }
            else
            {
                String Rec = " ";
                Rec += "Название автомобиля:  ";
                Rec += Name_Car;
                Rec += " \r\n ";

                Rec += "Год выпуска автомобиля:  ";
                Rec += Release_Date[0].ToString();
                Rec += ".";
                Rec += Release_Date[1].ToString();
                Rec += ".";
                Rec += Release_Date[2].ToString();
                Rec += " \r\n ";

                Rec += "Название автосалона: ";
                Rec += Name_Dealership;
                Rec += " \r\n ";

                Rec += "Адрес автосалона: ";
                Rec += Address_Dealership[0];
                Rec += ",";
                Rec += Address_Dealership[1];
                Rec += ",";
                Rec += Address_Dealership[2];
                Rec += ",";
                Rec += Address_Dealership[3];
                Rec += " \r\n ";

                Rec += "Имя продавца: ";
                Rec += Name_Seller;
                Rec += " \r\n ";

                Rec += "Телефон продавца: ";
                Rec += Number_Seller;
                Rec += " \r\n ";

                Rec += "Дата продажи автомобиля: ";
                Rec += Date_Sale[0].ToString();
                Rec += ".";
                Rec += Date_Sale[1].ToString();
                Rec += ".";
                Rec += Date_Sale[2].ToString();
                Rec += " \r\n ";

                Rec += "Цена продажи автомобиля: ";
                Rec += Price_Sale;
                Rec += " $";
                Rec += "\r\n";

               
                return Rec;
            }
        }

        //Получить текст квитанции
        public String GetText()
        {
            String Rec = "";
            Rec += "Название автомобиля:  ";
            Rec += Name_Car;
            Rec += " \r\n ";

            Rec += "Год выпуска автомобиля:  ";
            Rec += Release_Date[0].ToString();
            Rec += ".";
            Rec += Release_Date[1].ToString();
            Rec += ".";
            Rec += Release_Date[2].ToString();
            Rec += " \r\n ";

            Rec += "Название автосалона: ";
            Rec += Name_Dealership;
            Rec += " \r\n ";

            Rec += "Адрес автосалона: ";
            Rec += Address_Dealership[0];
            Rec += ",";
            Rec += Address_Dealership[1];
            Rec += ",";
            Rec += Address_Dealership[2];
            Rec += ",";
            Rec += Address_Dealership[3];
            Rec += " \r\n ";

            Rec += "Имя продавца: ";
            Rec += Name_Seller;
            Rec += " \r\n ";

            Rec += "Телефон продавца: ";
            Rec += Number_Seller;
            Rec += " \r\n ";

            Rec += "Дата продажи автомобиля: ";
            Rec += Date_Sale[0].ToString();
            Rec += ".";
            Rec += Date_Sale[1].ToString();
            Rec += ".";
            Rec += Date_Sale[2].ToString();
            Rec += " \r\n ";

            Rec += "Цена продажи автомобиля: ";
            Rec += Price_Sale;
            Rec += " $";
            Rec += "\r\n";


            return Rec;
        }

        // запись в файл
        public void writing_to_file()
        {
            try
            {
                String text = "";
                text = GetText();

                StreamWriter sw = new StreamWriter("..\\..\\..\\1.txt");
                sw.WriteLine(text);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Исключение: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Запись в файл завершена");
            }

        }
 
        // чтение из файла
        public void reading_from_file()
        {
            String path = "..\\..\\..\\1.txt";
            String fileText = File.ReadAllText(path);
            //Console.WriteLine(fileText);
            if (fileText.Count() == 0)
            {
                Console.WriteLine("Файл пуст");
                return;
            }

            //Запись значений в поля класса 
            Name_Car = "";
            Release_Date = new Int32[3];

            Name_Dealership = "";
            Address_Dealership = new  String[4];

            Name_Seller = "";
            Number_Seller = -1;

            Date_Sale = new Int32[3];
            Price_Sale = -1;

            String tmp = "";
            int cmp = 0;
            int i = 0; 
            while ((i < fileText.Count()) && (cmp != 9))
            {
                if ((fileText[i] == '\r') || (fileText[i] == '\n'))
                {
                    i ++;
                    cmp++;
                }
                tmp += fileText[i];

                if (tmp.Contains("Название автомобиля:"))
                {
                    tmp = "";
                    i++;
                    while (fileText[i] != '\r')
                    {
                        tmp += fileText[i];
                        i++;
                    }
                
                    Name_Car += tmp;
                    tmp = "";
                }

                if (tmp.Contains("Год выпуска автомобиля:"))
                {
                    tmp = "";
                    i++;
                
                    int k = 0; 
                    while (fileText[i] != '\r')
                    {
                        if (fileText[i] == '.')
                        {
                            Release_Date[k] = Convert.ToInt32(tmp);
                            tmp = "";
                            k++;
                            i++;
                        }
                        tmp += fileText[i];
                        i++;
                    }

                    Release_Date[k] = Convert.ToInt32(tmp);
                    tmp = "";
                }

                if (tmp.Contains("Название автосалона:"))
                {
                    tmp = "";
                    i++;
                    while (fileText[i] != '\r')
                    {
                        tmp += fileText[i];
                        i++;
                    }
                    Name_Dealership = tmp;
                    tmp = "";
                }


                if (tmp.Contains("Адрес автосалона:"))
                {
                    tmp = "";
                    i++;
                    int k = 0; 
                    while (fileText[i] != '\r')
                    {
                        if (fileText[i] == ',')
                        {
                            Address_Dealership[k] = tmp;
                            tmp = "";
                            k++;
                            i++; 
                        }
                        tmp += fileText[i];
                        i++;
                    }
                    Address_Dealership[k] = tmp;
                    tmp = "";
                }

                if (tmp.Contains("Имя продавца:"))
                {
                    tmp = "";
                    i++;
                    while (fileText[i] != '\r')
                    {
                        tmp += fileText[i];
                        i++;
                    }
                    Name_Seller = tmp;
                    tmp = "";
                }

                if (tmp.Contains("Телефон продавца:"))
                {
                    tmp = "";
                    i++;
                    while (fileText[i] != '\r')
                    {
                        tmp += fileText[i];
                        i++;
                    }
                    Number_Seller = Convert.ToInt64(tmp);
                    tmp = "";
                }

                if (tmp.Contains("Дата продажи автомобиля:"))
                {
                    tmp = "";
                    i++; 
                    int k = 0;
                    while (fileText[i] != '\r')
                    {
                        if (fileText[i] == '.')
                        {
                            Date_Sale[k] = Convert.ToInt32(tmp);
                            tmp = "";
                            k++;
                            i++;
                        }
                        tmp += fileText[i];
                        i++;
                    }

                    Date_Sale[k] = Convert.ToInt32(tmp);
                    tmp = "";
                }

                if (tmp.Contains("Цена продажи автомобиля:"))
                {
                    tmp = "";
                    i++;
                    while (fileText[i] != '$')
                    {
                        tmp += fileText[i];
                        i++;
                    }
                    Price_Sale = Convert.ToDouble(tmp);
                    tmp = "";
                }

                i++;
            }

        }
    }
}
