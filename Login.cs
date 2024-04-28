using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//works for sql connection//


namespace UniversityBookStoreManagement.cs
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.ActiveControl = txtUserName;
            txtUserName.Focus();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-E8KTCSJ\\SQLEXPRESS01;Initial Catalog=Assignment;Integrated Security=True");



        private void button1_Click(object sender, EventArgs e)
        {
            Alogin();
        }

        private void Alogin()
        {
            string username = txtUserName.Text;
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_loginInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = txtUserName.Text;
            cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = txtPassword.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while(dr.Read())
                {
                    string role = dr["role"].ToString();

                    if(role=="Student")
                    {
                        this.Hide();
                        Dashboard s = new Dashboard();
                        s.Show();

                    }
                    else
                    {
                        this.Hide();
                        Dashboard s = new Dashboard();
                        s.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("Login Failed! Please provide correct information.");
            }
            con.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            Registration cra = new Registration();
            cra.Show();
            this.Hide();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar== (char)Keys.Enter)
            {
                Alogin();
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
