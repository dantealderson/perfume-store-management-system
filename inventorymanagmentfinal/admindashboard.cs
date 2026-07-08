using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace inventorymanagmentfinal
{
    public partial class admindashboard : UserControl
    {
        public admindashboard()
        {
            InitializeComponent();
        }
        private void LoadDashboardData()
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                // 1. Count of active users from 'accounts' table
                string activeUsersQuery = "SELECT COUNT(*) FROM accounts WHERE status = 'Active'";
                using (MySqlCommand cmd = new MySqlCommand(activeUsersQuery, conn))
                {
                    int activeUsers = Convert.ToInt32(cmd.ExecuteScalar());
                    labelone.Text = activeUsers.ToString();
                }

                // 2. Count of today's customers from 'orders'
                string todaysCustomersQuery = "SELECT COUNT(DISTINCT customer_id) FROM orders WHERE DATE(order_date) = CURDATE()";
                using (MySqlCommand cmd = new MySqlCommand(todaysCustomersQuery, conn))
                {
                    int todaysCustomers = Convert.ToInt32(cmd.ExecuteScalar());
                    labeltwo.Text = todaysCustomers.ToString();
                }

                string todaysIncomeQuery = "SELECT IFNULL(SUM(total_price), 0) FROM orders WHERE DATE(order_date) = CURDATE()";
                using (MySqlCommand cmd = new MySqlCommand(todaysIncomeQuery, conn))
                {
                    decimal todaysIncome = Convert.ToDecimal(cmd.ExecuteScalar());
                    labelthree.Text = $"{todaysIncome:C}"; 
                }

                // 4. Placeholder for total income
                labelfour.Text = "$0.00";
            }
        }

        private void admindashboard_Load(object sender, EventArgs e)
        {
            LoadCustomersWithOrders();
            LoadDashboardData();
        }
        private void LoadCustomersWithOrders()
        {
            string query = @"
        SELECT 
            customers.id,
            customers.name,
            customers.phone,
            orders.id AS order_id,
            orders.order_date,
            orders.total_price
        FROM 
            customers
        JOIN 
            orders ON customers.id = orders.customer_id;
    ";

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                 
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    customersdgv.DataSource = dt;

                    // Optional column headers
                    customersdgv.Columns["id"].HeaderText = "Customer ID";
                    customersdgv.Columns["name"].HeaderText = "Name";
                    customersdgv.Columns["phone"].HeaderText = "Phone";
                    customersdgv.Columns["order_id"].HeaderText = "Order ID";
                    customersdgv.Columns["order_date"].HeaderText = "Order Date";
                    customersdgv.Columns["total_price"].HeaderText = "Total Price";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading customer data: " + ex.Message);
                }
            }
        }

        private void customersDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Make sure it's not the header
            {
                // Get the order ID from the clicked row
                var selectedRow = customersdgv.Rows[e.RowIndex];
                int orderId = Convert.ToInt32(selectedRow.Cells["order_id"].Value);

                // Show the order details (step 2)
                ShowOrderDetails(orderId);
            }
        }



        private void ShowOrderDetails(int orderId)
        {
            string query = @"
        SELECT 
            f.name AS fragrance_name,
            oi.size,
            oi.quantity,
            oi.price AS unit_price,
            (oi.quantity * oi.price) AS total_price
        FROM 
            order_items oi
        JOIN 
            fragrance f ON f.frag_id = oi.fragrance_id
        WHERE 
            oi.order_id = @orderId;
    ";

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@orderId", orderId);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    StringBuilder details = new StringBuilder();
                    decimal grandTotal = 0;

                    while (reader.Read())
                    {
                        string name = reader["fragrance_name"].ToString();
                        int sizeValue = reader.GetInt32("size");
                        string size = sizeValue.ToString();

                        int qty = Convert.ToInt32(reader["quantity"]);
                        decimal unitPrice = Convert.ToDecimal(reader["unit_price"]);
                        decimal totalPrice = Convert.ToDecimal(reader["total_price"]);

                        grandTotal += totalPrice;

                        details.AppendLine($"{name} | Size: {size} | Qty: {qty} | Unit Price: {unitPrice:C} | Total: {totalPrice:C}");
                    }

                    if (details.Length == 0)
                    {
                        details.AppendLine("No items found for this order.");
                    }
                    else
                    {
                        details.AppendLine("\n------------------------------");
                        details.AppendLine($"🧾 Grand Total: {grandTotal:C}");
                    }

                    MessageBox.Show(details.ToString(), $"Order #{orderId} Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading order details: " + ex.Message);
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            LoadCustomersWithOrders();
            LoadDashboardData();
        }
    }










}

