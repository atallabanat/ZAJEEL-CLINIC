namespace Clinics.Grid
{
    partial class Grid_Item
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Grid_Item));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clm_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_CostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_AvgCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_SalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Number_Retail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItem_MAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm_Code,
            this.clm_ItemName,
            this.clm_Tax,
            this.clm_CostPrice,
            this.clm_AvgCost,
            this.clm_SalePrice,
            this.clm_Number_Retail,
            this.clmItem_MAX});
            this.dataGridView1.Location = new System.Drawing.Point(0, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(514, 213);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // clm_Code
            // 
            this.clm_Code.DataPropertyName = "Code";
            this.clm_Code.HeaderText = "رمز المادة";
            this.clm_Code.Name = "clm_Code";
            this.clm_Code.ReadOnly = true;
            this.clm_Code.Width = 200;
            // 
            // clm_ItemName
            // 
            this.clm_ItemName.DataPropertyName = "ItemName";
            this.clm_ItemName.HeaderText = "اسم المادة";
            this.clm_ItemName.Name = "clm_ItemName";
            this.clm_ItemName.ReadOnly = true;
            this.clm_ItemName.Width = 270;
            // 
            // clm_Tax
            // 
            this.clm_Tax.DataPropertyName = "Tax";
            this.clm_Tax.HeaderText = "Tax";
            this.clm_Tax.Name = "clm_Tax";
            this.clm_Tax.ReadOnly = true;
            this.clm_Tax.Visible = false;
            // 
            // clm_CostPrice
            // 
            this.clm_CostPrice.DataPropertyName = "CostPrice";
            this.clm_CostPrice.HeaderText = "CostPrice";
            this.clm_CostPrice.Name = "clm_CostPrice";
            this.clm_CostPrice.ReadOnly = true;
            this.clm_CostPrice.Visible = false;
            // 
            // clm_AvgCost
            // 
            this.clm_AvgCost.DataPropertyName = "AvgCost";
            this.clm_AvgCost.HeaderText = "AvgCost";
            this.clm_AvgCost.Name = "clm_AvgCost";
            this.clm_AvgCost.ReadOnly = true;
            this.clm_AvgCost.Visible = false;
            // 
            // clm_SalePrice
            // 
            this.clm_SalePrice.DataPropertyName = "SalePrice";
            this.clm_SalePrice.HeaderText = "SalePrice";
            this.clm_SalePrice.Name = "clm_SalePrice";
            this.clm_SalePrice.ReadOnly = true;
            this.clm_SalePrice.Visible = false;
            // 
            // clm_Number_Retail
            // 
            this.clm_Number_Retail.DataPropertyName = "Number_Retail";
            this.clm_Number_Retail.HeaderText = "Number_Retail";
            this.clm_Number_Retail.Name = "clm_Number_Retail";
            this.clm_Number_Retail.ReadOnly = true;
            this.clm_Number_Retail.Visible = false;
            // 
            // clmItem_MAX
            // 
            this.clmItem_MAX.DataPropertyName = "Item_MAX";
            this.clmItem_MAX.HeaderText = "Item_MAX";
            this.clmItem_MAX.Name = "clmItem_MAX";
            this.clmItem_MAX.ReadOnly = true;
            this.clmItem_MAX.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.textBox_search);
            this.groupBox3.ForeColor = System.Drawing.Color.SeaGreen;
            this.groupBox3.Location = new System.Drawing.Point(0, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(514, 58);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "بحث  ( اسم المادة ، رمز المادة )";
            // 
            // textBox_search
            // 
            this.textBox_search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_search.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.textBox_search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox_search.HintForeColor = System.Drawing.Color.Empty;
            this.textBox_search.HintText = "";
            this.textBox_search.isPassword = false;
            this.textBox_search.LineFocusedColor = System.Drawing.Color.Crimson;
            this.textBox_search.LineIdleColor = System.Drawing.Color.SeaGreen;
            this.textBox_search.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.textBox_search.LineThickness = 3;
            this.textBox_search.Location = new System.Drawing.Point(7, 18);
            this.textBox_search.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(500, 33);
            this.textBox_search.TabIndex = 0;
            this.textBox_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox_search.OnValueChanged += new System.EventHandler(this.textBox_search_OnValueChanged);
            // 
            // Grid_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(514, 275);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Grid_Item";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "قائمة المواد";
            this.Load += new System.EventHandler(this.Grid_Item_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox textBox_search;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_CostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_AvgCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_SalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Number_Retail;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItem_MAX;
    }
}