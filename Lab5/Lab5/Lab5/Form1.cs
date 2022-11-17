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
    public partial class Form1 : Form
    {
        public Table T; // Таблица рецептов


        public Form1()
        {
            InitializeComponent();

            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        //Очистить список
        private void button5_Click(object sender, EventArgs e)
        {
            T.clear();
            UpdateList();
        }

        //Проверка на пустоту полей 
        public bool EmptyFields()
        {
            
            if ((textBox1.Text.Length == 0) || (textBox2.Text.Length == 0) || (textBox3.Text.Length == 0) ||
                (textBox4.Text.Length == 0) || (textBox5.Text.Length == 0) || (textBox6.Text.Length == 0) ||
                (textBox7.Text.Length == 0) || (textBox8.Text.Length == 0) )
            {
                string message = "Поле ввода данных не заполнено";
                string caption = "Ошибка ввода";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                
                return true;
            }

            return false;
        }

        //Обновление отображения списка
        public void UpdateList()
        {
            listView1.Items.Clear();

            // добавляем элемент в ListView
            for (int i = 0; i < T.Count(); i++)
            {
                //Строка
                ListViewItem item = new ListViewItem(new string[] {T.GetReceipt(i).C.title, 
                    T.GetReceipt(i).C.date_release.ToString(), 
                    T.GetReceipt(i).C.price.ToString(), 
                    T.GetReceipt(i).C.date_sale.ToString(), 
                    T.GetReceipt(i).S.name, 
                    T.GetReceipt(i).S.number.ToString(), 
                    T.GetReceipt(i).CD.name, 
                    T.GetReceipt(i).CD.adr});
                
                listView1.Items.Add(item);
            }

                
        }

        //Считывание нового рецепта
        public Receipt GetReceipt()
        {
            if (!EmptyFields())
            {

                    String NC = textBox1.Text;
                    Double NP = Convert.ToDouble(textBox4.Text);

                    if (NP <= 0)
                        throw new Exception("Неверно введена цена");

                    String NCD = textBox5.Text;
                    String Adr = textBox6.Text;

                    String NS = textBox7.Text;
                    Int32 Num = Convert.ToInt32(textBox8.Text);

                    if (Num <= 0)
                        throw new Exception("Неверно введен номер телефона");


                    Date DR = new Date();
                    Date DS = new Date();

                    String d1 = textBox2.Text;
                    String d2 = textBox3.Text;

                    DR.input(d1);
                    DS.input(d2);

                    Car NCar = new Car(NC, DR, NP, DS);
                    Car_Dealership NCDealersip = new Car_Dealership(NCD, Adr);
                    Seller NSeller = new Seller(NS, Num);

                    Receipt NR = new Receipt(NCar, NSeller, NCDealersip);

                    return NR;
                
            }
            return null;
        }

        //Добавить рецепт в таблицу
        private void button1_Click(object sender, EventArgs e)
        {
            Receipt NR = new Receipt();

            if (!EmptyFields())
            {
                try
                {
                    NR = GetReceipt();

                    if (T == null)
                        T = new Table();

                    T.Add(NR);
                }
                catch
                {
                    string message = "Данные введены неверно";
                    string caption = "Ошибка ввода";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                }


                
                UpdateList();
            }

        }

        //Удалить выбранные элементы
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                Int32 index = item.Index;
                listView1.Items.Remove(item);
                T.DeleteReceipt(T.GetReceipt(index));
            }
        }

        Form2 f2;

        //Найти
        private void button3_Click(object sender, EventArgs e)
        {
            f2 = new Form2(T);
            f2.Show();

        }

        public bool zamena = false;
        //Заменить
        private void button4_Click(object sender, EventArgs e)
        {
            if (zamena == false)
            {
                string message = "Выделите запись, которую хотите изменить. После чего введите в поля ввода новые данные. Нажмите кнопку 'Заменить' ";
                string caption = "Редактирование данных";
                DialogResult result;
                result = MessageBox.Show(message, caption);

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";

                zamena = true;
                return;
            }

            if (zamena == true)
            {

                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    Int32 index = item.Index;

                    Receipt NR = new Receipt();

                    if (!EmptyFields())
                    {
                        try
                        {
                            NR = GetReceipt();

                        }
                        catch
                        {
                            string message2 = "Данные введены неверно";
                            string caption2 = "Ошибка ввода";
                            MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                            DialogResult result2;
                            result2 = MessageBox.Show(message2, caption2, buttons2);

                            return;
                        }
                    }

                    //Замена 
                    try
                    {
                        T.Replace(index, NR);
                        UpdateList();
                    }
                    catch
                    {
                            string message2 = "Проверьте корректность данных";
                            string caption2 = "Ошибка ";
                            MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                            DialogResult result2;
                            result2 = MessageBox.Show(message2, caption2, buttons2);
                            return;
                    }
                }


            }

            
        }

        //Нажатие на запись и перенос данных в textbox
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                textBox1.Text = item.SubItems[0].Text;
                textBox2.Text = item.SubItems[1].Text;
                textBox3.Text = item.SubItems[3].Text;
                textBox4.Text = item.SubItems[2].Text;
                textBox5.Text = item.SubItems[6].Text;
                textBox6.Text = item.SubItems[7].Text;
                textBox7.Text = item.SubItems[4].Text;
                textBox8.Text = item.SubItems[5].Text;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //Создать
        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            T.clear();
            listView1.Items.Clear();
        }

        //Закрыть
        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void отсортироватьТаблицуПоНазваниюМашинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            T.sort_name_car();
            UpdateList();
        }

        private void отсортироватьТаблицуПоДатеВыпускаМашинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            T.sort_data_release();
            UpdateList();
        }

        private void отсортироватьТаблицуПоЦенеМашинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            T.sort_price();
            UpdateList();
        }

        private void отсортироватьТаблицуПоДатеПродажиМашинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            T.sort_data_sale();
            UpdateList();
        }

        //Открыть
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            String filename = openFileDialog1.FileName;
            // читаем файл в строку
            String fileText = System.IO.File.ReadAllText(filename);

            if (T == null)
                T = new Table();

            T.reading_from_file(fileText);
            UpdateList();
        }

        //Сохранить
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            // получаем выбранный файл
            String filename = saveFileDialog1.FileName;

            // сохраняем текст в файл
            
            System.IO.File.WriteAllText(filename, T.GetText());
        }
    }
}
