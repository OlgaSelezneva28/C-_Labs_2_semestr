using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    //Класс дат
     class Date : InOut
    {
        public Int32[] date;

        public Date()
        {
            date = new Int32[3];
        }

        public Date(Int32[] dd)
        {
            date = new Int32[3];
            for (int i = 0; i < 3; i++)
                date[i] = dd[i];
        }

        public Date(Date d2)
        {
            if (d2 == null)
                throw new Exception("Переданная дата пуста");
            date = new Int32[3];

            date = d2.date;
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


        //Ввод
        public override void input()
        {
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

                throw new Exception("Некорректно введена дата ");
            }

            if (validate() == false)
            {

                throw new Exception("Некорректно введена дата ");
            }
        }

        //Вывод
        public override void output()
        {
            String Rec = "";


            Rec += date[0].ToString();
            Rec += ".";
            if (date[1] < 10)
                Rec += "0";
            Rec += date[1].ToString();
            Rec += ".";
            Rec += date[2].ToString();

            Rec += "";

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
                String text = "";
                
                for (int i = 0; i < 3; i++)
                {
                    text += Convert.ToString(date[i]);
                    if (i != 2)
                        text += ".";
                }

                StreamWriter sw = new StreamWriter(FileAdr, false);
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
                date = new Int32[3];

                String tmp = "";
                int j = 0;
                for (int i = 0; i < fileText.Count(); i++)
                {
                    if (fileText[i] == '.')
                    {
                        date[j] = Convert.ToInt32(tmp);
                        tmp = "";
                        j++;
                    }
                    else
                        tmp += fileText[i];
                }
                if (j == 2)
                    date[j] = Convert.ToInt32(tmp);
                else
                {

                    throw new Exception("Некорректно введена дата ");
                }

                if (validate() == false)
                {

                    throw new Exception("Некорректно введена дата ");
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

            Rec += Convert.ToString(date[0]);
            Rec += ".";
            if (date[1] < 10)
                Rec += "0";
            Rec += Convert.ToString(date[1]);
            Rec += ".";
            Rec += Convert.ToString(date[2]);

            Rec += "";
            return Rec;

        }

        public override Obj copy()
        {
            Date DNew = new Date();
            for (int i = 0; i < date.Count(); i++)
                DNew.date[i] = date[i];
                return DNew;
        }

        public override bool equal(Obj Dr)
        {
            Date D = (Date)Dr;
            if (date == D.date)
                return true;
            else
                return false;
        }

        public override int cmp(Obj Dr)
        {
            //-1 >
            //0 =
            // 1 <
            Date D = (Date)Dr;

            if (this == D)
                return 0;

            if (this <= D)
                return 1;

            return -1;
        }

        public override String GetType()
        {
            return "Date";
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

            a.date[0]++;
            if (a.validate() == false)
                a.date[0]--;
            else
                return a;

            a.date[1]++;
            a.date[0] = 1;
            if (a.validate() == false)
            {
                a.date[1]--;
                a.date[0] = old_d;
            }
            else
                return a;

            a.date[2]++;
            a.date[1] = 1;
            a.date[1] = 1;

            return a;

        }

        //--
        public static Date operator --(Date a)
        {
            Int32 old_d = a.date[0];
            Int32 old_m = a.date[1];

            a.date[0]--;
            if (a.validate() == false)
                a.date[0]++;
            else
                return a;

            a.date[1]--;
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

            a.date[2]--;
            a.date[1] = 12;
            a.date[1] = 31;

            return a;
        }

        //
        public override bool Equals(object o)
        {
            if (o == null)
                return false;

            Date D = (Date)o;
            if (date == D.date)
                return true;
            else
                return false;
        }
         //
        public override int GetHashCode()
        {
            return date[2];
        }
    }

}
