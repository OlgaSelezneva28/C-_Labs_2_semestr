using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_4_9_Option_
{
    class Table
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
                Rec += "  ";
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

            if ((index < 0) || (index > T.Count()))
                return null;

            return T[index];
        }

        /*---------------------------------------------------------------------------------*/

        //Сортировка таблицы по названию машин 
        public void sort_name_car()
        {
            if (T  == null)
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

        /*---------------------------------------------------------------------------------*/

        //Поиск рецептов по имени продавца(Возвращает список рецептов, где указан данный продавец)
        public Table Search_by_sellers_name(String n)
        {
            Table rez = new Table();

            if (T == null)
                return rez;

            for (int i = 0; i < T.Count(); i++)
            {
                if (T[i].S.name == n)
                    rez.Add(T[i]);
            }

                return rez;
        }

        //Поиск рецептов по названию автосалона(Возвращает список рецептов, где указан данный автосалон)
        public Table Search_by_car_dealership_name(String n)
        {
            Table rez = new Table();

            if (T == null)
                return rez;

            for (int i = 0; i < T.Count(); i++)
            {
                if (T[i].CD.name == n)
                    rez.Add(T[i]);
            }

            return rez;
        }


        //Наличие автосалона в таблице 
        public bool Car_Dealership_exist(String name)
        {
            if (T == null)
                return false; 

            for (int i = 0; i < T.Count(); i ++)
            {
                if (T[i].CD.name == name)
                    return true;
            }

            return false;
        }

        //Наличие продавца в таблице
        public bool Seller_exist(String name)
        {
            if (T == null)
                return false;

            for (int i = 0; i < T.Count(); i++)
            {
                if (T[i].S.name == name)
                    return true;
            }

            return false;
        }



        //Вернет список работников автосалона 
        public Workers workers(Car_Dealership cd)
        {

            Workers w = new Workers(cd);
            if (T == null)
                return w;

            for (int i = 0; i < T.Count(); i++)
            {
                if (T[i].CD.name == cd.name)
                    w.AddSeller(T[i].S);
            }

            return w;
        }

        //Вернет список проданных машин автосалоном 
        public Sold_Car_in_Dealership sold_car_in_dialership(Car_Dealership cd)
        {

            Sold_Car_in_Dealership w = new Sold_Car_in_Dealership(cd);
            if (T == null)
                return w;

            for (int i = 0; i < T.Count(); i++)
            {
                if (T[i].CD.name == cd.name)
                    w.AddCar(T[i].C);
            }

            return w;
        }

        //Вернет список проданных машин конкретным продавцом
        public Cars_Sold sold_car_sellers(Seller s)
        {
            Cars_Sold w = new Cars_Sold(s);
            if (T == null)
                return w;

            for (int i = 0; i < T.Count(); i++)
            {
                if (T[i].S.name == s.name)
                    w.AddCar(T[i].C);
            }

            return w;
        }


        //Вернет автосалон по названию если он есть 
        public Car_Dealership GetDealership(String name)
        {
            if (T == null)
                return null;

            for (int i = 0; i < T.Count(); i++)
            {
                if (T[i].CD.name == name)
                    return T[i].CD;
            }

            return null;
        }

        //Вернет работника по имени если он есть
        public Seller GetSeller(String name)
        {
            if (T == null)
                return null;

            for (int i = 0; i < T.Count(); i++)
            {
                if (T[i].S.name == name)
                    return T[i].S;
            }

            return null;
        }


        //Работа с файлами 

        //Получить тест 
        public String GetText()
        {
            if (T == null)
                return "";

            String Text = "\r\n";
            for (int i = 0; i < T.Count(); i++)
            {
                Text += "Машина: ";
                Text += T[i].C.GetName();
                Text += "\r\n";

                Text += "Создана: ";
                Text += Convert.ToString(T[i].C.date_release);
                Text += "\r\n";

                Text += "Продана: ";
                Text += Convert.ToString(T[i].C.date_sale);
                Text += "\r\n";

                Text += "За сумму(в $): ";
                Text += Convert.ToString(T[i].C.GetPrice());
                Text += "\r\n";

                Text += "Продавец: ";
                Text += T[i].S.name;
                Text += "\r\n";

                Text += "Номер телефона: ";
                Text += Convert.ToString(T[i].S.number);
                Text += "\r\n";

                Text += "Автосалон: ";
                Text += T[i].CD.name;
                Text += "\r\n";

                Text += "Адрес автосалона: ";
                Text += T[i].CD.adr;
                Text += "\r\n";

                Text += "\r\n";
            }

            return Text;
        }

        //Запись в файл
        public void writing_to_file()
        {
            try
            {
                String text = "";
                
                    text += GetText();
                    text += "\r\n";

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
    }
}
