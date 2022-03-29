using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace PortfPlus
{
    public partial class SendEmail : Form
    {
        public SendEmail()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            NetworkCredential login = new NetworkCredential(tbUsername.Text, tbPassword.Text);
            SmtpClient client = new SmtpClient(tbSMTP.Text);
            client.Port = Convert.ToInt32(tbPort.Text);
            client.EnableSsl = true;
            client.Credentials = login;

            MailAddress sendAddr = new MailAddress(tbUsername.Text);
            MailAddress recAddr = new MailAddress(tbTo.Text);

            MailMessage msg = new MailMessage(sendAddr, recAddr);
            msg.Subject = tbSubject.Text;
            msg.Body = tbBody.Text;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.SendCompleted += new SendCompletedEventHandler(sendCallback);

            string userToken = "Sending";
            client.SendAsync(msg, userToken);

        }
        private static void sendCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled || e.Error != null)
            {
                MessageBox.Show("Error sending email!!");
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Sent Successfully");
            }
        }
        private void tbUsername_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
