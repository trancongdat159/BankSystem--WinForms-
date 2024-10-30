namespace Banking.View
{
    partial class Branch
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
            this.textbrcity = new System.Windows.Forms.TextBox();
            this.dataGridViewbr = new System.Windows.Forms.DataGridView();
            this.Save = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.textbrname = new System.Windows.Forms.TextBox();
            this.textbraddress = new System.Windows.Forms.TextBox();
            this.labelbrname = new System.Windows.Forms.Label();
            this.labelbraddresee = new System.Windows.Forms.Label();
            this.labelbrcity = new System.Windows.Forms.Label();
            this.textbrid = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.lablebrid = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewbr)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.textbrcity);
            this.panel1.Controls.Add(this.dataGridViewbr);
            this.panel1.Controls.Add(this.Save);
            this.panel1.Controls.Add(this.Delete);
            this.panel1.Controls.Add(this.textbrname);
            this.panel1.Controls.Add(this.textbraddress);
            this.panel1.Controls.Add(this.labelbrname);
            this.panel1.Controls.Add(this.labelbraddresee);
            this.panel1.Controls.Add(this.labelbrcity);
            this.panel1.Controls.Add(this.textbrid);
            this.panel1.Controls.Add(this.Add);
            this.panel1.Controls.Add(this.lablebrid);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(176, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1061, 684);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // textbrcity
            // 
            this.textbrcity.Location = new System.Drawing.Point(486, 195);
            this.textbrcity.Name = "textbrcity";
            this.textbrcity.Size = new System.Drawing.Size(319, 39);
            this.textbrcity.TabIndex = 13;
            this.textbrcity.TextChanged += new System.EventHandler(this.textbrcity_TextChanged);
            // 
            // dataGridViewbr
            // 
            this.dataGridViewbr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewbr.Location = new System.Drawing.Point(108, 280);
            this.dataGridViewbr.Name = "dataGridViewbr";
            this.dataGridViewbr.RowHeadersWidth = 51;
            this.dataGridViewbr.RowTemplate.Height = 24;
            this.dataGridViewbr.Size = new System.Drawing.Size(889, 244);
            this.dataGridViewbr.TabIndex = 12;
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.Location = new System.Drawing.Point(604, 540);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(89, 40);
            this.Save.TabIndex = 11;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Delete
            // 
            this.Delete.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.Location = new System.Drawing.Point(486, 540);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(89, 40);
            this.Delete.TabIndex = 10;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // textbrname
            // 
            this.textbrname.Location = new System.Drawing.Point(486, 129);
            this.textbrname.Name = "textbrname";
            this.textbrname.Size = new System.Drawing.Size(319, 39);
            this.textbrname.TabIndex = 8;
            this.textbrname.TextChanged += new System.EventHandler(this.textbrname_TextChanged);
            // 
            // textbraddress
            // 
            this.textbraddress.Location = new System.Drawing.Point(486, 161);
            this.textbraddress.Name = "textbraddress";
            this.textbraddress.Size = new System.Drawing.Size(319, 39);
            this.textbraddress.TabIndex = 7;
            this.textbraddress.TextChanged += new System.EventHandler(this.textbraddress_TextChanged);
            // 
            // labelbrname
            // 
            this.labelbrname.AutoSize = true;
            this.labelbrname.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelbrname.Location = new System.Drawing.Point(247, 129);
            this.labelbrname.Name = "labelbrname";
            this.labelbrname.Size = new System.Drawing.Size(179, 32);
            this.labelbrname.TabIndex = 6;
            this.labelbrname.Text = "Branch Name";
            // 
            // labelbraddresee
            // 
            this.labelbraddresee.AutoSize = true;
            this.labelbraddresee.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelbraddresee.Location = new System.Drawing.Point(247, 161);
            this.labelbraddresee.Name = "labelbraddresee";
            this.labelbraddresee.Size = new System.Drawing.Size(111, 32);
            this.labelbraddresee.TabIndex = 5;
            this.labelbraddresee.Text = "Address";
            // 
            // labelbrcity
            // 
            this.labelbrcity.AutoSize = true;
            this.labelbrcity.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelbrcity.Location = new System.Drawing.Point(247, 195);
            this.labelbrcity.Name = "labelbrcity";
            this.labelbrcity.Size = new System.Drawing.Size(65, 32);
            this.labelbrcity.TabIndex = 4;
            this.labelbrcity.Text = "City";
            // 
            // textbrid
            // 
            this.textbrid.Location = new System.Drawing.Point(486, 97);
            this.textbrid.Name = "textbrid";
            this.textbrid.Size = new System.Drawing.Size(319, 39);
            this.textbrid.TabIndex = 3;
            this.textbrid.TextChanged += new System.EventHandler(this.textbrid_TextChanged);
            // 
            // Add
            // 
            this.Add.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.Location = new System.Drawing.Point(716, 540);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(89, 40);
            this.Add.TabIndex = 1;
            this.Add.Text = "Close";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Close_Click);
            // 
            // lablebrid
            // 
            this.lablebrid.AutoSize = true;
            this.lablebrid.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lablebrid.Location = new System.Drawing.Point(247, 97);
            this.lablebrid.Name = "lablebrid";
            this.lablebrid.Size = new System.Drawing.Size(141, 32);
            this.lablebrid.TabIndex = 0;
            this.lablebrid.Text = "Branch ID";
            // 
            // Branch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel1);
            this.Name = "Branch";
            this.Size = new System.Drawing.Size(1352, 786);
            this.Load += new System.EventHandler(this.Branch_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewbr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textbrid;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Label lablebrid;
        private System.Windows.Forms.TextBox textbrname;
        private System.Windows.Forms.TextBox textbraddress;
        private System.Windows.Forms.Label labelbrname;
        private System.Windows.Forms.Label labelbraddresee;
        private System.Windows.Forms.Label labelbrcity;
        private System.Windows.Forms.DataGridView dataGridViewbr;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.TextBox textbrcity;
    }
}
