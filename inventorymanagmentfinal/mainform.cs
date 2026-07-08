using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventorymanagmentfinal
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }
        cashierorder cashierorder = new cashierorder(); 
        addfragrance addfragrance = new addfragrance();
        addbrand addbrand = new addbrand();
        adminadduser adminadduser = new adminadduser();
        admindashboard admindashboard = new admindashboard();

            


        private void mainform_Load(object sender, EventArgs e)
        {
            this.Controls.Add(addfragrance);
            this.Controls.Add(adminadduser);
            this.Controls.Add(admindashboard);
            this.Controls.Add(addbrand);
            this.Controls.Add(cashierorder);
            admindashboard.Dock = DockStyle.Fill;
            adminadduser.Dock = DockStyle.Fill;
            addbrand.Dock = DockStyle.Fill;
            addfragrance.Dock = DockStyle.Fill;
            cashierorder.Dock = DockStyle.Fill;
        }


        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(117, 145, 105);
            button2.BackColor = Color.FromArgb(85, 113, 73);
            button3.BackColor = Color.FromArgb(85, 113, 73);
            button4.BackColor = Color.FromArgb(85, 113, 73);
            button5.BackColor = Color.FromArgb(85, 113, 73);

            admindashboard.BringToFront();
            admindashboard.Visible = true;
            adminadduser.Visible = false;
            addbrand.Visible = false;
            addfragrance.Visible = false;
            cashierorder.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(85, 113, 73);
            button2.BackColor = Color.FromArgb(117, 145, 105);
            button3.BackColor = Color.FromArgb(85, 113, 73);
            button4.BackColor = Color.FromArgb(85, 113, 73);
            button5.BackColor = Color.FromArgb(85, 113, 73);
            adminadduser.BringToFront();
            admindashboard.Visible = false;
            adminadduser.Visible = true;
            addbrand.Visible = false;
            addfragrance.Visible = false;
            cashierorder.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(85, 113, 73);
            button3.BackColor = Color.FromArgb(117, 145, 105);
            button2.BackColor = Color.FromArgb(85, 113, 73);
            button4.BackColor = Color.FromArgb(85, 113, 73);
            button5.BackColor = Color.FromArgb(85, 113, 73);
            addbrand.BringToFront();
            admindashboard.Visible = false;
            adminadduser.Visible = false;
            addbrand.Visible = true;
            addfragrance.Visible = false;
            cashierorder.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(85, 113, 73);
            button4.BackColor = Color.FromArgb(117, 145, 105);
            button3.BackColor = Color.FromArgb(85, 113, 73);
            button2.BackColor = Color.FromArgb(85, 113, 73);
            button5.BackColor = Color.FromArgb(85, 113, 73);
            addfragrance.BringToFront();
            admindashboard.Visible = false;
            adminadduser.Visible = false;
            addbrand.Visible = false;
            addfragrance.Visible = true;
            cashierorder.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(85, 113, 73);
            button5.BackColor = Color.FromArgb(117, 145, 105);
            button3.BackColor = Color.FromArgb(85, 113, 73);
            button4.BackColor = Color.FromArgb(85, 113, 73);
            button2.BackColor = Color.FromArgb(85, 113, 73);
            cashierorder.BringToFront();  // later to do customer user control
            admindashboard.Visible = false;
            adminadduser.Visible = false;
            addbrand.Visible = false;
            addfragrance.Visible = false;
            cashierorder.Visible = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 loginform = new Form1();
            loginform.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
        
        }

        private void reportbtn_Click(object sender, EventArgs e)
        {
            Form2 reportform = new Form2();
            reportform.ShowDialog();
           
            
        }
    }
}
