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
    public partial class EditЧитатель : Form
    {
        static string conStr = "Data Source=DESKTOP-M14TIR5\\SQLSERVER;Initial Catalog=atm;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        Читатель it;
        public EditЧитатель(int id)
        {
            InitializeComponent();
            it = context.GetTable<Читатель>().FirstOrDefault(x => x.ID_билета == id);
            textBox1.Text = it.Фамилия;
            textBox1.Text = it.Имя;
            textBox1.Text = it.Отчество;
            dateTimePicker1.Value = it.Дата_рождения;
            textBox1.Text = it.Адрес;
            textBox1.Text = it.Телефон;
            dateTimePicker2.Value = it.Дата_выдачи_билета;
            dateTimePicker3.Value = it.Срок_действия_билета;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Изменить?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                it.Фамилия = textBox1.Text;
                it.Имя = textBox2.Text;
                it.Отчество = textBox3.Text;
                it.Дата_рождения = dateTimePicker1.Value;
                it.Адрес = textBox4.Text;
                it.Телефон = textBox5.Text;
                it.Дата_выдачи_билета = dateTimePicker2.Value;
                it.Срок_действия_билета = dateTimePicker3.Value;
                context.SubmitChanges();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
