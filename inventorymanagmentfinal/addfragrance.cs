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
    public partial class addfragrance : UserControl
    {
       
        private int selectedFragranceID = 0;

        public addfragrance()
        {
            InitializeComponent();
            LoadBrandNames();
            LoadFragrancesToGrid();
        }

       
        private void LoadBrandNames()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT brand_id, brand_name FROM brand";
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);

                    brandcombobox.DataSource = dt;
                    brandcombobox.DisplayMember = "brand_name";
                    brandcombobox.ValueMember = "brand_id";
                    brandcombobox.SelectedIndex = -1; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading brands: " + ex.Message);
            }
        }

        // Load fragrances into the DataGridView
        private void LoadFragrancesToGrid(string brandFilter = "", string nameFilter = "")
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    string query = @"
                SELECT 
                    f.frag_id AS ID,
                    f.name AS Name,
                    b.brand_id AS BrandID,
                    b.brand_name AS Brand,
                    h.cost_price AS Cost,
                    f.size AS Size,
                    IFNULL(h.stock, 0) AS Stock,
                    f.intensity AS Intensity,
                    (SELECT price FROM pricing WHERE frag_id = f.frag_id AND size = 3 LIMIT 1) AS Price_3ml,
                    (SELECT price FROM pricing WHERE frag_id = f.frag_id AND size = 5 LIMIT 1) AS Price_5ml,
                    (SELECT price FROM pricing WHERE frag_id = f.frag_id AND size = 10 LIMIT 1) AS Price_10ml,
                    (SELECT price FROM pricing WHERE frag_id = f.frag_id AND size >= 50 ORDER BY size LIMIT 1) AS Full_Bottle_Price
                FROM 
                    fragrance f
                JOIN 
                    brand b ON f.brand_id = b.brand_id
                LEFT JOIN 
                    history h ON f.frag_id = h.frag_id
                WHERE 
                    (@Brand = '' OR b.brand_id = @Brand)  -- Corrected to filter by brand_id
                    AND (@Name = '' OR f.name LIKE CONCAT('%', @Name, '%'))
            ";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // If the selected brand is not empty, use its ID for filtering
                    if (int.TryParse(brandFilter, out int brandId) && brandId > 0)
                    {
                        cmd.Parameters.AddWithValue("@Brand", brandId);  // Use the brand_id for filtering
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Brand", "");  // No filter applied if no brand is selected
                    }

                    cmd.Parameters.AddWithValue("@Name", nameFilter);  // Filter by name as before

                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);

                    fragdgv.DataSource = dt;
                    fragdgv.ClearSelection();  // Prevent auto-selection of the first row
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading fragrances: " + ex.Message);
            }
        }





        private void brandcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected brand id (not the name)
            string selectedBrand = brandcombobox.SelectedValue?.ToString() ?? "";  // Brand ID as string
            string nameFilter = fragnametxtbox.Text;  // Get text from the fragrance name textbox

            // Apply the filters to the DataGridView
            LoadFragrancesToGrid(selectedBrand, nameFilter);
        }


        private void fragnametxtbox_TextChanged(object sender, EventArgs e)
        {
            // Get the selected brand name
            string selectedBrand = brandcombobox.SelectedItem?.ToString() ?? "";  // Empty if no selection
            string nameFilter = fragnametxtbox.Text;  // Get the text from the name textbox

            // Apply the filters to the DataGridView
            LoadFragrancesToGrid(selectedBrand, nameFilter);
        }





        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 1. Validate required fields
            if (string.IsNullOrEmpty(fragnametxtbox.Text) ||
                brandcombobox.SelectedIndex == -1 ||
                intensitycombobox.SelectedIndex == -1 ||
                sizecombobox.SelectedIndex == -1 ||
                string.IsNullOrEmpty(fullpricetxtbox.Text) ||
                string.IsNullOrEmpty(costtxtbox.Text) ||
                string.IsNullOrEmpty(threemlpricetxtbox.Text) ||
                string.IsNullOrEmpty(fivemlpricetxtbox.Text) ||
                string.IsNullOrEmpty(tenmlpricetxtbox.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // 2. Extract brand ID
            if (!int.TryParse(brandcombobox.SelectedValue?.ToString(), out int brandID))
            {
                MessageBox.Show("Invalid brand selection.");
                return;
            }

            // 3. Extract numeric size from string (e.g., "100 ml" -> 100)
            string sizeString = sizecombobox.SelectedItem.ToString();
            if (!int.TryParse(Regex.Match(sizeString, @"\d+").Value, out int size))
            {
                MessageBox.Show("Invalid size format.");
                return;
            }

            // 4. Parse price and cost
            if (!decimal.TryParse(fullpricetxtbox.Text, out decimal fullPrice) ||
                !decimal.TryParse(costtxtbox.Text, out decimal costPrice) ||
                !decimal.TryParse(threemlpricetxtbox.Text, out decimal price3ml) ||
                !decimal.TryParse(fivemlpricetxtbox.Text, out decimal price5ml) ||
                !decimal.TryParse(tenmlpricetxtbox.Text, out decimal price10ml))
            {
                MessageBox.Show("Please enter valid prices.");
                return;
            }

            // 5. Parse stock
            if (!int.TryParse(stocktxtbox.Text, out int stock))
            {
                stock = 0; // Default to 0 if not provided
            }

            string fragranceName = fragnametxtbox.Text.Trim();
            string intensity = intensitycombobox.SelectedItem.ToString();

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    using (var transaction = conn.BeginTransaction())
                    {
                        // 6. Insert fragrance
                        string insertFragranceQuery = @"
                    INSERT INTO fragrance (name, brand_id, intensity, size, volume)
                    VALUES (@Name, @BrandID, @Intensity, @Size, @Volume)";
                        using (var cmd = new MySqlCommand(insertFragranceQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Name", fragranceName);
                            cmd.Parameters.AddWithValue("@BrandID", brandID);
                            cmd.Parameters.AddWithValue("@Intensity", intensity);
                            cmd.Parameters.AddWithValue("@Size", size);
                            cmd.Parameters.AddWithValue("@Volume", size);

                            cmd.ExecuteNonQuery();
                        }

                        // 7. Get frag_id
                        int fragId = Convert.ToInt32(new MySqlCommand("SELECT LAST_INSERT_ID()", conn, transaction).ExecuteScalar());

                        // 8. Determine batch number
                        int batchNumber = 1;
                        string batchQuery = @"
                    SELECT 
                        MAX(CAST(batch_number AS UNSIGNED)) AS max_batch,
                        COALESCE(SUM(stock), 0) AS total_stock
                    FROM history
                    WHERE frag_id IN (
                        SELECT frag_id FROM fragrance
                        WHERE name = @Name AND brand_id = @BrandID
                        AND intensity = @Intensity AND size = @Size
                    )";
                        using (var batchCmd = new MySqlCommand(batchQuery, conn, transaction))
                        {
                            batchCmd.Parameters.AddWithValue("@Name", fragranceName);
                            batchCmd.Parameters.AddWithValue("@BrandID", brandID);
                            batchCmd.Parameters.AddWithValue("@Intensity", intensity);
                            batchCmd.Parameters.AddWithValue("@Size", size);

                            using (var reader = batchCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    long maxBatch = reader["max_batch"] != DBNull.Value ? Convert.ToInt64(reader["max_batch"]) : 0;
                                    int totalStock = Convert.ToInt32(reader["total_stock"]);
                                    batchNumber = (totalStock > 0) ? (int)maxBatch + 1 : 1;
                                }
                            }
                        }

                        // 9. Insert into history (with CURDATE for purchase_date and exp_date)
                        string insertHistoryQuery = @"
                    INSERT INTO history 
                    (frag_id, batch_number, cost_price, stock, purchase_date, exp_date)
                    VALUES 
                    (@FragID, @BatchNumber, @CostPrice, @Stock, CURDATE(), DATE_ADD(CURDATE(), INTERVAL 4 YEAR))";
                        using (var historyCmd = new MySqlCommand(insertHistoryQuery, conn, transaction))
                        {
                            historyCmd.Parameters.AddWithValue("@FragID", fragId);
                            historyCmd.Parameters.AddWithValue("@BatchNumber", batchNumber);
                            historyCmd.Parameters.AddWithValue("@CostPrice", costPrice);
                            historyCmd.Parameters.AddWithValue("@Stock", stock);
                            historyCmd.ExecuteNonQuery();
                        }

                        // 10. Insert prices for 3ml, 5ml, 10ml, full
                        string insertPricingQuery = @"
                    INSERT INTO pricing (frag_id, size, price) 
                    VALUES (@FragID, @Size, @Price)";
                        using (var pricingCmd = new MySqlCommand(insertPricingQuery, conn, transaction))
                        {
                            pricingCmd.Parameters.Add("@FragID", MySqlDbType.Int32).Value = fragId;
                            pricingCmd.Parameters.Add("@Size", MySqlDbType.Int32);
                            pricingCmd.Parameters.Add("@Price", MySqlDbType.Int32);

                            // 3ml
                            pricingCmd.Parameters["@Size"].Value = 3;
                            pricingCmd.Parameters["@Price"].Value = (int)price3ml;
                            pricingCmd.ExecuteNonQuery();

                            // 5ml
                            pricingCmd.Parameters["@Size"].Value = 5;
                            pricingCmd.Parameters["@Price"].Value = (int)price5ml;
                            pricingCmd.ExecuteNonQuery();

                            // 10ml
                            pricingCmd.Parameters["@Size"].Value = 10;
                            pricingCmd.Parameters["@Price"].Value = (int)price10ml;
                            pricingCmd.ExecuteNonQuery();

                            // Full size
                            pricingCmd.Parameters["@Size"].Value = size;
                            pricingCmd.Parameters["@Price"].Value = (int)fullPrice;
                            pricingCmd.ExecuteNonQuery();
                        }

                        // 11. Commit transaction
                        transaction.Commit();
                        MessageBox.Show("Fragrance added successfully!");
                        LoadFragrancesToGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        // DataGridView cell click event
        private void fragdgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user clicked a valid row (not header or out of range)
            if (e.RowIndex < 0 || e.RowIndex >= fragdgv.Rows.Count)
                return;

            try
            {
                DataGridViewRow row = fragdgv.Rows[e.RowIndex];

                // Safely read each value
                object idValue = row.Cells["ID"].Value;
                object nameValue = row.Cells["name"].Value;
                object brandValue = row.Cells["BrandID"].Value;
                object intensityValue = row.Cells["intensity"].Value;
                object stockValue = row.Cells["stock"].Value;
                object sizeValue = row.Cells["size"].Value;

                if (idValue == null || idValue == DBNull.Value)
                    return;

                // Set fragrance ID
                selectedFragranceID = Convert.ToInt32(idValue);

                // Set name
                fragnametxtbox.Text = nameValue?.ToString() ?? "";

                // Set brand (make sure the ComboBox has its ValueMember set to "BrandID")
                if (brandValue != null && brandValue != DBNull.Value)
                    brandcombobox.SelectedValue = Convert.ToInt32(brandValue);

                // Set intensity
                intensitycombobox.SelectedItem = intensityValue?.ToString();

                // Set stock
                stocktxtbox.Text = stockValue?.ToString() ?? "0";

                // Set size (ComboBox expects like "100ml")
                if (sizeValue != null && sizeValue != DBNull.Value)
                {
                    string sizeStr = sizeValue.ToString().Trim();
                    sizecombobox.SelectedItem = sizeStr + "ml";
                }

                // Load pricing & cost info from DB
                LoadPricingAndCostDetails(selectedFragranceID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading row data: " + ex.Message);
            }
        }





        private void LoadPricingAndCostDetails(int fragId)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    // Query to load pricing data based on frag_id
                    string pricingQuery = @"
            SELECT size, price, 
                   MAX(CASE WHEN size >= 50 THEN size END) AS Full_Bottle_Size
            FROM pricing
            WHERE frag_id = @FragId
            GROUP BY size, price";

                    MySqlCommand pricingCmd = new MySqlCommand(pricingQuery, conn);
                    pricingCmd.Parameters.AddWithValue("@FragId", fragId);

                    MySqlDataReader pricingReader = pricingCmd.ExecuteReader();
                    while (pricingReader.Read())
                    {
                        string size = pricingReader["size"].ToString();
                        decimal price = Convert.ToDecimal(pricingReader["price"]);
                        string fullBottleSize = pricingReader["Full_Bottle_Size"].ToString();

                        // Set the price for the specific size in the textboxes
                        if (size == "3") // 3 ml
                            threemlpricetxtbox.Text = price.ToString();
                        else if (size == "5") // 5 ml
                            fivemlpricetxtbox.Text = price.ToString();
                        else if (size == "10") // 10 ml
                            tenmlpricetxtbox.Text = price.ToString();
                        else // Full Bottle (other sizes like 50, 100, etc.)
                            fullpricetxtbox.Text = price.ToString();

                        // Set the full bottle size in the combo box (if available)
                        if (!string.IsNullOrEmpty(fullBottleSize))
                        {
                            sizecombobox.SelectedItem = fullBottleSize + " ml"; // Assuming the combo box expects the size in ml
                        }
                    }

                    pricingReader.Close();

                    // Query to load the cost from history table for the selected fragrance
                    string costQuery = @"
            SELECT cost_price
            FROM history
            WHERE frag_id = @FragId
            ORDER BY batch_number DESC
            LIMIT 1"; // Assuming you want the most recent batch cost

                    MySqlCommand costCmd = new MySqlCommand(costQuery, conn);
                    costCmd.Parameters.AddWithValue("@FragId", fragId);

                    var cost = costCmd.ExecuteScalar();
                    if (cost != DBNull.Value)
                        costtxtbox.Text = Convert.ToDecimal(cost).ToString();
                    else
                        costtxtbox.Text = "0"; // If no cost is found, set it to 0
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading pricing and cost details: " + ex.Message);
            }
        }




        // Update fragrance
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedFragranceID == 0)
            {
                MessageBox.Show("Please select a fragrance to update.");
                return;
            }

            // Validate required fields
            if (string.IsNullOrEmpty(fragnametxtbox.Text) ||
                brandcombobox.SelectedIndex == -1 ||
                intensitycombobox.SelectedIndex == -1 ||
                sizecombobox.SelectedIndex == -1 ||
                string.IsNullOrEmpty(fullpricetxtbox.Text) ||
                string.IsNullOrEmpty(costtxtbox.Text) ||
                string.IsNullOrEmpty(threemlpricetxtbox.Text) ||
                string.IsNullOrEmpty(fivemlpricetxtbox.Text) ||
                string.IsNullOrEmpty(tenmlpricetxtbox.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            string fragranceName = fragnametxtbox.Text.Trim();
            string intensity = intensitycombobox.SelectedItem.ToString();

            // Parse brand ID and size
            if (!int.TryParse(brandcombobox.SelectedValue?.ToString(), out int brandID))
            {
                MessageBox.Show("Invalid brand.");
                return;
            }

            if (!int.TryParse(Regex.Match(sizecombobox.SelectedItem.ToString(), @"\d+").Value, out int size))
            {
                MessageBox.Show("Invalid size.");
                return;
            }

            if (!decimal.TryParse(fullpricetxtbox.Text, out decimal fullPrice) ||
                !decimal.TryParse(costtxtbox.Text, out decimal costPrice) ||
                !decimal.TryParse(threemlpricetxtbox.Text, out decimal price3ml) ||
                !decimal.TryParse(fivemlpricetxtbox.Text, out decimal price5ml) ||
                !decimal.TryParse(tenmlpricetxtbox.Text, out decimal price10ml))
            {
                MessageBox.Show("Please enter valid prices.");
                return;
            }

            if (!int.TryParse(stocktxtbox.Text, out int stock))
            {
                stock = 0;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    using (var transaction = conn.BeginTransaction())
                    {
                        // 1. Update fragrance details
                        string updateFragranceQuery = @"
                    UPDATE fragrance
                    SET name = @Name,
                        brand_id = @BrandID,
                        intensity = @Intensity,
                        size = @Size
                    WHERE frag_id = @FragId";
                        using (var cmd = new MySqlCommand(updateFragranceQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Name", fragranceName);
                            cmd.Parameters.AddWithValue("@BrandID", brandID);
                            cmd.Parameters.AddWithValue("@Intensity", intensity);
                            cmd.Parameters.AddWithValue("@Size", size);
                            cmd.Parameters.AddWithValue("@FragId", selectedFragranceID);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Get latest batch number
                        int latestBatch = 0;
                        string getBatchQuery = @"
                    SELECT MAX(CAST(batch_number AS UNSIGNED)) 
                    FROM history 
                    WHERE frag_id = @FragID";
                        using (var batchCmd = new MySqlCommand(getBatchQuery, conn, transaction))
                        {
                            batchCmd.Parameters.AddWithValue("@FragID", selectedFragranceID);
                            var result = batchCmd.ExecuteScalar();
                            if (result != DBNull.Value)
                            {
                                latestBatch = Convert.ToInt32(result);
                            }
                        }

                        // 3. Update history entry (cost & stock)
                        string updateHistoryQuery = @"
                    UPDATE history
                    SET cost_price = @CostPrice,
                        stock = @Stock
                    WHERE frag_id = @FragID 
                      AND batch_number = @BatchNumber";
                        using (var histCmd = new MySqlCommand(updateHistoryQuery, conn, transaction))
                        {
                            histCmd.Parameters.AddWithValue("@CostPrice", costPrice);
                            histCmd.Parameters.AddWithValue("@Stock", stock);
                            histCmd.Parameters.AddWithValue("@FragID", selectedFragranceID);
                            histCmd.Parameters.AddWithValue("@BatchNumber", latestBatch);
                            histCmd.ExecuteNonQuery();
                        }

                        // 4. Delete existing pricing entries
                        string deletePricingQuery = "DELETE FROM pricing WHERE frag_id = @FragID";
                        using (var deleteCmd = new MySqlCommand(deletePricingQuery, conn, transaction))
                        {
                            deleteCmd.Parameters.AddWithValue("@FragID", selectedFragranceID);
                            deleteCmd.ExecuteNonQuery();
                        }

                        // 5. Insert updated pricing
                        string insertPricingQuery = @"
                    INSERT INTO pricing (frag_id, size, price) 
                    VALUES (@FragID, @Size, @Price)";
                        using (var pricingCmd = new MySqlCommand(insertPricingQuery, conn, transaction))
                        {
                            pricingCmd.Parameters.Add("@FragID", MySqlDbType.Int32).Value = selectedFragranceID;
                            pricingCmd.Parameters.Add("@Size", MySqlDbType.Int32);
                            pricingCmd.Parameters.Add("@Price", MySqlDbType.Int32);

                            // 3ml
                            pricingCmd.Parameters["@Size"].Value = 3;
                            pricingCmd.Parameters["@Price"].Value = (int)price3ml;
                            pricingCmd.ExecuteNonQuery();

                            // 5ml
                            pricingCmd.Parameters["@Size"].Value = 5;
                            pricingCmd.Parameters["@Price"].Value = (int)price5ml;
                            pricingCmd.ExecuteNonQuery();

                            // 10ml
                            pricingCmd.Parameters["@Size"].Value = 10;
                            pricingCmd.Parameters["@Price"].Value = (int)price10ml;
                            pricingCmd.ExecuteNonQuery();

                            // Full bottle
                            pricingCmd.Parameters["@Size"].Value = size;
                            pricingCmd.Parameters["@Price"].Value = (int)fullPrice;
                            pricingCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Fragrance updated successfully!");
                        LoadFragrancesToGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating fragrance: " + ex.Message);
            }
        }



        // Remove fragrance
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (selectedFragranceID == 0)
            {
                MessageBox.Show("Please select a fragrance to remove.");
                return;
            }

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {

                    string deleteQuery = "DELETE FROM fragrance WHERE frag_id = @FragId";
                    using (var cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@FragId", selectedFragranceID);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Fragrance removed successfully!");
                    LoadFragrancesToGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing fragrance: " + ex.Message);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            selectedFragranceID = 0;
            fragnametxtbox.Clear();
            brandcombobox.SelectedIndex = -1;
            intensitycombobox.SelectedIndex = -1;
            stocktxtbox.Clear();
            fullpricetxtbox.Clear();
            threemlpricetxtbox.Clear();
            fivemlpricetxtbox.Clear();
            tenmlpricetxtbox.Clear();
            fragdgv.ClearSelection();
            costtxtbox.Clear();
            sizecombobox.SelectedIndex = -1;
            selectedFragranceID = 0;

        }

        private void addfragrance_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadFragrancesToGrid();
            LoadBrandNames();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadFragrancesToGrid();
            LoadBrandNames();
        }
    }
}
