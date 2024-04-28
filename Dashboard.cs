using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityBookStoreManagement.cs
{
    public partial class Dashboard : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-E8KTCSJ\\SQLEXPRESS01;Initial Catalog=Assignment;Integrated Security=True");

        public Dashboard()
        {
            InitializeComponent();
        }
       
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Close();
            Login back = new Login();
            back.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-E8KTCSJ\\SQLEXPRESS01;Initial Catalog=Assignment;Integrated Security=True");

            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Dashboard1 values (@Product_ID,@Product_Name,@Customer_Name,@Customer_No,@Date)", con);
            cmd.Parameters.AddWithValue("@Product_ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Product_Name", (textBox2.Text));
            cmd.Parameters.AddWithValue("@Customer_Name", (textBox3.Text));
            cmd.Parameters.AddWithValue("@Customer_No", (textBox4.Text));
            cmd.Parameters.AddWithValue("@Date", (dateTimePicker1.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Sucessfully Saved");










        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-E8KTCSJ\\SQLEXPRESS01;Initial Catalog=Assignment;Integrated Security=True");

            con.Open();
            SqlCommand cmd = new SqlCommand("Update Dashboard1 set Product_ID=@Product_ID, Product_Name=@Product_Name, Customer_Name=@Customer_Name ,Customer_No=@Customer_No,Date =@Date", con);
            cmd.Parameters.AddWithValue("@Product_ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Product_Name", (textBox2.Text));
            cmd.Parameters.AddWithValue("@Customer_Name", (textBox3.Text));
            cmd.Parameters.AddWithValue("@Customer_No", (textBox4.Text));
            cmd.Parameters.AddWithValue("@Date ", (dateTimePicker1.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Sucessfully Update");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-E8KTCSJ\\SQLEXPRESS01;Initial Catalog=Assignment;Integrated Security=True");

            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Dashboard1 where Product_ID=@Product_ID ", con);
            cmd.Parameters.AddWithValue("@Product_ID", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Sucessfully Delete");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-E8KTCSJ\\SQLEXPRESS01;Initial Catalog=Assignment;Integrated Security=True");

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Dashboard1", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd); // Use SqlDataAdapter instead of SqlCommand
            DataTable dt = new DataTable();
            da.Fill(dt); // Fill the DataTable with data from the database
            dataGridView1.DataSource = dt;

        }
    }
}
