
namespace SDO_Integrated_System.The_Guardian.Forms
{
    partial class CertAttendancePrintFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CertAttendancePrintFrm));
            this.ppName = new System.Windows.Forms.TextBox();
            this.ppUserID = new System.Windows.Forms.TextBox();
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ppForm = new System.Windows.Forms.TextBox();
            this.ppcertContent = new System.Windows.Forms.RichTextBox();
            this.ppTrainingCode = new System.Windows.Forms.TextBox();
            this.ppTrainingID = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ppCertAttendanceTemp = new System.Windows.Forms.TextBox();
            this.ppcertTemplate = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ppName
            // 
            this.ppName.Location = new System.Drawing.Point(26, 30);
            this.ppName.Name = "ppName";
            this.ppName.Size = new System.Drawing.Size(100, 21);
            this.ppName.TabIndex = 6;
            // 
            // ppUserID
            // 
            this.ppUserID.Location = new System.Drawing.Point(26, 56);
            this.ppUserID.Name = "ppUserID";
            this.ppUserID.Size = new System.Drawing.Size(100, 21);
            this.ppUserID.TabIndex = 8;
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.ShowCloseButton = false;
            this.crystalReportViewer.ShowCopyButton = false;
            this.crystalReportViewer.ShowExportButton = false;
            this.crystalReportViewer.ShowGotoPageButton = false;
            this.crystalReportViewer.ShowGroupTreeButton = false;
            this.crystalReportViewer.ShowLogo = false;
            this.crystalReportViewer.ShowParameterPanelButton = false;
            this.crystalReportViewer.ShowTextSearchButton = false;
            this.crystalReportViewer.Size = new System.Drawing.Size(917, 533);
            this.crystalReportViewer.TabIndex = 14;
            this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ppForm
            // 
            this.ppForm.Location = new System.Drawing.Point(26, 3);
            this.ppForm.Name = "ppForm";
            this.ppForm.Size = new System.Drawing.Size(100, 21);
            this.ppForm.TabIndex = 11;
            // 
            // ppcertContent
            // 
            this.ppcertContent.Location = new System.Drawing.Point(26, 166);
            this.ppcertContent.Name = "ppcertContent";
            this.ppcertContent.Size = new System.Drawing.Size(147, 96);
            this.ppcertContent.TabIndex = 12;
            this.ppcertContent.Text = "";
            this.ppcertContent.TextChanged += new System.EventHandler(this.ppcertContent_TextChanged);
            // 
            // ppTrainingCode
            // 
            this.ppTrainingCode.Location = new System.Drawing.Point(26, 110);
            this.ppTrainingCode.Name = "ppTrainingCode";
            this.ppTrainingCode.Size = new System.Drawing.Size(100, 21);
            this.ppTrainingCode.TabIndex = 10;
            // 
            // ppTrainingID
            // 
            this.ppTrainingID.Location = new System.Drawing.Point(26, 83);
            this.ppTrainingID.Name = "ppTrainingID";
            this.ppTrainingID.Size = new System.Drawing.Size(100, 21);
            this.ppTrainingID.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ppCertAttendanceTemp);
            this.panel1.Controls.Add(this.ppcertTemplate);
            this.panel1.Controls.Add(this.ppForm);
            this.panel1.Controls.Add(this.ppcertContent);
            this.panel1.Controls.Add(this.ppName);
            this.panel1.Controls.Add(this.ppTrainingCode);
            this.panel1.Controls.Add(this.ppUserID);
            this.panel1.Controls.Add(this.ppTrainingID);
            this.panel1.Location = new System.Drawing.Point(614, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 464);
            this.panel1.TabIndex = 15;
            // 
            // ppCertAttendanceTemp
            // 
            this.ppCertAttendanceTemp.Location = new System.Drawing.Point(26, 268);
            this.ppCertAttendanceTemp.Name = "ppCertAttendanceTemp";
            this.ppCertAttendanceTemp.Size = new System.Drawing.Size(100, 21);
            this.ppCertAttendanceTemp.TabIndex = 14;
            // 
            // ppcertTemplate
            // 
            this.ppcertTemplate.Location = new System.Drawing.Point(26, 137);
            this.ppcertTemplate.Name = "ppcertTemplate";
            this.ppcertTemplate.Size = new System.Drawing.Size(100, 21);
            this.ppcertTemplate.TabIndex = 13;
            this.ppcertTemplate.TextChanged += new System.EventHandler(this.ppcertTemplate_TextChanged);
            // 
            // CertAttendancePrintFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 533);
            this.Controls.Add(this.crystalReportViewer);
            this.Controls.Add(this.panel1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("CertAttendancePrintFrm.IconOptions.Image")));
            this.Name = "CertAttendancePrintFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintPreview";
            this.Load += new System.EventHandler(this.CertParticipationPreviewFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox ppName;
        private System.Windows.Forms.TextBox ppUserID;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
        public System.Windows.Forms.TextBox ppForm;
        private System.Windows.Forms.RichTextBox ppcertContent;
        private System.Windows.Forms.TextBox ppTrainingCode;
        private System.Windows.Forms.TextBox ppTrainingID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ppCertAttendanceTemp;
        private System.Windows.Forms.TextBox ppcertTemplate;
    }
}