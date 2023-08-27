using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryMS.Model;

namespace LibraryMS
{
    public partial class Frmmain : Form
    {
        private List<ISubScriber> subscribers = new List<ISubScriber>();

        public event EventHandler deleteAccountEvent;

        private UcLogInfo ucLogInfofrm;

        public void Subscribe(ISubScriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void Unsubscribe(ISubScriber subscriber)
        {
            subscribers.Remove(subscriber);
        }

        public void NotifyAll(string message)
        {
            foreach (var subscriber in subscribers)
            {
                subscriber.Notify(message);
            }
        }

        public Account signAccount { get; set; }
        public Frmmain()
        {
            InitializeComponent();

        }

        private void Frmmain_Load(object sender, EventArgs e)
        {

            FrmSignIn frmSignIn = new FrmSignIn();
            frmSignIn.Owner = this;
            frmSignIn.FormClosed += new FormClosedEventHandler(SignInFormClosed);
            this.Text = "Library Manager System: Sign In";
            LoadRoleForm(frmSignIn);

        }

        /// <summary>
        /// FrmUser,FrmSupplier,FrmStaff closed event
        /// The sign in form will be shown when these three forms are closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormClosed(object sender, FormClosedEventArgs e)
        {
            this.logPanel.Controls.Clear();
            FrmSignIn frmSignIn = new FrmSignIn();
            frmSignIn.Owner = this;
            frmSignIn.FormClosed += new FormClosedEventHandler(SignInFormClosed);
            this.Text = "Library Manager System: Sign In";
            LoadRoleForm(frmSignIn);

        }

        private void UserControl_LogoutButtonClicked(object sender, EventArgs e)
        {
            this.logPanel.Controls.Clear();
            FrmSignIn frmSignIn = new FrmSignIn();
            frmSignIn.Owner = this;
            frmSignIn.FormClosed += new FormClosedEventHandler(SignInFormClosed);
            this.Text = "Library Manager System: Sign In";
            LoadRoleForm(frmSignIn);

        }

        private void UserControl_ProfileButtonClicked(object sender, EventArgs e)
        {
            NotifyAll("Profile click");

        }

        /// <summary>
        /// SignIn Form Closed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignInFormClosed(object sender, FormClosedEventArgs e)
        {
            //closed from signin button clicked
            if (signAccount != null)
            {
                if (signAccount.RoleId == 1) //Staff role
                {
                    FrmStaff frmStaff = new FrmStaff();
                    frmStaff.signAccount = signAccount;
                    frmStaff.mainForm = this;
                    frmStaff.FormClosed += new FormClosedEventHandler(FormClosed);
                    Subscribe(frmStaff);
                    this.Text = "Library Manager System: Staff";
                    LoadRoleForm(frmStaff);
                }
                else if (signAccount.RoleId == 2)
                {
                    FrmUser frmUser = new FrmUser();
                    frmUser.signAccount = signAccount;
                    frmUser.mainForm = this;
                    frmUser.FormClosed += new FormClosedEventHandler(FormClosed);
                    Subscribe(frmUser);
                    this.Text = "Library Manager System: User";
                    LoadRoleForm(frmUser);

                }
                else if (signAccount.RoleId == 3)
                {
                    FrmSupplier frmSupplier = new FrmSupplier();
                    frmSupplier.signAccount = signAccount;
                    frmSupplier.mainForm= this;
                    frmSupplier.FormClosed += new FormClosedEventHandler(FormClosed);
                    Subscribe(frmSupplier);
                    this.Text = "Library Manager System: Supplier";
                    LoadRoleForm(frmSupplier);

                }

                ucLogInfofrm = new UcLogInfo();
                this.logPanel.Controls.Clear();
                ucLogInfofrm.Dock = DockStyle.Top;
                ucLogInfofrm.logoutButtonClicked += UserControl_LogoutButtonClicked;
                ucLogInfofrm.profileButtonClicked += UserControl_ProfileButtonClicked;
                ucLogInfofrm.account = signAccount;
                logPanel.Controls.Add(ucLogInfofrm);
                // ucLogInfofrm.Location = new Point((logPanel.Width - 50)/2 , (logPanel.Height - ucLogInfofrm.Height) / 2);
            }
            else //closed from signup button clicked
            {
                FrmSignUp frmSignUp = new FrmSignUp();
                frmSignUp.Owner = this;
                frmSignUp.FormClosed += new FormClosedEventHandler(SignUpFormClosed);
                this.Text = "Library Manager System: Sign Up";
                LoadRoleForm(frmSignUp);
            }

        }

        /// <summary>
        /// SignUp form closed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignUpFormClosed(object sender, FormClosedEventArgs e)
        {
            //closed from signin button clicked
            if (signAccount != null)
            {
                if (signAccount.RoleId == 1) //Staff role
                {
                    FrmStaff frmStaff = new FrmStaff();
                    frmStaff.signAccount = signAccount;
                    frmStaff.mainForm = this;
                    frmStaff.FormClosed += new FormClosedEventHandler(FormClosed);
                    Subscribe(frmStaff);
                    this.Text = "Library Manager System: Staff";
                    LoadRoleForm(frmStaff);
                }
                else if (signAccount.RoleId == 2)
                {
                    FrmUser frmUser = new FrmUser();
                    signAccount.role = new Role();
                    signAccount.role.RoleId = 2;
                    frmUser.signAccount = signAccount;
                    
                    frmUser.mainForm = this;
                    frmUser.FormClosed += new FormClosedEventHandler(FormClosed);
                    Subscribe(frmUser);
                    this.Text = "Library Manager System: User";
                    LoadRoleForm(frmUser);

                }
                else if (signAccount.RoleId == 3)
                {
                    FrmSupplier frmSupplier = new FrmSupplier();
                    frmSupplier.signAccount = signAccount;
                    frmSupplier.mainForm = this;
                    frmSupplier.FormClosed += new FormClosedEventHandler(FormClosed);
                    Subscribe(frmSupplier);
                    this.Text = "Library Manager System: Supplier";
                    LoadRoleForm(frmSupplier);

                }

                ucLogInfofrm = new UcLogInfo();
                this.logPanel.Controls.Clear();
                ucLogInfofrm.Dock = DockStyle.Top;
                ucLogInfofrm.logoutButtonClicked += UserControl_LogoutButtonClicked;
                ucLogInfofrm.profileButtonClicked += UserControl_ProfileButtonClicked;
                ucLogInfofrm.account = signAccount;
                logPanel.Controls.Add(ucLogInfofrm);
                // ucLogInfofrm.Location = new Point((logPanel.Width - 50)/2 , (logPanel.Height - ucLogInfofrm.Height) / 2);
            }
            else //closed from signup button clicked
            {
                FrmSignIn frmSignIn = new FrmSignIn();
                frmSignIn.Owner = this;
                frmSignIn.FormClosed += new FormClosedEventHandler(SignInFormClosed);
                this.Text = "Library Manager System: Sign In";
                LoadRoleForm(frmSignIn);
            }

        }

        public void UpdateUcLogInfo()
        {
           if (ucLogInfofrm != null)
            {
                ucLogInfofrm.account = this.signAccount;
                ucLogInfofrm.updateAccount(this.signAccount);
            }
            
        }

        public void LogoutFormDeleteAccount()
        {
            this.logPanel.Controls.Clear();
            FrmSignIn frmSignIn = new FrmSignIn();
            frmSignIn.Owner = this;
            frmSignIn.FormClosed += new FormClosedEventHandler(SignInFormClosed);
            this.Text = "Library Manager System: Sign In";
            LoadRoleForm(frmSignIn);

        }





        /// <summary>
        /// Load child form in the main form
        /// </summary>
        /// <param name="form"></param>
        private void LoadRoleForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            //
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(form);
            form.Location = new Point((mainPanel.Width - form.Width) / 2, (mainPanel.Height - form.Height) / 2);
            form.Show();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
