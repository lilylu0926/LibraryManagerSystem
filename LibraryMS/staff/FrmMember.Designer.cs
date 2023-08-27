namespace LibraryMS.staff
{
    partial class FrmMember
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.booksDataGridView = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.setButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.memberCheckBox = new System.Windows.Forms.CheckBox();
            this.appliedCheckBox = new System.Windows.Forms.CheckBox();
            this.nonMembercheckBox = new System.Windows.Forms.CheckBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.userNameText = new System.Windows.Forms.TextBox();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.accountText = new System.Windows.Forms.TextBox();
            this.labelB_Name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.booksDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.booksDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Gray;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1724, 622);
            this.splitContainer1.SplitterDistance = 382;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 4;
            // 
            // booksDataGridView
            // 
            this.booksDataGridView.AllowUserToAddRows = false;
            this.booksDataGridView.AllowUserToDeleteRows = false;
            this.booksDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.booksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.booksDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column4,
            this.Column1,
            this.BookName,
            this.Column3,
            this.Column5,
            this.Column6});
            this.booksDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.booksDataGridView.Location = new System.Drawing.Point(0, 0);
            this.booksDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.booksDataGridView.MultiSelect = false;
            this.booksDataGridView.Name = "booksDataGridView";
            this.booksDataGridView.ReadOnly = true;
            this.booksDataGridView.RowHeadersVisible = false;
            this.booksDataGridView.RowHeadersWidth = 51;
            this.booksDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.booksDataGridView.Size = new System.Drawing.Size(1724, 382);
            this.booksDataGridView.TabIndex = 2;
            this.booksDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.booksDataGridView_CellClick);
            this.booksDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.booksDataGridView_CellFormatting);
            this.booksDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.booksDataGridView_DataBindingComplete);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Index";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "UserId";
            this.Column4.HeaderText = "UserId";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "account";
            this.Column1.HeaderText = "Account";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // BookName
            // 
            this.BookName.DataPropertyName = "account";
            this.BookName.HeaderText = "User Name";
            this.BookName.MinimumWidth = 6;
            this.BookName.Name = "BookName";
            this.BookName.ReadOnly = true;
            this.BookName.Width = 400;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "account";
            this.Column3.HeaderText = "Telephone";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "status";
            this.Column5.HeaderText = "Member";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "StatusId";
            this.Column6.HeaderText = "StatusId";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(45)))), ((int)(((byte)(70)))));
            this.label1.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(223)))), ((int)(((byte)(246)))));
            this.label1.Location = new System.Drawing.Point(1492, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 35);
            this.label1.TabIndex = 48;
            this.label1.Text = "ACCEPT";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // setButton
            // 
            this.setButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(45)))), ((int)(((byte)(70)))));
            this.setButton.BackgroundImage = global::LibraryMS.Properties.Resources.accept;
            this.setButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.setButton.FlatAppearance.BorderSize = 0;
            this.setButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.setButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setButton.ForeColor = System.Drawing.Color.Black;
            this.setButton.Location = new System.Drawing.Point(1487, 62);
            this.setButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(110, 99);
            this.setButton.TabIndex = 42;
            this.setButton.UseVisualStyleBackColor = false;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(45)))), ((int)(((byte)(70)))));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.setButton);
            this.groupBox1.Controls.Add(this.SearchBtn);
            this.groupBox1.Controls.Add(this.resetBtn);
            this.groupBox1.Controls.Add(this.userNameText);
            this.groupBox1.Controls.Add(this.labelAuthor);
            this.groupBox1.Controls.Add(this.accountText);
            this.groupBox1.Controls.Add(this.labelB_Name);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1720, 235);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conditions";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.memberCheckBox);
            this.groupBox2.Controls.Add(this.appliedCheckBox);
            this.groupBox2.Controls.Add(this.nonMembercheckBox);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(603, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(248, 234);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Membership";
            // 
            // memberCheckBox
            // 
            this.memberCheckBox.AutoSize = true;
            this.memberCheckBox.Font = new System.Drawing.Font("Calibri", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(223)))), ((int)(((byte)(246)))));
            this.memberCheckBox.Location = new System.Drawing.Point(19, 143);
            this.memberCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.memberCheckBox.Name = "memberCheckBox";
            this.memberCheckBox.Size = new System.Drawing.Size(117, 32);
            this.memberCheckBox.TabIndex = 2;
            this.memberCheckBox.Text = "Member";
            this.memberCheckBox.UseVisualStyleBackColor = true;
            // 
            // appliedCheckBox
            // 
            this.appliedCheckBox.AutoSize = true;
            this.appliedCheckBox.Font = new System.Drawing.Font("Calibri", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appliedCheckBox.ForeColor = System.Drawing.Color.White;
            this.appliedCheckBox.Location = new System.Drawing.Point(19, 101);
            this.appliedCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.appliedCheckBox.Name = "appliedCheckBox";
            this.appliedCheckBox.Size = new System.Drawing.Size(108, 32);
            this.appliedCheckBox.TabIndex = 1;
            this.appliedCheckBox.Text = "Applied";
            this.appliedCheckBox.UseVisualStyleBackColor = true;
            // 
            // nonMembercheckBox
            // 
            this.nonMembercheckBox.AutoSize = true;
            this.nonMembercheckBox.Font = new System.Drawing.Font("Calibri", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nonMembercheckBox.ForeColor = System.Drawing.Color.Gray;
            this.nonMembercheckBox.Location = new System.Drawing.Point(19, 62);
            this.nonMembercheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.nonMembercheckBox.Name = "nonMembercheckBox";
            this.nonMembercheckBox.Size = new System.Drawing.Size(156, 32);
            this.nonMembercheckBox.TabIndex = 0;
            this.nonMembercheckBox.Text = "NonMember";
            this.nonMembercheckBox.UseVisualStyleBackColor = true;
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackColor = System.Drawing.Color.Transparent;
            this.SearchBtn.BackgroundImage = global::LibraryMS.Properties.Resources.loupe;
            this.SearchBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SearchBtn.FlatAppearance.BorderSize = 0;
            this.SearchBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.SearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SearchBtn.Location = new System.Drawing.Point(984, 64);
            this.SearchBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(115, 122);
            this.SearchBtn.TabIndex = 42;
            this.SearchBtn.UseVisualStyleBackColor = false;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.BackColor = System.Drawing.Color.Transparent;
            this.resetBtn.BackgroundImage = global::LibraryMS.Properties.Resources.reset;
            this.resetBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.resetBtn.FlatAppearance.BorderSize = 0;
            this.resetBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.resetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetBtn.ForeColor = System.Drawing.Color.Black;
            this.resetBtn.Location = new System.Drawing.Point(1231, 62);
            this.resetBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(115, 122);
            this.resetBtn.TabIndex = 43;
            this.resetBtn.UseVisualStyleBackColor = false;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // userNameText
            // 
            this.userNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameText.Location = new System.Drawing.Point(193, 123);
            this.userNameText.Margin = new System.Windows.Forms.Padding(4);
            this.userNameText.Name = "userNameText";
            this.userNameText.Size = new System.Drawing.Size(376, 38);
            this.userNameText.TabIndex = 39;
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Font = new System.Drawing.Font("Calibri", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(223)))), ((int)(((byte)(246)))));
            this.labelAuthor.Location = new System.Drawing.Point(58, 134);
            this.labelAuthor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(118, 28);
            this.labelAuthor.TabIndex = 38;
            this.labelAuthor.Text = "User Name";
            // 
            // accountText
            // 
            this.accountText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountText.Location = new System.Drawing.Point(193, 64);
            this.accountText.Margin = new System.Windows.Forms.Padding(4);
            this.accountText.Name = "accountText";
            this.accountText.Size = new System.Drawing.Size(376, 38);
            this.accountText.TabIndex = 35;
            // 
            // labelB_Name
            // 
            this.labelB_Name.AutoSize = true;
            this.labelB_Name.Font = new System.Drawing.Font("Calibri", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelB_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(223)))), ((int)(((byte)(246)))));
            this.labelB_Name.Location = new System.Drawing.Point(86, 72);
            this.labelB_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelB_Name.Name = "labelB_Name";
            this.labelB_Name.Size = new System.Drawing.Size(90, 28);
            this.labelB_Name.TabIndex = 34;
            this.labelB_Name.Text = "Account";
            // 
            // FrmMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1724, 622);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMember";
            this.Text = "FrmMember";
            this.Load += new System.EventHandler(this.FrmMember_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.booksDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView booksDataGridView;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.TextBox userNameText;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.TextBox accountText;
        private System.Windows.Forms.Label labelB_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox memberCheckBox;
        private System.Windows.Forms.CheckBox appliedCheckBox;
        private System.Windows.Forms.CheckBox nonMembercheckBox;
        private System.Windows.Forms.Label label1;
    }
}