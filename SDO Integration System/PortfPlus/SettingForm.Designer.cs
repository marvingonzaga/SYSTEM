
namespace SDO_Integrated_System
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.label27 = new System.Windows.Forms.Label();
            this.caSchool = new System.Windows.Forms.ComboBox();
            this.caEmail = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.caPassword = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.caDesignation = new System.Windows.Forms.TextBox();
            this.caExt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.caMI = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.caLName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.caCreateBtn = new ePOSOne.btnProduct.Button_WOC();
            this.caContact = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.caUsername = new System.Windows.Forms.TextBox();
            this.caPositionTitle = new System.Windows.Forms.TextBox();
            this.caFname = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbSchoolName = new DevExpress.XtraEditors.TextEdit();
            this.tbSchoolID = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSchoolName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSchoolID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(28, 60);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(38, 13);
            this.label27.TabIndex = 148;
            this.label27.Text = "School";
            // 
            // caSchool
            // 
            this.caSchool.FormattingEnabled = true;
            this.caSchool.Location = new System.Drawing.Point(28, 76);
            this.caSchool.Name = "caSchool";
            this.caSchool.Size = new System.Drawing.Size(347, 21);
            this.caSchool.TabIndex = 147;
            this.caSchool.DropDown += new System.EventHandler(this.caSchool_DropDown);
            this.caSchool.SelectedIndexChanged += new System.EventHandler(this.caSchool_SelectedIndexChanged);
            // 
            // caEmail
            // 
            this.caEmail.Location = new System.Drawing.Point(199, 223);
            this.caEmail.Name = "caEmail";
            this.caEmail.Size = new System.Drawing.Size(176, 21);
            this.caEmail.TabIndex = 144;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(199, 207);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 143;
            this.label13.Text = "DepEd Email";
            // 
            // caPassword
            // 
            this.caPassword.Location = new System.Drawing.Point(196, 269);
            this.caPassword.Name = "caPassword";
            this.caPassword.Size = new System.Drawing.Size(176, 21);
            this.caPassword.TabIndex = 142;
            this.caPassword.UseSystemPasswordChar = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(196, 253);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 141;
            this.label12.Text = "Password";
            this.label12.UseMnemonic = false;
            // 
            // caDesignation
            // 
            this.caDesignation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.caDesignation.Location = new System.Drawing.Point(28, 126);
            this.caDesignation.Name = "caDesignation";
            this.caDesignation.Size = new System.Drawing.Size(347, 21);
            this.caDesignation.TabIndex = 140;
            // 
            // caExt
            // 
            this.caExt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.caExt.Location = new System.Drawing.Point(337, 26);
            this.caExt.Name = "caExt";
            this.caExt.Size = new System.Drawing.Size(38, 21);
            this.caExt.TabIndex = 139;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(337, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 138;
            this.label11.Text = "Ext.";
            // 
            // caMI
            // 
            this.caMI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.caMI.Location = new System.Drawing.Point(160, 26);
            this.caMI.Name = "caMI";
            this.caMI.Size = new System.Drawing.Size(30, 21);
            this.caMI.TabIndex = 137;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(160, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 136;
            this.label5.Text = "M.I.";
            // 
            // caLName
            // 
            this.caLName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.caLName.Location = new System.Drawing.Point(196, 26);
            this.caLName.Name = "caLName";
            this.caLName.Size = new System.Drawing.Size(135, 21);
            this.caLName.TabIndex = 135;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(196, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 134;
            this.label4.Text = "Last Name";
            // 
            // caCreateBtn
            // 
            this.caCreateBtn.BackColor = System.Drawing.Color.Transparent;
            this.caCreateBtn.BorderColor = System.Drawing.Color.Empty;
            this.caCreateBtn.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(31)))), ((int)(((byte)(36)))));
            this.caCreateBtn.FlatAppearance.BorderSize = 0;
            this.caCreateBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.caCreateBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.caCreateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.caCreateBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caCreateBtn.Location = new System.Drawing.Point(115, 313);
            this.caCreateBtn.Name = "caCreateBtn";
            this.caCreateBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(174)))), ((int)(((byte)(81)))));
            this.caCreateBtn.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(174)))), ((int)(((byte)(81)))));
            this.caCreateBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.caCreateBtn.Size = new System.Drawing.Size(149, 35);
            this.caCreateBtn.TabIndex = 133;
            this.caCreateBtn.Text = "UPDATE";
            this.caCreateBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.caCreateBtn.TextColor = System.Drawing.Color.White;
            this.caCreateBtn.UseVisualStyleBackColor = false;
            this.caCreateBtn.Click += new System.EventHandler(this.caCreateBtn_Click);
            // 
            // caContact
            // 
            this.caContact.Location = new System.Drawing.Point(28, 223);
            this.caContact.Name = "caContact";
            this.caContact.Size = new System.Drawing.Size(162, 21);
            this.caContact.TabIndex = 132;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(28, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 125;
            this.label7.Text = "Designation";
            // 
            // caUsername
            // 
            this.caUsername.Location = new System.Drawing.Point(28, 269);
            this.caUsername.Name = "caUsername";
            this.caUsername.Size = new System.Drawing.Size(162, 21);
            this.caUsername.TabIndex = 131;
            // 
            // caPositionTitle
            // 
            this.caPositionTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.caPositionTitle.Location = new System.Drawing.Point(28, 177);
            this.caPositionTitle.Name = "caPositionTitle";
            this.caPositionTitle.Size = new System.Drawing.Size(347, 21);
            this.caPositionTitle.TabIndex = 130;
            // 
            // caFname
            // 
            this.caFname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.caFname.Location = new System.Drawing.Point(28, 26);
            this.caFname.Name = "caFname";
            this.caFname.Size = new System.Drawing.Size(127, 21);
            this.caFname.TabIndex = 129;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(28, 253);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 128;
            this.label10.Text = "Username";
            this.label10.UseMnemonic = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(25, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 127;
            this.label9.Text = "Contact";
            this.label9.UseMnemonic = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(28, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 126;
            this.label8.Text = "Position Title";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(28, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 124;
            this.label6.Text = "First Name";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(352, 270);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(19, 19);
            this.pictureBox5.TabIndex = 146;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbSchoolName);
            this.panel1.Controls.Add(this.tbSchoolID);
            this.panel1.Location = new System.Drawing.Point(381, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 252);
            this.panel1.TabIndex = 149;
            this.panel1.Visible = false;
            // 
            // tbSchoolName
            // 
            this.tbSchoolName.Location = new System.Drawing.Point(18, 46);
            this.tbSchoolName.Name = "tbSchoolName";
            this.tbSchoolName.Size = new System.Drawing.Size(167, 20);
            this.tbSchoolName.TabIndex = 68;
            // 
            // tbSchoolID
            // 
            this.tbSchoolID.Location = new System.Drawing.Point(20, 20);
            this.tbSchoolID.Name = "tbSchoolID";
            this.tbSchoolID.Size = new System.Drawing.Size(100, 20);
            this.tbSchoolID.TabIndex = 67;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 360);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.caSchool);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.caEmail);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.caPassword);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.caDesignation);
            this.Controls.Add(this.caExt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.caMI);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.caLName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.caCreateBtn);
            this.Controls.Add(this.caContact);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.caUsername);
            this.Controls.Add(this.caPositionTitle);
            this.Controls.Add(this.caFname);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Setting";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbSchoolName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSchoolID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox caSchool;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox caEmail;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox caPassword;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox caDesignation;
        private System.Windows.Forms.TextBox caExt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox caMI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox caLName;
        private System.Windows.Forms.Label label4;
        private ePOSOne.btnProduct.Button_WOC caCreateBtn;
        private System.Windows.Forms.TextBox caContact;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox caUsername;
        private System.Windows.Forms.TextBox caPositionTitle;
        private System.Windows.Forms.TextBox caFname;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit tbSchoolName;
        private DevExpress.XtraEditors.TextEdit tbSchoolID;
    }
}