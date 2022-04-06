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
using System.Data.SqlClient;

namespace GavrilevAAP
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Material". При необходимости она может быть перемещена или удалена.
            //    this.materialTableAdapter.Fill(this.dataSet1.Supplier);
            comboBox2.Text = "Название";
        }

        public int countGrid = 0;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source =SQLNCLI11;Data Source=DESKTOP-JHPU656\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Gavrilev");
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            if (comboBox2.SelectedIndex == 0)
            {
                da.SelectCommand = new SqlCommand("SELECT * from Material ORDER BY Title ASC", con);
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                da.SelectCommand = new SqlCommand("SELECT * from Material ORDER BY Cost ASC", con);
            }
            else
            {
                da.SelectCommand = new SqlCommand("SELECT * from Material ORDER BY CountInStock ASC", con);
            }
            con.Open();
            da.Fill(ds, "Material");
            dataGridView1.DataSource = ds.Tables[0];
            da.Dispose();
            con.Dispose();
            ds.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 addForm = new Form2();
            addForm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            countGrid = 0;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                dataGridView1.CurrentCell = null;
                dataGridView1.Rows[i].Visible = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(comboBox1.Text))
                        {
                            dataGridView1.Rows[i].Visible = true;
                            countGrid++;
                            break;
                        }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            countGrid = 0;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                dataGridView1.CurrentCell = null;
                dataGridView1.Rows[i].Visible = true;
            }
        }
    }
}
