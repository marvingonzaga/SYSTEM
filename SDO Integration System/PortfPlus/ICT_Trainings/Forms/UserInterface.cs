using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;

namespace SDO_Integrated_System.ICT_Trainings.Forms
{
    public partial class UserInterface : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection conn = Config.connString.conn;
        public Point mouseLocation;

        private Login loginfrm = (Login)Application.OpenForms["Login"];
        private Dashboard dashboard = (Dashboard)Application.OpenForms["Dashboard"];
        public UserInterface()
        {
            InitializeComponent();
        }
        private void Connection()
        {
            Config.connString.openConnection();
        }

        #region Form Load
        private void UserInterface_Load(object sender, EventArgs e)
        {
            listOfTraining();
            RequestedTrainings();
            reloadCertification();

            regUserID.Text = dashboard.dbUserID.Text;
        }
        
        private void button_WOC2_Click(object sender, EventArgs e)
        {
            reloadCertification();
        }
        private void certTitle_TextChanged(object sender, EventArgs e)
        {
            if (cert_QRPicture.Text == null)
            {
                //certParticipationPrintBtn.Enabled = false;
                certAttendancePrintBtn.Enabled = false;
            }
            else
            {
                //certParticipationPrintBtn.Enabled = true;
                certAttendancePrintBtn.Enabled = true;
            }
        }
        #endregion

        #region Registration Tab
        private void listOfTraining()
        {
            Connection();
            SqlCommand com = new SqlCommand("SELECT " +
                "Title, Description, Venue, TrainingDate, ConductedBy, TrainingStatus, TrainingID, TrainingCode, CertTemplate, TrainingStatus " +
                "from ListOfTrainings where TrainingStatus='Open' AND Office ='ICT'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgvAvailableTrainings.DataSource = table;
            Cursor = Cursors.Default;

            dgvAvailableTrainings.Columns[1].Visible = false;
            dgvAvailableTrainings.Columns[2].Visible = false;
            dgvAvailableTrainings.Columns[3].Visible = false;
            dgvAvailableTrainings.Columns[4].Visible = false;
            dgvAvailableTrainings.Columns[5].Visible = false;
            dgvAvailableTrainings.Columns[6].Visible = false;
            dgvAvailableTrainings.Columns[7].Visible = false;
            dgvAvailableTrainings.Columns[8].Visible = false;
            dgvAvailableTrainings.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void dgvAvailableTrainings_Click(object sender, EventArgs e)
        {
            try
            {
                regTitle.Text = dgvAvailableTrainings.CurrentRow.Cells[0].Value.ToString();
                regDescription.Text = dgvAvailableTrainings.CurrentRow.Cells[1].Value.ToString();
                regVenue.Text = dgvAvailableTrainings.CurrentRow.Cells[2].Value.ToString();
                regTrainingDate.Text = dgvAvailableTrainings.CurrentRow.Cells[3].Value.ToString();
                regConducted.Text = dgvAvailableTrainings.CurrentRow.Cells[4].Value.ToString();
                regTrainingID.Text = dgvAvailableTrainings.CurrentRow.Cells[6].Value.ToString();
                regTrainingCode.Text = dgvAvailableTrainings.CurrentRow.Cells[7].Value.ToString();
                regCertTemplate.Text = dgvAvailableTrainings.CurrentRow.Cells[8].Value.ToString();
            }

            catch { }
        }
        private void RequestedTrainings()
        {
            Connection();
            SqlCommand com = new SqlCommand("SELECT ListOfTrainings.Title, UserTrainings.RequestStat, ListOfTrainings.Description, ListOfTrainings.Venue, ListOfTrainings.TrainingDate, ListOfTrainings.ConductedBy FROM UserTrainings inner join ListOfTrainings on UserTrainings.TrainingID = ListOfTrainings.TrainingID where UserTrainings.UserID = '" + regUserID.Text + "'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgvRequestedTrainings.DataSource = table;
            dgvRequestedTrainings.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRequestedTrainings.Columns[2].Visible = false;
            dgvRequestedTrainings.Columns[3].Visible = false;
            dgvRequestedTrainings.Columns[4].Visible = false;
            dgvRequestedTrainings.Columns[5].Visible = false;

            Cursor = Cursors.Default;


        }
        private void reloadCertification()
        {
            Cursor.Current = Cursors.WaitCursor;
            Connection();
            SqlCommand com = new SqlCommand("select " +
                "ListOfTrainings.Title, " +
                "UserTrainings.TrainingID, " +
                "UserTrainings.TrainingCode, " +
                "concat (AntiqueUsers.FName,' ', AntiqueUsers.MName,' ', AntiqueUsers.LName,' ', AntiqueUsers.NameExt) as Name, " +
                "AntiqueUsers.Designation, " +
                "ListOfTrainings.TrainingDate, " +
                "ListOfTrainings.Description, " +
                "ListOfTrainings.Venue, " +
                "ListOfTrainings.ConductedBy, [CertContent], [CertAttendanceContent]" +
                "from((UserTrainings inner join AntiqueUsers on UserTrainings.UserID = AntiqueUsers.UserID) inner join ListOfTrainings on UserTrainings.TrainingID = ListOfTrainings.TrainingID) where UserTrainings.UserID = '" + regUserID.Text + "' and UserTrainings.TraineeApperance='Attended'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dataGridView3.DataSource = table;
            dataGridView3.Columns[1].Visible = false;
            dataGridView3.Columns[2].Visible = false;
            dataGridView3.Columns["Name"].Visible = false;
            dataGridView3.Columns[4].Visible = false;
            dataGridView3.Columns[5].Visible = false;
            dataGridView3.Columns[6].Visible = false;
            dataGridView3.Columns[7].Visible = false;
            dataGridView3.Columns[8].Visible = false;
            dataGridView3.Columns[9].Visible = false;
            dataGridView3.Columns[10].Visible = false;
        }
        private void dataGridView3_Click(object sender, EventArgs e)
        {
            try
            {
                certTitle.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                certTrainingID.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                certTrainingCode.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
                certName.Text = dataGridView3.CurrentRow.Cells["Name"].Value.ToString();
                certDesignation.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
                certDate.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();
                certDescription.Text = dataGridView3.CurrentRow.Cells[6].Value.ToString();
                certVenue.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString();
                certConductedBy.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString();
                certContent.Text = dataGridView3.CurrentRow.Cells[9].Value.ToString();
                certAttendanceContent.Text = dataGridView3.CurrentRow.Cells[10].Value.ToString();

                Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                cert_QRPicture.Image = qrcode.Draw(certTrainingID.Text + "\n"
                                + certName.Text + "\n"
                                + certDesignation.Text + "\n"
                                + certTrainingCode.Text + "\n"
                                + certDate.Text, 50);
            }
            catch { }

            
        }
       
        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Connection();
            SqlCommand com = new SqlCommand("Select UserID, TrainingID from UserTrainings where UserID='"+regUserID.Text+"' and TrainingID='"+regTrainingID.Text+"'",conn);
            SqlDataReader reader = com.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }
            if(count == 1)
            {
                MessageBox.Show("You already requested this training, check your requested training for any update", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
            }
            else
            {
                RegisterToTraining();
            }

            
        }
        private void RegisterToTraining()
        {
            Connection();
            SqlCommand com = new SqlCommand("Insert INTO [UserTrainings] " +
                "([UserID]," +
                "[TrainingID]," +
                "[TrainingCode]," +
                "[RequestStat]) VALUES (@1,@2,@3,@4)", conn);

            com.Parameters.Add("@1", SqlDbType.VarChar).Value = regUserID.Text;
            com.Parameters.Add("@2", SqlDbType.VarChar).Value = regTrainingID.Text;
            com.Parameters.Add("@3", SqlDbType.VarChar).Value = regTrainingCode.Text;
            com.Parameters.Add("@4", SqlDbType.VarChar).Value = "Pending";
            if (com.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Registered Successfully!");
                Cursor = Cursors.Default;
            }
        }
        private void regRefreshBtn_Click(object sender, EventArgs e)
        {
            listOfTraining();
        }
        #endregion

        #region Requested Tab
        private void dgvRequestedTrainings_Click(object sender, EventArgs e)
        {
            reqTitle.Text = dgvRequestedTrainings.CurrentRow.Cells[0].Value.ToString();
            reqDescription.Text = dgvRequestedTrainings.CurrentRow.Cells[2].Value.ToString();
            reqVenue.Text = dgvRequestedTrainings.CurrentRow.Cells[3].Value.ToString();
            reqTrainingDate.Text = dgvRequestedTrainings.CurrentRow.Cells[4].Value.ToString();
            reqConducted.Text = dgvRequestedTrainings.CurrentRow.Cells[5].Value.ToString();
        }
        private void rtRefresh_Click(object sender, EventArgs e)
        {
            RequestedTrainings();
        }
        #endregion

        #region Certification Tab
        private void certParticipationPrintBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Connection();
            SqlCommand com = new SqlCommand("select QRCode from [UserTrainings] where UserID='" + regUserID.Text + "' and TrainingID = '" + certTrainingID.Text + "'", conn);
            SqlDataReader reader = com.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }
            if (count != 1)
            {
                addQRImage();
            }
            else
            {
                printCertificate();
            }
        }
        private void addQRImage()
        {
            try
            {
                Connection();
                MemoryStream stream = new MemoryStream();
                cert_QRPicture.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();

                SqlCommand com = new SqlCommand("update [dbo].[UserTrainings] set [QRCode] = @1 where UserID='" + regUserID.Text + "' and TrainingID ='" + certTrainingID.Text + "'", conn);
                com.Parameters.AddWithValue("@1", pic);
                if (com.ExecuteNonQuery() == 1)
                {
                    printCertificate();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void printCertificate()
        {
            CertAttendancePrintFrm cert = new CertAttendancePrintFrm();
            cert.ppForm.Text = "User";
            cert.ShowDialog();
            Cursor = Cursors.Default;

        }
        private void certAttendancePrintBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Questionnaire Qfrm = new Questionnaire();
            Qfrm.ShowDialog();
            Cursor = Cursors.Default;

            //addQRImageAttendance();


            //Connection();
            //SqlCommand com = new SqlCommand("select UserID from [UserTrainings] where UserID='" + regUserID.Text + "' and TrainingID = '" + certTrainingID.Text + "'", conn);
            //SqlDataReader reader = com.ExecuteReader();
            //int count = 0;
            //while (reader.Read())
            //{
            //    count = count + 1;
            //}
            //if (count == 0)
            //{

            //}
            //else
            //{
            //    printAttendanceCertificate();
            //}
        }
        public void addQRImageAttendance()
        {
            try
            {
                Connection();
                MemoryStream stream = new MemoryStream();
                cert_QRPicture.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();

                SqlCommand com = new SqlCommand("update [dbo].[UserTrainings] set [QRCode] = @1 where UserID='" + regUserID.Text + "' and TrainingID ='" + certTrainingID.Text + "'", conn);
                com.Parameters.AddWithValue("@1", pic);
                if (com.ExecuteNonQuery() == 1)
                {
                    printAttendanceCertificate();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void printAttendanceCertificate()
        {
            CertAttendancePrintFrm cert = new CertAttendancePrintFrm();
            cert.ppForm.Text = "User";
            cert.ShowDialog();
            Cursor = Cursors.Default;
        }
        #endregion

        #region Back Button
        private void button_WOC1_Click(object sender, EventArgs e) //BackBtn
        {
            dashboard.Show();
            this.Close();
        }
        #endregion

        #region FormMove
        private void UserInterface_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }
        private void UserInterface_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }


        #endregion
    }
}
