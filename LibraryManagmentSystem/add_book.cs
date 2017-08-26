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
namespace LibraryManagmentSystem
{
    public partial class add_book : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-S5A1R3M;Initial Catalog=LMS;Integrated Security=True");
        public add_book()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text =="" && textBox2.Text == "" && textBox3.Text == "" && dateTimePicker1.Text == "" && textBox5.Text == "" && textBox6.Text == "")
            {
                MessageBox.Show("All fields are Required");
            }
            else
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into books_info values('" + textBox3.Text + "','" + textBox2.Text + "','" + Convert.ToDateTime(dateTimePicker1.Text) + "','" + textBox1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                cmd.ExecuteNonQuery();
                conn.Close();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                dateTimePicker1.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";


                MessageBox.Show("Book Added Successfully...!!!");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
