using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная1_Вариант_9_
{
    class Table
    {
        int MaxElements;
        int CurrentElements;
        List<Receipt> T;

        public Table()
        {
            T = new List<Receipt>();
            MaxElements = -1;
            Console.WriteLine("Введите максимальное число записей таблицы");
            MaxElements = Convert.ToInt32(Console.ReadLine());
            if (MaxElements <= 0)
            {
                Console.WriteLine("Не удалось создать таблицу. Максимальное количество элементов меньше либо равно нулю");
                throw new IndexOutOfRangeException();
            }
            CurrentElements = -1;
        }

        //Возвращает указатель(индекс) на начало массива 
        public Int32 begin()
        {
            if (CurrentElements == -1)
                return -1; // Таблица еще не создана 
            else
                return 0;
        }

        //Возвращает указатель(индекс) на первое свободное место в массиве 
        public Int32 end()
        {
            return CurrentElements + 1;
        }

        //Возвращает текущую длину таблицы
        public Int32 Length()
        {
            return CurrentElements + 1;
        }

        //Добавить элемент
        public void insert(Receipt R)
        {
            if (CurrentElements == MaxElements - 1)
            {
                Console.WriteLine("Достигнуто максимальное количество элементов таблицы");
                return;
            }

            if (CurrentElements == -1)
            {
                T = new List<Receipt>();
                T.Add(R);
                CurrentElements++;
            }
            else
            {
                T.Add(R);
                CurrentElements++;
            }


        }

        //Удалить элемент по индексу
        public void delete_ind(int ind)
        {
            if (CurrentElements == -1)
            {
                Console.WriteLine("Таблица пуста либо не создана");
                return;
            }
            if ((ind < 0) || (ind >= T.Count()))
            {
                Console.WriteLine("Не существует элемента с таким индексом");
                return;
            }
            else
            {
                T.RemoveAt(ind);
                CurrentElements--;
            }
        }

        //Очистить всю таблицу
        public void clear()
        {
            CurrentElements = -1;
            T.Clear();
        }

        //Удаление (удаляет все элементы, совпадающие с заданным. Возвращает количество удаленных элементов)
        public Int32 remote(Receipt P)
        {
            if (CurrentElements == -1)
            {
                Console.WriteLine("Таблица пуста либо не создана");
                return -1;
            }
            int cnt = 0;
            for (int i = 0; i < T.Count(); i++)
            {
                if (T[i].equal(P))
                {
                    cnt++;
                    T.RemoveAt(i);
                    CurrentElements--;
                    i--;
                }
            }
            return cnt;
        }


        //Поиск элемента по индексу
        public Receipt find_ind(Int32 ind)
        {
            if (CurrentElements == -1)
            {
                Console.WriteLine("Таблица пуста либо не создана");
                return null;
            }
            if ((ind < 0) || (ind >= T.Count()))
            {
                Console.WriteLine("Не существует элемента с таким индексом");
                return null;
            }

            for (int i = 0; i < T.Count(); i++)
            {
                if (i == ind)
                {
                    return T[i];
                }
            }

            Console.WriteLine("Не существует элемента с таким индексом");
            return null;
        }

        //Поиск элемента(Возвращает индекс первого элемента,  совпадающего с заданным. Если элемента нет, вернет -1)
        public Int32 find(Receipt P)
        {
            if (CurrentElements == -1)
            {
                Console.WriteLine("Таблица пуста либо не создана");
                return -1;
            }

            Int32 ind = -1;
            for (int i = 0; i < T.Count(); i++)
            {
                if (T[i].equal(P))
                    return i;
            }

            return ind;
        }

        //Поиск элемента по названию авто(Возвращает индекс первого элемента,  совпадающего с заданным. Если элемента нет, вернет -1)
        public Int32 find_name_auto(String P)
        {
            if (CurrentElements == -1)
            {
                Console.WriteLine("Таблица пуста либо не создана");
                return -1;
            }

            Int32 ind = -1;
            for (int i = 0; i < T.Count(); i++)
            {
                if (T[i].equal_Name(P))
                    return i;
            }

            return ind;
        }

        //Замена (Заменяет все вхождения элемента Old на элемент New . Возвращает количество замен)
        public Int32 replace(Receipt Old, Receipt New)
        {
            if (CurrentElements == -1)
            {
                Console.WriteLine("Таблица пуста либо не создана");
                return -1;
            }

            Int32 cmp = 0;

            for (int i = 0; i < T.Count(); i++)
            {
                if (T[i].equal(Old))
                {
                    cmp++;
                    T[i] = New;

                }
            }

            
            return cmp;
        }

        //Сортировка таблицы по названию машин 
        public void sort_name_car()
        {
            if (CurrentElements == -1)
            {
                Console.WriteLine("Таблица пуста либо не создана");
                return;
            }


            for (int i = 0; i <= CurrentElements; i++)
            {


                int min = i;
                for (int j = i + 1; j <= CurrentElements; j++)
                {
                    if (T[j].cmp_Name_Car_less(T[i]))
                    {
                        if (T[j].cmp_Name_Car_less(T[min]))
                            min = j;
                    }
                }

                var dummy = T[i];
                T[i] = T[min];
                T[min] = dummy;

            }


        }

        //Сортировка таблицы по цене машин 
        public void sort_price()
        {
            if (CurrentElements == -1)
            {
                Console.WriteLine("Таблица пуста либо не создана");
                return;
            }

            for (int i = 0; i <= CurrentElements; i++)
            {

                int min = i;
                for (int j = i + 1; j <= CurrentElements; j++)
                {
                    if (T[j].cmp_Price_less(T[i]))
                    {
                        if (T[j].cmp_Price_less(T[min]))
                            min = j;
                    }
                }

                var dummy = T[i];
                T[i] = T[min];
                T[min] = dummy;
            }

        }

        //Сортировка таблицы по дате выпуска авто
        public void sort_data_release()
        {
            if (CurrentElements == -1)
            {
                Console.WriteLine("Таблица пуста либо не создана");
                return;
            }

            for (int i = 0; i <= CurrentElements; i++)
            {

                int min = i;
                for (int j = i + 1; j <= CurrentElements; j++)
                {
                    if (T[j].cmp_Release_Date_less(T[i]))
                    {
                        if (T[j].cmp_Release_Date_less(T[min]))
                            min = j;
                    }
                }

                var dummy = T[i];
                T[i] = T[min];
                T[min] = dummy;
            }
        }

        //Сортировка таблицы по дате продажи авто
        public void sort_data_sale()
        {
            if (CurrentElements == -1)
            {
                Console.WriteLine("Таблица пуста либо не создана");
                return;
            }

            for (int i = 0; i <= CurrentElements; i++)
            {

                int min = i;
                for (int j = i + 1; j <= CurrentElements; j++)
                {
                    if (T[j].cmp_Sale_Date_less(T[i]))
                    {
                        if (T[j].cmp_Sale_Date_less(T[min]))
                            min = j;
                    }
                }

                var dummy = T[i];
                T[i] = T[min];
                T[min] = dummy;
            }
        }


        //Печать таблицы 
        public void print()
        {
            if (CurrentElements == -1)
            {
                Console.WriteLine("Таблица пуста либо не создана");
                return;
            }

            for (int i = 0; i <= CurrentElements; i++)
            {
                Console.Write("Квитаннция №  ");
                Console.WriteLine(i + 1);
                T[i].output();
            }
        }

        //Печать таблицы2 
        public void print2()
        {
            Console.Write("Марка Авто\t  Год выпуска  \tАвтоцентр  \tАдрес  \tПродавец \tНомер продавца \tДата продажи авто \tЦена продажи ");
            

            Console.WriteLine("");
            Console.WriteLine("");


            if (CurrentElements == -1)
            {
                Console.WriteLine("Таблица пуста либо не создана");
                return;
            }

            for (int i = 0; i <= CurrentElements; i++)
            {
                T[i].print();
            }
        }

        //Запись в файл
        public void writing_to_file()
        {
            try
            {
                String text = "";
                for (int i = 0; i < T.Count(); i++)
                {
                    text += T[i].GetText();
                    text += "\r\n";
                }

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
            String Name_Car = "";
            Int32[] Release_Date = new Int32[3];

            String Name_Dealership = "";
            String[] Address_Dealership = new String[4];

            String Name_Seller = "";
            Int64 Number_Seller = -1;

            Int32[] Date_Sale = new Int32[3];
            Double Price_Sale = -1;

            String tmp = "";
            int cmp = 0;
            int i = 0;
            while (i < fileText.Count())
            {
                if ((fileText[i] == '\r') || (fileText[i] == '\n'))
                {
                    i++;
                    cmp++;
                }
                tmp += fileText[i];

                if (cmp == 9)
                {
                    Receipt mr = new Receipt(Name_Car, Release_Date, Name_Dealership, Address_Dealership, Name_Seller, Number_Seller, Date_Sale, Price_Sale);
                    insert(mr);

                    Name_Car = "";
                    Release_Date = new Int32[3];

                    Name_Dealership = "";
                    Address_Dealership = new String[4];

                    Name_Seller = "";
                    Number_Seller = -1;

                    Date_Sale = new Int32[3];
                    Price_Sale = -1;

                    cmp = 0;
                    tmp = "";
                }
                

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
