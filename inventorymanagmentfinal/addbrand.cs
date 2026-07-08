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
    public partial class addbrand : UserControl
    {
        public addbrand()
        {
            InitializeComponent();
            LoadBrands();  
            branddgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // Load data into DataGridView
        private void LoadBrands()
        {
            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT * FROM Brand";
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    branddgv.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // Get selected brand style from radio buttons
        private string GetBrandStyle()
        {
            if (designerradio.Checked) return "Designer";
            if (nicheradio.Checked) return "Niche";
            if (commeradio.Checked) return "Commercial";
            if (dupesradio.Checked) return "Dupe"; 
            return null;
        }

        // Add a new brand
        private void addButton_Click(object sender, EventArgs e)
        {
            string brandName = brandtxtbox.Text;
            string brandStyle = GetBrandStyle();

            if (string.IsNullOrWhiteSpace(brandName) || string.IsNullOrWhiteSpace(brandStyle))
            {
                MessageBox.Show("Please fill out both fields.");
                return;
            }

            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = "INSERT INTO Brand (brand_name, brand_style) VALUES (@brandName, @brandStyle)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@brandName", brandName);
                    command.Parameters.AddWithValue("@brandStyle", brandStyle);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Brand added successfully.");
                        LoadBrands();
                    }
                    else
                    {
                        MessageBox.Show("Error adding brand.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Remove a brand
        private void removeButton_Click(object sender, EventArgs e)
        {
            if (branddgv.CurrentRow == null || branddgv.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a brand to remove.");
                return;
            }

            int brandId = Convert.ToInt32(branddgv.CurrentRow.Cells[0].Value);

            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = "DELETE FROM Brand WHERE brand_id = @brandId";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@brandId", brandId);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Brand removed successfully.");
                        LoadBrands();
                    }
                    else
                    {
                        MessageBox.Show("Error removing brand.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Update a brand
        private void updateButton_Click(object sender, EventArgs e)
        {
            if (branddgv.CurrentRow == null || branddgv.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a brand to update.");
                return;
            }

            int brandId = Convert.ToInt32(branddgv.CurrentRow.Cells[0].Value);
            string brandName = brandtxtbox.Text;
            string brandStyle = GetBrandStyle();

            if (string.IsNullOrWhiteSpace(brandName) || string.IsNullOrWhiteSpace(brandStyle))
            {
                MessageBox.Show("Please fill out both fields.");
                return;
            }

            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetConnection())
                {
                    string query = "UPDATE Brand SET brand_name = @brandName, brand_style = @brandStyle WHERE brand_id = @brandId";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@brandName", brandName);
                    command.Parameters.AddWithValue("@brandStyle", brandStyle);
                    command.Parameters.AddWithValue("@brandId", brandId);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Brand updated successfully.");
                        LoadBrands();
                    }
                    else
                    {
                        MessageBox.Show("Error updating brand.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Clear input fields
        private void clearButton_Click(object sender, EventArgs e)
        {
            brandtxtbox.Clear();
            designerradio.Checked = false;
            nicheradio.Checked = false;
        }

        // Populate input fields when a row is clicked
        private void branddgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = branddgv.Rows[e.RowIndex];
                brandtxtbox.Text = row.Cells[1].Value.ToString(); // brand_name
                string brandStyle = row.Cells[2].Value.ToString(); // brand_style

                if (brandStyle == "Designer")
                {
                    designerradio.Checked = true;
                    nicheradio.Checked = false;
                }
                else if (brandStyle == "Niche")
                {
                    nicheradio.Checked = true;
                    designerradio.Checked = false;
                }
            }
        }

        private void BrandForm_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}