namespace Clinics.Grid
{
    partial class Grid_QauntityPOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Grid_QauntityPOS));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmR_Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmR_ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_R_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmR_PriceSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmR_DateItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmR_Tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_R_PriceParchase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_search = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmR_Barcode,
            this.clmR_ItemName,
            this.clm_R_Qty,
            this.clmR_PriceSales,
            this.clmR_DateItem,
            this.clmR_Tax,
            this.clm_R_PriceParchase});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersWidth = 5;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(926, 183);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // clmR_Barcode
            // 
            this.clmR_Barcode.DataPropertyName = "R_Barcode";
            this.clmR_Barcode.HeaderText = "الباركود";
            this.clmR_Barcode.Name = "clmR_Barcode";
            this.clmR_Barcode.ReadOnly = true;
            // 
            // clmR_ItemName
            // 
            this.clmR_ItemName.DataPropertyName = "R_ItemName";
            this.clmR_ItemName.HeaderText = "اسم المادة";
            this.clmR_ItemName.Name = "clmR_ItemName";
            this.clmR_ItemName.ReadOnly = true;
            // 
            // clm_R_Qty
            // 
            this.clm_R_Qty.DataPropertyName = "R_Qty";
            this.clm_R_Qty.HeaderText = "الكمية المتاحة";
            this.clm_R_Qty.Name = "clm_R_Qty";
            this.clm_R_Qty.ReadOnly = true;
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
            // 
            // clmR_Tax
            // 
            this.clmR_Tax.DataPropertyName = "R_Tax";
            this.clmR_Tax.HeaderText = "Tax";
            this.clmR_Tax.Name = "clmR_Tax";
            this.clmR_Tax.ReadOnly = true;
            // 
            // clm_R_PriceParchase
            // 
            this.clm_R_PriceParchase.DataPropertyName = "R_PriceParchase";
            this.clm_R_PriceParchase.HeaderText = "R_PriceParchase";
            this.clm_R_PriceParchase.Name = "clm_R_PriceParchase";
            this.clm_R_PriceParchase.ReadOnly = true;
            this.clm_R_PriceParchase.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.textBox_search);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.ForeColor = System.Drawing.Color.SeaGreen;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(926, 58);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "بحث  ( اسم المادة ، رمز المادة )";
            // 
            // textBox_search
            // 
            this.textBox_search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_search.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.textBox_search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox_search.HintForeColor = System.Drawing.Color.Empty;
            this.textBox_search.HintText = "";
            this.textBox_search.isPassword = false;
            this.textBox_search.LineFocusedColor = System.Drawing.Color.Crimson;
            this.textBox_search.LineIdleColor = System.Drawing.Color.SeaGreen;
            this.textBox_search.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.textBox_search.LineThickness = 3;
            this.textBox_search.Location = new System.Drawing.Point(3, 16);
            this.textBox_search.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(920, 39);
            this.textBox_search.TabIndex = 0;
            this.textBox_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox_search.OnValueChanged += new System.EventHandler(this.textBox_search_OnValueChanged);
            // 
            // Grid_QauntityPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(926, 250);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Grid_QauntityPOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "قائمة المواد المتاحة";
            this.Load += new System.EventHandler(this.Grid_QauntityPOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmR_Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmR_ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_R_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmR_PriceSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmR_DateItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmR_Tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_R_PriceParchase;
        private System.Windows.Forms.GroupBox groupBox3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox textBox_search;
    }
}