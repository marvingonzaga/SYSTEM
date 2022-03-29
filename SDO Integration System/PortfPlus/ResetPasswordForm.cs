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
using System.Data.SqlClient;

namespace SDO_Integrated_System
{
    public partial class ResetPasswordForm : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection conn = Config.connString.conn;
        public ResetPasswordForm()
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
            Random r = new Random();
            tbRandomPass.Text = r.Next().ToString();
        }

        private void caSchool_DropDown(object sender, EventArgs e)
        {
            
        }

        private void caSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            Connection();
            SqlCommand com = new SqlCommand("select * from AntiqueUsers where FName='"+caFname.Text+ "' and LName='" + caLName.Text + "' and Contact='" + caContact.Text + "' and Email='" + caEmail.Text + "'", conn);
            SqlDataReader reader = com.ExecuteReader();
            int count = 0;
            while(reader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                Connection();
                SqlCommand updatePass = new SqlCommand("Update AntiqueUsers set Password='"+tbRandomPass.Text+ "' where FName='" + caFname.Text + "' and LName='" + caLName.Text + "' and Contact='" + caContact.Text + "' and Email='" + caEmail.Text + "'", conn);
                if (updatePass.ExecuteNonQuery() == 1)
                {
                    sendEmail();
                }
            }
            else
            {
                MessageBox.Show("Its seems you are not registered to the system.\nKindly check all the informations you've entered and try again.","Message", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            
        }
        private void sendEmail()
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
                Body = "Your password was reset successfuly! \n\nYour temporary password is: " + tbRandomPass.Text

            };
            Message.To.Add(ToEmail);

            try
            {
                Client.Send(Message);
                MessageBox.Show("Sent successfully! \nKindly check your email for your temporary password", "Done");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Something wrong \nKindly check your internet connection" + ee.Message + "Error");
            }
        }
    }
}