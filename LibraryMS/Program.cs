using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryMS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //FrmSignIn frmSignIn = new FrmSignIn();
            //if (frmSignIn.ShowDialog() == DialogResult.OK )
            //{
            //    Frmmain frmmain = new Frmmain();
            //    frmmain.signAccount = frmSignIn.signAccount;
            //    Application.Run(frmmain);
            //}
            Application.Run(new Frmmain());
           // Application.Run(new FrmStaff());

        }
    }
}
