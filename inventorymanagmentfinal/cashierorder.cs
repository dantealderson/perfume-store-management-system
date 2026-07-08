using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace inventorymanagmentfinal
{
    public partial class cashierorder : UserControl
    {
        private int selectedPrice = 0;
        private decimal orderprice = 0;
        private decimal change=0;
        public cashierorder()
        {
            InitializeComponent();
        }

        private void cashierorder_Load(object sender, EventArgs e)
        {
            LoadBrands();
            LoadProducts();
        }

        private void LoadBrands()
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    string query = "SELECT DISTINCT brand_name FROM brand ORDER BY brand_name ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    brandtxtbox.Items.Clear();
                    brandtxtbox.Items.Add("All Brands");

                    while (reader.Read())
                    {
                        brandtxtbox.Items.Add(reader.GetString("brand_name"));
                    }

                    brandtxtbox.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading brands: " + ex.Message);
                }
            }
        }

        private void LoadProducts()
        {
            string selectedBrand = brandtxtbox.SelectedItem?.ToString();
            string nameFilter = fragnametxtbox.Text.Trim();

            string query = @"
                SELECT 
                    fragrance.frag_id as ID,
                    fragrance.name AS Name,
                    brand.brand_name AS Brand,
                    fragrance.size AS Size,
                    history.stock AS Stock,
                    fragrance.intensity AS Intensity,
                    history.exp_date AS ExpirationDate
                FROM 
                    fragrance
                JOIN 
                    brand ON fragrance.brand_id = brand.brand_id
                JOIN 
                    history ON fragrance.frag_id = history.frag_id
                WHERE 
                    history.stock > 0";

            if (!string.IsNullOrEmpty(nameFilter))
            {
                query += " AND fragrance.name LIKE @name";
            }

            if (!string.IsNullOrEmpty(selectedBrand) && selectedBrand != "All Brands")
            {
                query += " AND brand.brand_name = @brand";
            }

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    if (!string.IsNullOrEmpty(nameFilter))
                    {
                        cmd.Parameters.AddWithValue("@name", "%" + nameFilter + "%");
                    }

                    if (!string.IsNullOrEmpty(selectedBrand) && selectedBrand != "All Brands")
                    {
                        cmd.Parameters.AddWithValue("@brand", selectedBrand);
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    productsdgv.DataSource = dt;

                    productsdgv.ReadOnly = true;
                    productsdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading products: " + ex.Message);
                }
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void brandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }


        private void sizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure the fragrance name and size are not empty before proceeding
            if (string.IsNullOrEmpty(fragnametxtbox.Text) || sizetxtbox.SelectedIndex == -1)
            {
                // If either the fragrance name or size is not selected, reset the price and show an error
                selectedPrice = 0;  // Reset the price
                label7.Text = "Price(IQD): ";  // Reset the price display
                return;  // Exit the method early
            }

            // If the size is "Full Bottle", use the full bottle logic
            if (sizetxtbox.SelectedItem.ToString() == "full bottle")
            {
                string sizeText = productsdgv.CurrentRow.Cells["Size"].Value?.ToString();
                if (!string.IsNullOrEmpty(sizeText) && int.TryParse(sizeText.Trim(), out int fullSize))
                {
                    object fragIdObj = productsdgv.CurrentRow.Cells["ID"]?.Value;
                    if (fragIdObj != null)
                    {
                        int fragranceId = Convert.ToInt32(fragIdObj);
                        using (MySqlConnection conn = DatabaseHelper.GetConnection())
                        {
                            string query = "SELECT price FROM pricing WHERE frag_id = @fragId AND size = @size LIMIT 1";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@fragId", fragranceId);
                            cmd.Parameters.AddWithValue("@size", fullSize);

                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                selectedPrice = Convert.ToInt32(result);
                                label7.Text = "Price(IQD): "+selectedPrice.ToString("N0");
                            }
                            else
                            {
                                MessageBox.Show("Price not found for this fragrance and full bottle size.");
                                selectedPrice = 0;
                                label7.Text = "Price(IQD): ";
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid size format.");
                    selectedPrice = 0;
                    label7.Text = "Price(IQD): ";
                }
            }
            else
            {
                int selectedSizeValue = 0;
                if (int.TryParse(sizetxtbox.SelectedItem.ToString().Replace("ml", "").Trim(), out selectedSizeValue))
                {
                    object fragIdObj = productsdgv.CurrentRow.Cells["ID"]?.Value;
                    if (fragIdObj != null)
                    {
                        int fragranceId = Convert.ToInt32(fragIdObj);
                        using (MySqlConnection conn = DatabaseHelper.GetConnection())
                        {
                            string query = "SELECT price FROM pricing WHERE frag_id = @fragId AND size = @size LIMIT 1";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@fragId", fragranceId);
                            cmd.Parameters.AddWithValue("@size", selectedSizeValue);

                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                selectedPrice = Convert.ToInt32(result);
                                label7.Text = "Price(IQD): "+selectedPrice.ToString("N0");
                            }
                            else
                            {
                                MessageBox.Show("Price not found for this fragrance and selected size.");
                                selectedPrice = 0;
                                label7.Text = "Price(IQD): ";
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid size selection.");
                    selectedPrice = 0;
                    label7.Text = "Price(IQD): ";
                }
            }
        }

        private void productsdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure that the click is on a valid row (not a header or an invalid cell)
            if (e.RowIndex >= 0)
            {
                // Get the fragrance ID from the clicked row (assuming "ID" is the fragrance ID column)
                object fragIdObj = productsdgv.Rows[e.RowIndex].Cells["ID"]?.Value;
                if (fragIdObj != null)
                {
                    int fragranceId = Convert.ToInt32(fragIdObj);

                    // Get the fragrance name and brand from the clicked row
                    string fragranceName = productsdgv.Rows[e.RowIndex].Cells["Name"]?.Value?.ToString();
                    string brandName = productsdgv.Rows[e.RowIndex].Cells["Brand"]?.Value?.ToString();

                    // Set the fragrance name in the text box
                    fragnametxtbox.Text = fragranceName;

                    // Set the selected brand in the combo box
                    // Ensure the brand exists in the combo box before selecting it
                    if (brandtxtbox.Items.Contains(brandName))
                    {
                        brandtxtbox.SelectedItem = brandName;
                    }
                    else
                    {
                        // Optional: If brand not found in the combo box, you can display an error or add it
                        MessageBox.Show("Brand not found in the combo box.");
                    }

                    // Optionally, you could also set other fields or perform additional actions here
                }
            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            clearfunction();  
        }

        private void clearfunction()
        {
            fragnametxtbox.Clear();


            brandtxtbox.SelectedIndex = -1;


            sizetxtbox.SelectedIndex = -1;


            quantityupdown.Value = 1;

            label7.Text = "Price(IQD): ";
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            if (productsdgv.CurrentRow == null)
            {
                MessageBox.Show("Please select a product from the list.");
                return;
            }

            if (string.IsNullOrWhiteSpace(sizetxtbox.Text) || quantityupdown.Value == 0)
            {
                MessageBox.Show("Please select a size and enter quantity.");
                return;
            }

            if (quantityupdown.Value <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            // Get data from selected product
            int fragranceId = Convert.ToInt32(productsdgv.CurrentRow.Cells["id"].Value);
            string fragranceName = productsdgv.CurrentRow.Cells["Name"].Value.ToString();
            string brand = productsdgv.CurrentRow.Cells["Brand"].Value.ToString();
            string selectedSize = sizetxtbox.Text.Trim().ToLower();
            decimal quantity = quantityupdown.Value;
            decimal priceEach = selectedPrice;
            decimal totalPrice = priceEach * quantity;

            // Handle size formatting
            string finalSize;
            if (selectedSize == "full bottle")
            {
                finalSize = productsdgv.CurrentRow.Cells["size"].Value.ToString(); // already a number like "100"
            }
            else
            {
                // e.g., "3ml" → "3"
                finalSize = new string(selectedSize.Where(char.IsDigit).ToArray());
            }

            // Update total order price
            orderprice += totalPrice;
            label8.Text = "Total Price(IQD): " + orderprice.ToString("N0");

            // Add to order DataGridView
            orderdgv.Rows.Add(fragranceName, brand, finalSize, quantity, priceEach, totalPrice, fragranceId);

            // Clear inputs
            sizetxtbox.SelectedIndex = -1;
            quantityupdown.Value = 1;



            clearfunction();

        }


        private void orderquantitytxtbox_ValueChanged(object sender, EventArgs e)
        {
            label7.Text = "Price(IQD): "+(selectedPrice*quantityupdown.Value).ToString("N0");
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void amounttextbox_TextChanged(object sender, EventArgs e)
        {
            int amount;
            if (int.TryParse(amounttextbox.Text, out amount) || string.IsNullOrEmpty(amounttextbox.Text))
            {
                change = amount - orderprice;
                label10.Text = "Change(IQD): "+change.ToString("N0");
            }
            else
            {
                MessageBox.Show("Please enter a valid number in the amount box.");
            }

        }

        private void paidbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (orderdgv.Rows.Count == 0)
                {
                    MessageBox.Show("The order is empty. Please add items before proceeding.");
                    return; 
                }
                using (MySqlConnection con = DatabaseHelper.GetConnection())
                {
                    string customerName = nametxtbox.Text.Trim();
                    string customerPhone = phonetxtbox.Text.Trim();

                    // Insert Customer
                    MySqlCommand insertCustomer = new MySqlCommand(
                        "INSERT INTO customers (name, phone) VALUES (@name, @phone); SELECT LAST_INSERT_ID();", con);
                    insertCustomer.Parameters.AddWithValue("@name", string.IsNullOrEmpty(customerName) ? DBNull.Value : (object)customerName);
                    insertCustomer.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(customerPhone) ? DBNull.Value : (object)customerPhone);
                    int customerId = Convert.ToInt32(insertCustomer.ExecuteScalar());

                    // Insert Order
                    MySqlCommand insertOrder = new MySqlCommand(
                        "INSERT INTO orders (order_date, total_price, customer_id) VALUES (NOW(), @total, @cust); SELECT LAST_INSERT_ID();", con);
                    insertOrder.Parameters.AddWithValue("@total", orderprice);
                    insertOrder.Parameters.AddWithValue("@cust", customerId);
                    int orderId = Convert.ToInt32(insertOrder.ExecuteScalar());

                    // Collect volume usage per fragrance
                    Dictionary<int, int> volumeUsed = new Dictionary<int, int>();
                    Dictionary<int, int> fragranceQty = new Dictionary<int, int>();

                    foreach (DataGridViewRow row in orderdgv.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int fragranceId = Convert.ToInt32(row.Cells["ID"].Value);
                        int soldSize = Convert.ToInt32(row.Cells["size"].Value); // ml: 3, 5, 10, or full
                        int quantity = Convert.ToInt32(row.Cells["quantity"].Value);
                        decimal price = Convert.ToDecimal(row.Cells["price"].Value);

                        // Insert into order_items
                        MySqlCommand insertDetail = new MySqlCommand(
                            "INSERT INTO order_items (order_id, fragrance_id, size, quantity, price) VALUES (@order, @frag, @size, @qty, @price)", con);
                        insertDetail.Parameters.AddWithValue("@order", orderId);
                        insertDetail.Parameters.AddWithValue("@frag", fragranceId);
                        insertDetail.Parameters.AddWithValue("@size", soldSize);
                        insertDetail.Parameters.AddWithValue("@qty", quantity);
                        insertDetail.Parameters.AddWithValue("@price", price);
                        insertDetail.ExecuteNonQuery();

                        if (soldSize >= 50) // Full bottle
                        {
                            // Decrease stock directly
                            MySqlCommand decreaseStock = new MySqlCommand(
                                "UPDATE history SET stock = stock - @qty WHERE frag_id = @id AND stock > 0 ORDER BY batch_number DESC LIMIT 1", con);
                            decreaseStock.Parameters.AddWithValue("@qty", quantity);
                            decreaseStock.Parameters.AddWithValue("@id", fragranceId);
                            decreaseStock.ExecuteNonQuery();
                        }
                        else
                        {
                            // Accumulate volume usage and quantity
                            if (!volumeUsed.ContainsKey(fragranceId))
                                volumeUsed[fragranceId] = 0;

                            if (!fragranceQty.ContainsKey(fragranceId))
                                fragranceQty[fragranceId] = 0;

                            volumeUsed[fragranceId] += soldSize * quantity;
                            fragranceQty[fragranceId] += quantity;
                        }
                    }

                    // Now update volume & stock for sample-size fragrances
                    foreach (var kvp in volumeUsed)
                    {
                        int fragranceId = kvp.Key;
                        int totalUsedVolume = kvp.Value;

                        // Get current volume and full bottle size
                        MySqlCommand getVolumeCmd = new MySqlCommand(
                            "SELECT volume, size FROM fragrance WHERE frag_id = @id", con);
                        getVolumeCmd.Parameters.AddWithValue("@id", fragranceId);

                        int currentVolume = 0;
                        int fullSize = 0;
                        using (var reader = getVolumeCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                currentVolume = Convert.ToInt32(reader["volume"]);
                                fullSize = Convert.ToInt32(reader["size"]);
                            }
                        }

                        int newVolume = currentVolume - totalUsedVolume;

                        if (newVolume <= 0)
                        {
                            // Decrease stock by 1
                            MySqlCommand decreaseStock = new MySqlCommand(
                                "UPDATE history SET stock = stock - 1 WHERE frag_id = @id AND stock > 0 ORDER BY batch_number DESC LIMIT 1", con);
                            decreaseStock.Parameters.AddWithValue("@id", fragranceId);
                            decreaseStock.ExecuteNonQuery();

                            // Reset volume to fullSize - remainder
                            int remainder = Math.Abs(newVolume);
                            newVolume = fullSize - remainder;
                        }

                        // Update fragrance table with new volume
                        MySqlCommand updateVolume = new MySqlCommand(
                            "UPDATE fragrance SET volume = @vol WHERE frag_id = @id", con);
                        updateVolume.Parameters.AddWithValue("@vol", newVolume);
                        updateVolume.Parameters.AddWithValue("@id", fragranceId);
                        updateVolume.ExecuteNonQuery();
                    }

                    MessageBox.Show("Order completed and saved successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            // Clear UI
            clearfunction();
            amounttextbox.Text = "";
            label10.Text = "Change(IQD): ";
            label8.Text = "Total Price(IQD):";
            orderdgv.Rows.Clear();
            orderprice = 0;
        }






        private void button3_Click(object sender, EventArgs e)
        {
            LoadBrands();
            LoadProducts();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadBrands();
            LoadProducts();
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (orderdgv.CurrentRow != null && !orderdgv.CurrentRow.IsNewRow)
            {
                var confirm = MessageBox.Show("Are you sure you want to remove the selected item?", "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    // Get the price from the selected row
                    object priceObj = orderdgv.CurrentRow.Cells["price"].Value;

                    if (priceObj != null && decimal.TryParse(priceObj.ToString(), out decimal itemPrice))
                    {
                        // Subtract the item's price from the order total
                        orderprice -= itemPrice;
                        label8.Text = "Price(IQD): "+orderprice.ToString("N0");
                    }

                    // Remove the row
                    orderdgv.Rows.Remove(orderdgv.CurrentRow);
                }
            }
            else
            {
                MessageBox.Show("Please select a valid item to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}

