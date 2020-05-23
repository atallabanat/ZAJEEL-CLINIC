namespace Clinics.Pharmacy.ToolsPos.FRM_Report
{
    partial class FRM_Report_Material_inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Report_Material_inventory));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radio_All_Item = new System.Windows.Forms.RadioButton();
            this.radio_ItemNo = new System.Windows.Forms.RadioButton();
            this.textBox_Item_Name = new System.Windows.Forms.TextBox();
            this.textBox_Item_No = new System.Windows.Forms.TextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Item = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Item_Name);
            this.groupBox1.Controls.Add(this.textBox_Item_No);
            this.groupBox1.Controls.Add(this.btn_Item);
            this.groupBox1.Controls.Add(this.radio_ItemNo);
            this.groupBox1.Controls.Add(this.radio_All_Item);
            this.groupBox1.Location = new System.Drawing.Point(8, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(606, 107);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات";
            // 
            // radio_All_Item
            // 
            this.radio_All_Item.AutoSize = true;
            this.radio_All_Item.Checked = true;
            this.radio_All_Item.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_All_Item.Location = new System.Drawing.Point(509, 74);
            this.radio_All_Item.Name = "radio_All_Item";
            this.radio_All_Item.Size = new System.Drawing.Size(85, 17);
            this.radio_All_Item.TabIndex = 0;
            this.radio_All_Item.TabStop = true;
            this.radio_All_Item.Text = "جميع المواد";
            this.radio_All_Item.UseVisualStyleBackColor = true;
            // 
            // radio_ItemNo
            // 
            this.radio_ItemNo.AutoSize = true;
            this.radio_ItemNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_ItemNo.Location = new System.Drawing.Point(516, 28);
            this.radio_ItemNo.Name = "radio_ItemNo";
            this.radio_ItemNo.Size = new System.Drawing.Size(78, 17);
            this.radio_ItemNo.TabIndex = 1;
            this.radio_ItemNo.Text = "رقم المادة";
            this.radio_ItemNo.UseVisualStyleBackColor = true;
            // 
            // textBox_Item_Name
            // 
            this.textBox_Item_Name.Enabled = false;
            this.textBox_Item_Name.Location = new System.Drawing.Point(84, 26);
            this.textBox_Item_Name.MaxLength = 50;
            this.textBox_Item_Name.Name = "textBox_Item_Name";
            this.textBox_Item_Name.ReadOnly = true;
            this.textBox_Item_Name.Size = new System.Drawing.Size(225, 20);
            this.textBox_Item_Name.TabIndex = 15;
            // 
            // textBox_Item_No
            // 
            this.textBox_Item_No.Enabled = false;
            this.textBox_Item_No.Location = new System.Drawing.Point(317, 26);
            this.textBox_Item_No.MaxLength = 30;
            this.textBox_Item_No.Name = "textBox_Item_No";
            this.textBox_Item_No.Size = new System.Drawing.Size(142, 20);
            this.textBox_Item_No.TabIndex = 13;
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.Blue;
            this.btn_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Image = global::Clinics.Properties.Resources.search_32px;
            this.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Add.Location = new System.Drawing.Point(140, 118);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(372, 32);
            this.btn_Add.TabIndex = 2;
            this.btn_Add.Text = "بحث";
            this.btn_Add.UseVisualStyleBackColor = false;
            // 
            // btn_Item
            // 
            this.btn_Item.Enabled = false;
            this.btn_Item.FlatAppearance.BorderSize = 0;
            this.btn_Item.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btn_Item.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Item.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Item.ForeColor = System.Drawing.Color.White;
            this.btn_Item.Image = global::Clinics.Properties.Resources.view_file_32px;
            this.btn_Item.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Item.Location = new System.Drawing.Point(463, 13);
            this.btn_Item.Name = "btn_Item";
            this.btn_Item.Size = new System.Drawing.Size(39, 41);
            this.btn_Item.TabIndex = 14;
            this.btn_Item.UseVisualStyleBackColor = true;
            this.btn_Item.Click += new System.EventHandler(this.btn_Item_Click);
            // 
            // FRM_Report_Material_inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(619, 163);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FRM_Report_Material_inventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقرير جرد المواد";
            this.Load += new System.EventHandler(this.FRM_Report_Material_inventory_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radio_ItemNo;
        private System.Windows.Forms.RadioButton radio_All_Item;
        public System.Windows.Forms.TextBox textBox_Item_Name;
        public System.Windows.Forms.TextBox textBox_Item_No;
        private System.Windows.Forms.Button btn_Item;
        private System.Windows.Forms.Button btn_Add;
    }
}