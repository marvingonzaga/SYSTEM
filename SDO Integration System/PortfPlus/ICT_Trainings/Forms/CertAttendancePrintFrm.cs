using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDO_Integrated_System.ICT_Trainings.Forms
{
    public partial class CertAttendancePrintFrm : DevExpress.XtraEditors.XtraForm
    {
        private static CertAttendancePrintFrm frm;
        SqlConnection conn = Config.connString.conn;

        private ProjectSoldierAdmin obj = (ProjectSoldierAdmin)Application.OpenForms["ProjectSoldierAdmin"];
        private UserInterface obj1 = (UserInterface)Application.OpenForms["UserInterface"];
        public CertAttendancePrintFrm()
        {
            InitializeComponent();
        }
        public static CertAttendancePrintFrm getfrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new CertAttendancePrintFrm();
                }
                return frm;
            }
        }

        #region Connection
        private void Connection()
        {
            Config.connString.openConnection();
        }
        #endregion

        #region Form Load
        private void CertParticipationPreviewFrm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //if (ppForm.Text == "Admin")
            //{
            //    ppName.Text = obj.certName.Text;
            //    ppUserID.Text = obj.certUserid.Text;
            //    ppTrainingID.Text = obj.certTrainingID.Text;
            //    ppTrainingCode.Text = obj.certTrainingCode.Text;
            //    ppcertContent.Text = obj.certContent.Text;

            //    getCertTemplate();
            //}
            //else
            //{
                ppName.Text = obj1.certName.Text;
                ppUserID.Text = obj1.regUserID.Text;
                ppTrainingID.Text = obj1.certTrainingID.Text;
                ppTrainingCode.Text = obj1.certTrainingCode.Text;
                ppcertContent.Text = obj1.certAttendanceContent.Text;
                getCertTemplate();

            //}
        }
        private void getCertTemplate()
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("select certTemplate from ListOfTrainings where TrainingID='" + ppTrainingID.Text + "'", conn);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    string certemp = reader.GetString(0);
                    ppcertTemplate.Text = certemp;
                }
            }
            catch { }
        }

        #endregion

        private void ppcertTemplate_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void ppcertContent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (ppcertTemplate.Text == "Certificate 1")
                //{
                Cursor.Current = Cursors.WaitCursor;
                CertificateOfAttendance cert = new CertificateOfAttendance();
                Connection();
                SqlCommand com = new SqlCommand("SELECT QRCode FROM [dbo].[UserTrainings] where UserID ='" + ppUserID.Text + "' and TrainingID ='" + ppTrainingID.Text + "'", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataTable table = new DataTable();
                adapter.Fill(table);
                cert.SetDataSource(table);

                TextObject reportName = (TextObject)cert.ReportDefinition.Sections["Section3"].ReportObjects["ReportName"];
                reportName.Text = ppName.Text;

                TextObject reportContent = (TextObject)cert.ReportDefinition.Sections["Section3"].ReportObjects["ReportContent"];
                reportContent.Text = ppcertContent.Text;

                crystalReportViewer.ReportSource = cert;
                Cursor.Current = Cursors.Default;
                //}
                //else
                //{
                //    Cursor.Current = Cursors.WaitCursor;
                //    Certificate2 cert = new Certificate2();
                //    Connection();
                //    SqlCommand com = new SqlCommand("SELECT QRCode FROM [dbo].[UserTrainings] where UserID ='" + ppUserID.Text + "' and TrainingID ='" + ppTrainingID.Text + "'", conn);
                //    SqlDataAdapter adapter = new SqlDataAdapter(com);
                //    DataTable table = new DataTable();
                //    adapter.Fill(table);
                //    cert.SetDataSource(table);

                //    TextObject reportName = (TextObject)cert.ReportDefinition.Sections["Section3"].ReportObjects["ReportName"];
                //    reportName.Text = ppName.Text;

                //    TextObject reportContent = (TextObject)cert.ReportDefinition.Sections["Section3"].ReportObjects["ReportContent"];
                //    reportContent.Text = ppcertContent.Text;

                //    crystalReportViewer.ReportSource = cert;
                //    Cursor.Current = Cursors.Default;
                //}
            }

            catch (Exception)
            {
                MessageBox.Show("Make sure you installed the crystal report in order to generate your certificate", "Crystal report Required", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}