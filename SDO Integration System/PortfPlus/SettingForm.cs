using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.IO.Ports;

namespace SDO_Integrated_System
{
    public partial class SettingForm : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection conn = Config.connString.conn;
        public SettingForm()
        {
            InitializeComponent();
        }
        private void Connection()
        {
            Config.connString.openConnection();
        }
        private Dashboard dashboard = (Dashboard)Application.OpenForms["Dashboard"];
        private void SettingForm_Load(object sender, EventArgs e)
        {
            Connection();
            SqlCommand com = new SqlCommand("select * from AntiqueUsers where UserID='"+dashboard.dbUserID.Text+"'",conn);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                string fname = reader.GetString(1);
                caFname.Text = fname;

                if (reader["MName"] == DBNull.Value)
                    caMI.Text = "";
                else
                    caMI.Text = reader.GetString(2);

                string lname = reader.GetString(3);
                caLName.Text = lname;

                if (reader["NameExt"] == DBNull.Value)
                    caExt.Text = "";
                else
                    caExt.Text = reader.GetString(4);

                if (reader["Designation"] == DBNull.Value)
                    caDesignation.Text = "";
                else
                    caDesignation.Text = reader.GetString(5);

                if (reader["PositionTitle"] == DBNull.Value)
                    caPositionTitle.Text = "";
                else
                    caPositionTitle.Text = reader.GetString(6);

                string contact = reader.GetString(7);
                string username = reader.GetString(8);
                string password = reader.GetString(9);
                string email = reader.GetString(11);
              
                caContact.Text = contact;
                caEmail.Text = email;
                caUsername.Text = username;
                caPassword.Text = password;


                if (reader["SchoolID"] == DBNull.Value)
                    caSchool.Text = "";
                else
                    caSchool.Text = reader.GetString(12 + 13);
            }
        }

        private void caSchool_DropDown(object sender, EventArgs e)
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

            Connection();
            SqlCommand com = new SqlCommand("select SchoolID, Name from tbl_Schools", conn);
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "ictservices.sdoantique@deped.gov.ph",
                    Password = "@Junnifer1987"
                }
            };

            MailAddress FromEmail = new MailAddress("ictservices.sdoantique@deped.gov.ph", "ICT Services");
            MailAddress ToEmail = new MailAddress(caEmail.Text, "Someone");
            MailMessage Message = new MailMessage()
            {
                From = FromEmail,
                Subject = "Reset Password",
                Body = "Your password was reset successfuly! \n\nYour password is "

            };
            Message.To.Add(ToEmail);

            try
            {
                Client.Send(Message);
                MessageBox.Show("Sent Successfully", "Done");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Somethin wrong \n" + ee.Message + "Error");
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

        private void caCreateBtn_Click(object sender, EventArgs e)
        {
            if (caFname.Text == "" || caLName.Text == "" || caContact.Text == "" || caEmail.Text == "" || caUsername.Text == "" || caPassword.Text == "")
            {
                MessageBox.Show("Fill in all required informations", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                Connection();
                SqlCommand com = new SqlCommand("update AntiqueUsers set " +
                    "[FName]=@1," +
                    "[MName]=@2," +
                    "[LName]=@3," +
                    "[NameExt]=@4," +
                    "[Designation]=@5," +
                    "[PositionTitle]=@6," +
                    "[Contact]=@7," +
                    "[Username]=@8," +
                    "[Password]=@9, Email=@11, SchoolID=@12, SchoolName=@13 where UserID='" + dashboard.dbUserID.Text + "'", conn);

                com.Parameters.Add("@1", SqlDbType.VarChar).Value = caFname.Text;
                com.Parameters.Add("@2", SqlDbType.VarChar).Value = caMI.Text;
                com.Parameters.Add("@3", SqlDbType.VarChar).Value = caLName.Text;
                com.Parameters.Add("@4", SqlDbType.VarChar).Value = caExt.Text;
                com.Parameters.Add("@5", SqlDbType.VarChar).Value = caDesignation.Text;
                com.Parameters.Add("@6", SqlDbType.VarChar).Value = caPositionTitle.Text;
                com.Parameters.Add("@7", SqlDbType.VarChar).Value = caContact.Text;
                com.Parameters.Add("@8", SqlDbType.VarChar).Value = caUsername.Text;
                com.Parameters.Add("@9", SqlDbType.VarChar).Value = caPassword.Text;
                com.Parameters.Add("@11", SqlDbType.VarChar).Value = caEmail.Text;
                com.Parameters.Add("@12", SqlDbType.VarChar).Value = tbSchoolID.Text;
                com.Parameters.Add("@13", SqlDbType.VarChar).Value = tbSchoolName.Text;
                if (com.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Updated Successfully!");
                    
                    Cursor = Cursors.Default;
                }
            }
        }
    }
}