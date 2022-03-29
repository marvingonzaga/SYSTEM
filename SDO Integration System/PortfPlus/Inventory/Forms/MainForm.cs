using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SDO_Integrated_System.Inventory.Forms
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {

        SqlConnection conn = Config.connString.conn;
        public MainForm()
        {
            InitializeComponent();
        }
        private void Connection()
        {
            Config.connString.openConnection();
        }
        private void tileBar_SelectedItemChanged(object sender, TileItemEventArgs e)
        {
            //navigationFrame.SelectedPageIndex = tileBarGroupTables.Items.IndexOf(e.Item);
        }

        private void employeesTileBarItem_ItemClick(object sender, TileItemEventArgs e)
        {
            pnlItems.BringToFront();
        }

        private void customersTileBarItem_ItemClick(object sender, TileItemEventArgs e)
        {
            pnlAccounts.BringToFront();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           

        }

        private void Accnts_gcListofSchools_Click(object sender, EventArgs e)
        {
            try
            {
                tbSchoolID.Text = Accnts_gvListofSchools.GetFocusedRowCellValue("SchoolID").ToString();
            }
            catch { }
        }

        private void tbSchoolID_TextChanged(object sender, EventArgs e)
        {
            Connection();
            SqlCommand com = new SqlCommand("select * from tbl_Teachers where SchoolID ='"+tbSchoolID.Text+"'",conn);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            adapter.Fill(table);
            Accnts_gcListofTeachers.DataSource = table;
            Accnts_gvListofTeachers.Columns[0].Visible = false;
            Accnts_gvListofTeachers.Columns[1].Visible = false;

        }

        private void Accnts_gcListofTeachers_Click(object sender, EventArgs e)
        {
            try
            {
                tbTeacherID.Text = Accnts_gvListofTeachers.GetFocusedRowCellValue("TeacherID").ToString();
            }
            catch { }
        }

        private void tbTeacherID_TextChanged(object sender, EventArgs e)
        {
            getListOfAccounts();
        }
        public void getListOfAccounts()
        {
            Connection();
            SqlCommand com = new SqlCommand("select * from tbl_Accounts where TeacherID ='" + tbTeacherID.Text + "'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            adapter.Fill(table);
            Accnts_gcListofAccounts.DataSource = table;
            Accnts_gvListofAccounts.Columns[0].Visible = false;
            Accnts_gvListofAccounts.Columns[1].Visible = false;
        }
        private void Accnts_gcListofAccounts_Click(object sender, EventArgs e)
        {
            try
            {
                tbAccountID.Text = Accnts_gvListofAccounts.GetFocusedRowCellValue("id").ToString();
            }
            catch { }
        }

        private void Account_DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(dialogResult == DialogResult.Yes)
            {
                Connection();
                SqlCommand com = new SqlCommand("DELETE FROM [dbo].[tbl_Accounts] WHERE id = '"+tbAccountID.Text+"'", conn);
                if (com.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Deleted Successfully!");
                }
            }
           

        }
        private void Account_AddBtn_Click(object sender, EventArgs e)
        {
            AccountRegistration frm = new AccountRegistration();
            frm.tbFor.Text = "add";
            frm.ShowDialog();
        }

        private void Account_UpdateBtn_Click(object sender, EventArgs e)
        {
            AccountRegistration frm = new AccountRegistration();
            frm.tbFor.Text = "update";
            frm.ShowDialog();
        }
        private Dashboard dashboard = (Dashboard)Application.OpenForms["Dashboard"];
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dashboard.Show();
            this.Hide();
        }
    }
}