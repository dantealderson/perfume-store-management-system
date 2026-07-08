using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace inventorymanagmentfinal
{
    public partial class registerform : Form
    {

        public registerform()
        {
            InitializeComponent();
        }
        // red close button
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // switches to login form
        private void showloginform()
        {
            Form1 loginform = new Form1();
            loginform.Show();
            this.Hide();
        }
        // when clicked on login label
        private void LoginLabel_Click(object sender, EventArgs e)
        {
            showloginform();
        }
        // username placeholder
        private void RegUsername_Leave(object sender, EventArgs e)
        {
            if (RegUsername.Text == "")
            {
                RegUsername.Text = "UserName";
                RegUsername.ForeColor = Color.Silver;
            }
        }
        // username placeholder
        private void RegUsername_Enter(object sender, EventArgs e)
        {
            if (RegUsername.Text == "UserName")
            {
                RegUsername.Text = "";
                RegUsername.ForeColor = Color.Black;
            }
        }
        // password placeholder
        private void RegPassword_Leave(object sender, EventArgs e)
        {
            if (RegPassword.Text == "")
            {

                RegPassword.Text = "Password";
                RegPassword.ForeColor = Color.Silver;
                RegPassword.PasswordChar = '\0';

            }
            closedeye1.Visible = false;
            openeye1.Visible = false;
            RegPassword.PasswordChar = '*';
        }
        // password placeholder
        private void RegPassword_Enter(object sender, EventArgs e)
        {
            if (RegPassword.Text == "Password")
            {
                RegPassword.Text = "";
                RegPassword.ForeColor = Color.Black;
                RegPassword.PasswordChar = '*';

            }

            closedeye1.Visible = true;
            openeye1.Visible = true;
            if (RegPassword.PasswordChar == '*')
                closedeye1.BringToFront();
        }
        // confirm password placeholder
        private void RegPassword2_Leave(object sender, EventArgs e)
        {
            if (RegPassword2.Text == "")
            {
                RegPassword2.Text = "Confirm Password";
                RegPassword2.ForeColor = Color.Silver;
            }
            closedeye2.Visible = false;
            openeye2.Visible = false;
            RegPassword2.PasswordChar = '*';
        }

        // confirm password placeholder
        private void RegPassword2_Enter(object sender, EventArgs e)
        {
            if (RegPassword2.Text == "Confirm Password")
            {
                RegPassword2.Text = "";
                RegPassword2.ForeColor = Color.Black;
                RegPassword2.PasswordChar = '*';
            }
            closedeye2.Visible = true;
            openeye2.Visible = true;
            if (RegPassword2.PasswordChar == '*')
                closedeye2.BringToFront();


        }


        // email placeholder
        private void RegPnu_Leave(object sender, EventArgs e)
        {
            if (RegPnu.Text == "")
            {
                RegPnu.Text = "07xxxxxxxxx";
                RegPnu.ForeColor = Color.Silver;
            }
        }
        // email placeholder
        private void RegPnu_Enter(object sender, EventArgs e)
        {
            if (RegPnu.Text == "07xxxxxxxxx")
            {
                RegPnu.Text = "";
                RegPnu.ForeColor = Color.Black;
            }
        }

        // sign up button click(where all the magic happens)
        private void SignupBtn_Click(object sender, EventArgs e)
        {
            // takes the username from the textbox, ensures that its not the placeholder and its not empty.
            string username = RegUsername.Text;
            if (RegUsername.Text == "UserName" && RegUsername.ForeColor == Color.Silver)
                username = "";
            if (username == "")
            {
                MessageBox.Show("Username cannot be empty");
                return;
            }
            // takes the password from its placeholder, makes sure its not the palceholder and its not empty.
            string password = RegPassword.Text;
            if (RegPassword.Text == "Password" && RegPassword.ForeColor == Color.Silver)
                password = "";
            if (password == "")
            {
                MessageBox.Show("password can not be empty");
                return;
            }
            // takes the first name
            string FN = RegFN.Text;
            string role = "cashier";
            //validate the first and the second name
            if (!ValidateName(FN)) return;

            string LN = RegLN.Text;
            if (!ValidateName2(LN)) return;
            // makes sure the email is not a placeholder and its not empty
            string email = RegPnu.Text;
            if (email == "" || RegPnu.ForeColor == Color.Silver)
            {
                MessageBox.Show("Email cannot be empty");
                return;
            }


            // Ensure passwords match and ignores placeholders
            string confirmPassword = RegPassword2.Text;
            if (RegPassword2.Text == "Confirm Password" && RegPassword2.ForeColor == Color.Silver)
                confirmPassword = "";

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // gender set and checks if no gender is chosen
            char gender = 'f';
            if (mradio.Checked)
                gender = 'm';
            else if (fradio.Checked)
                gender = 'f';
            else
            {
                MessageBox.Show("Please choose your gender");
                return;
            }

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open) // Ensure connection is open
                    conn.Open();

                MySqlTransaction transaction = conn.BeginTransaction(); // Start transaction

                try
                {
                    // Check if username already exists before inserting
                    if (UsernameExists(conn, username) && RegUsername.ForeColor == Color.Black)
                    {
                        MessageBox.Show("Username already exists. Please choose another.");
                        return;
                    }
                    if (EmailExists(conn, email) && RegPnu.ForeColor == Color.Black)
                    {
                        MessageBox.Show("Email is already used");
                        return;
                    }

                    // Insert into `user` table
                    string userQuery = "INSERT INTO user (`first name`, `last name`, gender, role) " +
                                       "VALUES (@FN, @LN, @gender, @role);";
                    using (MySqlCommand cmd = new MySqlCommand(userQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@FN", FN);
                        cmd.Parameters.AddWithValue("@LN", LN);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.ExecuteNonQuery();
                    }

                    // Get the last inserted `user_id`
                    long userId = Convert.ToInt64(new MySqlCommand("SELECT LAST_INSERT_ID();", conn, transaction).ExecuteScalar());

                    // Insert into `accounts` table
                    string accountsQuery = "INSERT INTO accounts (ID, username, password, email) " +
                                           "VALUES (@user_id, @username, @password, @email);";
                    using (MySqlCommand cmd2 = new MySqlCommand(accountsQuery, conn, transaction))
                    {
                        cmd2.Parameters.AddWithValue("@user_id", userId);
                        cmd2.Parameters.AddWithValue("@username", username);
                        cmd2.Parameters.AddWithValue("@password", password);
                        cmd2.Parameters.AddWithValue("@email", email);
                        cmd2.ExecuteNonQuery();
                    }

                    transaction.Commit(); // Commit both inserts
                    MessageBox.Show("Registration successful!");
                    showloginform(); // Redirect to login
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Rollback on error
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }





        private bool UsernameExists(MySqlConnection conn, string username)
        {
            string query = "SELECT COUNT(*) FROM accounts WHERE Username = @Username";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                int count = Convert.ToInt32(cmd.ExecuteScalar()); // Execute without opening a new connection
                return count > 0;
            }
        }
        private bool EmailExists(MySqlConnection conn, string email)
        {
            string query = "SELECT COUNT(*) FROM accounts WHERE email = @Email";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                int count = Convert.ToInt32(cmd.ExecuteScalar()); // Execute without opening a new connection
                return count > 0;
            }
        }

        private void openeye1_Click(object sender, EventArgs e)
        {
            RegPassword.PasswordChar = '*';
            closedeye1.BringToFront();
        }

        private void closedeye1_Click(object sender, EventArgs e)
        {
            RegPassword.PasswordChar = '\0';
            openeye1.BringToFront();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void openeye2_Click(object sender, EventArgs e)
        {
            RegPassword2.PasswordChar = '*';
            closedeye2.BringToFront();
        }

        private void closedeye2_Click(object sender, EventArgs e)
        {
            RegPassword2.PasswordChar = '\0';
            openeye2.BringToFront();
        }
        // perfrectly working, no comment needed
        private bool ValidateName(string firstName)
        {

            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("First name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(firstName, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("First name can only contain letters and spaces.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (firstName.Length < 2 || firstName.Length > 30)
            {
                MessageBox.Show("First name must be between 2 and 30 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private bool ValidateName2(string firstName)
        {

            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Second name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(firstName, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Second name can only contain letters and spaces.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (firstName.Length < 2 || firstName.Length > 30)
            {
                MessageBox.Show("Second name must be between 2 and 30 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void registerform_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RegFN_TextChanged(object sender, EventArgs e)
        {

        }
    }
}














