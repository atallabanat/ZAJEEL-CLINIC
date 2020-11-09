namespace Clinics
{
    partial class frmRigister
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
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Rad_Clinic = new System.Windows.Forms.RadioButton();
            this.radStore = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnActivate = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOurEmploye = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnCopyRequest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.radSchool = new System.Windows.Forms.RadioButton();
            this.rad_pos = new System.Windows.Forms.RadioButton();
            this.rd_Pahramcy = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(31, 222);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "تاريخ انتهاء الصلاحية";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(152, 216);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(201, 20);
            this.dateTimePicker1.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(513, 256);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(520, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(520, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(520, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(520, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "*";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rd_Pahramcy);
            this.groupBox1.Controls.Add(this.radSchool);
            this.groupBox1.Controls.Add(this.Rad_Clinic);
            this.groupBox1.Controls.Add(this.radStore);
            this.groupBox1.Controls.Add(this.rad_pos);
            this.groupBox1.Location = new System.Drawing.Point(34, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 59);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "البرامج:";
            // 
            // Rad_Clinic
            // 
            this.Rad_Clinic.AutoSize = true;
            this.Rad_Clinic.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Rad_Clinic.Location = new System.Drawing.Point(384, 23);
            this.Rad_Clinic.Margin = new System.Windows.Forms.Padding(4);
            this.Rad_Clinic.Name = "Rad_Clinic";
            this.Rad_Clinic.Size = new System.Drawing.Size(61, 17);
            this.Rad_Clinic.TabIndex = 0;
            this.Rad_Clinic.TabStop = true;
            this.Rad_Clinic.Tag = "3";
            this.Rad_Clinic.Text = "العيادات";
            this.Rad_Clinic.UseVisualStyleBackColor = true;
            // 
            // radStore
            // 
            this.radStore.AutoSize = true;
            this.radStore.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radStore.Location = new System.Drawing.Point(192, 23);
            this.radStore.Margin = new System.Windows.Forms.Padding(4);
            this.radStore.Name = "radStore";
            this.radStore.Size = new System.Drawing.Size(73, 17);
            this.radStore.TabIndex = 1;
            this.radStore.TabStop = true;
            this.radStore.Tag = "2";
            this.radStore.Text = "مستودعات";
            this.radStore.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(31, 256);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "أدخل الكود:";
            // 
            // btnExit
            // 
            this.btnExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExit.Location = new System.Drawing.Point(424, 286);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 30);
            this.btnExit.TabIndex = 27;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnActivate
            // 
            this.btnActivate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnActivate.Location = new System.Drawing.Point(307, 286);
            this.btnActivate.Margin = new System.Windows.Forms.Padding(4);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(112, 30);
            this.btnActivate.TabIndex = 28;
            this.btnActivate.Text = "تفعيل";
            this.btnActivate.UseVisualStyleBackColor = true;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(144, 253);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(362, 20);
            this.txtCode.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(31, 56);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "الفرع:";
            // 
            // txtBranch
            // 
            this.txtBranch.Location = new System.Drawing.Point(151, 52);
            this.txtBranch.Margin = new System.Windows.Forms.Padding(4);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(362, 20);
            this.txtBranch.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(31, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "موظف الدعم الفني:";
            // 
            // txtOurEmploye
            // 
            this.txtOurEmploye.Location = new System.Drawing.Point(151, 108);
            this.txtOurEmploye.Margin = new System.Windows.Forms.Padding(4);
            this.txtOurEmploye.Name = "txtOurEmploye";
            this.txtOurEmploye.Size = new System.Drawing.Size(362, 20);
            this.txtOurEmploye.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(31, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "الهاتف:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(151, 80);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(362, 20);
            this.txtPhone.TabIndex = 22;
            // 
            // btnCopyRequest
            // 
            this.btnCopyRequest.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCopyRequest.Location = new System.Drawing.Point(394, 215);
            this.btnCopyRequest.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopyRequest.Name = "btnCopyRequest";
            this.btnCopyRequest.Size = new System.Drawing.Size(112, 30);
            this.btnCopyRequest.TabIndex = 25;
            this.btnCopyRequest.Text = "طلب نسخه";
            this.btnCopyRequest.UseVisualStyleBackColor = true;
            this.btnCopyRequest.Click += new System.EventHandler(this.btnCopyRequest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(31, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "إسم الشركة:";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(151, 24);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(362, 20);
            this.txtCompanyName.TabIndex = 20;
            // 
            // radSchool
            // 
            this.radSchool.AutoSize = true;
            this.radSchool.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radSchool.Location = new System.Drawing.Point(30, 23);
            this.radSchool.Margin = new System.Windows.Forms.Padding(4);
            this.radSchool.Name = "radSchool";
            this.radSchool.Size = new System.Drawing.Size(52, 17);
            this.radSchool.TabIndex = 4;
            this.radSchool.TabStop = true;
            this.radSchool.Tag = "5";
            this.radSchool.Text = "مدارس";
            this.radSchool.UseVisualStyleBackColor = true;
            // 
            // rad_pos
            // 
            this.rad_pos.AutoSize = true;
            this.rad_pos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rad_pos.Location = new System.Drawing.Point(107, 23);
            this.rad_pos.Margin = new System.Windows.Forms.Padding(4);
            this.rad_pos.Name = "rad_pos";
            this.rad_pos.Size = new System.Drawing.Size(63, 17);
            this.rad_pos.TabIndex = 2;
            this.rad_pos.TabStop = true;
            this.rad_pos.Tag = "1";
            this.rad_pos.Text = "نقاط بيع";
            this.rad_pos.UseVisualStyleBackColor = true;
            // 
            // rd_Pahramcy
            // 
            this.rd_Pahramcy.AutoSize = true;
            this.rd_Pahramcy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rd_Pahramcy.Location = new System.Drawing.Point(298, 23);
            this.rd_Pahramcy.Margin = new System.Windows.Forms.Padding(4);
            this.rd_Pahramcy.Name = "rd_Pahramcy";
            this.rd_Pahramcy.Size = new System.Drawing.Size(61, 17);
            this.rd_Pahramcy.TabIndex = 5;
            this.rd_Pahramcy.TabStop = true;
            this.rd_Pahramcy.Tag = "3";
            this.rd_Pahramcy.Text = "الصيدلية";
            this.rd_Pahramcy.UseVisualStyleBackColor = true;
            // 
            // frmRigister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 340);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBranch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOurEmploye);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnCopyRequest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCompanyName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRigister";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "طلب نسخة";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Rad_Clinic;
        private System.Windows.Forms.RadioButton radStore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOurEmploye;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnCopyRequest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.RadioButton rd_Pahramcy;
        private System.Windows.Forms.RadioButton radSchool;
        private System.Windows.Forms.RadioButton rad_pos;
    }
}