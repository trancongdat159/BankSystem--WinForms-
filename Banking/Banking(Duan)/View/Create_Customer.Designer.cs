namespace Banking.View
{
    partial class Create_Customer
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textcusid = new System.Windows.Forms.TextBox();
            this.cusID = new System.Windows.Forms.Label();
            this.delete = new System.Windows.Forms.Button();
            this.dataGridViewcus = new System.Windows.Forms.DataGridView();
            this.save = new System.Windows.Forms.Button();
            this.textcuspass = new System.Windows.Forms.TextBox();
            this.Pin = new System.Windows.Forms.Label();
            this.textcussdt = new System.Windows.Forms.TextBox();
            this.textcustp = new System.Windows.Forms.TextBox();
            this.textcusdc = new System.Windows.Forms.TextBox();
            this.textcusemail = new System.Windows.Forms.TextBox();
            this.textcustenkh = new System.Windows.Forms.TextBox();
            this.close = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewcus)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(227, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập thông tin tài khoản";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.textcusid);
            this.panel1.Controls.Add(this.cusID);
            this.panel1.Controls.Add(this.delete);
            this.panel1.Controls.Add(this.dataGridViewcus);
            this.panel1.Controls.Add(this.save);
            this.panel1.Controls.Add(this.textcuspass);
            this.panel1.Controls.Add(this.Pin);
            this.panel1.Controls.Add(this.textcussdt);
            this.panel1.Controls.Add(this.textcustp);
            this.panel1.Controls.Add(this.textcusdc);
            this.panel1.Controls.Add(this.textcusemail);
            this.panel1.Controls.Add(this.textcustenkh);
            this.panel1.Controls.Add(this.close);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(29, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1508, 716);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // textcusid
            // 
            this.textcusid.Location = new System.Drawing.Point(475, 137);
            this.textcusid.Name = "textcusid";
            this.textcusid.Size = new System.Drawing.Size(285, 39);
            this.textcusid.TabIndex = 18;
            this.textcusid.TextChanged += new System.EventHandler(this.textcusid_TextChanged);
            // 
            // cusID
            // 
            this.cusID.AutoSize = true;
            this.cusID.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cusID.Location = new System.Drawing.Point(244, 134);
            this.cusID.Name = "cusID";
            this.cusID.Size = new System.Drawing.Size(160, 32);
            this.cusID.TabIndex = 17;
            this.cusID.Text = "Customer id";
            // 
            // delete
            // 
            this.delete.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.Location = new System.Drawing.Point(478, 598);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(219, 50);
            this.delete.TabIndex = 16;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click_1);
            // 
            // dataGridViewcus
            // 
            this.dataGridViewcus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewcus.Location = new System.Drawing.Point(233, 334);
            this.dataGridViewcus.Name = "dataGridViewcus";
            this.dataGridViewcus.RowHeadersWidth = 51;
            this.dataGridViewcus.RowTemplate.Height = 24;
            this.dataGridViewcus.Size = new System.Drawing.Size(1008, 252);
            this.dataGridViewcus.TabIndex = 15;
            this.dataGridViewcus.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewcus_CellClick_1);
            this.dataGridViewcus.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewcus_CellContentClick);
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save.Location = new System.Drawing.Point(652, 598);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(225, 50);
            this.save.TabIndex = 14;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click_1);
            // 
            // textcuspass
            // 
            this.textcuspass.Location = new System.Drawing.Point(1022, 231);
            this.textcuspass.Name = "textcuspass";
            this.textcuspass.Size = new System.Drawing.Size(289, 39);
            this.textcuspass.TabIndex = 13;
            this.textcuspass.TextChanged += new System.EventHandler(this.textcuspass_TextChanged);
            // 
            // Pin
            // 
            this.Pin.AutoSize = true;
            this.Pin.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pin.Location = new System.Drawing.Point(823, 239);
            this.Pin.Name = "Pin";
            this.Pin.Size = new System.Drawing.Size(56, 32);
            this.Pin.TabIndex = 12;
            this.Pin.Text = "Pin";
            // 
            // textcussdt
            // 
            this.textcussdt.Location = new System.Drawing.Point(475, 238);
            this.textcussdt.Name = "textcussdt";
            this.textcussdt.Size = new System.Drawing.Size(285, 39);
            this.textcussdt.TabIndex = 11;
            this.textcussdt.TextChanged += new System.EventHandler(this.textcussdt_TextChanged);
            // 
            // textcustp
            // 
            this.textcustp.Location = new System.Drawing.Point(1022, 177);
            this.textcustp.Name = "textcustp";
            this.textcustp.Size = new System.Drawing.Size(289, 39);
            this.textcustp.TabIndex = 10;
            this.textcustp.TextChanged += new System.EventHandler(this.textcustp_TextChanged);
            // 
            // textcusdc
            // 
            this.textcusdc.Location = new System.Drawing.Point(1022, 127);
            this.textcusdc.Name = "textcusdc";
            this.textcusdc.Size = new System.Drawing.Size(289, 39);
            this.textcusdc.TabIndex = 9;
            this.textcusdc.TextChanged += new System.EventHandler(this.textcusdc_TextChanged);
            // 
            // textcusemail
            // 
            this.textcusemail.Location = new System.Drawing.Point(475, 289);
            this.textcusemail.Name = "textcusemail";
            this.textcusemail.Size = new System.Drawing.Size(285, 39);
            this.textcusemail.TabIndex = 8;
            this.textcusemail.TextChanged += new System.EventHandler(this.textcusemail_TextChanged);
            // 
            // textcustenkh
            // 
            this.textcustenkh.Location = new System.Drawing.Point(475, 187);
            this.textcustenkh.Name = "textcustenkh";
            this.textcustenkh.Size = new System.Drawing.Size(285, 39);
            this.textcustenkh.TabIndex = 7;
            this.textcustenkh.TextChanged += new System.EventHandler(this.textcustenkh_TextChanged);
            // 
            // close
            // 
            this.close.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.Location = new System.Drawing.Point(830, 598);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(220, 50);
            this.close.TabIndex = 6;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(823, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 32);
            this.label6.TabIndex = 5;
            this.label6.Text = "Địa chỉ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(823, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Thành phố";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(244, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số điện thoại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(244, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(244, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên khách hàng";
            // 
            // Create_Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Create_Customer";
            this.Size = new System.Drawing.Size(1665, 830);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewcus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textcussdt;
        private System.Windows.Forms.TextBox textcustp;
        private System.Windows.Forms.TextBox textcusdc;
        private System.Windows.Forms.TextBox textcusemail;
        private System.Windows.Forms.TextBox textcustenkh;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textcuspass;
        private System.Windows.Forms.Label Pin;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.DataGridView dataGridViewcus;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox textcusid;
        private System.Windows.Forms.Label cusID;
    }
}