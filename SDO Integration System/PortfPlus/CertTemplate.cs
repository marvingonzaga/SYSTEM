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

namespace SDO_Integrated_System
{
    public partial class CertTemplate : DevExpress.XtraEditors.XtraForm
    {
        public CertTemplate()
        {
            InitializeComponent();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbcertTemplate_VisibleChanged(object sender, EventArgs e)
        {
            
        }
        private ProjectSoldierAdmin obj1 = (ProjectSoldierAdmin)Application.OpenForms["ProjectSoldierAdmin"];
        private ProjectSoldierSuperAdmin superAdmin = (ProjectSoldierSuperAdmin)Application.OpenForms["ProjectSoldierSuperAdmin"];
        private void rjButton1_Click(object sender, EventArgs e)
        {
            try
            {
                obj1.tbCertTemplate.Text = cbcertTemplate.Text;
                this.Close();
            }
            catch 
            {
                superAdmin.tbCertTemplate.Text = cbcertTemplate.Text;
                this.Close();
            }
        }

        private void cbcertTemplate_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbcertTemplate.Text == "Certificate 1")
            {
                certificateImage.BackgroundImage = Properties.Resources.cert1;
            }
            else
            {
                certificateImage.BackgroundImage = Properties.Resources.cert2;
            }
        }
    }
}