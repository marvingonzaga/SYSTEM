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

namespace SDO_Integrated_System.Inventory.Forms
{
    public partial class AccountRegistration : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection conn = Config.connString.conn;
        public AccountRegistration()
        {
            InitializeComponent();
        }
        private void Connection()
        {
            Config.connString.openConnection();
        }
        private MainForm mainfrm = (MainForm)Application.OpenForms["MainForm"];
        private void AccountRegistration_Load(object sender, EventArgs e)
        {
            tbAccountID.Text = mainfrm.tbAccountID.Text;
            if (tbFor.Text == "update")
            {
                Connection();
                SqlCommand com = new SqlCommand("select * from tbl_Accounts where id = '"+tbAccountID.Text+"'", conn);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {

                    string accountType = reader.GetString(3);
                    string email = reader.GetString(2);
                    string status = reader.GetString(4);

                    arAccountType.Text = accountType;
                    arUserEmail.Text = email;
                    arStatus.Text = status;

                    if (reader["Notes"] == DBNull.Value)
                        arNotes.Text = "";
                    else
                        arNotes.Text = reader.GetString(5);


                }
            }
        }
        private void ARSaveBtn_Click(object sender, EventArgs e)
        {
            if(tbFor.Text=="update")
            {
                Connection();
                SqlCommand com = new SqlCommand("update [dbo].[tbl_Accounts] set [Accounts]=@1 ," +
                    "[Type] =@2," +
                    "[Status] =@3," +
                    "[Notes] = @4 where id ='"+tbAccountID.Text+"'", conn);

                com.Parameters.Add("@1", SqlDbType.VarChar).Value = arUserEmail.Text;
                com.Parameters.Add("@2", SqlDbType.VarChar).Value = arAccountType.Text;
                com.Parameters.Add("@3", SqlDbType.VarChar).Value = arStatus.Text;
                com.Parameters.Add("@4", SqlDbType.VarChar).Value = arNotes.Text;

                if (com.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Updated Successfully!");
                }
            }
            else
            {
                Connection();
                SqlCommand com = new SqlCommand("INSERT INTO [dbo].[tbl_Accounts] ([Accounts] ,[Type] ,[Status] ,[Notes]) VALUES (@1, @2, @3, @4)", conn);

                com.Parameters.Add("@1", SqlDbType.VarChar).Value = arUserEmail.Text;
                com.Parameters.Add("@2", SqlDbType.VarChar).Value = arAccountType.Text;
                com.Parameters.Add("@3", SqlDbType.VarChar).Value = arStatus.Text;
                com.Parameters.Add("@4", SqlDbType.VarChar).Value = arNotes.Text;

                if (com.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Added Successfully!");
                }
            }
           
        }
        private SchoolForm schoolFrm = (SchoolForm)Application.OpenForms["SchoolForm"];
        private MainForm mainFrm = (MainForm)Application.OpenForms["MainForm"];
        private void AccountRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            try 
            {
                mainFrm.getListOfAccounts();
            } 
            catch
            {
                schoolFrm.getListofTeachers();
            }
           
        }
    }
}