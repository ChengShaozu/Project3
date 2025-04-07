using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ChengShaozuProject3
{
    public partial class frmCreative: Form
    {
        private Icon m_Ready = new Icon(SystemIcons.Information , 40 , 40);

        public frmCreative()
        {
            InitializeComponent();
        }

        private void frmCreative_Load(object sender, EventArgs e)
        {
            txtSource.Text = "C:\\Creative\\Source\\";
            txtProcessedFile.Text = "C:\\Creative\\Processed\\";
            txtDest.Text = "C:\\Creative\\Destination\\";
            optGenerateLog.Checked = true;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //source text box validation
            if (!Directory.Exists(txtSource.Text))
            {
                errMessage.SetError(txtSource, "Invalid Source Directory");
                txtSource.Focus();
                tabControl1.SelectedTab = tabSource;
                return;
            }
            else
                errMessage.SetError(txtSource, "");//no error

            //processedFile text box validation
            if (!Directory.Exists(txtProcessedFile.Text))
            {
                errMessage.SetError(txtProcessedFile, "Invalid Processed File Directory");
                txtSource.Focus();
                tabControl1.SelectedTab = tabSource;
                return;
            }
            else
                errMessage.SetError(txtProcessedFile, "");//no error

            //destination text box validation
            if (!Directory.Exists(txtDest.Text))
            {
                errMessage.SetError(txtDest, "Invalid Destination Directory");
                txtDest.Focus();
                tabControl1.SelectedTab = tabDest;
                return;
            }
            else
                errMessage.SetError(txtDest, "");//no error

            //end validation

            //activate watching directory
            watchDir.EnableRaisingEvents = true;//start watching
            watchDir.Path = txtSource.Text;//C:\\Creative\\Source\\
            mnuNotify.Icon = m_Ready;//set icon
            mnuNotify.Visible = true;//show
            this.ShowInTaskbar = false;//hide in task bar
            this.Hide();//hide window

        }

        private void txtSource_KeyUp(object sender, KeyEventArgs e)
        {
            //source
            if (Directory.Exists(txtSource.Text))
            {
                //no error
                txtSource.BackColor = Color.White;
            }
            else
                //error
                txtSource.BackColor = Color.Pink;
        }
        private void txtDest_KeyUp(object sender, KeyEventArgs e)
        {
            //destination
            if (Directory.Exists(txtDest.Text))
            {
                //no error
                txtDest.BackColor = Color.White;
            }
            else
                //error
                txtDest.BackColor = Color.Pink;
        }

        private void txtProcessedFile_KeyUp(object sender, KeyEventArgs e)
        {
            //processed file
            if (Directory.Exists(txtProcessedFile.Text))
            {
                //no error
                txtProcessedFile.BackColor = Color.White;
            }
            else
                //error
                txtProcessedFile.BackColor = Color.Pink;
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }

        private void configuerApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnuNotify.Visible = false;
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuNotify_DoubleClick(object sender, EventArgs e)
        {
            mnuNotify.Visible = false;
            this.ShowInTaskbar = true;
            this.Show();
        }
    }
}
