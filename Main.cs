using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.Linq;
using System.Data.SqlClient;


namespace ATM
{
    public partial class Main : Form
    {
        static string conStr = "Data Source=DESKTOP-M14TIR5\\SQLSERVER;Initial Catalog=atm;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        int ВыдачаID = 0;
        int ЧитательID = 0;
        public Main()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string conStr = "Data Source=DESKTOP-M14TIR5\\SQLSERVER;Initial Catalog=atm;Integrated Security=Truee";
            if (comboBox1.SelectedIndex == 0)
            {
                string sql = "Select * From [Выдача] Where [ID_читатель] Like N'%" + textBox1.Text + "%' ";
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(conStr);
                SqlDataAdapter ad = new SqlDataAdapter(sql, con);
                ad.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            if (comboBox1.SelectedIndex == 1)
            {
                var v = context.GetTable<Читатель>().Where(x => x.Фамилия.Contains(textBox1.Text));
                dataGridView1.DataSource = v.ToList();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.OK)
                {
                    Выдача DeliteВыдача = context.GetTable<Выдача>().OrderByDescending(x => x.ID).FirstOrDefault();
                    context.GetTable<Выдача>().DeleteOnSubmit(DeliteВыдача);
                    context.SubmitChanges();
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.OK)
                {
                    Читатель DeliteЧитатель = context.GetTable<Читатель>().OrderByDescending(x => x.ID_билета).FirstOrDefault();
                    context.GetTable<Читатель>().DeleteOnSubmit(DeliteЧитатель);
                    context.SubmitChanges();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label1.Text = "Поиск ID_читатель:";
                Table<Выдача> gender = context.GetTable<Выдача>();
                dataGridView1.DataSource = gender.ToList();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                label1.Text = "Поиск по Фамилии:";
                Table<Читатель> product = context.GetTable<Читатель>();
                dataGridView1.DataSource = product.ToList();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                label1.Text = "Поиск:";
                Table<Издание_произведения> acc = context.GetTable<Издание_произведения>();
                dataGridView1.DataSource = acc.ToList();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                label1.Text = "Поиск:";
                Table<Издание> CliSer = context.GetTable<Издание>();
                dataGridView1.DataSource = CliSer.ToList();
            }
            if (comboBox1.SelectedIndex == 4)
            {
                label1.Text = "Поиск:";
                Table<Произведение> gender = context.GetTable<Произведение>();
                dataGridView1.DataSource = gender.ToList();
            }
            if (comboBox1.SelectedIndex == 5)
            {
                label1.Text = "Поиск:";
                Table<Издательство> product = context.GetTable<Издательство>();
                dataGridView1.DataSource = product.ToList();
            }
            if (comboBox1.SelectedIndex == 6)
            {
                label1.Text = "Поиск:";
                Table<Город> acc = context.GetTable<Город>();
                dataGridView1.DataSource = acc.ToList();
            }
            if (comboBox1.SelectedIndex == 7)
            {
                label1.Text = "Поиск:";
                Table<Категория_произведения> CliSer = context.GetTable<Категория_произведения>();
                dataGridView1.DataSource = CliSer.ToList();
            }
            if (comboBox1.SelectedIndex == 8)
            {
                label1.Text = "Поиск:";
                Table<Автор_произведения> gender = context.GetTable<Автор_произведения>();
                dataGridView1.DataSource = gender.ToList();
            }
            if (comboBox1.SelectedIndex == 9)
            {
                label1.Text = "Поиск:";
                Table<Автор> product = context.GetTable<Автор>();
                dataGridView1.DataSource = product.ToList();
            }
            if (comboBox1.SelectedIndex == 10)
            {
                label1.Text = "Поиск:";
                Table<Категория> acc = context.GetTable<Категория>();
                dataGridView1.DataSource = acc.ToList();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                var f = context.GetTable<Выдача>().Where(x => x.ID_книги == Convert.ToInt32(comboBox2.SelectedValue));
                dataGridView1.DataSource = f.ToList();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                var f = context.GetTable<Читатель>().Where(x => x.Дата_рождения >= dateTimePicker1.Value);
                dataGridView1.DataSource = f.ToList();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "atmDataSet.Издание_произведения". При необходимости она может быть перемещена или удалена.
            this.издание_произведенияTableAdapter.Fill(this.atmDataSet.Издание_произведения);
            comboBox1.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                AddВыдача F = new AddВыдача();
                F.Show();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                AddЧитатель F = new AddЧитатель();
                F.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label1.Text = "Поиск ID_читатель:";
                Table<Выдача> gender = context.GetTable<Выдача>();
                dataGridView1.DataSource = gender.ToList();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                label1.Text = "Поиск по Фамилии:";
                Table<Читатель> product = context.GetTable<Читатель>();
                dataGridView1.DataSource = product.ToList();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                label1.Text = "Поиск:";
                Table<Издание_произведения> acc = context.GetTable<Издание_произведения>();
                dataGridView1.DataSource = acc.ToList();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                label1.Text = "Поиск:";
                Table<Издание> CliSer = context.GetTable<Издание>();
                dataGridView1.DataSource = CliSer.ToList();
            }
            if (comboBox1.SelectedIndex == 4)
            {
                label1.Text = "Поиск:";
                Table<Произведение> gender = context.GetTable<Произведение>();
                dataGridView1.DataSource = gender.ToList();
            }
            if (comboBox1.SelectedIndex == 5)
            {
                label1.Text = "Поиск:";
                Table<Издательство> product = context.GetTable<Издательство>();
                dataGridView1.DataSource = product.ToList();
            }
            if (comboBox1.SelectedIndex == 6)
            {
                label1.Text = "Поиск:";
                Table<Город> acc = context.GetTable<Город>();
                dataGridView1.DataSource = acc.ToList();
            }
            if (comboBox1.SelectedIndex == 7)
            {
                label1.Text = "Поиск:";
                Table<Категория_произведения> CliSer = context.GetTable<Категория_произведения>();
                dataGridView1.DataSource = CliSer.ToList();
            }
            if (comboBox1.SelectedIndex == 8)
            {
                label1.Text = "Поиск:";
                Table<Автор_произведения> gender = context.GetTable<Автор_произведения>();
                dataGridView1.DataSource = gender.ToList();
            }
            if (comboBox1.SelectedIndex == 9)
            {
                label1.Text = "Поиск:";
                Table<Автор> product = context.GetTable<Автор>();
                dataGridView1.DataSource = product.ToList();
            }
            if (comboBox1.SelectedIndex == 10)
            {
                label1.Text = "Поиск:";
                Table<Категория> acc = context.GetTable<Категория>();
                dataGridView1.DataSource = acc.ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0 && ВыдачаID != 0)
            {
                EditВыдача F = new EditВыдача(ВыдачаID);
                F.ShowDialog();
                ВыдачаID = 0;
            }
            if (comboBox1.SelectedIndex == 1 && ЧитательID != 0)
            {
                EditЧитатель F = new EditЧитатель(ЧитательID);
                F.ShowDialog();
                ЧитательID = 0;
            }
        }
    }
}
