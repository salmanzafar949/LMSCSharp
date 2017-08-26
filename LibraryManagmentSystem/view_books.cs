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
    public partial class view_books : Form
    {
        int res = 0;
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-S5A1R3M;Initial Catalog=LMS;Integrated Security=True");
        public view_books()
        {
            InitializeComponent();
        }
        public void display_books()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from books_info";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void view_books_Load(object sender, EventArgs e)
        {
            display_books();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from books_info where book_name  like('%" + textBox1.Text + "%')  or book_author like('%" + textBox1.Text + "%')";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    res = Convert.ToInt32(dt.Rows.Count.ToString());
                    dataGridView1.DataSource = dt;
                    conn.Close();

                    if (res == 0)
                    {
                        MessageBox.Show("No Record Found");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Enter a book name to search");
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from books_info where book_name  like('%" + textBox1.Text + "%') or book_author like('%" + textBox1.Text + "%')";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    res = Convert.ToInt32(dt.Rows.Count.ToString());
                    dataGridView1.DataSource = dt;
                    conn.Close();

                    if (res == 0)
                    {
                        MessageBox.Show("No Record Found");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Enter a book name to search");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Visible = true;
            int i;
            i = Convert.ToInt32( dataGridView1.SelectedCells[0].Value.ToString() );
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from books_info where id='"+ i +"'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                
                foreach(DataRow dr in dt.Rows)
                {
                    book_name.Text = dr["book_name"].ToString();
                    Author_name.Text = dr["book_author"].ToString();
                    publish_date.Value = Convert.ToDateTime( dr["book_p_date"].ToString() );
                    publication_name.Text = dr["book_p_name"].ToString();
                    book_price.Text = dr["book_price"].ToString();
                    book_quantity.Text = dr["books_quantity"].ToString();
                }


                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books_info set book_name='"+ book_name.Text +"', book_author='"+ Author_name.Text  +"', book_p_date='"+ Convert.ToDateTime( publish_date.Value ) +"', book_p_name='"+ publication_name.Text +"', book_price='"+ book_price.Text +"', books_quantity='"+ book_quantity.Text +"' where id='"+ i +"' ";
                cmd.ExecuteNonQuery();
                conn.Close();
                display_books();
                MessageBox.Show("Record Updated Successfully...!!!!");
                panel1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
