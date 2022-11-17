using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace Lab4
{
    
    //Класс, описывающий машину
     class Car : InOut
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

            if (!validate())
            {
                throw new Exception("Цена некорректна. Пожалуйста, исправьте");
            }
            if ((!date_release.validate()) || (!date_sale.validate()))
            {
                throw new Exception("Дата некорректна. Пожалуйста, исправьте");
            }
        }

        //Проверка корректности цены
        public bool validate()
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
                while (validate() == false)
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


        public String GetNameCar()
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

        //Ввод
        public override void input()
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

        //Вывод
        public override void output()
        {
            String Rec = "";

            Rec += title;

            Rec += date_release.ToString();

            Rec += ",  ";
            Rec += price;
            Rec += " $";

            Rec += date_sale.ToString();

            Rec += " ";
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

                Rec += "Название автомобиля:  ";
                Rec += title;
                Rec += " \r\n ";

                Rec += "Год выпуска автомобиля:  ";
                Rec += date_release.ToString();
                Rec += " \r\n ";

                Rec += "Дата продажи автомобиля: ";
                Rec += date_sale.ToString();
                Rec += " \r\n ";

                Rec += "Цена продажи автомобиля: ";
                Rec += price;
                Rec += " $";
                Rec += "\r\n";


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
                //Console.WriteLine(fileText);
                if (fileText.Count() == 0)
                {
                    Console.WriteLine("Файл пуст");
                    return;
                }

                //Запись значений в поля класса 
                String tmp = "";
                int cmp = 0;
                int i = 0;
                while ((i < fileText.Count()) && (cmp != 5))
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

                        title += tmp;
                        tmp = "";
                    }

                    Int32[] Release_Date = new Int32[3];
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

                        date_release = new Date(Release_Date);
                    }

                    Int32[] Date_Sale = new Int32[3];
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
                        date_sale = new Date(Date_Sale);
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
                        price = Convert.ToDouble(tmp);
                        tmp = "";
                    }

                    i++;
                }

            }
            else
            {
                throw new Exception("Файл не существует");
            }

        }



        //Obj
        public override string ToString()
        {
            String Rec = " ";
            Rec += "Авто ";
            Rec += title;

            Rec += "  создан: ";
            Rec += date_release.ToString();

            Rec += "  продан за: ";
            Rec += price;
            Rec += " $ ";

            Rec += "  ";
            Rec += date_sale.ToString();

            Rec += " ";
            return Rec;

        }

        public override Obj copy()
        {
            return new Car(this.title, this.date_release, this.price, this.date_sale);
        }

        public override bool equal(Obj Dr)
        {
            Car D = (Car)Dr;
            if ((this.title == D.title) && (this.price == D.price) && (this.date_release == D.date_release) && (this.date_sale == D.date_sale))
                return true;
            else
                return false;
        }

        public override int cmp(Obj Dr)
        {
            //-1 >
            //0 =
            // 1 <
            Car D = (Car)Dr;

            if (this == D)
                return 0;

            if (this <= D)
                return 1;

            return -1;
        }

        public override String GetType()
        {
            return "Car";
        }
       
        

        //
        public override bool Equals(object o)
        {
            if (o == null)
                return false;

            Car D = (Car)o;
            if ((title == D.title) && (price == D.price) && (date_release == D.date_release) && (date_sale == D.date_sale))
                return true;
            else
                return false;
        }
        //
        public override int GetHashCode()
        {
            return (int)price;
        }

        //Перегрузка операций 

        //!= 
        public static bool operator !=(Car a, Car b)
        {
            if ((a.title != b.title) || (a.price != b.price) || (a.date_release != b.date_release) || (a.date_sale != b.date_sale))
                return true;
            else
                return false;
        }

        //==
        public static bool operator ==(Car a, Car b)
        {
            if ((a.title == b.title) && (a.price == b.price) && (a.date_release == b.date_release) && (a.date_sale == b.date_sale))
                return true;
            else
                return false;
        }

        //<
        public static bool operator <(Car a, Car b)
        {
            return a.title.CompareTo(b.title) < 0;
        }

        //>
        public static bool operator >(Car a, Car b)
        {
            return b.title.CompareTo(a.title) < 0;
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
            return new Car { title = a.title + ", " + b.title, price = a.price + b.price };
        }

        //+= вызывает + 

    }
    
}
