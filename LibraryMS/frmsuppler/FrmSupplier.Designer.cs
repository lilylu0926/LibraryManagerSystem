namespace LibraryMS
{
    partial class FrmSupplier
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sellbutton = new System.Windows.Forms.Button();
            this.historyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.FunctionOptions.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(1453, 790);
            this.splitContainer1.SplitterDistance = 243;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // FunctionOptions
            // 
            this.FunctionOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(45)))), ((int)(((byte)(70)))));
            this.FunctionOptions.Controls.Add(this.pictureBox2);
            this.FunctionOptions.Controls.Add(this.pictureBox1);
            this.FunctionOptions.Controls.Add(this.sellbutton);
            this.FunctionOptions.Controls.Add(this.historyButton);
            this.FunctionOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FunctionOptions.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.FunctionOptions.Location = new System.Drawing.Point(0, 0);
            this.FunctionOptions.Margin = new System.Windows.Forms.Padding(4);
            this.FunctionOptions.Name = "FunctionOptions";
            this.FunctionOptions.Size = new System.Drawing.Size(243, 790);
            this.FunctionOptions.TabIndex = 4;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LibraryMS.Properties.Resources.home;
            this.pictureBox2.Location = new System.Drawing.Point(57, 41);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(102, 92);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibraryMS.Properties.Resources.transaction_history1;
            this.pictureBox1.Location = new System.Drawing.Point(57, 236);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // sellbutton
            // 
            this.sellbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(223)))), ((int)(((byte)(246)))));
            this.sellbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sellbutton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sellbutton.ForeColor = System.Drawing.Color.Black;
            this.sellbutton.Location = new System.Drawing.Point(15, 165);
            this.sellbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sellbutton.Name = "sellbutton";
            this.sellbutton.Size = new System.Drawing.Size(187, 41);
            this.sellbutton.TabIndex = 7;
            this.sellbutton.Text = "Home";
            this.sellbutton.UseVisualStyleBackColor = false;
            this.sellbutton.Click += new System.EventHandler(this.sellbutton_Click);
            // 
            // historyButton
            // 
            this.historyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(223)))), ((int)(((byte)(246)))));
            this.historyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.historyButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyButton.ForeColor = System.Drawing.Color.Black;
            this.historyButton.Location = new System.Drawing.Point(15, 343);
            this.historyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(187, 41);
            this.historyButton.TabIndex = 5;
            this.historyButton.Text = "History";
            this.historyButton.UseVisualStyleBackColor = false;
            this.historyButton.Click += new System.EventHandler(this.historyButton_Click);
            // 
            // FrmSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1453, 790);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmSupplier";
            this.Text = "Library Manager System: Supplier";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSupplier_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.FunctionOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel FunctionOptions;
        private System.Windows.Forms.Button sellbutton;
        private System.Windows.Forms.Button historyButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}