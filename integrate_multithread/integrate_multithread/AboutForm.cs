using System;
using System.Windows.Forms;

namespace integrate_multithread
{
    partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
         }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
