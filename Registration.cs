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
    public partial class Registration : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-E8KTCSJ\\SQLEXPRESS01;Initial Catalog=Assignment;Integrated Security=True");

        public Registration()
        {
            InitializeComponent();
        }

        private bool usernameunique(string username)
        {
            string query = "Select Count (*)  from loginInfo where username=@username";

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@username", username);
                    int count = (int)command.ExecuteScalar();
                    return count == 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string query = "INSERT INTO Students (Username, ID, Email, Password, ContactNo,) VALUES (@Username, @ID, @Departmant, @Email,@ContactNo)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Assuming you have a textbox named txtID for manual entry of ID
                    cmd.Parameters.AddWithValue("@Username", txtStdUsername.Text);
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtStdID.Text));
                    cmd.Parameters.AddWithValue("@Email", txtStdEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", txtStdPassword.Text);
                    cmd.Parameters.AddWithValue("@ContactNo", txtStdContactNO.Text);


                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Account created successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                con.Close();
            }
        }




        private void btnStdCreate_Click(object sender, EventArgs e)
        {
            string id;
            string username;
            string email;
            string password;
            string contactNo;


            string role = "Student";

            id = txtStdID.Text;
            username = txtStdUsername.Text;
            email = txtStdEmail.Text;
            password = txtStdPassword.Text;
            contactNo = txtStdContactNO.Text;

            if (!usernameunique(username))
            {
                MessageBox.Show("Username already exist.....");
                return;
            }


            if (this.txtStdUsername.Text.Length == 0 || this.txtStdEmail.Text.Length == 0 || this.txtStdID.Text.Length == 0 ||
                this.txtStdPassword.Text.Length == 0 || this.txtStdContactNO.Text.Length == 0)
            {
                MessageBox.Show("All field are mandatory....");
            }
            else
            {
                try
                {
                    using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-E8KTCSJ\\SQLEXPRESS01;Initial Catalog=Assignment;Integrated Security=True"))
                    {
                        con.Open();

                        string query = "Insert into loginInfo (username,password,role) values (@username,@password,@role)";

                        using (SqlCommand info = new SqlCommand(query, con))
                        {
                            info.Parameters.AddWithValue("@username", username);
                            info.Parameters.AddWithValue("@password", password);
                            info.Parameters.AddWithValue("@role", role);

                            info.ExecuteNonQuery();
                        }

                        string insert = "INSERT INTO student (Student_Name, ID, Contact_No, EMail) VALUES (@username, @id,@contactNo, @email)";

                        using (SqlCommand info = new SqlCommand(insert, con))
                        {
                            info.Parameters.AddWithValue("@username", username);
                            info.Parameters.AddWithValue("@id", id);
                            info.Parameters.AddWithValue("@contactNo", contactNo);
                            info.Parameters.AddWithValue("@email", email);

                            int row = info.ExecuteNonQuery();

                            if (row > 0)
                            {
                                MessageBox.Show("Added successfully....");
                            }
                            else
                            {
                                MessageBox.Show("Failed....");
                            }
                        }

                    }               
                    }
                catch (Exception)
                {
                throw;
            }
        }
}

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Login back = new Login();
            back.Show();
        }
    }
}



