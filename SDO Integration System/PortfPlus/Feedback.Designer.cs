
namespace SDO_Integrated_System
{
    partial class Feedback
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
            this.tbFeedback = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFName = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbContact = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Submit = new ePOSOne.btnProduct.Button_WOC();
            this.SuspendLayout();
            // 
            // tbFeedback
            // 
            this.tbFeedback.Location = new System.Drawing.Point(53, 213);
            this.tbFeedback.Name = "tbFeedback";
            this.tbFeedback.Size = new System.Drawing.Size(547, 143);
            this.tbFeedback.TabIndex = 1;
            this.tbFeedback.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Questions / Feedback / Suggestions";
            // 
            // tbFName
            // 
            this.tbFName.Location = new System.Drawing.Point(113, 68);
            this.tbFName.Name = "tbFName";
            this.tbFName.Size = new System.Drawing.Size(487, 21);
            this.tbFName.TabIndex = 3;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(113, 104);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(487, 21);
            this.tbEmail.TabIndex = 4;
            // 
            // tbContact
            // 
            this.tbContact.Location = new System.Drawing.Point(113, 142);
            this.tbContact.Name = "tbContact";
            this.tbContact.Size = new System.Drawing.Size(487, 21);
            this.tbContact.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Full Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Contact #:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Optional Informations";
            // 
            // Submit
            // 
            this.Submit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Submit.BackColor = System.Drawing.Color.Transparent;
            this.Submit.BorderColor = System.Drawing.Color.White;
            this.Submit.ButtonColor = System.Drawing.Color.Firebrick;
            this.Submit.FlatAppearance.BorderSize = 0;
            this.Submit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Submit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Submit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Submit.Location = new System.Drawing.Point(230, 362);
            this.Submit.Name = "Submit";
            this.Submit.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(174)))), ((int)(((byte)(81)))));
            this.Submit.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(174)))), ((int)(((byte)(81)))));
            this.Submit.OnHoverTextColor = System.Drawing.Color.White;
            this.Submit.Size = new System.Drawing.Size(184, 49);
            this.Submit.TabIndex = 53;
            this.Submit.Text = "SUBMIT";
            this.Submit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Submit.TextColor = System.Drawing.Color.White;
            this.Submit.UseVisualStyleBackColor = false;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // Feedback
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 441);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbContact);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbFName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFeedback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Feedback";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Feedback";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbFeedback;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFName;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbContact;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ePOSOne.btnProduct.Button_WOC Submit;
    }
}