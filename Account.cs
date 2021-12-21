using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ATM
{
    public partial class Account : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        public Account()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Auth(textBox1.Text, textBox2.Text);
            Main f = new Main();
            f.Show();
        }
        public bool Auth(string login, string password)
        {
            bool state = false;
            string Login = textBox1.Text;
            string Password = textBox2.Text;
            con = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Home\Desktop\хлам\Учеба\Новая папка\Success.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            string str = ("SELECT * FROM accounts where Login='" + textBox1.Text + "' AND Password='" + textBox2.Text + "'");
            cmd.CommandText = str;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Добро пожаловать " + textBox1.Text);
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
            con.Close();
            return state;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены продолжить, как Гость?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                Guest F2 = new Guest();
                this.Hide();
                F2.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "successDataSet.accounts". При необходимости она может быть перемещена или удалена.
            this.accountsTableAdapter.Fill(this.successDataSet.accounts);
        }
    }
}
