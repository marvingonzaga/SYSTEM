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
    public partial class Questionnaire2 : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection conn = Config.connString.conn;
        SqlCommand command = null;
        SqlDataReader reader = null;

        private ProjectSoldierAdmin projectsoldierAdmin = (ProjectSoldierAdmin)Application.OpenForms["ProjectSoldierAdmin"];
        private ProjectSoldierUser projectsoldier = (ProjectSoldierUser)Application.OpenForms["ProjectSoldierUser"];
        private ICT_Trainings.Forms.UserInterface ict = (ICT_Trainings.Forms.UserInterface)Application.OpenForms["UserInterface"];
        public Questionnaire2()
        {
            InitializeComponent();
        }
        private void Questionnaire2_Load(object sender, EventArgs e)
        {
            label2.Focus();
            if (tbUserType.Text == "projectSoldier")
            {
                tbUserID.Text = projectsoldier.regUserID.Text;
                tbTrainingID.Text = projectsoldier.certTrainingID.Text;
            }
            else if (tbUserType.Text == "projectSoldierUserRegister")
            {
                tbUserID.Text = projectsoldier.regUserID.Text;
                tbTrainingID.Text = projectsoldier.certTrainingID.Text;
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
        private void Connection()
        {
            Config.connString.openConnection();
        }
        #region Insert into Questionnaire if not exist
        private void tbTrainingID_TextChanged(object sender, EventArgs e)
        {
            Connection();
            command = new SqlCommand("Select UserID, TrainingID from Questionnaire2 where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
            reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                DialogResult dialogResult = MessageBox.Show("You have already submitted your answers" + "\n" + "Do you want to start it again?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    Connection();
                    command = new SqlCommand("Update [dbo].[Questionnaire2] set TL1=null, TL2=null, TL3=null, TL4=null, TL5=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                    command.ExecuteNonQuery();
                }
                else
                {
                    if (tbUserType.Text == "projectSoldier")
                    {
                        projectsoldier.SaveToDBAttendanceQuestion();
                        this.Close();
                    }
                    else if (tbUserType.Text == "projectSoldierUserRegister")
                    {
                        projectsoldier.RegisterToTraining();
                        this.Close();
                    }
                    else if (tbUserType.Text == "admin")
                    {
                        projectsoldierAdmin.SaveToDBAttendanceQuestion();
                        this.Close();
                    }
                    else
                    {
                        ict.addQRImageAttendance();
                        this.Close();
                    }
                }
               
            }
            else
            {
                Connection();
                command = new SqlCommand("INSERT INTO [dbo].[Questionnaire2] ([UserID], [TrainingID]) VALUES (@1,@2)", conn);
                command.Parameters.Add("@1", SqlDbType.VarChar).Value = tbUserID.Text;
                command.Parameters.Add("@2", SqlDbType.VarChar).Value = tbTrainingID.Text;
                command.ExecuteNonQuery();
            }
        }
        #endregion
        private void saveAllAnswers()
        {
            Cursor = Cursors.WaitCursor;
            if (q1True.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire2 set TL1='TRUE', TL1AK='TRUE', TL2AK='TRUE', TL3AK='TRUE', TL4AK='TRUE', TL5AK='TRUE' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();

            }
            else if (q1False.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire2 set TL1='FALSE', TL1AK='TRUE', TL2AK='TRUE', TL3AK='TRUE', TL4AK='TRUE', TL5AK='TRUE' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (q2True.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire2 set TL2='TRUE', TL1AK='TRUE', TL2AK='TRUE', TL3AK='TRUE', TL4AK='TRUE', TL5AK='TRUE' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();

            }
            else if (q2False.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire2 set TL2='FALSE', TL1AK='TRUE', TL2AK='TRUE', TL3AK='TRUE', TL4AK='TRUE', TL5AK='TRUE' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (q3True.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire2 set TL3='TRUE', TL1AK='TRUE', TL2AK='TRUE', TL3AK='TRUE', TL4AK='TRUE', TL5AK='TRUE' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();

            }
            else if (q3False.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire2 set TL3='FALSE', TL1AK='TRUE', TL2AK='TRUE', TL3AK='TRUE', TL4AK='TRUE', TL5AK='TRUE' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (q4True.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire2 set TL4='TRUE', TL1AK='TRUE', TL2AK='TRUE', TL3AK='TRUE', TL4AK='TRUE', TL5AK='TRUE' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();

            }
            else if (q4False.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire2 set TL4='FALSE', TL1AK='TRUE', TL2AK='TRUE', TL3AK='TRUE', TL4AK='TRUE', TL5AK='TRUE' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (q5True.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire2 set TL5='TRUE', TL1AK='TRUE', TL2AK='TRUE', TL3AK='TRUE', TL4AK='TRUE', TL5AK='TRUE' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();

            }
            else if (q5False.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire2 set TL5='FALSE', TL1AK='TRUE', TL2AK='TRUE', TL3AK='TRUE', TL4AK='TRUE', TL5AK='TRUE' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (tbUserType.Text == "projectSoldier")
            {
                //MessageBox.Show("ProjectSOldier");
                Cursor = Cursors.Default;
                projectsoldier.SaveToDBAttendanceQuestion();
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

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            saveAllAnswers();
        }
    }
}