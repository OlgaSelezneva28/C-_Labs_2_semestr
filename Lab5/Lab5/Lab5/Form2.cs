using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        public Table TT; //Исходная = T 
        public Table T2; // Итоговая с поиском


        public Form2(Table T)
        {
            TT = new Table();
            TT = T;
            InitializeComponent();
        }

        //Обновление отображения списка
        public void UpdateList()
        {
            listView1.Items.Clear();

            // добавляем элемент в ListView
            for (int i = 0; i < T2.Count(); i++)
            {
                //Строка
                ListViewItem item = new ListViewItem(new string[] {T2.GetReceipt(i).C.title, 
                    T2.GetReceipt(i).C.date_release.ToString(), 
                    T2.GetReceipt(i).C.price.ToString(), 
                    T2.GetReceipt(i).C.date_sale.ToString(), 
                    T2.GetReceipt(i).S.name, 
                    T2.GetReceipt(i).S.number.ToString(), 
                    T2.GetReceipt(i).CD.name, 
                    T2.GetReceipt(i).CD.adr});

                listView1.Items.Add(item);
            }


        }

        //Поиск 
        private void button1_Click(object sender, EventArgs e)
        {
            String FindText = Convert.ToString(textBox1.Text);

            if (FindText == "")
                return;

            T2 = new Table();

            T2 = TT.Search(FindText);

            UpdateList();
        }
    }
}
