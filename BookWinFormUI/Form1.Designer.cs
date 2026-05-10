namespace BookWinFormUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlpContent = new System.Windows.Forms.TableLayoutPanel();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnBookPerCountry = new System.Windows.Forms.Button();
            this.cmbFilterCountry = new System.Windows.Forms.ComboBox();
            this.lblFilterCountry = new System.Windows.Forms.Label();
            this.grpForm = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.cmbBookCountry = new System.Windows.Forms.ComboBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.dtpDatePublished = new System.Windows.Forms.DateTimePicker();
            this.lblDatePublished = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpBooks = new System.Windows.Forms.GroupBox();
            this.dtgData = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tlpContent.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.grpForm.SuspendLayout();
            this.grpBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(47)))), ((int)(((byte)(60)))));
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 64);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblHeader.Size = new System.Drawing.Size(1000, 64);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Books Manager";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 678);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1000, 22);
            this.statusStrip1.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 17);
            this.lblStatus.Text = "Ready";
            // 
            // tlpContent
            // 
            this.tlpContent.ColumnCount = 1;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.Controls.Add(this.grpFilter, 0, 0);
            this.tlpContent.Controls.Add(this.grpForm, 0, 1);
            this.tlpContent.Controls.Add(this.grpBooks, 0, 2);
            this.tlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContent.Location = new System.Drawing.Point(0, 64);
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.Padding = new System.Windows.Forms.Padding(16);
            this.tlpContent.RowCount = 3;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.Size = new System.Drawing.Size(1000, 614);
            this.tlpContent.TabIndex = 2;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.btnShowAll);
            this.grpFilter.Controls.Add(this.btnBookPerCountry);
            this.grpFilter.Controls.Add(this.cmbFilterCountry);
            this.grpFilter.Controls.Add(this.lblFilterCountry);
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpFilter.Location = new System.Drawing.Point(19, 19);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(962, 84);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.White;
            this.btnShowAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnShowAll.FlatAppearance.BorderSize = 1;
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnShowAll.Location = new System.Drawing.Point(545, 30);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(150, 28);
            this.btnShowAll.TabIndex = 3;
            this.btnShowAll.Text = "Show all";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnBookPerCountry
            // 
            this.btnBookPerCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnBookPerCountry.FlatAppearance.BorderSize = 0;
            this.btnBookPerCountry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookPerCountry.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBookPerCountry.ForeColor = System.Drawing.Color.White;
            this.btnBookPerCountry.Location = new System.Drawing.Point(385, 30);
            this.btnBookPerCountry.Name = "btnBookPerCountry";
            this.btnBookPerCountry.Size = new System.Drawing.Size(150, 28);
            this.btnBookPerCountry.TabIndex = 2;
            this.btnBookPerCountry.Text = "Filter by country";
            this.btnBookPerCountry.UseVisualStyleBackColor = false;
            this.btnBookPerCountry.Click += new System.EventHandler(this.btnBookPerCountry_Click);
            // 
            // cmbFilterCountry
            // 
            this.cmbFilterCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterCountry.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFilterCountry.FormattingEnabled = true;
            this.cmbFilterCountry.Location = new System.Drawing.Point(85, 32);
            this.cmbFilterCountry.Name = "cmbFilterCountry";
            this.cmbFilterCountry.Size = new System.Drawing.Size(280, 23);
            this.cmbFilterCountry.TabIndex = 1;
            // 
            // lblFilterCountry
            // 
            this.lblFilterCountry.AutoSize = true;
            this.lblFilterCountry.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterCountry.Location = new System.Drawing.Point(20, 35);
            this.lblFilterCountry.Name = "lblFilterCountry";
            this.lblFilterCountry.Size = new System.Drawing.Size(56, 15);
            this.lblFilterCountry.TabIndex = 0;
            this.lblFilterCountry.Text = "Country:";
            // 
            // grpForm
            // 
            this.grpForm.Controls.Add(this.btnClear);
            this.grpForm.Controls.Add(this.btnAddBook);
            this.grpForm.Controls.Add(this.cmbBookCountry);
            this.grpForm.Controls.Add(this.lblCountry);
            this.grpForm.Controls.Add(this.dtpDatePublished);
            this.grpForm.Controls.Add(this.lblDatePublished);
            this.grpForm.Controls.Add(this.txtPrice);
            this.grpForm.Controls.Add(this.lblPrice);
            this.grpForm.Controls.Add(this.txtDescription);
            this.grpForm.Controls.Add(this.lblDescription);
            this.grpForm.Controls.Add(this.txtAuthor);
            this.grpForm.Controls.Add(this.lblAuthor);
            this.grpForm.Controls.Add(this.txtTitle);
            this.grpForm.Controls.Add(this.lblTitle);
            this.grpForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpForm.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpForm.Location = new System.Drawing.Point(19, 109);
            this.grpForm.Name = "grpForm";
            this.grpForm.Size = new System.Drawing.Size(962, 214);
            this.grpForm.TabIndex = 1;
            this.grpForm.TabStop = false;
            this.grpForm.Text = "New book";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnClear.FlatAppearance.BorderSize = 1;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnClear.Location = new System.Drawing.Point(742, 165);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 32);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnAddBook.FlatAppearance.BorderSize = 0;
            this.btnAddBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBook.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddBook.ForeColor = System.Drawing.Color.White;
            this.btnAddBook.Location = new System.Drawing.Point(848, 165);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(100, 32);
            this.btnAddBook.TabIndex = 12;
            this.btnAddBook.Text = "Save book";
            this.btnAddBook.UseVisualStyleBackColor = false;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // cmbBookCountry
            // 
            this.cmbBookCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBookCountry.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbBookCountry.FormattingEnabled = true;
            this.cmbBookCountry.Location = new System.Drawing.Point(20, 163);
            this.cmbBookCountry.Name = "cmbBookCountry";
            this.cmbBookCountry.Size = new System.Drawing.Size(220, 23);
            this.cmbBookCountry.TabIndex = 11;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCountry.Location = new System.Drawing.Point(20, 145);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(56, 15);
            this.lblCountry.TabIndex = 10;
            this.lblCountry.Text = "Country:";
            // 
            // dtpDatePublished
            // 
            this.dtpDatePublished.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDatePublished.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatePublished.Location = new System.Drawing.Point(260, 113);
            this.dtpDatePublished.Name = "dtpDatePublished";
            this.dtpDatePublished.Size = new System.Drawing.Size(220, 23);
            this.dtpDatePublished.TabIndex = 9;
            // 
            // lblDatePublished
            // 
            this.lblDatePublished.AutoSize = true;
            this.lblDatePublished.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDatePublished.Location = new System.Drawing.Point(260, 95);
            this.lblDatePublished.Name = "lblDatePublished";
            this.lblDatePublished.Size = new System.Drawing.Size(95, 15);
            this.lblDatePublished.TabIndex = 8;
            this.lblDatePublished.Text = "Date published:";
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPrice.Location = new System.Drawing.Point(20, 113);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(220, 23);
            this.txtPrice.TabIndex = 7;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPrice.Location = new System.Drawing.Point(20, 95);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(38, 15);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Price:";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescription.Location = new System.Drawing.Point(500, 53);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(440, 83);
            this.txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescription.Location = new System.Drawing.Point(500, 35);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(72, 15);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description:";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAuthor.Location = new System.Drawing.Point(260, 53);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(220, 23);
            this.txtAuthor.TabIndex = 3;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAuthor.Location = new System.Drawing.Point(260, 35);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(48, 15);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "Author:";
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTitle.Location = new System.Drawing.Point(20, 53);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(220, 23);
            this.txtTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTitle.Location = new System.Drawing.Point(20, 35);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(34, 15);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";
            // 
            // grpBooks
            // 
            this.grpBooks.Controls.Add(this.dtgData);
            this.grpBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBooks.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpBooks.Location = new System.Drawing.Point(19, 329);
            this.grpBooks.Name = "grpBooks";
            this.grpBooks.Padding = new System.Windows.Forms.Padding(8);
            this.grpBooks.Size = new System.Drawing.Size(962, 266);
            this.grpBooks.TabIndex = 2;
            this.grpBooks.TabStop = false;
            this.grpBooks.Text = "Books";
            // 
            // dtgData
            // 
            this.dtgData.AllowUserToAddRows = false;
            this.dtgData.AllowUserToDeleteRows = false;
            this.dtgData.AllowUserToResizeRows = false;
            this.dtgData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgData.BackgroundColor = System.Drawing.Color.White;
            this.dtgData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgData.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(47)))), ((int)(((byte)(60)))));
            this.dtgData.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dtgData.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dtgData.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(47)))), ((int)(((byte)(60)))));
            this.dtgData.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dtgData.ColumnHeadersHeight = 32;
            this.dtgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgData.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtgData.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(248)))));
            this.dtgData.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgData.EnableHeadersVisualStyles = false;
            this.dtgData.Location = new System.Drawing.Point(8, 24);
            this.dtgData.Name = "dtgData";
            this.dtgData.ReadOnly = true;
            this.dtgData.RowHeadersVisible = false;
            this.dtgData.RowHeadersWidth = 51;
            this.dtgData.RowTemplate.Height = 28;
            this.dtgData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgData.Size = new System.Drawing.Size(946, 234);
            this.dtgData.TabIndex = 0;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnAddBook;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.tlpContent);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Books Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlHeader.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tlpContent.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.grpForm.ResumeLayout(false);
            this.grpForm.PerformLayout();
            this.grpBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnBookPerCountry;
        private System.Windows.Forms.ComboBox cmbFilterCountry;
        private System.Windows.Forms.Label lblFilterCountry;
        private System.Windows.Forms.GroupBox grpForm;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.ComboBox cmbBookCountry;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.DateTimePicker dtpDatePublished;
        private System.Windows.Forms.Label lblDatePublished;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpBooks;
        private System.Windows.Forms.DataGridView dtgData;
    }
}
