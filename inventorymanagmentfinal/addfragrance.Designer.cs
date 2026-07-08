namespace inventorymanagmentfinal
{
    partial class addfragrance
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.fragdgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sizecombobox = new System.Windows.Forms.ComboBox();
            this.intensitycombobox = new System.Windows.Forms.ComboBox();
            this.brandcombobox = new System.Windows.Forms.ComboBox();
            this.fivemlpricetxtbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.costtxtbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.threemlpricetxtbox = new System.Windows.Forms.TextBox();
            this.stocktxtbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tenmlpricetxtbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fullpricetxtbox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.fragnametxtbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clearbtn = new System.Windows.Forms.Button();
            this.removebtn = new System.Windows.Forms.Button();
            this.updatebtn = new System.Windows.Forms.Button();
            this.addbtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fragdgv)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.fragdgv);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1120, 347);
            this.panel1.TabIndex = 0;
            // 
            // fragdgv
            // 
            this.fragdgv.AllowUserToAddRows = false;
            this.fragdgv.AllowUserToDeleteRows = false;
            this.fragdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fragdgv.Location = new System.Drawing.Point(18, 38);
            this.fragdgv.Name = "fragdgv";
            this.fragdgv.ReadOnly = true;
            this.fragdgv.Size = new System.Drawing.Size(1080, 295);
            this.fragdgv.TabIndex = 1;
            this.fragdgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fragdgv_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "All Products";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.sizecombobox);
            this.panel2.Controls.Add(this.intensitycombobox);
            this.panel2.Controls.Add(this.brandcombobox);
            this.panel2.Controls.Add(this.fivemlpricetxtbox);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.costtxtbox);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.threemlpricetxtbox);
            this.panel2.Controls.Add(this.stocktxtbox);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tenmlpricetxtbox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.fullpricetxtbox);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.fragnametxtbox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.clearbtn);
            this.panel2.Controls.Add(this.removebtn);
            this.panel2.Controls.Add(this.updatebtn);
            this.panel2.Controls.Add(this.addbtn);
            this.panel2.Location = new System.Drawing.Point(12, 371);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1120, 354);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::inventorymanagmentfinal.Properties.Resources.Sync;
            this.pictureBox1.Location = new System.Drawing.Point(1031, 262);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // sizecombobox
            // 
            this.sizecombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizecombobox.FormattingEnabled = true;
            this.sizecombobox.Items.AddRange(new object[] {
            "50ml",
            "75ml",
            "100ml",
            "125ml",
            "150ml",
            "200ml"});
            this.sizecombobox.Location = new System.Drawing.Point(374, 90);
            this.sizecombobox.Name = "sizecombobox";
            this.sizecombobox.Size = new System.Drawing.Size(181, 26);
            this.sizecombobox.TabIndex = 3;
            // 
            // intensitycombobox
            // 
            this.intensitycombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intensitycombobox.FormattingEnabled = true;
            this.intensitycombobox.Items.AddRange(new object[] {
            "EDT",
            "EDP",
            "PARFUM"});
            this.intensitycombobox.Location = new System.Drawing.Point(80, 213);
            this.intensitycombobox.Name = "intensitycombobox";
            this.intensitycombobox.Size = new System.Drawing.Size(181, 26);
            this.intensitycombobox.TabIndex = 2;
            // 
            // brandcombobox
            // 
            this.brandcombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brandcombobox.FormattingEnabled = true;
            this.brandcombobox.Location = new System.Drawing.Point(80, 155);
            this.brandcombobox.Name = "brandcombobox";
            this.brandcombobox.Size = new System.Drawing.Size(181, 26);
            this.brandcombobox.TabIndex = 1;
            this.brandcombobox.SelectedIndexChanged += new System.EventHandler(this.brandcombobox_SelectedIndexChanged);
            // 
            // fivemlpricetxtbox
            // 
            this.fivemlpricetxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fivemlpricetxtbox.Location = new System.Drawing.Point(645, 213);
            this.fivemlpricetxtbox.Name = "fivemlpricetxtbox";
            this.fivemlpricetxtbox.Size = new System.Drawing.Size(181, 26);
            this.fivemlpricetxtbox.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(642, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 18);
            this.label10.TabIndex = 1;
            this.label10.Text = "5ml price:";
            // 
            // costtxtbox
            // 
            this.costtxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costtxtbox.Location = new System.Drawing.Point(374, 213);
            this.costtxtbox.Name = "costtxtbox";
            this.costtxtbox.Size = new System.Drawing.Size(181, 26);
            this.costtxtbox.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(371, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "Cost:";
            // 
            // threemlpricetxtbox
            // 
            this.threemlpricetxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.threemlpricetxtbox.Location = new System.Drawing.Point(645, 150);
            this.threemlpricetxtbox.Name = "threemlpricetxtbox";
            this.threemlpricetxtbox.Size = new System.Drawing.Size(181, 26);
            this.threemlpricetxtbox.TabIndex = 7;
            // 
            // stocktxtbox
            // 
            this.stocktxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stocktxtbox.Location = new System.Drawing.Point(374, 150);
            this.stocktxtbox.Name = "stocktxtbox";
            this.stocktxtbox.Size = new System.Drawing.Size(181, 26);
            this.stocktxtbox.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(642, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 18);
            this.label9.TabIndex = 1;
            this.label9.Text = "3ml price:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(77, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Intensity:";
            // 
            // tenmlpricetxtbox
            // 
            this.tenmlpricetxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenmlpricetxtbox.Location = new System.Drawing.Point(885, 89);
            this.tenmlpricetxtbox.Name = "tenmlpricetxtbox";
            this.tenmlpricetxtbox.Size = new System.Drawing.Size(181, 26);
            this.tenmlpricetxtbox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(371, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 18);
            this.label6.TabIndex = 1;
            this.label6.Text = "Stock:";
            // 
            // fullpricetxtbox
            // 
            this.fullpricetxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullpricetxtbox.Location = new System.Drawing.Point(645, 89);
            this.fullpricetxtbox.Name = "fullpricetxtbox";
            this.fullpricetxtbox.Size = new System.Drawing.Size(181, 26);
            this.fullpricetxtbox.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(882, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 18);
            this.label11.TabIndex = 1;
            this.label11.Text = "10ml price:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(642, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 18);
            this.label8.TabIndex = 1;
            this.label8.Text = "Full bottle price:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Brand:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(371, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Size:";
            // 
            // fragnametxtbox
            // 
            this.fragnametxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fragnametxtbox.Location = new System.Drawing.Point(80, 89);
            this.fragnametxtbox.Name = "fragnametxtbox";
            this.fragnametxtbox.Size = new System.Drawing.Size(181, 26);
            this.fragnametxtbox.TabIndex = 0;
            this.fragnametxtbox.TextChanged += new System.EventHandler(this.fragnametxtbox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fragrance Name:";
            // 
            // clearbtn
            // 
            this.clearbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.clearbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearbtn.ForeColor = System.Drawing.Color.White;
            this.clearbtn.Location = new System.Drawing.Point(876, 278);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(140, 43);
            this.clearbtn.TabIndex = 13;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = false;
            this.clearbtn.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // removebtn
            // 
            this.removebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.removebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removebtn.ForeColor = System.Drawing.Color.White;
            this.removebtn.Location = new System.Drawing.Point(645, 278);
            this.removebtn.Name = "removebtn";
            this.removebtn.Size = new System.Drawing.Size(140, 43);
            this.removebtn.TabIndex = 12;
            this.removebtn.Text = "Remove";
            this.removebtn.UseVisualStyleBackColor = false;
            this.removebtn.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // updatebtn
            // 
            this.updatebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.updatebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updatebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatebtn.ForeColor = System.Drawing.Color.White;
            this.updatebtn.Location = new System.Drawing.Point(374, 278);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(140, 43);
            this.updatebtn.TabIndex = 11;
            this.updatebtn.Text = "Update";
            this.updatebtn.UseVisualStyleBackColor = false;
            this.updatebtn.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // addbtn
            // 
            this.addbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.addbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbtn.ForeColor = System.Drawing.Color.White;
            this.addbtn.Location = new System.Drawing.Point(121, 278);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(140, 43);
            this.addbtn.TabIndex = 10;
            this.addbtn.Text = "Add";
            this.addbtn.UseVisualStyleBackColor = false;
            this.addbtn.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // addfragrance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "addfragrance";
            this.Size = new System.Drawing.Size(1148, 741);
            this.Load += new System.EventHandler(this.addfragrance_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fragdgv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView fragdgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button removebtn;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.ComboBox sizecombobox;
        private System.Windows.Forms.ComboBox intensitycombobox;
        private System.Windows.Forms.ComboBox brandcombobox;
        private System.Windows.Forms.TextBox fivemlpricetxtbox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox costtxtbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox threemlpricetxtbox;
        private System.Windows.Forms.TextBox stocktxtbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tenmlpricetxtbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fullpricetxtbox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fragnametxtbox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
