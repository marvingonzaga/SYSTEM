
namespace SDO_Integrated_System
{
    partial class PostTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlQ1 = new System.Windows.Forms.Panel();
            this.pnlID = new System.Windows.Forms.Panel();
            this.tbPassingScore = new System.Windows.Forms.TextBox();
            this.tbCountCorrectAnswers = new System.Windows.Forms.TextBox();
            this.tbAnswerKey = new System.Windows.Forms.TextBox();
            this.tbCountAnsweredQuestions = new System.Windows.Forms.TextBox();
            this.tbCountQuestions = new System.Windows.Forms.TextBox();
            this.tbQID = new System.Windows.Forms.TextBox();
            this.tbRemarks = new System.Windows.Forms.TextBox();
            this.tbAnswer = new System.Windows.Forms.TextBox();
            this.tbQuestion = new System.Windows.Forms.TextBox();
            this.tbUserType = new System.Windows.Forms.TextBox();
            this.tbTrainingID = new System.Windows.Forms.TextBox();
            this.tbUserID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvChoices = new System.Windows.Forms.DataGridView();
            this.dgvQuestions = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.RegisterBtn = new ePOSOne.btnProduct.Button_WOC();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlQ1.SuspendLayout();
            this.pnlID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlQ1
            // 
            this.pnlQ1.Controls.Add(this.pnlID);
            this.pnlQ1.Controls.Add(this.label3);
            this.pnlQ1.Controls.Add(this.label1);
            this.pnlQ1.Controls.Add(this.dgvChoices);
            this.pnlQ1.Controls.Add(this.dgvQuestions);
            this.pnlQ1.Controls.Add(this.label2);
            this.pnlQ1.Controls.Add(this.RegisterBtn);
            this.pnlQ1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQ1.Location = new System.Drawing.Point(0, 0);
            this.pnlQ1.Name = "pnlQ1";
            this.pnlQ1.Size = new System.Drawing.Size(1151, 640);
            this.pnlQ1.TabIndex = 103;
            // 
            // pnlID
            // 
            this.pnlID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlID.Controls.Add(this.label6);
            this.pnlID.Controls.Add(this.label5);
            this.pnlID.Controls.Add(this.label4);
            this.pnlID.Controls.Add(this.tbPassingScore);
            this.pnlID.Controls.Add(this.tbCountCorrectAnswers);
            this.pnlID.Controls.Add(this.tbAnswerKey);
            this.pnlID.Controls.Add(this.tbCountAnsweredQuestions);
            this.pnlID.Controls.Add(this.tbCountQuestions);
            this.pnlID.Controls.Add(this.tbQID);
            this.pnlID.Controls.Add(this.tbRemarks);
            this.pnlID.Controls.Add(this.tbAnswer);
            this.pnlID.Controls.Add(this.tbQuestion);
            this.pnlID.Controls.Add(this.tbUserType);
            this.pnlID.Controls.Add(this.tbTrainingID);
            this.pnlID.Controls.Add(this.tbUserID);
            this.pnlID.Location = new System.Drawing.Point(825, 393);
            this.pnlID.Name = "pnlID";
            this.pnlID.Size = new System.Drawing.Size(393, 225);
            this.pnlID.TabIndex = 196;
            this.pnlID.Visible = false;
            // 
            // tbPassingScore
            // 
            this.tbPassingScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPassingScore.Location = new System.Drawing.Point(253, 84);
            this.tbPassingScore.Name = "tbPassingScore";
            this.tbPassingScore.ReadOnly = true;
            this.tbPassingScore.Size = new System.Drawing.Size(137, 21);
            this.tbPassingScore.TabIndex = 11;
            this.tbPassingScore.TabStop = false;
            // 
            // tbCountCorrectAnswers
            // 
            this.tbCountCorrectAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCountCorrectAnswers.Location = new System.Drawing.Point(253, 57);
            this.tbCountCorrectAnswers.Name = "tbCountCorrectAnswers";
            this.tbCountCorrectAnswers.ReadOnly = true;
            this.tbCountCorrectAnswers.Size = new System.Drawing.Size(137, 21);
            this.tbCountCorrectAnswers.TabIndex = 10;
            this.tbCountCorrectAnswers.TabStop = false;
            this.tbCountCorrectAnswers.TextChanged += new System.EventHandler(this.tbCountCorrectAnswers_TextChanged);
            // 
            // tbAnswerKey
            // 
            this.tbAnswerKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAnswerKey.Location = new System.Drawing.Point(94, 161);
            this.tbAnswerKey.Name = "tbAnswerKey";
            this.tbAnswerKey.Size = new System.Drawing.Size(187, 21);
            this.tbAnswerKey.TabIndex = 9;
            this.tbAnswerKey.TabStop = false;
            // 
            // tbCountAnsweredQuestions
            // 
            this.tbCountAnsweredQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCountAnsweredQuestions.Location = new System.Drawing.Point(253, 30);
            this.tbCountAnsweredQuestions.Name = "tbCountAnsweredQuestions";
            this.tbCountAnsweredQuestions.ReadOnly = true;
            this.tbCountAnsweredQuestions.Size = new System.Drawing.Size(137, 21);
            this.tbCountAnsweredQuestions.TabIndex = 8;
            this.tbCountAnsweredQuestions.TabStop = false;
            this.tbCountAnsweredQuestions.TextChanged += new System.EventHandler(this.tbCountAnswered_TextChanged);
            // 
            // tbCountQuestions
            // 
            this.tbCountQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCountQuestions.Location = new System.Drawing.Point(253, 3);
            this.tbCountQuestions.Name = "tbCountQuestions";
            this.tbCountQuestions.ReadOnly = true;
            this.tbCountQuestions.Size = new System.Drawing.Size(137, 21);
            this.tbCountQuestions.TabIndex = 7;
            this.tbCountQuestions.TabStop = false;
            this.tbCountQuestions.TextChanged += new System.EventHandler(this.tbCountQuestions_TextChanged);
            // 
            // tbQID
            // 
            this.tbQID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbQID.Location = new System.Drawing.Point(94, 3);
            this.tbQID.Name = "tbQID";
            this.tbQID.ReadOnly = true;
            this.tbQID.Size = new System.Drawing.Size(137, 21);
            this.tbQID.TabIndex = 6;
            this.tbQID.TabStop = false;
            // 
            // tbRemarks
            // 
            this.tbRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRemarks.Location = new System.Drawing.Point(94, 188);
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.Size = new System.Drawing.Size(187, 21);
            this.tbRemarks.TabIndex = 5;
            this.tbRemarks.TabStop = false;
            // 
            // tbAnswer
            // 
            this.tbAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAnswer.Location = new System.Drawing.Point(94, 134);
            this.tbAnswer.Name = "tbAnswer";
            this.tbAnswer.Size = new System.Drawing.Size(187, 21);
            this.tbAnswer.TabIndex = 4;
            this.tbAnswer.TabStop = false;
            this.tbAnswer.TextChanged += new System.EventHandler(this.tbAnswer_TextChanged);
            // 
            // tbQuestion
            // 
            this.tbQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbQuestion.Location = new System.Drawing.Point(94, 107);
            this.tbQuestion.Name = "tbQuestion";
            this.tbQuestion.Size = new System.Drawing.Size(187, 21);
            this.tbQuestion.TabIndex = 3;
            this.tbQuestion.TabStop = false;
            this.tbQuestion.TextChanged += new System.EventHandler(this.tbQuestion_TextChanged);
            // 
            // tbUserType
            // 
            this.tbUserType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUserType.Location = new System.Drawing.Point(94, 30);
            this.tbUserType.Name = "tbUserType";
            this.tbUserType.ReadOnly = true;
            this.tbUserType.Size = new System.Drawing.Size(137, 21);
            this.tbUserType.TabIndex = 2;
            this.tbUserType.TabStop = false;
            // 
            // tbTrainingID
            // 
            this.tbTrainingID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTrainingID.Location = new System.Drawing.Point(94, 80);
            this.tbTrainingID.Name = "tbTrainingID";
            this.tbTrainingID.ReadOnly = true;
            this.tbTrainingID.Size = new System.Drawing.Size(137, 21);
            this.tbTrainingID.TabIndex = 1;
            this.tbTrainingID.TabStop = false;
            this.tbTrainingID.TextChanged += new System.EventHandler(this.tbTrainingID_TextChanged);
            // 
            // tbUserID
            // 
            this.tbUserID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUserID.Location = new System.Drawing.Point(94, 55);
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.ReadOnly = true;
            this.tbUserID.Size = new System.Drawing.Size(137, 21);
            this.tbUserID.TabIndex = 0;
            this.tbUserID.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(759, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 200;
            this.label3.Text = "Select your answer";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 199;
            this.label1.Text = "Questions";
            // 
            // dgvChoices
            // 
            this.dgvChoices.AllowUserToAddRows = false;
            this.dgvChoices.AllowUserToDeleteRows = false;
            this.dgvChoices.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvChoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChoices.Location = new System.Drawing.Point(762, 95);
            this.dgvChoices.Name = "dgvChoices";
            this.dgvChoices.ReadOnly = true;
            this.dgvChoices.ShowEditingIcon = false;
            this.dgvChoices.Size = new System.Drawing.Size(320, 212);
            this.dgvChoices.TabIndex = 198;
            this.dgvChoices.TabStop = false;
            this.dgvChoices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChoices_CellClick);
            // 
            // dgvQuestions
            // 
            this.dgvQuestions.AllowUserToAddRows = false;
            this.dgvQuestions.AllowUserToDeleteRows = false;
            this.dgvQuestions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvQuestions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuestions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(70)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuestions.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvQuestions.Location = new System.Drawing.Point(42, 95);
            this.dgvQuestions.Name = "dgvQuestions";
            this.dgvQuestions.ReadOnly = true;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuestions.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestions.ShowCellErrors = false;
            this.dgvQuestions.ShowCellToolTips = false;
            this.dgvQuestions.ShowEditingIcon = false;
            this.dgvQuestions.ShowRowErrors = false;
            this.dgvQuestions.Size = new System.Drawing.Size(714, 452);
            this.dgvQuestions.TabIndex = 197;
            this.dgvQuestions.TabStop = false;
            this.dgvQuestions.VirtualMode = true;
            this.dgvQuestions.Click += new System.EventHandler(this.dgvQuestions_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(165, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(829, 43);
            this.label2.TabIndex = 8;
            this.label2.Text = "POST-TEST: TRUE OR FALSE";
            // 
            // RegisterBtn
            // 
            this.RegisterBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterBtn.BackColor = System.Drawing.Color.Transparent;
            this.RegisterBtn.BorderColor = System.Drawing.Color.Empty;
            this.RegisterBtn.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.RegisterBtn.FlatAppearance.BorderSize = 0;
            this.RegisterBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RegisterBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RegisterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterBtn.Location = new System.Drawing.Point(851, 313);
            this.RegisterBtn.Name = "RegisterBtn";
            this.RegisterBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.RegisterBtn.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.RegisterBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.RegisterBtn.Size = new System.Drawing.Size(162, 50);
            this.RegisterBtn.TabIndex = 100;
            this.RegisterBtn.Text = "SUBMIT";
            this.RegisterBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RegisterBtn.TextColor = System.Drawing.Color.White;
            this.RegisterBtn.UseVisualStyleBackColor = false;
            this.RegisterBtn.Click += new System.EventHandler(this.RegisterBtn_Click);
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.Name = "sqlDataSource1";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "tbAnswer";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "tbQID";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "tbUserType";
            // 
            // PostTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 640);
            this.Controls.Add(this.pnlQ1);
            this.Name = "PostTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PostTest";
            this.Load += new System.EventHandler(this.PostTest_Load);
            this.pnlQ1.ResumeLayout(false);
            this.pnlQ1.PerformLayout();
            this.pnlID.ResumeLayout(false);
            this.pnlID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlQ1;
        private System.Windows.Forms.Panel pnlID;
        public System.Windows.Forms.TextBox tbRemarks;
        public System.Windows.Forms.TextBox tbAnswer;
        public System.Windows.Forms.TextBox tbQuestion;
        public System.Windows.Forms.TextBox tbUserType;
        public System.Windows.Forms.TextBox tbTrainingID;
        public System.Windows.Forms.TextBox tbUserID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvChoices;
        private System.Windows.Forms.DataGridView dgvQuestions;
        private System.Windows.Forms.Label label2;
        private ePOSOne.btnProduct.Button_WOC RegisterBtn;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        public System.Windows.Forms.TextBox tbQID;
        public System.Windows.Forms.TextBox tbCountQuestions;
        public System.Windows.Forms.TextBox tbCountAnsweredQuestions;
        public System.Windows.Forms.TextBox tbAnswerKey;
        public System.Windows.Forms.TextBox tbCountCorrectAnswers;
        public System.Windows.Forms.TextBox tbPassingScore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}