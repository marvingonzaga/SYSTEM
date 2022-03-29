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

namespace SDO_Integrated_System
{
    public partial class ProjectSoldierAdmin : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {

        SqlConnection conn = Config.connString.conn;
        public ProjectSoldierAdmin()
        {
            InitializeComponent();                     
        }
        private void Connection()
        {
            Config.connString.openConnection();
        }
        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            accordionControlElement8.Appearance.Normal.BackColor = System.Drawing.Color.Transparent;
            accordionControlElement3.Appearance.Normal.BackColor = System.Drawing.Color.Transparent;
            accordionControlElement2.Appearance.Normal.BackColor = System.Drawing.Color.Aqua;
            pnlRegistrations.Visible = true;
            pnlRegistrations.BringToFront();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            pnlCertification.Visible = false;
        }
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            //try
            //{
            //    Connection();
            //    comboBox1.Items.Clear();
            //    SqlCommand com = new SqlCommand("SELECT Name from Registrations", conn);
            //    SqlDataReader reader = com.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        string location = reader.GetString(0);
            //        comboBox1.Items.Add(location);
            //    }
            //}
            //catch (Exception) { }

        }
        private void getID()
        {
            ////try
            ////{
            //    Connection();
            //    SqlCommand cmd = new SqlCommand("SELECT ID FROM Registrations where Name='" + comboBox1.Text + "'", conn);
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        int id = reader.GetInt32(0);
            //    textBox2.Text = id.ToString();
                   
            //    }
            ////}
            ////catch (Exception) { Connection(); }
        }
        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            accordionControlElement8.Appearance.Normal.BackColor = System.Drawing.Color.Transparent;
            accordionControlElement2.Appearance.Normal.BackColor = System.Drawing.Color.Transparent;
            accordionControlElement3.Appearance.Normal.BackColor = System.Drawing.Color.Aqua;
            TrainingTab.Visible = true;
            TrainingTab.BringToFront();
            ListofTrainings();
            RequestedTrainings();
            trainingAtttendace();
        }
        private void ListofTrainings()
        {
            Connection();
            SqlCommand com = new SqlCommand("select [TrainingID],[TrainingCode],[Title] ,[Venue],[Description] ,[TrainingDate],[ConductedBy] from ListOfTrainings where UserID='"+adminUserID.Text+"'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gcListOfTrainings.DataSource = table;
            gcAttendaceTrainings.DataSource = table;
            Cursor = Cursors.Default;
        }
        #region Requested Traininings
        private void RequestedTrainings()
        {
            Connection();
            SqlCommand com = new SqlCommand("SELECT ListOfTrainings.Title, UserTrainings.RequestStat, UserTrainings.UserID, ListOfTrainings.TrainingID FROM UserTrainings inner join ListOfTrainings on UserTrainings.TrainingID = ListOfTrainings.TrainingID where UserTrainings.RequestStat = 'Pending' or  UserTrainings.RequestStat = 'Accepted' and ListOfTrainings.UserID='"+adminUserID.Text+"'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgvRequestedTrainings.DataSource = table;
            gridView2.Columns[2].Visible = false;
            gridView2.Columns[3].Visible = false;
            //gridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Cursor = Cursors.Default;
        }

        private void rtRefresh_Click(object sender, EventArgs e)
        {
            RequestedTrainings();
            
        }
        private void reqTrainingApproveBtn_Click(object sender, EventArgs e)
        {
            Connection();
            SqlCommand com = new SqlCommand("UPDATE UserTrainings SET UserTrainings.RequestStat = 'Accepted' FROM UserTrainings AS R INNER JOIN ListOfTrainings AS P ON R.TrainingID = P.TrainingID  where R.UserID = '" + reqTrainingUserID.Text+"' and P.TrainingID='"+reqTrainingID.Text+"'", conn);            
            if (com.ExecuteNonQuery() == 1)
            {
                RequestedTrainings();
            }
        }
        private void dgvRequestedTrainings_Click(object sender, EventArgs e)
        {          
            try
            {
                reqTrainingUserID.Text = gridView2.GetFocusedRowCellValue("UserID").ToString();
                reqTrainingID.Text = gridView2.GetFocusedRowCellValue("TrainingID").ToString();
            }
            catch { }

        }
        private void reqTrainingUserID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Connection();
                SqlCommand com = new SqlCommand("select concat (FName,' ',MName,' ',LName,' ',NameExt) as Name, Designation,  PositionTitle, Contact, Email from [AntiqueUsers] where UserID='" + reqTrainingUserID.Text + "'", conn);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    string desig = reader.GetString(1);
                    string position = reader.GetString(2);
                    string contact = reader.GetString(3);
                    string email = reader.GetString(4);

                    reqTrainingName.Text = name;
                    reqTrainingDesignation.Text = desig;
                    reqTrainingPosition.Text = position;
                    reqTrainingContact.Text = contact;
                    reqTrainingEmail.Text = email;
                    Cursor = Cursors.Default;
                }
            }
            catch
            {
                Cursor = Cursors.Default;
            }
        }

        #endregion
        #region Trainees Attendance
        private void trainingAtttendace()
        {
            Connection();
            SqlCommand com = new SqlCommand("SELECT concat (AntiqueUsers.FName,' ',AntiqueUsers.MName,' ',AntiqueUsers.LName,' ',AntiqueUsers.NameExt) as Trainees, UserTrainings.UserID, ListOfTrainings.TrainingID, UserTrainings.TraineeApperance as Attendance FROM ((AntiqueUsers inner join UserTrainings on AntiqueUsers.UserID = UserTrainings.UserID) inner join ListOfTrainings on UserTrainings.TrainingID = ListOfTrainings.TrainingID) Where UserTrainings.RequestStat = 'Accepted' and UserTrainings.TrainingID='"+ttTrainingID.Text+"'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gcTraineesAttendance.DataSource = table;
            dgvTraineesAttendance.Columns[1].Visible = false;
            dgvTraineesAttendance.Columns[2].Visible = false;
            //dgvTraineesAttendance.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvTraineesAttendance.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Cursor = Cursors.Default;
        }
        private void dgvTraineesAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                ttUserID.Text = dgvTraineesAttendance.GetFocusedRowCellValue("UserID").ToString();
                ttTrainingID.Text = dgvTraineesAttendance.GetFocusedRowCellValue("TrainingID").ToString();
            }
            catch { }
        }
        private void ttUserID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Connection();
                SqlCommand com = new SqlCommand("select concat (FName,' ',MName,' ',LName,' ',NameExt) as Name, Designation,  PositionTitle, Contact, Email from [AntiqueUsers] where UserID='" + ttUserID.Text + "'", conn);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    string desig = reader.GetString(1);
                    string position = reader.GetString(2);
                    string contact = reader.GetString(3);
                    string email = reader.GetString(4);

                    ttName.Text = name;
                    ttDesignation.Text = desig;
                    ttPosition.Text = position;
                    ttContact.Text = contact;
                    ttEmail.Text = email;
                    Cursor = Cursors.Default;
                }
            }
            catch
            {
                Cursor = Cursors.Default;
            }
        }
        private void ttVerifiedAttendanceBtn_Click(object sender, EventArgs e)
        {
            Connection();
            SqlCommand com = new SqlCommand("UPDATE UserTrainings SET UserTrainings.TraineeApperance = 'Attended' FROM UserTrainings AS R INNER JOIN ListOfTrainings AS P ON R.TrainingID = P.TrainingID  where R.UserID = '" + ttUserID.Text + "' and P.TrainingID='" + ttTrainingID.Text + "'", conn);
            if (com.ExecuteNonQuery() == 1)
            {
                trainingAtttendace();
            }
        }
        #endregion
        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            getAllParticipants();
            accordionControlElement2.Appearance.Normal.BackColor = System.Drawing.Color.Transparent;
            accordionControlElement3.Appearance.Normal.BackColor = System.Drawing.Color.Transparent;
            accordionControlElement8.Appearance.Normal.BackColor = System.Drawing.Color.Aqua;
            pnlCertification.Visible = true;
            pnlCertification.BringToFront();
        }
        public void getAllParticipants()
        {
            Connection();
            SqlCommand com = new SqlCommand("SELECT distinct AntiqueUsers.UserID, concat (AntiqueUsers.FName,' ',AntiqueUsers.MName,' ',AntiqueUsers.LName,' ',AntiqueUsers.NameExt) as Name FROM " +
                "((AntiqueUsers INNER JOIN UserTrainings ON AntiqueUsers.UserID = UserTrainings.UserID) inner join ListOfTrainings on UserTrainings.TrainingID = ListOfTrainings.TrainingID) " +
                "where TraineeApperance = 'Attended'  and ListOfTrainings.UserID = '" + adminUserID.Text + "'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gcdataGridView2.DataSource = table;
            dataGridView2.Columns[0].Visible = false;
            //dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Cursor = Cursors.Default;
            //DGVItems.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 
        }
        private void dataGridView2_Click(object sender, EventArgs e)
        {
            try { 
                certUserid.Text = dataGridView2.GetFocusedRowCellValue("UserID").ToString(); 
            } catch (Exception) {  }
            
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            getID();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //try
            //{
                // TODO: This line of code loads data into the 'ictSystemsDataSet4.ListOfTrainings' table. You can move, or remove it, as needed.
                //this.listOfTrainingsTableAdapter1.Fill(this.ictSystemsDataSet4.ListOfTrainings);
                // TODO: This line of code loads data into the 'dS_ListOfTraining.ListOfTrainings' table. You can move, or remove it, as needed.
                //this.listOfTrainingsTableAdapter.Fill(this.dS_ListOfTraining.ListOfTrainings);
                // TODO: This line of code loads data into the 'ictSystemsDataSet2.AntiqueUsers' table. You can move, or remove it, as needed.
                //this.antiqueUsersTableAdapter.Fill(this.ictSystemsDataSet2.AntiqueUsers);
                
            //}
            //catch {
            //    DialogResult result = MessageBox.Show("Internet connection problem encountered" + "\n" + "Retry in few seconds.", "Internet Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    if (result == DialogResult.OK)
            //    {
            //        Connection();
            //    }
            //}

           
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            Connection();
            SqlCommand com = new SqlCommand("INSERT INTO [dbo].[AntiqueUsers] " +
                "([FName]," +
                "[MName]," +
                "[LName]," +
                "[NameExt]," +
                "[Designation]," +
                "[PositionTitle]," +
                "[Contact]," +
                "[Username]," +
                "[Password]) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9)", conn);

            com.Parameters.Add("@1", SqlDbType.VarChar).Value = regFName.Text;
            com.Parameters.Add("@2", SqlDbType.VarChar).Value = regMI.Text;
            com.Parameters.Add("@3", SqlDbType.VarChar).Value = regLName.Text;
            com.Parameters.Add("@4", SqlDbType.VarChar).Value = regExt.Text;
            com.Parameters.Add("@5", SqlDbType.VarChar).Value = regDesignation.Text;
            com.Parameters.Add("@6", SqlDbType.VarChar).Value = regPosition.Text;
            com.Parameters.Add("@7", SqlDbType.VarChar).Value = regContact.Text;
            com.Parameters.Add("@8", SqlDbType.VarChar).Value = regUsername.Text;
            com.Parameters.Add("@9", SqlDbType.VarChar).Value = regPassword.Text;
            if (com.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Registered Successfully!");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            getCertInfo();
        }
        private void getCertInfo()
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
                "ListOfTrainings.ConductedBy, " +
                "ListOfTrainings.certContent, [CertAttendanceContent] " +
                "from((UserTrainings inner join AntiqueUsers on UserTrainings.UserID = AntiqueUsers.UserID) inner join ListOfTrainings on UserTrainings.TrainingID = ListOfTrainings.TrainingID) where UserTrainings.UserID = '" + certUserid.Text + "'", conn);
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
                certContent.Text = dataGridView3.GetFocusedRowCellValue("certContent").ToString();
                certAttendanceContent.Text = dataGridView3.GetFocusedRowCellValue("CertAttendanceContent").ToString();

                Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                cert_QRPicture.Image = qrcode.Draw(certName.Text + "\n"
                                + certDesignation.Text + "\n"
                                + certTrainingCode.Text + ", " + certTrainingID.Text + "\n"
                                + certControlNo.Text + "\n"
                                + certDate.Text, 50);
            }
            catch { }

           
        }    
       
        private Login loginfrm = (Login)Application.OpenForms["Login"];
        private Dashboard dashboard = (Dashboard)Application.OpenForms["Dashboard"];
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dashboard.Show();
            this.Hide();
        }
        private void button_WOC2_Click(object sender, EventArgs e)
        {
            Connection();
            SqlCommand com = new SqlCommand("INSERT INTO [dbo].[ListOfTrainings] (" +
                "[TrainingID]," +
                "[TrainingCode]," +
                "[Title]," +
                "[Venue]," +
                "[Description]," +
                "[TrainingDate]," +
                "[ConductedBy]," +
                "[TrainingStatus]," +
                "[CertTemplate]," +
                "[CertContent], CertAttendanceTemp, CertAttendanceContent, Office, UserID) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14)", conn);

            com.Parameters.Add("@1", SqlDbType.VarChar).Value = tbTrainingID.Text;
            com.Parameters.Add("@2", SqlDbType.VarChar).Value = tbTrainingCode.Text;
            com.Parameters.Add("@3", SqlDbType.VarChar).Value = tbTitle.Text;
            com.Parameters.Add("@4", SqlDbType.VarChar).Value = tbVenue.Text;
            com.Parameters.Add("@5", SqlDbType.VarChar).Value = tbDescription.Text;
            com.Parameters.Add("@6", SqlDbType.VarChar).Value = tbDate.Text;
            com.Parameters.Add("@7", SqlDbType.VarChar).Value = tbConducted.Text;
            com.Parameters.Add("@8", SqlDbType.VarChar).Value = "Open";
            com.Parameters.Add("@9", SqlDbType.VarChar).Value = tbCertTemplate.Text;
            com.Parameters.Add("@10", SqlDbType.VarChar).Value = tbCertParticipationContent.Text;
            com.Parameters.Add("@11", SqlDbType.VarChar).Value = tbCertAttendanceTemp.Text;
            com.Parameters.Add("@12", SqlDbType.VarChar).Value = tbCertAttendaceContent.Text;
            com.Parameters.Add("@13", SqlDbType.VarChar).Value = tbOffice.Text;
            com.Parameters.Add("@14", SqlDbType.VarChar).Value = adminUserID.Text;
            if (com.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Registered Successfully!");
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            CertTemplate temp = new CertTemplate();
            temp.ShowDialog();
        }

        private void certPrint_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Questionnaire2 Qfrm = new Questionnaire2();
            Qfrm.tbUserType.Text = "admin";
            Qfrm.ShowDialog();
            Cursor = Cursors.Default;
            //try
            //{
            //    Cursor = Cursors.WaitCursor;
            //    Connection();
            //    SqlCommand com = new SqlCommand("select ControlNo from [UserTrainings] where UserID='" + certUserid.Text + "' and TrainingID = '" + certTrainingID.Text + "'", conn);
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

            //                //MessageBox.Show("not null");
            //                printAttendanceCertificate();
            //            }

            //        }
            //        catch (Exception)
            //        {
            //            addQRImageAttendance();
            //            //MessageBox.Show("null");

            //        }

            //    }
            //}
            //catch (Exception) { }
        }
        private void addQRImage()
        {
            try
            {
                Connection();
                MemoryStream stream = new MemoryStream();
                cert_QRPicture.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();

                SqlCommand com = new SqlCommand("update [dbo].[UserTrainings] set [QRCode] = @1, Format='" + certControlNoFormat.Text + "', ControlNo='" + certControlNo.Text + "' where UserID='" + certUserid.Text + "' and TrainingID ='" + certTrainingID.Text + "'", conn);
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
            CertParticipationPreviewFrm cert = new CertParticipationPreviewFrm();
            cert.ppForm.Text = "Admin";
            cert.ShowDialog();
            Cursor = Cursors.Default;

        }
        private void certAttendancePrintBtn_Click(object sender, EventArgs e)
        {
            Questionnaire Qfrm = new Questionnaire();
            Qfrm.tbUserType.Text = "admin";
            Qfrm.ShowDialog();
            //addQRImageAttendance();

            //Cursor = Cursors.WaitCursor;
            //Connection();
            //SqlCommand com = new SqlCommand("select QRCode from [UserTrainings] where UserID='" + certUserid.Text + "' and TrainingID = '" + certTrainingID.Text + "'", conn);
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
                SqlCommand com = new SqlCommand("select ControlNo from [UserTrainings] where UserID='" + certUserid.Text + "' and TrainingID = '" + certTrainingID.Text + "'", conn);
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
        public void addQRImageAttendance()
        {
            try
            {
                Connection();
                MemoryStream stream = new MemoryStream();
                cert_QRPicture.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();

                SqlCommand com = new SqlCommand("update [dbo].[UserTrainings] set [QRCode] = @1 where UserID='" + certUserid.Text + "' and TrainingID ='" + certTrainingID.Text + "'", conn);
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
        public void printAttendanceCertificate()
        {
            CertAttendancePreviewFrm cert = new CertAttendancePreviewFrm();
            cert.ppForm.Text = "Admin";
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
                certParticipationPrintBtn.Enabled = Enabled;
                certAttendancePrintBtn.Enabled = Enabled;
            }
        }

        private void pnlCertification_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControl3_Click(object sender, EventArgs e)
        {
            try
            {
                tbTrainingID.Text = gvListOfTrainings.GetFocusedRowCellValue("TrainingID").ToString();
            

                
            }
            catch { }
        }

        private void btnRefreshTrainings_Click(object sender, EventArgs e)
        {
            //this.listOfTrainingsTableAdapter1.Fill(this.ictSystemsDataSet4.ListOfTrainings);
            ListofTrainings();
        }

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            //this.antiqueUsersTableAdapter.Fill(this.ictSystemsDataSet2.AntiqueUsers);
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

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            trainingAtttendace();
        }
        public void SaveToDBAttendanceQuestion()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Connection();
                SqlCommand com = new SqlCommand("select ControlNo from [UserTrainings] where UserID='" + certUserid.Text + "' and TrainingID = '" + certTrainingID.Text + "'", conn);
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

        private void button_WOC4_Click(object sender, EventArgs e)
        {
            ListofTrainings();
        }

        private void gcAttendaceTrainings_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            
        }

        private void ttTrainingID_TextChanged(object sender, EventArgs e)
        {
            trainingAtttendace();
        }

        private void gcAttendaceTrainings_Click(object sender, EventArgs e)
        {
            try { ttTrainingID.Text = gvAttendaceTrainings.GetFocusedRowCellValue("TrainingID").ToString(); } catch { }
        }
    }
}
