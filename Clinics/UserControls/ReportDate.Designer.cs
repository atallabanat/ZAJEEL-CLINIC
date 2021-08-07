namespace Clinics.UserControls
{
    partial class ReportDate
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmDebrt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNameDr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNamePat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIDPat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmfileID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel9 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel8 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dtp_Date = new System.Windows.Forms.DateTimePicker();
            this.dtp_Date2 = new System.Windows.Forms.DateTimePicker();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btn_file_save = new System.Windows.Forms.Button();
            this.panelControls = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.58003F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.41997F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 631);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmID,
            this.clmfileID,
            this.clmDate,
            this.clmIDPat,
            this.clmNamePat,
            this.clmNameDr,
            this.clmDebrt});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 94);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(994, 534);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // clmDebrt
            // 
            this.clmDebrt.DataPropertyName = "NameDebrt";
            this.clmDebrt.HeaderText = "القسم";
            this.clmDebrt.Name = "clmDebrt";
            this.clmDebrt.ReadOnly = true;
            // 
            // clmNameDr
            // 
            this.clmNameDr.DataPropertyName = "NameDr";
            this.clmNameDr.HeaderText = "الطبيب";
            this.clmNameDr.Name = "clmNameDr";
            this.clmNameDr.ReadOnly = true;
            // 
            // clmNamePat
            // 
            this.clmNamePat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmNamePat.DataPropertyName = "NamePat";
            this.clmNamePat.HeaderText = "المريض";
            this.clmNamePat.Name = "clmNamePat";
            this.clmNamePat.ReadOnly = true;
            // 
            // clmIDPat
            // 
            this.clmIDPat.DataPropertyName = "IDPat";
            this.clmIDPat.HeaderText = "IDPat";
            this.clmIDPat.Name = "clmIDPat";
            this.clmIDPat.ReadOnly = true;
            this.clmIDPat.Visible = false;
            // 
            // clmDate
            // 
            this.clmDate.DataPropertyName = "Date";
            this.clmDate.HeaderText = "تاريخ الموعد";
            this.clmDate.Name = "clmDate";
            this.clmDate.ReadOnly = true;
            // 
            // clmfileID
            // 
            this.clmfileID.DataPropertyName = "fileID";
            this.clmfileID.HeaderText = "رقم الملف";
            this.clmfileID.Name = "clmfileID";
            this.clmfileID.ReadOnly = true;
            // 
            // clmID
            // 
            this.clmID.DataPropertyName = "ID";
            this.clmID.HeaderText = "ID";
            this.clmID.Name = "clmID";
            this.clmID.ReadOnly = true;
            this.clmID.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_file_save);
            this.panel1.Controls.Add(this.bunifuCustomLabel1);
            this.panel1.Controls.Add(this.dtp_Date2);
            this.panel1.Controls.Add(this.dtp_Date);
            this.panel1.Controls.Add(this.bunifuCustomLabel8);
            this.panel1.Controls.Add(this.bunifuCustomLabel9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 85);
            this.panel1.TabIndex = 1;
            // 
            // bunifuCustomLabel9
            // 
            this.bunifuCustomLabel9.AutoSize = true;
            this.bunifuCustomLabel9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel9.ForeColor = System.Drawing.Color.Blue;
            this.bunifuCustomLabel9.Location = new System.Drawing.Point(917, 38);
            this.bunifuCustomLabel9.Name = "bunifuCustomLabel9";
            this.bunifuCustomLabel9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bunifuCustomLabel9.Size = new System.Drawing.Size(63, 14);
            this.bunifuCustomLabel9.TabIndex = 37;
            this.bunifuCustomLabel9.Text = "من تاريخ :";
            // 
            // bunifuCustomLabel8
            // 
            this.bunifuCustomLabel8.AutoSize = true;
            this.bunifuCustomLabel8.ForeColor = System.Drawing.Color.Red;
            this.bunifuCustomLabel8.Location = new System.Drawing.Point(914, 28);
            this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
            this.bunifuCustomLabel8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bunifuCustomLabel8.Size = new System.Drawing.Size(13, 13);
            this.bunifuCustomLabel8.TabIndex = 38;
            this.bunifuCustomLabel8.Text = "*";
            // 
            // dtp_Date
            // 
            this.dtp_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Date.Location = new System.Drawing.Point(749, 35);
            this.dtp_Date.Name = "dtp_Date";
            this.dtp_Date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtp_Date.RightToLeftLayout = true;
            this.dtp_Date.Size = new System.Drawing.Size(162, 20);
            this.dtp_Date.TabIndex = 39;
            // 
            // dtp_Date2
            // 
            this.dtp_Date2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Date2.Location = new System.Drawing.Point(551, 35);
            this.dtp_Date2.Name = "dtp_Date2";
            this.dtp_Date2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtp_Date2.RightToLeftLayout = true;
            this.dtp_Date2.Size = new System.Drawing.Size(162, 20);
            this.dtp_Date2.TabIndex = 40;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Blue;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(726, 38);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(12, 14);
            this.bunifuCustomLabel1.TabIndex = 41;
            this.bunifuCustomLabel1.Text = "-";
            // 
            // btn_file_save
            // 
            this.btn_file_save.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_file_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_file_save.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_file_save.ForeColor = System.Drawing.Color.White;
            this.btn_file_save.Location = new System.Drawing.Point(306, 28);
            this.btn_file_save.Name = "btn_file_save";
            this.btn_file_save.Size = new System.Drawing.Size(214, 34);
            this.btn_file_save.TabIndex = 65;
            this.btn_file_save.Text = "بحث";
            this.btn_file_save.UseVisualStyleBackColor = false;
            this.btn_file_save.Click += new System.EventHandler(this.btn_file_save_Click);
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.White;
            this.panelControls.Controls.Add(this.tableLayoutPanel1);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(1000, 631);
            this.panelControls.TabIndex = 2;
            // 
            // ReportDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControls);
            this.Name = "ReportDate";
            this.Size = new System.Drawing.Size(1000, 631);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_file_save;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.DateTimePicker dtp_Date2;
        private System.Windows.Forms.DateTimePicker dtp_Date;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel8;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmfileID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIDPat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNamePat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNameDr;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDebrt;
        private System.Windows.Forms.Panel panelControls;
    }
}
