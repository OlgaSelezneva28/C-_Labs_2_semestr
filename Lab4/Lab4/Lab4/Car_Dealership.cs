using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    
    //Класс автосалона
     class Car_Dealership : InOut
    {
        public String name; // Название 
        public String adr; //Адрес

        public Car_Dealership() { }

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


        //Ввод
        public override void input()
        {
            Console.WriteLine("Введите название автосалона");
            name = Console.ReadLine();

            Console.WriteLine("Введите адрес автосалона");
            adr = Console.ReadLine();
        }

        //Вывод
        public override void output()
        {
            String Rec = "";

            Rec += "Автосалон: ";
            Rec += name;
            Rec += " ";

            Rec += " по адресу: ";
            Rec += adr;
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
                String Rec = " ";

                Rec += "Автосалон: ";
                Rec += name;
                Rec += " \r\n ";

                Rec += " по адресу: ";
                Rec += adr;
                Rec += " \r\n ";


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
                while ((i < fileText.Count()) && (cmp != 3))
                {
                    if ((fileText[i] == '\r') || (fileText[i] == '\n'))
                    {
                        i++;
                        cmp++;
                    }
                    tmp += fileText[i];

                    if (tmp.Contains("Автосалон:"))
                    {
                        tmp = "";
                        i++;
                        while (fileText[i] != '\r')
                        {
                            tmp += fileText[i];
                            i++;
                        }
                        name = tmp;
                        tmp = "";
                    }

                    if (tmp.Contains("по адресу:"))
                    {
                        tmp = "";
                        i++;
                        while (fileText[i] != '\r')
                        {
                            tmp += fileText[i];
                            i++;
                        }
                        adr = tmp;
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

            String Rec = "";

            Rec += " автосалон: ";
            Rec += name;
            Rec += " ";

            Rec += " по адресу: ";
            Rec += adr;
            Rec += " ";


            return Rec;

        }

        public override Obj copy()
        {
            return new Car_Dealership(this.name, this.adr);
        }

        public override bool equal(Obj Dr)
        {
            Car_Dealership D = (Car_Dealership)Dr;
            if ((this.name == D.name) && (this.adr == D.adr))
                return true;
            else
                return false;
        }

        public override int cmp(Obj Dr)
        {
            //-1 >
            //0 =
            // 1 <
            Car_Dealership D = (Car_Dealership)Dr;

            if (this == D)
                return 0;

            if (this <= D)
                return 1;

            return -1;
        }

        public override String GetType()
        {
            return "Car_Dealership";
        }



        //
        public override bool Equals(object o)
        {
            if (o == null)
                return false;

            Car_Dealership D = (Car_Dealership)o;
            if ((this.name == D.name) && (this.adr == D.adr))
                return true;
            else
                return false;
        }
        //
        public override int GetHashCode()
        {
            return name.Count();
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

        //<
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

        //>
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
     
}
