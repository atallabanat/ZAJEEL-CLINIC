namespace Clinics.Grid
{
    partial class Grid_Invoice_Sales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Grid_Invoice_Sales));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clm_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_DateInvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_TotalAmount_Invoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.clm_ID,
            this.clm_DateInvoice,
            this.clm_Time,
            this.clm_Status,
            this.clm_TotalAmount_Invoice});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersWidth = 5;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(757, 184);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // clm_ID
            // 
            this.clm_ID.DataPropertyName = "ID";
            this.clm_ID.HeaderText = "رقم الفاتورة";
            this.clm_ID.Name = "clm_ID";
            this.clm_ID.ReadOnly = true;
            // 
            // clm_DateInvoice
            // 
            this.clm_DateInvoice.DataPropertyName = "DateInvoice";
            this.clm_DateInvoice.HeaderText = "تاريخ الفاتورة";
            this.clm_DateInvoice.Name = "clm_DateInvoice";
            this.clm_DateInvoice.ReadOnly = true;
            // 
            // clm_Time
            // 
            this.clm_Time.DataPropertyName = "Time";
            this.clm_Time.HeaderText = "وقت الفاتورة";
            this.clm_Time.Name = "clm_Time";
            this.clm_Time.ReadOnly = true;
            // 
            // clm_Status
            // 
            this.clm_Status.DataPropertyName = "Status";
            this.clm_Status.HeaderText = "حالة الفاتورة";
            this.clm_Status.Name = "clm_Status";
            this.clm_Status.ReadOnly = true;
            // 
            // clm_TotalAmount_Invoice
            // 
            this.clm_TotalAmount_Invoice.DataPropertyName = "TotalAmount_Invoice";
            this.clm_TotalAmount_Invoice.HeaderText = "مجموع الفاتورة";
            this.clm_TotalAmount_Invoice.Name = "clm_TotalAmount_Invoice";
            this.clm_TotalAmount_Invoice.ReadOnly = true;
            // 
            // Grid_Invoice_Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(757, 184);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Grid_Invoice_Sales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "قائمة فواتير البيع";
            this.Load += new System.EventHandler(this.Grid_Invoice_Sales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_DateInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_TotalAmount_Invoice;
    }
}