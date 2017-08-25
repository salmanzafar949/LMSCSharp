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
    public partial class Login : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-S5A1R3M;Initial Catalog=LMS;Integrated Security=True");
        int count =0;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

            if(conn.State == ConnectionState.Open)
            {
                conn.Close();

            }

            conn.Open();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

             if(textBox1.Text == "" && textBox2.Text =="")
            {
                MessageBox.Show("Please Enter Valid Credentials");
            }
            else
            { 
           
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from login where email='"+ textBox1.Text +"' and pass='"+ textBox2.Text +"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());

            if(count == 0)
            {
                MessageBox.Show("Invalid Credentials");
            }
            else
            {
                this.Hide();
                MDI_user user = new MDI_user();
                user.Show();
            }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
