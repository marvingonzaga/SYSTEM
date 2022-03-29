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
    public partial class PostTest : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection conn = Config.connString.conn;
        SqlCommand command = null;
        SqlDataReader reader = null;

        private ProjectSoldierAdmin projectsoldierAdmin = (ProjectSoldierAdmin)Application.OpenForms["ProjectSoldierAdmin"];
        private ProjectSoldierUser projectsoldierUser = (ProjectSoldierUser)Application.OpenForms["ProjectSoldierUser"];
        private ICT_Trainings.Forms.UserInterface ict = (ICT_Trainings.Forms.UserInterface)Application.OpenForms["UserInterface"];
        public PostTest()
        {
            InitializeComponent();

        }
        private void Connection()
        {
            Config.connString.openConnection();
        }
        private void PostTest_Load(object sender, EventArgs e)
        {
            label2.Focus();
            if (tbUserType.Text == "projectSoldier")
            {
                tbUserID.Text = projectsoldierUser.regUserID.Text;
                tbTrainingID.Text = projectsoldierUser.certTrainingID.Text;
            }
            else if (tbUserType.Text == "projectSoldierUserRegister")
            {
                tbUserID.Text = projectsoldierUser.regUserID.Text;
                tbTrainingID.Text = projectsoldierUser.certTrainingID.Text;
            }
            else if (tbUserType.Text == "admin")
            {
                tbUserID.Text = projectsoldierAdmin.certUserid.Text;
                tbTrainingID.Text = projectsoldierAdmin.certTrainingID.Text;
            }
            else
            {
                tbUserID.Text = ict.regUserID.Text;
                tbTrainingID.Text = ict.certTrainingID.Text;
            }

            Cursor = Cursors.Default;
        }

        private void tbTrainingID_TextChanged(object sender, EventArgs e)
        {
            DisplayQuestions();
        }
        private void DisplayQuestions()
        {
            Connection();
            command = new SqlCommand("Select PostTestQ.Questions, PostTestA.Answer, PostTestQ.AnswerKey, PostTestQ.QID from PostTestQ left join PostTestA on PostTestQ.TrainingID=PostTestA.TrainingID and CONVERT(VARCHAR(MAX), PostTestQ.Questions)=CONVERT(VARCHAR(MAX), PostTestA.Questions) where CONVERT(VARCHAR(MAX), PostTestA.TrainingID)='" + tbTrainingID.Text + "' and PostTestA.UserID='" + tbUserID.Text+"'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgvQuestions.DataSource = table;
            dgvQuestions.Columns[1].Width = 50;
            dgvQuestions.Columns[2].Visible = false;
            dgvQuestions.Columns[3].Visible = false;

            if (dgvQuestions.Rows.Count == 0)
            {
                Connection();
                SqlCommand command1 = new SqlCommand("Insert into PostTestA (QID, UserID,TrainingID, Questions) select QID, '"+tbUserID.Text+"', TrainingID, Questions from PostTestQ",conn);
                command1.ExecuteNonQuery();

                Connection();
                command = new SqlCommand("Select PostTestQ.Questions, PostTestA.Answer, PostTestQ.AnswerKey, PostTestQ.QID from PostTestQ left join PostTestA on PostTestQ.TrainingID=PostTestA.TrainingID and CONVERT(VARCHAR(MAX), PostTestQ.Questions)=CONVERT(VARCHAR(MAX), PostTestA.Questions) where CONVERT(VARCHAR(MAX), PostTestA.TrainingID)='" + tbTrainingID.Text + "' and PostTestA.UserID='" + tbUserID.Text + "'", conn);
                SqlDataAdapter adapter1 = new SqlDataAdapter(command);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                dgvQuestions.DataSource = table1;
                dgvQuestions.Columns[1].Width = 50;
                dgvQuestions.Columns[2].Visible = false;
                dgvQuestions.Columns[3].Visible = false;
            }
            //else
            //{
            //    Connection();
            //    SqlCommand command1 = new SqlCommand("Select PostTestQ.Questions, PostTestA.Answer, PostTestQ.AnswerKey, PostTestQ.QID from PostTestQ left join PostTestA on PostTestQ.TrainingID=PostTestA.TrainingID and CONVERT(VARCHAR(MAX), PostTestQ.Questions)=CONVERT(VARCHAR(MAX), PostTestA.Questions) where CONVERT(VARCHAR(MAX), PostTestQ.TrainingID)='" + tbTrainingID.Text + "' and UserID='"+tbUserID.Text+"'", conn);
            //    SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            //    DataTable table1 = new DataTable();
            //    adapter1.Fill(table1);
            //    dgvQuestions.DataSource = table1;
            //    dgvQuestions.Columns[1].Width = 50;
            //    dgvQuestions.Columns[2].Visible = false;
            //    dgvQuestions.Columns[3].Visible = false;
            //}

        }

        private void dgvQuestions_Click(object sender, EventArgs e)
        {
            tbQuestion.Text = dgvQuestions.CurrentRow.Cells[0].Value.ToString();
            tbAnswerKey.Text = dgvQuestions.CurrentRow.Cells[2].Value.ToString();
            tbQID.Text = dgvQuestions.CurrentRow.Cells[3].Value.ToString();
            dgvChoices.CurrentCell.Selected = false;
            tbAnswer.Text = "";
        }

        private void tbQuestion_TextChanged(object sender, EventArgs e)
        {
            Connection();
            command = new SqlCommand("Select TRUE, FALSE from PostTestQ where CONVERT(VARCHAR(MAX), TrainingID)='" + tbTrainingID.Text + "' AND CONVERT(VARCHAR(MAX), Questions) ='" + tbQuestion.Text + "'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgvChoices.DataSource = table;
        }

        private void dgvChoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbAnswer.Text = dgvChoices.CurrentCell.Value.ToString();
        }

        private void tbAnswer_TextChanged(object sender, EventArgs e)
        {
            if(tbAnswer.Text != "")
            {
                if(tbAnswerKey.Text == tbAnswer.Text)
                {
                    tbRemarks.Text = "1";
                }
                else
                {
                    tbRemarks.Text = "0";
                }

                Connection();
                SqlCommand com = new SqlCommand("select QID from PostTestA Where QID='"+tbQID.Text+"' and Userid='"+tbUserID.Text+"'",conn);
                SqlDataReader reader = com.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count = count + 1;
                }
                //if exist update
                if (count == 1)
                {
                    UpdateAnswer();
                }
                //if not exist then insert
                else
                {
                    InsertAnswer();
                }
               
                
            }
        }
        private void UpdateAnswer()
        {
            Connection();
            command = new SqlCommand("Update PostTestA set Answer='" + tbAnswer.Text + "', Remarks='"+tbRemarks.Text+"' where CONVERT(VARCHAR(MAX), TrainingID)='" + tbTrainingID.Text + "' AND CONVERT(VARCHAR(MAX), QID) ='" + tbQID.Text + "' and Userid='" + tbUserID.Text + "'", conn);
            if (command.ExecuteNonQuery() == 1)
            {
                dgvQuestions.CurrentCell.Selected = false;
                DisplayQuestions();
            }
        }
        private void InsertAnswer()
        {
            Connection();
            command = new SqlCommand("insert into PostTestA (QID, UserID, TrainingID, Questions, Answer, Remarks) values " +
                "('"+tbQID.Text+ "', '" + tbUserID.Text + "', '" + tbTrainingID.Text + "', '" + tbQuestion.Text + "', '" + tbAnswer.Text + "', '" + tbRemarks.Text + "')", conn);
            if (command.ExecuteNonQuery() == 1)
            {
                dgvQuestions.CurrentCell.Selected = false;
                DisplayQuestions();
            }
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Connection();
                command = new SqlCommand("SELECT count(*) from PostTestQ where TrainingID='" + tbTrainingID.Text + "'", conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int questionsCount = reader.GetInt32(0);
                    tbCountQuestions.Text = questionsCount.ToString();
                }
            }
            catch { }



        }

        private void tbCountQuestions_TextChanged(object sender, EventArgs e)
        {

            try
            {
                Connection();
                command = new SqlCommand("SELECT count(*) from PostTestA where TrainingID='" + tbTrainingID.Text + "' and UserID='" + tbUserID.Text + "'", conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int countAnswered = reader.GetInt32(0);
                    tbCountAnsweredQuestions.Text = countAnswered.ToString();
                }
            }
            catch { }
        }

        private void tbCountAnswered_TextChanged(object sender, EventArgs e)
        {
            if (tbCountAnsweredQuestions.Text != tbCountQuestions.Text)
            {
                MessageBox.Show("Answer All the Questions first.");
            }
            else
            {
                Connection();
                command = new SqlCommand("SELECT count(Remarks) from PostTestA where Remarks='1' AND TrainingID='" + tbTrainingID.Text + "' and UserID= '" + tbUserID.Text + "'", conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int countCorrectAnsweres = reader.GetInt32(0);
                    tbCountCorrectAnswers.Text = countCorrectAnsweres.ToString();
                }
            }
        }

        private void tbCountCorrectAnswers_TextChanged(object sender, EventArgs e)
        {
            int TotalQuestions;
            int score;
            double percent = 0.8;

            TotalQuestions = Convert.ToInt32(tbCountQuestions.Text);
            score = Convert.ToInt32(tbCountCorrectAnswers.Text);

            double PassingScore = TotalQuestions * percent;

            tbPassingScore.Text = PassingScore.ToString();

            if (score < PassingScore)
            {
                MessageBox.Show("Please try again! You need to pass atleast 80% of the passing score", "Message", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                this.Close();
            }
            else
            {
                if (tbUserType.Text == "User")
                {
                    //MessageBox.Show("ProjectSOldier");
                    Cursor = Cursors.Default;
                    projectsoldierUser.SaveToDB();
                    this.Close();
                }
                else if (tbUserType.Text == "admin")
                {
                    Cursor = Cursors.Default;
                    projectsoldierAdmin.SaveToDBAttendanceQuestion();
                    this.Close();
                }
                else
                {
                    Cursor = Cursors.Default;
                    ict.addQRImageAttendance();
                    this.Close();
                }
            }

        }
    }
}