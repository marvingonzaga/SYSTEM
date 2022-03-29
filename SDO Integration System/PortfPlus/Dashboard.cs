using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
namespace SDO_Integrated_System
{
    public partial class Dashboard : DevExpress.XtraEditors.XtraForm
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        private void Connection()
        {
            Config.connString.openConnection();
        }
        private void btnProjectSoldier_Click(object sender, EventArgs e)
        {
            LoginProjectSoldier();

        }
        private void LoginProjectSoldier()
        {
            Cursor = Cursors.WaitCursor;

            if (DBuserType.Text == "Super Admin")
            {
                ProjectSoldierSuperAdmin mainFrm = new ProjectSoldierSuperAdmin();
                mainFrm.adminUserID.Text = dbUserID.Text;
                mainFrm.Show();
                this.Hide();
                Cursor = Cursors.Default;
            }
            else if (DBuserType.Text == "Administrator")
            {
                ProjectSoldierAdmin mainFrm = new ProjectSoldierAdmin();
                mainFrm.adminUserID.Text = dbUserID.Text;
                mainFrm.Show();
                this.Hide();
                Cursor = Cursors.Default;
            }
            else if (DBuserType.Text == "User")
            {
                ProjectSoldierUser mainFrm = new ProjectSoldierUser();
                mainFrm.psUserName.Text = DBUsername.Text;
                mainFrm.regUserID.Text = dbUserID.Text;
                mainFrm.certName.Text = DBUsername.Text;
                mainFrm.Show();
                this.Hide();
                Cursor = Cursors.Default;
            }
            
        }
        private Login loginfrm = (Login)Application.OpenForms["Login"];

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            if (DBuserType.Text == "School")
            {
                btnProjectSoldier.Enabled = false;
                btnICTTrainings.Enabled = false;
            }
        }

        #region mouseHover
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            btnSetting.BackgroundImage = Properties.Resources.settings_50px;
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            btnSetting.BackgroundImage = Properties.Resources.settings_40px;
        }
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pnlIctProjects.BringToFront();
            pnlIctProjects.Visible = true;
            btnICTTrainings.BackgroundImage = Properties.Resources.ICTTrainings_127px;
        }
        private void btnICTTrainings_MouseLeave(object sender, EventArgs e)
        {
            btnICTTrainings.BackgroundImage = Properties.Resources.ICTTrainings_100px;
        }
        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pnlInventorySystem.BringToFront();
            pnlInventorySystem.Visible = true;
            btnInventorySystem.BackgroundImage = Properties.Resources.fork_lift_127px;
        }
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            btnInventorySystem.BackgroundImage = Properties.Resources.fork_lift_100px;
        }
        private void btnProjectSoldier_MouseMove(object sender, MouseEventArgs e)
        {
            pnldbProjectSoldier.BringToFront();
            btnProjectSoldier.BackgroundImage = Properties.Resources.police127;
            pnldbProjectSoldier.Visible = true;
        }
        private void btnProjectSoldier_MouseLeave(object sender, EventArgs e)
        {
            btnProjectSoldier.BackgroundImage = Properties.Resources.police100;
        }


        #endregion

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            //loginfrm.textClear();
            //loginfrm.loginUserID.Text = "";
            //loginfrm.loginUserType.Text = "";
            //loginfrm.loginUserName.Text = "";
            //loginfrm.Show();
            //this.Close();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
           
            loginfrm.textClear();
            loginfrm.loginUserID.Text = "";
            loginfrm.loginUserType.Text = "";
            loginfrm.loginUserName.Text = "";
            loginfrm.adminUsername.Text = "";
            loginfrm.adminPassword.Text = "";
            loginfrm.Show();
            this.Close();
        }

        private void btnICTTrainings_Click(object sender, EventArgs e)
        {
            //LoginICTTrainings();

        }
        private void LoginICTTrainings()
        {
            Cursor = Cursors.WaitCursor;

            if (DBuserType.Text == "Administrator")
            {
                ProjectSoldierAdmin mainFrm = new ProjectSoldierAdmin();
                mainFrm.Show();
                this.Hide();
                Cursor = Cursors.Default;
            }
            else if (DBuserType.Text == "User")
            {
                ICT_Trainings.Forms.UserInterface mainFrm = new ICT_Trainings.Forms.UserInterface();
                mainFrm.psUserName.Text = DBUsername.Text;
                mainFrm.regUserID.Text = dbUserID.Text;
                mainFrm.certName.Text = DBUsername.Text;
                mainFrm.Show();
                this.Hide();
                Cursor = Cursors.Default;
            }

        }

        private void btnInventorySystem_Click(object sender, EventArgs e)
        {
            if (DBuserType.Text == "Super Admin")
            {
                Cursor = Cursors.WaitCursor;
                Inventory.Forms.MainForm mainFrm = new Inventory.Forms.MainForm();
                //mainFrm.adminUserID.Text = dbUserID.Text;
                mainFrm.Show();
                this.Hide();
                Cursor = Cursors.Default;
            }
            else if (DBuserType.Text == "School")
            {
                Cursor = Cursors.WaitCursor;
                Inventory.Forms.SchoolForm mainFrm = new Inventory.Forms.SchoolForm();
                //mainFrm.adminUserID.Text = dbUserID.Text;
                mainFrm.Show();
                this.Hide();
                Cursor = Cursors.Default;
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SettingForm setting = new SettingForm();
            setting.ShowDialog();
        }
    }
}