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
using MySql.Data;
using MySql.Data.MySqlClient;
using static System.Net.WebRequestMethods;
namespace inventorymanagmentfinal
{
    public partial class Form1 : Form
    {
        public string UserRole { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegLabel_Click(object sender, EventArgs e)
        {
            registerform regform = new registerform();
            regform.Show();
            this.Hide();
        }



        private void LoginBtn_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    string query = @"
                SELECT u.role 
                FROM accounts a
                JOIN user u ON a.id = u.id
                WHERE a.username = @username AND a.password = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", LoginUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", LoginPassword.Text.Trim());

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string role = result.ToString().ToLower(); // normalize to lowercase
                            MessageBox.Show("Login Successful! Role: " + role);

                            this.Hide();

                            if (role == "admin")
                            {
                                mainform mainForm = new mainform();
                                mainForm.Show();
                            }
                            else if (role == "cashier")
                            {
                                cashierform cashierForm = new cashierform();
                                cashierForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Unknown role: " + role);
                                this.Show(); // show login form again
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username or password are incorrect");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }



        private void LoginPassword_Enter(object sender, EventArgs e)
        {
            login_closedeye1.Visible = true;
            login_openeye1.Visible = true;
            if (LoginPassword.PasswordChar == '*')
                login_closedeye1.BringToFront();
        }

        private void LoginPassword_Leave(object sender, EventArgs e)
        {
            login_closedeye1.Visible = false;
            login_openeye1.Visible = false;

            LoginPassword.PasswordChar = '*';
        }
        private void login_openeye1_Click(object sender, EventArgs e)
        {
            LoginPassword.PasswordChar = '*';
            login_closedeye1.BringToFront();
        }

        private void closedeye1_Click(object sender, EventArgs e)
        {
            LoginPassword.PasswordChar = '\0';
            login_openeye1.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
         

        
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick(); 
            }
        

    }
}
}

