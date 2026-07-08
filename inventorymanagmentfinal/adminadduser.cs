using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace inventorymanagmentfinal
{
    public partial class adminadduser : UserControl
    {
        public adminadduser()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string query = "SELECT a.username, u.role, a.status, a.phonenumber, u.firstname, u.lastname, u.gender FROM accounts a JOIN user u ON a.ID = u.ID";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    userdgv.DataSource = dt;
                }
            }
        }

        private string FormatPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.StartsWith("+964"))
            {
                return "0" + phoneNumber.Substring(4);
            }
            return phoneNumber;
        }

        private bool IsValidName(string name)
        {
            return !string.IsNullOrEmpty(name) && Regex.IsMatch(name, "^[A-Za-z]+$");
        }

        private void addusers_addbtn_Click(object sender, EventArgs e)
        {
            string firstName = userfntxtbox.Text.Trim();
            string lastName = userlntxtbox.Text.Trim();
            string username = userusernametxtbox.Text.Trim();
            string password = userpasswordtxtbox.Text.Trim();
            string role = "cashier";
            string status = statuscombobox.SelectedItem?.ToString();
            string phoneNumber = FormatPhoneNumber(userpnutxtbox.Text.Trim());
            String gender="";
            if (userfradio.Checked)
                gender = "f";
            else if (usermradio.Checked)
                gender = "m";

            if (useradminradio.Checked)
                role = "admin";
            else if (usercashierradio.Checked)
                role = "cashier";

            if (!IsValidName(firstName) || !IsValidName(lastName))
            {
                MessageBox.Show("First name and last name must only contain letters and cannot be empty.");
                return;
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("All fields, including gender, must be filled.");
                return;
            }

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                MySqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    string roleQuery = "INSERT INTO user (role, firstname, lastname, gender) VALUES (@role, @firstname, @lastname, @gender);";
                    int userId;
                    using (MySqlCommand roleCmd = new MySqlCommand(roleQuery, conn, transaction))
                    {
                        roleCmd.Parameters.AddWithValue("@role", role);
                        roleCmd.Parameters.AddWithValue("@firstname", firstName);
                        roleCmd.Parameters.AddWithValue("@lastname", lastName);
                        roleCmd.Parameters.AddWithValue("@gender", gender);
                        roleCmd.ExecuteNonQuery();
                        userId = Convert.ToInt32(roleCmd.LastInsertedId);
                    }

                    string query = "INSERT INTO accounts (username, password, ID, status, phonenumber) VALUES (@username, @password, @ID, @status, @phonenumber);";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@ID", userId);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@phonenumber", phoneNumber);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("User added successfully.");
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            string newUsername = userusernametxtbox.Text.Trim();
            string firstName = userfntxtbox.Text.Trim();
            string lastName = userlntxtbox.Text.Trim();
            string phoneNumber = FormatPhoneNumber(userpnutxtbox.Text.Trim());
            string gender = userfradio.Checked ? "f" : (usermradio.Checked ? "m" : "");
            string status = statuscombobox.SelectedItem?.ToString();
            string role = useradminradio.Checked ? "admin" : "cashier";

            if (string.IsNullOrEmpty(originalUsername))
            {
                MessageBox.Show("Please select a user to update.");
                return;
            }

            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(status))
            {
                MessageBox.Show("All fields must be filled.");
                return;
            }

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string query = "UPDATE user u JOIN accounts a ON u.ID = a.ID " +
                               "SET a.username = @newUsername, u.firstname = @firstname, u.lastname = @lastname, " +
                               "u.gender = @gender, u.role = @role, a.phonenumber = @phonenumber, a.status = @status " +
                               "WHERE a.username = @originalUsername";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@newUsername", newUsername);
                    cmd.Parameters.AddWithValue("@firstname", firstName);
                    cmd.Parameters.AddWithValue("@lastname", lastName);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@phonenumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@originalUsername", originalUsername);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User updated successfully.");
                        originalUsername = newUsername; // Update stored username
                        LoadUsers();
                    }
                    else
                    {
                        MessageBox.Show("User not found.");
                    }
                }
            }
        }


        private void removebtn_Click(object sender, EventArgs e)
        {
            string username = userusernametxtbox.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Enter a username to remove.");
                return;
            }

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string query = "DELETE a, u FROM accounts a JOIN user u ON a.ID = u.ID WHERE a.username = @username";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected > 0 ? "User removed successfully." : "User not found.");
                    LoadUsers();
                }
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            userfntxtbox.Clear();
            userlntxtbox.Clear();
            userusernametxtbox.Clear();
            userpasswordtxtbox.Clear();
            userpnutxtbox.Clear();
            useradminradio.Checked = false;
            usercashierradio.Checked = false;
            userfradio.Checked = false;
            usermradio.Checked = false;
            statuscombobox.SelectedIndex = -1;
        }

        private string originalUsername = "";

        private void adduserdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = userdgv.Rows[e.RowIndex];

                originalUsername = row.Cells["username"].Value?.ToString(); // Store the original username
                userusernametxtbox.Text = originalUsername; // Fill textbox with it

                userfntxtbox.Text = row.Cells["firstname"].Value?.ToString();
                userlntxtbox.Text = row.Cells["lastname"].Value?.ToString();
                userpnutxtbox.Text = row.Cells["phonenumber"].Value?.ToString();
                statuscombobox.SelectedItem = row.Cells["status"].Value?.ToString();

                string gender = row.Cells["gender"].Value?.ToString();
                userfradio.Checked = gender == "f";
                usermradio.Checked = gender == "m";

                string role = row.Cells["role"].Value?.ToString();
                useradminradio.Checked = role == "admin";
                usercashierradio.Checked = role == "cashier";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void useradminradio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void adminadduser_Load(object sender, EventArgs e)
        {

        }
    }
}
