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
    public partial class EditВыдача : Form
    {
        static string conStr = "Data Source=DESKTOP-M14TIR5\\SQLSERVER;Initial Catalog=YP;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        Выдача it;
        public EditВыдача(int id)
        {
            InitializeComponent();
            it = context.GetTable<Выдача>().FirstOrDefault(x => x.ID == id);
            comboBox1.DataSource = context.GetTable<Читатель>().ToList();
            comboBox1.DisplayMember = "Фамилия";
            comboBox1.ValueMember = "ID_читателя";
            comboBox2.DataSource = context.GetTable<Издание_произведения>().ToList();
            comboBox2.DisplayMember = "Произведение";
            comboBox2.ValueMember = "ID_издания_произведения";
            comboBox1.SelectedValue = it.ID_читатель;
            comboBox2.SelectedValue = it.ID_книги;
            dateTimePicker1.Value = it.Дата_выдачи;
            dateTimePicker2.Value = it.Дата_возврата;
        }

        private void EditВыдача_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "atmDataSet.Издание_произведения". При необходимости она может быть перемещена или удалена.
            this.издание_произведенияTableAdapter.Fill(this.atmDataSet.Издание_произведения);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "atmDataSet.Читатель". При необходимости она может быть перемещена или удалена.
            this.читательTableAdapter.Fill(this.atmDataSet.Читатель);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Изменить?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                it.ID_читатель = Convert.ToInt32(comboBox1.SelectedValue);
                it.ID_книги = Convert.ToInt32(comboBox1.SelectedValue);
                it.Дата_выдачи = dateTimePicker1.Value;
                it.Дата_возврата = dateTimePicker1.Value;
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
