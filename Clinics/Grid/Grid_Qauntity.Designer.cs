namespace Clinics.Grid
{
    partial class Grid_Qauntity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Grid_Qauntity));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmR_Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmR_ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_R_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmR_PriceParchase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmR_PriceSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmR_DateItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.clmR_Barcode,
            this.clmR_ItemName,
            this.clm_R_Qty,
            this.clmR_PriceParchase,
            this.clmR_PriceSales,
            this.clmR_DateItem});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersWidth = 5;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(942, 213);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // clmR_Barcode
            // 
            this.clmR_Barcode.DataPropertyName = "R_Barcode";
            this.clmR_Barcode.HeaderText = "الباركود";
            this.clmR_Barcode.Name = "clmR_Barcode";
            this.clmR_Barcode.ReadOnly = true;
            this.clmR_Barcode.Width = 200;
            // 
            // clmR_ItemName
            // 
            this.clmR_ItemName.DataPropertyName = "R_ItemName";
            this.clmR_ItemName.HeaderText = "اسم المادة";
            this.clmR_ItemName.Name = "clmR_ItemName";
            this.clmR_ItemName.ReadOnly = true;
            this.clmR_ItemName.Width = 250;
            // 
            // clm_R_Qty
            // 
            this.clm_R_Qty.DataPropertyName = "R_Qty";
            this.clm_R_Qty.HeaderText = "الكمية المتاحة";
            this.clm_R_Qty.Name = "clm_R_Qty";
            this.clm_R_Qty.ReadOnly = true;
            this.clm_R_Qty.Width = 135;
            // 
            // clmR_PriceParchase
            // 
            this.clmR_PriceParchase.DataPropertyName = "R_PriceParchase";
            this.clmR_PriceParchase.HeaderText = "سعر الشراء";
            this.clmR_PriceParchase.Name = "clmR_PriceParchase";
            this.clmR_PriceParchase.ReadOnly = true;
            // 
            // clmR_PriceSales
            // 
            this.clmR_PriceSales.DataPropertyName = "R_PriceSales";
            this.clmR_PriceSales.HeaderText = "سعر البيع";
            this.clmR_PriceSales.Name = "clmR_PriceSales";
            this.clmR_PriceSales.ReadOnly = true;
            // 
            // clmR_DateItem
            // 
            this.clmR_DateItem.DataPropertyName = "R_DateItem";
            this.clmR_DateItem.HeaderText = "تاريخ الصلاحية";
            this.clmR_DateItem.Name = "clmR_DateItem";
            this.clmR_DateItem.ReadOnly = true;
            this.clmR_DateItem.Width = 150;
            // 
            // Grid_Qauntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(942, 213);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Grid_Qauntity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الكمية المتاحة لهذه المادة";
            this.Load += new System.EventHandler(this.Grid_Qauntity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmR_Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmR_ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_R_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmR_PriceParchase;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmR_PriceSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmR_DateItem;
    }
}