using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Table
    {

        List<Receipt> T; // Список квитанций 


        public Table()
        {
            T = new List<Receipt>();

        }


        //Добавить Квитанцию
        public void Add(Receipt R)
        {
            if (T == null)
                T = new List<Receipt>();

            T.Add(R);
        }

        //Очистить всю таблицу
        public void clear()
        {
            T.Clear();
        }


        //Перегрузка вывода 
        public override string ToString()
        {

            String Rec = "";

            for (int i = 0; i < T.Count(); i++)
            {
                Rec += i + 1;
                Rec += " ";
                Rec += T[i];
                Rec += "\r\n";
            }

            return Rec;

        }

        //Возвращает число записей таблицы
        public Int32 Count()
        {
            return T.Count();
        }

        //Возвращает рецепт по индексу
        public Receipt GetReceipt(int index)
        {
            if (T == null)
                return null;

            if ((index < 0) || (index >= T.Count()))
                return null;

            return T[index];
        }

        /*---------------------------------------------------------------------------------*/

        //Сортировка таблицы по названию машин 
        public void sort_name_car()
        {
            if (T == null)
            {
                Console.WriteLine("Таблица пуста либо не создана");
                return;
            }

            for (int i = 0; i < T.Count(); i++)
            {

                int min = i;
                for (int j = i + 1; j < T.Count(); j++)
                {

                    if (T[j].C < T[i].C)
                    {
                        if (T[j].C < T[min].C)
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
            if (T == null)
            {
                Console.WriteLine("Таблица пуста либо не создана");
                return;
            }

            for (int i = 0; i < T.Count(); i++)
            {

                int min = i;
                for (int j = i + 1; j < T.Count(); j++)
                {
                    if (T[j] < T[i])
                    {
                        if (T[j] < T[min])
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
            if (T == null)
            {
                Console.WriteLine("Таблица пуста либо не создана");
                return;
            }

            for (int i = 0; i < T.Count(); i++)
            {

                int min = i;
                for (int j = i + 1; j < T.Count(); j++)
                {
                    if (T[j].C.date_release <= T[i].C.date_release)
                    {
                        if (T[j].C.date_release <= T[min].C.date_release)
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
            if (T == null)
            {
                Console.WriteLine("Таблица пуста либо не создана");
                return;
            }

            for (int i = 0; i < T.Count(); i++)
            {

                int min = i;
                for (int j = i + 1; j < T.Count(); j++)
                {
                    if (T[j].C.date_sale <= T[i].C.date_sale)
                    {
                        if (T[j].C.date_sale <= T[min].C.date_sale)
                            min = j;
                    }
                }

                var dummy = T[i];
                T[i] = T[min];
                T[min] = dummy;
            }
        }

        /*---------------------------------------------------------------------------------*/
       
        //Общий поиск. Возвращает все рецепты где встретилось n. Как строка так и подстрока
        public Table Search(String n)
        {
            if (T == null)
                return null;

            Table Rez = new Table();

            for (int i = 0; i < T.Count(); i++)
            {
                if ((T[i].C.title == n) ||
                    (Convert.ToString(T[i].C.date_release) == n) ||
                    (Convert.ToString(T[i].C.price) == n) ||
                    (Convert.ToString(T[i].C.date_sale) == n) ||
                    (Convert.ToString(T[i].S.number) == n) ||
                    (T[i].S.name == n) ||
                    (T[i].CD.name == n) ||
                    (T[i].CD.adr == n) 
                    ||
                    (T[i].C.title.Contains(n)) ||
                    (Convert.ToString(T[i].C.date_release).Contains(n)) ||
                    (Convert.ToString(T[i].C.price).Contains(n)) ||
                    (Convert.ToString(T[i].C.date_sale).Contains(n)) ||
                    (Convert.ToString(T[i].S.number).Contains(n)) ||
                    (T[i].S.name.Contains(n)) ||
                    (T[i].CD.name.Contains(n)) ||
                    (T[i].CD.adr.Contains(n)))
                {
                    Rez.Add(T[i]);
                }
            }

            return Rez;
        }

        /*---------------------------------------------------------------------------------*/
        
        //Удаление 
        public void DeleteReceipt(Receipt r)
        {
            T.Remove(r);
        }

        /*---------------------------------------------------------------------------------*/

        //Замена по индексу на новый рецепт 
        public void Replace(Int32 index, Receipt neww)
        {
            if ((index < 0) || (index >= T.Count()))
                throw new Exception("Индекс за пределами поля");

            T[index] = neww;
        }

        //Получить тест 
        public String GetText()
        {
            if (T == null)
                return "";

            String text = "";
            for (int i = 0; i < T.Count(); i++)
            {
                text += T[i].GetText();
                text += "\r\n";
            }

            return text;
        }

        /*---------------------------------------------------------------------------------*/

        // чтение из файла
        public void reading_from_file(String fileText)
        {
            if (T == null)
                T = new List<Receipt>();

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
                    Date dr = new Date(Release_Date);
                    Date ds = new Date(Date_Sale);
                    Receipt mr = new Receipt(Name_Car, dr, Price_Sale, ds, Name_Seller, Number_Seller , Name_Dealership, Address_Dealership);
                    T.Add(mr);

                    Name_Car = "";
                    Release_Date = new Int32[3];

                    Name_Dealership = "";
                    Address_Dealership = "";

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
