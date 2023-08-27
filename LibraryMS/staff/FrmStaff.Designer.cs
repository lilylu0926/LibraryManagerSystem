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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FunctionOptions = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BookInfobutton = new System.Windows.Forms.Button();
            this.Membersbutton = new System.Windows.Forms.Button();
            this.BookListbutton = new System.Windows.Forms.Button();
            this.Lendbutton = new System.Windows.Forms.Button();
            this.Reservebutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.FunctionOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.FunctionOptions);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(45)))), ((int)(((byte)(70)))));
            this.splitContainer1.Size = new System.Drawing.Size(1535, 836);
            this.splitContainer1.SplitterDistance = 224;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // FunctionOptions
            // 
            this.FunctionOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(45)))), ((int)(((byte)(70)))));
            this.FunctionOptions.Controls.Add(this.pictureBox5);
            this.FunctionOptions.Controls.Add(this.pictureBox4);
            this.FunctionOptions.Controls.Add(this.pictureBox3);
            this.FunctionOptions.Controls.Add(this.pictureBox2);
            this.FunctionOptions.Controls.Add(this.pictureBox1);
            this.FunctionOptions.Controls.Add(this.BookInfobutton);
            this.FunctionOptions.Controls.Add(this.Membersbutton);
            this.FunctionOptions.Controls.Add(this.BookListbutton);
            this.FunctionOptions.Controls.Add(this.Lendbutton);
            this.FunctionOptions.Controls.Add(this.Reservebutton);
            this.FunctionOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FunctionOptions.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.FunctionOptions.Location = new System.Drawing.Point(0, 0);
            this.FunctionOptions.Margin = new System.Windows.Forms.Padding(4);
            this.FunctionOptions.Name = "FunctionOptions";
            this.FunctionOptions.Size = new System.Drawing.Size(224, 836);
            this.FunctionOptions.TabIndex = 4;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.No;
            this.pictureBox5.Image = global::LibraryMS.Properties.Resources.networking;
            this.pictureBox5.Location = new System.Drawing.Point(64, 537);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(73, 62);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 12;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.No;
            this.pictureBox4.Image = global::LibraryMS.Properties.Resources.book_stack;
            this.pictureBox4.Location = new System.Drawing.Point(64, 422);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(70, 53);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.No;
            this.pictureBox3.Image = global::LibraryMS.Properties.Resources.peer_to_peer;
            this.pictureBox3.Location = new System.Drawing.Point(64, 289);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(70, 69);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.No;
            this.pictureBox2.Image = global::LibraryMS.Properties.Resources.reserved;
            this.pictureBox2.Location = new System.Drawing.Point(64, 169);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 54);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.No;
            this.pictureBox1.Image = global::LibraryMS.Properties.Resources.home;
            this.pictureBox1.Location = new System.Drawing.Point(64, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // BookInfobutton
            // 
            this.BookInfobutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(223)))), ((int)(((byte)(246)))));
            this.BookInfobutton.FlatAppearance.BorderSize = 0;
            this.BookInfobutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BookInfobutton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BookInfobutton.ForeColor = System.Drawing.Color.Black;
            this.BookInfobutton.Location = new System.Drawing.Point(15, 109);
            this.BookInfobutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BookInfobutton.Name = "BookInfobutton";
            this.BookInfobutton.Size = new System.Drawing.Size(187, 41);
            this.BookInfobutton.TabIndex = 7;
            this.BookInfobutton.Text = "Home";
            this.BookInfobutton.UseVisualStyleBackColor = false;
            this.BookInfobutton.Click += new System.EventHandler(this.BookInfobutton_Click);
            // 
            // Membersbutton
            // 
            this.Membersbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(223)))), ((int)(((byte)(246)))));
            this.Membersbutton.FlatAppearance.BorderSize = 0;
            this.Membersbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Membersbutton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Membersbutton.ForeColor = System.Drawing.Color.Black;
            this.Membersbutton.Location = new System.Drawing.Point(15, 604);
            this.Membersbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Membersbutton.Name = "Membersbutton";
            this.Membersbutton.Size = new System.Drawing.Size(187, 41);
            this.Membersbutton.TabIndex = 5;
            this.Membersbutton.Text = "Members";
            this.Membersbutton.UseVisualStyleBackColor = false;
            this.Membersbutton.Click += new System.EventHandler(this.Membersbutton_Click);
            // 
            // BookListbutton
            // 
            this.BookListbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(223)))), ((int)(((byte)(246)))));
            this.BookListbutton.FlatAppearance.BorderSize = 0;
            this.BookListbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BookListbutton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BookListbutton.ForeColor = System.Drawing.Color.Black;
            this.BookListbutton.Location = new System.Drawing.Point(15, 480);
            this.BookListbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BookListbutton.Name = "BookListbutton";
            this.BookListbutton.Size = new System.Drawing.Size(187, 41);
            this.BookListbutton.TabIndex = 5;
            this.BookListbutton.Text = "Book List";
            this.BookListbutton.UseVisualStyleBackColor = false;
            this.BookListbutton.Click += new System.EventHandler(this.BookListbutton_Click);
            // 
            // Lendbutton
            // 
            this.Lendbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(223)))), ((int)(((byte)(246)))));
            this.Lendbutton.FlatAppearance.BorderSize = 0;
            this.Lendbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Lendbutton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lendbutton.ForeColor = System.Drawing.Color.Black;
            this.Lendbutton.Location = new System.Drawing.Point(15, 363);
            this.Lendbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Lendbutton.Name = "Lendbutton";
            this.Lendbutton.Size = new System.Drawing.Size(187, 41);
            this.Lendbutton.TabIndex = 5;
            this.Lendbutton.Text = "Lend";
            this.Lendbutton.UseVisualStyleBackColor = false;
            this.Lendbutton.Click += new System.EventHandler(this.Lendbutton_Click);
            // 
            // Reservebutton
            // 
            this.Reservebutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(223)))), ((int)(((byte)(246)))));
            this.Reservebutton.FlatAppearance.BorderSize = 0;
            this.Reservebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reservebutton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reservebutton.ForeColor = System.Drawing.Color.Black;
            this.Reservebutton.Location = new System.Drawing.Point(15, 228);
            this.Reservebutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Reservebutton.Name = "Reservebutton";
            this.Reservebutton.Size = new System.Drawing.Size(187, 41);
            this.Reservebutton.TabIndex = 5;
            this.Reservebutton.Text = "Reserve";
            this.Reservebutton.UseVisualStyleBackColor = false;
            this.Reservebutton.Click += new System.EventHandler(this.Reservebutton_Click);
            // 
            // FrmStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1535, 836);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmStaff";
            this.Text = "Library Management System: Staff";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmStaff_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.FunctionOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel FunctionOptions;
        private System.Windows.Forms.Button BookInfobutton;
        private System.Windows.Forms.Button Membersbutton;
        private System.Windows.Forms.Button BookListbutton;
        private System.Windows.Forms.Button Lendbutton;
        private System.Windows.Forms.Button Reservebutton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}