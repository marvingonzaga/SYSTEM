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


namespace SDO_Integrated_System
{
    public partial class CertAttendancePreviewFrm : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection conn = Config.connString.conn;

        private static CertParticipationPreviewFrm frm;
        private ProjectSoldierAdmin obj = (ProjectSoldierAdmin)Application.OpenForms["ProjectSoldierAdmin"];
        private ProjectSoldierUser obj1 = (ProjectSoldierUser)Application.OpenForms["ProjectSoldierUser"];
        public CertAttendancePreviewFrm()
        {
            InitializeComponent();
        }
        private void Connection()
        {
            Config.connString.openConnection();
        }
        public static CertParticipationPreviewFrm getfrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new CertParticipationPreviewFrm();
                }
                return frm;
            }
        }
        
        private void CertAttendancePreviewFrm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (ppForm.Text == "Admin")
            {
                ppName.Text = obj.certName.Text;
                ppUserID.Text = obj.certUserid.Text;
                ppTrainingID.Text = obj.certTrainingID.Text;
                ppTrainingCode.Text = obj.certTrainingCode.Text;
                ppcertContent.Text = obj.certAttendanceContent.Text;

                getCertAttendanceTemplate();
            }
            else
            {
                ppName.Text = obj1.certName.Text;
                ppUserID.Text = obj1.regUserID.Text;
                ppTrainingID.Text = obj1.certTrainingID.Text;
                ppTrainingCode.Text = obj1.certTrainingCode.Text;
                ppcertContent.Text = obj1.certAttendanceContent.Text;
                getCertAttendanceTemplate();

            }
        }
        private void getCertAttendanceTemplate()
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("select CertAttendanceTemp from ListOfTrainings where TrainingID='" + ppTrainingID.Text + "'", conn);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    string certemp = reader.GetString(0);
                    ppcertTemplate.Text = certemp;
                }
            }
            catch{}
            

        }

        private void ppcertTemplate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (ppcertTemplate.Text == "Certificate 1")
                //{
                Cursor.Current = Cursors.WaitCursor;
                CertificateOfAttendance cert = new CertificateOfAttendance();
                Connection();
                SqlCommand com = new SqlCommand("SELECT QRCode, ControlNo FROM [dbo].[UserTrainings] where UserID ='" + ppUserID.Text + "' and TrainingID ='" + ppTrainingID.Text + "'", conn);
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
            }
            catch (Exception)
            {
                MessageBox.Show("Make sure you installed the crystal report in order to generate your certificate","Crystal report Required",MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }
            
        }
    }
}