
namespace SDO_Integrated_System
{
    partial class CertTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CertTemplate));
            this.cbcertTemplate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.certificateImage = new System.Windows.Forms.PictureBox();
            this.rjButton1 = new SDO_Integrated_System.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.certificateImage)).BeginInit();
            this.SuspendLayout();
            // 
            // cbcertTemplate
            // 
            this.cbcertTemplate.FormattingEnabled = true;
            this.cbcertTemplate.Items.AddRange(new object[] {
            "Certificate 1",
            "Certificate 2"});
            this.cbcertTemplate.Location = new System.Drawing.Point(115, 7);
            this.cbcertTemplate.Name = "cbcertTemplate";
            this.cbcertTemplate.Size = new System.Drawing.Size(173, 21);
            this.cbcertTemplate.TabIndex = 1;
            this.cbcertTemplate.SelectedValueChanged += new System.EventHandler(this.cbcertTemplate_SelectedValueChanged);
            this.cbcertTemplate.VisibleChanged += new System.EventHandler(this.cbcertTemplate_VisibleChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose Template :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // certificateImage
            // 
            this.certificateImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.certificateImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.certificateImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.certificateImage.Location = new System.Drawing.Point(12, 34);
            this.certificateImage.Name = "certificateImage";
            this.certificateImage.Size = new System.Drawing.Size(747, 496);
            this.certificateImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.certificateImage.TabIndex = 0;
            this.certificateImage.TabStop = false;
            // 
            // rjButton1
            // 
            this.rjButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rjButton1.BackColor = System.Drawing.Color.RoyalBlue;
            this.rjButton1.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.rjButton1.BorderColor = System.Drawing.Color.RoyalBlue;
            this.rjButton1.BorderRadius = 10;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.rjButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(294, 4);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(59, 26);
            this.rjButton1.TabIndex = 80;
            this.rjButton1.Text = "Procced";
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // CertTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 542);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbcertTemplate);
            this.Controls.Add(this.certificateImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("CertTemplate.IconOptions.Image")));
            this.Name = "CertTemplate";
            this.Text = "Certification Template";
            ((System.ComponentModel.ISupportInitialize)(this.certificateImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox certificateImage;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbcertTemplate;
        private RJButton rjButton1;
    }
}