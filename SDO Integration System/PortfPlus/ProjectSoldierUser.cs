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
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;
using System.Threading;


namespace SDO_Integrated_System
{
    public partial class ProjectSoldierUser : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection conn = Config.connString.conn;

        public Point mouseLocation;

        private Login loginfrm = (Login)Application.OpenForms["Login"];
        private Dashboard dashboard = (Dashboard)Application.OpenForms["Dashboard"];
        private void Connection()
        {
            Config.connString.openConnection();
        }
        public ProjectSoldierUser()
        {
            InitializeComponent();
            
        }
        
        
        private void UsersForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ictSystemsDataSet3.ListOfTrainings' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'dS_ListOfTraining.ListOfTrainings' table. You can move, or remove it, as needed.
            //this.listOfTrainingsTableAdapter.Fill(this.dS_ListOfTraining.ListOfTrainings);
            // certUserid.Text = obj.loginUserID.Text;

            
            listOfTraining();
            RequestedTrainings();
            reloadCertification();
            
        }
        private void listOfTraining()
        {
            Cursor.Current = Cursors.WaitCursor;
            Connection();
            SqlCommand com = new SqlCommand("SELECT " +
                "Title, Description, Venue, TrainingDate, ConductedBy, TrainingStatus, TrainingID, TrainingCode, CertTemplate, TrainingStatus " +           
                "from ListOfTrainings where TrainingStatus='Open'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gcAvailableTrainings.DataSource = table;
            Cursor = Cursors.Default;

            dgvAvailableTrainings.Columns[1].Visible = false;
            dgvAvailableTrainings.Columns[2].Visible = false;
            dgvAvailableTrainings.Columns[3].Visible = false;
            dgvAvailableTrainings.Columns[4].Visible = false;
            dgvAvailableTrainings.Columns[5].Visible = false;
            dgvAvailableTrainings.Columns[6].Visible = false;
            dgvAvailableTrainings.Columns[7].Visible = false;
            dgvAvailableTrainings.Columns[8].Visible = false;
            //dgvAvailableTrainings.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Cursor.Current = Cursors.Default;

        }
        private void dgvAvailableTrainings_Click(object sender, EventArgs e)
        {
            try
            {
                regTitle.Text = dgvAvailableTrainings.GetFocusedRowCellValue("Title").ToString();
                regDescription.Text = dgvAvailableTrainings.GetFocusedRowCellValue("Description").ToString();
                regVenue.Text = dgvAvailableTrainings.GetFocusedRowCellValue("Venue").ToString();
                regTrainingDate.Text = dgvAvailableTrainings.GetFocusedRowCellValue("TrainingDate").ToString();
                regConducted.Text = dgvAvailableTrainings.GetFocusedRowCellValue("ConductedBy").ToString();
                regTrainingID.Text = dgvAvailableTrainings.GetFocusedRowCellValue("TrainingID").ToString();
                regTrainingCode.Text = dgvAvailableTrainings.GetFocusedRowCellValue("TrainingCode").ToString();
                regCertTemplate.Text = dgvAvailableTrainings.GetFocusedRowCellValue("CertTemplate").ToString();
            }
            catch { }
        }
        private void regRefreshBtn_Click(object sender, EventArgs e)
        {
            listOfTraining();
        }
        private void RequestedTrainings()
        {
            Cursor.Current = Cursors.WaitCursor;
            Connection();
            SqlCommand com = new SqlCommand("SELECT ListOfTrainings.Title, UserTrainings.RequestStat, ListOfTrainings.Description, ListOfTrainings.Venue, ListOfTrainings.TrainingDate, ListOfTrainings.ConductedBy FROM UserTrainings inner join ListOfTrainings on UserTrainings.TrainingID = ListOfTrainings.TrainingID where UserTrainings.UserID = '" + regUserID.Text+"'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gcRequestedTrainings.DataSource = table;
           // dgvRequestedTrainings.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRequestedTrainings.Columns[2].Visible = false;
            dgvRequestedTrainings.Columns[3].Visible = false;
            dgvRequestedTrainings.Columns[4].Visible = false;
            dgvRequestedTrainings.Columns[5].Visible = false;
            Cursor = Cursors.Default;
        }
        private void dgvRequestedTrainings_Click(object sender, EventArgs e)
        {
            try
            {
                reqTitle.Text = dgvRequestedTrainings.GetFocusedRowCellValue("Title").ToString();
                reqDescription.Text = dgvRequestedTrainings.GetFocusedRowCellValue("Description").ToString();
                reqVenue.Text = dgvRequestedTrainings.GetFocusedRowCellValue("Venue").ToString();
                reqTrainingDate.Text = dgvRequestedTrainings.GetFocusedRowCellValue("TrainingDate").ToString();
                reqConducted.Text = dgvRequestedTrainings.GetFocusedRowCellValue("ConductedBy").ToString();
            }
            catch { }


        }
        private void certUserid_TextChanged(object sender, EventArgs e)
        {

            
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

            gcdataGridView3.DataSource = table;
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
            Cursor.Current = Cursors.Default;
        }
        private void dataGridView3_Click(object sender, EventArgs e)
        {
            try
            {
                certControlNoFormat.Text = "HRD-" + DateTime.Now.ToString("yyyy") + "-TID-";
                certTitle.Text = dataGridView3.GetFocusedRowCellValue("Title").ToString();
                certTrainingID.Text = dataGridView3.GetFocusedRowCellValue("TrainingID").ToString();
                certTrainingCode.Text = dataGridView3.GetFocusedRowCellValue("TrainingCode").ToString();
                certName.Text = dataGridView3.GetFocusedRowCellValue("Name").ToString();
                certDesignation.Text = dataGridView3.GetFocusedRowCellValue("Designation").ToString();
                certDate.Text = dataGridView3.GetFocusedRowCellValue("TrainingDate").ToString();
                certDescription.Text = dataGridView3.GetFocusedRowCellValue("Description").ToString();
                certVenue.Text = dataGridView3.GetFocusedRowCellValue("Venue").ToString();
                certConductedBy.Text = dataGridView3.GetFocusedRowCellValue("ConductedBy").ToString();
                certContent.Text = dataGridView3.GetFocusedRowCellValue("CertContent").ToString();
                certAttendanceContent.Text = dataGridView3.GetFocusedRowCellValue("CertAttendanceContent").ToString();

                //Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                //QrCode.Image = qrcode.Draw(certName.Text + "\n"
                //                + certDesignation.Text + "\n"
                //                + certTrainingCode.Text + ", " + certTrainingID.Text + "\n"
                //                + certControlNo.Text + "\n"
                //                + certDate.Text, 9999);

                //BarcodeWriter barcodeWriter = new BarcodeWriter();
                //EncodingOptions encodingOptions = new EncodingOptions() { Width = 200, Height = 200, Margin = 0, PureBarcode = false };
                //encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
                //barcodeWriter.Renderer = new BitmapRenderer();
                //barcodeWriter.Options = encodingOptions;
                //barcodeWriter.Format = BarcodeFormat.QR_CODE;
                //Bitmap bitmap = barcodeWriter.Write(certName.Text + "\n"
                //                + certDesignation.Text + "\n"
                //                + certTrainingCode.Text + ", " + certTrainingID.Text + "\n"
                //                + certControlNo.Text + "\n"
                //                + certDate.Text);
                ////Bitmap logo = new Bitmap($"/logo.png");
                ////Graphics g = Graphics.FromImage(bitmap);
                ////g.DrawImage(logo, new System.Drawing.Point((bitmap.Width - logo.Width) / 2, (bitmap.Height - logo.Height) / 2));
                //QrCode.Image = bitmap;


                Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                cert_QRPicture.Image = qrcode.Draw(certName.Text + "\n"
                                + certDesignation.Text + "\n"
                                + certTrainingCode.Text + ", " + certTrainingID.Text + "\n"
                                + certControlNo.Text + "\n"
                                + certDate.Text, 9999);
            }
            catch { }
        }

        private void QRBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Questionnaire2 Qfrm = new Questionnaire2();
            Qfrm.tbUserType.Text = "projectSoldier";
            Qfrm.ShowDialog();
            Cursor = Cursors.Default;
            //try
            //{
            //    Cursor = Cursors.WaitCursor;
            //    Connection();
            //    SqlCommand com = new SqlCommand("select ControlNo from [UserTrainings] where UserID='" + regUserID.Text + "' and TrainingID = '" + certTrainingID.Text + "'", conn);
            //    SqlDataReader reader = com.ExecuteReader();
            //    string count = "";
            //    while (reader.Read())
            //    {
            //        try
            //        {
            //            count = "not null";
            //            string controlno = reader.GetString(0);
            //            if (count == "not null")
            //            {
            //                // MessageBox.Show("not null");
            //                printAttendanceCertificate();
            //            }

            //        }
            //        catch (Exception)
            //        {
            //            addQRImageAttendance();

            //        }

            //    }
            //}
            //catch (Exception) { }
        }
        public void addQRImage()
        {
            try
            {
                Connection();
                MemoryStream stream = new MemoryStream();
                cert_QRPicture.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();

                SqlCommand com = new SqlCommand("update [dbo].[UserTrainings] set [QRCode] = @1, Format='"+certControlNoFormat.Text+"', ControlNo='"+certControlNo.Text+"' where UserID='"+regUserID.Text+"' and TrainingID ='"+certTrainingID.Text+"'", conn);
                com.Parameters.AddWithValue("@1", pic);
                if (com.ExecuteNonQuery() == 1)
                {
                    printCertificate();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message,"Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
        private void printCertificate()
        {
            CertParticipationPreviewFrm cert = new CertParticipationPreviewFrm();
            cert.ppForm.Text = "User";
            cert.ShowDialog();
            Cursor = Cursors.Default;

        }

        private void UsersForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void UsersForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }

        }
        private void gcListOfTrainingAttended_Click(object sender, EventArgs e)
        {
            //GidControl clicked event
            //if (gridView1.DataRowCount > 0)
            //{
            //    foreach (int i in gridView1.GetSelectedRows())
            //    {
            //        DataRow row = gridView1.GetDataRow(i);
            //        regTrainingID.Text = row[1].ToString();
            //    }
            //}

        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor;
            Connection();
            SqlCommand com = new SqlCommand("Select UserID, TrainingID from UserTrainings where UserID='" + regUserID.Text + "' and TrainingID='" + regTrainingID.Text + "'", conn);
            SqlDataReader reader = com.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                MessageBox.Show("You already requested this training, check your requested training for any update", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
            }
            else
            {
                Pre_Test Qfrm = new Pre_Test();
                Qfrm.ShowDialog();
                Cursor = Cursors.Default;
            }
        }
        public void RegisterToTraining()
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
        private void regTrainingID_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button_WOC1_Click_1(object sender, EventArgs e)
        {
            dashboard.Show(); 
            this.Close();
        }

        private void rtRefresh_Click(object sender, EventArgs e)
        {
            RequestedTrainings();
        }

        private void button_WOC2_Click_1(object sender, EventArgs e)
        {
            reloadCertification();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor;
            PostTest Qfrm = new PostTest();
            Qfrm.tbUserType.Text = "User";
            Qfrm.ShowDialog();
            Cursor = Cursors.Default;

            //Cursor = Cursors.WaitCursor;
            //Questionnaire Qfrm = new Questionnaire();
            //Qfrm.tbUserType.Text = "projectSoldier";
            //Qfrm.ShowDialog();
            //Cursor = Cursors.Default;



            //addQRImageAttendance();


            //Cursor = Cursors.WaitCursor;
            //Connection();
            //SqlCommand com = new SqlCommand("select QRCode from [UserTrainings] where UserID='" + regUserID.Text + "' and TrainingID = '" + certTrainingID.Text + "'", conn);
            //SqlDataReader reader = com.ExecuteReader();
            //int count = 0;
            //while (reader.Read())
            //{
            //    count = count + 1;
            //}
            //if (count != 1)
            //{

            //}
            //else
            //{
            //    printAttendanceCertificate();
            //}
        }
        public void SaveToDB()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Connection();
                SqlCommand com = new SqlCommand("select ControlNo from [UserTrainings] where UserID='" + regUserID.Text + "' and TrainingID = '" + certTrainingID.Text + "'", conn);
                SqlDataReader reader = com.ExecuteReader();
                string count = "";
                while (reader.Read())
                {

                    try
                    {
                        count = "not null";
                        string controlno = reader.GetString(0);
                        if (count == "not null")
                        {

                            // MessageBox.Show("not null");
                            printCertificate();
                        }

                    }
                    catch (Exception)
                    {
                        addQRImage();

                    }
                }
            }
            catch (Exception) { }
           
        }
        public void SaveToDBAttendanceQuestion()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Connection();
                SqlCommand com = new SqlCommand("select ControlNo from [UserTrainings] where UserID='" + regUserID.Text + "' and TrainingID = '" + certTrainingID.Text + "'", conn);
                SqlDataReader reader = com.ExecuteReader();
                string count = "";
                while (reader.Read())
                {

                    try
                    {
                        count = "not null";
                        string controlno = reader.GetString(0);
                        if (count == "not null")
                        {

                            // MessageBox.Show("not null");
                            printAttendanceCertificate();
                        }

                    }
                    catch (Exception)
                    {
                        addQRImageAttendance();

                    }
                }
            }
            catch (Exception) { }

        }
        public void addQRImageAttendance()
        {
            try
            {
                Connection();
                MemoryStream stream = new MemoryStream();
                cert_QRPicture.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();

                SqlCommand com = new SqlCommand("update [dbo].[UserTrainings] set [QRCode] = @1, Format='" + certControlNoFormat.Text + "', ControlNo='" + certControlNo.Text + "' where UserID='" + regUserID.Text + "' and TrainingID ='" + certTrainingID.Text + "'", conn);
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
            CertAttendancePreviewFrm cert = new CertAttendancePreviewFrm();
            cert.ppForm.Text = "User";
            cert.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void cert_QRPicture_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void certTitle_TextChanged(object sender, EventArgs e)
        {
            if (cert_QRPicture.Text == null)
            {
                certParticipationPrintBtn.Enabled = false;
                certAttendancePrintBtn.Enabled = false;
            }
            else
            {
                certParticipationPrintBtn.Enabled = true;
                certAttendancePrintBtn.Enabled = true;
            }
            
        }
        private void GetControlNo()
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("SELECT MAX(ID) FROM UserTrainings", conn);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.IsDBNull(0))
                    {
                        certControlNoSequence.Text = "1";
                        certControlNo.Text = certControlNoFormat.Text + certControlNoSequence.Text;
                    }
                    else
                    {
                        int NextNumber = reader.GetInt32(0);
                        certControlNoSequence.Text = NextNumber.ToString(); ;
                        certControlNo.Text = certControlNoFormat.Text + certControlNoSequence.Text;
                    }
                }
            }
            catch (Exception) { }
        }

        private void certControlNoFormat_TextChanged(object sender, EventArgs e)
        {
            GetControlNo();
        }

        private void certControlNo_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}