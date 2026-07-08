using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;

namespace inventorymanagmentfinal
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT name, brand_name from fragrance join brand on fragrance.brand_id = brand.brand_id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    { 
                    DataTable dt = new DataTable();
                        dt.Load(reader);

                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.ReportPath = "D:\\universitystuff\\software engineering\\New folder\\inventorymanagmentfinal\\inventorymanagmentfinal\\Report1.rdlc";

                        ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                        reportViewer1.LocalReport.DataSources.Add(ds);
                        reportViewer1.RefreshReport();
                    }
                }
            }

        }
    }
}
