namespace Clinics.pharmacy_Control
{
    partial class count2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(count2));
            this.dataGridView1 = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Clm_R_DateItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clm_R_Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clm_R_ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clm_R_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clm_R_PriceSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clm_R_Tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_R_PriceParchase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Brown;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clm_R_DateItem,
            this.Clm_R_Barcode,
            this.Clm_R_ItemName,
            this.Clm_R_Qty,
            this.Clm_R_PriceSales,
            this.Clm_R_Tax,
            this.clm_R_PriceParchase});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.DoubleBuffered = true;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.HeaderBgColor = System.Drawing.Color.Brown;
            this.dataGridView1.HeaderForeColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DividerHeight = 3;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(801, 296);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // Clm_R_DateItem
            // 
            this.Clm_R_DateItem.DataPropertyName = "R_DateItem";
            this.Clm_R_DateItem.HeaderText = "تاريخ الانتهاء";
            this.Clm_R_DateItem.Name = "Clm_R_DateItem";
            this.Clm_R_DateItem.ReadOnly = true;
            // 
            // Clm_R_Barcode
            // 
            this.Clm_R_Barcode.DataPropertyName = "R_Barcode";
            this.Clm_R_Barcode.HeaderText = "الباركود";
            this.Clm_R_Barcode.Name = "Clm_R_Barcode";
            this.Clm_R_Barcode.ReadOnly = true;
            // 
            // Clm_R_ItemName
            // 
            this.Clm_R_ItemName.DataPropertyName = "R_ItemName";
            this.Clm_R_ItemName.HeaderText = "اسم المادة";
            this.Clm_R_ItemName.Name = "Clm_R_ItemName";
            this.Clm_R_ItemName.ReadOnly = true;
            // 
            // Clm_R_Qty
            // 
            this.Clm_R_Qty.DataPropertyName = "R_Qty";
            this.Clm_R_Qty.HeaderText = "الكمية";
            this.Clm_R_Qty.Name = "Clm_R_Qty";
            this.Clm_R_Qty.ReadOnly = true;
            // 
            // Clm_R_PriceSales
            // 
            this.Clm_R_PriceSales.DataPropertyName = "R_PriceSales";
            this.Clm_R_PriceSales.HeaderText = "سعر البيع";
            this.Clm_R_PriceSales.Name = "Clm_R_PriceSales";
            this.Clm_R_PriceSales.ReadOnly = true;
            // 
            // Clm_R_Tax
            // 
            this.Clm_R_Tax.DataPropertyName = "R_Tax";
            this.Clm_R_Tax.HeaderText = "TAX";
            this.Clm_R_Tax.Name = "Clm_R_Tax";
            this.Clm_R_Tax.ReadOnly = true;
            // 
            // clm_R_PriceParchase
            // 
            this.clm_R_PriceParchase.DataPropertyName = "R_PriceParchase";
            this.clm_R_PriceParchase.HeaderText = "R_PriceParchase";
            this.clm_R_PriceParchase.Name = "clm_R_PriceParchase";
            this.clm_R_PriceParchase.ReadOnly = true;
            this.clm_R_PriceParchase.Visible = false;
            // 
            // count2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 295);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "count2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "يرجى إختيار المادة";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Bunifu.Framework.UI.BunifuCustomDataGrid dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clm_R_DateItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clm_R_Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clm_R_ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clm_R_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clm_R_PriceSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clm_R_Tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_R_PriceParchase;
    }
}