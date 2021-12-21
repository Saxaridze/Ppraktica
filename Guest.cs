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
    public partial class Guest : Form
    {
        static string conStr = "Data Source=DESKTOP-M14TIR5\\SQLSERVER;Initial Catalog=atm;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public Guest()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label1.Text = "Поиск:";
                Table<Издание_произведения> acc = context.GetTable<Издание_произведения>();
                dataGridView1.DataSource = acc.ToList();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                label1.Text = "Поиск:";
                Table<Издание> CliSer = context.GetTable<Издание>();
                dataGridView1.DataSource = CliSer.ToList();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                label1.Text = "Поиск:";
                Table<Произведение> gender = context.GetTable<Произведение>();
                dataGridView1.DataSource = gender.ToList();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                label1.Text = "Поиск:";
                Table<Издательство> product = context.GetTable<Издательство>();
                dataGridView1.DataSource = product.ToList();
            }
            if (comboBox1.SelectedIndex == 4)
            {
                label1.Text = "Поиск:";
                Table<Город> acc = context.GetTable<Город>();
                dataGridView1.DataSource = acc.ToList();
            }
            if (comboBox1.SelectedIndex == 5)
            {
                label1.Text = "Поиск:";
                Table<Категория_произведения> CliSer = context.GetTable<Категория_произведения>();
                dataGridView1.DataSource = CliSer.ToList();
            }
            if (comboBox1.SelectedIndex == 6)
            {
                label1.Text = "Поиск:";
                Table<Автор_произведения> gender = context.GetTable<Автор_произведения>();
                dataGridView1.DataSource = gender.ToList();
            }
            if (comboBox1.SelectedIndex == 7)
            {
                label1.Text = "Поиск:";
                Table<Автор> product = context.GetTable<Автор>();
                dataGridView1.DataSource = product.ToList();
            }
            if (comboBox1.SelectedIndex == 8)
            {
                label1.Text = "Поиск:";
                Table<Категория> acc = context.GetTable<Категория>();
                dataGridView1.DataSource = acc.ToList();
            }
        }

        private void Guest_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Account F2 = new Account();
            this.Hide();
            F2.Show();
        }
    }
}
