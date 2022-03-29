using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace SDO_Integrated_System.Config
{
    class connString
    {
        #region ict_Systems Connection string
        public static SqlConnection conn = new SqlConnection("Data Source=180.193.203.234;Initial Catalog=ictSystems;Persist Security Info=True;User ID=ICT_Innovations;Password=ictinnovations2022");
        public static void openConnection()
        {
            try
            {
                conn.Close();
                conn.Open();
                
            }
            catch (Exception)
            {
                DialogResult result = MessageBox.Show("Internet connection problem encountered" + "\n" + "Retry in few seconds.", "Internet Connection Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Retry)
                {
                    openConnection();
                    Cursor.Current = Cursors.Default;
                }
                else if (result == DialogResult.None)
                {
                    
                    Application.Exit();
                }
                else
                { 
                    Application.Exit();
                }
            }
        }
        #endregion


        #region Inventory Connection string
        public static SqlConnection conn_Inventory = new SqlConnection("Data Source=180.193.203.234;Initial Catalog=Inventory;Persist Security Info=True;User ID=ICT_Innovations;Password=ictinnovations2022");
        public static void openIventoryConnection()
        {
            try
            {
                conn_Inventory.Close();
                conn_Inventory.Open();

            }
            catch (Exception)
            {
                DialogResult result = MessageBox.Show("Internet connection problem encountered" + "\n" + "Retry in few seconds.", "Internet Connection Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Retry)
                {
                    openConnection();
                    Cursor.Current = Cursors.Default;
                }
                else if (result == DialogResult.None)
                {

                    Application.Exit();
                }
                else
                {
                    Application.Exit();
                }
            }
        }
        #endregion
    }

}
