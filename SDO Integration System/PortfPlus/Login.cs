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
using System.Net;
using System.Net.Mail;

namespace SDO_Integrated_System
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection conn = Config.connString.conn;
        SqlConnection connInventory = Config.connString.conn_Inventory;
        private void Connection()
        {
            Config.connString.openConnection();
        }
        private void ConnectionInventory()
        {
            Config.connString.openIventoryConnection();
        }
        public Login()
        {
            InitializeComponent();

        }
        private void Login_Load(object sender, EventArgs e)
        {
            //label3.Parent = pictureBox1;
            pnlLogin.Parent = pictureBox1;
            pnlCreateAccount.Parent = pictureBox1;
            panel2.Parent = pictureBox1;
            GetManualLink();
        }
        private void getVersion()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Connection();
                SqlCommand com = new SqlCommand("select Version from SysVersion where Version='" + SystemVersion.Text + "'", conn);
                SqlDataReader reader = com.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count = count + 1;
                }
                if (count != 1)
                {
                    DialogResult dialogResult = MessageBox.Show("There is a latest update to the system!" + "\n" + "You have to update your current version to newer version in order continue using it", "UPDATE!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (dialogResult == DialogResult.OK)
                    {
                        Cursor = Cursors.Default;
                        pnlUpdate.BringToFront();
                        pnlUpdate.Visible = true;
                        pictureBox1.Enabled = false;
                        pnlLogin.Enabled = false;
                        GetUpdateLink();
                    }
                    else if (dialogResult == DialogResult.None)
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    verifyAccount();
                }
            }
            catch (Exception)
            {
                DialogResult result = MessageBox.Show("Internet connection problem encountered" + "\n" + "Retry in few seconds.", "Internet Connection Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Retry)
                {
                    Connection();
                }
                else
                {
                    Application.Exit();
                }
            }


        }
        private void GetUpdateLink()
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("select Link from SysVersion", conn);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    string link = reader.GetString(0);
                    tbLink.Text = link;
                }
            }
            catch (Exception) { }

        }

        private void GetManualLink()
        {
            try
            {
                ConnectionInventory();
                SqlCommand com = new SqlCommand("select Manual from SysVersion", conn);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    string link = reader.GetString(0);
                    tbManual.Text = link;
                }
            }
            catch (Exception) { }

        }

        #region login Account
        private void btnLogin_Click(object sender, EventArgs e)
        {
            getVersion();

        }
        private void verifyAccount()
        {
            Username.Focus();
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("Select Username, Password from AntiqueUsers where Username='" + Username.Text + "' and Password='" + Password.Text + "'", conn);
                SqlDataReader reader = com.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count = count + 1;

                }
                if (count == 1)
                {
                    Connection();
                    try
                    {
                        SqlCommand com1 = new SqlCommand("Select UserType, UserID, concat(FName,' ', MName,' ', LName,' ', NameExt) as Name  from AntiqueUsers where Username='" + Username.Text + "' and Password='" + Password.Text + "'", conn);
                        SqlDataReader reader1 = com1.ExecuteReader();
                        while (reader1.Read())
                        {
                            string usertype = reader1.GetString(0);
                            int userID = reader1.GetInt32(1);
                            string userName = reader1.GetString(2);
                            loginUserType.Text = usertype;
                            loginUserID.Text = userID.ToString();
                            loginUserName.Text = userName;
                            Cursor = Cursors.Default;
                            if (loginUserType.Text != "" && loginUserName.Text != "")
                            {
                                LoginAccount();
                            }
                        }
                    }
                    catch
                    {

                        Cursor = Cursors.Default;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username/password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ee)
            {

                DialogResult result = MessageBox.Show(ee.Message, "Server Problem", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Retry)
                {
                    verifyAccount();
                    Cursor = Cursors.Default;
                }

            }
        }
        private void LoginAccount()
        {
            Connection();
            SqlCommand com = new SqlCommand("Select * from AntiqueUsers where Username='" + Username.Text + "' and Password='" + Password.Text + "' and UserType='User'", conn);
            SqlDataReader reader = com.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {

                Dashboard mainFrm = new Dashboard();
                mainFrm.DBuserType.Text = loginUserType.Text;
                mainFrm.DBUsername.Text = loginUserName.Text;
                mainFrm.dbUserID.Text = loginUserID.Text;
                mainFrm.Show();
                this.Hide();
                Cursor = Cursors.Default;

            }

            else
            {

                MessageBox.Show("Incorrect Username or Password");
                Cursor = Cursors.Default;
            }
        }
        #endregion
        public void textClear()
        {
            Username.Text = "";
            Password.Text = "";
            loginUserType.Text = "";
            loginUserID.Text = "";
        }
        private void loginUserType_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginUserID_TextChanged(object sender, EventArgs e)
        {


        }
        private void button_WOC5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void caCreateBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Connection();
            SqlCommand com = new SqlCommand("Select FName, MName, LName From AntiqueUsers Where FName='" + caFname.Text + "' and MName='" + caMI.Text + "' and LName='" + caLName.Text + "'", conn);
            SqlDataReader reader = com.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                MessageBox.Show("Your Name matched on the records already, please contact the Administrator for verification.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                createAccount();
            }
        }
        private void createAccount()
        {
            if (caFname.Text == "" || caLName.Text == "" || caContact.Text == "" || caEmail.Text == "" || caUsername.Text == "" || caPassword.Text == "")
            {
                MessageBox.Show("Fill in all required informations", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                Connection();
                SqlCommand com = new SqlCommand("INSERT INTO [dbo].[AntiqueUsers] " +
                    "([FName]," +
                    "[MName]," +
                    "[LName]," +
                    "[NameExt]," +
                    "[Designation]," +
                    "[PositionTitle]," +
                    "[Contact]," +
                    "[Username]," +
                    "[Password], UserType, Email, SchoolID, SchoolName) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13)", conn);

                com.Parameters.Add("@1", SqlDbType.VarChar).Value = caFname.Text;
                com.Parameters.Add("@2", SqlDbType.VarChar).Value = caMI.Text;
                com.Parameters.Add("@3", SqlDbType.VarChar).Value = caLName.Text;
                com.Parameters.Add("@4", SqlDbType.VarChar).Value = caExt.Text;
                com.Parameters.Add("@5", SqlDbType.VarChar).Value = caDesignation.Text;
                com.Parameters.Add("@6", SqlDbType.VarChar).Value = caPositionTitle.Text;
                com.Parameters.Add("@7", SqlDbType.VarChar).Value = caContact.Text;
                com.Parameters.Add("@8", SqlDbType.VarChar).Value = caUsername.Text;
                com.Parameters.Add("@9", SqlDbType.VarChar).Value = caPassword.Text;
                com.Parameters.Add("@10", SqlDbType.VarChar).Value = "User";
                com.Parameters.Add("@11", SqlDbType.VarChar).Value = caEmail.Text;
                com.Parameters.Add("@12", SqlDbType.VarChar).Value = tbSchoolID.Text;
                com.Parameters.Add("@13", SqlDbType.VarChar).Value = tbSchoolName.Text;
                if (com.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Registered Successfully!");
                    pnlCreateAccount.Visible = false;
                    Cursor = Cursors.Default;
                }
            }
        }
        private void button_WOC4_Click(object sender, EventArgs e)
        {
            pnlCreateAccount.Visible = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pnlCreateAccount.BringToFront();
            pnlCreateAccount.Visible = true;
        }

        private void button_WOC6_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            pnlLogin.SendToBack();
            adminUsername.Text = "";
            adminPassword.Text = "";
            panel3.Visible = true;
            panel3.BringToFront();
            adminUsername.Focus();
        }
        private void LoginAccountSchool()
        {
            Dashboard mainFrm = new Dashboard();
            Connection();
            SqlCommand com = new SqlCommand("Select * from AntiqueUsers where Username='" + adminUsername.Text + "' and Password='" + adminPassword.Text + "' and UserType ='School'", conn);
            SqlDataReader reader = com.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;

                 string schoolID = reader.GetString(12);
                 mainFrm.DBSchoolID.Text = schoolID;

                
            }
            if (count == 1)
            {
                
                mainFrm.DBuserType.Text = "School";
                //mainFrm.DBUsername.Text = loginUserName.Text;
                //mainFrm.dbUserID.Text = loginUserID.Text;
                mainFrm.Show();
                this.Hide();
                Cursor = Cursors.Default;
            }
            else
            {

                MessageBox.Show("Incorrect Username or Password");
                Cursor = Cursors.Default;
            }
        }
        private void button_WOC7_Click(object sender, EventArgs e)
        {
            if(logAs.Text=="School")
            {
                LoginAccountSchool();
            }
            else
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    Connection();
                    SqlCommand com = new SqlCommand("select Version from SysVersion where Version='" + SystemVersion.Text + "'", conn);
                    SqlDataReader reader = com.ExecuteReader();
                    int count = 0;
                    while (reader.Read())
                    {
                        count = count + 1;
                    }
                    if (count != 1)
                    {
                        DialogResult dialogResult = MessageBox.Show("There is a latest update to the system" + "\n" + "You have to update in order continue using it", "UPDATE!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        if (dialogResult == DialogResult.OK)
                        {
                            System.Windows.Forms.Application.ExitThread();
                        }
                        else if (dialogResult == DialogResult.None)
                        {
                            Application.Exit();
                        }
                    }
                    else
                    {
                        verifyAccountAdmin();
                    }
                }
                catch (Exception)
                {
                    DialogResult result = MessageBox.Show("Internet connection problem encountered" + "\n" + "Retry in few seconds.", "Internet Connection Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
                    if (result == DialogResult.Retry)
                    {
                        Connection();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
           
        }
        private void verifyAccountAdmin()
        {
            adminUsername.Focus();
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("Select Username, Password from AntiqueUsers where Username='" + adminUsername.Text + "' and Password='" + adminPassword.Text + "'", conn);
                SqlDataReader reader = com.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count = count + 1;

                }
                if (count == 1)
                {
                    Connection();
                    try
                    {
                        SqlCommand com1 = new SqlCommand("Select UserType, UserID, concat(FName,' ', MName,' ', LName,' ', NameExt) as Name  from AntiqueUsers where Username='" + adminUsername.Text + "' and Password='" + adminPassword.Text + "'", conn);
                        SqlDataReader reader1 = com1.ExecuteReader();
                        while (reader1.Read())
                        {
                            string usertype = reader1.GetString(0);
                            int userID = reader1.GetInt32(1);
                            string userName = reader1.GetString(2);
                            loginUserType.Text = usertype;
                            loginUserID.Text = userID.ToString();
                            loginUserName.Text = userName;
                            Cursor = Cursors.Default;
                            if (loginUserType.Text != "" && loginUserName.Text != "")
                            {
                                LoginAccountAdmin();
                            }
                        }
                    }
                    catch
                    {

                        Cursor = Cursors.Default;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username/password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ee)
            {

                DialogResult result = MessageBox.Show(ee.Message, "Server Problem", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Retry)
                {
                    verifyAccount();
                    Cursor = Cursors.Default;
                }
            }
        }
        private void LoginAccountAdmin()
        {
           
            Connection();
            SqlCommand com = new SqlCommand("Select * from AntiqueUsers where NOT UserType ='User' AND Username='" + adminUsername.Text + "' and Password='" + adminPassword.Text + "' and UserType ='"+loginAs.Text+"'", conn);
            SqlDataReader reader = com.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;

                //int schoolID = reader.GetInt32(12);
                // mainFrm.DBSchoolID.Text = schoolID.ToString();
            }
            if (count == 1)
            {
                Dashboard mainFrm = new Dashboard();
                mainFrm.DBuserType.Text = loginUserType.Text;
                mainFrm.DBUsername.Text = loginUserName.Text;
                mainFrm.dbUserID.Text = loginUserID.Text;
                mainFrm.Show();
                this.Hide();
                Cursor = Cursors.Default;
            }
            else
            {

                MessageBox.Show("Incorrect Username or Password");
                Cursor = Cursors.Default;
            }
        }

        private void button_WOC9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(tbLink.Text);
        }

        private void button_WOC8_Click(object sender, EventArgs e)
        {
            pnlUpdate.Visible = false;
            pictureBox1.Enabled = true;
            pnlLogin.Enabled = true;
        }

        private void loginUserManual_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(tbManual.Text);
        }

        private void loginFeedback_Click(object sender, EventArgs e)
        {
            Feedback frm = new Feedback();
            frm.ShowDialog();
        }

        private void tbpasswordShowPass_Click(object sender, EventArgs e)
        {
            if (Password.UseSystemPasswordChar == true)
            {
                Password.UseSystemPasswordChar = false;
            }
            else
            {
                Password.UseSystemPasswordChar = true;
            }

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (adminPassword.UseSystemPasswordChar == true)
            {
                adminPassword.UseSystemPasswordChar = false;
            }
            else
            {
                adminPassword.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (caPassword.UseSystemPasswordChar == true)
            {
                caPassword.UseSystemPasswordChar = false;
            }
            else
            {
                caPassword.UseSystemPasswordChar = true;
            }
        }

        private void comboBoxEdit1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (logAs.SelectedItem.ToString() == "Trainer")
            {
                loginAs.Text = "Administrator";
            }
            else if (logAs.SelectedItem.ToString() == "School")
            {
                loginAs.Text = "School";
            }
            else if (logAs.SelectedItem.ToString() == "Super Admin")
            {
                loginAs.Text = "Super Admin";
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            caSchool.Items.Clear();
            //Connection();
            //SqlCommand com = new SqlCommand("select SchoolID, Name from tbl_Schools", connInventory);
            //SqlDataReader reader = com.ExecuteReader();
            //while (reader.Read())
            //{
            //    string schools = reader.GetString(1);
            //    caSchool.Items.Add(schools);
            //}

            ConnectionInventory();
            SqlCommand com = new SqlCommand("select SchoolID, Name from tbl_Schools", connInventory);
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                caSchool.Items.Add(ds.Tables[0].Rows[i][0] + " | " + ds.Tables[0].Rows[i][1]);
            }
        }

        private void caSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            string result = caSchool.Text.Substring(0, 6);
            tbSchoolID.Text = result;

            string schoolName = caSchool.Text.Substring(9);
            tbSchoolName.Text = schoolName;
        }

        private void resetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPasswordForm frm = new ResetPasswordForm();
            frm.ShowDialog();
            //DialogResult result = MessageBox.Show("Are you sure you wish to reset your password?" + "\n" + "Press yes to continue", "Reset password", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            //if (result == DialogResult.Yes)
            //{
            //    SmtpClient Client = new SmtpClient()
            //    {
            //        Host = "smtp.gmail.com",
            //        Port = 587,
            //        EnableSsl = true,
            //        DeliveryMethod = SmtpDeliveryMethod.Network,
            //        UseDefaultCredentials = false,
            //        Credentials = new NetworkCredential()
            //        {
            //            UserName = "ictservices.sdoantique@deped.gov.ph",
            //            Password = "@Junnifer1987"
            //        }
            //    };

            //    MailAddress FromEmail = new MailAddress("ictservices.sdoantique@deped.gov.ph", "ICT Services");
            //    MailAddress ToEmail = new MailAddress(caEmail.Text, "Someone");
            //    MailMessage Message = new MailMessage()
            //    {
            //        From = FromEmail,
            //        Subject = "Reset Password",
            //        Body = "Your password was reset successfuly! \n\nYour password is "

            //    };
            //    Message.To.Add(ToEmail);

            //    try
            //    {
            //        Client.Send(Message);
            //        MessageBox.Show("Sent successfully! \nKindly check your email for your temporary password", "Done");
            //    }
            //    catch (Exception ee)
            //    {
            //        MessageBox.Show("Somethin wrong \n" + ee.Message + "Error");
            //    }
            //}
            
            
        }
    }
}