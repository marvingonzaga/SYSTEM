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

namespace SDO_Integrated_System
{
    public partial class Feedback : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection conn = Config.connString.conn;
        private void Connection()
        {
            Config.connString.openConnection();
        }
        public Feedback()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            Connection();
            SqlCommand com = new SqlCommand("insert into Feedback (FName, Email, Contact, Message) values (@1, @2, @3, @4)",conn);
            com.Parameters.Add("@1", SqlDbType.Text).Value = tbFName.Text;
            com.Parameters.Add("@2", SqlDbType.Text).Value = tbEmail.Text;
            com.Parameters.Add("@3", SqlDbType.Text).Value = tbContact.Text;
            com.Parameters.Add("@4", SqlDbType.Text).Value = tbFeedback.Text;
            if (com.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Your message has been set successfully."+"\n"+"Thank you to your time to give as feedback.");
            }
        }
    }
}