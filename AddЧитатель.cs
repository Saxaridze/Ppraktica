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
    public partial class AddЧитатель : Form
    {
        static string conStr = "Data Source=DESKTOP-M14TIR5\\SQLSERVER;Initial Catalog=atm;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public AddЧитатель()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Добавить", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                Читатель NewЧитатель = new Читатель { Фамилия = textBox1.Text, Имя = textBox2.Text, Отчество = textBox3.Text, Дата_рождения = dateTimePicker1.Value, Адрес = textBox4.Text, Телефон = textBox5.Text, Дата_выдачи_билета = dateTimePicker2.Value, Срок_действия_билета=dateTimePicker3.Value };
                context.GetTable<Читатель>().InsertOnSubmit(NewЧитатель);
                context.SubmitChanges();
                this.Close();
            }
        }
    }
}
