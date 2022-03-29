
namespace SDO_Integrated_System
{
    partial class TeacherRegistration
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
            this.caEmail = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.caDesignation = new System.Windows.Forms.TextBox();
            this.caCreateBtn = new ePOSOne.btnProduct.Button_WOC();
            this.caContact = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.caFname = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbSchoolName = new DevExpress.XtraEditors.TextEdit();
            this.tbSchoolID = new DevExpress.XtraEditors.TextEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSchoolName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSchoolID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // caEmail
            // 
            this.caEmail.Location = new System.Drawing.Point(28, 171);
            this.caEmail.Name = "caEmail";
            this.caEmail.Size = new System.Drawing.Size(347, 20);
            this.caEmail.TabIndex = 144;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(28, 155);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 143;
            this.label13.Text = "DepEd Email";
            // 
            // caDesignation
            // 
            this.caDesignation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.caDesignation.Location = new System.Drawing.Point(28, 78);
            this.caDesignation.Name = "caDesignation";
            this.caDesignation.Size = new System.Drawing.Size(347, 20);
            this.caDesignation.TabIndex = 140;
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
            this.caCreateBtn.Location = new System.Drawing.Point(115, 215);
            this.caCreateBtn.Name = "caCreateBtn";
            this.caCreateBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(174)))), ((int)(((byte)(81)))));
            this.caCreateBtn.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(174)))), ((int)(((byte)(81)))));
            this.caCreateBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.caCreateBtn.Size = new System.Drawing.Size(149, 35);
            this.caCreateBtn.TabIndex = 133;
            this.caCreateBtn.Text = "ADD";
            this.caCreateBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.caCreateBtn.TextColor = System.Drawing.Color.White;
            this.caCreateBtn.UseVisualStyleBackColor = false;
            this.caCreateBtn.Click += new System.EventHandler(this.caCreateBtn_Click);
            // 
            // caContact
            // 
            this.caContact.Location = new System.Drawing.Point(28, 124);
            this.caContact.Name = "caContact";
            this.caContact.Size = new System.Drawing.Size(347, 20);
            this.caContact.TabIndex = 132;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(28, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 125;
            this.label7.Text = "Position";
            // 
            // caFname
            // 
            this.caFname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.caFname.Location = new System.Drawing.Point(28, 26);
            this.caFname.Name = "caFname";
            this.caFname.Size = new System.Drawing.Size(347, 20);
            this.caFname.TabIndex = 129;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(25, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 127;
            this.label9.Text = "Contact";
            this.label9.UseMnemonic = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(28, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 13);
            this.label6.TabIndex = 124;
            this.label6.Text = "Full Name (Last First MI Ext)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbSchoolName);
            this.panel1.Controls.Add(this.tbSchoolID);
            this.panel1.Location = new System.Drawing.Point(381, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 252);
            this.panel1.TabIndex = 149;
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
            // TeacherRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 264);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.caEmail);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.caDesignation);
            this.Controls.Add(this.caCreateBtn);
            this.Controls.Add(this.caContact);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.caFname);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Name = "TeacherRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teacher Registration";
            this.Load += new System.EventHandler(this.TeacherRegistration_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbSchoolName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSchoolID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox caEmail;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox caDesignation;
        private ePOSOne.btnProduct.Button_WOC caCreateBtn;
        private System.Windows.Forms.TextBox caContact;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox caFname;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit tbSchoolName;
        private DevExpress.XtraEditors.TextEdit tbSchoolID;
    }
}