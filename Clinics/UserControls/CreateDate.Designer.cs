namespace Clinics.UserControls
{
    partial class CreateDate
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Name_pat = new System.Windows.Forms.TextBox();
            this.dtp_Date = new System.Windows.Forms.DateTimePicker();
            this.bunifuCustomLabel14 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel15 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.textBox_ID_pat = new System.Windows.Forms.TextBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel11 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.textBox_ID_visit = new System.Windows.Forms.TextBox();
            this.bunifuCustomLabel8 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel9 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btn_file_save = new System.Windows.Forms.Button();
            this.txtDebrt = new System.Windows.Forms.TextBox();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtDoc = new System.Windows.Forms.TextBox();
            this.bunifuCustomLabel7 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDoc);
            this.groupBox1.Controls.Add(this.bunifuCustomLabel7);
            this.groupBox1.Controls.Add(this.txtDebrt);
            this.groupBox1.Controls.Add(this.bunifuCustomLabel4);
            this.groupBox1.Controls.Add(this.btn_file_save);
            this.groupBox1.Controls.Add(this.textBox_Name_pat);
            this.groupBox1.Controls.Add(this.dtp_Date);
            this.groupBox1.Controls.Add(this.bunifuCustomLabel14);
            this.groupBox1.Controls.Add(this.bunifuCustomLabel15);
            this.groupBox1.Controls.Add(this.textBox_ID_pat);
            this.groupBox1.Controls.Add(this.bunifuCustomLabel1);
            this.groupBox1.Controls.Add(this.bunifuCustomLabel3);
            this.groupBox1.Controls.Add(this.bunifuCustomLabel5);
            this.groupBox1.Controls.Add(this.bunifuCustomLabel11);
            this.groupBox1.Controls.Add(this.textBox_ID_visit);
            this.groupBox1.Controls.Add(this.bunifuCustomLabel8);
            this.groupBox1.Controls.Add(this.bunifuCustomLabel9);
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(179, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(716, 329);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "معلومات مهمة";
            // 
            // textBox_Name_pat
            // 
            this.textBox_Name_pat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_Name_pat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_Name_pat.Location = new System.Drawing.Point(172, 113);
            this.textBox_Name_pat.Name = "textBox_Name_pat";
            this.textBox_Name_pat.Size = new System.Drawing.Size(439, 20);
            this.textBox_Name_pat.TabIndex = 63;
            this.textBox_Name_pat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Name_pat_KeyDown);
            // 
            // dtp_Date
            // 
            this.dtp_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Date.Location = new System.Drawing.Point(172, 65);
            this.dtp_Date.Name = "dtp_Date";
            this.dtp_Date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtp_Date.RightToLeftLayout = true;
            this.dtp_Date.Size = new System.Drawing.Size(439, 20);
            this.dtp_Date.TabIndex = 36;
            // 
            // bunifuCustomLabel14
            // 
            this.bunifuCustomLabel14.AutoSize = true;
            this.bunifuCustomLabel14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel14.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel14.Location = new System.Drawing.Point(6, 16);
            this.bunifuCustomLabel14.Name = "bunifuCustomLabel14";
            this.bunifuCustomLabel14.Size = new System.Drawing.Size(74, 13);
            this.bunifuCustomLabel14.TabIndex = 35;
            this.bunifuCustomLabel14.Text = "حقول إجبارية";
            // 
            // bunifuCustomLabel15
            // 
            this.bunifuCustomLabel15.AutoSize = true;
            this.bunifuCustomLabel15.Location = new System.Drawing.Point(77, 16);
            this.bunifuCustomLabel15.Name = "bunifuCustomLabel15";
            this.bunifuCustomLabel15.Size = new System.Drawing.Size(13, 13);
            this.bunifuCustomLabel15.TabIndex = 34;
            this.bunifuCustomLabel15.Text = "*";
            // 
            // textBox_ID_pat
            // 
            this.textBox_ID_pat.Enabled = false;
            this.textBox_ID_pat.Location = new System.Drawing.Point(497, 19);
            this.textBox_ID_pat.MaxLength = 15;
            this.textBox_ID_pat.Name = "textBox_ID_pat";
            this.textBox_ID_pat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_ID_pat.Size = new System.Drawing.Size(114, 20);
            this.textBox_ID_pat.TabIndex = 1;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Blue;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(361, 22);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(79, 14);
            this.bunifuCustomLabel1.TabIndex = 1;
            this.bunifuCustomLabel1.Text = "رقم الموعد :";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.Blue;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(617, 25);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(75, 14);
            this.bunifuCustomLabel3.TabIndex = 12;
            this.bunifuCustomLabel3.Text = "رقم الملف :";
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.ForeColor = System.Drawing.Color.Red;
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(613, 110);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(13, 13);
            this.bunifuCustomLabel5.TabIndex = 16;
            this.bunifuCustomLabel5.Text = "*";
            // 
            // bunifuCustomLabel11
            // 
            this.bunifuCustomLabel11.AutoSize = true;
            this.bunifuCustomLabel11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel11.ForeColor = System.Drawing.Color.Blue;
            this.bunifuCustomLabel11.Location = new System.Drawing.Point(621, 116);
            this.bunifuCustomLabel11.Name = "bunifuCustomLabel11";
            this.bunifuCustomLabel11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bunifuCustomLabel11.Size = new System.Drawing.Size(89, 14);
            this.bunifuCustomLabel11.TabIndex = 24;
            this.bunifuCustomLabel11.Text = "اسم المريض :";
            // 
            // textBox_ID_visit
            // 
            this.textBox_ID_visit.Enabled = false;
            this.textBox_ID_visit.Location = new System.Drawing.Point(241, 16);
            this.textBox_ID_visit.MaxLength = 15;
            this.textBox_ID_visit.Name = "textBox_ID_visit";
            this.textBox_ID_visit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_ID_visit.Size = new System.Drawing.Size(114, 20);
            this.textBox_ID_visit.TabIndex = 0;
            // 
            // bunifuCustomLabel8
            // 
            this.bunifuCustomLabel8.AutoSize = true;
            this.bunifuCustomLabel8.ForeColor = System.Drawing.Color.Red;
            this.bunifuCustomLabel8.Location = new System.Drawing.Point(614, 58);
            this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
            this.bunifuCustomLabel8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bunifuCustomLabel8.Size = new System.Drawing.Size(13, 13);
            this.bunifuCustomLabel8.TabIndex = 22;
            this.bunifuCustomLabel8.Text = "*";
            // 
            // bunifuCustomLabel9
            // 
            this.bunifuCustomLabel9.AutoSize = true;
            this.bunifuCustomLabel9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel9.ForeColor = System.Drawing.Color.Blue;
            this.bunifuCustomLabel9.Location = new System.Drawing.Point(617, 68);
            this.bunifuCustomLabel9.Name = "bunifuCustomLabel9";
            this.bunifuCustomLabel9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bunifuCustomLabel9.Size = new System.Drawing.Size(84, 14);
            this.bunifuCustomLabel9.TabIndex = 21;
            this.bunifuCustomLabel9.Text = "تاريخ الموعد :";
            // 
            // btn_file_save
            // 
            this.btn_file_save.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_file_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_file_save.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_file_save.ForeColor = System.Drawing.Color.White;
            this.btn_file_save.Location = new System.Drawing.Point(109, 273);
            this.btn_file_save.Name = "btn_file_save";
            this.btn_file_save.Size = new System.Drawing.Size(534, 34);
            this.btn_file_save.TabIndex = 64;
            this.btn_file_save.Text = "اضافة موعد جديد";
            this.btn_file_save.UseVisualStyleBackColor = false;
            this.btn_file_save.Click += new System.EventHandler(this.btn_file_save_Click);
            // 
            // txtDebrt
            // 
            this.txtDebrt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtDebrt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDebrt.Location = new System.Drawing.Point(172, 156);
            this.txtDebrt.Name = "txtDebrt";
            this.txtDebrt.Size = new System.Drawing.Size(439, 20);
            this.txtDebrt.TabIndex = 67;
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel4.ForeColor = System.Drawing.Color.Blue;
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(622, 159);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(53, 14);
            this.bunifuCustomLabel4.TabIndex = 66;
            this.bunifuCustomLabel4.Text = "القسم :";
            // 
            // txtDoc
            // 
            this.txtDoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtDoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDoc.Location = new System.Drawing.Point(172, 202);
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.Size = new System.Drawing.Size(439, 20);
            this.txtDoc.TabIndex = 70;
            // 
            // bunifuCustomLabel7
            // 
            this.bunifuCustomLabel7.AutoSize = true;
            this.bunifuCustomLabel7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel7.ForeColor = System.Drawing.Color.Blue;
            this.bunifuCustomLabel7.Location = new System.Drawing.Point(623, 205);
            this.bunifuCustomLabel7.Name = "bunifuCustomLabel7";
            this.bunifuCustomLabel7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bunifuCustomLabel7.Size = new System.Drawing.Size(55, 14);
            this.bunifuCustomLabel7.TabIndex = 69;
            this.bunifuCustomLabel7.Text = "الطبيب :";
            // 
            // CreateDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Name = "CreateDate";
            this.Size = new System.Drawing.Size(1136, 631);
            this.Load += new System.EventHandler(this.CreateDate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox textBox_Name_pat;
        private System.Windows.Forms.DateTimePicker dtp_Date;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel14;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel15;
        private System.Windows.Forms.TextBox textBox_ID_pat;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel11;
        private System.Windows.Forms.TextBox textBox_ID_visit;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel8;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel9;
        public System.Windows.Forms.TextBox txtDoc;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel7;
        public System.Windows.Forms.TextBox txtDebrt;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private System.Windows.Forms.Button btn_file_save;
    }
}
