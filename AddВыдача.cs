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
    public partial class AddВыдача : Form
    {
        static string conStr = "Data Source=DESKTOP-M14TIR5\\SQLSERVER;Initial Catalog=atm;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public AddВыдача()
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
                Выдача NewВыдача = new Выдача { ID_читатель = Convert.ToInt32(comboBox1.SelectedValue), ID_книги = Convert.ToInt32(comboBox2.SelectedValue), Дата_выдачи = dateTimePicker1.Value, Дата_возврата = dateTimePicker2.Value };
                context.GetTable<Выдача>().InsertOnSubmit(NewВыдача);
                context.SubmitChanges();
                this.Close();
            }
        }

        private void AddВыдача_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "atmDataSet.Издание_произведения". При необходимости она может быть перемещена или удалена.
            this.издание_произведенияTableAdapter.Fill(this.atmDataSet.Издание_произведения);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "atmDataSet.Читатель". При необходимости она может быть перемещена или удалена.
            this.читательTableAdapter.Fill(this.atmDataSet.Читатель);

        }
    }
}
