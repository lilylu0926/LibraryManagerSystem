namespace LibraryMS
{
    partial class FrmUser
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.borrowButton = new System.Windows.Forms.Button();
            this.historybutton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.FunctionOptions.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(1493, 682);
            this.splitContainer1.SplitterDistance = 217;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // FunctionOptions
            // 
            this.FunctionOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(45)))), ((int)(((byte)(70)))));
            this.FunctionOptions.Controls.Add(this.pictureBox3);
            this.FunctionOptions.Controls.Add(this.pictureBox2);
            this.FunctionOptions.Controls.Add(this.pictureBox1);
            this.FunctionOptions.Controls.Add(this.borrowButton);
            this.FunctionOptions.Controls.Add(this.historybutton);
            this.FunctionOptions.Controls.Add(this.returnButton);
            this.FunctionOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FunctionOptions.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.FunctionOptions.Location = new System.Drawing.Point(0, 0);
            this.FunctionOptions.Margin = new System.Windows.Forms.Padding(4);
            this.FunctionOptions.Name = "FunctionOptions";
            this.FunctionOptions.Size = new System.Drawing.Size(217, 682);
            this.FunctionOptions.TabIndex = 4;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::LibraryMS.Properties.Resources.transaction_history;
            this.pictureBox3.Location = new System.Drawing.Point(47, 371);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(113, 80);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LibraryMS.Properties.Resources.undo;
            this.pictureBox2.Location = new System.Drawing.Point(47, 213);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(113, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibraryMS.Properties.Resources.home;
            this.pictureBox1.Location = new System.Drawing.Point(62, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // borrowButton
            // 
            this.borrowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(223)))), ((int)(((byte)(246)))));
            this.borrowButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.borrowButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.borrowButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borrowButton.ForeColor = System.Drawing.Color.Black;
            this.borrowButton.Location = new System.Drawing.Point(15, 153);
            this.borrowButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.borrowButton.Name = "borrowButton";
            this.borrowButton.Size = new System.Drawing.Size(187, 41);
            this.borrowButton.TabIndex = 7;
            this.borrowButton.Text = "Home";
            this.borrowButton.UseVisualStyleBackColor = false;
            this.borrowButton.Click += new System.EventHandler(this.borrowButton_Click);
            // 
            // historybutton
            // 
            this.historybutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(223)))), ((int)(((byte)(246)))));
            this.historybutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.historybutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.historybutton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historybutton.ForeColor = System.Drawing.Color.Black;
            this.historybutton.Location = new System.Drawing.Point(12, 468);
            this.historybutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.historybutton.Name = "historybutton";
            this.historybutton.Size = new System.Drawing.Size(187, 41);
            this.historybutton.TabIndex = 5;
            this.historybutton.Text = "History";
            this.historybutton.UseVisualStyleBackColor = false;
            this.historybutton.Click += new System.EventHandler(this.historybutton_Click);
            // 
            // returnButton
            // 
            this.returnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(223)))), ((int)(((byte)(246)))));
            this.returnButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.returnButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnButton.ForeColor = System.Drawing.Color.Black;
            this.returnButton.Location = new System.Drawing.Point(15, 309);
            this.returnButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(187, 41);
            this.returnButton.TabIndex = 5;
            this.returnButton.Text = "Return";
            this.returnButton.UseVisualStyleBackColor = false;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // FrmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1493, 682);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Library Manager System: User";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmUser_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.FunctionOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel FunctionOptions;
        private System.Windows.Forms.Button borrowButton;
        private System.Windows.Forms.Button historybutton;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}