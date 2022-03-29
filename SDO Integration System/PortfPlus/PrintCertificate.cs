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

namespace PortfPlus
{
    public partial class PrintCertificate : Form
    {
        private static PrintCertificate frm;
        private static MainForm main;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);

        public static PrintCertificate getfrm
        {
            get
            {
                if (frm == null)
                {
                    frm = new PrintCertificate();
                }
                return frm;
            }
        }
        public PrintCertificate()
        {
            InitializeComponent();
        }
        private void Connection()
        {
            conn.Close();
            conn.Open();
        }
        private MainForm obj = (MainForm)Application.OpenForms["MainForm"];
        private void Report_Load(object sender, EventArgs e)
        {
            
           // textBox1.Text = obj.Cert_ID.Text;


        }
        private void getCertInfo()
        {

            //Cursor.Current = Cursors.WaitCursor;
            //Connection();
            //Certification cert = new Certification();
            //SqlCommand com = new SqlCommand("SELECT * FROM Registrations where ID='" + obj.Cert_ID.Text + "'", conn);
            //SqlDataAdapter adapter = new SqlDataAdapter(com);
            //DataTable table = new DataTable();
            //adapter.Fill(table);

            //cert.SetDataSource(table);
            //crystalReportViewer.ReportSource = cert;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            getCertInfo();
        }
        ReportDocument cr = new ReportDocument();
        private void pictureBox1_VisibleChanged(object sender, EventArgs e)
        {
            ////Certification ReportViewer = new Certification();           
            ////TextObject certName = (TextObject)ReportViewer.ReportDefinition.Sections["Section3"].ReportObjects["TextName"];
            ////certName.Text = textBox2.Text;
          

            //Connection();
            //SqlCommand com = new SqlCommand("SELECT QRCode FROM Registrations where ID=@id", conn);
            //com.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            //DataSet ds = new DataSet();
            //SqlDataAdapter da = new SqlDataAdapter(com);
            //da.Fill(ds,"Registrations");
            //DataTable dt = ds.Tables["Registrations"];
            //cr.Load("Certification.rpt");
            //cr.SetDataSource(dt);
            //crystalReportViewer.ReportSource = cr;


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
