namespace Clinics.UserControls
{
    partial class Paid_MM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paid_MM));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.totalLabel = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btn_file_save = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.t1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.text1 = new System.Windows.Forms.TextBox();
            this.t2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.text2 = new System.Windows.Forms.TextBox();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lbl_EndDate = new Bunifu.Framework.UI.BunifuCustomLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.s1,
            this.Column2,
            this.s2,
            this.Column3,
            this.s3,
            this.Column4,
            this.s4,
            this.Column5,
            this.s5});
            this.dataGridView1.Location = new System.Drawing.Point(2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(1043, 117);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name_Measures1";
            this.Column1.HeaderText = "الاجراء 1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // s1
            // 
            this.s1.DataPropertyName = "Price_Measures1";
            this.s1.HeaderText = "سعر الاجراء 1";
            this.s1.Name = "s1";
            this.s1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Name_Measures2";
            this.Column2.HeaderText = "الاجراء 2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // s2
            // 
            this.s2.DataPropertyName = "Price_Measures2";
            this.s2.HeaderText = "سعر الاجراء 2";
            this.s2.Name = "s2";
            this.s2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Name_Measures3";
            this.Column3.HeaderText = "الاجراء 3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // s3
            // 
            this.s3.DataPropertyName = "Price_Measures3";
            this.s3.HeaderText = "سعر الاجراء 3";
            this.s3.Name = "s3";
            this.s3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Name_Measures4";
            this.Column4.HeaderText = "الاجراء 4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // s4
            // 
            this.s4.DataPropertyName = "Price_Measures4";
            this.s4.HeaderText = "سعر الاجراء 4";
            this.s4.Name = "s4";
            this.s4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Name_MeasuresOther";
            this.Column5.HeaderText = "الاجراءات الاخرى";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // s5
            // 
            this.s5.DataPropertyName = "Price_MeasuresOther";
            this.s5.HeaderText = "سعر الاجراءات الاخرى";
            this.s5.Name = "s5";
            this.s5.ReadOnly = true;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Blue;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(426, 141);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(158, 23);
            this.bunifuCustomLabel1.TabIndex = 2;
            this.bunifuCustomLabel1.Text = "المبلغ المطلوب :";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.ForeColor = System.Drawing.Color.Red;
            this.totalLabel.Location = new System.Drawing.Point(463, 196);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.totalLabel.Size = new System.Drawing.Size(48, 23);
            this.totalLabel.TabIndex = 3;
            this.totalLabel.Text = "دينار";
            // 
            // btn_file_save
            // 
            this.btn_file_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_file_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_file_save.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_file_save.ForeColor = System.Drawing.Color.White;
            this.btn_file_save.Location = new System.Drawing.Point(101, 371);
            this.btn_file_save.Name = "btn_file_save";
            this.btn_file_save.Size = new System.Drawing.Size(312, 34);
            this.btn_file_save.TabIndex = 5;
            this.btn_file_save.Text = "الحصول على خصم";
            this.btn_file_save.UseVisualStyleBackColor = false;
            this.btn_file_save.Click += new System.EventHandler(this.btn_file_save_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 198);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(28, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Red;
            this.textBox2.Location = new System.Drawing.Point(517, 193);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(194, 35);
            this.textBox2.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Blue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(560, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(312, 34);
            this.button1.TabIndex = 17;
            this.button1.Text = "دفع الحساب";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // t1
            // 
            this.t1.AutoSize = true;
            this.t1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t1.ForeColor = System.Drawing.Color.Red;
            this.t1.Location = new System.Drawing.Point(913, 125);
            this.t1.Name = "t1";
            this.t1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.t1.Size = new System.Drawing.Size(130, 23);
            this.t1.TabIndex = 18;
            this.t1.Text = "هذا المريض :";
            this.t1.Visible = false;
            // 
            // text1
            // 
            this.text1.BackColor = System.Drawing.Color.White;
            this.text1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text1.ForeColor = System.Drawing.Color.Blue;
            this.text1.Location = new System.Drawing.Point(764, 128);
            this.text1.Multiline = true;
            this.text1.Name = "text1";
            this.text1.ReadOnly = true;
            this.text1.Size = new System.Drawing.Size(146, 22);
            this.text1.TabIndex = 19;
            this.text1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.text1.Visible = false;
            // 
            // t2
            // 
            this.t2.AutoSize = true;
            this.t2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t2.ForeColor = System.Drawing.Color.Red;
            this.t2.Location = new System.Drawing.Point(853, 163);
            this.t2.Name = "t2";
            this.t2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.t2.Size = new System.Drawing.Size(190, 23);
            this.t2.TabIndex = 21;
            this.t2.Text = "يتحمل النسبة التالية";
            this.t2.Visible = false;
            // 
            // text2
            // 
            this.text2.BackColor = System.Drawing.Color.White;
            this.text2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text2.ForeColor = System.Drawing.Color.Blue;
            this.text2.Location = new System.Drawing.Point(785, 163);
            this.text2.Multiline = true;
            this.text2.Name = "text2";
            this.text2.ReadOnly = true;
            this.text2.Size = new System.Drawing.Size(62, 27);
            this.text2.TabIndex = 22;
            this.text2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.text2.Visible = false;
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel5.ForeColor = System.Drawing.Color.Red;
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(748, 165);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(33, 23);
            this.bunifuCustomLabel5.TabIndex = 23;
            this.bunifuCustomLabel5.Text = "%";
            this.bunifuCustomLabel5.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(46, 198);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(15, 20);
            this.textBox3.TabIndex = 25;
            this.textBox3.Visible = false;
            // 
            // lbl_EndDate
            // 
            this.lbl_EndDate.AutoSize = true;
            this.lbl_EndDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_EndDate.ForeColor = System.Drawing.Color.Red;
            this.lbl_EndDate.Location = new System.Drawing.Point(22, 141);
            this.lbl_EndDate.Name = "lbl_EndDate";
            this.lbl_EndDate.Size = new System.Drawing.Size(258, 16);
            this.lbl_EndDate.TabIndex = 66;
            this.lbl_EndDate.Text = "تنبيه : تاريخ صلاحية بطاقة الـتأمين منتهية";
            this.lbl_EndDate.Visible = false;
            // 
            // Paid_MM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1045, 450);
            this.Controls.Add(this.lbl_EndDate);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.bunifuCustomLabel5);
            this.Controls.Add(this.text2);
            this.Controls.Add(this.t2);
            this.Controls.Add(this.text1);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_file_save);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Paid_MM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "دفع الحساب";
            this.Load += new System.EventHandler(this.Paid_MM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuCustomLabel totalLabel;
        private System.Windows.Forms.Button btn_file_save;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn s1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn s2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn s3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn s4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn s5;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private Bunifu.Framework.UI.BunifuCustomLabel t1;
        private System.Windows.Forms.TextBox text1;
        private Bunifu.Framework.UI.BunifuCustomLabel t2;
        private System.Windows.Forms.TextBox text2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        public System.Windows.Forms.TextBox textBox3;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_EndDate;
    }
}