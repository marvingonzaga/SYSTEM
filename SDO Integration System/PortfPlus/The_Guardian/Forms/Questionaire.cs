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

namespace SDO_Integrated_System.The_Guardian.Forms
{
    public partial class Questionaire : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection conn = Config.connString.conn;
        SqlCommand command = null;
        SqlDataReader reader = null;

        private ProjectSoldierAdmin projectsoldierAdmin = (ProjectSoldierAdmin)Application.OpenForms["ProjectSoldierAdmin"];
        private ProjectSoldierUser projectsoldier = (ProjectSoldierUser)Application.OpenForms["ProjectSoldierUser"];
        private ICT_Trainings.Forms.UserInterface ict = (ICT_Trainings.Forms.UserInterface)Application.OpenForms["UserInterface"];
        public Questionaire()
        {
            InitializeComponent();
        }
        private void Questionaire_Load(object sender, EventArgs e)
        {
            if (tbUserType.Text == "projectSoldier")
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
            command = new SqlCommand("Select UserID, TrainingID from Questionnaire where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
            reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }
            if(count != 1)
            {
                Connection();
                command = new SqlCommand("INSERT INTO [dbo].[Questionnaire] ([UserID], [TrainingID]) VALUES (@1,@2)", conn);
                command.Parameters.Add("@1", SqlDbType.VarChar).Value = tbUserID.Text;
                command.Parameters.Add("@2", SqlDbType.VarChar).Value = tbTrainingID.Text;
                command.ExecuteNonQuery();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("You have already submitted this questionnaire" + "\n" + "Do you want to start it again?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialogResult == DialogResult.Yes)
                {
                    Connection();
                    command = new SqlCommand("DELETE FROM [dbo].[Questionnaire] where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                    command.ExecuteNonQuery();
                }
                else
                {
                    if (tbUserType.Text == "projectSoldier")
                    {
                        projectsoldier.addQRImageAttendance();
                        this.Close();
                    }
                    else if (tbUserType.Text == "admin")
                    {
                        projectsoldierAdmin.addQRImageAttendance();
                        this.Close();
                    }
                    else
                    {
                        ict.addQRImageAttendance();
                        this.Close();
                    }
                }
            }

        }
        #endregion

        #region textbox others
        private void cbTL9_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTL9.Checked == true)
            {
                tbTL9.Enabled = false;
            }
            else
            {
                tbTL9.Enabled = true;
            }        
        }
        private void cbTL15_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTL15.Checked == true)
            {
                tbTL15.Enabled = false;
            }
            else
            {
                tbTL15.Enabled = true;
            }
        }
        private void cbTL31_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTL31.Checked == true)
            {
                tbTL31.Enabled = false;
            }
            else
            {
                tbTL31.Enabled = true;
            }
        }
        private void cbTL37_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTL37.Checked == true)
            {
                tbTL37.Enabled = false;
            }
            else
            {
                tbTL37.Enabled = true;
            }
        }
        private void cbTL48_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTL48.Checked == true)
            {
                tbTL48.Enabled = false;
            }
            else
            {
                tbTL48.Enabled = true;
            }
        }
        private void cbTL55_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTL55.Checked == true)
            {
                tbTL55.Enabled = false;
            }
            else
            {
                tbTL55.Enabled = true;
            }
        }
        private void cbTL59_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTL59.Checked == true)
            {
                tbTL59.Enabled = false;
            }
            else
            {
                tbTL59.Enabled = true;
            }
        }
        private void cbTL74_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTL74.Checked == true)
            {
                tbTL74.Enabled = false;
            }
            else
            {
                tbTL74.Enabled = true;
            }
        }
        #endregion

        private void saveQ1()
        {
            Cursor = Cursors.WaitCursor;
            if (cbTL1.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL1='Content' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();

            }
            else if (cbTL1.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL1=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL2.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL2='Knowledge' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL2.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL2=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL3.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL3='Pedagogy' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL3.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL3=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL4.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL4='Learning Environment' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL4.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL4=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL5.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL5='Diversity of Learners' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL5.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL5=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL6.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL6='Curriculum' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL6.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL6=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL7.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL7='Lesson Planning' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL7.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL7=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL8.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL8='Assessment and Reporting' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL8.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL8=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL9.Checked == true)
            {
                tbTL9.Enabled = false;
                Connection();
                command = new SqlCommand("update Questionnaire set TL9='" + tbTL9.Text + "' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL9.Checked == false)
            {
                tbTL9.Enabled = true;
                Connection();
                command = new SqlCommand("update Questionnaire set TL9=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL10.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL10='Developing Self and Others' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL10.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL10=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL11.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL11='Building Connections' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL11.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL11=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL12.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL12='Supporting Curriculum Management and Implementation' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL12.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL12=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL13.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL13='Fostering a Culture of Continuous Improvement' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL13.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL13=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL14.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL14='Results-Based Performance Management' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL14.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL14=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL15.Checked == true)
            {
                tbTL15.Enabled = false;
                Connection();
                command = new SqlCommand("update Questionnaire set TL15='" + tbTL15.Text + "' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL15.Checked == false)
            {
                tbTL15.Enabled = true;
                Connection();
                command = new SqlCommand("update Questionnaire set TL15=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL16.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL16='Developing Self and Others' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL16.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL16=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL17.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL17='Financial Literacy Education' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL17.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL17=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            if (cbTL18.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL18='Socio Emotional Learning' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL18.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL18=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            if (cbTL19.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL19='Children at risk and children in conflict with the law' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL19.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL19=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL20.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL20='Reproductive health and Early pregnancy' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL20.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL20=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL21.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL21='Increasing Adversity Quotient' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL21.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL21=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL22.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL22='Mental Health in School Setting' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL22.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL22=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL23.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL23='Reproductive Health' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL23.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL23=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL24.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL24='Research' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL24.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL24=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL25.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL25='Self-Management' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL25.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL25=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL26.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL26='Professionalism and Ethics' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL26.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL26=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL27.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL27='Teamwork' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL27.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL27=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL28.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL28='Service Orientation' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL28.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL28=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL29.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL29='Innovation' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL29.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL29=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL30.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL30='Oral Communication' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL30.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL30=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL31.Checked == true)
            {
                tbTL31.Enabled = false;
                Connection();
                command = new SqlCommand("update Questionnaire set TL31='" + tbTL31.Text + "' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL31.Checked == false)
            {
                tbTL31.Enabled = true;
                Connection();
                command = new SqlCommand("update Questionnaire set TL31=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL32.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL32='Disaster Preparedness' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL32.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL32=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL33.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL33='Child Protection Policy' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL33.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL33=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL34.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL34='Anti-Bullying Policy' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL34.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL34=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL35.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL35='Alternative Work Arrangement' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL35.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL35=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL36.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL36='Health Protocools' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL36.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL36=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL37.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL37='" + tbTL37.Text + "' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL37.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL37=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            saveQ2();
        }
   
        private void saveQ2()
        {
            if (cbTL38.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL38='Designng Lessons' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL38.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL38=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL39.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL39='Class Management' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL39.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL39=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL40.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL40='Teacher Learner Interaction' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL40.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL40=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL41.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL41='Assessment' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL41.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL41=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL42.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL42='Art of Questioning' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL42.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL42=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL43.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL43='Testing/Assessment Learning' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL43.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL43=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL44.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL44='Motivation' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL44.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL44=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL45.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL45='Community Linkages' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL45.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL45=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL46.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL46='Research' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL46.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL46=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL47.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL47='Innovative Teaching,please specify' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL47.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL47=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL48.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL48='" + tbTL48.Text + "' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL48.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL48=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL49.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL49='Improved Financial Management Skills' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL49.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL49=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL50.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL50='Self Motivation' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL50.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL50=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL51.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL51='Positive Work Attitude' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL51.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL51=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL52.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL52='Proper Grooming' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL52.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL52=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL53.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL53='Self-Descipline' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL53.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL53=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL54.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL54='Improved Time Management Skills' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL54.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL54=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL55.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL55='" + tbTL55.Text + "' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL55.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL55=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL56.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL56='Improved Work Performance' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL56.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL56=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL57.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL57='Fast Customer Service' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL57.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL57=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL58.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL58='Implementation of Programs, Activities and Projects in accordance with Policies' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL58.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL58=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL59.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL59='" + tbTL59.Text + "' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL59.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL59=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            saveQ5();
        }

        private void saveQ5()
        {
            if (cbTL62.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL62='LAC Sessions' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL62.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL62=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL63.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL63='Coaching' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if(cbTL63.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL63=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL64.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL64='Mentoring' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL64.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL64=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL65.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL65='Observation' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL65.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL65=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL66.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL66='Workshop' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL66.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL66=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL67.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL67='Focused Group Discussion' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL67.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL67=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL68.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL68='Job Embedded Learning' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL68.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL68=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL69.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL69='Action Research' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL69.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL69=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL70.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL70='Cross Training' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL70.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL70=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL71.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL71='Re-assignment in other office/station' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL71.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL71=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL72.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL72='Peer Support' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL72.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL72=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL73.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL73='Learning & Development Materials Support Portal' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL73.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL73=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }

            if (cbTL74.Checked == true)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL74='" + tbTL74.Text + "' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            else if (cbTL74.Checked == false)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL74=null where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
            }
            saveREMARKS();
        }

        private void saveREMARKS()
        {
            Connection();
            command = new SqlCommand("update Questionnaire set TL60='" + tbTL60.Text + "' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
            command.ExecuteNonQuery();
            if (command.ExecuteNonQuery() == 1)
            {
                Connection();
                command = new SqlCommand("update Questionnaire set TL61='" + tbTL61.Text + "' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                command.ExecuteNonQuery();
                if (command.ExecuteNonQuery() == 1)
                {
                    Connection();
                    command = new SqlCommand("update Questionnaire set TL75='" + tbTL75.Text + "' where UserID='" + tbUserID.Text + "' and TrainingID='" + tbTrainingID.Text + "'", conn);
                    command.ExecuteNonQuery();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        Cursor = Cursors.Default;
                        if (tbUserType.Text == "projectSoldier")
                        {
                            Cursor = Cursors.Default;
                            projectsoldier.addQRImageAttendance();
                            this.Close();
                        }
                        else if (tbUserType.Text == "admin")
                        {
                            Cursor = Cursors.Default;
                            projectsoldierAdmin.addQRImageAttendance();
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

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            saveQ1();
        }
    }
}