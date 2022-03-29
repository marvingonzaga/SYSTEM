
namespace PortfPlus
{
    partial class SendEmail
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
            this.asddgsdfgdf = new DevExpress.XtraEditors.LabelControl();
            this.fhfdgh = new DevExpress.XtraEditors.LabelControl();
            this.labl = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.tbSMTP = new DevExpress.XtraEditors.TextEdit();
            this.tbPort = new DevExpress.XtraEditors.TextEdit();
            this.tbUsername = new DevExpress.XtraEditors.TextEdit();
            this.tbBody = new System.Windows.Forms.RichTextBox();
            this.tbSubject = new DevExpress.XtraEditors.TextEdit();
            this.tbTo = new DevExpress.XtraEditors.TextEdit();
            this.tbPassword = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSMTP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // asddgsdfgdf
            // 
            this.asddgsdfgdf.Location = new System.Drawing.Point(6, 247);
            this.asddgsdfgdf.Name = "asddgsdfgdf";
            this.asddgsdfgdf.Size = new System.Drawing.Size(26, 13);
            this.asddgsdfgdf.TabIndex = 29;
            this.asddgsdfgdf.Text = "SMTP";
            // 
            // fhfdgh
            // 
            this.fhfdgh.Location = new System.Drawing.Point(6, 221);
            this.fhfdgh.Name = "fhfdgh";
            this.fhfdgh.Size = new System.Drawing.Size(20, 13);
            this.fhfdgh.TabIndex = 28;
            this.fhfdgh.Text = "Port";
            // 
            // labl
            // 
            this.labl.Location = new System.Drawing.Point(6, 195);
            this.labl.Name = "labl";
            this.labl.Size = new System.Drawing.Size(46, 13);
            this.labl.TabIndex = 27;
            this.labl.Text = "Password";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(6, 169);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 13);
            this.labelControl4.TabIndex = 26;
            this.labelControl4.Text = "Username";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(6, 97);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 13);
            this.labelControl3.TabIndex = 25;
            this.labelControl3.Text = "Body";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 13);
            this.labelControl2.TabIndex = 24;
            this.labelControl2.Text = "Subject";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 13);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "To";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(63, 280);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(212, 34);
            this.simpleButton1.TabIndex = 22;
            this.simpleButton1.Text = "Send";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // tbSMTP
            // 
            this.tbSMTP.EditValue = "smtp.gmail.com";
            this.tbSMTP.Location = new System.Drawing.Point(63, 244);
            this.tbSMTP.Name = "tbSMTP";
            this.tbSMTP.Size = new System.Drawing.Size(212, 20);
            this.tbSMTP.TabIndex = 21;
            // 
            // tbPort
            // 
            this.tbPort.EditValue = "587";
            this.tbPort.Location = new System.Drawing.Point(63, 218);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(212, 20);
            this.tbPort.TabIndex = 20;
            // 
            // tbUsername
            // 
            this.tbUsername.EditValue = "marvinkrys@gmail.com";
            this.tbUsername.Location = new System.Drawing.Point(63, 166);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(212, 20);
            this.tbUsername.TabIndex = 18;
            this.tbUsername.EditValueChanged += new System.EventHandler(this.tbUsername_EditValueChanged);
            // 
            // tbBody
            // 
            this.tbBody.Location = new System.Drawing.Point(63, 64);
            this.tbBody.Name = "tbBody";
            this.tbBody.Size = new System.Drawing.Size(212, 96);
            this.tbBody.TabIndex = 17;
            this.tbBody.Text = "its working";
            // 
            // tbSubject
            // 
            this.tbSubject.EditValue = "test";
            this.tbSubject.Location = new System.Drawing.Point(63, 38);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(212, 20);
            this.tbSubject.TabIndex = 16;
            // 
            // tbTo
            // 
            this.tbTo.EditValue = "marvinkrys1@gmail.com";
            this.tbTo.Location = new System.Drawing.Point(63, 12);
            this.tbTo.Name = "tbTo";
            this.tbTo.Size = new System.Drawing.Size(212, 20);
            this.tbTo.TabIndex = 15;
            // 
            // tbPassword
            // 
            this.tbPassword.EditValue = "1Lmpa24ever";
            this.tbPassword.Location = new System.Drawing.Point(63, 192);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Properties.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(212, 20);
            this.tbPassword.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 323);
            this.Controls.Add(this.asddgsdfgdf);
            this.Controls.Add(this.fhfdgh);
            this.Controls.Add(this.labl);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.tbSMTP);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.tbBody);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.tbTo);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tbSMTP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl asddgsdfgdf;
        private DevExpress.XtraEditors.LabelControl fhfdgh;
        private DevExpress.XtraEditors.LabelControl labl;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit tbSMTP;
        private DevExpress.XtraEditors.TextEdit tbPort;
        private DevExpress.XtraEditors.TextEdit tbUsername;
        private System.Windows.Forms.RichTextBox tbBody;
        private DevExpress.XtraEditors.TextEdit tbSubject;
        private DevExpress.XtraEditors.TextEdit tbTo;
        private DevExpress.XtraEditors.TextEdit tbPassword;
    }
}