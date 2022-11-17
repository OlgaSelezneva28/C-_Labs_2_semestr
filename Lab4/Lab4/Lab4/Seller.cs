using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    
    //Класс продавцов
     class Seller : InOut
    {
        public String name; // Имя
        public Int64 number;// Телефон

        public Seller() { }

        public Seller(String n, Int64 num)
        {
            name = n;
            number = num;
        }

        //Ввод
        public override void input()
        {
            Console.WriteLine("Введите имя продавца");
            name = Console.ReadLine();

            Console.WriteLine("Введите номер продавца");
            number = Convert.ToInt64(Console.ReadLine());
        }

        //Вывод
        public override void output()
        {
            String Rec = " ";

            Rec += "Продавец: ";
            Rec += name;

            Rec += " ( ";
            Rec += "Телефон: ";
            Rec += number;
            Rec += " ) ";
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
                Rec += "Имя продавца: ";
                Rec += name;
                Rec += " \r\n ";

                Rec += "Телефон продавца: ";
                Rec += number;
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

                    if (tmp.Contains("Имя продавца:"))
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

                    if (tmp.Contains("Телефон продавца:"))
                    {
                        tmp = "";
                        i++;
                        while (fileText[i] != '\r')
                        {
                            tmp += fileText[i];
                            i++;
                        }
                        number = Convert.ToInt64(tmp);
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

            Rec += " продавец: ";
            Rec += name;

            Rec += " телефон: ";
            Rec += number;
            Rec += " ";

            return Rec;

        }

        public override Obj copy()
        {
            return new Seller(this.name, this.number);
        }

        public override bool equal(Obj Dr)
        {
            Seller D = (Seller)Dr;
            if ((this.name == D.name) && (this.number == D.number))
                return true;
            else
                return false;
        }

        public override int cmp(Obj Dr)
        {
            //-1 >
            //0 =
            // 1 <
            Seller D = (Seller)Dr;

            if (this == D)
                return 0;

            if (this <= D)
                return 1;

            return -1;
        }

        public override String GetType()
        {
            return "Seller";
        }



        //
        public override bool Equals(object o)
        {
            if (o == null)
                return false;

            Seller D = (Seller)o;
            if ((this.name == D.name) && (this.number == D.number))
                return true;
            else
                return false;
        }
        //
        public override int GetHashCode()
        {
            return (int)number;
        }
        

        //Получить имя продавца 
        public String GetName()
        {
            return name;
        }

        //Получить номер продавца
        public Int64 GetNumber()
        {
            return number;
        }

        //Перегрузка операций 

        //!= 
        public static bool operator !=(Seller a, Seller b)
        {
            if ((a.name != b.name) || (a.number != b.number))
                return true;
            else
                return false;
        }

        //==
        public static bool operator ==(Seller a, Seller b)
        {
            if ((a.name == b.name) && (a.number == b.number))
                return true;
            else
                return false;
        }


        public static bool operator <(Seller a, Seller b)
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

        public static bool operator >(Seller a, Seller b)
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
        public static bool operator <=(Seller a, Seller b)
        {
            if ((a < b) || (a == b))
                return true;

            else return false;
        }

        //>=
        public static bool operator >=(Seller a, Seller b)
        {
            if ((a > b) || (a == b))
                return true;

            else return false;
        }

        //Для строк

        //+
        public static Seller operator +(Seller a, Seller b)
        {
            return new Seller { name = a.name + ", " + b.name, number = a.number };
        }

        //+= вызывает +     
    }
}
