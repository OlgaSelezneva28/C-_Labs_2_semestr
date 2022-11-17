using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    
     class Receipt : InOut
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

        public Receipt(String T, Int32[] DR, Double p, Int32[] DS, String ns, Int64 num, String nd, String Adr)
        {
            Date dr = new Date(DR);
            Date ds = new Date(DS);

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


        //Получить текст квитанции
        public String GetText()
        {
            String Rec = "";
            Rec += "Название автомобиля:";
            Rec += C.title;
            Rec += " \r\n ";

            Rec += "Год выпуска автомобиля:";
            Rec += C.date_release.ToString();
            Rec += " \r\n ";

            Rec += "Цена продажи автомобиля:";
            Rec += C.price.ToString();
            Rec += " $";
            Rec += "\r\n";

            Rec += "Дата продажи автомобиля:";
            Rec += C.date_sale.ToString();
            Rec += " \r\n ";

            Rec += "Имя продавца:";
            Rec += S.name;
            Rec += " \r\n ";

            Rec += "Телефон продавца:";
            Rec += S.number;
            Rec += " \r\n ";

            Rec += "Название автосалона:";
            Rec += CD.name;
            Rec += " \r\n ";

            Rec += "Адрес автосалона:";
            Rec += CD.adr;
            Rec += " \r\n ";

            
            return Rec;
        }

        //Ввод
        public override void input()
        {
            C = new Car();
            S = new Seller();
            CD = new Car_Dealership();

            C.input();
            S.input();
            CD.input();
        }

        //Вывод
        public override void output()
        {
            String Rec = "";

            Rec += C.ToString();
            Rec += " ";
            Rec += S.ToString();
            Rec += " ";
            Rec += CD.ToString();

            Console.WriteLine(Rec);
        }

        //Запись в файл
        public override void input(String f)
        {
            String FileAdr = "..\\..\\..\\";
            FileAdr += f;
            FileAdr += ".txt";

            try
            {
                String Rec = "";

                Rec = GetText();

                StreamWriter sw = new StreamWriter(FileAdr, false);
                sw.WriteLine(Rec);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Исключение: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Запись в файл завершена");
                Console.Write("Путь к файлу: ");
                FileInfo fileInf = new FileInfo(FileAdr);
                Console.Write(fileInf.DirectoryName);

            }
        }

        //Чтение из файла
        public override void output(String f)
        {
            String path = "..\\..\\..\\";
            path += f;
            path += ".txt";
            FileInfo fileInf = new FileInfo(path);



            if (fileInf.Exists)
            {
                String fileText = File.ReadAllText(path);

                if (fileText.Count() == 0)
                {
                    return;
                }

                //Запись значений в поля класса 
                String Name_Car = "";
                Int32[] Release_Date = new Int32[3];

                String Name_Dealership = "";
                String Address_Dealership = "";

                String Name_Seller = "";
                Int32 Number_Seller = -1;

                Int32[] Date_Sale = new Int32[3];
                Double Price_Sale = -1;

                String tmp = "";
                int cmp = 0;
                int i = 0;
                while ((i < fileText.Count()) && (cmp != 9))
                {
                    if ((fileText[i] == '\r') || (fileText[i] == '\n'))
                    {
                        i++;
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
                        while (fileText[i] != '\r')
                        {
                            tmp += fileText[i];
                            i++;
                        }
                        Address_Dealership = tmp;
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
                        Number_Seller = Convert.ToInt32(tmp);
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


                //Запись в поля
                C = new Car();
                S = new Seller();
                CD = new Car_Dealership();

                C.title = Name_Car;
                C.date_release.date = Release_Date;
                C.date_sale.date = Date_Sale;
                C.price = Price_Sale;

                S.name = Name_Seller;
                S.number = Number_Seller;

                CD.name = Name_Dealership;
                CD.adr = Address_Dealership;

            }
            else
            {
                throw new Exception("Файл не существует");
            }

        }



        //Obj
        public override string ToString()
        {
            String Rec = "";
            Rec += C.ToString();
            Rec += S.ToString();
            Rec += CD.ToString();

            return Rec;
        }

        public override Obj copy()
        {
            return new Receipt(this.C, this.S, this.CD);
        }

        public override bool equal(Obj Dr)
        {
            Receipt D = (Receipt)Dr;
            if ((this.C == D.C) && (this.S == D.S) && (this.CD == D.CD))
                return true;
            else
                return false;
        }

        public override int cmp(Obj Dr)
        {
            //-1 >
            //0 =
            // 1 <
            Receipt D = (Receipt)Dr;

            if (this == D)
                return 0;

            if (this <= D)
                return 1;

            return -1;
        }

        public override String GetType()
        {
            return "Receipt";
        }



        //
        public override bool Equals(object o)
        {
            if (o == null)
                return false;

            Receipt D = (Receipt)o;
            if ((this.C == D.C) && (this.S == D.S) && (this.CD == D.CD))
                return true;
            else
                return false;
        }
        //
        public override int GetHashCode()
        {
            return C.GetHashCode();
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
