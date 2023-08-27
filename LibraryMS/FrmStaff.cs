using LibraryMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryMS
{
    public partial class FrmStaff : Form
    {
        public Account signAccount { get; set; }
        public FrmStaff()
        {
            InitializeComponent();
        }

        private void FrmStaff_Load(object sender, EventArgs e)
        {
            updateNameInfo();
        }

        private void updateNameInfo()
        {
            if (signAccount != null)
            {
                nameLabel.Text = signAccount.AccountName;
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
                
        }
    }
}
