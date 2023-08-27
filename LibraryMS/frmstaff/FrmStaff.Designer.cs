namespace LibraryMS
{
    partial class FrmStaff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStaff));
            this.logoutButton = new System.Windows.Forms.Button();
            this.FunctionOptions = new System.Windows.Forms.Panel();
            this.buttonBook = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonUserAccount = new System.Windows.Forms.Button();
            this.pictureBoxAccountManagement = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelInput = new System.Windows.Forms.Panel();
            this.textBoxB_Price = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.buttonB_Delete = new System.Windows.Forms.Button();
            this.buttonB_Modify = new System.Windows.Forms.Button();
            this.buttonB_Reset = new System.Windows.Forms.Button();
            this.buttonB_Add = new System.Windows.Forms.Button();
            this.textBoxB_Publisher = new System.Windows.Forms.TextBox();
            this.labelPublisher = new System.Windows.Forms.Label();
            this.textBoxB_Author = new System.Windows.Forms.TextBox();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.textBoxB_ISBN = new System.Windows.Forms.TextBox();
            this.labelISBN = new System.Windows.Forms.Label();
            this.textBoxB_Name = new System.Windows.Forms.TextBox();
            this.labelB_Name = new System.Windows.Forms.Label();
            this.panelOutPut = new System.Windows.Forms.Panel();
            this.bookDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FunctionOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAccountManagement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelInput.SuspendLayout();
            this.panelOutPut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "This is user form";
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.Transparent;
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutButton.ForeColor = System.Drawing.Color.Black;
            this.logoutButton.Location = new System.Drawing.Point(87, 322);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(2);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(140, 33);
            this.logoutButton.TabIndex = 2;
            this.logoutButton.Text = "LogOut";
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // FunctionOptions
            // 
            this.FunctionOptions.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.FunctionOptions.Controls.Add(this.buttonBook);
            this.FunctionOptions.Controls.Add(this.pictureBox2);
            this.FunctionOptions.Controls.Add(this.buttonUserAccount);
            this.FunctionOptions.Controls.Add(this.pictureBoxAccountManagement);
            this.FunctionOptions.Controls.Add(this.pictureBox1);
            this.FunctionOptions.Controls.Add(this.logoutButton);
            this.FunctionOptions.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.FunctionOptions.Location = new System.Drawing.Point(12, 12);
            this.FunctionOptions.Name = "FunctionOptions";
            this.FunctionOptions.Size = new System.Drawing.Size(267, 637);
            this.FunctionOptions.TabIndex = 3;
            // 
            // buttonBook
            // 
            this.buttonBook.BackColor = System.Drawing.Color.Transparent;
            this.buttonBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBook.ForeColor = System.Drawing.Color.Black;
            this.buttonBook.Location = new System.Drawing.Point(87, 132);
            this.buttonBook.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBook.Name = "buttonBook";
            this.buttonBook.Size = new System.Drawing.Size(140, 33);
            this.buttonBook.TabIndex = 7;
            this.buttonBook.Text = "Book ";
            this.buttonBook.UseVisualStyleBackColor = false;
            this.buttonBook.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(19, 132);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(51, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // buttonUserAccount
            // 
            this.buttonUserAccount.BackColor = System.Drawing.Color.Transparent;
            this.buttonUserAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUserAccount.ForeColor = System.Drawing.Color.Black;
            this.buttonUserAccount.Location = new System.Drawing.Point(87, 221);
            this.buttonUserAccount.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUserAccount.Name = "buttonUserAccount";
            this.buttonUserAccount.Size = new System.Drawing.Size(140, 33);
            this.buttonUserAccount.TabIndex = 5;
            this.buttonUserAccount.Text = "User Account ";
            this.buttonUserAccount.UseVisualStyleBackColor = false;
            // 
            // pictureBoxAccountManagement
            // 
            this.pictureBoxAccountManagement.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAccountManagement.Image")));
            this.pictureBoxAccountManagement.Location = new System.Drawing.Point(19, 224);
            this.pictureBoxAccountManagement.Name = "pictureBoxAccountManagement";
            this.pictureBoxAccountManagement.Size = new System.Drawing.Size(52, 39);
            this.pictureBoxAccountManagement.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAccountManagement.TabIndex = 4;
            this.pictureBoxAccountManagement.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 314);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelInput.Controls.Add(this.textBoxB_Price);
            this.panelInput.Controls.Add(this.labelPrice);
            this.panelInput.Controls.Add(this.buttonB_Delete);
            this.panelInput.Controls.Add(this.buttonB_Modify);
            this.panelInput.Controls.Add(this.buttonB_Reset);
            this.panelInput.Controls.Add(this.buttonB_Add);
            this.panelInput.Controls.Add(this.textBoxB_Publisher);
            this.panelInput.Controls.Add(this.labelPublisher);
            this.panelInput.Controls.Add(this.textBoxB_Author);
            this.panelInput.Controls.Add(this.labelAuthor);
            this.panelInput.Controls.Add(this.textBoxB_ISBN);
            this.panelInput.Controls.Add(this.labelISBN);
            this.panelInput.Controls.Add(this.textBoxB_Name);
            this.panelInput.Controls.Add(this.labelB_Name);
            this.panelInput.Location = new System.Drawing.Point(285, 12);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(794, 96);
            this.panelInput.TabIndex = 5;
            // 
            // textBoxB_Price
            // 
            this.textBoxB_Price.Location = new System.Drawing.Point(684, 7);
            this.textBoxB_Price.Name = "textBoxB_Price";
            this.textBoxB_Price.Size = new System.Drawing.Size(98, 20);
            this.textBoxB_Price.TabIndex = 14;
            this.textBoxB_Price.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(647, 11);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(31, 13);
            this.labelPrice.TabIndex = 13;
            this.labelPrice.Text = "Price";
            this.labelPrice.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonB_Delete
            // 
            this.buttonB_Delete.BackColor = System.Drawing.Color.Transparent;
            this.buttonB_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonB_Delete.ForeColor = System.Drawing.Color.Black;
            this.buttonB_Delete.Location = new System.Drawing.Point(289, 57);
            this.buttonB_Delete.Margin = new System.Windows.Forms.Padding(2);
            this.buttonB_Delete.Name = "buttonB_Delete";
            this.buttonB_Delete.Size = new System.Drawing.Size(77, 33);
            this.buttonB_Delete.TabIndex = 12;
            this.buttonB_Delete.Text = "Delete";
            this.buttonB_Delete.UseVisualStyleBackColor = false;
            // 
            // buttonB_Modify
            // 
            this.buttonB_Modify.BackColor = System.Drawing.Color.Transparent;
            this.buttonB_Modify.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonB_Modify.ForeColor = System.Drawing.Color.Black;
            this.buttonB_Modify.Location = new System.Drawing.Point(179, 57);
            this.buttonB_Modify.Margin = new System.Windows.Forms.Padding(2);
            this.buttonB_Modify.Name = "buttonB_Modify";
            this.buttonB_Modify.Size = new System.Drawing.Size(77, 33);
            this.buttonB_Modify.TabIndex = 11;
            this.buttonB_Modify.Text = "Modify";
            this.buttonB_Modify.UseVisualStyleBackColor = false;
            // 
            // buttonB_Reset
            // 
            this.buttonB_Reset.BackColor = System.Drawing.Color.Transparent;
            this.buttonB_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonB_Reset.ForeColor = System.Drawing.Color.Black;
            this.buttonB_Reset.Location = new System.Drawing.Point(409, 57);
            this.buttonB_Reset.Margin = new System.Windows.Forms.Padding(2);
            this.buttonB_Reset.Name = "buttonB_Reset";
            this.buttonB_Reset.Size = new System.Drawing.Size(77, 33);
            this.buttonB_Reset.TabIndex = 10;
            this.buttonB_Reset.Text = "Reset";
            this.buttonB_Reset.UseVisualStyleBackColor = false;
            // 
            // buttonB_Add
            // 
            this.buttonB_Add.BackColor = System.Drawing.Color.Transparent;
            this.buttonB_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonB_Add.ForeColor = System.Drawing.Color.Black;
            this.buttonB_Add.Location = new System.Drawing.Point(80, 57);
            this.buttonB_Add.Margin = new System.Windows.Forms.Padding(2);
            this.buttonB_Add.Name = "buttonB_Add";
            this.buttonB_Add.Size = new System.Drawing.Size(62, 33);
            this.buttonB_Add.TabIndex = 9;
            this.buttonB_Add.Text = "Add";
            this.buttonB_Add.UseVisualStyleBackColor = false;
            this.buttonB_Add.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // textBoxB_Publisher
            // 
            this.textBoxB_Publisher.Location = new System.Drawing.Point(533, 11);
            this.textBoxB_Publisher.Name = "textBoxB_Publisher";
            this.textBoxB_Publisher.Size = new System.Drawing.Size(98, 20);
            this.textBoxB_Publisher.TabIndex = 7;
            // 
            // labelPublisher
            // 
            this.labelPublisher.AutoSize = true;
            this.labelPublisher.Location = new System.Drawing.Point(468, 14);
            this.labelPublisher.Name = "labelPublisher";
            this.labelPublisher.Size = new System.Drawing.Size(50, 13);
            this.labelPublisher.TabIndex = 6;
            this.labelPublisher.Text = "Publisher";
            // 
            // textBoxB_Author
            // 
            this.textBoxB_Author.Location = new System.Drawing.Point(220, 13);
            this.textBoxB_Author.Name = "textBoxB_Author";
            this.textBoxB_Author.Size = new System.Drawing.Size(98, 20);
            this.textBoxB_Author.TabIndex = 5;
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(176, 16);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(38, 13);
            this.labelAuthor.TabIndex = 4;
            this.labelAuthor.Text = "Author";
            // 
            // textBoxB_ISBN
            // 
            this.textBoxB_ISBN.Location = new System.Drawing.Point(372, 11);
            this.textBoxB_ISBN.Name = "textBoxB_ISBN";
            this.textBoxB_ISBN.Size = new System.Drawing.Size(76, 20);
            this.textBoxB_ISBN.TabIndex = 3;
            // 
            // labelISBN
            // 
            this.labelISBN.AutoSize = true;
            this.labelISBN.Location = new System.Drawing.Point(334, 13);
            this.labelISBN.Name = "labelISBN";
            this.labelISBN.Size = new System.Drawing.Size(32, 13);
            this.labelISBN.TabIndex = 2;
            this.labelISBN.Text = "ISBN";
            // 
            // textBoxB_Name
            // 
            this.textBoxB_Name.Location = new System.Drawing.Point(80, 13);
            this.textBoxB_Name.Name = "textBoxB_Name";
            this.textBoxB_Name.Size = new System.Drawing.Size(76, 20);
            this.textBoxB_Name.TabIndex = 1;
            this.textBoxB_Name.TextChanged += new System.EventHandler(this.textBoxB_Name_TextChanged);
            // 
            // labelB_Name
            // 
            this.labelB_Name.AutoSize = true;
            this.labelB_Name.Location = new System.Drawing.Point(11, 16);
            this.labelB_Name.Name = "labelB_Name";
            this.labelB_Name.Size = new System.Drawing.Size(63, 13);
            this.labelB_Name.TabIndex = 0;
            this.labelB_Name.Text = "Book Name";
            // 
            // panelOutPut
            // 
            this.panelOutPut.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelOutPut.Controls.Add(this.bookDataGridView);
            this.panelOutPut.Location = new System.Drawing.Point(285, 123);
            this.panelOutPut.Name = "panelOutPut";
            this.panelOutPut.Size = new System.Drawing.Size(794, 526);
            this.panelOutPut.TabIndex = 6;
            // 
            // bookDataGridView
            // 
            this.bookDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.bookDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookDataGridView.Location = new System.Drawing.Point(0, 0);
            this.bookDataGridView.Name = "bookDataGridView";
            this.bookDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bookDataGridView.Size = new System.Drawing.Size(794, 526);
            this.bookDataGridView.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "BookInfoId";
            this.Column1.HeaderText = "BookInfo Id";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "BookName";
            this.Column2.HeaderText = "Book Name";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ISBN13";
            this.Column3.HeaderText = "ISBN";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Author";
            this.Column4.HeaderText = "Author";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Publisher";
            this.Column5.HeaderText = "Publisher";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Price";
            this.Column6.HeaderText = "Price";
            this.Column6.Name = "Column6";
            // 
            // FrmStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 661);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.panelOutPut);
            this.Controls.Add(this.FunctionOptions);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmStaff";
            this.Text = "Library Manager System: Staff";
            this.Load += new System.EventHandler(this.FrmStaff_Load);
            this.FunctionOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAccountManagement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panelOutPut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bookDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Panel FunctionOptions;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxAccountManagement;
        private System.Windows.Forms.Button buttonBook;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonUserAccount;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.TextBox textBoxB_Publisher;
        private System.Windows.Forms.Label labelPublisher;
        private System.Windows.Forms.TextBox textBoxB_Author;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.TextBox textBoxB_ISBN;
        private System.Windows.Forms.Label labelISBN;
        private System.Windows.Forms.TextBox textBoxB_Name;
        private System.Windows.Forms.Label labelB_Name;
        private System.Windows.Forms.Panel panelOutPut;
        private System.Windows.Forms.Button buttonB_Reset;
        private System.Windows.Forms.Button buttonB_Add;
        private System.Windows.Forms.Button buttonB_Delete;
        private System.Windows.Forms.Button buttonB_Modify;
        private System.Windows.Forms.TextBox textBoxB_Price;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.DataGridView bookDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}