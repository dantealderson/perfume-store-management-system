namespace inventorymanagmentfinal
{
    partial class registerform
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.RegUsername = new System.Windows.Forms.TextBox();
            this.RegPassword2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.closedeye2 = new System.Windows.Forms.PictureBox();
            this.closedeye1 = new System.Windows.Forms.PictureBox();
            this.openeye2 = new System.Windows.Forms.PictureBox();
            this.openeye1 = new System.Windows.Forms.PictureBox();
            this.fradio = new System.Windows.Forms.RadioButton();
            this.mradio = new System.Windows.Forms.RadioButton();
            this.RegPnu = new System.Windows.Forms.TextBox();
            this.RegPassword = new System.Windows.Forms.TextBox();
            this.RegLN = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.RegFN = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closedeye2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closedeye1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openeye2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openeye1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::inventorymanagmentfinal.Properties.Resources.Male_User;
            this.pictureBox1.Location = new System.Drawing.Point(314, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 82);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(278, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "Register Account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sans Serif Collection", 9.749998F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(228, 471);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 44);
            this.label2.TabIndex = 7;
            this.label2.Text = "already have an account?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sans Serif Collection", 9.749998F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(387, 471);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 44);
            this.label3.TabIndex = 6;
            this.label3.Text = "login";
            this.label3.Enter += new System.EventHandler(this.LoginLabel_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::inventorymanagmentfinal.Properties.Resources.User;
            this.pictureBox2.Location = new System.Drawing.Point(209, 250);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 26);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::inventorymanagmentfinal.Properties.Resources.Lock;
            this.pictureBox3.Location = new System.Drawing.Point(209, 373);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(26, 26);
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // RegUsername
            // 
            this.RegUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegUsername.ForeColor = System.Drawing.Color.Gray;
            this.RegUsername.Location = new System.Drawing.Point(241, 250);
            this.RegUsername.Name = "RegUsername";
            this.RegUsername.Size = new System.Drawing.Size(227, 26);
            this.RegUsername.TabIndex = 2;
            this.RegUsername.Text = "UserName";
            this.RegUsername.Enter += new System.EventHandler(this.RegUsername_Enter);
            this.RegUsername.Leave += new System.EventHandler(this.RegUsername_Leave);
            // 
            // RegPassword2
            // 
            this.RegPassword2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegPassword2.ForeColor = System.Drawing.Color.Gray;
            this.RegPassword2.Location = new System.Drawing.Point(241, 373);
            this.RegPassword2.Name = "RegPassword2";
            this.RegPassword2.Size = new System.Drawing.Size(227, 26);
            this.RegPassword2.TabIndex = 5;
            this.RegPassword2.Text = "Confirm Password";
            this.RegPassword2.Enter += new System.EventHandler(this.RegPassword2_Enter);
            this.RegPassword2.Leave += new System.EventHandler(this.RegPassword2_Leave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(241, 428);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Enter += new System.EventHandler(this.SignupBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.closedeye2);
            this.panel1.Controls.Add(this.closedeye1);
            this.panel1.Controls.Add(this.openeye2);
            this.panel1.Controls.Add(this.openeye1);
            this.panel1.Controls.Add(this.fradio);
            this.panel1.Controls.Add(this.mradio);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.RegPnu);
            this.panel1.Controls.Add(this.RegPassword);
            this.panel1.Controls.Add(this.RegPassword2);
            this.panel1.Controls.Add(this.RegLN);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.RegFN);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.RegUsername);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(55, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 506);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // closedeye2
            // 
            this.closedeye2.Image = global::inventorymanagmentfinal.Properties.Resources.Closed_Eye;
            this.closedeye2.Location = new System.Drawing.Point(484, 373);
            this.closedeye2.Name = "closedeye2";
            this.closedeye2.Size = new System.Drawing.Size(26, 26);
            this.closedeye2.TabIndex = 16;
            this.closedeye2.TabStop = false;
            this.closedeye2.Visible = false;
            this.closedeye2.Click += new System.EventHandler(this.closedeye2_Click);
            // 
            // closedeye1
            // 
            this.closedeye1.Image = global::inventorymanagmentfinal.Properties.Resources.Closed_Eye;
            this.closedeye1.Location = new System.Drawing.Point(484, 332);
            this.closedeye1.Name = "closedeye1";
            this.closedeye1.Size = new System.Drawing.Size(26, 26);
            this.closedeye1.TabIndex = 16;
            this.closedeye1.TabStop = false;
            this.closedeye1.Click += new System.EventHandler(this.closedeye1_Click);
            // 
            // openeye2
            // 
            this.openeye2.Image = global::inventorymanagmentfinal.Properties.Resources.Eye;
            this.openeye2.Location = new System.Drawing.Point(484, 373);
            this.openeye2.Name = "openeye2";
            this.openeye2.Size = new System.Drawing.Size(26, 26);
            this.openeye2.TabIndex = 17;
            this.openeye2.TabStop = false;
            this.openeye2.Visible = false;
            this.openeye2.Click += new System.EventHandler(this.openeye2_Click);
            // 
            // openeye1
            // 
            this.openeye1.Image = global::inventorymanagmentfinal.Properties.Resources.Eye;
            this.openeye1.Location = new System.Drawing.Point(484, 332);
            this.openeye1.Name = "openeye1";
            this.openeye1.Size = new System.Drawing.Size(26, 26);
            this.openeye1.TabIndex = 17;
            this.openeye1.TabStop = false;
            this.openeye1.Visible = false;
            this.openeye1.Click += new System.EventHandler(this.openeye1_Click);
            // 
            // fradio
            // 
            this.fradio.AutoSize = true;
            this.fradio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fradio.Location = new System.Drawing.Point(362, 405);
            this.fradio.Name = "fradio";
            this.fradio.Size = new System.Drawing.Size(66, 20);
            this.fradio.TabIndex = 7;
            this.fradio.TabStop = true;
            this.fradio.Text = "female";
            this.fradio.UseVisualStyleBackColor = true;
            // 
            // mradio
            // 
            this.mradio.AutoSize = true;
            this.mradio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mradio.Location = new System.Drawing.Point(259, 405);
            this.mradio.Name = "mradio";
            this.mradio.Size = new System.Drawing.Size(55, 20);
            this.mradio.TabIndex = 6;
            this.mradio.TabStop = true;
            this.mradio.Text = "male";
            this.mradio.UseVisualStyleBackColor = true;
            // 
            // RegPnu
            // 
            this.RegPnu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegPnu.ForeColor = System.Drawing.Color.Gray;
            this.RegPnu.Location = new System.Drawing.Point(241, 291);
            this.RegPnu.Name = "RegPnu";
            this.RegPnu.Size = new System.Drawing.Size(227, 26);
            this.RegPnu.TabIndex = 3;
            this.RegPnu.Text = "07xxxxxxxxx";
            this.RegPnu.Enter += new System.EventHandler(this.RegPnu_Enter);
            this.RegPnu.Leave += new System.EventHandler(this.RegPnu_Leave);
            // 
            // RegPassword
            // 
            this.RegPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegPassword.ForeColor = System.Drawing.Color.Gray;
            this.RegPassword.Location = new System.Drawing.Point(241, 332);
            this.RegPassword.Name = "RegPassword";
            this.RegPassword.Size = new System.Drawing.Size(227, 26);
            this.RegPassword.TabIndex = 4;
            this.RegPassword.Text = "Password";
            this.RegPassword.Enter += new System.EventHandler(this.RegPassword_Enter);
            this.RegPassword.Leave += new System.EventHandler(this.RegPassword_Leave);
            // 
            // RegLN
            // 
            this.RegLN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegLN.Location = new System.Drawing.Point(362, 218);
            this.RegLN.Name = "RegLN";
            this.RegLN.Size = new System.Drawing.Size(180, 26);
            this.RegLN.TabIndex = 1;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::inventorymanagmentfinal.Properties.Resources.Lock;
            this.pictureBox5.Location = new System.Drawing.Point(209, 291);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(26, 26);
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            // 
            // RegFN
            // 
            this.RegFN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegFN.Location = new System.Drawing.Point(160, 218);
            this.RegFN.Name = "RegFN";
            this.RegFN.Size = new System.Drawing.Size(184, 26);
            this.RegFN.TabIndex = 0;
            this.RegFN.TextChanged += new System.EventHandler(this.RegFN_TextChanged);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::inventorymanagmentfinal.Properties.Resources.Lock;
            this.pictureBox4.Location = new System.Drawing.Point(209, 332);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(26, 26);
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(353, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 54);
            this.label5.TabIndex = 8;
            this.label5.Text = "last name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(151, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 54);
            this.label4.TabIndex = 8;
            this.label4.Text = "first name:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(756, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 35);
            this.button2.TabIndex = 15;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.close_Click);
            // 
            // registerform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(828, 598);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "registerform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "registerform";
            this.Load += new System.EventHandler(this.registerform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closedeye2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closedeye1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openeye2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openeye1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox RegUsername;
        private System.Windows.Forms.TextBox RegPassword2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton fradio;
        private System.Windows.Forms.RadioButton mradio;
        private System.Windows.Forms.TextBox RegPnu;
        private System.Windows.Forms.TextBox RegPassword;
        private System.Windows.Forms.TextBox RegLN;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox RegFN;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox closedeye1;
        private System.Windows.Forms.PictureBox openeye1;
        private System.Windows.Forms.PictureBox closedeye2;
        private System.Windows.Forms.PictureBox openeye2;
    }
}