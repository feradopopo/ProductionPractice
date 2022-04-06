using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GavrilevAAP
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source =SQLNCLI11;Data Source=DESKTOP-HVD7F6Q\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=gavr");

            // Считываем данные с формы ...
            string Title = textBox1.Text.Trim();
            string CountInPack = textBox2.Text.Trim();
            string Unit = textBox3.Text.Trim();
            string CountInStock = textBox4.Text.Trim();
            string MinCount = textBox5.Text.Trim();
            string Description = textBox6.Text.Trim();
            string Cost = textBox7.Text.Trim();
            string Image = textBox8.Text.Trim();
            int MaterialTypeID = comboBox1.SelectedIndex;



/*          {
            if (Cost.Trim() == "")
            {
                MessageBox.Show("Цена не может быть пустым!");
            }
            else if (Convert.ToInt32(Cost) < 0)
            {
                MessageBox.Show("Цена не может быть отрицательным!");
            }
            else
*/
            try
            {
                con.Open();
                SqlCommand InputCmd = new SqlCommand("INSERT INTO Material (Title, CountInPack, Unit, CountInStock, MinCount, Description, Cost, Image, MaterialTypeID) VALUES ('" + Title + "','" + CountInPack + "','" + Unit + "','" + CountInStock + "','" + MinCount + "','" + Description + "','" + Cost + "','" + Image + "','" + (MaterialTypeID + 1) + "')", con);
                InputCmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                con.Close();
                // da.SelectCommand = new SqlCommand("INSERT INTO Material (Title, CountInPack, Unit, CountInStock, MinCount, Description, Cost, Image, MaterialTypeID) VALUES ('" + Title + "','" + CountInPack + "','" + Unit + "','" + CountInStock + "','" + MinCount + "','" + Description + "','" + Cost + "','" + Image + "','" + MaterialTypeID + "')", con);

                con.Dispose();
                this.Close();
            }
 //         }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet3.MaterialType". При необходимости она может быть перемещена или удалена.
            this.materialTypeTableAdapter.Fill(this.dataSet3.MaterialType);

        }
    }
}
