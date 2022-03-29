
namespace SDO_Integrated_System.Inventory.Forms
{
    partial class AccountRegistration
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
            this.arUserEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.arAccountType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.arStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.arNotes = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbAccountID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbFor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ARSaveBtn = new SDO_Integrated_System.RJButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // arUserEmail
            // 
            this.arUserEmail.Location = new System.Drawing.Point(45, 89);
            this.arUserEmail.Name = "arUserEmail";
            this.arUserEmail.Size = new System.Drawing.Size(284, 21);
            this.arUserEmail.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username / Email";
            // 
            // arAccountType
            // 
            this.arAccountType.FormattingEnabled = true;
            this.arAccountType.Items.AddRange(new object[] {
            "LIS",
            "LRMDS",
            "PNPKI",
            "HubHuman",
            "MS 365",
            "Google Workspace"});
            this.arAccountType.Location = new System.Drawing.Point(45, 38);
            this.arAccountType.Name = "arAccountType";
            this.arAccountType.Size = new System.Drawing.Size(284, 21);
            this.arAccountType.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Account Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Status";
            // 
            // arStatus
            // 
            this.arStatus.FormattingEnabled = true;
            this.arStatus.Location = new System.Drawing.Point(45, 140);
            this.arStatus.Name = "arStatus";
            this.arStatus.Size = new System.Drawing.Size(284, 21);
            this.arStatus.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Notes";
            // 
            // arNotes
            // 
            this.arNotes.Location = new System.Drawing.Point(45, 192);
            this.arNotes.Name = "arNotes";
            this.arNotes.Size = new System.Drawing.Size(283, 105);
            this.arNotes.TabIndex = 8;
            this.arNotes.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbAccountID);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbFor);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(335, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 158);
            this.panel1.TabIndex = 121;
            this.panel1.Visible = false;
            // 
            // tbAccountID
            // 
            this.tbAccountID.Location = new System.Drawing.Point(81, 45);
            this.tbAccountID.Name = "tbAccountID";
            this.tbAccountID.Size = new System.Drawing.Size(131, 21);
            this.tbAccountID.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "AccountID";
            // 
            // tbFor
            // 
            this.tbFor.Location = new System.Drawing.Point(81, 18);
            this.tbFor.Name = "tbFor";
            this.tbFor.Size = new System.Drawing.Size(131, 21);
            this.tbFor.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "for";
            // 
            // ARSaveBtn
            // 
            this.ARSaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ARSaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(97)))), ((int)(((byte)(12)))));
            this.ARSaveBtn.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(97)))), ((int)(((byte)(12)))));
            this.ARSaveBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ARSaveBtn.BorderRadius = 15;
            this.ARSaveBtn.BorderSize = 0;
            this.ARSaveBtn.FlatAppearance.BorderSize = 0;
            this.ARSaveBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ARSaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ARSaveBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ARSaveBtn.ForeColor = System.Drawing.Color.White;
            this.ARSaveBtn.Location = new System.Drawing.Point(102, 312);
            this.ARSaveBtn.Name = "ARSaveBtn";
            this.ARSaveBtn.Size = new System.Drawing.Size(149, 33);
            this.ARSaveBtn.TabIndex = 120;
            this.ARSaveBtn.Text = "SAVE";
            this.ARSaveBtn.TextColor = System.Drawing.Color.White;
            this.ARSaveBtn.UseVisualStyleBackColor = false;
            this.ARSaveBtn.Click += new System.EventHandler(this.ARSaveBtn_Click);
            // 
            // AccountRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 366);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ARSaveBtn);
            this.Controls.Add(this.arNotes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.arStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.arAccountType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.arUserEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AccountRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Registration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AccountRegistration_FormClosing);
            this.Load += new System.EventHandler(this.AccountRegistration_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox arUserEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox arAccountType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox arStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox arNotes;
        private RJButton ARSaveBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbAccountID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox tbFor;
    }
}